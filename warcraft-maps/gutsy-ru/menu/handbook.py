"""Derive the hero handbook from the actual localized map, not a made-up roster."""
import csv
import re

SHOPS = [
    ('n009', 0, 'Танки'), ('n00A', 1, 'Бойцы'),
    ('n007', 2, 'Маги и техники'), ('n00I', 3, 'Убийцы'),
    ('n00X', 5, 'Стрелки'), ('n00D', 6, 'Поддержка'),
    ('n011', 4, 'Особые'), ('n012', 8, 'Облики'),
]


def profiles(blob):
    result = {}
    current = None
    for line in blob.decode('utf8').splitlines():
        if line.startswith('['):
            current = result.setdefault(line[1:line.index(']')], {})
        elif current is not None and '=' in line and not line.startswith('//'):
            key, value = line.split('=', 1)
            current[key.lower()] = next(csv.reader([value]))
    return result


def slk(blob):
    rows = {}
    x = y = 0
    for line in blob.decode().splitlines():
        if not line.startswith('C;'):
            continue
        mx = re.search(r'(?:^|;)X(\d+)', line)
        my = re.search(r'(?:^|;)Y(\d+)', line)
        if mx:
            x = int(mx[1])
        if my:
            y = int(my[1])
        value = re.search(r'(?:^|;)K("(?:[^"]|"")*"|[^;]+)', line)
        if value:
            rows.setdefault(y, {})[x] = value[1].strip('"').replace('""', '"')
    header = rows[1]
    return {row[1]: {header[k].lower(): v for k, v in row.items()}
            for number, row in rows.items() if number > 1 and 1 in row}


def plain(text):
    text = re.sub(r'(?i)\|c[0-9a-f]{8}|\|r', '', text)
    text = text.replace('|n', '\n').replace('▶', '').replace('▷', '')
    text = re.sub(r'[ \t]+', ' ', text)
    return re.sub(r' *\n *', '\n', text).strip()


def pages(text, limit=480):
    """Split on word boundaries, retaining every word and UTF-8 character."""
    text = plain(text)
    result = []
    current = ''
    for word in re.findall(r'\S+\s*', text):
        assert len(word.encode()) <= limit, ('Oversized unsplittable word', word)
        if current and len((current + word).encode()) > limit:
            result.append(current.rstrip())
            current = ''
        current += word
    if current:
        result.append(current.rstrip())
    assert ' '.join(text.split()) == ' '.join(' '.join(result).split())
    return result or ['Описание отсутствует в исходной карте.']


def extract(st, archive):
    unit = profiles(st.read(archive, 'units\\campaignunitstrings.txt'))
    ability = profiles(st.read(archive, 'units\\campaignabilitystrings.txt'))
    loadout = slk(st.read(archive, 'units\\unitabilities.slk'))
    ability_data = slk(st.read(archive, 'units\\abilitydata.slk'))
    # These are the actual binary tooltip overrides already in the original.
    from catalog import Reader
    reader = Reader(st.read(archive, 'war3map.w3a'))
    assert reader.i() == 2
    for table in range(2):
        for _ in range(reader.i()):
            old, new = reader.read(4), reader.read(4)
            raw = (old if table == 0 else new).decode()
            for _ in range(reader.i()):
                field, kind = reader.read(4), reader.i()
                level, pointer = reader.i(), reader.i()
                if kind == 3:
                    _, _, value = reader.string()
                    if field == b'aub1':
                        values = ability.setdefault(raw, {}).setdefault('ubertip', [])
                        while len(values) < level:
                            values.append('')
                        values[level-1] = value
                else:
                    reader.read(4)
                reader.read(4)

    unresolved = set()
    def resolve(text):
        def substitute(match):
            parts = [p.strip() for p in match[1].split(',')]
            value = ability_data.get(parts[0], {}).get(parts[1].lower()) if len(parts) >= 2 else None
            if value is None:
                unresolved.add(match[0])
                return 'по уровню способности'
            if len(parts) > 2 and parts[2] == '%':
                value = str(float(value)*100).removesuffix('.0')
            return value
        return re.sub(r'<([^<>]+)>', substitute, text)

    heroes = []
    seen = set()
    purchasable = {raw.strip().replace('|n', '') for shop, _, _ in SHOPS for raw in unit[shop]['sellunits']}
    for role, (shop, tavern, category) in enumerate(SHOPS):
        for raw in unit[shop]['sellunits']:
            raw = raw.strip().replace('|n', '')
            assert len(raw) == 4 and raw in unit and raw in loadout, raw
            assert raw not in seen, raw
            seen.add(raw)
            data = unit[raw]
            name = plain(data.get('tip', data.get('name'))[0])
            about = '\n'.join(plain(v) for v in data.get('ubertip', []) if v.strip())
            aliases = [v for v in data.get('dependencyor', []) if len(v) == 4 and v in unit and v in loadout and v not in purchasable]
            skills = []
            codes = ','.join(loadout[form].get('abillist', '')+','+loadout[form].get('heroabillist', '') for form in [raw]+aliases)
            for code in dict.fromkeys(codes.split(',')):
                data = ability.get(code)
                if not data or not data.get('tip') or not any(data.get('ubertip', [])):
                    continue
                position = data.get('buttonpos', [])
                if any(v.strip().startswith('-') for v in position):
                    continue
                title = plain(data['tip'][0])
                if not title or title.startswith('#'):
                    continue
                key = data.get('hotkey', [''])[0].upper()
                descriptions = []
                for rank, description in enumerate(data.get('ubertip', []), 1):
                    if not description.strip():
                        continue
                    heading = f'Ранг {rank}\n' if len(data['ubertip']) > 1 else ''
                    descriptions.extend(pages(heading + resolve(description)))
                skills.append(dict(raw=code, title=title, key=key,
                                   icon=data.get('art', [''])[0], pages=descriptions))
            skills.sort(key=lambda v: ('QWERZDF'.find(v['key']) if len(v['key']) == 1 and v['key'] in 'QWERZDF' else 99))
            primary_keys = set()
            for skill in skills:
                skill['additionalForm'] = skill['key'] in primary_keys if skill['key'] else False
                if skill['key']:
                    primary_keys.add(skill['key'])
            skills.sort(key=lambda v: v['additionalForm'])
            assert skills, (raw, 'No actual skills in handbook')
            heroes.append(dict(raw=raw, name=name, role=role, tavern=tavern,
                               about=pages(about), aliases=aliases, skills=skills))
    return dict(heroes=heroes, roles=[s[2] for s in SHOPS],
                unresolvedOriginalReferences=sorted(unresolved))

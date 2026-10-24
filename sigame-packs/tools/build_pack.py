"""Build the offline SIQ 4 package understood by SIGame and SIQuester."""
from __future__ import annotations
import argparse
import hashlib
import json
from pathlib import Path
import xml.etree.ElementTree as ET
import zipfile

NS = 'http://vladimirkhil.com/ygpackage3.0.xsd'
TYPES_NS = 'http://schemas.openxmlformats.org/package/2006/content-types'

def element(parent, tag, text=None, **attrs):
    node = ET.SubElement(parent, '{' + NS + '}' + tag, {key: str(value) for key, value in attrs.items()})
    if text is not None:
        node.text = text
    return node

def info(parent, *, authors=(), sources=(), comments=None):
    node = element(parent, 'info')
    a = element(node, 'authors')
    for author in authors:
        element(a, 'author', author)
    s = element(node, 'sources')
    for source in sources:
        element(s, 'source', source)
    element(node, 'comments', comments or '')
    return node

def xml_bytes(root):
    ET.indent(root, space='  ')
    return ET.tostring(root, encoding='utf-8', xml_declaration=True)

def build(pack_dir: Path, output_dir: Path):
    pack = json.loads((pack_dir / 'pack.json').read_text(encoding='utf-8'))
    media = json.loads((pack_dir / 'media-sources.json').read_text(encoding='utf-8'))
    by_id = {m['id']: m for m in media}
    if len(by_id) != len(media):
        raise ValueError('Duplicate media IDs')
    ET.register_namespace('', NS)
    root = ET.Element('{' + NS + '}package', {
        'name': pack['name'], 'version': '4', 'id': pack['id'],
        'restriction': pack['restriction'], 'date': pack['date'],
        'difficulty': str(pack['difficulty']), 'language': pack['language'],
    })
    tags = element(root, 'tags')
    for tag in ['Видеоигры', 'Аниме', 'Warcraft', 'Terraria', 'Для друзей']:
        element(tags, 'tag', tag)
    info(root, authors=pack['authors'], comments=pack['description'])
    rounds = element(root, 'rounds')
    round_node = element(rounds, 'round', name=pack['round_name'], type='standart')
    info(round_node)
    themes = element(round_node, 'themes')
    used = set()
    question_count = 0
    for theme in pack['themes']:
        theme_node = element(themes, 'theme', name=theme['name'])
        info(theme_node)
        questions = element(theme_node, 'questions')
        if [q['price'] for q in theme['questions']] != [100, 200, 300, 400, 500]:
            raise ValueError('Every theme must have prices 100–500')
        for question in theme['questions']:
            question_count += 1
            if not question['prompt'].strip() or not question['answers'] or any(not a.strip() for a in question['answers']):
                raise ValueError('Question has an empty prompt or answer')
            q = element(questions, 'question', price=question['price'])
            m = by_id[question['media']] if question.get('media') else None
            comments = [question.get('note', '')]
            if m:
                comments.append(m['credit'])
            info(q, sources=[m['source']['url']] if m else [], comments='\n'.join(filter(None, comments)))
            element(q, 'type', name='simple')
            scenario = element(q, 'scenario')
            if m:
                # The host sees the instruction as a replica while the picture/audio
                # remains the question on the game screen.
                element(scenario, 'atom', question['prompt'], type='say')
                media_type = 'image' if m['path'].startswith('Images/') else 'voice'
                element(scenario, 'atom', '@' + Path(m['path']).name, type=media_type)
                used.add(m['id'])
            else:
                element(scenario, 'atom', question['prompt'])
            right = element(q, 'right')
            for answer in question['answers']:
                element(right, 'answer', answer)
            element(q, 'wrong')
    if len(pack['themes']) != 6 or question_count != 30 or len(used) != 25 or used != set(by_id):
        raise ValueError('The pack must have 6 themes, 30 questions and 25 referenced media')
    output_dir.mkdir(parents=True, exist_ok=True)
    path = output_dir / 'Bro-Pack-01.siq'
    types = ET.Element('Types', xmlns=TYPES_NS)
    for extension, mime in [('xml', 'si/xml'), ('jpg', 'image/jpeg'), ('mp3', 'audio/mpeg')]:
        ET.SubElement(types, 'Default', Extension=extension, ContentType=mime)
    entries = {'content.xml': xml_bytes(root), '[Content_Types].xml': xml_bytes(types)}
    # Legacy text stores are present even though metadata is written inline.
    entries['Texts/authors.xml'] = b'<?xml version="1.0" encoding="utf-8"?><authors />'
    entries['Texts/sources.xml'] = b'<?xml version="1.0" encoding="utf-8"?><sources />'
    for m in media:
        relative = Path(m['path'])
        if relative.is_absolute() or '..' in relative.parts or relative.parts[0] not in ('Images', 'Audio'):
            raise ValueError('Unsafe media path')
        data = (pack_dir / 'media' / relative).read_bytes()
        if len(data) != m['bytes'] or hashlib.sha256(data).hexdigest() != m['sha256']:
            raise ValueError('Media verification failed: ' + m['id'])
        entries[m['path']] = data
    with zipfile.ZipFile(path, 'w', zipfile.ZIP_DEFLATED, compresslevel=9) as archive:
        for name, data in sorted(entries.items()):
            zi = zipfile.ZipInfo(name, date_time=(2026, 10, 24, 12, 0, 0))
            zi.compress_type = zipfile.ZIP_DEFLATED
            zi.external_attr = 0o100644 << 16
            archive.writestr(zi, data, compresslevel=9)
    checksum = hashlib.sha256(path.read_bytes()).hexdigest()
    (output_dir / (path.name + '.sha256')).write_text(checksum + '  ' + path.name + '\n', encoding='ascii')
    (output_dir / 'How-to-play.txt').write_text((pack_dir / 'HOW-TO-PLAY.txt').read_text(encoding='utf-8'), encoding='utf-8-sig')
    result = {'file': path.name, 'bytes': path.stat().st_size, 'sha256': checksum,
              'rounds': 1, 'themes': 6, 'questions': question_count, 'images': 10, 'audio': 15,
              'format': 4, 'external_question_media': 0}
    (output_dir / 'build-info.json').write_text(json.dumps(result, indent=2) + '\n', encoding='utf-8')
    print(json.dumps(result, ensure_ascii=False, indent=2))
    return path

if __name__ == '__main__':
    parser = argparse.ArgumentParser()
    parser.add_argument('--pack', type=Path, default=Path(__file__).resolve().parent.parent / 'friends-01')
    parser.add_argument('--output', type=Path, default=Path('dist/sigame-pack'))
    args = parser.parse_args()
    build(args.pack, args.output)

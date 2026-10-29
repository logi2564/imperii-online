"""Keep descriptions in the original inline TXT/object format of this map.

FIX1's added WTS object overrides were not reliable in the native client.
Long descriptions use reviewed wording or remove redundant formatting;
no byte/character truncation or new gameplay object overrides are needed.
"""
import re
from collections import Counter

CELL_LIMIT = 1023
LINE_LIMIT = 4095
TOOLTIP_FIELDS = {
    'tip': b'atp1', 'ubertip': b'aub1', 'researchtip': b'aret',
    'researchubertip': b'arut', 'untip': b'aut1', 'unubertip': b'auu1',
}
COLORS = re.compile(r'(?i)\|c[0-9a-f]{8}|\|r')
NUMBERS = re.compile(r'[+\-]?(?:\d+(?:\.\d+)?|\.\d+)%?')
SHORT_WORDS = {
    'Технический Физический урон': 'Физ. урон',
    'Технический физический урон': 'Физ. урон',
    'Технические Физические повреждения': 'Физ. урон',
    'Физический урон навыка': 'Физ. урон',
    'Навык физического урона': 'Физ. урон',
    'Абсолютное пробивание урона': 'Чистый пробивной урон',
    'Проникающий физический урон': 'Пробивной физ. урон',
    'Мгновенные навыки произнесения заклинаний': 'Мгновенно',
    'Навыки мгновенного произнесения заклинаний': 'Мгновенно',
    'Навыки немедленного произнесения заклинаний': 'Мгновенно',
    'Навык мгновенного применения': 'Мгновенно',
    'Мгновенный навык': 'Мгновенно', 'Навык с выбором точки': 'На точку',
    'Направленный навык': 'Направленный', 'Пассивный эффект': 'Пассивно',
    'Мгновенное применение': 'Мгновенно',
    'Интеллект': 'Инт.', 'Инлектелт': 'Инт.', 'Ловкость': 'Ловк.',
    'Максимальный': 'Макс.', 'Максимальная': 'Макс.',
    'Максимальное': 'Макс.', 'Максимального': 'Макс.',
    'Максимальному': 'Макс.', 'максимальное': 'макс.',
    'максимальный': 'макс.', 'максимальная': 'макс.',
    'Перезарядка': 'КД', 'Перезарядку': 'КД',
    'перезарядки': 'КД', 'перезарядка': 'КД', 'перезарядку': 'КД',
    'секунд': 'сек.', 'секунды': 'сек.', 'секунду': 'сек.',
    'секунда': 'сек.', 'Дальность действия': 'Дальность',
    'Продолжительность': 'Длительность',
}


def tooltip_fingerprint(text):
    """Retain every number (including repeated values), token and hotkey."""
    text = COLORS.sub('', text).replace('|n', ' ')
    text = re.sub(r'(?i)\bc\s*000080\s*ff|\bc\s*00\s*ffff\s*00', ' ', text)
    numbers = Counter(v.lstrip('+-') for v in NUMBERS.findall(text))
    tokens = Counter(re.findall(r'<[^<>\r\n]+>|%(?:\d+\$)?[+\-0 #]*(?:\d+|\*)?(?:\.(?:\d+|\*))?[diouxXeEfFgGcs%]', text))
    hotkeys = Counter(re.findall(r'\(([A-Z])\)', text))
    return numbers, tokens, hotkeys


def inline_text(text, reviewed, force=False):
    before = text
    if force or len(text.encode()) > CELL_LIMIT:
        if text in reviewed:
            text = reviewed[text]
        else:
            text = COLORS.sub('', text)
            text = re.sub(r'[ \t]+', ' ', text)
            text = re.sub(r' *\|n *', '|n', text)
            text = re.sub(r'(?:\|n){3,}', '|n|n', text).strip()
            for old, new in sorted(SHORT_WORDS.items(), key=lambda item: -len(item[0])):
                text = re.sub(re.escape(old) + r'(?![а-яА-Я])', lambda _: new, text)
    # Legacy TXT quote parsing differs from modern RFC 4180 CSV escaping.
    opening = True
    result = []
    for char in text:
        if char == '"':
            char = '«' if opening else '»'
            opening = not opening
        result.append(char)
    text = ''.join(result)
    assert text.strip() or not before.strip(), 'Nonempty tooltip became empty'
    assert len(text.encode()) <= CELL_LIMIT, ('Tooltip needs reviewed wording', len(text.encode()), before)
    assert tooltip_fingerprint(text) == tooltip_fingerprint(before), ('Tooltip mechanics changed', before, text)
    return text

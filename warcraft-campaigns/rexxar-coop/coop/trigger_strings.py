"""Warcraft trigger strings, including the editor's sound-path comments."""
import re


def parse_wts(data):
    """Read WTS entries without treating comments inside a value as syntax.

    World Editor writes a // Sound\\Dialogue... line between STRING and {.
    Those are normal entries, especially the campaign's spoken dialogue.
    Fail on malformed/missing entries rather than shipping visible references.
    """
    text = data.decode('utf-8-sig') if isinstance(data, bytes) else data.lstrip('\ufeff')
    lines = text.replace('\r\n', '\n').replace('\r', '\n').split('\n')
    result = {}
    pos = 0
    while pos < len(lines):
        line = lines[pos].strip()
        pos += 1
        if not line or line.startswith('//'):
            continue
        match = re.fullmatch(r'STRING\s+(\d+)', line)
        if not match:
            raise ValueError(f'Invalid WTS header at line {pos}: {line!r}')
        key = int(match[1])
        if key in result:
            raise ValueError(f'Duplicate WTS entry {key}')
        while pos < len(lines) and (not lines[pos].strip() or lines[pos].lstrip().startswith('//')):
            pos += 1
        if pos == len(lines):
            raise ValueError(f'Missing opening brace for WTS entry {key}')
        if lines[pos].strip() != '{':
            raise ValueError(f'Missing opening brace for WTS entry {key}')
        pos += 1
        start = pos
        while pos < len(lines) and lines[pos].strip() != '}':
            if re.fullmatch(r'STRING\s+\d+', lines[pos].strip()):
                raise ValueError(f'Unclosed WTS entry {key} before line {pos + 1}')
            pos += 1
        if pos == len(lines):
            raise ValueError(f'Unclosed WTS entry {key}')
        result[key] = '\n'.join(lines[start:pos]).encode('utf-8')
        pos += 1
    return result


def parse_campaign_wts(data, mission):
    """Repair two known damaged delimiters in the supplied OrcX01 export.

    Do this explicitly: the old regex silently swallowed entry 121 into 120.
    No story dialogue or sound path is replaced or invented here.
    """
    if mission == 'OrcX01':
        text = data.decode('utf-8-sig').replace('\r\n', '\n')
        text = text.replace('|r"\nSTRING 121\n', '|r"\n}\n\nSTRING 121\n')
        text = re.sub(r'(?m)^(STRING 323\n)(Постройте ферму\.,[^\n]+)\n\n(?=STRING 324\n)',
                      r'\1{\n\2\n}\n\n', text)
        data = text.encode('utf-8')
    return parse_wts(data)


def write_wts(strings):
    return ''.join(f'STRING {key}\n{{\n{value.decode("utf-8")}\n}}\n\n'
                   for key,value in sorted(strings.items())).encode('utf-8')


def resolve_string(value, strings):
    """Resolve exact WTS references and reject absent text at build time."""
    is_bytes = isinstance(value, bytes)
    if not is_bytes and not isinstance(value, str):
        return value
    # Also accepts the accidentally double-quoted references of old builds.
    pattern = r'(?:TRIGSTR_(\d+)|"TRIGSTR_(\d+)"|\\"TRIGSTR_(\d+)\\")'
    match = re.fullmatch(pattern.encode() if is_bytes else pattern, value)
    if not match:
        return value
    key = int(next(group for group in match.groups() if group is not None))
    if key not in strings:
        raise ValueError(f'Missing trigger string TRIGSTR_{key}')
    resolved = strings[key]
    return resolved if is_bytes else resolved.decode('utf-8')

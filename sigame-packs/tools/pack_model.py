"""Pack metadata shared by the builder and deliverable checks."""
from pathlib import Path

LEGACY_COUNTS = {'rounds': 1, 'themes_per_round': 6, 'questions': 30, 'images': 10, 'audio': 15}

def rounds_of(pack):
    return pack['rounds'] if 'rounds' in pack else [
        {'name': pack['round_name'], 'price_step': 100, 'themes': pack['themes']}]

def expected_counts(pack):
    counts = dict(pack.get('expectations', LEGACY_COUNTS))
    if set(counts) != set(LEGACY_COUNTS) or any(not isinstance(n, int) or n < 1 for n in counts.values()):
        raise ValueError('Invalid expected game board')
    if counts['rounds'] * counts['themes_per_round'] * 5 != counts['questions']:
        raise ValueError('Question count does not fit the game board')
    return counts

def filename_of(pack):
    filename = pack.get('filename', 'Bro-Pack-01.siq')
    if Path(filename).name != filename or not filename.endswith('.siq') or not filename.isascii():
        raise ValueError('Invalid output filename')
    return filename

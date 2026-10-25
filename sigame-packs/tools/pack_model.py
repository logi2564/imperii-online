"""Pack metadata shared by the builder and deliverable checks."""
from pathlib import Path

LEGACY_COUNTS = {'rounds': 1, 'themes_per_round': 6, 'questions': 30, 'images': 10, 'audio': 15}

def rounds_of(pack):
    return pack['rounds'] if 'rounds' in pack else [
        {'name': pack['round_name'], 'price_step': 100, 'themes': pack['themes']}]

def round_type(round_spec):
    kind = round_spec.get('type', 'standart')
    if kind not in ('standart', 'final'):
        raise ValueError('Unknown round type')
    return kind

def expected_counts(pack):
    counts = dict(pack.get('expectations', LEGACY_COUNTS))
    if set(counts) != set(LEGACY_COUNTS) or any(not isinstance(n, int) or n < 1 for n in counts.values()):
        raise ValueError('Invalid expected game board')
    rounds = rounds_of(pack)
    if len(rounds) != counts['rounds']:
        raise ValueError('Wrong number of rounds')
    final_positions = [i for i, r in enumerate(rounds) if round_type(r) == 'final']
    if final_positions and final_positions != [len(rounds) - 1]:
        raise ValueError('Only the last round may be a final')
    slots = 0
    for r in rounds:
        if round_type(r) == 'final':
            if len(r['themes']) != 1 or len(r['themes'][0]['questions']) != 1:
                raise ValueError('The final must have exactly one theme and one question')
            slots += 1
        else:
            if len(r['themes']) != counts['themes_per_round']:
                raise ValueError('Invalid standard round board')
            slots += counts['themes_per_round'] * 5
    if slots != counts['questions']:
        raise ValueError('Question count does not fit the game board')
    return counts

def filename_of(pack):
    filename = pack.get('filename', 'Bro-Pack-01.siq')
    if Path(filename).name != filename or not filename.endswith('.siq') or not filename.isascii():
        raise ValueError('Invalid output filename')
    return filename

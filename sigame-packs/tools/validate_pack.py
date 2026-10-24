"""Check the actual deliverable, embedded references, picture decoding and audio."""
import argparse
import array
import hashlib
import io
import json
from pathlib import Path
import subprocess
import tempfile
import xml.etree.ElementTree as ET
import zipfile

from lxml import etree
from PIL import Image

from pack_model import expected_counts, rounds_of

NS = {'q': 'http://vladimirkhil.com/ygpackage3.0.xsd'}

def validate(path: Path, pack_dir: Path):
    pack = json.loads((pack_dir / 'pack.json').read_text(encoding='utf-8'))
    counts = expected_counts(pack)
    round_specs = rounds_of(pack)
    source_media = json.loads((pack_dir / 'media-sources.json').read_text(encoding='utf-8'))
    expected = {m['path']: m for m in source_media}
    results = []
    with zipfile.ZipFile(path) as archive, tempfile.TemporaryDirectory(prefix='sigame-check-') as temp:
        if archive.testzip() is not None:
            raise ValueError('Archive CRC failure')
        names = archive.namelist()
        if len(names) != len(set(names)) or any('..' in Path(n).parts or Path(n).is_absolute() for n in names):
            raise ValueError('Invalid archive entries')
        xml = archive.read('content.xml')
        schema_path = Path(__file__).resolve().parent / 'schema' / 'ygpackage3.1.xsd'
        schema = etree.XMLSchema(etree.parse(str(schema_path)))
        schema.assertValid(etree.fromstring(xml))
        root = ET.fromstring(xml)
        rounds = root.findall('./q:rounds/q:round', NS)
        themes = root.findall('./q:rounds/q:round/q:themes/q:theme', NS)
        if len(rounds) != counts['rounds'] or any(len(r.findall('./q:themes/q:theme', NS)) != counts['themes_per_round'] for r in rounds):
            raise ValueError('Wrong round or theme count')
        count = 0
        references = []
        theme_steps = [r.get('price_step', 100) for r in round_specs for _ in r['themes']]
        signatures = set()
        for theme, price_step in zip(themes, theme_steps, strict=True):
            questions = theme.findall('./q:questions/q:question', NS)
            if [int(q.attrib['price']) for q in questions] != [price_step * n for n in range(1, 6)]:
                raise ValueError('Invalid game board')
            for q in questions:
                count += 1
                answers = q.findall('./q:right/q:answer', NS)
                if not answers or any(not (a.text or '').strip() for a in answers):
                    raise ValueError('Missing answer')
                body = q.find('./q:scenario', NS)
                signature = ET.tostring(body, encoding='utf-8')
                if signature in signatures:
                    raise ValueError('Repeated question scenario')
                signatures.add(signature)
                for atom in q.findall('./q:scenario/q:atom', NS):
                    kind = atom.attrib.get('type', 'text')
                    if kind not in ('image', 'voice'):
                        continue
                    if not (atom.text or '').startswith('@'):
                        raise ValueError('Question depends on external media')
                    folder = 'Images/' if kind == 'image' else 'Audio/'
                    references.append(folder + atom.text[1:])
        if count != counts['questions'] or len(references) != counts['images'] + counts['audio'] or len(references) != len(set(references)) or set(references) != set(expected):
            raise ValueError('Missing or unused question media')
        if {n for n in names if n.startswith(('Images/', 'Audio/'))} != set(expected):
            raise ValueError('Archive media does not match the source manifest')
        if len({m['sha256'] for m in source_media}) != len(source_media):
            raise ValueError('Repeated media content')
        if sum(n.startswith('Images/') for n in expected) != counts['images'] or sum(n.startswith('Audio/') for n in expected) != counts['audio']:
            raise ValueError('Wrong mix of question media')
        for name, spec in expected.items():
            data = archive.read(name)
            if len(data) != spec['bytes'] or hashlib.sha256(data).hexdigest() != spec['sha256']:
                raise ValueError('Changed or corrupt media: ' + name)
            if name.startswith('Images/'):
                with Image.open(io.BytesIO(data)) as image:
                    image.load()
                    if image.width < 640 or image.height < 350:
                        raise ValueError('Unreadable image size')
                    colors = image.convert('RGB').resize((128, 72)).getcolors(128 * 72)
                    if colors is None or len(colors) < 150:
                        raise ValueError('Blank image')
                    results.append({'file': name, 'width': image.width, 'height': image.height})
            else:
                local = Path(temp) / Path(name).name
                local.write_bytes(data)
                metadata = json.loads(subprocess.check_output([
                    'ffprobe', '-v', 'error', '-show_entries', 'format=duration:format_tags:stream=codec_name,channels,sample_rate',
                    '-of', 'json', str(local)]))
                seconds = float(metadata['format']['duration'])
                if not 2 <= seconds <= 15:
                    raise ValueError('Unexpected audio duration')
                if set(metadata['format'].get('tags', {})) & {'title', 'artist', 'album', 'comment'}:
                    raise ValueError('Answer leaked in audio metadata')
                decoded = subprocess.check_output(['ffmpeg', '-v', 'error', '-i', str(local),
                    '-f', 's16le', '-ac', '1', '-ar', '8000', '-'], timeout=30)
                samples = array.array('h', decoded)
                peak = max(abs(s) for s in samples) if samples else 0
                if peak < 100 or peak >= 32767:
                    raise ValueError('Silent or clipped audio')
                results.append({'file': name, 'seconds': round(seconds, 3), 'peak_pcm': peak})
    report = {'result': 'PASS', 'questions': count, 'themes': len(themes), 'rounds': len(rounds),
              'xml_schema': 'official ygpackage3.1.xsd', 'offline_media': len(references), 'media': results}
    path.with_name('validation.json').write_text(json.dumps(report, indent=2) + '\n', encoding='utf-8')
    print(f"PASS: official XML schema; {count} questions in {len(rounds)} rounds; all {counts['images']} pictures and {counts['audio']} audio files decode; all media embedded and distinct.")

if __name__ == '__main__':
    parser = argparse.ArgumentParser()
    parser.add_argument('file', type=Path)
    parser.add_argument('--pack', type=Path, default=Path(__file__).resolve().parent.parent / 'friends-120')
    args = parser.parse_args()
    validate(args.file, args.pack)

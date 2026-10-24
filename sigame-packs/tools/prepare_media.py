"""Prepare short, offline quiz media from identified public sources."""
import concurrent.futures
import hashlib
import json
from pathlib import Path
import subprocess
import urllib.request
import zipfile

ROOT = Path('dist/sigame-media')
ROOT.mkdir(parents=True, exist_ok=True)
CACHE = Path('dist/sigame-source-cache')
CACHE.mkdir(parents=True, exist_ok=True)
records = []

def download(url, destination, limit=180_000_000):
    if destination.exists():
        return
    req = urllib.request.Request(url, headers={'User-Agent': 'Mozilla/5.0 (compatible; FriendsQuiz/1.0)'})
    with urllib.request.urlopen(req, timeout=65) as response, destination.open('wb') as output:
        count = 0
        while chunk := response.read(1024 * 1024):
            count += len(chunk)
            if count > limit:
                raise ValueError('source exceeds media size limit')
            output.write(chunk)

def ffmpeg(*args):
    subprocess.run(['ffmpeg', '-hide_banner', '-loglevel', 'error', '-y', *map(str, args)], check=True, timeout=180)

def anime(entry):
    key, stem = entry
    errors = []
    source = CACHE / (key + '.webm')
    for host in ['https://v.animethemes.moe/', 'https://videos.animethemes.moe/']:
        url = host + stem + '.webm'
        try:
            download(url, source)
            for time in [12, 24, 42, 60, 75]:
                ffmpeg('-ss', time, '-i', source, '-frames:v', '1', '-vf', 'scale=1280:-2', '-q:v', '3', ROOT / (key + '-' + str(time) + '.jpg'))
            ffmpeg('-ss', 30, '-i', source, '-t', 14, '-vn', '-map_metadata', '-1', '-af', 'loudnorm=I=-18:TP=-2:LRA=9,afade=t=in:d=0.12,afade=t=out:st=13.5:d=0.5', '-ar', 44100, '-ac', 2, '-b:a', '160k', ROOT / (key + '.mp3'))
            return {'key': key, 'url': url, 'source_sha256': hashlib.sha256(source.read_bytes()).hexdigest(), 'ok': True}
        except Exception as error:
            errors.append(str(error))
            source.unlink(missing_ok=True)
    return {'key': key, 'ok': False, 'errors': errors}

ANIME = [('naruto', 'NarutoShippuuden-OP3'), ('tokyo-ghoul', 'TokyoGhoul-OP1'),
         ('attack-on-titan', 'ShingekiNoKyojin-OP1'), ('fullmetal', 'FullmetalAlchemistBrotherhood-OP1'),
         ('evangelion', 'NeonGenesisEvangelion-OP1'), ('one-piece', 'OnePiece-OP1'),
         ('death-note', 'DeathNote-OP1'), ('demon-slayer', 'KimetsuNoYaiba-OP1')]
with concurrent.futures.ThreadPoolExecutor(max_workers=4) as executor:
    records.extend(executor.map(anime, ANIME))

for key, appid in [('terraria', '105600'), ('portal2', '620'), ('stardew', '413150')]:
    url = 'https://store.steampowered.com/api/appdetails?appids=' + appid
    try:
        data = json.load(urllib.request.urlopen(url, timeout=40))[appid]['data']
        screenshot = data['screenshots'][0]['path_full']
        original = CACHE / (key + '.jpg')
        download(screenshot, original, 10_000_000)
        ffmpeg('-i', original, '-frames:v', '1', '-vf', 'scale=1280:-2', '-q:v', '3', ROOT / (key + '-screen.jpg'))
        records.append({'key': key + '-screen', 'url': screenshot, 'metadata_url': url,
                        'name': data['name'], 'source_sha256': hashlib.sha256(original.read_bytes()).hexdigest(), 'ok': True})
    except Exception as error:
        records.append({'key': key, 'ok': False, 'error': str(error)})

(ROOT / 'sources.json').write_text(json.dumps(records, ensure_ascii=False, indent=2), encoding='utf-8')
with zipfile.ZipFile('dist/SIGame-media-review.zip', 'w', zipfile.ZIP_DEFLATED, compresslevel=6) as archive:
    for path in sorted(ROOT.iterdir()):
        archive.write(path, path.name)
for record in records:
    print(json.dumps(record, ensure_ascii=False))

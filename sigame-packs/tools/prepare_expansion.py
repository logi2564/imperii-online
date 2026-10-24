"""Gather distinct short clips and frame candidates for the 120-question edition."""
import concurrent.futures
import hashlib
import json
from pathlib import Path
import subprocess
import time
import urllib.request
import zipfile

ROOT = Path('dist/sigame-expanded-media')
CACHE = Path('dist/sigame-expanded-cache')
ROOT.mkdir(parents=True, exist_ok=True)
CACHE.mkdir(parents=True, exist_ok=True)

ANIME = {
 'bleach': ['Bleach-OP1'], 'sao': ['SwordArtOnline-OP1'],
 'cowboy': ['CowboyBebop-OP1'], 'code-geass': ['CodeGeass-OP1'],
 'one-punch': ['OnePunchMan-OP1'], 'jujutsu': ['JujutsuKaisen-OP1'],
 'chainsaw': ['ChainsawMan-OP1'], 'mob': ['MobPsycho100-OP1'],
 'no-game': ['NoGameNoLife-OP1'], 'steins': ['SteinsGate-OP1'],
 'hunter': ['HunterHunter2011-OP1', 'HunterXHunter2011-OP1'],
 'gurren': ['TengenToppaGurrenLagann-OP1'], 'fairy-tail': ['FairyTail-OP1'],
 'demon': ['KimetsuNoYaiba-OP1'], 'spy': ['SpyXFamily-OP1'],
 'dandadan': ['Dandadan-OP1'], 'dragon-ball': ['DragonBallZ-OP1'],
 'boku-hero': ['BokuNoHeroAcademia-OP1'],
}
GAMES = {
 'counter-strike': '730', 'dota': '570', 'left4dead': '550', 'half-life': '220',
 'witcher': '292030', 'skyrim': '489830', 'elden-ring': '1245620', 'hollow-knight': '367520',
 'undertale': '391540', 'dont-starve': '322330', 'factorio': '427520', 'cuphead': '268910',
 'celeste': '504230', 'dead-cells': '588650', 'hades': '1145360',
}

def download(url, target, limit=180_000_000):
    target.unlink(missing_ok=True)
    request = urllib.request.Request(url, headers={'User-Agent': 'Mozilla/5.0 (FriendsQuiz media preparation)'})
    with urllib.request.urlopen(request, timeout=70) as response, target.open('wb') as output:
        total = 0
        while chunk := response.read(1024 * 1024):
            total += len(chunk)
            if total > limit:
                raise ValueError('media source exceeds size limit')
            output.write(chunk)

def convert(*args):
    subprocess.run(['ffmpeg', '-hide_banner', '-loglevel', 'error', '-y', *map(str, args)], check=True, timeout=180)

def anime(entry):
    key, stems = entry
    errors = []
    for stem in stems:
        url = 'https://v.animethemes.moe/' + stem + '.webm'
        source = CACHE / (key + '.webm')
        for attempt in range(2):
            try:
                download(url, source)
                for second in [24, 42, 60, 75]:
                    convert('-ss', second, '-i', source, '-frames:v', 1, '-vf', 'scale=1280:-2', '-q:v', 3, '-map_metadata', -1, ROOT / f'{key}-{second}.jpg')
                convert('-ss', 30, '-i', source, '-t', 14, '-vn', '-map_metadata', -1,
                        '-af', 'loudnorm=I=-18:TP=-2:LRA=9,afade=t=in:d=0.1,afade=t=out:st=13.5:d=0.5',
                        '-ar', 44100, '-ac', 2, '-b:a', '160k', ROOT / (key + '.mp3'))
                result = {'key': key, 'url': url, 'source_sha256': hashlib.sha256(source.read_bytes()).hexdigest(), 'ok': True}
                print(json.dumps(result), flush=True)
                return result
            except Exception as error:
                errors.append(str(error))
                time.sleep(1)
    return {'key': key, 'ok': False, 'errors': errors}

def game(entry):
    key, appid = entry
    metadata_url = 'https://store.steampowered.com/api/appdetails?appids=' + appid
    try:
        request = urllib.request.Request(metadata_url, headers={'User-Agent': 'FriendsQuiz/1.0'})
        with urllib.request.urlopen(request, timeout=45) as response:
            data = json.load(response)[appid]['data']
        url = data['screenshots'][0]['path_full']
        source = CACHE / (key + '.jpg')
        download(url, source, 15_000_000)
        convert('-i', source, '-frames:v', 1, '-vf', 'scale=1280:-2', '-q:v', 3, '-map_metadata', -1, ROOT / (key + '-screen.jpg'))
        result = {'key': key + '-screen', 'url': url, 'metadata_url': metadata_url, 'name': data['name'],
                  'source_sha256': hashlib.sha256(source.read_bytes()).hexdigest(), 'ok': True}
        print(json.dumps(result), flush=True)
        return result
    except Exception as error:
        return {'key': key, 'ok': False, 'error': str(error)}

with concurrent.futures.ThreadPoolExecutor(max_workers=5) as executor:
    records = list(executor.map(anime, ANIME.items()))
with concurrent.futures.ThreadPoolExecutor(max_workers=3) as executor:
    records.extend(executor.map(game, GAMES.items()))
(ROOT / 'sources.json').write_text(json.dumps(records, ensure_ascii=False, indent=2), encoding='utf-8')
with zipfile.ZipFile('dist/SIGame-120-media-review.zip', 'w', zipfile.ZIP_DEFLATED, compresslevel=6) as archive:
    for path in sorted(ROOT.iterdir()):
        archive.write(path, path.name)
print(json.dumps(records, ensure_ascii=False, indent=2))

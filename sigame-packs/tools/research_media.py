"""Fetch public source metadata; never execute anything from a media source."""
import concurrent.futures
import json
from pathlib import Path
import urllib.request

SOURCES = {
    'terraria': 'https://store.steampowered.com/api/appdetails?appids=105600',
    'portal2': 'https://store.steampowered.com/api/appdetails?appids=620',
    'stardew': 'https://store.steampowered.com/api/appdetails?appids=413150',
}
for slug in ['naruto', 'naruto_shippuuden', 'tokyo_ghoul', 'shingeki_no_kyojin',
             'fullmetal_alchemist_brotherhood', 'neon_genesis_evangelion',
             'one_piece', 'death_note', 'kimetsu_no_yaiba']:
    SOURCES[slug] = ('https://api.animethemes.moe/anime?filter[slug]=' + slug
        + '&include=animethemes.animethemeentries.videos,animethemes.song.artists')

out = Path('dist/sigame-research')
out.mkdir(parents=True, exist_ok=True)
def fetch(entry):
    name, url = entry
    try:
        req = urllib.request.Request(url, headers={'User-Agent': 'FriendsQuiz/1.0 (media-source-research)'})
        with urllib.request.urlopen(req, timeout=45) as response:
            raw = response.read(5_000_000)
        data = json.loads(raw)
        (out / (name + '.json')).write_text(json.dumps(data, ensure_ascii=False, indent=2), encoding='utf-8')
        return {'source': name, 'url': url, 'ok': True}
    except Exception as error:
        return {'source': name, 'url': url, 'ok': False, 'error': str(error)}

with concurrent.futures.ThreadPoolExecutor(max_workers=4) as executor:
    results = list(executor.map(fetch, SOURCES.items()))
(out / 'status.json').write_text(json.dumps(results, indent=2), encoding='utf-8')
print(json.dumps(results, indent=2))

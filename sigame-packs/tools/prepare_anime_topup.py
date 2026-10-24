"""Find working original anime excerpts for the expanded quiz; no placeholder media."""
import concurrent.futures
import hashlib
import json
from pathlib import Path
import subprocess
import urllib.request
import zipfile

ROOT = Path('dist/sigame-anime-extra')
CACHE = Path('dist/sigame-anime-extra-cache')
ROOT.mkdir(parents=True, exist_ok=True)
CACHE.mkdir(parents=True, exist_ok=True)
CANDIDATES = {
 'mob': ('mob_psycho_100', ['MobPsycho100-OP1v2', 'MobPsycho100-OP1v1']),
 'no-game': ('no_game_no_life', ['NoGameNoLife-OP1v2', 'NoGameNoLife-OP1v1']),
 'steins': ('steinsgate', ['SteinsGate-OP1v2', 'SteinsGate-OP1v1']),
 'hunter': ('hunter_x_hunter_2011', ['HunterHunter2011-OP1v2', 'HunterHunter2011-OP1v1']),
 'gurren': ('tengen_toppa_gurren_lagann', ['TengenToppaGurrenLagann-OP1v2', 'TengenToppaGurrenLagann-OP1v1']),
 'samurai': ('samurai_champloo', ['SamuraiChamploo-OP1']),
 'elfen': ('elfen_lied', ['ElfenLied-OP1']),
 'hellsing': ('hellsing', ['Hellsing-OP1']),
 'black-lagoon': ('black_lagoon', ['BlackLagoon-OP1']),
 'trigun': ('trigun', ['Trigun-OP1']),
 'angel-beats': ('angel_beats', ['AngelBeats-OP1']),
 'death-parade': ('death_parade', ['DeathParade-OP1']),
 'ergo-proxy': ('ergo_proxy', ['ErgoProxy-OP1']),
 'soul-eater': ('soul_eater', ['SoulEater-OP1']),
}

def fetch_bytes(url, limit=180_000_000):
    req = urllib.request.Request(url, headers={'User-Agent': 'Mozilla/5.0 (FriendsQuiz/1.0)'})
    with urllib.request.urlopen(req, timeout=65) as r:
        data = r.read(limit + 1)
        if len(data) > limit: raise ValueError('source exceeds size limit')
        return data

def find_videos(value):
    found=[]
    if isinstance(value,dict):
        for k,v in value.items():
            if k=='link' and isinstance(v,str) and v.startswith('https://') and v.endswith('.webm'):
                found.append(v)
            elif isinstance(v,(dict,list)):found.extend(find_videos(v))
    elif isinstance(value,list):
        for v in value:found.extend(find_videos(v))
    return found

def collect(entry):
    key,(slug,stems)=entry
    urls=[];errors=[]
    try:
        api='https://api.animethemes.moe/anime/'+slug+'?include=animethemes.animethemeentries.videos'
        data=json.loads(fetch_bytes(api,5_000_000));(ROOT/(key+'-metadata.json')).write_text(json.dumps(data,ensure_ascii=False),encoding='utf-8')
        urls=[u for u in find_videos(data) if '-OP1' in u]
    except Exception as error:errors.append(str(error))
    urls.extend('https://v.animethemes.moe/'+s+'.webm' for s in stems)
    for url in dict.fromkeys(urls):
        try:
            raw=fetch_bytes(url);source=CACHE/(key+'.webm');source.write_bytes(raw)
            def ff(*args):subprocess.run(['ffmpeg','-hide_banner','-loglevel','error','-y',*map(str,args)],check=True,timeout=180)
            for second in [24,42,60,75]:
                ff('-ss',second,'-i',source,'-frames:v',1,'-vf','scale=1280:-2','-q:v',3,'-map_metadata',-1,ROOT/f'{key}-{second}.jpg')
            ff('-ss',30,'-i',source,'-t',14,'-vn','-map_metadata',-1,'-af','loudnorm=I=-18:TP=-2:LRA=9,afade=t=in:d=0.1,afade=t=out:st=13.5:d=0.5','-ar',44100,'-ac',2,'-b:a','160k',ROOT/(key+'.mp3'))
            record={'key':key,'url':url,'source_sha256':hashlib.sha256(raw).hexdigest(),'ok':True};print(json.dumps(record),flush=True);return record
        except Exception as error:errors.append(str(error))
    return {'key':key,'ok':False,'errors':errors}

with concurrent.futures.ThreadPoolExecutor(max_workers=3) as executor:
    records=list(executor.map(collect,CANDIDATES.items()))
(ROOT/'sources.json').write_text(json.dumps(records,ensure_ascii=False,indent=2),encoding='utf-8')
with zipfile.ZipFile('dist/SIGame-120-anime-extra.zip','w',zipfile.ZIP_DEFLATED,compresslevel=6) as z:
    for p in sorted(ROOT.iterdir()):z.write(p,p.name)
print(json.dumps(records,ensure_ascii=False,indent=2))

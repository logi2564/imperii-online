"""Collect actual rare game screenshots and anime sources for the hard edition."""
import concurrent.futures, hashlib, json, re, subprocess, urllib.parse, urllib.request, zipfile
import time
from pathlib import Path
ROOT=Path('dist/hardcore-review');CACHE=Path('dist/hardcore-cache');ROOT.mkdir(parents=True,exist_ok=True);CACHE.mkdir(parents=True,exist_ok=True)
GAMES=['Arcanum','Sacrifice','Battle Realms','Kohan II','Perimeter','Ground Control','Zanzarah','Giants Citizen Kabuto','SpellForce Platinum','Dungeon Siege II','Warlords Battlecry III','Seven Kingdoms 2 HD','Celtic Kings','Rising Kingdoms','Evil Islands','Etherlords II','The I of the Dragon','War Wind','Demigod','Majesty Gold HD','Tzar The Burden of the Crown','Knights and Merchants','Majesty 2']
ANIME={
 'lain':['serial_experiments_lain'],'haibane':['haibane_renmei'],'texhnolyze':['texhnolyze'],'ergo':['ergo_proxy'],
 'wolfs-rain':['wolfs_rain'],'mushishi':['mushishi'],'katanagatari':['katanagatari'],'houseki':['houseki_no_kuni'],
 'baccano':['baccano'],'paranoia':['mousou_dairinin'],'mononoke':['mononoke'],'ping-pong':['ping_pong_the_animation'],
 'dennou':['dennou_coil'],'kyousougiga':['kyousougiga_2013','kyousougiga_tv'],'hyouge':['hyouge_mono'],'gankutsuou':['gankutsuou'],
 'planetes':['planetes'],'kaiba':['kaiba'],'saraiya':['saraiya_goyou'],'bokurano':['bokurano'],
 'moribito':['seirei_no_moribito'],'acca':['acca_13ku_kansatsuka'],'sayonara':['sayonara_zetsubou_sensei']}

def get(url,limit=180_000_000):
 req=urllib.request.Request(url,headers={'User-Agent':'Mozilla/5.0 (Quiz source research)'})
 with urllib.request.urlopen(req,timeout=65) as r:
  raw=r.read(limit+1)
  if len(raw)>limit:raise ValueError('source too large')
  return raw

def jget(url):return json.loads(get(url,8_000_000))
def ff(*args):subprocess.run(['ffmpeg','-hide_banner','-loglevel','error','-y',*map(str,args)],check=True,timeout=180)

def game(entry):
 index,title=entry;key=f'game-{index:02d}';url='https://store.steampowered.com/api/storesearch/?'+urllib.parse.urlencode({'term':title,'l':'english','cc':'us'})
 try:
  known={'Arcanum':'500810','Sacrifice':'38440','Demigod':'202710'}
  if title in known:appid=known[title]
  else:
   search=jget(url);items=search.get('items',[])
   if not items:raise ValueError('no store results')
   item=items[0];appid=str(item['id'])
  meta_url='https://store.steampowered.com/api/appdetails?appids='+appid;data=jget(meta_url)[appid]['data']
  shots=[]
  for i in [0,1,3]:
   if i>=len(data.get('screenshots',[])):continue
   src=data['screenshots'][i]['path_full'];raw=get(src,15_000_000);file=f'{key}-{i}.jpg';(ROOT/file).write_bytes(raw);shots.append({'file':file,'url':src,'source_sha256':hashlib.sha256(raw).hexdigest()})
  if not shots:raise ValueError('no screenshots')
  result={'key':key,'requested':title,'name':data['name'],'appid':appid,'url':meta_url,'screenshots':shots,'ok':True};print(json.dumps(result),flush=True);return result
 except Exception as e:return {'key':key,'requested':title,'ok':False,'error':str(e)}

def anime(entry):
 key,slugs=entry;errors=[]
 for slug in slugs:
  api='https://api.animethemes.moe/anime/'+slug+'?include=animethemes.animethemeentries.videos'
  try:
   data=jget(api);anime=data['anime'];themes=[t for t in anime.get('animethemes',[]) if t.get('slug','').startswith('OP1')]
   if not themes:raise ValueError('no OP1')
   theme=themes[0];videos=[v for e in theme.get('animethemeentries',[]) for v in e.get('videos',[]) if v.get('link')]
   videos.sort(key=lambda v:(not bool(v.get('nc')),abs((v.get('resolution') or 720)-720),v.get('size') or 0))
   for v in videos[:3]:
    try:
     raw=get(v['link']);source=CACHE/(key+'.webm');source.write_bytes(raw)
     for second in [18,27,48,67]:ff('-ss',second,'-i',source,'-frames:v',1,'-q:v',3,'-map_metadata',-1,ROOT/f'{key}-{second}.jpg')
     ff('-ss',48,'-i',source,'-t',7,'-vn','-map_metadata',-1,'-af','loudnorm=I=-18:TP=-2:LRA=9,afade=t=in:d=0.08,afade=t=out:st=6.7:d=0.3','-ar',44100,'-ac',2,'-b:a','160k',ROOT/(key+'.mp3'))
     result={'key':key,'name':anime['name'],'slug':slug,'url':v['link'],'metadata_url':api,'source_sha256':hashlib.sha256(raw).hexdigest(),'song':theme.get('song'),'ok':True};print(json.dumps(result),flush=True);return result
    except Exception as e:errors.append(str(e))
  except Exception as e:errors.append(str(e))
 return {'key':key,'ok':False,'errors':errors}

previous='https://github.com/logi2564/imperii-online/releases/download/sigame-hardcore-media-e5f10c11/SIGame-hardcore-review.zip'
try:
 previous_raw=get(previous,100_000_000);previous_file=CACHE/'previous.zip';previous_file.write_bytes(previous_raw)
 with zipfile.ZipFile(previous_file) as archive:
  for name in archive.namelist():
   if Path(name).name!=name:raise ValueError('unsafe archive entry')
  archive.extractall(ROOT)
 prior=json.loads((ROOT/'sources.json').read_text());games=prior['games'];animes=prior['anime']
except Exception:
 games=[];animes=[]
# Reject incorrect search matches; never use unrelated adult or similarly named games.
for n in [1,2,19]:
 for old in ROOT.glob(f'game-{n:02d}-*.jpg'):old.unlink()
todo_games=[(i,t) for i,t in enumerate(GAMES,1) if i in [1,2,19] or not any(g.get('key')==f'game-{i:02d}' and g.get('ok') for g in games)]
with concurrent.futures.ThreadPoolExecutor(max_workers=2) as ex:
 replacements=list(ex.map(game,todo_games))
for fresh in replacements:
 games=[g for g in games if g.get('key')!=fresh['key']]+[fresh]
todo_anime=[(key,slugs) for key,slugs in ANIME.items() if not any(a.get('key')==key and a.get('ok') for a in animes)]
for entry in todo_anime:
 fresh=anime(entry);animes=[a for a in animes if a.get('key')!=fresh['key']]+[fresh];time.sleep(2)
(ROOT/'sources.json').write_text(json.dumps({'games':games,'anime':animes},ensure_ascii=False,indent=2),encoding='utf-8')
with zipfile.ZipFile('dist/SIGame-hardcore-review.zip','w',zipfile.ZIP_DEFLATED,compresslevel=6) as z:
 for p in sorted(ROOT.iterdir()):z.write(p,p.name)
print('Games',sum(g['ok'] for g in games),'Anime',sum(a['ok'] for a in animes),flush=True)

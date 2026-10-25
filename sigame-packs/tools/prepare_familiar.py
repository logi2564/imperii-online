"""Collect short, genuine media candidates for the familiar-games remix."""
from pathlib import Path
import concurrent.futures,hashlib,json,subprocess,urllib.request,urllib.parse,zipfile,time,os
ROOT=Path('dist/remix-review');CACHE=Path('dist/remix-cache');ROOT.mkdir(parents=True,exist_ok=True);CACHE.mkdir(parents=True,exist_ok=True)
GAMES={'gta5':['3240220','271590'],'rdr2':['1174180'],'cyberpunk':['1091500'],'hogwarts':['990080'],'rust':['252490'],'lethal':['1966720'],'phasmo':['739630'],'amongus':['945360'],'valheim':['892970'],'re4':['2050650'],'stray':['1332010'],'doom':['782330'],'palworld':['1623730'],'detroit':['1222140']}
ANIME={
 'jojo':('jojo_no_kimyou_na_bouken_2012',['JoJoNoKimyouNaBouken2012-OP1','JoJoNoKimyouNaBoukenStardustCrusaders-OP1','JoJoNoKimyouNaBouken-OP1']),
 'demon':('kimetsu_no_yaiba',['KimetsuNoYaiba-OP1']),
 'spy':('spy_x_family',['SpyXFamily-OP1']),
 'frieren':('sousou_no_frieren',['SousouNoFrieren-OP1']),
 'solo':('ore_dake_level_up_na_ken',['OreDakeLevelUpNaKen-OP1']),
 'dandadan':('dandadan',['Dandadan-OP1']),
 'apothecary':('kusuriya_no_hitorigoto',['KusuriyaNoHitorigoto-OP1']),
 'kaiju':('kaijuu_8_gou',['Kaijuu8Gou-OP1','Kaijuu8Gou-OP1v2']),
 'rezero':('rezero_kara_hajimeru_isekai_seikatsu',['ReZero-OP1v2','ReZero-OP1','ReZero-OP1v1']),
 'bluelock':('blue_lock',['BlueLock-OP1']),
}
def fetch(url,limit=180_000_000):
 for attempt in range(4):
  try:
   req=urllib.request.Request(url,headers={'User-Agent':'Mozilla/5.0 (FriendsQuiz media review)'})
   with urllib.request.urlopen(req,timeout=55)as r:
    b=r.read(limit+1)
    if len(b)>limit:raise ValueError('source exceeds size limit')
    return b
  except Exception as e:
   if getattr(e,'code',None)==404 or attempt==3:raise
   time.sleep(2*(attempt+1))

def ff(*args):subprocess.run(['ffmpeg','-hide_banner','-loglevel','error','-y',*map(str,args)],check=True,timeout=180)
def links(v):
 if isinstance(v,dict):
  for k,x in v.items():
   if k=='link'and isinstance(x,str)and x.endswith('.webm'):yield x
   elif isinstance(x,(dict,list)):yield from links(x)
 elif isinstance(v,list):
  for x in v:yield from links(x)
def game(item):
 key,ids=item;errors=[]
 for app in ids:
  try:
   api='https://store.steampowered.com/api/appdetails?appids='+app;d=json.loads(fetch(api,10_000_000))[app]['data'];records=[]
   for i,s in enumerate(d['screenshots'][:4]):
    raw=fetch(s['path_full'],15_000_000);name=f'{key}-{i}.jpg';(ROOT/name).write_bytes(raw);records.append({'file':name,'url':s['path_full'],'sha256':hashlib.sha256(raw).hexdigest()})
   return {'key':key,'kind':'game','ok':True,'name':d['name'],'metadata_url':api,'screenshots':records}
  except Exception as e:errors.append(type(e).__name__+': '+str(e)[:170])
 return {'key':key,'kind':'game','ok':False,'errors':errors}
def anime(item):
 key,(slug,stems)=item;errors=[];urls=[];api='https://api.animethemes.moe/anime/'+slug+'?include=animethemes.animethemeentries.videos,animethemes.song.artists'
 try:
  data=json.loads(fetch(api,10_000_000));(ROOT/(key+'-metadata.json')).write_text(json.dumps(data,ensure_ascii=False));urls=[u for u in links(data)if '-OP1' in u]
 except Exception as e:errors.append(type(e).__name__+': '+str(e)[:180])
 urls+=['https://v.animethemes.moe/'+stem+'.webm'for stem in stems]
 for u in dict.fromkeys(urls):
  try:
   raw=fetch(u);source=CACHE/(key+'.webm');source.write_bytes(raw);frames=[]
   for second in [18,37,56,72]:
    name=f'{key}-{second}.jpg';ff('-ss',second,'-i',source,'-frames:v',1,'-vf','scale=1280:-2','-q:v',3,'-map_metadata',-1,ROOT/name);frames.append(name)
   return {'key':key,'kind':'anime','ok':True,'url':u,'metadata_url':api,'source_sha256':hashlib.sha256(raw).hexdigest(),'frames':frames}
  except Exception as e:errors.append(type(e).__name__+': '+str(e)[:170])
 return {'key':key,'kind':'anime','ok':False,'errors':errors}
only=os.environ.get('SIGAME_ONLY_ANIME')
if only:GAMES={};ANIME={k:v for k,v in ANIME.items()if k==only}
with concurrent.futures.ThreadPoolExecutor(max_workers=4)as e:rows=list(e.map(game,GAMES.items()))
with concurrent.futures.ThreadPoolExecutor(max_workers=4)as e:rows+=list(e.map(anime,ANIME.items()))
(ROOT/'sources.json').write_text(json.dumps(rows,ensure_ascii=False,indent=2))
with zipfile.ZipFile('dist/SIGame-Remix-Media.zip','w',zipfile.ZIP_DEFLATED,compresslevel=6)as z:
 for p in ROOT.iterdir():z.write(p,p.name)
for r in rows:print(r['key'],r['ok'],r.get('name',''),r.get('errors',[]),flush=True)

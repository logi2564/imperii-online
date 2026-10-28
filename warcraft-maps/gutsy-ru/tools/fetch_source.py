"""Fetch only the public Gutsy Geoid map selected by name, never execute it."""
import hashlib,html,json,re,sys
from pathlib import Path
import requests,gdown
root=Path(sys.argv[1]);root.mkdir(parents=True,exist_ok=True)
folder='1zt5-LXPax5N4xsXCrSub0Id2k0szaqux'
r=requests.get('https://drive.google.com/drive/folders/'+folder,timeout=60);r.raise_for_status()
text=r.text
(root/"Folder.html").write_text(text)
m=re.search(r"window\['_DRIVE_ivd'\]\s*=\s*'((?:[^'\\]|\\.)*)'",text)
if not m:raise RuntimeError('Public Drive folder listing unavailable')
s=re.sub(r'\\x([a-fA-F0-9]{2})',lambda x:chr(int(x[1],16)),m[1]);s=s.replace('\\/','/')
data=json.loads(s);files={}
def visit(x):
 if not isinstance(x,list):return
 if len(x)>3 and isinstance(x[0],str) and isinstance(x[2],str) and re.fullmatch('[A-Za-z0-9_-]{20,}',x[0]) and isinstance(x[3],str) and '/' in x[3]:
  files[x[0]]=x[2]
 for child in x:
  if isinstance(child,list):visit(child)
visit(data)
selected=[(fid,name) for fid,name in files.items() if 'gutsy' in name.lower() and ('1.0.5' in name or '1_0_5' in name)]
(root/'Listing.json').write_text(json.dumps(files,ensure_ascii=False,indent=2))
if len(selected)!=1:raise RuntimeError('Expected one Gutsy 1.0.5 map; folder names: '+json.dumps(list(files.values()),ensure_ascii=False))
fid,name=selected[0]
if not name.lower().endswith('.w3x'):raise RuntimeError('Expected Warcraft map, found '+name)
path=root/'Gutsy-Geoid-EN-1.0.5.w3x'
result=gdown.download(id=fid,output=str(path),quiet=False)
if result is None or path.stat().st_size<512:raise RuntimeError('Source map download failed')
with path.open('rb') as f:header=f.read(512)
if header[:4]!=b'HM3W':raise RuntimeError('Downloaded file is not a classic Warcraft map')
report=dict(file=name,driveFileId=fid,bytes=path.stat().st_size,sha256=hashlib.sha256(path.read_bytes()).hexdigest())
(root/'Source.json').write_text(json.dumps(report,ensure_ascii=False,indent=2));print(json.dumps(report,ensure_ascii=False))

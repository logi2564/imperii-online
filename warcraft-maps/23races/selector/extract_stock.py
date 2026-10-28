"""Extract stock metadata; pass the pinned w3x2lni checkout as argv1."""
from pathlib import Path
import re,json
import sys
root=Path(sys.argv[1])/'data/zhCN-1.24.4/mpq/units'
def slk(path):
 rows={};x=y=1
 for line in path.read_text(errors='replace').splitlines():
  if not line.startswith('C;'):continue
  parts=re.findall(r'(?:[^;\"]|\"(?:\"\"|[^\"])*\")+',line)
  for item in parts[1:]:
   if item.startswith('X'):x=int(item[1:])
   elif item.startswith('Y'):y=int(item[1:])
  for item in parts[1:]:
   if item.startswith('K'):
    v=item[1:]
    if v.startswith('"'):v=v[1:-1].replace('""','"')
    else:
     try:v=float(v) if '.' in v else int(v)
     except ValueError:pass
    rows.setdefault(y,{})[x]=v
 head=rows.pop(1);return {str(r[1]):{head[k]:v for k,v in r.items() if k in head} for r in rows.values() if 1 in r}
ui=slk(root/'unitui.slk');bal=slk(root/'unitbalance.slk');data=slk(root/'unitdata.slk');func={}
for path in root.glob('*unitfunc.txt'):
 raw=None
 for line in path.read_text(errors='replace').splitlines():
  if line.startswith('['):raw=line.strip()[1:-1];func.setdefault(raw,{})
  elif raw and '=' in line:k,v=line.split('=',1);func[raw][k]=v
out={}
for raw,row in ui.items():
 f=func.get(raw,{});b=bal.get(raw,{});d=data.get(raw,{})
 out[raw]=dict(root=raw,umdl=row.get('file',''),usca=row.get('scale',1),unam=row.get('name',raw),uico=f.get('Art',''),ubui=f.get('Builds',''),utra=f.get('Trains',''),uupt=f.get('Upgrade',''),uhpm=b.get('HP',0),umvs=d.get('spd',b.get('spd',0)),umvt=d.get('movetp',''))
(Path(__file__).resolve().parent/'base-units.json').write_text(json.dumps(out,ensure_ascii=False,indent=1))
print('stock unit metadata',len(out))

from pathlib import Path
import re

def read(path):
 cells={};x=y=1
 for line in Path(path).read_text(encoding='utf-8-sig',errors='replace').splitlines():
  if not line.startswith('C;'):continue
  for dim,val in re.findall(r';([XY])(\d+)',line):
   if dim=='X':x=int(val)
   else:y=int(val)
  m=re.search(r';K(.*)',line)
  if m:
   v=m[1];v=v[1:-1].replace('""','"')if v.startswith('"')else v
   cells[x,y]=v
 cols={x:v for(x,y),v in cells.items()if y==1};rows={}
 for y in sorted({y for x,y in cells if y>1}):
  values={cols.get(x,str(x)):v for(x,yy),v in cells.items()if yy==y};key=values.get(cols.get(1,'ID'))
  if key:rows[key]=values
 return rows
if __name__=='__main__':
 base=Path('/workspace/warcraft-map-work/wc3lib-compat/src/map/test');u=read(base/'UnitMetaData.slk')
 for name in ['unam','umdl','uabi','uhab','utra','ubui','upgr','ureq','urqa','uupg','ugol','ulum','uhpm','uhpr','uarm','udef','ua1b','ua1d','ua1s','ua1c','ua1r','ua1t','ua1w','uaen','umvs','ufma','ufoo','ubld','ubdg','usca','usnd','ushb','utyp','uico','ubpx','ubpy']:
  print(name,u.get(name))

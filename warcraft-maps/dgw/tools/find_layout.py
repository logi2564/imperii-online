"""Choose twelve separated clearings from the original classic pathing map."""
from pathlib import Path
from array import array
import json,struct,math,sys
root=Path(sys.argv[1]);out=Path(sys.argv[2]);data=(root/'extracted/war3map.wpm').read_bytes();version,w,h=struct.unpack_from('<3I',data,4);assert data[:4]==b'MP3W'and version==0
flags=data[16:];assert len(flags)==w*h;left=bottom=-18432;stride=w+1;integral=array('I',[0])*((w+1)*(h+1))
for y in range(h):
 s=0
 for x in range(w):
  s+=bool(flags[y*w+x]&10);integral[(y+1)*stride+x+1]=integral[y*stride+x+1]+s

def clear(x,y,radius=448):
 cx=round((x-left)/32);cy=round((y-bottom)/32);r=radius//32;x0=cx-r;x1=cx+r;y0=cy-r;y1=cy+r
 if x0<0 or y0<0 or x1>w or y1>h:return 0
 blocked=integral[y1*stride+x1]-integral[y0*stride+x1]-integral[y1*stride+x0]+integral[y0*stride+x0]
 return 1-blocked/((x1-x0)*(y1-y0))
candidates=[]
for y in range(-15360,15361,256):
 for x in range(-15360,15361,256):
  score=clear(x,y)
  if score>=.92 and clear(x,y,96)==1:candidates.append((x,y,score))
starts=[]
for n in range(12):
 angle=2*math.pi*n/12;tx=8192*math.cos(angle);ty=8192*math.sin(angle)
 eligible=[p for p in candidates if all(math.hypot(p[0]-s['x'],p[1]-s['y'])>=3600 for s in starts)]
 assert eligible,('No free base',n)
 x,y,coverage=min(eligible,key=lambda p:math.hypot(p[0]-tx,p[1]-ty)+(1-p[2])*20000)
 starts.append(dict(player=n,x=x,y=y,buildableFraction=coverage))
shrines=[]
for tx,ty in [(0,0),(4096,0),(-4096,0),(0,4096),(0,-4096)]:
 eligible=[p for p in candidates if all(math.hypot(p[0]-s['x'],p[1]-s['y'])>=2300 for s in starts)and all(math.hypot(p[0]-s['x'],p[1]-s['y'])>=3000 for s in shrines)]
 x,y,coverage=min(eligible,key=lambda p:math.hypot(p[0]-tx,p[1]-ty)+(1-p[2])*2000)
 shrines.append(dict(x=x,y=y,buildableFraction=coverage))
layout=dict(starts=starts,shrines=shrines,minimumStartDistance=min(math.hypot(a['x']-b['x'],a['y']-b['y'])for i,a in enumerate(starts)for b in starts[i+1:]),pathingSource='Original DGW war3map.wpm; 32 world units per cell; flags 0x02 and 0x08 rejected; 896x896 clearing coverage >=92%')
out.write_text(json.dumps(layout,indent=2)+'\n');print(json.dumps(layout,indent=2))

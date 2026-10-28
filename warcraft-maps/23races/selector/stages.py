"""Find temporary camera camps without moving original terrain or placed units."""
import math,re,struct
from classic_data import Reader

def choose(environment,pathing,script):
    r=Reader(environment);assert r.read(4)==b'W3E!';r.read(9)
    grounds=[r.read(4).decode() for _ in range(r.i())];r.read(r.i()*4)
    width,height=r.i(),r.i();originX,originY=r.f(),r.f();data=r.read(width*height*7)
    pw,ph=struct.unpack_from('<ii',pathing,8);assert (pw,ph)==((width-1)*4,(height-1)*4)
    units=set((float(x),float(y)) for x,y in re.findall(r"CreateUnit\(\s*[^,]+,\s*'[^']+',\s*([-\d.]+),\s*([-\d.]+)",script))
    cells=[]
    for y in range(height):
        row=[]
        for x in range(width):
            p=(y*width+x)*7;z=struct.unpack_from('<H',data,p)[0]/4-2048+((data[p+6]&15)-2)*128
            water=bool(data[p+4]&0x40);ground=grounds[data[p+4]&15]
            blocked=pathing[16+min(y*4+2,ph-1)*pw+min(x*4+2,pw-1)]&2
            row.append((z,water,blocked,ground))
        cells.append(row)
    choices=[]
    for cy in range(24,height-24,8):
        for cx in range(24,width-24,8):
            x=originX+cx*128;y=originY+cy*128
            nearest=min(((ux-x)**2+(uy-y)**2 for ux,uy in units),default=999999999)
            if nearest<1800**2:continue
            patch=[cells[yy][xx] for yy in range(cy-13,cy+14,2) for xx in range(cx-15,cx+16,2)]
            solid=sum(not v[1] and not v[2] for v in patch)/len(patch)
            delta=max(v[0] for v in patch)-min(v[0] for v in patch)
            if delta>96:continue
            grass=sum(v[3].lower().endswith(('grs','grr','grd','gsb')) for v in patch)/len(patch)
            score=solid*10+grass*5-delta/100+min(nearest,6000**2)/6000**2
            choices.append((score,x,y,cells[cy][cx][0],solid,delta,grass))
    selected=[]
    for item in sorted(choices,reverse=True):
        if all((item[1]-old[1])**2+(item[2]-old[2])**2>=6500**2 for old in selected):selected.append(item)
        if len(selected)==12:break
    if len(selected)!=12:raise ValueError(f'Only {len(selected)} flat, clear, separated camera stages; do not put camps over original actors')
    # A temporary non-colliding grass platform provides the camp floor; original
    # terrain is never flattened, repainted, or left changed after the menu.
    return [dict(x=x,y=y,z=z+1100,score=score,walkable=solid,heightVariation=delta,grass=grass) for score,x,y,z,solid,delta,grass in selected]

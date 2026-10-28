"""Classic 480-square atlas for the seventeen ORIGINAL Rexxar locations.

Discard only the unplayable camera-border padding, retaining two extra terrain
cells on every edge. Copy original height, cliff, water and pathing data; a
sixteen-entry material palette is necessary for classic W3E's four-bit index.
This module does not claim native Warcraft compatibility from binary checks.
"""
import random,struct
from dataclasses import dataclass
from formats import Reader,i

SIZE=480
ORIGIN=-SIZE*64.0
PAD=2
GROUND=[b'Bdrt',b'Bdrh',b'Bdrr',b'Bdrg',b'Bdsr',b'Bdsd',b'Bflr',b'Bgrr',b'Gbrk',b'Grds',b'Gsqd',b'Dlvc',b'Zsan',b'Ztil',b'Ybtl',b'Oaby']
MATERIALS={
 'Adrt':'Bdrt','Adrd':'Bdrh','Agrs':'Bgrr','Arck':'Bdrr','Agrd':'Bdrg','Avin':'Bdrg','Adrg':'Bgrr','Alvd':'Bdsr',
 'Gdrt':'Bdrh','Wrok':'Bdrr','Wsng':'Gsqd','Ggrs':'Bgrr','Glvc':'Dlvc','Glav':'Dlvc','Gdkr':'Grds',
 'Zdrt':'Bdrt','Zdtr':'Bdrh','Zdrg':'Bdrg','Zbks':'Gbrk','Zbkl':'Gbrk','Zgrs':'Bgrr','Zvin':'Bdrg',
 'Ydrt':'Bdrt','Ydtr':'Bdrh','Yblm':'Grds','Ysqd':'Gsqd','Ygsb':'Bgrr','Yrtl':'Ztil','Yhdg':'Bdrg','Ywmb':'Gsqd',
 'Ddrt':'Bdrh','Dbrk':'Gbrk','Drds':'Grds','Dlav':'Dlvc','Ddkr':'Grds','Dgrs':'Bgrr','Dsqd':'Gsqd',
 'Odrt':'Bdrh','Odtr':'Bdrt','Osmb':'Grds','Ofst':'Grds','Olgb':'Dlvc','Orok':'Bdrr','Ofsl':'Gsqd',
 'Lrok':'Bdrr','cQc1':'Bflr'}

@dataclass
class Terrain:
    name:str
    ground:list
    cliffs:list
    width:int
    height:int
    x:float
    y:float
    vertices:bytes
    left:int
    bottom:int
    playable_width:int
    playable_height:int
    atlas_x:int=0
    atlas_y:int=0

    @property
    def crop(self):return self.left-PAD,self.bottom-PAD,self.playable_width+PAD*2,self.playable_height+PAD*2
    @property
    def offset(self):
        left,bottom,_,_=self.crop
        return ORIGIN+(self.atlas_x-left)*128-self.x,ORIGIN+(self.atlas_y-bottom)*128-self.y
    @property
    def playable(self):
        x=ORIGIN+(self.atlas_x+PAD)*128;y=ORIGIN+(self.atlas_y+PAD)*128
        return x,y,x+self.playable_width*128,y+self.playable_height*128

def read(name,environment,info):
    r=Reader(environment);assert r.read(4)==b'W3E!';assert r.i()==11
    r.read(5);ground=[r.read(4) for _ in range(r.i())];cliffs=[r.read(4) for _ in range(r.i())]
    w,h=r.i(),r.i();x,y=r.f(),r.f();vertices=r.read(w*h*7);assert r.p==len(environment)
    q=Reader(info);assert q.i()==25;q.read(8)
    for _ in range(4):q.s()
    q.read(32);left,right,bottom,top=[q.i() for _ in range(4)];pw,ph=q.i(),q.i()
    assert pw==w-1-left-right and ph==h-1-bottom-top
    assert min(left,right,bottom,top)>=PAD
    return Terrain(name,ground,cliffs,w,h,x,y,vertices,left,bottom,pw,ph)

def contained(a,b):
    x,y,w,h=a;X,Y,W,H=b
    return x>=X and y>=Y and x+w<=X+W and y+h<=Y+H

def _pack(sequence):
    free=[(8,8,SIZE-16,SIZE-16)];out={}
    for t in sequence:
        w,h=t.crop[2:];choices=[(min(W-w,H-h),max(W-w,H-h),x,y) for x,y,W,H in free if w<=W and h<=H]
        if not choices:return None
        _,_,x,y=min(choices);out[t.name]=(x,y);following=[]
        for X,Y,W,H in free:
            if x>=X+W or x+w<=X or y>=Y+H or y+h<=Y:following.append((X,Y,W,H));continue
            if x>X:following.append((X,Y,x-X,H))
            if x+w<X+W:following.append((x+w,Y,X+W-x-w,H))
            if y>Y:following.append((X,Y,W,y-Y))
            if y+h<Y+H:following.append((X,y+h,W,Y+H-y-h))
        free=[a for n,a in enumerate(following) if not any(n!=k and contained(a,b) for k,b in enumerate(following))]
    return out

def arrange(terrains):
    rng=random.Random(37)
    for attempt in range(20000):
        sequence=sorted(terrains,key=lambda t:t.crop[2]*t.crop[3]*(1 if attempt==0 else rng.uniform(.4,1.6)),reverse=True)
        positions=_pack(sequence)
        if positions:
            for t in terrains:t.atlas_x,t.atlas_y=positions[t.name]
            return
    raise ValueError('All original playable regions with two-cell padding do not fit 480x480')

def material(raw):
    if raw in GROUND:return raw
    return MATERIALS[raw.decode()].encode()

def merge(terrains,paths,shadows):
    cliffs=sorted({v for t in terrains for v in t.cliffs});assert len(cliffs)<15
    vertices=bytearray(struct.pack('<HHBBB',8192,8192,0x80,0,0xF2)*((SIZE+1)**2))
    path=bytearray([0xFF])*(SIZE*4)**2
    shadow=bytearray([255])*(SIZE*4)**2
    for t in terrains:
        l,b,w,h=t.crop;ground=[GROUND.index(material(v)) for v in t.ground];cliff=[cliffs.index(v) for v in t.cliffs]
        p=paths[t.name];assert p[:4]==b'MP3W';version,pw,ph=struct.unpack_from('<iii',p,4)
        assert version==0 and pw==(t.width-1)*4 and ph==(t.height-1)*4
        old_shadow=shadows[t.name]
        if old_shadow is not None:assert len(old_shadow)==pw*ph
        for y in range(h+1):
            for x in range(w+1):
                source=((b+y)*t.width+l+x)*7;target=((t.atlas_y+y)*(SIZE+1)+t.atlas_x+x)*7
                tile=bytearray(t.vertices[source:source+7]);tile[4]=(tile[4]&0x70)|ground[tile[4]&15]
                ci=tile[6]>>4;tile[6]=(tile[6]&15)|((15 if ci==15 else cliff[ci])<<4)
                vertices[target:target+7]=tile
        for y in range(h*4):
            start=((b*4+y)*pw+l*4);dest=((t.atlas_y*4+y)*SIZE*4+t.atlas_x*4)
            path[dest:dest+w*4]=p[16+start:16+start+w*4]
            if old_shadow is not None:shadow[dest:dest+w*4]=old_shadow[start:start+w*4]
    env=b'W3E!'+i(11)+b'B'+i(1)+i(len(GROUND))+b''.join(GROUND)+i(len(cliffs))+b''.join(cliffs)+struct.pack('<iiff',SIZE+1,SIZE+1,ORIGIN,ORIGIN)+vertices
    return {'war3map.w3e':env,'war3map.wpm':b'MP3W'+struct.pack('<iii',0,SIZE*4,SIZE*4)+path,'war3map.shd':bytes(shadow)},cliffs


def preview_stages(terrains,entries):
    """Four flat rehearsal platforms outside every original mission crop."""
    occupied=[[False]*SIZE for _ in range(SIZE)]
    for t in terrains:
        for y in range(max(0,t.atlas_y-1),min(SIZE,t.atlas_y+t.crop[3]+1)):
            for x in range(max(0,t.atlas_x-1),min(SIZE,t.atlas_x+t.crop[2]+1)):occupied[y][x]=True
    spots=[];width=14
    for y in range(6,SIZE-width-6):
        for x in range(6,SIZE-width-6):
            if all(not occupied[Y][X] for Y in range(y,y+width) for X in range(x,x+width)):
                spots.append((x,y))
                for Y in range(y,y+width):
                    for X in range(x,x+width):occupied[Y][X]=True
                if len(spots)==4:break
        if len(spots)==4:break
    if len(spots)!=4:raise ValueError('No safe space for four preview platforms')
    env=bytearray(entries['war3map.w3e']);r=Reader(env);r.read(13)
    r.read(r.i()*4);r.read(r.i()*4);r.read(16);start=r.p
    path=bytearray(entries['war3map.wpm']);shadow=bytearray(entries['war3map.shd'])
    for x,y in spots:
        for Y in range(y,y+width+1):
            for X in range(x,x+width+1):
                tile=GROUND.index(b'Bgrr' if X in (x,x+width) or Y in (y,y+width) else b'Bflr')
                at=start+(Y*(SIZE+1)+X)*7
                env[at:at+7]=struct.pack('<HHBBB',8192,8192,tile,0,0xF2)
        for Y in range(y*4,(y+width)*4):
            at=Y*SIZE*4+x*4
            path[16+at:16+at+width*4]=bytes(width*4)
            shadow[at:at+width*4]=bytes(width*4)
    entries.update({'war3map.w3e':bytes(env),'war3map.wpm':bytes(path),'war3map.shd':bytes(shadow)})
    return [(ORIGIN+(x+width/2)*128,ORIGIN+(y+width/2)*128) for x,y in spots]

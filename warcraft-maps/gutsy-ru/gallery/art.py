"""Classic BLP1 icons and version-800 MDX floor geometry."""
import math,struct
from PIL import Image

def chunk(name,data):return name.encode()+struct.pack('<I',len(data))+data
def fixed(text,length):
    data=text.encode('ascii');assert len(data)<length;return data+bytes(length-len(data))
def extent(width,height,horizontal=False):
    v=height/2/math.sqrt(2);y=height/2 if horizontal else v;z=1 if horizontal else v
    return struct.pack('<7f',math.sqrt((width/2)**2+y*y+z*z),-width/2,-y,-z,width/2,y,z)
def quad(texture,width,height,hitbox=False,horizontal=False):
    """A camera-facing quad; classic binary sizes checked independently later."""
    ext=extent(width,height,horizontal);v=height/2/math.sqrt(2);vy=height/2 if horizontal else v;vz=0 if horizontal else v
    model=chunk('VERS',struct.pack('<I',800))+chunk('MODL',fixed('Race selector UI',80)+bytes(260)+ext+struct.pack('<I',150))
    model+=chunk('SEQS',fixed('Stand',80)+struct.pack('<IIfIfI',0,1000,0.,0,0.,0)+ext)
    model+=chunk('TEXS',struct.pack('<I',0)+fixed(texture,260)+struct.pack('<I',0))
    # The ground belongs in the opaque depth-tested pass. UI-style no-depth
    # flags would let the grass paint over the faction models in the camp.
    filter_mode=0 if horizontal else 2
    flags=1|16|32 if horizontal else 1|16|32|64|128
    layer=struct.pack('<6If',28,filter_mode,flags,0,0xFFFFFFFF,0,0. if hitbox else 1.)
    model+=chunk('MTLS',struct.pack('<III',48,0,0)+b'LAYS'+struct.pack('<I',1)+layer)
    verts=[(-width/2,vy,vz),(width/2,vy,vz),(-width/2,-vy,-vz),(width/2,-vy,-vz)]
    geoset=b'VRTX'+struct.pack('<I',4)+b''.join(struct.pack('<3f',*p) for p in verts)
    geoset+=b'NRMS'+struct.pack('<I',4)+(struct.pack('<3f',0,0,1) if horizontal else struct.pack('<3f',0,-1/math.sqrt(2),1/math.sqrt(2)))*4
    geoset+=b'PTYP'+struct.pack('<II',1,4)+b'PCNT'+struct.pack('<II',1,6)+b'PVTX'+struct.pack('<I6H',6,0,2,1,1,2,3)
    geoset+=b'GNDX'+struct.pack('<I',4)+bytes(4)+b'MTGC'+struct.pack('<II',1,1)+b'MATS'+struct.pack('<II',1,0)
    geoset+=struct.pack('<III',0,0,0)+ext+struct.pack('<I',1)+ext
    geoset+=b'UVAS'+struct.pack('<I',1)+b'UVBS'+struct.pack('<I8f',4,0,0,1,0,0,1,1,1)
    model+=chunk('GEOS',struct.pack('<I',len(geoset)+4)+geoset)
    bone=struct.pack('<I',96)+fixed('Root',80)+struct.pack('<III',0,0xFFFFFFFF,256)+struct.pack('<II',0xFFFFFFFF,0xFFFFFFFF)
    model+=chunk('BONE',bone)
    model+=chunk('PIVT',bytes(24 if hitbox else 12))
    if hitbox:
        node=struct.pack('<I',96)+fixed('Hitbox',80)+struct.pack('<III',1,0xFFFFFFFF,8192)
        model+=chunk('CLID',node+struct.pack('<I6f',0,-width/2,-v-8,-v-8,width/2,v+8,v+8))
    return b'MDLX'+model

def blp1(image):
    """Classic indexed BLP1, opaque palette, complete 64..1 mip chain."""
    base=image.quantize(colors=256);palette=base.getpalette();palette=palette+([0]*(768-len(palette)))
    colours=b''.join(bytes((palette[i+2],palette[i+1],palette[i],0)) for i in range(0,768,3))
    mips=[];size=64
    while size:
        mips.append(image.resize((size,size),Image.Resampling.LANCZOS).quantize(palette=base,dither=Image.Dither.NONE).tobytes());size//=2
    offset=156+1024;offsets=[]
    for m in mips:offsets.append(offset);offset+=len(m)
    return struct.pack('<4s6I',b'BLP1',1,0,64,64,5,1)+struct.pack('<16I',*(offsets+[0]*(16-len(mips))))+struct.pack('<16I',*([len(m) for m in mips]+[0]*(16-len(mips))))+colours+b''.join(mips)

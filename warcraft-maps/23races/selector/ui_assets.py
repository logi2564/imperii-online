"""Build original interface textures and small classic-v800 UI models."""
import math,struct,textwrap,random
from pathlib import Path
from PIL import Image,ImageDraw,ImageFont

WIDTH,HEIGHT=1024,512
GOLD=(226,185,74,255);LIGHT=(255,224,155,255);WHITE=(228,225,211,255);DIM=(153,151,139,255)
FONT=Path('/usr/share/fonts/truetype/dejavu/DejaVuSerif.ttf')

def font(n):return ImageFont.truetype(str(FONT),n)
def lines(draw,text,x,y,width,size=10,max_lines=3,colour=WHITE):
    f=font(size);words=text.replace('\n',' ').split();current='';result=[]
    for word in words:
        candidate=(current+' '+word).strip()
        if draw.textlength(candidate,font=f)>width and current:result.append(current);current=word
        else:current=candidate
    if current:result.append(current)
    if len(result)>max_lines:result=result[:max_lines];result[-1]=result[-1].rstrip(' ,.;')+'…'
    for line in result:draw.text((x,y),line,font=f,fill=colour);y+=size+3
    return y

def panel(race,ready=False):
    # The bottom third stays transparent: native portrait, minimap and all
    # twelve command-card buttons must remain visible and clickable.
    image=Image.new('RGBA',(WIDTH,HEIGHT),(0,0,0,0));d=ImageDraw.Draw(image)
    d.rounded_rectangle((20,20,320,342),radius=3,fill=(2,5,5,245),outline=GOLD,width=2)
    d.text((36,32),'РАСА ВЫБРАНА' if ready else 'ВЫБОР РАСЫ',font=font(10),fill=GOLD)
    lines(d,race['name'],36,52,270,18,1,colour=LIGHT)
    d.text((36,80),f"Раса {race['index']+1} / 34    Страница {race['index']//8+1} / 5",font=font(9),fill=DIM)
    d.line((36,101,304,101),fill=GOLD)
    if ready:
        lines(d,'Выбор подтверждён. Ожидаем остальных игроков.',36,117,268,13,4)
        lines(d,'Все начнут одновременно. Твой отряд уже подготовлен.',36,209,268,11,4,colour=DIM)
    else:
        lines(d,f"5 × {race['workerName']}  ·  {race['hp']} HP  ·  скорость {race['speed']}",36,113,268,10,2)
        d.text((36,150),'Строительство',font=font(11),fill=GOLD)
        lines(d,' · '.join(race['buildingNames'][:5]),36,168,268,9,3)
        d.text((36,211),'Войска',font=font(11),fill=GOLD)
        lines(d,' · '.join(race['armyNames'][:5]),36,229,268,9,2)
        lines(d,race['description'],36,264,268,8,3,colour=DIM)
    d.text((36,313),'Иконки рас и кнопки — справа внизу',font=font(10),fill=LIGHT)
    assert image.getbbox()[3] <= 350
    return image

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

def build(catalog,out):
    out=Path(out);assets=out/'assets';assets.mkdir(parents=True,exist_ok=True);files={}
    half_h=800*math.tan(math.radians(35));half_w=half_h*4/3
    for race in catalog.races:
        for ready in (False,True):
            image=panel(race,ready);name=f"AS\\Panels\\{'ready' if ready else 'race'}{race['index']:02}.tga"
            path=assets/name.replace('\\','__');image.save(path,format='TGA');files[name]=path
            if race['index']==9 and not ready:image.save(out/'BloodElf-panel.png')
    rng=random.Random(34);floor=Image.new('RGBA',(256,256));pixels=floor.load()
    for y in range(256):
        for x in range(256):
            tone=rng.randrange(40);pixels[x,y]=(18+tone//2,65+tone*2,14+tone//3,255)
    draw=ImageDraw.Draw(floor)
    for _ in range(5000):
        x=rng.randrange(256);y=rng.randrange(256);draw.line((x,y,x+rng.randrange(-1,2),y-3),fill=(28,90+rng.randrange(60),20,255))
    for x,y in [(500,480),(-120,450),(1100,350),(1050,900)]:
        px=(x+2100)/4200*256;py=(1600-y)/3200*256
        draw.ellipse((px-22,py-18,px+22,py+18),fill=(83,69,35,255))
    for name,blob in [('AS\\Scene\\Floor.mdx',quad('AS\\Scene\\Grass.tga',4200,3200,horizontal=True))]:
        path=assets/name.replace('\\','__');path.write_bytes(blob);files[name]=path
    name='AS\\Scene\\Grass.tga';path=assets/name.replace('\\','__');floor.save(path,format='TGA');files[name]=path
    for key,label in [('prev','←'),('next','→'),('random','?'),('pick','✓')]:
        icon=Image.new('RGB',(64,64),(16,18,14));d=ImageDraw.Draw(icon)
        d.rounded_rectangle((2,2,61,61),radius=4,outline=GOLD[:3],width=3)
        f=ImageFont.truetype('/usr/share/fonts/truetype/dejavu/DejaVuSans.ttf',42)
        box=d.textbbox((0,0),label,font=f);d.text(((64-(box[2]-box[0]))/2-box[0],(64-(box[3]-box[1]))/2-box[1]),label,font=f,fill=LIGHT[:3])
        for disabled in (False,True):
            source=icon.convert('L').convert('RGB') if disabled else icon
            name=('ReplaceableTextures\\CommandButtonsDisabled\\DISBTN_AS_' if disabled else 'ReplaceableTextures\\CommandButtons\\BTN_AS_')+key+'.blp'
            path=assets/name.replace('\\','__');path.write_bytes(blp1(source));files[name]=path
    return files

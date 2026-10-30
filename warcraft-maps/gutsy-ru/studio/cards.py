"""Large, directly selectable world-space cards for the classic client."""
import io
import math
import struct
import hashlib
from functools import lru_cache
from pathlib import Path
from PIL import Image,ImageDraw,ImageFont
from art import quad,extent,chunk
from classic_data import field
from objects import Codes,controller

FONT='/usr/share/fonts/truetype/dejavu/DejaVuSans.ttf'
BOLD='/usr/share/fonts/truetype/dejavu/DejaVuSans-Bold.ttf'
GOLD=(219,190,132,255);INK=(13,20,27,255);WHITE=(242,239,224,255)
BUTTONS={1:('Герои','Портреты и демонстрация навыков'),30:('Режим и команды','Правила матча и состав команд'),
31:('Подготовка','Выбор игроков и начало боя'),6:('Вернуться в бой','Закрыть справку'),
13:('Главное меню','Вернуться к подготовке'),15:('← Назад','Предыдущие герои'),16:('Далее →','Следующие герои'),
19:('← Навыки','Предыдущая четвёрка'),20:('Ещё навыки →','Другие умения и формы'),
22:('Выбрать героя','Подтвердить и перейти к подготовке'),10:('Другой герой','Изменить выбор до начала боя'),
11:('Готов','Подтвердить правила матча'),12:('Начать бой','Все игроки должны быть готовы'),
2:('Арена','Команды, монстры и захват баз'),3:('Эпицентр','Командные раунды и захват территории'),
28:('Каждый за себя','Свободная битва без союзных команд'),5:('Цель матча','Изменить число очков или побед'),
4:('Моя команда','Переключить команду 1 / 2'),27:('К герою','Назад к модели и навыкам'),
23:('← Описание','Предыдущая страница'),24:('Описание →','Следующая страница'),
32:('Автодемо','Повторить применение выбранного навыка'),14:('Роли','Найти героя по роли')}


@lru_cache(maxsize=64)
def font(size,bold=False):return ImageFont.truetype(BOLD if bold else FONT,size)


def write(draw,text,box,size=29,colour=WHITE,bold=False,max_lines=3):
    x,y,width=box;lines=[];line=''
    for word in text.split():
        candidate=(line+' '+word).strip()
        if line and draw.textlength(candidate,font=font(size,bold))>width:
            lines.append(line);line=word
        else:line=candidate
    if line:lines.append(line)
    if len(lines)>max_lines:return write(draw,text,box,size-2,colour,bold,max_lines)
    for row in lines:draw.text((x,y),row,font=font(size,bold),fill=colour);y+=size+8
    return y


def paint(title,subtitle,icon=None):
    image=Image.new('RGBA',(1024,320),(0,0,0,0));d=ImageDraw.Draw(image)
    d.rounded_rectangle((8,10,1015,309),radius=16,fill=(4,7,11,245),outline=(58,48,35,255),width=7)
    d.rounded_rectangle((17,19,1006,300),radius=10,fill=INK,outline=GOLD,width=3)
    for y in range(25,296):
        c=tuple(int(a*(1-(y-25)/700)) for a in (27,39,49))+(255,)
        d.line((24,y,999,y),fill=c)
    if icon:
        image.alpha_composite(icon.resize((224,224),Image.Resampling.LANCZOS),(44,46))
        d.rectangle((41,43,270,273),outline=GOLD,width=3);x=307;w=650
    else:x=57;w=910
    y=write(d,title,(x,56,w),42,GOLD,True,2)
    d.line((x,y+8,963,y+8),fill=(104,88,58,255),width=2)
    write(d,subtitle,(x,y+27,w),27,WHITE,False,3)
    return image


def visible_quad(texture,width,height):
    data=bytearray(quad(texture,width,height,hitbox=True))
    layers=data.index(b'LAYS')
    struct.pack_into('<f',data,layers+8+24,1.)
    return bytes(data)


def with_engine_icon(model,path,width,height):
    """A second classic material resolves built-in icons from Warcraft's MPQs.

    They are not archive omissions: map-only builders cannot rasterize the
    player's built-in textures. The original path can be loaded by the game.
    """
    def chunks(blob):
        result={};at=4
        while at<len(blob):
            name=blob[at:at+4].decode();size=struct.unpack_from('<I',blob,at+4)[0]
            result[name]=blob[at+8:at+8+size];at+=8+size
        assert at==len(blob)
        return result
    base=chunks(model)
    small=chunks(visible_quad(path,width*224/1024,height*224/320))
    material=bytearray(small['MTLS']);struct.pack_into('<I',material,4,1)
    layer=material.index(b'LAYS')+8;struct.pack_into('<I',material,layer+12,1)
    geometry=bytearray(small['GEOS']);vertex=geometry.index(b'VRTX')+8
    x_offset=width*(156/1024-.5);v=height*(.5-158/320)/math.sqrt(2)
    for i in range(4):
        x,y,z=struct.unpack_from('<3f',geometry,vertex+12*i)
        struct.pack_into('<3f',geometry,vertex+12*i,x+x_offset,y+v-2,z+v+2)
    material_id=geometry.index(b'MATS')+12;struct.pack_into('<I',geometry,material_id,1)
    ext_at=material_id+12
    geometry[ext_at:ext_at+28]=extent(width,height)
    geometry[ext_at+32:ext_at+60]=extent(width,height)
    base['TEXS']+=small['TEXS'];base['MTLS']+=bytes(material);base['GEOS']+=bytes(geometry)
    return b'MDLX'+b''.join(chunk(name,blob) for name,blob in base.items())


def build(st,archive,data,used,out):
    out=Path(out);folder=out/'studio-assets';folder.mkdir(parents=True,exist_ok=True)
    codes=Codes(used);units=[];files={};art_cache={};meta=dict(buttons={},heroes=[],skills=[],roles=[],engineIcons=[])
    def add(path,blob):
        file=folder/path.replace('\\','__');file.write_bytes(blob);files[path]=file
    def icon(path):
        blob=st.read(archive,path)
        if blob:
            try:return Image.open(io.BytesIO(blob)).convert('RGBA')
            except (ValueError,OSError):pass
        return None
    def card(key,title,subtitle,portrait=None,width=750,height=230,source_icon=None):
        engine_icon=source_icon if source_icon and portrait is None else None
        if engine_icon:
            if engine_icon.endswith('BTN3M3.blp'):engine_icon='ReplaceableTextures\\CommandButtons\\BTNSpellBookBLS.blp'
            assert engine_icon.startswith('ReplaceableTextures\\'),engine_icon
            portrait=Image.new('RGBA',(224,224),(25,37,48,255))
        art_key=(title,subtitle,width,height,hashlib.sha256(portrait.tobytes()).hexdigest() if portrait else '',engine_icon)
        if art_key in art_cache:
            texture,model=art_cache[art_key]
        else:
            texture='GST\\Cards\\'+key+'.tga';model='GST\\Cards\\'+key+'.mdx'
            image=paint(title,subtitle,portrait);stream=io.BytesIO();image.resize((512,256),Image.Resampling.LANCZOS).save(stream,format='TGA')
            mesh=visible_quad(texture,width,height)
            if engine_icon:mesh=with_engine_icon(mesh,engine_icon,width,height)
            add(texture,stream.getvalue());add(model,mesh)
            art_cache[art_key]=(texture,model)
        raw=codes.take('r');unit=controller(raw,model,'ReplaceableTextures\\CommandButtons\\BTNSelectHeroOn.blp',1.,name=title)
        units.append(unit)
        if engine_icon:meta['engineIcons'].append(dict(unit=raw,path=engine_icon,model=model))
        return raw
    for action,(title,subtitle) in BUTTONS.items():meta['buttons'][str(action)]=card('action'+str(action),title,subtitle)
    for h,hero in enumerate(data['heroes']):
        meta['heroes'].append(card('hero'+str(h),hero['name'],data['roles'][hero['role']],icon(hero['icon']),680,225,hero['icon']))
        for skill in hero['skills']:
            meta['skills'].append(card('skill'+str(skill['index']),skill['title'],'Нажми: применение и описание',icon(skill['icon']),500,175,skill['icon']))
    for r,title in enumerate(data['roles']):
        representative=next(h for h in data['heroes'] if h['role']==r)
        meta['roles'].append(card('role'+str(r),title,'Открыть героев роли',icon(representative['icon']),680,225,representative['icon']))
    # A background only, never a fake clickable button.
    panel=Image.new('RGBA',(1024,1024),(10,15,21,246));d=ImageDraw.Draw(panel)
    d.rectangle((5,5,1018,1018),outline=GOLD,width=5)
    d.rectangle((17,17,1006,1006),outline=(69,76,84,255),width=2)
    d.rectangle((580,145,1004,899),fill=(0,0,0,0),outline=GOLD,width=2)
    d.text((58,45),'GUTSY GEOID GAME',font=font(39,True),fill=GOLD)
    d.line((57,117,968,117),fill=GOLD,width=2)
    stream=io.BytesIO();panel.save(stream,format='TGA')
    add('GST\\Cards\\panel.tga',stream.getvalue());add('GST\\Cards\\panel.mdx',quad('GST\\Cards\\panel.tga',2800,1510))
    panel_raw=codes.take('r');units.append(controller(panel_raw,'GST\\Cards\\panel.mdx','ReplaceableTextures\\CommandButtons\\BTNSelectHeroOn.blp',1.,True))
    meta['panel']=panel_raw
    paint('Выбери героя','Крупные портреты • применение навыков • один понятный выбор',icon(data['heroes'][15]['icon'])).save(out/'Studio-card-preview.png')
    return units,files,meta

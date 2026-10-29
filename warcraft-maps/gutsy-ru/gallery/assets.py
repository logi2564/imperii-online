"""Render a restrained Warcraft-style panel, keeping native buttons exposed."""
import io
from pathlib import Path
from PIL import Image,ImageDraw,ImageFont
from art import blp1,quad

ROOT='GGV\\'
GOLD=(226,187,94,255)
LIGHT=(249,232,187,255)
TEXT=(226,230,235,255)
MUTED=(163,177,193,255)
FONT='/usr/share/fonts/truetype/dejavu/DejaVuSans.ttf'


def font(size):return ImageFont.truetype(FONT,size)


def text_lines(draw,text,x,y,width,size,colour=TEXT,max_lines=20):
    lines=[];line=''
    for word in text.split():
        candidate=(line+' '+word).strip()
        if line and draw.textlength(candidate,font=font(size))>width:
            lines.append(line);line=word
        else:line=candidate
    if line:lines.append(line)
    assert len(lines)<=max_lines,('Text would be truncated',text,len(lines),max_lines)
    for line in lines:
        draw.text((x,y),line,font=font(size),fill=colour);y+=size+5
    return y


def base(title):
    image=Image.new('RGBA',(1024,512));d=ImageDraw.Draw(image)
    d.rounded_rectangle((18,16,382,335),radius=8,fill=(8,13,23,245),outline=GOLD,width=2)
    d.rounded_rectangle((23,21,377,330),radius=6,outline=(71,79,91,255),width=1)
    d.text((37,34),title,font=font(13),fill=GOLD)
    d.line((37,58,363,58),fill=(81,87,96,255))
    return image,d


def panel(hero,role,portrait=None):
    image,d=base('ГАЛЕРЕЯ ГЕРОЕВ')
    if portrait:
        image.alpha_composite(portrait.convert('RGBA').resize((62,62)),(38,76))
        d.rectangle((37,75,101,139),outline=GOLD,width=2)
    else:
        d.rounded_rectangle((37,75,101,139),radius=3,fill=(23,37,53),outline=GOLD,width=2)
        d.text((54,83),hero['name'][0],font=font(34),fill=LIGHT)
    text_lines(d,hero['name'],114,75,245,17,LIGHT,3)
    d.text((38,151),role.upper(),font=font(12),fill=GOLD)
    y=text_lines(d,hero['overview'],38,176,323,13,TEXT,6)
    assert y<=286,(hero['name'],y)
    d.line((37,290,363,290),fill=(81,87,96,255))
    d.text((38,303),'Иконки навыков — справа внизу',font=font(12),fill=MUTED)
    assert image.getbbox()[3]<340
    return image


CONTROL_LABELS={
 'roles':'ГЕРОИ','arena':'АР','epic':'ЭП','team':'КМ','goal':'ЦЕЛЬ',
 'help':'?','camera':'ВИД','mine':'МОЙ','change':'СМЕНА','ready':'ГОТОВ',
 'unready':'НАЗАД','start':'БОЙ','close':'×','main':'МЕНЮ','prev':'←',
 'next':'→','confirm':'ВЫБОР','about':'i','skillprev':'←','skillnext':'→',
 'rankprev':'Р−','ranknext':'Р+',
}


def build(st,archive,data,out):
    folder=Path(out)/'assets';folder.mkdir(parents=True,exist_ok=True);files={}
    def add(name,blob):
        path=folder/name.replace('\\','__');path.write_bytes(blob);files[name]=path
    def tga(image):
        # Keep the classic client's texture cache bounded when browsing all
        # heroes. Native skill text remains rendered by the game at full size.
        stream=io.BytesIO();image.resize((512,256),Image.Resampling.LANCZOS).save(stream,format='TGA');return stream.getvalue()
    main,d=base('ПОДГОТОВКА МАТЧА')
    y=text_lines(d,'Выбери героя. Подтверди выбор. Нажми «Готов».',38,78,323,21,LIGHT,4)
    y=text_lines(d,'Когда все будут готовы, ведущий начинает бой отдельной кнопкой.',38,y+17,323,14,TEXT,4)
    text_lines(d,'Один игрок — один боевой герой. Просмотр моделей не создаёт дополнительных героев.',38,240,323,12,MUTED,4)
    add(ROOT+'Panels\\main.tga',tga(main));main.save(Path(out)/'Menu-preview.png')
    roles,d=base('ВЫБОР ГЕРОЯ')
    text_lines(d,'Выбери роль',38,82,323,25,LIGHT,2)
    text_lines(d,'Нажимай на портреты справа внизу. Сначала откроется модель героя и его навыки.',38,140,323,16,TEXT,5)
    text_lines(d,'Выбор закрепляется отдельной кнопкой. Боевой герой появится только при запуске.',38,254,323,12,MUTED,4)
    add(ROOT+'Panels\\roles.tga',tga(roles))
    for i,hero in enumerate(data['heroes']):
        portrait=None
        blob=st.read(archive,hero['icon'])
        if blob:
            try:portrait=Image.open(io.BytesIO(blob)).convert('RGBA')
            except (OSError,ValueError):pass
        image=panel(hero,data['roles'][hero['role']],portrait)
        add(ROOT+f'Panels\\hero{i:02}.tga',tga(image))
        if i==15:image.save(Path(out)/'Saber-preview.png')
    for key,label in CONTROL_LABELS.items():
        image=Image.new('RGB',(64,64),(12,20,30));d=ImageDraw.Draw(image)
        d.rounded_rectangle((2,2,61,61),radius=5,outline=GOLD[:3],width=3)
        size=30 if len(label)<=2 else 13
        f=font(size);box=d.textbbox((0,0),label,font=f)
        d.text(((64-box[2]+box[0])/2-box[0],(64-box[3]+box[1])/2-box[1]),label,font=f,fill=LIGHT[:3])
        add(ROOT+f'Icons\\{key}.blp',blp1(image))
    floor=Image.new('RGBA',(128,128),(28,35,44,255));d=ImageDraw.Draw(floor)
    for n in range(0,128,16):
        d.line((n,0,n,127),fill=(39,48,59,255));d.line((0,n,127,n),fill=(39,48,59,255))
    d.ellipse((37,37,91,91),outline=(136,112,67,255),width=2)
    add(ROOT+'Scene\\floor.tga',tga(floor))
    add(ROOT+'Scene\\floor.mdx',quad(ROOT+'Scene\\floor.tga',4200,3200,horizontal=True))
    return files

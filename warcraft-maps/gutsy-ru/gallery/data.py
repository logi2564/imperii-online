"""Russian editorial layer and resources for the nonmodal classic gallery."""
import csv
import io
import json
import re
import struct
import sys
from pathlib import Path

HERE = Path(__file__).resolve().parent
sys.path.insert(0, str(HERE.parent/'menu'))
from handbook import extract, profiles, slk

FAMILIES = {'H06V':'H00D','H070':'H029','H071':'H01Z','H073':'H02W',
            'H074':'H01U','H076':'H00C','H079':'H016'}
TERMS = {
    'Технический Физический урон':'Физ. урон',
    'Технический физический урон':'Физ. урон',
    'Технические Физические повреждения':'Физ. урон',
    'Технология Физические повреждения':'Физ. урон',
    'Физический урон навыка':'Физ. урон',
    'Технический урон':'Урон навыка',
    'Абсолютный проникающий урон':'Чистый урон',
    'Абсолютное пробивание урона':'Чистый урон',
    'Время британского окна':'Время подготовки',
    'Британское время':'Время подготовки',
    'Время брига':'Время подготовки',
    'Ментальная концентрация':'Концентрация',
    'ментальная концентрация':'концентрация',
    'Ментальная фокусировка':'Концентрация',
    'восстановление выносливости':'восстановление здоровья',
    'Восстановление выносливости':'Восстановление здоровья',
    'Предел диапазона':'Дальность',
    'Ограниченная дальность':'Дальность',
    'Перезарядка Перезарядка':'Перезарядка',
    'Трансцендентная скорость движения':'Предельная скорость',
    'трансцендентная скорость движения':'предельная скорость',
    'Гипогонадизм':'Мгновенный шаг',
    'Мегамен Калибр Морган':'Экскалибур Морган',
    'Мегамен Калибр':'Экскалибур',
    'Раб Дракона':'Драгон Слейв',
    'Частное железо':'Железный песок',
    'Лунный червь':'Гэцуга Тэнсё',
    'Букмекерская контора':'Бук Мейкер',
}


def rendered(values):
    out=io.StringIO(newline='')
    csv.writer(out,lineterminator='\n').writerow(values)
    return out.getvalue()[:-1]


def polish(text):
    for old,new in sorted(TERMS.items(),key=lambda item:-len(item[0])):
        text=text.replace(old,new)
    text=re.sub(r'(?i)\bИнлектелт\b','Интеллект',text)
    return text


def preview_scale(blob,original_scale):
    """Enlarge only the harmless gallery model, using authored model extents."""
    height=0.
    if blob and blob[:4]==b'MDLX':
        cursor=4
        while cursor+8<=len(blob):
            tag,size=struct.unpack_from('<4sI',blob,cursor);cursor+=8
            if cursor+size>len(blob):break
            if tag==b'MODL' and size>=368:
                ext=struct.unpack_from('<7f',blob,cursor+340)
                height=ext[6]-ext[3]
            if tag==b'SEQS' and not 20<height<5000:
                for offset in range(cursor,cursor+size-131,132):
                    name=blob[offset:offset+80].split(b'\0')[0].lower()
                    if name.startswith(b'stand'):
                        ext=struct.unpack_from('<7f',blob,offset+104)
                        if 20<ext[6]-ext[3]<5000:height=ext[6]-ext[3];break
            cursor+=size
    if not 20<height<5000:height=200./original_scale
    return min(25.,max(.1,850./height))


def prepare(st, archive):
    source=extract(st,archive)
    reviewed=json.loads((HERE/'editorial.json').read_text())
    units=profiles(st.read(archive,'units\\campaignunitstrings.txt'))
    unitui=slk(st.read(archive,'units\\unitui.slk'))
    names=(st.read(archive,'(listfile)') or b'').decode().splitlines()
    available={name.lower():name for name in names}
    def resource(path,kind):
        candidates=[path]
        if kind=='model':candidates.extend([re.sub(r'(?i)\.mdl$','.mdx',path),path+'.mdx'])
        else:candidates.extend([path+'.blp',path+'.tga'])
        return next((available[p.lower()] for p in candidates if p.lower() in available),path)
    changes={}
    abi_labels={}
    hero_index={h['raw']:i for i,h in enumerate(source['heroes'])}
    for i,hero in enumerate(source['heroes']):
        row=reviewed[hero['raw']]
        hero['name']=row['name']
        hero['overview']=row['overview']
        hero['icon']=resource(units[hero['raw']].get('art',['ReplaceableTextures\\CommandButtons\\BTNSelectHeroOn.blp'])[0],'icon')
        hero['model']=resource(unitui[hero['raw']]['file'],'model')
        hero['scale']=float(unitui[hero['raw']].get('modelscale','1'))
        hero['previewScale']=preview_scale(st.read(archive,hero['model']),hero['scale'])
        hero['family']=hero_index.get(FAMILIES.get(hero['raw'],hero['raw']),i)
        hero['about']=[row['overview']]
        for skill,title in zip(hero['skills'][:4],row['primary']):
            # One raw ability can appear in multiple cosmetic versions.
            existing=abi_labels.get(skill['raw'])
            assert existing is None or existing==title,(skill['raw'],existing,title)
            abi_labels[skill['raw']]=title
        changes[(hero['raw'],'tip')]=[row['name']]
        changes[(hero['raw'],'ubertip')]=[f"Роль: {source['roles'][hero['role']]}|n{row['overview']}"]
        for key in ('name','propernames'):
            if key in units[hero['raw']]:
                changes[(hero['raw'],key)]=[row['name']]*len(units[hero['raw']][key])
    def edit(name):
        blob=st.read(archive,name);parsed=profiles(blob);section='';lines=blob.decode().splitlines(keepends=True);out=[]
        for line in lines:
            if line.startswith('['):section=line[1:line.index(']')]
            if '=' not in line or line.startswith('//'):
                out.append(line);continue
            key,value=line.rstrip('\r\n').split('=',1);end=line[len(line.rstrip('\r\n')):]
            old=next(csv.reader([value]));new=old
            if name.endswith('unitstrings.txt') and (section,key.lower()) in changes:
                new=changes[(section,key.lower())]
            if name.endswith('abilitystrings.txt'):
                if key.lower() in ('tip','researchtip') and section in abi_labels:
                    original=parsed[section]
                    hotkey=original.get('hotkey',[''])[0]
                    title=('Изучить: ' if key.lower()=='researchtip' else '')+abi_labels[section]+(' ('+hotkey+')' if hotkey else '')
                    new=[title+(f' — ранг {rank}' if len(old)>1 else '') for rank in range(1,len(old)+1)]
                elif key.lower() in ('ubertip','researchubertip','tip','researchtip'):
                    new=[polish(v) for v in old]
            if new!=old:
                assert len(new)==len(old),(section,key,'rank cardinality')
                assert all(len(v.encode())<=1023 for v in new),(section,key,'tooltip size')
                value=rendered(new)
            assert len((key+'='+value).encode())<=4095
            out.append(key+'='+value+end)
        return ''.join(out).encode()
    edits={name:edit(name) for name in ['units\\campaignunitstrings.txt','units\\campaignabilitystrings.txt']}
    # Apply the same edited labels and text to all handbook entries/ranks.
    for hero in source['heroes']:
        for skill in hero['skills']:
            if skill['raw'] in abi_labels:
                skill['title']=abi_labels[skill['raw']]+(' ('+skill['key']+')' if skill['key'] else '')
            else:skill['title']=polish(skill['title'])
            skill['pages']=[polish(text) for text in skill['pages']]
            skill['icon']=resource(skill['icon'],'icon')
    return source,edits,dict(reviewedHeroProfiles=len(reviewed),primaryAbilityNames=len(abi_labels))

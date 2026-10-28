"""Real classic command-card buttons, with eight race icons per page."""
from classic_data import field

ORDERS=('channel','acidbomb','banish','farsight','drunkenhaze','healingward','thunderclap','roar','berserk','divineshield','fanofknives','taunt')
KEYS='QWERASDFZXCV'
# Four-byte rawcodes only.
CONTROLS=(('qPrv','prev','Предыдущая страница'),('qNxt','next','Следующая страница'),('qRnd','random','Случайная раса'),('qPck','pick','Подтвердить расу'))

def ability(raw,name,icon,slot,description):
    mods=[field('aher',0,0),field('aite',0,0),field('alev',0,1),field('arlv',0,0),field('anam',3,name),field('aart',3,icon),field('ahky',3,KEYS[slot]),field('abpx',0,slot%4),field('abpy',0,slot//4),field('acat',3,''),field('aeat',3,''),field('atat',3,''),field('arac',3,'other'),field('areq',3,''),field('arqa',3,'')]
    mods += [field('atp1',3,name+' ('+KEYS[slot]+')',1),field('aub1',3,description,1),field('amcs',0,0,1),field('acdn',2,0.,1),field('acas',2,0.,1),field('aran',2,0.,1),field('Ncl1',2,0.,1),field('Ncl2',0,0,1),field('Ncl3',0,1,1),field('Ncl4',2,0.,1),field('Ncl5',0,0,1),field('Ncl6',3,ORDERS[slot],1)]
    return dict(old=b'ANcl',new=raw.encode(),mods=mods)

def abilities(catalog):
    result=[]
    for r in catalog.races:
        desc=f"Показать лагерь расы «{r['name']}».|n5 × {r['workerName']}. Здоровье: {r['hp']}. Скорость: {r['speed']}.|n|n"+r['description'].replace('\n','|n')+'|n|nПосле просмотра нажми «Подтвердить расу» (V).'
        # Classic tooltip buffers should not receive unbounded source lore.
        while len(desc.encode())>950:desc=desc[:-1]
        result.append(ability(f'qA{r["index"]:02}',r['name'],r['icon'],r['index']%8,desc))
    for slot,(raw,key,name) in enumerate(CONTROLS,8):
        desc='Показать восемь других рас.' if slot in (8,9) else ('Показать случайную расу. Для выбора нажми V.' if slot==10 else 'Подтвердить показанную расу. После готовности всех игроков начнётся игра.')
        result.append(ability(raw,name,f'ReplaceableTextures\\CommandButtons\\BTN_AS_{key}.blp',slot,desc))
    assert len(result)==38 and len({o['new'] for o in result})==38
    return result

def units(catalog):
    result=[]
    for r in catalog.races:
        data=catalog.unit(r['worker']);start=r['index']//8*8
        ids=[f'qA{i:02}' for i in range(start,min(start+8,34))]+[c[0] for c in CONTROLS]+['Avul']
        mods=[field('unam',3,'Выбор расы: '+r['name']),field('umdl',3,data['umdl']),field('uico',3,r['icon']),field('usca',2,float(data.get('usca',1))),field('uabi',3,','.join(ids)),field('uhab',3,''),field('ures',3,''),field('utra',3,''),field('ubui',3,''),field('ufoo',0,0),field('uaen',0,0),field('uacq',2,0.),field('umvs',0,0),field('umvt',3,'fly'),field('umvh',2,0.),field('umvf',2,0.),field('ucol',2,0.),field('upat',3,''),field('ubdg',0,0),field('ushb',3,''),field('ushu',3,''),field('ucpt',2,0.),field('ucbs',2,0.),field('umpi',0,0),field('umpm',0,0),field('usid',0,0),field('usin',0,0)]
        result.append(dict(old=b'hfoo',new=f'qC{r["index"]:02}'.encode(),mods=mods))
    return result

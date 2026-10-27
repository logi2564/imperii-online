"""Classic object data for sixteen scripted, learnable skills and hidden helpers."""
from formats import field
HEROES=['Orex','Orkn','Nsjs','Ocb2']
OLD=[['Arsg','Arsq','ANsb','Arsp'],['ANhw','ANhx','Arsw','AOls'],['ANcf','Acdh','Acdb','Acef'],['AOs2','AOw2','AOr2','AOr3']]
# Name, icon, targeting (0 instant / 1 unit / 2 point), mana, cooldown, description.
SPECS=[
 [('Возвращающийся топор','BTNArcaniteMelee',2,55,8,'Топор летит до 700 и возвращается к Рексару. За проход: {a} урона, каждую цель задевает не более двух раз. По отмеченной добыче +50%.'),
  ('Боевые спутники','BTNSpiritWolf',0,75,24,'Призывает волка и кабана на 22 сек. Дополнительно +{p} здоровья и +{q} урона каждому. Звери атакуют отмеченную добычу.'),
  ('След охотника','BTNEnsnare',1,60,14,'Вражеская цель замедляется; получает {c} урона раз в секунду, 6 сек. При гибели лечит героев рядом на 12% здоровья. Топоры и ульт усиливаются по этой цели.'),
  ('Прыжок стаи','BTNStampede',2,130,45,'В указанную точку бросаются три духа-зверя на 12 сек. Взрыв при появлении: {d} урона в радиусе 280; отмеченная добыча получает ещё 50%.')],
 [('Живая нить','BTNHealingWave',1,65,8,'Исцеляет дружественного героя на {a}; затем ещё трижды по {e} за 3 сек. Нить обрывается дальше 1100 от Рокхана.'),
  ('Тотем очищения','BTNHealingWard',2,85,22,'Тотем на 8 сек. Раз в секунду лечит героев в радиусе 450 на {c} и снимает отрицательные эффекты. Враг может уничтожить тотем.'),
  ('Якорь души','BTNSpiritLink',1,90,26,'На 7 сек. запоминает место и здоровье дружественного героя. При окончании возвращает его; здоровье не ниже записанного (потолок 35% + 7% за ранг). Погибший герой возрождается у якоря.'),
  ('Круг предков','BTNAncestralSpirit',2,150,50,'8 сек. наносит врагам {f} урона в секунду в радиусе 450 и исцеляет героев на столько же. В начале поднимает одного погибшего героя с 40% здоровья.')],
 [('Хмельной веер','BTNStrongDrink',2,55,7,'Конус 550 перед Чэнем: {a} урона, замедление и мокрая метка на 6 сек. Метка усиливает огненные навыки.'),
  ('Взрывная бочка','BTNBarrel',2,70,12,'Бочка долетает до выбранной точки и взрывается в радиусе 280: {b} урона. По мокрым целям +60% и короткое оглушение.'),
  ('Огненный перекат','BTNBreathOfFire',2,65,14,'Рывок до 420 по проходимой земле. Задевает каждого врага один раз на {a} урона; по мокрой цели ещё 40%. Не проходит сквозь стены.'),
  ('Огненный водоворот','BTNStormEarth&Fire',2,140,45,'6 сек. огненной зоны радиусом 380: {f} урона в секунду, по мокрым врагам +50%. Обычных наземных врагов стягивает к центру; героев и строения не перемещает.')],
 [('Раскол земли','BTNShockWave',2,60,9,'Разлом длиной 650 поражает каждого врага один раз: {a} урона и короткое оглушение.'),
  ('Вызов вождя','BTNCommand',0,70,18,'На 6 сек. даёт Кэрну +{g} брони. Ближайшим обычным врагам раз в секунду приказывает атаковать Кэрна; боссы и строения не подчиняются.'),
  ('Ответный удар','BTNDefend',0,65,20,'За 5 сек. накапливает входящий урон, затем лечит Кэрна и бьёт вокруг. Лечение и урон: 60 + 12 за ранг + 35% накопленного (предел {h}). Повторное применение не сбрасывает накопление.'),
  ('Земля предков','BTNWarStomp',0,150,50,'8 сек. зона вокруг места применения. Герои рядом получают +{g} брони. Раз в 2 сек. враги получают {d} урона и короткое оглушение. Броня снимается при выходе из зоны.')]]

def skill_id(role,slot):return f'R4{role}{slot}'
def abilities():
    out=[]
    for role,specs in enumerate(SPECS):
        for slot,(name,icon,target,mana,cooldown,description) in enumerate(specs):
            key='QWER'[slot];levels=3 if slot==3 else 5
            mods=[field('aher',0,1),field('aite',0,0),field('alev',0,levels),field('arlv',0,6 if slot==3 else 1),field('alsk',0,6 if slot==3 else 2),field('anam',3,name),field('aart',3,'ReplaceableTextures\\CommandButtons\\'+icon+'.blp'),field('arar',3,'ReplaceableTextures\\CommandButtons\\'+icon+'.blp'),field('ahky',3,key),field('arhk',3,key),field('abpx',0,slot),field('abpy',0,2),field('arpx',0,slot),field('arpy',0,0),field('aret',3,name+' ('+key+')'),field('arut',3,'Открывает новый ранг навыка. '+description.format(a='35 + 25 × ранг',b='90 + 50 × ранг',c='12 + 9 × ранг',d='100 + 80 × ранг',e='10 + 8 × ранг',f='18 + 17 × ранг',g='3 + 2 × ранг',h='180 + 60 × ранг',p='75 + 50 × ранг',q='4 × ранг')),field('acat',3,''),field('aeat',3,''),field('atat',3,'')]
            for level in range(1,levels+1):
                desc=description.format(a=35+25*level,b=90+50*level,c=12+9*level,d=100+80*level,e=10+8*level,f=18+17*level,g=3+2*level,h=180+60*level,p=75+50*level,q=4*level)
                mods += [field('atp1',3,f'{name} ({key}) — ранг {level}',level),field('aub1',3,desc+f'|nМана: {mana}. Перезарядка: {cooldown} сек.',level),field('amcs',0,mana,level),field('acdn',2,float(cooldown),level),field('aran',2,700.,level),field('atar',3,'air,ground,friend,enemy,organic,neutral',level),field('Ncl1',2,0.,level),field('Ncl2',0,target,level),field('Ncl3',0,1,level),field('Ncl4',2,0.,level),field('Ncl5',0,0,level),field('Ncl6',3,['channel','farsight','drunkenhaze','healingward'][slot],level)]
            out.append(dict(old=b'ANcl',new=skill_id(role,slot).encode(),mods=mods))
    # Max-life bonuses are integers in classic AbilityMetaData (Ilif, NOT IIf1).
    for n in range(16):out.append(dict(old=b'AIlf',new=f'RH{n:02}'.encode(),mods=[field('Ilif',0,25*(2**n),1),field('anam',3,'Co-op HP bit'),field('aite',0,1),field('aart',3,'')]))
    for rank in range(1,6):out.append(dict(old=b'AId1',new=f'RD0{rank}'.encode(),mods=[field('Idef',0,3+2*rank,1),field('aite',0,1),field('aart',3,'')]))
    for rank in range(1,6):out.append(dict(old=b'AItg',new=f'RP0{rank}'.encode(),mods=[field('Iatt',0,4*rank,1),field('aite',0,1),field('aart',3,'')]))
    out += [dict(old=b'Aslo',new=b'RSlw',mods=[field('Slo1',2,.35,1),field('Slo2',2,.20,1),field('amcs',0,0,1),field('adur',2,2.,1),field('ahdu',2,.8,1),field('aran',2,9999.,1),field('atar',3,'air,ground,enemy,organic',1)]),dict(old=b'AHtb',new=b'RStn',mods=[field('Htb1',2,0.,1),field('amcs',0,0,1),field('adur',2,.65,1),field('ahdu',2,.30,1),field('aran',2,9999.,1),field('atar',3,'air,ground,enemy,organic',1),field('amat',3,'')])]
    return out

def unit_helpers():
    return [dict(old=b'hpea',new=b'rD40',mods=[field('unam',3,'Spell helper'),field('uabi',3,'Aloc,Avul'),field('umdl',3,''),field('umvs',0,0),field('umvt',3,'fly'),field('ufoo',0,0),field('umpi',0,10000),field('umpm',0,10000),field('ucpt',2,0.),field('ucbs',2,0.),field('ushb',3,''),field('ushu',3,''),field('udtm',2,.01)])]

def apply_heroes(tables):
    for role,raw in enumerate(HEROES):
        obj=next((o for o in tables[0] if o['old']==raw.encode()),None)
        if obj is None:obj=dict(old=raw.encode(),new=b'\0'*4,mods=[]);tables[0].append(obj)
        obj['mods']=[m for m in obj['mods'] if m[0]!='uhab']+[field('uhab',3,','.join([skill_id(role,n) for n in range(4)]+['Aamk']))]

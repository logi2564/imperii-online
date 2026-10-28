"""Classic command-card front end. No Reforged frames or injected natives."""
from formats import field
from kits import HEROES,SPECS
import copy
ORDERS=('channel','acidbomb','banish','farsight','drunkenhaze','healingward','thunderclap','roar','berserk','divineshield','fanofknives','taunt')
KEYS='QWERASDFZXCV'
MODELS=['Units\\Other\\Rexxar\\Rexxar.mdl','Units\\Orc\\HeroShadowHunter\\HeroShadowHunter.mdl','Units\\Creeps\\PandarenBrewmaster\\PandarenBrewmaster.mdl','Units\\Orc\\HeroTaurenChieftainCIN\\HeroTaurenChieftainCIN.mdl']
ICONS=['BTNBeastMaster','BTNShadowHunter','BTNPandarenBrewmaster','BTNHeroTaurenChieftain']
NAMES=['Рексар','Рокхан','Чэнь','Кэрн']
CONTROLS=[('Выбрать '+n,ICONS[r], 'Твоя роль: '+['урон и звери','лечение и спасение','огненные связки','защита отряда'][r]+'.|n'+'|n'.join(s[0] for s in SPECS[r])+'|nГерой уникален: если место занято неготовым игроком, вы обменяетесь героями.') for r,n in enumerate(NAMES)]+[
 ('Лёгкая','BTNHumanArmorUpOne','Ведущий выбирает сложность. Здоровье врагов растёт с числом игроков.'),('Обычная','BTNHumanArmorUpTwo','Враги усиливаются по здоровью и урону за каждого участника.'),('Тяжёлая','BTNHumanArmorUpThree','Для четырёх героев: здоровье обычных врагов ×6,5, урон ×2. Отдельный баланс массовой битвы финала.'),
 ('Выбрать акт','BTNSelectHeroOn','Ведущий переключает начало: акт I → II → III. Для полного прохождения начните с I. Сохранение выбирает локацию автоматически.'),
 ('Состав и правила','BTNScroll','Показать героев, сложность и правила кампании. Сохранение новой сессии: -save, загрузка до старта: -load КОД.'),
 ('О герое','BTNTomeOfRetraining','Описания, иконки и показ четырёх навыков на манекенах. В игре: K — обучение, T — таланты на 4/8/12/16/20.'),
 ('Продолжение','BTNChestOfGold','В новой сессии выбери своего героя и введи -load КОД. Коды нужны только между игровыми сессиями, не на дверях.'),
 ('Готов / отменить','BTNSelectHeroOn','Подтвердить своего героя. Когда все готовы и выбран Рексар, кампания начнётся. Повторное нажатие отменяет готовность.')]

def objects():
 abilities=[];units=[]
 for slot,(name,icon,desc) in enumerate(CONTROLS):
  mods=[field('aher',0,0),field('aite',0,0),field('alev',0,1),field('arlv',0,0),field('anam',3,name),field('aart',3,'ReplaceableTextures\\CommandButtons\\'+icon+'.blp'),field('ahky',3,KEYS[slot]),field('abpx',0,slot%4),field('abpy',0,slot//4),field('acat',3,''),field('aeat',3,''),field('atat',3,''),field('arac',3,'other'),field('areq',3,''),field('arqa',3,'')]
  mods += [field('atp1',3,name+' ('+KEYS[slot]+')',1),field('aub1',3,desc,1),field('amcs',0,0,1),field('acdn',2,0.,1),field('acas',2,0.,1),field('aran',2,0.,1),field('Ncl1',2,0.,1),field('Ncl2',0,0,1),field('Ncl3',0,1,1),field('Ncl4',2,0.,1),field('Ncl5',0,0,1),field('Ncl6',3,ORDERS[slot],1)]
  abilities.append(dict(old=b'ANcl',new=f'uM{slot:02}'.encode(),mods=mods))
 # A separate command card exposes the actual skill icons and full tooltips.
 # Clicks run the actual skill code on isolated training stages.
 def info_button(raw,name,icon,key,description,order,x,y):
  values={'anam':name,'aart':'ReplaceableTextures\\CommandButtons\\'+icon+'.blp',
          'ahky':key,'atp1':name+' ('+key+')','aub1':description,'Ncl6':order,'abpx':x,'abpy':y}
  mods=[field(m[0],m[1],values[m[0]],m[2]) if m[0] in values else copy.deepcopy(m) for m in abilities[0]['mods']]
  return dict(old=b'ANcl',new=raw.encode(),mods=mods)
 for role,specs in enumerate(SPECS):
  for slot,(name,icon,target,mana,cooldown,description) in enumerate(specs):
   desc=description.format(a='35 + 25 × ранг',b='90 + 50 × ранг',c='12 + 9 × ранг',d='100 + 80 × ранг',e='10 + 8 × ранг',f='18 + 17 × ранг',g='3 + 2 × ранг',h='180 + 60 × ранг',p='75 + 50 × ранг',q='4 × ранг')
   desc+='|n|nМана в игре: '+str(mana)+'. Перезарядка: '+str(cooldown)+' сек.'
   desc+='|nУровни изучения: '+('6 / 12 / 18.' if slot==3 else '1 / 3 / 5 / 7 / 9.')
   desc+='|n|cffffcc00Нажми для показа на манекенах. Назад к выбору — B.|r'
   abilities.append(info_button(f'uI{role}{slot}','Справка: '+name,icon,'QWER'[slot],desc,ORDERS[slot],slot,0))
 abilities.append(info_button('uIBk','Назад к выбору','BTNCancel','B','Вернуться к выбору героя, главы, сложности и готовности.','roar',3,2))
 for r in range(4):
  mods=[field('unam',3,'Выбор: '+NAMES[r]),field('umdl',3,MODELS[r]),field('uico',3,'ReplaceableTextures\\CommandButtons\\'+ICONS[r]+'.blp'),field('usca',1,1.),field('uabi',3,','.join(f'uM{i:02}' for i in range(12))+',Avul'),field('uhab',3,''),field('ures',3,''),field('utra',3,''),field('ubui',3,''),field('ufoo',0,0),field('uaen',0,0),field('uacq',2,0.),field('umvs',0,0),field('umvt',3,'fly'),field('umvh',2,0.),field('umvf',2,0.),field('ucol',2,0.),field('upat',3,''),field('ubdg',0,0),field('ushb',3,''),field('ushu',3,''),field('ucpt',2,0.),field('ucbs',2,0.),field('umpi',0,0),field('umpm',0,0),field('usid',0,0),field('usin',0,0)]
  units.append(dict(old=b'hfoo',new=f'uC0{r}'.encode(),mods=mods))
 return abilities,units

GLOBALS='''
    string array UM_panel
    unit array UM_unit
    boolean array UM_ready
    boolean array UM_details
    integer array UM_detailAbility
    integer UM_backAbility=0
    string array UM_actTitle
    real array UM_stageX
    real array UM_stageY
    unit array UM_demoHero
    trigger array UM_demoDamage
    group array UM_demoEnemies
    integer array UM_demoRole
    integer array UM_demoSkill
    real array UM_demoAge
    boolean array UM_demoCast
    boolean array UM_demoHit
    integer UM_demoCount=0
    integer UM_demoOwner=0
    timer UM_demoClock=null
    integer array UM_pending
    integer array UM_unitType
    integer array UM_ability
    timer UM_clock=null
    timer UM_inputClock=null
    boolean UM_scheduled=false
    leaderboard UM_board=null
    integer UM_act=0
'''

def assets():
 from PIL import Image,ImageDraw,ImageFont
 from io import BytesIO
 font_path='/usr/share/fonts/truetype/dejavu/DejaVuSans.ttf'
 def font(n):return ImageFont.truetype(font_path,n)
 out={}
 for r in range(4):
  im=Image.new('RGBA',(1024,1024),(0,0,0,0));d=ImageDraw.Draw(im)
  d.rounded_rectangle((20,42,350,687),radius=5,fill=(12,15,17,238),outline=(199,159,67,255),width=3)
  d.text((42,66),'КАМПАНИЯ РЕКСАРА',font=font(19),fill='#eacb74')
  d.text((42,104),NAMES[r],font=font(38),fill='#ffe3a3')
  d.text((42,158),['Охотник и стая','Целитель и духи','Огонь и хмель','Оплот отряда'][r],font=font(18),fill='#b1cab7')
  d.line((42,198,328,198),fill='#917438',width=2)
  y=219
  for i,spec in enumerate(SPECS[r]):
   text=spec[0];words=text.split();line=''
   lines=[]
   for word in words:
    candidate=(line+' '+word).strip()
    if d.textlength(candidate,font=font(19))>250:lines.append(line);line=word
    else:line=candidate
   lines.append(line)
   d.text((42,y),'QWER'[i],font=font(21),fill='#eacb74')
   for line in lines:d.text((72,y),line,font=font(19),fill='#e9ece3');y+=27
   y+=18
  d.line((42,443,328,443),fill='#917438',width=1)
  for yy,text in [(463,'Q W E R — выбрать героя'),(494,'A S D — сложность'),(525,'F — выбрать главу'),(556,'V — готов / отмена'),(593,'X — описание навыков'),(622,'B — назад из описаний'),(653,'В игре: K — навыки, T — таланты')]:
   d.text((42,yy),text,font=font(17),fill='#b4bdb6')
  # Bottom third is fully transparent: native portrait, HUD and command card.
  stream=BytesIO();im.save(stream,format='TGA');out[f'RexxarUI\\Hero{r}.tga']=stream.getvalue()
 return out

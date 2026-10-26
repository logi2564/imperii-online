"""Generate explicit, editable classic object definitions for sixteen complete factions."""
from pathlib import Path
import sys,json
from slk import read
repo=Path(__file__).resolve().parents[1];reference=Path(sys.argv[1]);meta=read(reference/'wc3lib-compat/src/map/test/UnitMetaDataEx.slk');ui=read(reference/'War3Net/src/War3Net.Build.Core/Resources/UnitUI.slk')
rows=[
('Люди Рассвета','Аурион, бог Солнца','Hpal','AHhb,AHad,AHds,AHre','hpea','htow hkee hcas hhou hbar hars harm halt hgtw','hfoo hrif hmpr hkni hmtm hgry hsor hhes',1.00,1.00,0,'Священное сияние','Дополнительные 10 золота каждые 5 секунд; лечение армии.',(255,220,125)),
('Орда Грома','Громтар, бог Бури','Ofar','AOcl,AOfs,AOfw,AOeq','opeo','ogre ostr ofrt ocbw obar osld obea oalt owtw','ogru ohun oshm orai ocat owyv odoc otau',1.16,.96,1,'Гнев небес','Крепкая пехота: на 16% больше здоровья.',(210,130,75)),
('Ледяная Плеть','Нергал, владыка Мороза','Ulic','AUfn,AUfu,AUfa,AUdd','uaco','unpl unp1 unp2 uzig usep utod uslh uaod uzg1','ugho ucry unec uabo umtw ugar uban ufro',.98,1.08,2,'Пустота зимы','Сильный урон; божественная атака иссушает ману врага.',(145,210,255)),
('Дети Луны','Элунара, хранительница Луны','Emoo','AEfa,AEst,AEar,AEsf','ewsp','etol etoa etoe emow eaom eate eaoe eaow etrp','esen earc edot edoc emtg ehip edry echm',.92,1.08,3,'Лунное благословение','Быстрые бойцы, мощное групповое лечение и восстановление маны.',(165,145,245)),
('Кланы Кузни','Борунд, бог Горна','Hmkg','AHtb,AHtc,AHbh,AHav','hpea','htow hkee hcas hhou hbar hars harm halt hctw','hfoo hrif hmpr hkni hmtm hgry hspt hmtt',1.10,1.04,4,'Сердце кузни','Дополнительные 8 дерева каждые 5 секунд; крепкая броня.',(220,160,80)),
('Эльфы Феникса','Каэлион, вечный Феникс','Hblm','AHfs,AHbn,AHdr,AHpx','hpea','htow hkee hcas hhou hbar hars hgra halt hgtw','hhes earc hmpr hkni hmtm hphx hsor hspt',.90,1.18,5,'Пламя перерождения','Хрупкая, но сильная армия; жар феникса поражает площадь.',(255,115,70)),
('Держава Прилива','Азшари, богиня Глубин','Nngs','ANfl,ANfa,ANms,ANto','nmpe','nntt nntt nntt nnfm nnsg nnsa nnsg nnad nntg','nmyr nsnp nnsw nnrg hmtm nwgs nnsw nhyd',1.04,1.02,6,'Врата океана','Призыв водных стражей; стойкая пехота и сильные стрелки.',(75,220,230)),
('Тролли Лоа','Зул\u2019Аман, голос Лоа','Oshd','AOhw,AOhx,AOsw,AOvd','opeo','ogre ostr ofrt ocbw obar osld obea oalt owtw','nftr nftt nfsh orai ocat owyv odoc nwwd',.96,1.09,7,'Охота духов','За убийства получаешь дополнительную веру; призыв духов.',(100,220,145)),
('Огры Камня','Грум, отец Гор','Otch','AOsh,AOws,AOae,AOre','hpea','ogre ostr ofrt ocbw obar osld obea oalt owtw','nogr nogn nogm nogl ocat owyv nogm noga',1.27,.89,8,'Раскол мира','Медленные великаны с большим запасом здоровья; урон зданиям.',(195,170,125)),
('Кобольды Недр','Керн, хранитель Искры','Ntin','ANsy,ANcs,ANeg,ANrg','nkob','htow hkee hcas hhou harm hars harm halt hgtw','nkob nkot nkog noga hmtm hgyr nkog hmtt',.87,1.02,9,'Перегрузка механизмов','Дешёвая армия и ремонт укреплений; выгодная экономика.',(215,180,100)),
('Нерубский Рой','Ануб\u2019Ра, владыка Роя','Ucrl','AUim,AUts,AUcb,AUls','uaco','unpl unp1 unp2 uzig usep utod uslh uaod uzg1','nnwa ucry nnwq nnwl umtw ugar unec nnws',1.06,.99,10,'Пробуждение роя','Призыв жуков; крепкие наземные части и контроль.',(170,135,215)),
('Легион Пепла','Азгар, бог Пламени','Nplh','ANrf,ANht,ANca,ANdo','ncpn','ogre ostr ofrt ocbw obar osld obea oalt owtw','nfgu nfel unec ninf ocat nbal uban nbal',1.02,1.16,11,'Падение преисподней','Дорогие ударные войска; призыв инфернала.',(245,105,70)),
('Двор Крови','Сангвир, алый Владыка','Udre','AUav,AUsl,AUcs,AUin','uaco','htow hkee hcas hhou hbar hars harm halt hgtw','ugho ucry unec uabo umtw ugar uban nrvd',.98,1.05,12,'Кровавое затмение','Божественный удар лечит своего владыку за каждого врага.',(220,75,110)),
('Пандарены Тумана','Шен, хранитель Равновесия','Npbm','ANbf,ANdh,ANdb,ANef','hpea','etol etoa etoe emow eaom eate eaoe eaow etrp','nfrl earc hmpr edoc hmtm ehpr edot npn3',1.11,.95,13,'Дыхание равновесия','Устойчивая армия; исцеление и снятие отрицательных эффектов.',(160,230,185)),
('Крылья Драконов','Астрагор, отец Неба','Hblm','AHfs,AHbn,AHdr,AHpx','hpea','ogre ostr ofrt ocbw obar osld obea oalt owtw','hhes nsnp oshm nnrg hmtm ndrk nnsw nrdr',1.01,1.12,14,'Дыхание древнего','Дорогие драконы и сильная авиация; разрушительный огонь.',(255,175,90)),
('Безликие Бездны','Ниал, око Бездны','Udre','AUav,AUsl,AUcs,AUin','uaco','unpl unp1 unp2 uzig usep utod uslh uaod uzg1','nfor ucry unec nfot umtw ugar uban nfod',1.05,1.06,15,'Гравитационный разлом','Притягивание врагов к точке удара; сильная элитная пехота.',(155,110,220)),
]
# Stock mechanics are shared by role; faction models, stats, elite passives and hero toolkits differ.
roles=[('Страж','hfoo',500,19,110,0,2,1,'',270),('Стрелок','hrif',340,17,130,15,2,1,'',270),('Целитель','hmpr',330,11,160,30,2,1,'Ahea',265),('Штурмовик','hkni',780,30,220,45,3,2,'',300),('Осадная машина','hmtm',450,48,230,70,3,2,'',220),('Крылатый охотник','hgry',650,30,260,80,4,2,'',280),('Мистик','hsor',390,15,200,60,2,2,'Aslo',265),('Избранный','hkni',1200,46,380,110,5,3,'ACev',280)]
objects=[];abilities=[];upgrades=[];factions=[];used_fields={}
def unit(old,id,fields):
 assert old in ui,(old,id)
 mods=[]
 for key,value in fields.items():
  assert key in meta,('Unknown classic field',key)
  kind=meta[key]['type'];typ=3 if isinstance(value,str)else (1 if kind=='real'else 2)if isinstance(value,float)else 0
  if typ==0:assert kind in ['int','bool','attackBits','channelType','deathType','teamColor','versionFlags','attributeType'],(key,kind,value)
  used_fields[key]=kind;mods.append(dict(id=key,type=typ,value=value))
 if id.startswith('dM'):
  replacement='war3mapImported\\VampireTown.mdl'if id[-2:]in ['10','11','12']else {'00':'war3mapImported\\Acolyte1.mdl','20':'war3mapImported\\VampirePool.mdl','21':'war3mapImported\\VampireBarracks.mdl','24':'war3mapImported\\VampireAltar.mdl'}.get(id[-2:])
  if replacement:
   next(m for m in mods if m['id']=='umdl')['value']=replacement
 objects.append(dict(old=old,id=id,fields=mods))
def model(k):
 assert k in ui,('Unknown stock model',k)
 return ui[k]['file']+'.mdl'
def common(name,icon):return dict(unam=name,utip=name,utub=name,uico='ReplaceableTextures\\CommandButtons\\BTN'+icon+'.blp',urac='human',ucam=0,uspe=0)
for n,row in enumerate(rows,1):
 name,god,hero,skills,worker,builds,skins,hp,damage,mode,spell,trait,tint=row;letter=chr(64+n);p='d'+letter;h='D'+letter;b=builds.split();models=skins.split();assert len(models)==8
 f=dict(id=n,prefix=p,name=name,god=god,heroBase=hero,skills=skills,worker=p+'00',hq=[p+'10',p+'11',p+'12'],buildings=[p+str(i)for i in range(20,26)],army=[p+str(i)for i in range(30,38)],champion=h+'80',avatar=h+'90',spell='Y'+letter+'00',spellMode=mode,spellName=spell,trait=trait,color=tint,weaponUpgrade='Q'+letter+'00',armorUpgrade='Q'+letter+'01',units=[])
 buildings=[p+'10',*[p+str(i)for i in range(20,26)]]
 fields=common(name+' — Рабочий','Peasant');fields.update(umdl=model(worker),uabi='Ahar,Arep',ubui=','.join(buildings),uhpm=260,ufoo=1,ugol=65,ulum=0,ubld=12,ucol=16.0,umvs=280,utyp='peon',urqa='',ureq='')
 # Human construction is encoded by race + Builds; Ahar performs classic gold/wood harvesting.
 unit('hpea',p+'00',fields)
 for tier in range(3):
  title=name+' — '+['Оплот','Крепость','Цитадель'][tier];fields=common(title,'TownHall'if tier==0 else'Keep'if tier==1 else'Castle')
  fields.update(umdl=model(b[tier]),utra=p+'00',uabi='Abgs,Argl',ufma=30+10*tier,uhpm=1800+1000*tier,udef=5+2*tier,ugol=[450,500,900][tier],ulum=[180,200,400][tier],ubld=[35,45,65][tier],uupt=p+str(11+tier)if tier<2 else'',udep=','.join(p+str(t)for t in range(11+tier,13)),ureq='',urqa='',ubpx=0,ubpy=0,utub=title+'|nПассивный доход зависит от высшей столицы. Улучшай её до III ступени, чтобы открыть избранных и призыв бога. Потеря всех столиц означает поражение.')
  unit(['htow','hkee','hcas'][tier],p+str(10+tier),fields)
 specs=[('Жилище','hhou',3,'Farm',90,15,600,[]),('Казармы','hbar',4,'HumanBarracks',150,40,1200,[0,1,3,7]),('Святилище','hars',5,'ArcaneSanctum',170,60,1000,[2,6]),('Мастерская','harm',6,'Workshop',220,80,1100,[4,5]),('Алтарь богов','halt',7,'AltarOfKings',180,50,1100,[]),('Дозорная башня','hgtw',8,'GuardTower',120,40,850,[])]
 for i,(title,base,mi,icon,gold,wood,life,trains)in enumerate(specs):
  fields=common(name+' — '+title,icon);fields.update(umdl=model(b[mi]),ugol=gold,ulum=wood,uhpm=life,udef=4,ubld=25,utra=','.join(f['army'][j]for j in trains),uabi='Abgs',ureq=p+'11'if i==3 else'',urqa='1'if i==3 else'',ubpx=(i+1)%4,ubpy=(i+1)//4,ures='',uupt='',udep='')
  if i==0:fields['ufma']=15
  if i==1:fields['ures']=f['weaponUpgrade']+','+f['armorUpgrade']
  if i==4:fields.update(utra=f['champion'],urev=1,uabi='Abgs,ZG00',utub='Вознесение: цитадель III, 800 золота, 350 дерева, 150 веры.|nКнопка V призывает одного бога. Павших героев можно воскресить здесь.')
  unit(base,p+str(20+i),fields)
 for i,(title,base,life,atk,gold,wood,food,tier,abil,speed)in enumerate(roles):
  unitname=name+' — '+title;fields=common(unitname,['Footman','Rifleman','Priest','Knight','MortarTeam','GryphonRider','Sorceress','Knight'][i]);scale=.87 if i<2 else 1.0
  price=.87 if n==10 else 1.12 if n in [6,12,15]else 1.0
  fields.update(umdl=model(models[i]),usca=scale,uhpm=round(life*hp),udef=2+(1 if n in [5,9]else 0)+(2 if i==7 else 0),ua1b=round(atk*damage),ua1d=1,ua1s=3,umvs=speed+(20 if n==4 else -15 if n==9 else 0),ugol=round(gold*price),ulum=wood,ufoo=food,ufma=0,ubld=18+4*i,upgr=f['weaponUpgrade']+','+f['armorUpgrade'],ureq=p+str(9+tier)if tier>1 else'',urqa='1'if tier>1 else'',uabi=abil,utyp='mechanical'if i==4 else'',ucol=24.0,ubpx=i%4,ubpy=i//4,utub=unitname+'|n'+['Ближний бой. Защищает стрелков и магов.','Дальний бой. Уязвим для штурмовиков.','Автоматически лечит союзников.','Быстрый тяжёлый боец II ступени.','Осадный урон по зданиям. Береги от пехоты.','Летающая ударная единица II ступени.','Замедляет врагов и поддерживает армию.','Элита III ступени. Большие затраты пищи и ресурсов.'][i])
  if i in [2,6]:fields.update(umpm=350,umpr=1.25)
  unit(base,f['army'][i],fields);f['units'].append(dict(id=f['army'][i],role=i,tier=tier,gold=round(gold*price),wood=wood,food=food))
 for divine in [False,True]:
  title=god if divine else name+' — Чемпион';fields=common(title,''+{'Hpal':'HeroPaladin','Ofar':'HeroFarSeer','Ulic':'Lich','Emoo':'HeroMoonPriestess','Hmkg':'HeroMountainKing','Hblm':'HeroBloodElf','Nngs':'SeaWitch','Oshd':'ShadowHunter','Otch':'HeroTaurenChieftain','Ntin':'HeroTinker','Ucrl':'HeroCryptLord','Nplh':'PitLord','Udre':'HeroDreadLord','Npbm':'PandarenBrewmaster'}[hero])
  fields.update(umdl=model(hero),uabi='AInv'+(','+f['spell']if divine else''),uhab=skills,usca=1.25 if divine else 1.0,ustr=45 if divine else 22,uagi=28 if divine else 16,uint=40 if divine else 20,ustp=3.0,uagp=2.0,uinp=3.0,uhpm=1800 if divine else 650,umpm=650 if divine else 300,umpr=2.5 if divine else 1.0,uhpr=3.0 if divine else 1.0,udef=6 if divine else 3,ua1b=65 if divine else 23,ua1d=1,ua1s=6,umvs=300,ugol=800 if divine else 250,ulum=350 if divine else 60,ufoo=8 if divine else 5,ufma=0,ubld=60 if divine else 30,ureq='',urqa='',upro=god if divine else'Чемпион '+name,upgr='',utub=title+'|n'+(spell+' (Z). '+trait if divine else'Четыре способности героя. Для возвращения после гибели используй алтарь.'))
  if n==13:fields['umdl']='war3mapImported\\HeroPitLord1.mdl'
  if n==15:fields['umdl']='BlackDragon.mdl'
  unit(hero,f['avatar']if divine else f['champion'],fields)
 factions.append(f)
# A neutral capturable shrine uses no production or combat and cannot be destroyed.
fields=common('Святилище веры','FountainOfLife');fields.update(umdl=model('nfoh'),uabi='Avul',utra='',ugol=0,ulum=0,uhpm=2000,ufma=0,ufoo=0,ureq='',urqa='',uaen=0,utyp='',usca=.85,utip='Святилище веры',utub='Удерживай рядом боевой отряд 10 секунд без соперников.|nКаждые 5 секунд владелец получает +25 золота, +5 дерева и +5 веры.')
unit('nfoh','dS00',fields)
catalog=dict(version='0.1',factions=factions,objects=objects,classicFieldTypes=used_fields,rules=dict(startGold=750,startWood=400,startFaith=10,ascendGold=800,ascendWood=350,ascendFaith=150,selectionTimeout=90,incomePeriod=5,captureSeconds=10,victoryUnlockSeconds=1200,victoryHoldSeconds=120))
(repo/'source/catalog.json').write_text(json.dumps(catalog,ensure_ascii=False,indent=2)+'\n');print('Catalog:',len(factions),'factions,',len(objects),'custom units/buildings/heroes; classic fields:',len(used_fields))

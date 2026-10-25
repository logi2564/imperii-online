"""Compose the requested familiar-franchise remix from visually reviewed media."""
from pathlib import Path
import argparse,copy,hashlib,json,shutil,uuid,subprocess,tempfile
ROOT=Path(__file__).resolve().parents[1];DEST=ROOT/'friends-remix'
parser=argparse.ArgumentParser();parser.add_argument('--candidates',type=Path,required=True);parser.add_argument('--audio',type=Path,required=True);parser.add_argument('--selection',type=Path,required=True);a=parser.parse_args()
selection=json.loads(a.selection.read_text());records={r['key']:r for r in json.loads((a.candidates/'sources.json').read_text())};new_audio={r['key']:r for r in json.loads(a.audio.read_text())}
old={edition:json.loads((ROOT/edition/'pack.json').read_text())for edition in ['friends-120','friends-140']}
old_media={edition:{m['id']:m for m in json.loads((ROOT/edition/'media-sources.json').read_text())}for edition in old}
media=[];questions={};used=set();generated=[]
def put(mid,path,spec):
 assert mid not in used;used.add(mid);spec=copy.deepcopy(spec);spec.pop('file',None);spec.pop('key',None);suffix=path.suffix.lower();folder='Audio'if suffix=='.mp3'else'Images';target=DEST/'media'/folder/(mid+suffix);target.parent.mkdir(parents=True,exist_ok=True)
 if path.resolve()!=target.resolve():shutil.copyfile(path,target)
 raw=target.read_bytes();spec.update(id=mid,path=folder+'/'+target.name,bytes=len(raw),sha256=hashlib.sha256(raw).hexdigest());media.append(spec);return mid
def previous(mid,edition,old_id):
 spec=old_media[edition][old_id];source=ROOT/edition/'media'/spec['path']
 if mid.startswith('o'):
  spec=copy.deepcopy(spec);spec['processing']={'type':'audio','operation':'7-second excerpt of the previously identified opening clip','start_in_previous_clip_seconds':2,'seconds':7,'previous_clip_sha256':spec['sha256']}
  with tempfile.TemporaryDirectory()as folder:
   short=Path(folder)/'clip.mp3';subprocess.run(['ffmpeg','-hide_banner','-loglevel','error','-y','-ss','2','-i',str(source),'-t','7','-vn','-map_metadata','-1','-af','afade=t=in:d=0.07,afade=t=out:st=6.7:d=0.3','-ar','44100','-ac','2','-b:a','160k',str(short)],check=True);return put(mid,short,spec)
 return put(mid,source,spec)
def q(key,answers,prompt,media_id=None,franchise=None,anime=None,note='',sources=()):
 assert key not in questions;d={'prompt':prompt,'answers':answers,'note':note,'sources':list(sources),'franchise':franchise or key}
 if media_id:d['media']=media_id
 if anime:d['anime']=anime
 questions[key]=d;return key
# All game titles below are mainstream releases; Warcraft III and WoW are the requested older exceptions.
GAMES=[
 ('gta5',['GTA V','GTA 5','Grand Theft Auto V','ГТА 5'],2013),('cyberpunk',['Cyberpunk 2077','Киберпанк 2077'],2020),
 ('cs2',['Counter-Strike 2','CS2','CS 2','Контр-Страйк 2'],2023),('dota2',['Dota 2','Дота 2'],2013),('rdr2',['Red Dead Redemption 2','RDR 2','RDR2'],2018),
 ('elden',['Elden Ring','Элден Ринг'],2022),('witcher',['The Witcher 3','Ведьмак 3','The Witcher 3: Wild Hunt'],2015),('wow',['World of Warcraft','WoW','Вовка'],2004),('wc3',['Warcraft III','Warcraft 3','Варкрафт 3','Варик 3'],2002),('hogwarts',['Hogwarts Legacy','Хогвартс: Наследие','Хогвартс'],2023),
 ('rust',['Rust','Раст'],2018),('lethal',['Lethal Company','Летал Компани'],2023),('phasmo',['Phasmophobia','Фазмофобия','Фазма'],2020),('valheim',['Valheim','Вальхейм','Валхейм'],2021),('amongus',['Among Us','Амонг Ас','Амонгас'],2018),
 ('detroit',['Detroit: Become Human','Detroit Become Human','Детройт: Стать человеком','Детройт'],2018),('re4',['Resident Evil 4','Resident Evil 4 Remake','Обитель зла 4','RE4'],2023),('stray',['Stray','Стрей','Стрэй'],2022),('palworld',['Palworld','Палворлд'],2024),('doom',['Doom Eternal','Дум Этернал'],2020)]
reused={'cs2':('friends-120','g06'),'dota2':('friends-120','g07'),'elden':('friends-120','g12'),'witcher':('friends-120','g10'),'wow':('friends-120','i03'),'wc3':('friends-120','i05')}
for i,(key,answers,year)in enumerate(GAMES,1):
 mid=f'g{i:02}'
 if key in reused:previous(mid,*reused[key])
 else:
  r=records[key];assert r['ok'];shot=next(s for s in r['screenshots']if s['file']==selection[key]);path=a.candidates/shot['file'];put(mid,path,{'credit':r['name']+'; настоящий игровой скриншот из официальной галереи Steam.','source':{'url':shot['url'],'metadata_url':r['metadata_url'],'name':r['name'],'source_sha256':shot['sha256']},'processing':{'type':'image','operation':'Original gallery screenshot copied without pixel edits'}})
 q(key,answers,'Назови игру по настоящему скриншоту. Для номерных частей нужен номер.',mid,key,note='Приняты русское и английское названия; общее название серии без нужной части недостаточно.');questions[key]['first_release_year']=year;questions[key]['kind']='game_screenshot'
# One anime franchise per question across both recognition modes and animal riddles.
ANIME_FRAMES=[
 ('spy',['Семья шпиона','Spy x Family','Spy Family']),('demon',['Клинок, рассекающий демонов','Demon Slayer','Kimetsu no Yaiba','Клинок рассекающий демонов']),
 ('jojo',['Невероятные приключения ДжоДжо','ДжоДжо','Джоджо','JoJo','JoJo’s Bizarre Adventure']),('frieren',['Провожающая в последний путь Фрирен','Фрирен','Frieren','Sousou no Frieren']),('dandadan',['Дандадан','Dandadan']),
 ('solo',['Поднятие уровня в одиночку','Solo Leveling','Соло Левелинг']),('kaiju',['Кайдзю № 8','Кайдзю номер 8','Кайдзю 8','Kaiju No. 8']),('apothecary',['Монолог фармацевта','The Apothecary Diaries','Kusuriya no Hitorigoto']),('rezero',['Re:Zero','Re Zero','Ре:Зеро','Жизнь с нуля в альтернативном мире']),('bluelock',['Синяя тюрьма','Блю Лок','Blue Lock'])]
for i,(key,answers)in enumerate(ANIME_FRAMES,1):
 r=records[key];assert r['ok'],key;filename=selection[key];assert filename in r['frames'];mid=f'f{i:02}';second=int(Path(filename).stem.rsplit('-',1)[1]);put(mid,a.candidates/filename,{'credit':answers[0]+'; кадр оригинального опенинга через AnimeThemes. Права у создателей аниме.','source':{'url':r['url'],'metadata_url':r['metadata_url'],'source_sha256':r['source_sha256'],'name':answers[0]},'processing':{'type':'image','frame_seconds':second,'operation':'Single-frame FFmpeg extraction; no title overlay'}})
 q('anime-'+key,answers,'Назови аниме по кадру. Часть, сезон и имя персонажа называть не нужно.',mid,'anime-'+key,key)
ANIME_AUDIO=[('jujutsu','o14',['Магическая битва','Jujutsu Kaisen']),('chainsaw','o15',['Человек-бензопила','Chainsaw Man']),('tokyo-ghoul','a12',['Токийский гуль','Tokyo Ghoul']),('attack','a13',['Атака титанов','Attack on Titan','Shingeki no Kyojin']),('one-punch','o13',['Ванпанчмен','One Punch Man','Ванпанчмен: Ван-Панч Мен']),('mob','o16',['Моб Психо 100','Mob Psycho 100']),('bleach','o09',['Блич','Bleach']),('sao','o10',['Мастера меча онлайн','Sword Art Online','SAO']),('no-game','o17',['Нет игры — нет жизни','Нет игры нет жизни','No Game No Life']),('steins','o18',['Врата Штейна','Steins;Gate','Steins Gate'])]
for i,(key,oldid,answers)in enumerate(ANIME_AUDIO,1):
 mid=f'o{i:02}';previous(mid,'friends-120',oldid);q('opening-'+key,answers,'Назови аниме по фрагменту опенинга. Исполнителя и название песни угадывать не нужно.',mid,'anime-'+key,key,note='У этого сериала нет второго вопроса в теме кадров; принимается основное название без сезона.')
VOICES=[
 ('level','friends-120','a01',['Повышение уровня','Получение уровня','Level up'],'Minecraft: какое событие сопровождает этот звук?','minecraft'),
 ('alarm','friends-120','a03',['Экстренное собрание','Emergency Meeting','Собрание'],'Among Us: какое событие запускает этот сигнал?','amongus'),
 ('peon','friends-120','s11',['Батрак','Орочий батрак','Peon'],'Warcraft III: назови юнита по реплике.','wc3'),
 ('glados','friends-120','s06',['ГЛаДОС','GLaDOS','Гладос'],'Portal 2: кто произносит эту реплику?','portal2'),
 ('cj','new','gta-cj',['Си-Джей','Си Джей','CJ','Карл Джонсон','Carl Johnson'],'GTA: назови героя, который это произносит.','gta-sa'),
 ('arthas','friends-140','v04',['Артас','Артас Менетил','Arthas'],'Warcraft III: назови персонажа по реплике.','wc3'),
 ('jaina','friends-140','v03',['Джайна','Джайна Праудмур','Jaina'],'Warcraft III: назови героиню по реплике.','wc3'),
 ('lich','friends-140','v02',['Лич','Lich'],'Warcraft III: какой тип героя нежити так говорит?','wc3'),
 ('tauren','friends-140','v01',['Таурен','Tauren'],'World of Warcraft: назови расу по реплике.','wow'),
 ('murloc','friends-120','s20',['Мурлок','Murloc'],'World of Warcraft: какое существо издаёт этот звук?','wow'),
 ('invoker','friends-140','v16',['Инвокер','Invoker','Карл'],'Dota 2: назови героя по голосу.','dota2'),
 ('axe','friends-120','s19',['Акс','Axe','Могул Хан'],'Dota 2: назови героя по голосу.','dota2'),
 ('zeus','friends-140','v19',['Зевс','Zeus'],'Dota 2: назови героя по голосу.','dota2'),
 ('hoodwink','friends-140','v17',['Худвинк','Hoodwink','Белка'],'Dota 2: назови героиню по голосу.','dota2'),
 ('doomfist','new','doomfist',['Кулак Смерти','Думфист','Doomfist'],'Overwatch: назови героя по реплике.','overwatch'),
 ('villager','new','villager',['Деревенский житель','Житель','Villager'],'Minecraft: кто издаёт этот звук?','minecraft'),
 ('wisp','friends-120','s14',['Светлячок','Wisp'],'Warcraft III: назови юнита по звуку.','wc3'),
 ('acolyte','friends-120','s13',['Послушник','Acolyte'],'Warcraft III: назови юнита по реплике.','wc3'),
 ('death','friends-120','a04',['Смерть игрока','Смерть','Player death'],'Terraria: какое событие звучит?','terraria'),
 ('radio','friends-120','s07',['Враг замечен','Противник замечен','Enemy spotted'],'Counter-Strike: как по смыслу называется эта радиокоманда?','counterstrike')]
for i,(key,edition,oldid,answers,prompt,franchise)in enumerate(VOICES,1):
 mid=f'v{i:02}'
 if edition=='new':
  r=new_audio[oldid];put(mid,Path(r['file']),r)
 else:previous(mid,edition,oldid)
 q('voice-'+key,answers,prompt,mid,franchise,note='Нужен объект, персонаж или событие, указанные в вопросе. Общего названия игры недостаточно.')
MUSIC=[('sweden','friends-120','a07',['Minecraft','Майнкрафт'],'Назови игру по музыкальному фрагменту.','minecraft'),('roc','friends-120','a09',['Warcraft III','Warcraft 3','Варкрафт 3'],'Назови игру по музыкальному фрагменту.','wc3'),('stormwind','friends-120','a08',['Штормград','Stormwind'],'World of Warcraft: музыкальная тема какого города звучит?','wow'),('among','friends-120','a10',['Among Us','Амонг Ас'],'Назови игру по музыкальному фрагменту.','amongus'),('gta','new','gta-cue',['GTA San Andreas','Grand Theft Auto: San Andreas','ГТА Сан Андреас','Сан Андреас'],'GTA: в какой части звучит этот сигнал завершения миссии?','gta-sa'),('orgrimmar','friends-120','m06',['Оргриммар','Orgrimmar'],'World of Warcraft: музыкальная тема какого города звучит?','wow'),('arcane','friends-120','m13',['Warcraft III','Warcraft 3','Варкрафт 3'],'Назови игру по музыкальному фрагменту.','wc3'),('terraria','friends-120','a06',['Terraria','Террария'],'Назови игру по музыкальному фрагменту.','terraria'),('mice','friends-120','m15',['Minecraft','Майнкрафт'],'Назови игру по музыкальному фрагменту.','minecraft'),('elwynn','friends-120','m19',['Элвиннский лес','Elwynn Forest','Элвинский лес'],'World of Warcraft: тема какой стартовой локации звучит?','wow')]
for i,(key,edition,oldid,answers,prompt,franchise)in enumerate(MUSIC,1):
 mid=f'm{i:02}'
 if edition=='new':r=new_audio[oldid];put(mid,Path(r['file']),r)
 else:previous(mid,edition,oldid)
 q('music-'+key,answers,prompt,mid,franchise)
# Keep fourteen successful animal illustrations, but no repeated anime franchises.
OLD_ANIMALS=[('h01','naruto'),('h04',None),('h05',None),('h06',None),('h07','my-hero-academia'),('h08',None),('h09',None),('h11','code-geass'),('h14','hunter-x-hunter'),('h15',None),('h16',None),('h18',None),('h19','bungo-stray-dogs'),('h03','one-piece')]
old_questions={qu.get('media'):qu for r in old['friends-140']['rounds']for t in r['themes']for qu in t['questions']if qu.get('media')}
old_prompts={x['id']:x for x in json.loads((ROOT/'friends-140/generation-prompts.json').read_text())}
for oldid,anime in OLD_ANIMALS:
 previous(oldid,'friends-140',oldid);qu=old_questions[oldid];q(oldid,qu['answers'],'Персонаживотное: назови склеенное имя или обе части — животное и героя.',oldid,'anime-'+anime if anime else'warcraft',anime,note=qu['note']);generated.append(old_prompts[oldid])
NEW_ANIMALS=[('n01','воробей','Тревор Филипс',['Треворобей','Воробей + Тревор','Тревор + воробей','Воробей и Тревор Филипс'],'gta5','SPARROW + TREVOR PHILIPS, GTA V; receding hairline, dirty V-neck shirt, grey sweatpants and desert trailer'),('n02','носорог','Кратос',['Кратосорог','Носорог + Кратос','Кратос + носорог'],'god-of-war','RHINOCEROS + KRATOS; nose horn, red warpaint, beard, northern leather armour and Leviathan axe'),('n03','тюлень','Геральт',['Геральтюлень','Тюлень + Геральт','Геральт + тюлень'],'witcher','SEAL + GERALT; flippers, white hair, yellow eyes, wolf medallion, two swords and witcher leather armour'),('n04','панда','Палач Рока',['Пандумгай','Панда + Думгай','Панда + Палач Рока','Панда + Doom Slayer','Думпанда'],'doom','PANDA + DOOM SLAYER; black-and-white panda, green Praetor armour, raised helmet and Super Shotgun'),('n05','капибара','Стив',['Стивобара','Капибара + Стив','Стив + капибара'],'minecraft','CAPYBARA + STEVE; capybara snout, turquoise shirt, blue-purple pants and pixel diamond pickaxe'),('n06','косатка','Леон Кеннеди',['Леонорка','Косатка + Леон','Косатка + Леон Кеннеди','Леон + косатка'],'re4','ORCA + LEON S KENNEDY; eye patches, dorsal fin, swept blond fringe and Resident Evil 4 shearling jacket')]
for mid,animal,hero,answers,franchise,summary in NEW_ANIMALS:
 p=DEST/'media/Images'/(mid+'.png');digest=hashlib.sha256(p.read_bytes()).hexdigest();put(mid,p,{'credit':'Новая авторская иллюстрация, image_gen, Codex, 25.10.2026. Права на персонажа у его авторов.','source':{'url':'Авторская иллюстрация image_gen; generation-prompts.json#'+mid,'generator':'image_gen','source_sha256':digest,'prompt_summary':summary},'processing':{'type':'image','operation':'Original generated PNG copied byte-for-byte; no editing'}})
 q(mid,answers,'Персонаживотное: назови склеенное имя или обе части — животное и героя.',mid,franchise,note=answers[0]+' = '+animal+' + '+hero+'. Любое понятное склеенное имя или обе верные части засчитываются; одно имя героя недостаточно.');generated.append({'id':mid,'animal':animal,'hero':hero,'answer':answers[0],'generator':'image_gen','prompt_summary':summary,'sha256':digest})
# New original written questions: precise, short answers on familiar games.
TEXT=[
 ('l1',['Вариматрас','Varimathras'],'Warcraft III: The Frozen Throne. Как зовут повелителя ужаса, который перешёл на сторону Сильваны и помог ей захватить Подгород?','wc3','https://warcraft.wiki.gg/wiki/Varimathras'),
 ('l2',['Мурадин','Мурадин Бронзобород','Muradin Bronzebeard'],'Warcraft III. Какой дворф вместе с Артасом нашёл Ледяную Скорбь и пытался отговорить его от снятия проклятого клинка?','wc3','https://warcraft.wiki.gg/wiki/Muradin_Bronzebeard'),
 ('l3',['Иллидан','Иллидан Ярость Бури','Illidan Stormrage'],'Warcraft III. Кого Тиренд освободила из темницы Стражей ради войны с Пылающим Легионом?','wc3','https://warcraft.wiki.gg/wiki/Illidan_Stormrage'),
 ('l4',['Череп Гулдана','Череп Гул’дана','Skull of Gul’dan'],'Warcraft III. Какой артефакт поглотил Иллидан перед победой над Тихондрием?','wc3','https://warcraft.wiki.gg/wiki/Skull_of_Gul%27dan'),
 ('l5',['Книга Медива','Книга Медивха','Book of Medivh'],'Warcraft III. Какую книгу Кел’Тузад забрал в Даларане, чтобы призвать Архимонда?','wc3','https://warcraft.wiki.gg/wiki/Book_of_Medivh'),
 ('l6',['Душегуб','Soulkiller','Соулкиллер'],'Cyberpunk 2077. Как называется программа, создающая цифровую копию сознания и связанная с энграммами Арасаки?','cyberpunk','https://cyberpunk.fandom.com/wiki/Soulkiller'),
 ('l7',['Мерриуэзер','Мерривезер','Merryweather'],'GTA V. Какая частная военная компания охраняет грузовой корабль и офшорные объекты в одном из ограблений команды?','gta5','https://gta.fandom.com/wiki/Merryweather_Security'),
 ('l8',['Палас','Дворец','Palace'],'Counter-Strike 2, Mirage. Как игроки обычно называют помещение с балконом, откуда террористы выходят сверху на точку A?','cs2','https://counterstrike.fandom.com/wiki/Mirage'),
 ('l9',['Black King Bar','BKB','БКБ'],'Dota 2. Какой предмет активирует Avatar, давая иммунитет к отрицательным эффектам?','dota2','https://liquipedia.net/dota2/Black_King_Bar'),
 ('l10',['Хранитель','Варден','Warden'],'Minecraft. Какой слепой моб реагирует на вибрации в глубинной тьме и атакует звуковым ударом?','minecraft','https://minecraft.wiki/w/Warden'),
 ('l11',['Мок’натал','Мокнатал','Mok’nathal','Mok Nathal'],'Warcraft. Как называется клан полуорков-полуогров, из которого происходит Рексар?','wow','https://warcraft.wiki.gg/wiki/Mok%27nathal'),
 ('l12',['Испепелитель','Ashbringer'],'World of Warcraft. Как называется меч, которым Тирион Фордринг разбил Ледяную Скорбь?','wow','https://warcraft.wiki.gg/wiki/Ashbringer'),
 ('l13',['Маннорот','Mannoroth'],'Warcraft III. Какого демона убил Гром Адский Крик, освободив орков от кровавого проклятия?','wc3','https://warcraft.wiki.gg/wiki/Mannoroth'),
 ('l14',['Азшара','Azshara'],'Warcraft. Какая бывшая королева высокорождённых после Великого Раскола стала правительницей наг?','wow','https://warcraft.wiki.gg/wiki/Azshara'),
 ('l15',['Нер’зул','Нерзул','Ner’zhul','Nerzhul'],'Warcraft. Чья душа была заточена в Ледяном Троне, создав первого Короля-лича ещё до Артаса?','wc3','https://warcraft.wiki.gg/wiki/Ner%27zhul'),
 ('l16',['Гуарма','Guarma'],'Red Dead Redemption 2. На какой остров заносит банду после неудачного ограбления банка в Сен-Дени?','rdr2','https://reddead.fandom.com/wiki/Guarma'),
 ('l17',['Весемир','Vesemir'],'«Ведьмак 3». Как зовут старшего ведьмака Каэр Морхена, погибшего, защищая Цири от Имерлиха?','witcher','https://witcher.fandom.com/wiki/Vesemir'),
 ('l18',['Партурнакс','Паартурнакс','Paarthurnax'],'Skyrim. Какой дракон живёт на Глотке Мира и помогает Седобородым и Довакину?','skyrim','https://en.uesp.net/wiki/Skyrim:Paarthurnax'),
 ('l19',['Лас-Плагас','Лас Плагас','Las Plagas','Плага'],'Resident Evil 4. Как называется паразит, которым заражены жители испанской деревни и которого извлекают из Леона и Эшли?','re4','https://residentevil.fandom.com/wiki/Plaga'),
 ('l20',['Крепость Круглого стола','Круглый стол','Roundtable Hold'],'Elden Ring. Как называется убежище Погасших с кузнецом Хью и Родерикой?','elden','https://eldenring.wiki.gg/wiki/Roundtable_Hold'),
]
for key,answers,prompt,franchise,source in TEXT:q(key,answers,prompt,franchise=franchise,sources=[source])
BOSSES=[
 ('b1',['Маления','Malenia'],'Elden Ring: рыжие волосы, протез руки, арена в Эльфаэле и вторая фаза с алой гнилью. Кто это?','elden'),
 ('b2',['Гюнтер О’Дим','Гюнтер о Дим','Гюнтер О Дим','Gaunter O’Dimm','Gaunter O Dimm'],'«Ведьмак 3: Каменные сердца». Торговец зеркалами, остановка времени в таверне и контракт с Ольгердом. Назови этого персонажа.','witcher'),
 ('b3',['Дракон Края','Эндер-дракон','Эндер дракон','Ender Dragon'],'Minecraft: центральный остров Края, обсидиановые столбы и кристаллы, восстанавливающие ему здоровье. Кто босс?','minecraft'),
 ('b4',['Гэнитиро','Генитиро','Гэнитиро Асина','Genichiro Ashina'],'Sekiro: лук и катана на крыше замка Асина; затем снятые доспехи и атаки молниями. Назови противника.','sekiro'),
 ('b5',['Немезис','Nemesis'],'Resident Evil: преследует бойцов S.T.A.R.S., носит чёрное снаряжение и способен использовать ракетницу. Как зовут этого монстра?','resident-evil'),
 ('b6',['Алдуин','Alduin'],'Skyrim: появляется в Хелгене; финальная встреча с ним происходит в Совнгарде. Назови дракона.','skyrim'),
 ('b7',['Радагон','Радагон Золотого порядка','Radagon'],'Elden Ring: рыжеволосый противник с молотом, связанный с Марикой; после победы над ним начинается бой со Зверем Элдена. Кто это?','elden'),
 ('b8',['Бальдр','Балдр','Бальдур','Baldur'],'God of War: не чувствует боли из-за заклятия матери; уязвимость обнаруживается благодаря омеле. Как зовут противника?','god-of-war'),
 ('b9',['Близняшки','Левая и Правая','Левая Правая','Twins'],'Atomic Heart: две серебристые роботизированные балерины с гладкими лицевыми панелями. Как их обычно называют вместе?','atomic-heart'),
 ('b10',['Яглут','Яглутт','Yagluth'],'Valheim: огромный безногий скелет на Равнинах; использует огонь и метеориты. Назови босса.','valheim')]
for key,answers,prompt,franchise in BOSSES:q(key,answers,prompt,franchise=franchise,note='Нужен персонаж, а не название игры.')
REVIEWS=[
 ('r1',['GTA V','GTA 5','Grand Theft Auto V','ГТА 5'],'Перед убийством случайного мужика консультировался не с адвокатом, а с биржей. Самым прибыльным оружием оказался портфель акций.','gta5'),
 ('r2',['Phasmophobia','Фазмофобия','Фазма'],'Принёс распятие, а привидение отклонило подарок: оказалось, за пределами радиуса. Теперь ставлю рядом журнал и лазерную решётку.','phasmo'),
 ('r3',['Lethal Company','Летал Компани'],'Купил телепорт, который возвращает сотрудника, но оставляет всю добычу на месте. Бухгалтерия моей космической шарашки недовольна.','lethal'),
 ('r4',['Rust','Раст'],'Самый дорогой учебник — верстак третьего уровня. Учёба оплачивается металлоломом, а соседи проверяют мою каменную коробку, пока я сплю.','rust'),
 ('r5',['Stardew Valley','Стардью Валли'],'Восстановил клуб с помощью редкого товара из тележки у свиньи. Теперь деду не стыдно за мои четыре свечки.','stardew'),
 ('r6',['Red Dead Redemption 2','RDR2','RDR 2'],'Деньги спрятал не в банке: доверил их весьма гостеприимной парочке на свиноферме. Потом забрал этот депозит уже другим человеком.','rdr2'),
 ('r7',['Cyberpunk 2077','Киберпанк 2077'],'В супермаркете выбирал, кому отдать робота Flathead и стоит ли платить заражённым чипом. Дальше проблемы с чужой электроникой переехали мне в голову.','cyberpunk'),
 ('r8',['The Witcher 3','Ведьмак 3'],'Шёл искать приёмную дочь, но внезапно собрал колоду шпионов и начал обирать кузнецов в карточной игре. Дочь подождёт ещё один раунд.','witcher'),
 ('r9',['Palworld','Палворлд'],'Нанял милого зверька на конвейер, а он впал в депрессию. Оказалось, нужна кровать и нормальная еда; пулемёт трудовой спор не решает.','palworld'),
 ('r10',['Hogwarts Legacy','Хогвартс: Наследие','Хогвартс'],'Зачислили сразу на пятый курс. Чтобы лучше взламывать замки, собираю луны у каменных существ, но работать приходится только ночью.','hogwarts'),
 ('r11',['Elden Ring','Элден Ринг'],'Один подъёмник, два медальона. Нажал другую реплику у того же механизма — и открыл маршрут, о существовании которого раньше не догадывался.','elden'),
 ('r12',['Minecraft','Майнкрафт'],'Поставил зомби перед деревенскими и автоматизировал продажу железа. Производственный процесс выглядит как преступление против жителей.','minecraft'),
 ('r13',['Counter-Strike','CS2','Counter-Strike 2','CS:GO','Контр-Страйк'],'Весь вечер учил один дым на Mirage. На настоящей игре в нём снова оказалась щель, а четыре незнакомца уже всё обо мне поняли.','counterstrike'),
 ('r14',['Dota 2','Дота 2'],'Купил дорогую жёлтую кнопку, чтобы меня не превращали в лягушку. Нажал слишком поздно. Курьер тоже умер, но его хотя бы не отправили в чат.','dota2'),
 ('r15',['Detroit: Become Human','Detroit Become Human','Детройт'],'Отказался выполнять приказ — и интерфейс устроил мне пробежку сквозь красные стены. Теперь бытовое непослушание считается политической позицией.','detroit'),
 ('r16',['God of War','God of War 2018','God of War Ragnarok','God of War Ragnarök','Год оф Вар','Бог войны'],'Самый полезный навигатор висит на поясе и рассказывает истории, хотя туловища у него уже нет. Сыну не нравится мой короткий словарь.','god-of-war'),
 ('r17',['Resident Evil 4','Resident Evil 4 Remake','Обитель зла 4','RE4'],'В испанской деревне экономлю патроны так: сначала стреляю по коленям, затем предлагаю жителям бесплатный сеанс борьбы. Эшли тоже пришлось объяснить правила.','re4'),
 ('r18',['Stray','Стрей','Стрэй'],'Не починил человечество, зато открыл крышу целого города. Для эмоциональной поддержки предусмотрена отдельная кнопка мяуканья.','stray'),
 ('r19',['Among Us','Амонг Ас','Амонгас'],'Моё алиби должно было отсканироваться в медотсеке, но хозяин отключил визуальные подтверждения. Теперь я подозрительный астронавт в очереди.','amongus'),
 ('r20',['Valheim','Вальхейм','Валхейм'],'Крышу над верстаком построил. Крышу над костром тоже построил. Первое ускорило работу, второе — появление моего надгробия от дыма.','valheim')]
for key,answers,body,franchise in REVIEWS:q(key,answers,'Узнай игру по выдуманному отзыву: «'+body+'»',franchise=franchise,note='Авторская шуточная зарисовка для этого пака; это не цитата и не настоящий отзыв Steam. Угадывается игра или серия в пределах приведённых ответов.')
ANIMAL_ROUNDS=[['h01','h04','n02','n05','n03'],['h05','h07','h03','n04','n06'],['h08','h09','h11','h19','n01'],['h06','h14','h15','h16','h18']]
rounds=[]
for r in range(4):
 special=['music-'+m[0]for m in MUSIC[r//2*5:r//2*5+5]]if r%2==0 else['b'+str(i)for i in range((r//2)*5+1,(r//2)*5+6)]
 anime_keys=['anime-'+x[0]for x in ANIME_FRAMES[(r//2)*5:(r//2)*5+5]]if r%2==0 else['opening-'+x[0]for x in ANIME_AUDIO[(r//2)*5:(r//2)*5+5]]
 specs=[('Знакомые игры: кадры',[x[0]for x in GAMES[r*5:r*5+5]]),('Узнаёшь голос?',['voice-'+v[0]for v in VOICES[r*5:r*5+5]]),('Музыка и сигналы'if r%2==0 else'Боссы и злодеи',special),('Аниме: кадры'if r%2==0 else'Аниме: опенинги',anime_keys),('Лор и детали',['l'+str(i)for i in range(r*5+1,r*5+6)]),('Персонаживотные',ANIMAL_ROUNDS[r]),('Кривой отзыв',['r'+str(i)for i in range(r*5+1,r*5+6)])]
 themes=[]
 for name,keys in specs:
  assert len(keys)==5;items=[]
  for i,key in enumerate(keys,1):qu=copy.deepcopy(questions[key]);qu['price']=(r+1)*100*i;items.append(qu)
  themes.append({'name':name,'questions':items})
 rounds.append({'name':f'{r+1}-й раунд — знакомые миры','price_step':(r+1)*100,'themes':themes})
pack={'name':'БРО-ПАК — РЕМИКС: знакомые игры, аниме и персонаживотные','id':str(uuid.uuid5(uuid.NAMESPACE_URL,'logi2564/sigame/familiar-remix-140-v1')),'date':'25.10.2026','language':'ru-RU','restriction':'16+','difficulty':8,'filename':'Bro-Pack-140-Remix.siq','tags':['Персонаживотные','JoJo','GTA','Знакомые игры','Кривой отзыв'],'authors':['logi2564 — идея и подбор тем; Codex — вопросы, иллюстрации и сборка'],'expectations':{'rounds':4,'themes_per_round':7,'questions':140,'images':50,'audio':40},'description':'Переработанная версия для друзей: 140 вопросов в четырёх раундах. Знакомые игры, современная подборка аниме с JoJo, без повторов аниме-франшиз; 20 персонаживотных, 20 авторских кривых отзывов, голоса, короткие музыкальные фрагменты, боссы и лор. Warcraft III и World of Warcraft сохранены по просьбе автора. Terraria — только два вопроса. Сложность за счёт деталей знакомых миров. У персонаживотных принимается склейка или обе верные части. Все медиа встроены.','rounds':rounds}
assert sum(len(t['questions'])for r in rounds for t in r['themes'])==len(questions)==140
final_path=DEST/'final-round.json'
if final_path.exists():
 pack['rounds'].append(json.loads(final_path.read_text(encoding='utf-8')))
 pack['name']='БРО-ПАК — РЕМИКС + ФИНАЛ: 141 вопрос'
 pack['id']=str(uuid.uuid5(uuid.NAMESPACE_URL,'logi2564/sigame/familiar-remix-141-final-v1'))
 pack['filename']='Bro-Pack-141-Remix-Final.siq'
 pack['expectations'].update(rounds=5,questions=141)
 pack['description']=pack['description'].replace('140 вопросов в четырёх раундах.','140 вопросов в четырёх обычных раундах и пятый раунд — настоящий финал со ставками и одним вопросом. Всего 141 вопрос.')
(DEST/'pack.json').write_text(json.dumps(pack,ensure_ascii=False,indent=2)+'\n');(DEST/'media-sources.json').write_text(json.dumps(media,ensure_ascii=False,indent=2)+'\n');(DEST/'generation-prompts.json').write_text(json.dumps(generated,ensure_ascii=False,indent=2)+'\n')
# Only used, opaque files go to the deliverable source folder.
kept={m['path']for m in media}
for p in (DEST/'media').rglob('*'):
 if p.is_file()and p.relative_to(DEST/'media').as_posix()not in kept:p.unlink()
print('Composed',sum(len(t['questions'])for r in pack['rounds']for t in r['themes']),'questions with',len(media),'distinct media files')

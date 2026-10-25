"""Build a self-contained HTML SIQ pack and a QR-only compatibility pack."""
from __future__ import annotations
import base64,hashlib,json,subprocess,sys,zipfile
from pathlib import Path
import xml.etree.ElementTree as ET

ROOT=Path(__file__).resolve().parents[2]
SITE=ROOT/'mini-games';OUT=ROOT/'dist/arcade'
NS='http://vladimirkhil.com/ygpackage3.0.xsd'
PUBLIC='https://rawcdn.githack.com/logi2564/imperii-online/arcade-61-v1/mini-games/index.html'

def catalog():
 source="global.window={};"+(SITE/'catalog.js').read_text()+";process.stdout.write(JSON.stringify(window.ARCADE_GAMES));"
 return json.loads(subprocess.check_output(['node','-e',source],text=True))

def node(parent,tag,text=None,**attrs):
 e=ET.SubElement(parent,'{'+NS+'}'+tag,{k:str(v) for k,v in attrs.items()})
 if text is not None:e.text=text
 return e

def info(parent,comment=''):
 n=node(parent,'info');node(n,'authors');node(n,'sources');node(n,'comments',comment)

def standalone(meta):
 css=(SITE/'style.css').read_text();qr=base64.b64encode((SITE/'assets'/('qr-'+meta['id']+'.png')).read_bytes()).decode()
 bootstrap='window.ENTRY_GAME='+json.dumps(meta['id'])+';window.ENTRY_QR="data:image/png;base64,'+qr+'";window.ARCADE_GAMES='+json.dumps([meta],ensure_ascii=False)+';'
 scripts='\n'.join((SITE/n).read_text() for n in ['engine.js','games.js','app.js'])
 # No scripts, fonts, media, or libraries are requested over the network.
 return ('<!doctype html><html lang="ru"><head><meta charset="utf-8"><meta name="viewport" content="width=device-width,initial-scale=1,viewport-fit=cover"><title>'+meta['title']+' — БРО Аркада</title><style>'+css+'</style></head><body><div id="app"></div><script>'+bootstrap+'\n'+scripts+'</script></body></html>').encode()

def build_one(games,html_mode):
 ET.register_namespace('',NS)
 name='Bro-Arcade-61'+('' if html_mode else '-QR')+'.siq'
 package=ET.Element('{'+NS+'}package',name='БРО · АРКАДА — 61 мини-игра'+('' if html_mode else ' · QR'),version='4',id='7b29df77-b675-4b96-a374-'+('f7d396191001' if html_mode else 'f7d396191002'),restriction='12+',date='25.10.2026',difficulty='5')
 info(package,'Каждый проходит мини-игру на своём устройстве и получает ответ после победы. Включите фальстарты (ответ до окончания вопроса). На HTML/QR-сцену отведено время игры + 45 секунд; ведущий может поставить показ на паузу. Правила и ограничение просмотра исходников — в инструкции.')
 rounds=node(package,'rounds');files={};questions=0
 genre_order=['Ловкость','Головоломки','Память','Точность','Стратегии','Эксперименты']
 for r in range(3):
  final=r==2;rn=node(rounds,'round',name=['I · Выбирай приключение','II · Больше азарта','Финал · Рейд на Хранителя'][r],type='final' if final else 'standart');info(rn);themes=node(rn,'themes')
  for genre in (['Финал'] if final else genre_order):
   t=node(themes,'theme',name=genre);info(t);qs=node(t,'questions');selection=[g for g in games if g['genre']==genre];selection=selection if final else selection[r*5:r*5+5]
   for index,g in enumerate(selection):
    q=node(qs,'question',price=0 if final else (index+1)*(100 if r==0 else 200));questions+=1
    info(q,f"№{g['index']}. {g['title']}. {g['seconds']} секунд на игру + 45 секунд на открытие. Ответ виден в личной игре только после победы. Ссылка: {PUBLIC}?g={g['id']}")
    node(q,'type',name='stakeAll' if final else 'simple');scenario=node(q,'scenario')
    node(scenario,'atom',f"Мини-игра №{g['index']}: «{g['title']}». Каждый играет у себя. Пройди игру и назови полученный секретный ответ.",type='say')
    image_name=g['id']+'.png';image=(ROOT/'sigame-arcade/cards'/image_name).read_bytes();files['Images/'+image_name]=image
    node(scenario,'atom','@'+image_name,type='image',time=5 if html_mode else g['seconds']+45)
    if html_mode:
     filename=g['id']+'.html';files['Html/'+filename]=standalone(g)
     node(scenario,'atom','@'+filename,type='html',time=g['seconds']+45)
    right=node(q,'right');node(right,'answer',g['answer']);node(q,'wrong')
 assert questions==61
 types=ET.Element('Types',xmlns='http://schemas.openxmlformats.org/package/2006/content-types')
 for ext,mime in [('xml','si/xml'),('png','image/png'),('html','text/html')]:ET.SubElement(types,'Default',Extension=ext,ContentType=mime)
 ET.indent(package,space='  ')
 files.update({'content.xml':ET.tostring(package,encoding='utf-8',xml_declaration=True),'[Content_Types].xml':ET.tostring(types,encoding='utf-8',xml_declaration=True),'Texts/authors.xml':b'<?xml version="1.0" encoding="utf-8"?><authors/>','Texts/sources.xml':b'<?xml version="1.0" encoding="utf-8"?><sources/>'})
 path=OUT/name
 with zipfile.ZipFile(path,'w',zipfile.ZIP_DEFLATED,compresslevel=9) as z:
  for filename,data in sorted(files.items()):z.writestr(filename,data)
 (OUT/(name+'.sha256')).write_text(hashlib.sha256(path.read_bytes()).hexdigest()+'  '+name+'\n')
 return {'file':name,'sha256':hashlib.sha256(path.read_bytes()).hexdigest(),'bytes':path.stat().st_size,'questions':61,'html':61 if html_mode else 0,'images':61,'rounds':3,'final_rounds':1,'questions_time_min':min(g['seconds']+45 for g in games),'questions_time_max':max(g['seconds']+45 for g in games)}

def prepare():
 import qrcode
 games=catalog();(SITE/'assets').mkdir(exist_ok=True)
 assert len(games)==61 and len({g['mechanic'] for g in games})==61
 assert all(90<=g['seconds']<=300 for g in games)
 for g in games:
  qr=qrcode.QRCode(box_size=7,border=3,error_correction=qrcode.constants.ERROR_CORRECT_M);qr.add_data(PUBLIC+'?g='+g['id']);qr.make(fit=True);qr.make_image(fill_color='#15221f',back_color='#ffffff').save(SITE/'assets'/('qr-'+g['id']+'.png'))
 (ROOT/'sigame-arcade/catalog.json').write_text(json.dumps(games,ensure_ascii=False,indent=2)+'\n')
 print('Prepared 61 unique mechanics and QR codes.')

def build():
 games=catalog();OUT.mkdir(parents=True,exist_ok=True);results=[build_one(games,True),build_one(games,False)]
 (OUT/'build-info.json').write_text(json.dumps({'games':61,'distinct_mechanics':61,'rounds':3,'themes_per_standard_round':6,'final_questions':1,'game_seconds_min':min(g['seconds'] for g in games),'game_seconds_max':max(g['seconds'] for g in games),'packs':results},ensure_ascii=False,indent=2)+'\n')
 (OUT/'How-to-play.txt').write_text((ROOT/'sigame-arcade/HOW-TO-PLAY.txt').read_text(),encoding='utf-8-sig')
 with zipfile.ZipFile(OUT/'Bro-Arcade-61-Offline.zip','w',zipfile.ZIP_DEFLATED,compresslevel=9) as z:
  for p in SITE.rglob('*'):
   if p.is_file():z.write(p,'Bro-Arcade/'+str(p.relative_to(SITE)))
  for g in games:z.writestr(f"Standalone-Games/{g['id']}.html",standalone(g))
  z.write(OUT/'How-to-play.txt','How-to-play.txt')
  for result in results:z.write(OUT/result['file'],result['file'])
 print(json.dumps(results,ensure_ascii=False,indent=2))
if __name__=='__main__':prepare() if '--prepare' in sys.argv else build()

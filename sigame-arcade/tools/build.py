"""Build an in-question-only SIGame pack: no QR cards, links, or external assets."""
from __future__ import annotations
import hashlib, json, subprocess, sys, zipfile
from pathlib import Path
import xml.etree.ElementTree as ET
ROOT=Path(__file__).resolve().parents[2]
SITE=ROOT/'mini-games';OUT=ROOT/'dist/blitz'
NS='http://vladimirkhil.com/ygpackage3.0.xsd'
NAME='Bro-Arcade-Blitz-61.siq'

def catalog():
 source='global.window={};'+(SITE/'catalog.js').read_text()+';process.stdout.write(JSON.stringify(window.ARCADE_GAMES));'
 return json.loads(subprocess.check_output(['node','-e',source],text=True))

def node(parent,tag,text=None,**attrs):
 e=ET.SubElement(parent,'{'+NS+'}'+tag,{k:str(v) for k,v in attrs.items()})
 if text is not None:e.text=text
 return e

def info(parent,comment=''):
 n=node(parent,'info');node(n,'authors');node(n,'sources');node(n,'comments',comment)

def standalone(g):
 css=(SITE/'style.css').read_text()
 # Each phone downloads and parses just this game's code, not the entire arcade.
 source=(SITE/'games.js').read_text()
 lines=[line for line in source.splitlines() if not line.startswith("R('") or line.startswith("R('"+g['mechanic']+"',")]
 selected='\n'.join(lines)
 assert selected.count("\nR('")==1
 bootstrap='window.ENTRY_GAME='+json.dumps(g['id'])+';window.ARCADE_GAMES='+json.dumps([g],ensure_ascii=False)+';'
 scripts='\n'.join([(SITE/'engine.js').read_text(),selected,(SITE/'app.js').read_text()])
 return ('<!doctype html><html lang="ru"><head><meta charset="utf-8"><meta name="viewport" content="width=device-width,initial-scale=1,viewport-fit=cover"><title>'+g['title']+' — БРО БЛИЦ</title><style>'+css+'</style></head><body><div id="app"></div><script>'+bootstrap+'\n'+scripts+'</script></body></html>').encode()

def prepare():
 games=catalog()
 assert len(games)==len({g['mechanic'] for g in games})==61
 assert all(15<=g['seconds']<=35 for g in games[:-1]) and games[-1]['seconds']==40
 assert len({g['answer'] for g in games})==61
 (ROOT/'sigame-arcade/catalog.json').write_text(json.dumps(games,ensure_ascii=False,indent=2)+'\n')
 print('Prepared 61 short games: 15–35s, final 40s; no QR generation.')

def build():
 games=catalog();OUT.mkdir(parents=True,exist_ok=True)
 ET.register_namespace('',NS)
 package=ET.Element('{'+NS+'}package',name='БРО · БЛИЦ — 61 мини-игра прямо в СИГейме',version='4',id='7b29df77-b675-4b96-a374-f7d396192001',restriction='12+',date='25.10.2026',difficulty='3')
 info(package,'Для SI Online с HTML-контентом. Игры встроены в вопросы. 5 секунд подготовки, затем автоматический старт; 15–35 секунд на игру, финал 40. Ответ виден в личной игре после победы. Включите фальстарты. Пауза и возобновление клиента поддерживаются. Сайты и QR-коды не нужны.')
 rounds=node(package,'rounds');files={};questions=0
 genres=['Ловкость','Головоломки','Память','Точность','Стратегии','Эксперименты']
 for r in range(3):
  final=r==2;rn=node(rounds,'round',name=['I · Быстрый старт','II · Ещё по одной','Финал · Хранитель'][r],type='final' if final else 'standart');info(rn);themes=node(rn,'themes')
  for genre in (['Финал'] if final else genres):
   theme=node(themes,'theme',name=genre);info(theme);qs=node(theme,'questions');selection=[g for g in games if g['genre']==genre];selection=selection if final else selection[r*5:r*5+5]
   for index,g in enumerate(selection):
    q=node(qs,'question',price=0 if final else (index+1)*(100 if r==0 else 200));questions+=1
    info(q,f"№{g['index']} · {g['title']}. Подготовка 5 с; игра {g['seconds']} с; 3 с запаса на ответ. Всё открывается прямо в вопросе.")
    node(q,'type',name='stakeAll' if final else 'simple');scenario=node(q,'scenario')
    filename=g['id']+'.html';files['Html/'+filename]=standalone(g)
    node(scenario,'atom','@'+filename,type='html',time=g['seconds']+g['prepSeconds']+3)
    right=node(q,'right');node(right,'answer',g['answer']);node(q,'wrong')
 assert questions==61
 types=ET.Element('Types',xmlns='http://schemas.openxmlformats.org/package/2006/content-types')
 for ext,mime in [('xml','si/xml'),('html','text/html')]:ET.SubElement(types,'Default',Extension=ext,ContentType=mime)
 ET.indent(package,space='  ')
 files.update({'content.xml':ET.tostring(package,encoding='utf-8',xml_declaration=True),'[Content_Types].xml':ET.tostring(types,encoding='utf-8',xml_declaration=True),'Texts/authors.xml':b'<?xml version="1.0" encoding="utf-8"?><authors/>','Texts/sources.xml':b'<?xml version="1.0" encoding="utf-8"?><sources/>'})
 path=OUT/NAME
 with zipfile.ZipFile(path,'w',zipfile.ZIP_DEFLATED,compresslevel=9) as z:
  for filename,data in sorted(files.items()):z.writestr(filename,data)
 sha=hashlib.sha256(path.read_bytes()).hexdigest();(OUT/(NAME+'.sha256')).write_text(sha+'  '+NAME+'\n')
 details={'file':NAME,'sha256':sha,'bytes':path.stat().st_size,'games':61,'uniqueMechanics':61,'htmlFiles':61,'imageFiles':0,'qrCodes':0,'rounds':3,'finalQuestions':1,'prepSeconds':5,'standardSecondsMin':15,'standardSecondsMax':35,'finalSeconds':40,'totalGameBudgetSeconds':sum(g['seconds'] for g in games),'totalQuestionMediaSeconds':sum(g['seconds']+8 for g in games),'htmlBytesMax':max(len(standalone(g))for g in games)}
 (OUT/'build-info.json').write_text(json.dumps(details,ensure_ascii=False,indent=2)+'\n')
 (OUT/'How-to-play.txt').write_text((ROOT/'sigame-arcade/HOW-TO-PLAY.txt').read_text(),encoding='utf-8-sig')
 print(json.dumps(details,ensure_ascii=False,indent=2))
if __name__=='__main__':prepare() if '--prepare'in sys.argv else build()

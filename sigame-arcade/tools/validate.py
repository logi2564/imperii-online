import hashlib,json,re,zipfile
from pathlib import Path
import xml.etree.ElementTree as ET
ROOT=Path(__file__).resolve().parents[2];N={'s':'http://vladimirkhil.com/ygpackage3.0.xsd'}
games=json.loads((ROOT/'sigame-arcade/catalog.json').read_text());byid={g['id']:g for g in games}
assert len(games)==len({g['mechanic']for g in games})==len({g['answer']for g in games})==61
assert all(15<=g['seconds']<=35 for g in games[:-1])and games[-1]['seconds']==40
path=ROOT/'dist/blitz/Bro-Arcade-Blitz-61.siq'
with zipfile.ZipFile(path)as z:
 assert z.testzip()is None
 assert len([n for n in z.namelist()if n.startswith('Html/')])==61
 assert not any(n.startswith(('Images/','Audio/','Video/'))for n in z.namelist())
 tree=ET.fromstring(z.read('content.xml'));rounds=tree.findall('s:rounds/s:round',N);assert len(rounds)==3
 assert rounds[-1].attrib['type']=='final'
 qs=tree.findall('.//s:question',N);assert len(qs)==61;total=0
 for q in qs:
  atoms=q.findall('s:scenario/s:atom',N);assert len(atoms)==1
  atom=atoms[0];assert atom.attrib['type']=='html'and atom.text.startswith('@')
  game=byid[atom.text[1:-5]];duration=int(atom.attrib['time']);assert duration==game['seconds']+8;total+=duration
  assert q.find('s:right/s:answer',N).text==game['answer']
  html=z.read('Html/'+atom.text[1:]).decode();assert len(html.encode())<30000
  assert 'window.ENTRY_GAME="'+game['id']+'"'in html
  assert 'Arcade.prime()'in html and 'si:media-control'in html
  assert 'ENTRY_QR'not in html and 'qr-wrap'not in html and 'Open the page'not in html
  assert not re.search(r'<(?:script|img|link)\b[^>]*(?:src|href)=',html)
 assert qs[-1].find('s:type',N).attrib['name']=='stakeAll'
 assert total==2048
print('PASS: 61 in-question HTML games, no QR/media links, 15–35s + 5s preparation, final 40s, one stakeAll final')
print(path.name,path.stat().st_size,'bytes',hashlib.sha256(path.read_bytes()).hexdigest())

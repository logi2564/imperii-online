import hashlib,json,zipfile,re
from pathlib import Path
import xml.etree.ElementTree as ET
ROOT=Path(__file__).resolve().parents[2]
N={'s':'http://vladimirkhil.com/ygpackage3.0.xsd'}
games=json.loads((ROOT/'sigame-arcade/catalog.json').read_text())
assert len(games)==len({g['mechanic'] for g in games})==61
assert min(g['seconds'] for g in games)>=90
assert len({g['answer'] for g in games})==61
for suffix in ['', '-QR']:
 path=ROOT/f'dist/arcade/Bro-Arcade-61{suffix}.siq'
 with zipfile.ZipFile(path) as z:
  assert z.testzip() is None
  tree=ET.fromstring(z.read('content.xml'))
  rounds=tree.findall('s:rounds/s:round',N);assert len(rounds)==3
  assert rounds[-1].attrib['type']=='final'
  qs=tree.findall('.//s:question',N);assert len(qs)==61
  for q in qs:
   atoms=q.findall('s:scenario/s:atom',N)
   media=[a for a in atoms if a.attrib.get('type') in ['html','image']]
   for atom in media:
    folder='Html' if atom.attrib['type']=='html' else 'Images'
    filename=atom.text[1:];assert folder+'/'+filename in z.namelist()
    if folder=='Html':
     html=z.read(folder+'/'+filename).decode();assert 'window.ENTRY_GAME=' in html
     assert not re.search(r'<script[^>]+src=',html)
   assert int(media[-1].attrib['time'])>=135
  assert qs[-1].find('s:type',N).attrib['name']=='stakeAll'
 print(path.name,'PASS',path.stat().st_size,'bytes',hashlib.sha256(path.read_bytes()).hexdigest())
print('PASS: 61 unique mechanics and reward words, offline embedded content, variable >=90s budgets, long SI question durations')

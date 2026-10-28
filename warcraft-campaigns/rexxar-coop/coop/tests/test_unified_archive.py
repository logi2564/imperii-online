"""Inspect the actual released MPQ and classic binary control/skill fields."""
import json,re,struct,sys
from pathlib import Path
sys.path.insert(0,str(Path(__file__).resolve().parents[1]))
from formats import read_info,read_objects,ABILITY_POINTERS
from storm import Storm
from unified_catalog import ALL_KINDS
from kits import HEROES
out=Path(sys.argv[1]);st=Storm();h=st.open(out/'Maps/Rexxar-VII-Coop-1.26.w3x')
try:
 script=st.read(h,'war3map.j').decode();assert script==(out/'Rexxar-VII.j').read_text()
 info=read_info(st.read(h,'war3map.w3i'))
 assert [p['id'] for p in info['players'] if p['controller']==1]==[0,1,2,3]
 assert [p['id'] for p in info['players']]==list(range(12))
 assert all((p['controller']==1)==(p['id']<4) for p in info['players'])
 tables={kind:read_objects(st.read(h,path),level) for kind,(path,level) in ALL_KINDS.items()}
 abilities={o['new']:o for o in tables['ability'][1]};units={o['new']:o for o in tables['unit'][1]}
 def value(obj,key,level=None):
  mod=next(m for m in reversed(obj['mods']) if m[0]==key and (level is None or m[2]==level))
  return mod[4].decode() if mod[1]==3 else struct.unpack('<i' if mod[1]==0 else '<f',mod[4])[0]
 types=json.loads((Path(__file__).resolve().parents[1]/'metadata-types.json').read_text())['types']
 for table in tables.values():
  for group in table:
   for obj in group:
    for mod in obj['mods']:
     if mod[0] in types:assert mod[1]==types[mod[0]],(obj['new'],mod[0],mod[1],types[mod[0]])
 for role in range(4):
  menu=units[f'uC0{role}'.encode()];assert menu['old']==b'hfoo'
  ids=value(menu,'uabi').split(',');assert ids==[f'uM{i:02}' for i in range(12)]+['Avul']
  assert value(menu,'umvs')==0 and value(menu,'uaen')==0
  assert 'HeroTaurenChieftainCIN' in value(menu,'umdl') if role==3 else True
  tga=st.read(h,f'RexxarUI\\Hero{role}.tga');assert tga and tga[2]==2 and struct.unpack_from('<HH',tga,12)==(1024,1024)
  # Uncompressed TGA, bottom-up origin. Native bottom-third HUD is unobscured.
  offset=18+tga[0];assert all(tga[offset+i*4+3]==0 for i in range(1024*330))
 for raw,obj in abilities.items():
  if raw.startswith((b'uM',b'R4',b'R7')):
   for mod in obj['mods']:
    if mod[0].startswith('Ncl'):assert mod[3]==ABILITY_POINTERS[mod[0]],(raw,mod)
 for slot in range(12):
  a=abilities[f'uM{slot:02}'.encode()]
  assert value(a,'Ncl2',1)==0 and value(a,'Ncl3',1)==1 and value(a,'amcs',1)==0 and value(a,'acdn',1)==0
  assert (value(a,'abpx'),value(a,'abpy'))==(slot%4,slot//4)
 assert len({value(abilities[f'uM{i:02}'.encode()],'Ncl6',1) for i in range(12)})==12
 for role in range(4):
  for slot in range(4):
   a=abilities[f'R4{role}{slot}'.encode()];proxy=abilities[f'R7{role}{slot}'.encode()]
   assert value(a,'aher')==0 and value(proxy,'aher')==1
   for rank in range(1,4 if slot==3 else 6):assert value(a,'Ncl3',rank)==1 and value(proxy,'Ncl3',rank)==0
 assert b'MaxHeroLevel=20' in st.read(h,'war3mapMisc.txt')
 for z in range(17):
  assert f'function UZ_InitZ{z:02} ' in script and f'function Z{z:02}_InitCustomTriggers ' in script
  assert f'function UZ_ReturnZ{z:02} ' in script and f'function UZ_ExportZ{z:02} ' in script
 for forbidden in ['ChangeLevel','StartCampaignAI','LoadGame','SaveGameExists','CopySaveGameBJ','TriggerRegisterGameSavedEventBJ','SetMissionAvailable']:
  assert not re.search(r'\bcall '+forbidden+r'\s*\(',script),forbidden
  # Also reject condition-valued single-player disk checks.
  assert not re.search(r'(?<!function )\bSaveGameExists\s*\(',script)
 for m in re.finditer(r'function (Z\d+_Trig_Zone_to_\w+_Actions) takes[^\n]*\n([\s\S]*?)endfunction',script):
  if 'RC_Transition(' in m[2]:assert 'DisableTrigger(' not in m[2] and 'TriggerSleepAction(' not in m[2]
 literal=re.compile(r'"(?:[^"\\]|\\.)*"');assert max(len(v[0].encode()) for v in literal.finditer(script))<=1025
 print('PASS actual MPQ: four lobby humans, seventeen namespaced original locations, all object table types, classic Channel pointers/slots/unique orders, sixteen learnable kits, transparent native HUD, no single-player load/disk-save transitions.')
finally:st.close(h)

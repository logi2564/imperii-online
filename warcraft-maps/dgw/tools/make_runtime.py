from pathlib import Path
import json
root=Path(__file__).resolve().parents[1];catalog=json.loads((root/'source/catalog.json').read_text());layout=json.loads((root/'source/layout.json').read_text());lines=['function DGW_LoadData takes nothing returns nothing','    set DGW_Data=InitHashtable()']
def raw(s):return "'"+s+"'"
def literal(s):return json.dumps(s,ensure_ascii=False)
for f in catalog['factions']:
 n=f['id']
 for var,key in [('Worker','worker'),('HQ1','hq'),('HQ2','hq'),('HQ3','hq'),('Farm','buildings'),('Barracks','buildings'),('Altar','buildings'),('ChampionType','champion'),('GodType','avatar'),('Spell','spell')]:
  v=f[key]
  if key=='hq':v=v[int(var[-1])-1]
  elif key=='buildings':v=v[{'Farm':0,'Barracks':1,'Altar':4}[var]]
  lines.append(f'    set DGW_{var}[{n}]={raw(v)}')
 for var,key in [('RaceName','name'),('GodName','god'),('Trait','trait')]:lines.append(f'    set DGW_{var}[{n}]={literal(f[key])}')
 lines.append(f"    call SaveInteger(DGW_Data,{n},11,{raw(f['skills'].split(',')[0])})")
 for key,kind in [('worker',1),('hq',2),('buildings',3),('army',4),('champion',5),('avatar',6)]:
  values=f[key]if isinstance(f[key],list)else[f[key]]
  for index,id in enumerate(values):
   lines.append(f'    call SaveInteger(DGW_Data,{raw(id)},1,{kind})')
   lines.append(f'    call SaveInteger(DGW_Data,{raw(id)},2,{n})')
   if key=='hq':lines.append(f'    call SaveInteger(DGW_Data,{raw(id)},3,{index+1})')
 for i,u in enumerate(f['units']):
  for var,key in [('Army','id'),('ArmyGold','gold'),('ArmyWood','wood'),('ArmyFood','food'),('ArmyTier','tier')]:lines.append(f"    set DGW_{var}[{n*8+i}]={raw(u[key])if key=='id'else u[key]}")
for s in layout['starts']:
 for axis in ['x','y']:lines.append(f"    set DGW_Start{axis.upper()}[{s['player']}]={s[axis]}.0")
for i,s in enumerate(layout['shrines']):
 for axis in ['x','y']:lines.append(f"    set DGW_Shrine{axis.upper()}[{i}]={s[axis]}.0")
lines.append('endfunction')
code='\n'.join(lines)+'\n\n'+(root/'source/gameplay.j').read_text();(root/'source/expansion.j').write_text(code);print('Generated',len(code),'characters of standalone expansion JASS')

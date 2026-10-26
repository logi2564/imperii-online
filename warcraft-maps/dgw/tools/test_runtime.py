"""Execute the actual JASS, transpiled by War3Net, against controlled native mocks.
This checks game-state rules, not Warcraft rendering/pathfinding/real networking.
"""
from pathlib import Path
import sys,json
from lupa import LuaRuntime
root=Path(sys.argv[1]);source=Path(sys.argv[2]).read_text();catalog=json.loads((root/'source/catalog.json').read_text())
def setup(count=2):
 lua=LuaRuntime(unpack_returned_tuples=True);lua.execute((root/'tools/runtime_mocks.lua').read_text());lua.execute(source);g=lua.globals()
 for obj in catalog['objects']:
  f={m['id']:m['value']for m in obj['fields']};abilities=lua.table_from({g.FourCC(a):True for a in f.get('uabi','').split(',')if a});g.WORLD.defs[g.FourCC(obj['id'])]=lua.table_from(dict(hp=f.get('uhpm',1000),worker=f.get('utyp')=='peon',structure='utra'in f,hero=obj['id'][0].isupper(),abilities=abilities))
 g.DGW_LoadData();g.DGW_Pending=count;g.DGW_InitialPlayers=count
 for p in range(count):g.DGW_Active[p]=True;g.DGW_Alive[p]=True;g.DGW_Dialog[p]=g.DialogCreate()
 for s in range(5):g.DGW_Shrine[s]=g.CreateUnit(15,g.FourCC('dS00'),g.DGW_ShrineX[s],g.DGW_ShrineY[s],270);g.DGW_CapturePlayer[s]=-1
 return lua,g
checks=0
for race in range(1,17):
 lua,g=setup();g.DGW_ChooseRace(0,race);assert not g.DGW_Begun and g.DGW_Main[0]is None and len(g.WORLD.units)==5
 g.DGW_ChooseRace(0,2);assert g.DGW_Pending==1 and g.DGW_Race[0]==race
 g.DGW_ChooseRace(1,17-race);assert g.DGW_Begun and g.DGW_Pending==0
 for p in range(2):assert g.WORLD.players[p].gold==750 and g.WORLD.players[p].wood==400 and g.DGW_Faith[p]==10
 expected=g.FourCC(catalog['factions'][race-1]['hq'][0]);assert g.DGW_Main[0].id==expected
 assert sum(u.owner==0 and u.worker for _,u in g.WORLD.units.items())==5
 before=len(g.WORLD.units);g.DGW_ChooseRace(0,1);assert len(g.WORLD.units)==before and g.DGW_Pending==0
 checks+=1
lua,g=setup();g.DGW_ShowMenu(0);g.DGW_ShowMenu(1);g.WORLD.events.player=0;g.WORLD.events.button=g.DGW_Button[12];g.DGW_MenuClick();assert not g.DGW_Chosen[0];checks+=1
lua,g=setup();g.DGW_ChooseRace(0,1)
for i in range(90):g.DGW_Tick()
assert g.DGW_Begun and g.DGW_Chosen[1]and g.WORLD.players[0].gold==750 and g.WORLD.players[1].gold==750;checks+=1
lua,g=setup();g.DGW_ChooseRace(0,1);g.WORLD.events.player=1;g.DGW_Leave();assert g.DGW_Begun and g.DGW_Pending==0 and not g.DGW_Alive[1];checks+=1
for race in range(1,17):
 lua,g=setup();g.DGW_ChooseRace(0,race);g.DGW_ChooseRace(1,1)
 assert not g.DGW_TryAscend(0)and not g.DGW_Ascended[0]
 g.DGW_Main[0].id=g.DGW_HQ3[race];g.WORLD.players[0].gold=1600;g.WORLD.players[0].wood=700;g.DGW_Faith[0]=149
 assert not g.DGW_TryAscend(0)and g.WORLD.players[0].gold==1600
 g.DGW_Faith[0]=300;before=len(g.WORLD.units);assert g.DGW_TryAscend(0);assert len(g.WORLD.units)==before+1 and g.WORLD.players[0].gold==800 and g.WORLD.players[0].wood==350 and g.DGW_Faith[0]==150
 assert not g.DGW_TryAscend(0)and len(g.WORLD.units)==before+1 and g.DGW_Faith[0]==150
 g.WORLD.events.unit=g.DGW_God[0];g.WORLD.events.spell=g.DGW_Spell[race];g.WORLD.events.x=3000;g.WORLD.events.y=3000
 enemy=g.CreateUnit(1,g.DGW_Army[8],3000,3000,270);g.DGW_SpellCast();assert enemy.hp<enemy.maxhp
 checks+=1
lua,g=setup();g.DGW_ChooseRace(0,1);g.DGW_ChooseRace(1,2);x,y=g.DGW_ShrineX[0],g.DGW_ShrineY[0];worker=g.CreateUnit(0,g.DGW_Worker[1],x,y,270)
for _ in range(7):g.DGW_ShrineTick()
assert g.DGW_Shrine[0].owner==15
fighter=g.CreateUnit(0,g.DGW_Army[8],x,y,270)
for _ in range(3):g.DGW_ShrineTick()
contest=g.CreateUnit(1,g.DGW_Army[16],x,y,270);g.DGW_ShrineTick();assert g.DGW_CaptureTime[0]==0
contest.x=20000
for _ in range(5):g.DGW_ShrineTick()
assert g.DGW_Shrine[0].owner==0;before=g.WORLD.players[0].gold;g.DGW_Income();assert g.DGW_ShrineCount[0]==1 and g.WORLD.players[0].gold==before+85 and g.DGW_Faith[0]==17;checks+=1
lua,g=setup();g.DGW_ChooseRace(0,1);g.DGW_ChooseRace(1,2);g.DGW_Main[0].hp=0;g.DGW_Income();assert not g.DGW_Alive[0]and g.DGW_Ended and len(g.WORLD.victories)==1 and g.WORLD.victories[1]==1;checks+=1
lua,g=setup();g.DGW_ChooseRace(0,1);g.DGW_ChooseRace(1,2);g.DGW_God[0]=g.CreateUnit(0,g.DGW_GodType[1],0,0,270)
for i in range(3):g.DGW_Shrine[i].owner=0
g.DGW_Time=1199;g.DGW_Income();assert g.DGW_Hold[0]==0 and not g.DGW_Ended
g.DGW_Time=1200
for _ in range(23):g.DGW_Income()
assert g.DGW_Hold[0]==115 and not g.DGW_Ended
g.DGW_Income();assert g.DGW_Ended and g.WORLD.victories[1]==0;checks+=1
print(f'PASS: {checks} actual-JASS runtime scenarios: all 16 faction starts and divine spells, simultaneous start, duplicate/foreign clicks, timeout/leave, ascension resource rules, contested capture/income, capital defeat and timed shrine victory. Native rendering/networking not simulated.')

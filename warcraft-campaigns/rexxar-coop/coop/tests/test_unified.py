"""Run the exact generated campaign code at explicit native boundaries."""
import sys,json,re
from pathlib import Path
from lupa import LuaRuntime
ROOT=Path(__file__).resolve().parent
source=Path(sys.argv[1])

def setup(players=(0,1,2,3),source_init=False):
 lua=LuaRuntime(unpack_returned_tuples=True);lua.execute((ROOT/'natives.lua').read_text());lua.execute((ROOT/'unified_natives.lua').read_text());lua.execute(source.read_text());g=lua.globals()
 for p in range(4):g.WORLD.players[p].state='playing' if p in players else 'empty'
 # Do not emulate 17 cinematic/quest initializers. The engine lifecycle,
 # dispatch, freezes, timers, transfers and progression below are REAL code.
 for z in range(17):
  def init(z=z):g.UZ_initialized[z]=True
  g[f'UZ_InitZ{z:02}']=init
  g[f'UZ_EnvironmentZ{z:02}']=lambda:None
  g[f'Z{z:02}_RunInitializationTriggers']=lambda:None
  g[f'UZ_ReturnZ{z:02}']=lambda:None
  g[f'UZ_ExportZ{z:02}']=lambda:None
  # Original map code updates these booleans at scene boundaries.
  g[f'Z{z:02}_udg_InCinematic']=False
 g.UZ_Bootstrap()
 return lua,g

def start(g):g.RC_Begin();g.UZ_FinishEntry()
def advance(g,target,area=0):
 g.WORLD.time=g.WORLD.time+10
 g.UZ_RequestTransition(target,area);assert g.RC_transitionPending
 g.UZ_Travel();g.UZ_FinishEntry();assert g.RC_map==target and not g.RC_transitionPending

def capture(g):
 return [(g.RC_hero[r].handle,g.RC_hero[r].xp,g.RC_hero[r].points,g.RC_talents[r],tuple(g.GetUnitAbilityLevel(g.RC_hero[r],g.RC_skill[r*5+i]) for i in range(5)),tuple((g.GetItemTypeId(g.UnitItemInSlot(g.RC_hero[r],i)),g.GetItemCharges(g.UnitItemInSlot(g.RC_hero[r],i))) for i in range(6))) for r in range(4) if g.RC_Active(r)]

def menus():
 _,g=setup();assert not g.RC_started
 assert [g.UZ_playerClass[p] for p in range(4)]==list(range(4))
 # A native effect is deferred: the caster still exists on the spell stack.
 old=g.UM_unit[0];g.WORLD.events.unit=old;g.WORLD.events.player=0;g.WORLD.events.spell=g.UM_ability[2]
 g.UM_Spell();assert g.UM_pending[0]==3 and not old.removed
 g.UM_Input();assert old.removed and g.UZ_playerClass[0]==2 and g.UZ_playerClass[2]==0
 assert g.RC_Player(0)==2 and g.RC_Role(0)==2 and g.RC_host==2
 # Host choice/ready must be synchronized; another player cannot set hard.
 g.UM_pending[1]=7;g.UM_Input();assert g.RC_difficulty==1
 g.UM_pending[0]=7;g.UM_Input();assert g.RC_difficulty==2
 g.UM_pending[0]=8;g.UM_Input();assert g.RC_map==5
 for p in range(4):g.UM_pending[p]=12
 g.UM_Input();assert g.RC_started and [g.RC_hero[r].owner for r in range(4)]==[2,1,0,3]
 print('PASS native command-card dispatcher: deferred replacement, class swap/ownership, host-only difficulty/chapter and all-player readiness.')

def travel():
 for players in [(0,),(1,),(0,1),(0,1,2),(0,1,2,3)]:
  _,g=setup(players);start(g)
  for r in range(4):
   if g.RC_Active(r):
    u=g.RC_hero[r];g.SetHeroLevel(u,8,False);assert g.RC_LearnRank(r,0);assert g.RC_GiveTalent(r,0,2)
    g.UnitAddItemToSlotById(u,g.FourCC('shea'),4);g.SetItemCharges(g.UnitItemInSlot(u,4),7)
  before=capture(g)
  u=g.UZ_CreateUnit(10,g.FourCC('hfoo'),g.UZ_startX[0]+500,g.UZ_startY[0],0)
  q=g.UZ_CreateQuest();g.QuestSetEnabled(q,True)
  trigger=g.UZ_CreateTrigger();g.UZ_RegisterTrigger(trigger,0);g.UZ_GateZone(0,True);g.UZ_DestroyTrigger(trigger)
  t=g.CreateTimer();g.UZ_TimerStart(t,20,False,None,0)
  dead=g.CreateTimer();g.UZ_TimerStart(dead,3,False,None,0);g.UZ_DestroyTimer(dead)
  # World state freezes, while physical party handles move.
  advance(g,1,0)
  assert capture(g)==before and u.owner==15 and not u.visible and u.paused,(players,before,capture(g),u.owner,u.visible,u.paused)
  assert t.paused and not q.enabled and not g.UZ_ActiveUnit(u)
  assert not g.RC_EnemyUnit(u)
  advance(g,0,0)
  assert capture(g)==before and u.owner==10 and u.visible and not u.paused
  assert not t.paused and q.enabled
  assert len([x for _,x in g.WORLD.units.items() if x.hero and not x.removed and x.owner<4])==len(players)
  # Destroyed quests/timers never get dereferenced on later travel.
  g.UZ_DestroyQuest(q);advance(g,1);advance(g,0)
 print('PASS actual atlas travel: 1–4 occupied slots (including solo blue), same hero/item handles, XP/points/skills/talents, frozen NPC ownership/visibility/timers/quests and return restoration.')

def gameplay():
 _,g=setup();start(g)
 assert g.RC_LearnRank(0,0) and g.RC_hero[0].points==1
 for r in range(4):g.RC_XPHandicapPercent(g.RC_Player(r),7)
 enemy=g.UZ_CreateUnit(10,g.FourCC('hfoo'),g.RC_hero[0].x,g.RC_hero[0].y,0)
 enemy.hp=0;enemy.level=1;g.WORLD.events.unit=enemy;g.WORLD.events.killer=g.RC_hero[0]
 before=[g.RC_hero[r].xp for r in range(4)];g.RC_KillExperience()
 assert [g.RC_hero[r].xp-before[r] for r in range(4)]==[32]*4
 # A far companion refuses a door without deleting or hiding the party.
 g.WORLD.time=10;g.RC_hero[1].x+=5000;g.UZ_RequestTransition(1,0);assert not g.RC_transitionPending and g.RC_map==0
 g.RC_hero[1].x=g.RC_hero[0].x
 # Source cache stores the real NPC handle, not native campaign serialization.
 npc=g.UZ_CreateUnit(0,g.FourCC('Hjai'),100,200,0);g.UZ_StoreUnit(g.RC_cache,'m','Jaina',npc);assert g.UZ_HaveStoredUnit(g.RC_cache,'m','Jaina')
 g.RC_SourceRemove(npc);assert not npc.removed and npc.paused
 point=g.Rect(0,0,0,0);point.x=900;point.y=800
 restored=g.UZ_RestoreCached('Jaina','m',g.RC_cache,0,point,45)
 assert restored.handle==npc.handle and restored.visible and restored.x==900
 print('PASS actual learning and +32 XP for EACH nearby hero; distant-party door rejection; in-memory cached companion restore.')

def checkpoint():
 _,g=setup((0,1));start(g);advance(g,6)
 for r in (0,1):
  g.SetHeroLevel(g.RC_hero[r],8,False);g.RC_LearnRank(r,0);g.RC_GiveTalent(r,0,2)
  g.UnitAddItemToSlotById(g.RC_hero[r],g.FourCC('shea'),2)
 before=capture(g);g.RC_SaveAll(False);assert g.RC_saveOK
 codes=[g.RC_checkpointCode[r] for r in (0,1)]
 _,h=setup((0,1))
 assert h.RC_LoadCheckpoint(codes[0],0) and h.RC_map==6
 assert not h.RC_LoadCheckpoint(codes[1][:-1]+'!',1) and h.RC_map==6
 assert h.RC_LoadCheckpoint(codes[1],1)
 start(h);after=capture(h)
 assert [x[1:] for x in after]==[x[1:] for x in before],(before,after)
 assert h.RC_map==6
 print('PASS actual Z6 codes restore destination 6 in the SAME W3X, two heroes, talent/XP/skills/inventory; damaged code cannot change selected destination.')

def real_portal():
 _,g=setup((0,1));start(g);g.WORLD.time=10
 g.Z00_Trig_Zone_to_GoblinCave_Actions()
 assert g.RC_transitionPending and g.UZ_target==1 and g.UZ_area==1
 g.UZ_Travel();g.UZ_FinishEntry();assert g.RC_map==1
 g.WORLD.time=20;g.UZ_RequestTransition(0,0);g.UZ_Travel();g.UZ_FinishEntry();assert g.RC_map==0
 print('PASS original Goblin Cave portal action requests in-session destination/entry area without a disable/sleep/rehost path.')

def skill_events():
 _,g=setup();start(g)
 for r in range(4):
  hero=g.RC_hero[r];g.SetHeroLevel(hero,20,False)
  for slot in range(4):
   for rank in range(1,4 if slot==3 else 6):
    old=hero.points;g.SelectHeroSkill(hero,g.RC_learnSkill[r*5+slot])
    assert g.GetUnitAbilityLevel(hero,g.RC_skill[r*5+slot])==rank and hero.points==old-1,(r,slot,rank)
    g.UnitModifySkillPoints(hero,1)
 print('PASS all sixteen skills and every rank through registered native HERO_SKILL events, including point spending and visible cast-ability installation.')

def adapted_ai():
 _,g=setup();start(g)
 building=g.UZ_CreateUnit(10,g.FourCC('hbar'),g.UZ_startX[0]+1000,g.UZ_startY[0],0);building.structure=True
 g.UZ_StartAI(10,'original.ai');g.UZ_aiTicks=6
 old=len(g.WORLD.units);g.UZ_AIProduction();assert len(g.WORLD.units)>old
 trained=g.WORLD.units[len(g.WORLD.units)];assert not trained.hero and trained.owner==10
 building.hp=0;g.UZ_aiTicks=12;old=len(g.WORLD.units);g.UZ_AIProduction();assert len(g.WORLD.units)==old
 # Native summoned enemies also enter the active zone's freeze registry.
 summoned=g.CreateUnit(10,g.FourCC('osw1'),100,200,0);g.WORLD.events.entering=summoned;g.UZ_UnitAppeared();assert g.LoadInteger(g.UZ_state,summoned.handle,1)==1
 print('PASS adapted AI: living factory production, no hero-flood, destroyed factory stops; native-spawned NPCs enter the zone registry.')

menus();travel();gameplay();checkpoint();real_portal();skill_events();adapted_ai()
# Existing outcome assertions exercise all forty advertised talent effects
# against this exact unified artifact, with its real class/zone runtime.
import test_progress
from test_kits import ticks
def talent_fresh(ignored):
 _,g=setup();start(g)
 for r in range(4):g.SetUnitPosition(g.RC_hero[r],100,200)
 return g
test_progress.fresh=talent_fresh
test_progress.node_effects(str(source))
print('Native Warcraft 1.26 graphics, campaign cinematics, pathfinding and live multiplayer have NOT been exercised by these headless checks.')

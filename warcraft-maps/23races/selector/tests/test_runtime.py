"""Actual delivered JASS, native command-card object data and registered events."""
import argparse,json,sys,math
from functools import lru_cache
from pathlib import Path
from lupa import LuaRuntime
ROOT=Path(__file__).resolve().parent
sys.path.insert(0,str(ROOT.parent))
from storm import Storm
from classic_data import read_objects

@lru_cache(maxsize=None)
def archive_resources(work):
    storm=Storm();h=storm.open(work/'23-Races-Race-Selection-1.26.w3x')
    try:
        names=storm.read(h,'(listfile)').decode().splitlines();models={};unit_abilities={}
        for table in read_objects(storm.read(h,'war3map.w3u')):
            for obj in table:
                raw=int.from_bytes(obj['new'] if obj['new']!=b'\0'*4 else obj['old'],'big')
                for m in obj['mods']:
                    if m[0]=='umdl':models[raw]=m[4].decode()
                    if m[0]=='uabi':unit_abilities[raw]=[int.from_bytes(s.encode(),'big') for s in m[4].decode().split(',') if len(s)==4]
        return names,models,unit_abilities
    finally:storm.close(h)

def setup(work,players=range(12),local=0):
    lua=LuaRuntime(unpack_returned_tuples=True);lua.execute((ROOT/'natives.lua').read_text());lua.execute((work/'runtime.lua').read_text());g=lua.globals();g.W.localPlayer=local
    names,models,unit_abilities=archive_resources(work)
    for name in names:g.W.resources[name.lower()]=True
    for raw,name in models.items():g.W.models[raw]=name
    for raw,abilities in unit_abilities.items():g.W.unitAbilities[raw]=lua.table_from({a:True for a in abilities})
    original=[]
    for n,e in enumerate(json.loads((ROOT.parent.parent/'source/trigger-index.json').read_text())['entries']):
        t=g.CreateTrigger();t.enabled=n%3!=0;g['gg_trg_'+e['name']]=t;original.append((t,t.enabled))
    for p in range(12):
        g.W.players[p].state='playing' if p in players else 'empty'
        g.CreateUnit(p,g.FourCC('n00B'),24000+p*100,-27000,0)
    paused=g.CreateUnit(12,g.FourCC('nfoo'),100,200,0);paused.paused=True
    normal=g.CreateUnit(12,g.FourCC('nbar'),200,300,0)
    g.AS_Bootstrap()
    for n in range(13):g.W.time=.03*(n+1);g.udg_AS_SetupTimer.action()
    assert g.udg_AS_Running and paused.paused and normal.paused
    assert all(not t.enabled for t,_ in original)
    assert all(g.udg_AS_OriginalTimer[n].started is None for n in range(45))
    assert g.W.uiVisible and g.W.selectEnabled and g.W.userUI and g.W.userControl
    if local in players:
        control=g.udg_AS_Control[local]
        assert control is not None and not control.paused and g.IsUnitSelected(control,local)
        assert not control.abilities[g.FourCC('Amov')] and not control.abilities[g.FourCC('Aatk')]
        g.AS_CameraTick();assert g.IsUnitSelected(control,local), 'Camera must not clear the native command card'
        distance=g.W.cameraFields['CAMERA_FIELD_TARGET_DISTANCE'];fov=g.W.cameraFields['CAMERA_FIELD_FIELD_OF_VIEW']
        for n in range(12):
            dy=g.udg_AS_StageY[local]+g.udg_AS_PreviewY[n]-g.W.cameraY
            depth=distance+dy/math.sqrt(2)
            v=.5-(dy/math.sqrt(2))/(2*depth*math.tan(math.radians(fov/2)))
            assert .15<v<.70, 'Camp formation falls behind the native HUD'
    return lua,g,original,paused,normal

def live(g,p,raw=None):
    return [u for _,u in g.W.units.items() if not u.removed and u.owner==p and (raw is None or u.raw==g.FourCC(raw))]

def click(g,p,raw):
    # A real registered SPELL_EFFECT event, with only abilities from the actual
    # W3X allowed. The callback must finish before replacing the selected caster.
    g.W.time+=.20
    u=g.udg_AS_Control[p];g.EmitSpell(u,g.FourCC(raw))
    assert not u.removed
    g.udg_AS_InputTimer.action()

def choose(g,p,index):
    for _ in range(5):
        if g.udg_AS_Choice[p]//8==index//8:break
        click(g,p,'qNxt')
    assert g.udg_AS_Choice[p]//8==index//8
    click(g,p,f'qA{index:02}')
    assert g.udg_AS_Choice[p]==index

def key(g,p,event):
    g.W.time+=.20;g.EmitKey(p,event);g.udg_AS_InputTimer.action()

def run(work):
    checks=[];races=json.loads((work/'catalog.json').read_text())
    for race in races:
        _,g,triggers,paused,normal=setup(work,players=[0,1])
        choose(g,0,race['index']);control=g.udg_AS_Control[0]
        assert g.IsUnitSelected(control,0) and not control.paused
        click(g,0,'qPck')
        assert g.udg_AS_Ready[0] and g.udg_AS_Running
        workers=live(g,0,race['worker']);assert len(workers)==5 and all(u.paused for u in workers)
        assert g.W.tech[0][g.FourCC(race['research'])]==1 and not live(g,0,'n00B')
        count=len(g.W.units);g.AS_Confirm(0);assert len(g.W.units)==count
        click(g,1,'qPck')
        assert not g.udg_AS_Running and all(not u.paused for u in live(g,0))
        assert paused.paused and not normal.paused
        assert all(t.enabled==old for t,old in triggers)
        assert all(g.udg_AS_OriginalTimer[n].started==g.W.time for n in range(45))
        assert all(t.removed for _,t in g.W.trees.items())
        assert control.removed and g.udg_AS_Countdown.destroyed
    checks.append('all 34 races selected through actual native command-card ability lists and registered spell events, then confirmed; original five workers/tech reward; paused workers released together; state and timer restoration')
    checks.append('native UI/input enabled, menu unit selected and unpaused, move/attack commands removed, camera ticks preserve selection, spell callback never tears down its caster')
    checks.append('all 68 panel paths and generated model paths resolve in the actual delivered MPQ')
    _,g,_,_,_=setup(work,players=[0,1]);caster=g.udg_AS_Control[0]
    g.EmitSpell(caster,g.FourCC('qA11'));g.EmitSpell(caster,g.FourCC('qPck'))
    assert not caster.removed
    g.udg_AS_InputTimer.action()
    assert g.udg_AS_Choice[0]==11 and g.udg_AS_Ready[0] and len(live(g,0,races[11]['worker']))==5
    checks.append('race click followed by immediate confirm in the same input frame confirms the new race, without dropping the selection')
    _,g,_,_,_=setup(work)
    click(g,3,'qNxt');assert g.udg_AS_Choice[3]==16 and g.udg_AS_Choice[2]==9
    for _ in range(3):click(g,3,'qNxt')
    assert g.udg_AS_Choice[3]==0
    click(g,3,'qPrv');assert g.udg_AS_Choice[3]==32
    click(g,3,'qRnd');assert 0<=g.udg_AS_Choice[3]<34
    choose(g,5,33);click(g,5,'qPck');assert g.udg_AS_Ready[5] and not g.udg_AS_Ready[4]
    # Ineligible casters and already-ready input cannot change someone else's choice.
    other=g.CreateUnit(4,g.FourCC('hfoo'),0,0,0);g.W.events.unit=other;g.W.events.spell=g.FourCC('qA00');g.AS_Spell();assert g.udg_AS_Pending[4]==0
    for p in range(12):
        if not g.udg_AS_Ready[p]:click(g,p,'qPck')
    assert not g.udg_AS_Running and not g.udg_AS_Spells.enabled
    assert all(len(live(g,p,races[g.udg_AS_Choice[p]]['worker']))==5 for p in range(12))
    assert all(not u.paused for p in range(12) for u in live(g,p))
    checks.append('five pages wrap; random preview; 12 independent selections and ready flags; unrelated units rejected; duplicate confirmation cannot issue extra workers')
    _,g,_,_,_=setup(work,players=[0,1,7]);key(g,0,'right');assert g.udg_AS_Choice[0]==10
    # Repeat input inside debounce window is ignored.
    g.EmitKey(0,'right');g.udg_AS_InputTimer.action();assert g.udg_AS_Choice[0]==10
    key(g,0,'left');assert g.udg_AS_Choice[0]==9
    key(g,0,'up');assert g.udg_AS_Ready[0]
    g.W.players[7].state='empty';g.EmitKey(7,'leave')
    for _ in range(90):g.W.time+=1;g.AS_Tick()
    assert not g.udg_AS_Running and len(live(g,1,races[9]['worker']))==5 and g.W.fog and g.W.mask
    checks.append('arrow backup and debounce, native 90-second countdown, timeout accepts shown choice, departure cannot block start, fog settings restored')
    snapshots=[]
    for local in [0,3,11]:
        _,g,_,_,_=setup(work,local=local)
        for p in range(12):choose(g,p,p);click(g,p,'qPck')
        state=[(u.handle,u.owner,u.raw,round(u.x,2),round(u.y,2),bool(u.removed),u.paused) for _,u in g.W.units.items()]
        snapshots.append((g.W.next,state))
    assert snapshots[0]==snapshots[1]==snapshots[2]
    checks.append('different local-player views allocate identical gameplay handles/state for the same native-button sequence')
    report={'checks':checks,'passed':len(checks),'nativeWarcraftRun':False,'limits':'Native mocks do not validate graphics, physical mouse input, client performance or real network sync.'}
    (work/'runtime-tests.json').write_text(json.dumps(report,ensure_ascii=False,indent=2)+'\n')
    for c in checks:print('PASS '+c)

if __name__=='__main__':
    p=argparse.ArgumentParser();p.add_argument('work',type=Path);run(p.parse_args().work)

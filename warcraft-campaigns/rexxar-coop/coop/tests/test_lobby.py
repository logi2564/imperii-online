"""Cross-check host-bot lobby records against the EXECUTED map config.

W3I reader follows GHost++ ghost/map.cpp's classic v25 layout/slot policy;
it intentionally does not import the builder's formats.py. The config is JASS
transpiled by War3Net and run with recording natives. No real game/IrinaBot runs.
"""
import argparse,json,os,re,struct,subprocess,sys
from pathlib import Path
from lupa import LuaRuntime
sys.path.insert(0,str(Path(__file__).resolve().parents[1]))
from storm import Storm

ROOT=Path(__file__).resolve().parents[1]
class Binary:
    def __init__(self,data):self.data=data;self.p=0
    def u32(self):v=struct.unpack_from('<I',self.data,self.p)[0];self.p+=4;return v
    def text(self):end=self.data.index(0,self.p);v=self.data[self.p:end].decode();self.p=end+1;return v
    def skip(self,n):self.p+=n
    def real(self):v=struct.unpack_from('<f',self.data,self.p)[0];self.p+=4;return v

def host_info(data):
    b=Binary(data);assert b.u32()==25;b.skip(8)
    title=b.text();b.text();b.text();b.text();b.skip(56)
    flags=b.u32();b.skip(1);b.u32()
    for _ in range(4):b.text()
    b.u32()
    for _ in range(4):b.text()
    b.skip(24);b.text();b.skip(5)
    players=[]
    for _ in range(b.u32()):
        p=dict(zip(['id','controller','race','fixed'],[b.u32() for _ in range(4)]));p['name']=b.text();p['x']=b.real();p['y']=b.real();p['low']=b.u32();p['high']=b.u32();players.append(p)
    forces=[]
    for _ in range(b.u32()):forces.append(dict(flags=b.u32(),mask=b.u32(),name=b.text()))
    # Same policy as GHost: neutral/rescuable/NONE are closed, not human or AI
    # network slots. Do not turn campaign neutral factions into computer AIs.
    slots=[p for p in players if p['controller'] in (1,2)]
    return dict(title=title,flags=flags,players=players,forces=forces,slots=slots)

NATIVES='''
function __jarray(default) return setmetatable({}, {__index=function() return default end}) end
WORLD={players={},starts={},available={},alliances={},states={}}
for n=0,15 do WORLD.players[n]={} end
MAP_CONTROL_NONE=0;MAP_CONTROL_USER=1;MAP_CONTROL_COMPUTER=2;MAP_CONTROL_NEUTRAL=3;MAP_CONTROL_RESCUABLE=4
RACE_PREF_HUMAN=1;RACE_PREF_ORC=2;RACE_PREF_UNDEAD=3;RACE_PREF_NIGHTELF=4;RACE_PREF_RANDOM=0
MAP_PLACEMENT_USE_MAP_SETTINGS=2;PLAYER_STATE_ALLIED_VICTORY=5
ALLIANCE_PASSIVE='passive';ALLIANCE_SHARED_VISION='vision';ALLIANCE_SHARED_CONTROL='control';ALLIANCE_SHARED_ADVANCED_CONTROL='advanced'
function Player(p) return p end
function SetMapName(s) WORLD.name=s end
function SetMapDescription(s) WORLD.description=s end
function SetPlayers(n) WORLD.count=n end
function SetTeams(n) WORLD.teams=n end
function SetGamePlacement(n) WORLD.placement=n end
function DefineStartLocation(n,x,y) WORLD.starts[n]={x=x,y=y} end
function SetPlayerStartLocation(p,n) WORLD.players[p].start=n end
function ForcePlayerStartLocation(p,n) WORLD.players[p].forced=n end
function ConvertPlayerColor(n) return n end
function SetPlayerColor(p,n) WORLD.players[p].colour=n end
function SetPlayerController(p,n) WORLD.players[p].controller=n end
function SetPlayerTeam(p,n) WORLD.players[p].team=n end
function SetPlayerRacePreference(p,n) WORLD.players[p].race=n end
function SetPlayerRaceSelectable(p,v) WORLD.players[p].selectable=v end
function SetPlayerSlotAvailable(p,c) WORLD.available[p]=c end
function SetPlayerAlliance(p,q,kind,v) WORLD.alliances[p..':'..q..':'..kind]=v end
function SetPlayerState(p,kind,v) WORLD.states[p..':'..kind]=v end
'''

def execute_config(script,path,dotnet):
    config=re.search(r'^function config takes[\s\S]*?^endfunction',script,re.M)[0]
    path.with_suffix('.j').write_text(config+'\n')
    subprocess.run([dotnet,str(ROOT/'Tools/bin/Release/net10.0/Tools.dll'),'transpile',str(path.with_suffix('.j')),str(ROOT/'tests/reference'),str(path)],check=True,capture_output=True)
    lua=LuaRuntime();lua.execute(NATIVES);lua.execute(path.read_text());lua.globals().config()
    return lua.globals().WORLD

def problems(info,world):
    errors=[];players=info['players'];present=sum(1<<p['id'] for p in players)
    if [p['id'] for p in players]!=sorted(p['id'] for p in players):errors.append('unsorted player records')
    if world.count!=len(players) or not 0<world.teams<=world.count:errors.append('invalid player/team capacity')
    masks=0;teams={}
    for n,f in enumerate(info['forces']):
        if masks&f['mask']:errors.append('overlapping force membership')
        if f['mask']&~present:errors.append('force contains absent colours')
        masks|=f['mask']
        for p in players:
            if f['mask']&(1<<p['id']):teams[p['id']]=n
    if masks!=present:errors.append('force membership does not cover the lobby')
    for p in players:
        actual=world.players[p['id']]
        if actual.colour!=p['id']:errors.append('colour not explicitly configured: '+str(p['id']))
        if actual.controller!=p['controller']:errors.append('controller differs: '+str(p['id']))
        if actual.team!=teams.get(p['id']):errors.append('host/config team differs: '+str(p['id']))
        if actual.race!=p['race'] and p['race'] in (1,2,3,4):errors.append('race differs: '+str(p['id']))
        start=world.starts[actual.start]
        if (start.x,start.y)!=(p['x'],p['y']):errors.append('start differs: '+str(p['id']))
    return errors

def run(out,dotnet):
    storm=Storm();folder=out/'lobby';folder.mkdir(exist_ok=True);profiles=[]
    files=sorted((out/'Maps').glob('RX6-*.w3x'));assert len(files)==17
    for path in files:
        a=storm.open(path)
        try:info=host_info(storm.read(a,'war3map.w3i'));script=storm.read(a,'war3map.j').decode()
        finally:storm.close(a)
        world=execute_config(script,folder/(path.stem+'.lua'),dotnet)
        errors=problems(info,world);assert not errors,(path.name,errors)
        assert [p['id'] for p in info['slots'] if p['controller']==1]==[0,1,2,3]
        assert world.name==info['title']
        data=path.read_bytes();b=Binary(data[8:]);assert b.text()==info['title'];assert b.u32()==info['flags'] and b.u32()==4
        assert len('Maps\\Download\\81743_'+path.name)<53 and path.stat().st_size<8*1024*1024
        for n,f in enumerate(info['forces']):
            for p in info['players']:
                if not f['mask']&(1<<p['id']):continue
                for q in info['players']:
                    if p==q or not f['mask']&(1<<q['id']):continue
                    for bit,key in [(1,'passive'),(8,'vision'),(16,'control'),(32,'advanced')]:
                        if f['flags']&bit:assert world.alliances[str(p['id'])+':'+str(q['id'])+':'+key]
        profiles.append(dict(file=path.name,humans=[0,1,2,3],hostNetworkSlots=[p['id'] for p in info['slots']],npcControllers={p['id']:p['controller'] for p in info['players'] if p['id'] not in [0,1,2,3]},teams={p['id']:world.players[p['id']].team for p in info['players']}))
    # Real RC2 metadata/config, retained specifically to prove the cross-check
    # detects the previously released defect rather than round-tripping itself.
    fixtures=ROOT/'tests/fixtures'
    old=host_info((fixtures/'rc2-OrcX01.w3i').read_bytes());old_world=execute_config((fixtures/'rc2-OrcX01-config.j').read_text(),folder/'old-rc2.lua',dotnet)
    errors=problems(old,old_world)
    assert 'unsorted player records' in errors and any(x.startswith('host/config team differs:') for x in errors),errors
    prior=host_info((fixtures/'rc3-OrcX01.w3i').read_bytes());prior_world=execute_config((fixtures/'rc3-OrcX01-config.j').read_text(),folder/'old-rc3.lua',dotnet)
    prior_errors=problems(prior,prior_world)
    assert prior_errors and all(x.startswith('colour not explicitly configured:') for x in prior_errors),prior_errors
    (out/'Lobby-report.json').write_text(json.dumps(dict(nativeWarcraftTested=False,liveIrinaBotTested=False,reference='uakfdotb/ghostpp ghost/map.cpp classic v25 slot/force layout',rc2RegressionErrors=errors,rc3MissingColourAssignments=prior_errors,maps=profiles),indent=2))
    print('PASS: 17 host-bot lobby profiles match EXECUTED JASS config: sorted colours, exact controllers/races/teams/starts, four human slots, bounded/disjoint force masks, matching HM3W/W3I/config titles and short bot download paths. Real released RC2 fixture is correctly rejected for unsorted records and mismatched host/config teams. Native Warcraft and live IrinaBot were NOT run.')

if __name__=='__main__':
    p=argparse.ArgumentParser();p.add_argument('out',type=Path);p.add_argument('--dotnet',default=os.environ.get('DOTNET','dotnet'));a=p.parse_args();run(a.out,a.dotnet)

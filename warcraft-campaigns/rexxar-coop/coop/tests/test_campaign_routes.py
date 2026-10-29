"""Run original imports/entry selection on every original door, not just travel APIs."""
import re,sys
from pathlib import Path
from test_unified import setup,start,advance
sys.path.insert(0,str(Path(__file__).resolve().parents[1]))
from build import MAPS,ROOT
from storm import Storm

script=Path(sys.argv[1]).with_suffix('.j').read_text()
functions={m[1]:m[0] for m in re.finditer(r'^function (\w+) takes[^\n]*\n[\s\S]*?^endfunction',script,re.M)}
doors=[]
for name,body in functions.items():
    zone=re.match(r'Z(\d+)_Trig_Zone_to_\w+_Actions$',name)
    target=re.search(r'call RC_Transition\((\d+),(\d+)\)',body)
    if zone and target:doors.append((int(zone[1]),int(target[1]),int(target[2]),name))


def source_party(players):
    lua,g=setup(players)
    for name in ('SetSoundPosition','RegisterStackedSound','PanCameraToTimedLocForPlayer','SelectUnitForPlayerSingle'):
        g[name]=lambda *args:None
    g.AddWeatherEffect=lambda *args:lua.table()
    g.EnableWeatherEffect=lambda *args:None
    g.TriggerSleepAction=lambda *args:None
    g.QueuedTriggerAddBJ=lambda *args:None
    g.QueuedTriggerRemoveBJ=lambda *args:None
    def initialize(z):
        prefix=f'Z{z:02}_'
        g[prefix+'InitGlobals']();g[prefix+'CreateRegions']()
        for r,hero in enumerate(('Rexxar','Rokhan','Chen','Cairne')):
            var=prefix+'udg_'+hero+'InParty'
            if re.search(r'\b'+var+r'\s*=',script[:script.index('endglobals')]):g[var]=g.RC_Active(r)
        for name in functions:
            if re.match(prefix+r'InitTrig_(?:Import_All|Import_Mission_Data|Import_Heroes|Import_Hero_\w+|Set_Hero_Locations|Init_Zones)$',name):g[name]()
        if prefix+'Trig_Init_Zones_Actions' in functions:g[prefix+'Trig_Init_Zones_Actions']()
        g.UZ_initialized[z]=True
    for z in range(15):
        g[f'UZ_InitZ{z:02}']=lambda z=z:initialize(z)
        g[f'Z{z:02}_RunInitializationTriggers']=lambda z=z:g[f'Z{z:02}_Trig_Import_All_Actions']()
        g[f'UZ_ReturnZ{z:02}']=lambda z=z:g[f'Z{z:02}_Trig_Import_All_Actions']()
        g[f'UZ_ExportZ{z:02}']=lambda z=z:g[f'Z{z:02}_Trig_Export_Mission_Data_Actions']()
    for r in range(4):g.RC_flags[r]=1 if g.RC_Active(r) else 0
    start(g)
    for r in range(len(players)):
        hero=g.RC_hero[r];g.SetHeroLevel(hero,8,False)
        g.RC_LearnRank(r,0);g.RC_GiveTalent(r,0,2)
        g.UnitAddItemToSlotById(hero,g.FourCC('shea'),2)
        hero.hp=501+r;hero.mana=211+r
    return lua,g


def capture(g,players):
    return [(g.GetHandleId(g.RC_hero[r]),g.GetHeroXP(g.RC_hero[r]),g.GetHeroSkillPoints(g.RC_hero[r]),g.GetWidgetLife(g.RC_hero[r]),g.GetUnitState(g.RC_hero[r],g.UNIT_STATE_MANA),g.RC_talents[r],g.GetUnitAbilityLevel(g.RC_hero[r],g.RC_skill[r*5]),g.GetItemTypeId(g.UnitItemInSlot(g.RC_hero[r],2))) for r in range(len(players))]


def all_doors():
    assert len(doors)==29
    for players in [(1,),(0,1,2,3)]:
        _,g=source_party(players)
        for old,target,area,action in doors:
            if g.RC_map!=old:advance(g,old)
            before=capture(g,players)
            g.WORLD.time+=10
            g[action]()
            assert g.RC_transitionPending and g.UZ_target==target and g.UZ_area==area,action
            g.UZ_Travel()
            # Import_All and its real hero import actions have run, while
            # the outgoing-door cooldown is still active.
            assert g[f'Z{target:02}_udg_TransitionTargetArea']==area,action
            point=(f'SpawnPoint{area:02}A' if target==5 else f'SpawnPoint{area}A')
            expected=g[f'Z{target:02}_gg_rct_{point}']
            if expected is None:raise AssertionError((action,'missing independent source spawn',point))
            x=(g.GetRectMinX(expected)+g.GetRectMaxX(expected))/2
            y=(g.GetRectMinY(expected)+g.GetRectMaxY(expected))/2
            assert (g.GetUnitX(g.RC_hero[0]),g.GetUnitY(g.RC_hero[0]))==(x,y),(action,'source import selected wrong entrance')
            g.UZ_FinishEntry()
            assert g.RC_map==target and not g.RC_transitionPending
            assert capture(g,players)==before,(action,'party state changed')
            for r in range(len(players)):
                assert (g.GetUnitX(g.RC_hero[r]),g.GetUnitY(g.RC_hero[r]))==(x+r*90,y)
    print(f'PASS all {len(doors)} original doors, solo blue/four players: real source imports select each original entry region, preserve exact heroes/items/XP/points/skills/talents/HP/mana and place the whole party together.')


def fourth_hero_turn_in():
    _,g=source_party((0,1,2,3))
    # The first act originally only had Rexxar, Rokhan and Chen. Cairne must
    # now be able to hand in a completed cave objective as well.
    g.Z00_udg_QuestSealTunnelProgress=4
    for r in range(4):
        g.WORLD.events.entering=g.RC_hero[r]
        assert g.Z00_Trig_SealTunnel_Complete_Conditions(),('Gazlowe ignores party role',r)


def original_generic_filters():
    # Identify the generic OR lists independently in the user's untouched
    # archives, then execute the corresponding functions in the built map.
    filters=[];storm=Storm()
    for z,name in enumerate(MAPS):
        archive=storm.open(ROOT/'inputs'/f'{name}.w3x')
        try:original=storm.read(archive,'war3map.j').decode().replace('\r\n','\n')
        finally:storm.close(archive)
        for match in re.finditer(r'^function (\w+) takes[^\n]*\n([\s\S]*?)^endfunction',original,re.M):
            text=re.sub(r'\s+','',match[2])
            identities=re.findall(r'GetEnteringUnit\(\)==udg_(Rexxar|Rokhan|Chen|Cairne)',text)
            if len(identities)<2:continue
            expected=''.join(f'if((GetEnteringUnit()==udg_{hero}))thenreturntrueendif' for hero in identities)+'returnfalse'
            if text==expected:filters.append((z,f'Z{z:02}_'+match[1]))
    assert len(filters)==43
    for players in [(1,),(0,1),(0,1,2,3)]:
        _,g=source_party(players)
        impostors=[g.RC_EnsureAbsent(3) if len(players)<4 else None,
                   g.UZ_CreateUnit(g.RC_Player(0),g.FourCC('hfoo'),0,0,0),
                   g.UZ_CreateUnit(15,g.FourCC('Ocb2'),0,0,0)]
        for z,name in filters:
            for r,hero in enumerate(('Rexxar','Rokhan','Chen','Cairne')):
                g[f'Z{z:02}_udg_{hero}']=g.RC_hero[r] if g.RC_Active(r) else g.RC_EnsureAbsent(r)
            for r in range(len(players)):
                g.WORLD.events.entering=g.RC_hero[r]
                assert g[name](),(name,'ignored actual hero',r)
            for unit in impostors:
                g.WORLD.events.entering=unit
                assert not g[name](),(name,'accepted an NPC/troop/absent role')
        # Named single-character scenes must retain their original identity.
        g.WORLD.events.entering=g.RC_hero[0]
        assert g.Z00_Trig_Rexxar_Meets_Thrall_Conditions()
        g.WORLD.events.entering=g.RC_hero[1] if len(players)>1 else None
        assert not g.Z00_Trig_Rexxar_Meets_Thrall_Conditions()
    print('PASS 43 original generic interaction filters: every occupied hero can interact; NPCs/troops/absent roles remain excluded and Rexxar-only scenes retain their identity gate.')


def cave_return_and_reward():
    for players in [(1,),(0,1,2,3)]:
        _,g=source_party(players)
        # Presentation and elapsed sound waits are explicit native boundaries.
        for name in ('SetSpeechVolumeGroupsBJ','TransmissionFromUnitWithNameBJ','WaitForSoundBJ','VolumeGroupResetBJ'):
            g[name]=lambda *args:None
        messages=[];queue=[]
        g.QuestMessageBJ=lambda force,kind,text:messages.append(text)
        g.QueuedTriggerAddBJ=lambda trigger,flag:queue.append(trigger)
        g.QueuedTriggerRemoveBJ=lambda trigger:None
        def quest_initializers(z):
            for name in functions:
                if re.match(f'Z{z:02}_InitTrig_Quest_(SealTunnel|EarnKeep)_',name):g[name]()
        quest_initializers(0)
        for name in ('SealTunnel_Complete','SealTunnel_Complete_Q','Talky_Remove_Gazlowe','EarnKeep_Subgoals_Check'):
            g['Z00_InitTrig_'+name]()
        g.Z00_udg_QuestSealTunnelProgress=2
        # Leave by the original door and import into the original cave.
        g.WORLD.time+=10;g.Z00_Trig_Zone_to_GoblinCave_Actions();g.UZ_Travel();g.UZ_FinishEntry()
        assert g.Z01_udg_QuestSealTunnelProgress==2
        quest_initializers(1)
        g.Z01_InitTrig_Update_Column_Leaderboard()
        g.Z01_udg_LBColumnLeaderboard=g.CreateLeaderboard()
        g.Z01_Trig_Quest_SealTunnel_Update1_Actions()
        # Exercise the original three-column tally and its actual quest update;
        # the collapse animations/pathfinding themselves are not simulated.
        g.Z01_udg_LBColumnsDestroyed=3
        g.Z01_Trig_Update_Column_Leaderboard_Actions()
        assert g.Z01_udg_AllTunnelsClosed and g.Z01_udg_QuestSealTunnelProgress==4
        g.WORLD.time+=10;g.Z01_Trig_Zone_to_Orgrimmar_Actions();g.UZ_Travel();g.UZ_FinishEntry()
        assert g.Z00_udg_QuestSealTunnelProgress==4
        g.Z00_Trig_Quest_SealTunnel_Sync_Actions()
        assert not g.Z00_udg_QuestSealTunnel.completed
        assert g.Z00_udg_QuestSealTunnelReq2.completed and not g.Z00_udg_QuestSealTunnelReq3.completed
        # The last present hero (Cairne in a full party) performs the hand-in.
        hero=g.RC_hero[len(players)-1]
        g.WORLD.events.entering=hero
        trigger=g.Z00_gg_trg_SealTunnel_Complete
        assert g.TriggerEvaluate(trigger)
        before=len(g.WORLD.drops)
        g.TriggerExecute(trigger)
        assert len(queue)==1
        while queue:
            next_trigger=queue.pop(0)
            if g.TriggerEvaluate(next_trigger):g.TriggerExecute(next_trigger)
        assert g.Z00_udg_QuestSealTunnelProgress==5 and g.Z00_udg_QuestSealTunnel.completed
        assert g.Z00_udg_QuestEarnKeepProgress1 and g.Z00_udg_QuestEarnKeepReq1.completed
        drops=[g.WORLD.drops[n].id for n in range(before+1,len(g.WORLD.drops)+1)]
        assert drops==[g.FourCC('RI07'),g.FourCC('rugt')]
        assert not g.IsTriggerEnabled(trigger) and not g.Z00_Trig_SealTunnel_Complete_Conditions()
        assert sum('ОСНОВНОЕ ЗАДАНИЕ ВЫПОЛНЕНО' in text for text in messages)==1
        # A second trip must not restore the cave's earlier "awaiting hand-in"
        # state over the completed hub quest or issue another reward.
        after=len(g.WORLD.drops)
        advance(g,1,1);assert g.Z01_udg_QuestSealTunnelProgress==5
        advance(g,0,1);assert g.Z00_udg_QuestSealTunnelProgress==5
        g.WORLD.events.entering=hero
        assert not g.Z00_Trig_SealTunnel_Complete_Conditions()
        assert len(g.WORLD.drops)==after and not queue
    print('PASS original Goblin Cave -> Durotar -> Gazlowe quest chain, solo blue/four players: objective tally, pending hand-in, fourth-hero interaction, original rewards and one completion announcement.')


if __name__=='__main__':
    all_doors()
    fourth_hero_turn_in()
    original_generic_filters()
    cave_return_and_reward()

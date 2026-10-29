"""Original preplaced units, checked codes and fresh-session act-III state."""
import json,re,sys
from pathlib import Path
from test_unified import setup,start,advance

output=Path(sys.argv[1]).parent
layouts=json.loads((output/'World-layout.json').read_text())


def battlefield(z,players=(0,1,2,3),codes=None):
    lua,g=setup(players)
    for name in ('SetUnitColor','SetUnitAcquireRange','SetResourceAmount','SetSoundPosition','RegisterStackedSound','StartSound','UnitAddIndicator','SetPlayerColor','SetPlayerOnScoreScreen','EnableCreepSleep','PingMinimap'):
        g[name]=lambda *args:None
    g.ConvertPlayerColor=lambda color:color
    g.AddWeatherEffect=lambda *args:lua.table()
    g.EnableWeatherEffect=lambda *args:None
    # Native time/scheduling is not simulated; source waits resume in the
    # same zone here, while generation guards remain actual campaign code.
    g.TriggerSleepAction=lambda seconds:None
    g.PolledWait=lambda seconds:None
    g.CinematicFadeBJ=lambda *args:None
    g.PLAYER_STATE_UNFOLLOWABLE='unfollowable'
    g.PLAYER_STATE_CREEP_SLEEPING='creepSleeping'
    g.PLAYER_STATE_NO_CREEP_SLEEP='noCreepSleep'
    g.PLAYER_STATE_GIVES_BOUNTY='givesBounty'
    g.WakePlayerUnits=lambda player:None
    g.SetUnitLifePercentBJ=lambda unit,value:g.SetWidgetLife(unit,unit.maxhp*value/100)
    if codes:
        for r,code in enumerate(codes):assert g.RC_LoadCheckpoint(code,r)
    else:g.RC_map=z;g.RC_defaultLevel=12
    start(g)
    g.UZ_entering=True
    g[f'Z{z}_InitGlobals']()
    g[f'Z{z}_CreateRegions']()
    g[f'Z{z}_CreateAllUnits']()
    assert g.UW_registered[z]==len(layouts[str(z)]['entries'])
    for e in layouts[str(z)]['entries']:
        if 'Buildings' in e['function']:g.UW_unit[z*256+e['index']].structure=True
    g[f'Z{z}_Trig_Init_01_Players_Actions']()
    g.RC_Alliances()
    g[f'Z{z}_Trig_Init_02_Units_Actions']()
    assert g.UW_ready[z]
    quest='Quest_Seas_of_Blood_Create' if z==15 else 'Quest_LastAdmiral_Create'
    g[f'Z{z}_InitTrig_{quest}']()
    g.ConditionalTriggerExecute(g[f'Z{z}_gg_trg_{quest}'])
    g.RC_ObserveStoryHeroes()
    if z==15:
        for name in ('Activate_Shipyard','Create_Battleship_Leaderboard','Battleship_Dies','Respawn_Juggernaut','Respawn_Frigate','Respawn_Transport'):
            g[f'Z15_InitTrig_{name}']()
    else:
        g.Z16_Trig_Init_07_Army_Variables_Actions()
        for name in ('Retarget_Human_Forces','OrcNorthBuilding_Destroyed','OrcMainBuilding_Destroyed','OrcEastBuilding_Destroyed','KulTirasNorthBuildings_Destroyed','KulTirasMainBuildings_Destroyed','KulTirasEastBuildings_Destroyed'):
            g[f'Z16_InitTrig_{name}']()
    g.UZ_entering=False
    return lua,g


def construction():
    for z in (15,16):
        _,g=battlefield(z)
        assert all(g.UW_unit[z*256+i] is not None for i in range(g.UW_count[z]))
    print('PASS original final-act unit creation registers every stable world slot.')


def save(g,players):
    g.RC_SaveAll(False)
    assert g.RC_saveOK
    result=[g.RC_checkpointCode[r] for r in range(len(players))]
    assert all(code.startswith('W1') and len(code)<=121 for code in result)
    return result


def naval():
    players=(0,1)
    _,g=battlefield(15,players)
    ships=[e['index'] for e in layouts['15']['entries'] if e['ship']]
    for index in ships[::2]:g.KillUnit(g.UW_unit[15*256+index])
    assert g.Z15_udg_LBBattleshipsDestroyed==3
    g.QuestSetDiscovered(g.Z15_udg_QuestSeasOfBlood,True)
    g.SetUnitOwner(g.Z15_gg_unit_nshp_0060,g.RC_Player(0),True)
    codes=save(g,players)
    _,h=battlefield(15,players,codes)
    before=[h.GetHeroXP(h.RC_hero[r]) for r in range(2)]
    h.UW_Restore()
    assert h.UW_resumed[15] and h.UW_loaded[15]==''
    assert [not h.RK_Alive(h.UW_unit[15*256+i]) for i in ships]==[True,False,True,False,True,False]
    assert h.Z15_udg_LBBattleshipsDestroyed==3
    assert h.GetOwningPlayer(h.Z15_gg_unit_nshp_0060)==h.RC_Player(0)
    assert '3 из 6' in h.Z15_udg_QuestSeasReq2.description
    assert '3/6' in h.Z15_udg_LBBattleshipLeaderboard['items'][h.RC_Player(0)]
    assert [h.GetHeroXP(h.RC_hero[r]) for r in range(2)]==before
    assert sum(1 for _,u in h.WORLD.units.items() if u.id==h.FourCC('ojgn'))==3
    h.RC_Distribute()
    fleet=[u for _,u in h.WORLD.units.items() if u.id in [h.FourCC(raw) for raw in ('ojgn','odes','obot')] and h.RC_IsPartyPlayer(u.owner)]
    assert len(fleet)==6 and sum(u.owner==0 for u in fleet)==3 and sum(u.owner==1 for u in fleet)==3
    h.KillUnit(h.UW_unit[15*256+ships[1]])
    assert h.Z15_udg_LBBattleshipsDestroyed==4
    _,solo=battlefield(15,(1,))
    boat=solo.CreateUnit(15,solo.FourCC('ojgn'),100,200,0)
    solo.RC_RescueUnit(boat,0,True);solo.RC_Distribute()
    assert solo.GetOwningPlayer(boat)==1
    print('PASS fresh naval save: exact three destroyed ships, counter/journal/leaderboard, captured shipyard, replenished transport fleet, no extra XP; next real sinking counts once.',[len(c) for c in codes])


def final_battle():
    for players in [(1,),(0,1,2,3)]:
        _,g=battlefield(16,players)
        owners=[g.Z16_udg_P04_Orc_Main,g.Z16_udg_P05_Orc_North,g.Z16_udg_P06_Orc_East]
        assert len(set(owners))==3 and all(owner>=4 for owner in owners)
        owned=[(g.UW_unit[16*256+i],g.GetOwningPlayer(g.UW_unit[16*256+i])) for i in range(g.UW_count[16])]
        g.RC_InitialArmy();g.RC_Distribute()
        assert all(g.GetOwningPlayer(u)==owner for u,owner in owned)
        for p in players:
            assert not g.GetPlayerAlliance(p,15,g.ALLIANCE_SHARED_CONTROL)
            assert not g.GetPlayerAlliance(15,p,g.ALLIANCE_SHARED_CONTROL)
            assert g.GetPlayerAlliance(4,p,g.ALLIANCE_SHARED_CONTROL)
        g.QuestSetDiscovered(g.Z16_udg_QuestLastAdmiral,True)
        for name in ('OrcNorthBuildingGroup','KulTirasEastBuildingGroup'):
            group=g[f'Z16_udg_{name}']
            for u in [group[i] for i in range(1,g.CountUnitsInGroup(group)+1)]:g.KillUnit(u)
        partial=g.FirstOfGroup(g.Z16_udg_KulTirasMainBuildingGroup)
        assert partial is not None
        g.KillUnit(partial)
        assert g.Z16_udg_NorthDestroyed and g.Z16_udg_KulTirasEastDestroyed
        assert not g.Z16_udg_KulTirasMainDestroyed
        for r in range(len(players)):
            hero=g.RC_hero[r]
            g.SetHeroLevel(hero,16,False)
            assert g.RC_LearnRank(r,0) and g.RC_GiveTalent(r,0,2)
            g.UnitAddItemToSlotById(hero,g.FourCC('shea'),2)
        dead=[not g.RK_Alive(g.UW_unit[16*256+i]) for i in range(g.UW_count[16])]
        codes=save(g,players)
        _,h=battlefield(16,players,codes)
        before=[h.GetHeroXP(h.RC_hero[r]) for r in range(len(players))]
        h.UW_Restore()
        assert [not h.RK_Alive(h.UW_unit[16*256+i]) for i in range(h.UW_count[16])]==dead
        assert h.Z16_udg_NorthDestroyed and h.Z16_udg_KulTirasEastDestroyed
        assert not h.Z16_udg_KulTirasMainDestroyed
        assert h.CountUnitsInGroup(h.Z16_udg_OrcNorthBuildingGroup)==0
        assert h.CountUnitsInGroup(h.Z16_udg_KulTirasEastBuildingGroup)==0
        assert h.CountUnitsInGroup(h.Z16_udg_KulTirasMainBuildingGroup)==g.CountUnitsInGroup(g.Z16_udg_KulTirasMainBuildingGroup)
        assert [h.GetHeroXP(h.RC_hero[r]) for r in range(len(players))]==before
        for r in range(len(players)):
            assert h.GetHeroLevel(h.RC_hero[r])==16 and h.RC_talents[r]==2
            assert h.GetUnitAbilityLevel(h.RC_hero[r],h.RC_skill[r*5])==1
            assert h.GetItemTypeId(h.UnitItemInSlot(h.RC_hero[r],2))==h.FourCC('shea')
        assert h.Z16_udg_QuestLastAdmiral.discovered
        for p in players:assert h.GetPlayerAlliance(h.Z16_udg_P03_Thrall,p,h.ALLIANCE_PASSIVE)
    print('PASS fresh final battle, solo blue and four players: three distinct NPC armies remain outside human slots; shared stash, neutral shops, full/partial destroyed bases, death flags and retargeting; hero levels/items/skills/talents retained without extra XP.')


def validation():
    _,g=battlefield(15,(0,1))
    codes=save(g,(0,1))
    _,h=setup((0,1))
    assert h.RC_LoadCheckpoint(codes[0],0)
    def state():return (h.RC_map,h.RC_loadedGroup,h.UW_loaded[15],h.RC_checkpointCode[0],h.RC_talents[1])
    before=state()
    for index in range(len(codes[1])):
        damaged=codes[1][:index]+('0' if codes[1][index]!='0' else '1')+codes[1][index+1:]
        assert not h.RC_LoadCheckpoint(damaged,1)
        assert state()==before
    inner=g.UW_Unwrap(codes[1]);world=g.UW_decoded
    wrong_tag=g.RC_Pack((g.UW_tag[15]+1)%4096,2)+world[2:]
    assert not h.RC_LoadCheckpoint(g.UW_Wrap(inner,wrong_tag),1)
    ships=[e['index'] for e in layouts['15']['entries'] if e['ship']]
    g.KillUnit(g.UW_unit[15*256+ships[0]])
    other=g.UW_Wrap(inner,g.UW_Capture())
    assert not h.RC_LoadCheckpoint(other,1) and state()==before
    assert h.RC_LoadCheckpoint(codes[1],1)
    # Unwrapped C4 codes still load; their absent world state is never invented.
    _,old=setup((0,1))
    for role,saved in enumerate(codes):assert old.RC_LoadCheckpoint(g.UW_Unwrap(saved),role)
    assert old.UW_loaded[15]==''
    print('PASS W1 integrity/atomicity: every single-character corruption, wrong roster and mismatched world rejected; original C4 codes still load.')


def intro_and_timers():
    script=Path(sys.argv[1]).with_suffix('.j').read_text()
    for z in (15,16):
        _,g=battlefield(z,(0,1))
        calls=[]
        def scene_setup():calls.append('setup')
        g[f'Z{z}_gg_trg_Intro_Setup']=g.CreateTrigger()
        g.TriggerAddAction(g[f'Z{z}_gg_trg_Intro_Setup'],scene_setup)
        # Camera/scene choreography is outside this test; the source queue,
        # actual skip action, world restore and gameplay action all run.
        g[f'Z{z}_gg_trg_Intro_Cleanup']=g.CreateTrigger()
        g[f'Z{z}_gg_trg_Intro_Cinematic_Q']=g.CreateTrigger()
        g.TriggerAddAction(g[f'Z{z}_gg_trg_Intro_Cinematic_Q'],g[f'Z{z}_Trig_Intro_Cinematic_Q_Actions'])
        g[f'Z{z}_gg_trg_Intro_Skipped']=g.CreateTrigger()
        g.TriggerAddAction(g[f'Z{z}_gg_trg_Intro_Skipped'],g[f'Z{z}_Trig_Intro_Skipped_Actions'])
        g[f'Z{z}_gg_trg_Gameplay']=g.CreateTrigger()
        g.TriggerAddAction(g[f'Z{z}_gg_trg_Gameplay'],g[f'Z{z}_Trig_Gameplay_Actions'])
        discovery='Quest_Seas_of_Blood_Discovered_Q' if z==15 else 'Quest_LastAdmiral_Discover_Q'
        g[f'Z{z}_gg_trg_{discovery}']=g.CreateTrigger()
        g.QueuedTriggerAddBJ=lambda trigger,*args:calls.append(('queue',g.GetHandleId(trigger)))
        g.QueuedTriggerRemoveBJ=lambda trigger:calls.append(('remove',g.GetHandleId(trigger)))
        g.UW_loaded[z]=g.UW_Capture()
        g.TriggerExecute(g[f'Z{z}_gg_trg_Intro_Cinematic_Q'])
        assert calls[0]=='setup'
        assert g.UW_resumed[z] and g.UW_loaded[z]=='' and not g.RC_StoryCinematic()
        assert ('queue',g.GetHandleId(g[f'Z{z}_gg_trg_{discovery}'])) not in calls
        assert ('remove',g.GetHandleId(g[f'Z{z}_gg_trg_Intro_Cinematic_Q'])) in calls
        if z==15:
            clocks=[g.Z15_udg_JuggernautTimer,g.Z15_udg_FrigateTimer,g.Z15_udg_TransportTimer]
            assert all(g.LoadInteger(g.UZ_state,g.GetHandleId(t),20)==16 for t in clocks)
            g.UZ_PauseTimerBJ(True,clocks[0])
            advance(g,16)
            assert all(t.paused for t in clocks)
            advance(g,15)
            assert clocks[0].paused and all(not t.paused for t in clocks[1:])
            g.UZ_PauseTimerBJ(False,clocks[0]);assert not clocks[0].paused
    assert not re.search(r'\b(?:StartTimerBJ|CreateTimerBJ|PauseTimerBJ)\(',script)
    print('PASS actual intro delegates to skip only after setup, restores before control returns, suppresses stale quest discovery; original gameplay timers freeze/thaw with travel.')


def victory_save():
    _,g=battlefield(16,(0,1))
    save(g,(0,1));checkpoint=g.RC_checkpoint
    g.Z16_udg_InCinematic=True
    g.WORLD.events.player=g.RC_Player(0);g.WORLD.events.chat='-save'
    g.RC_Chat()
    assert g.RC_checkpoint==checkpoint
    g.RC_Victory(g.RC_Player(0),False,False)
    assert g.RC_saveOK and g.RC_checkpoint==checkpoint+1 and g.RC_transitionPending
    print('PASS manual save waits for the scene, but the original victory callback can still save and finish during the ending cinematic.')


def completed_battle():
    for z in (15,16):
        _,g=battlefield(z,(0,1))
        if z==15:
            targets=[g.UW_unit[z*256+e['index']] for e in layouts[str(z)]['entries'] if e['ship']]
        else:targets=[g.Z16_udg_Proudmoore]
        for u in targets:g.KillUnit(u)
        codes=save(g,(0,1))
        _,h=battlefield(z,(0,1),codes)
        h[f'Z{z}_InitTrig_Victory']()
        completed='Quest_Seas_of_Blood_Completed_Q' if z==15 else 'Quest_LastAdmiral_Completed_Q'
        for suffix in (completed,'Victory_Cinematic_Q'):h[f'Z{z}_gg_trg_{suffix}']=h.CreateTrigger()
        queued=[]
        h.QueuedTriggerAddBJ=lambda trigger,*args:queued.append(h.GetHandleId(trigger))
        before=[h.GetHeroXP(h.RC_hero[r]) for r in range(2)]
        h.UW_Restore()
        assert h[f'Z{z}_udg_GameOver']
        assert queued==[h.GetHandleId(h[f'Z{z}_gg_trg_{suffix}']) for suffix in (completed,'Victory_Cinematic_Q')]
        assert [h.GetHeroXP(h.RC_hero[r]) for r in range(2)]==before
    print('PASS saves taken after the last ship/boss death resume the original completion/ending queue; no dead-object softlock or repeated kill XP.')


construction()
naval()
final_battle()
validation()
intro_and_timers()
victory_save()
completed_battle()

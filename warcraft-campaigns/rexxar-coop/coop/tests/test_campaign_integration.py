"""Exercise original mission globals, alliance setup and cave conditions.

    Rendering/pathfinding, cinematic playback and transport are not emulated.
    These tests deliberately do NOT replace the campaign's portal conditions
    or the Blizzard alliance helpers with a constant result.
"""
import sys
from pathlib import Path
from test_unified import setup, start, advance


def campaign(players):
    lua, g = setup(players)
    # These are engine presentation options, unrelated to alliance logic.
    for name in ('SetPlayerColorBJ', 'SetPlayerOnScoreScreenBJ', 'EnableCreepSleepBJ',
                 'SetSoundPosition', 'RegisterStackedSound'):
        g[name] = lambda *args: None
    start(g)
    g.bj_FORCE_PLAYER[0] = g.CreateForce()
    g.ForceAddPlayer(g.bj_FORCE_PLAYER[0], 0)
    g.Z00_InitGlobals()
    g.Z00_CreateRegions()
    g.RC_ObserveStoryHeroes()
    return lua, g


def original_player_setup():
    for players in [(0,), (1,), (0,1), (0,2,3), (0,1,2,3)]:
        lua, g = campaign(players)
        # An unrelated neutral-neural pair must survive missing party slots.
        g.SetPlayerAlliance(15,12,g.ALLIANCE_PASSIVE,True)
        g.Z00_Trig_Init_01_Players_Actions()
        g.RC_Alliances()
        thrall = g.Z00_udg_P03_Thrall
        assert thrall >= 4
        for p in players:
            assert g.GetPlayerAlliance(thrall,p,g.ALLIANCE_PASSIVE), (players,thrall,p)
            assert g.GetPlayerAlliance(p,thrall,g.ALLIANCE_PASSIVE)
            assert not g.GetPlayerAlliance(12,p,g.ALLIANCE_PASSIVE)
            assert not g.GetPlayerAlliance(p,12,g.ALLIANCE_PASSIVE)
            for npc in range(4,16):
                for flag in range(10):
                    kind=g.ConvertAllianceType(flag)
                    assert g.GetPlayerAlliance(p,npc,kind)==g.GetPlayerAlliance(0,npc,kind), (players,p,npc,flag,'outgoing')
                    assert g.GetPlayerAlliance(npc,p,kind)==g.GetPlayerAlliance(npc,0,kind), (players,p,npc,flag,'incoming')
        assert g.GetPlayerAlliance(15,12,g.ALLIANCE_PASSIVE), players
        assert g.GetHandleId(g.Z00_udg_APG1_Player) == g.GetHandleId(g.RC_force)
        assert all(g.IsPlayerInForce(p,g.Z00_udg_APG1_Player) for p in players)
        # Keep the exact asymmetric/default and quest-modified relations on
        # a departure/return, rather than recomputing just "allied".
        before = {(a,b,f): g.GetPlayerAlliance(a,b,g.ConvertAllianceType(f))
                  for a in range(16) for b in range(16) for f in range(10)}
        advance(g,1)
        advance(g,0)
        after = {(a,b,f): g.GetPlayerAlliance(a,b,g.ConvertAllianceType(f)) for a,b,f in before}
        assert before == after, players
    print('PASS original act-I player initialization: 1–4 occupied slots, Horde allies, hostile creeps, unchanged neutral relations, shared dialogue force and exact return diplomacy.')


def original_cave_conditions():
    lua, g = campaign((0,1))
    door = g.Z00_gg_rct_Zone_Goblin_Tripwire
    x=(g.GetRectMinX(door)+g.GetRectMaxX(door))/2
    y=(g.GetRectMinY(door)+g.GetRectMaxY(door))/2
    assert not g.Z00_Trig_Zone_to_GoblinCave_Conditions()
    g.SetUnitPosition(g.RC_hero[0],x,y)
    g.SetUnitPosition(g.RC_hero[1],x+75,y)
    assert g.Z00_Trig_Zone_to_GoblinCave_Conditions()
    g.bj_queuedExecTotal=1
    assert not g.Z00_Trig_Zone_to_GoblinCave_Conditions()
    g.bj_queuedExecTotal=0
    g.WORLD.time=10
    g.Z00_Trig_Zone_to_GoblinCave_Actions()
    assert g.RC_transitionPending and g.UZ_target==1 and g.UZ_area==1
    g.UZ_Travel();g.UZ_FinishEntry()
    assert g.RC_map==1
    print('PASS original Goblin Cave conditions: actual relocated region, living story hero, queue gating and in-session transition action.')


def manual_save_quests():
    lua,g=campaign((0,1))
    g.Z00_udg_QuestDyingWishProgress=2
    g.Z00_udg_QuestEarnKeepProgress1=True
    g.Z00_udg_QuestEarnKeepProgress2=False
    g.RC_SaveAll(False)
    assert g.RC_saveOK
    codes=[g.RC_checkpointCode[n] for n in (0,1)]
    _,h=setup((0,1))
    assert h.RC_LoadCheckpoint(codes[0],0)
    assert h.RC_LoadCheckpoint(codes[1],1)
    start(h)
    assert h.Z00_udg_QuestDyingWishProgress==2
    assert h.Z00_udg_QuestEarnKeepProgress1
    assert not h.Z00_udg_QuestEarnKeepProgress2
    print('PASS -save collects live original quest progress and restores it in a fresh session, instead of reusing stale portal state.')


def original_drekthar_spawn():
    _,g=campaign((0,1))
    g.Z00_CreateUnitsForPlayer2()
    drek=g.Z00_gg_unit_Odrt_0006
    assert drek is not None and g.GetUnitTypeId(drek)==g.FourCC('Odrt')
    assert g.GetOwningPlayer(drek)==g.Z00_udg_P03_Thrall
    assert g.GetHeroLevel(drek)==10
    assert g.UZ_ActiveUnit(drek) and drek.visible is not False and not g.IsUnitPaused(drek)
    advance(g,1);advance(g,0)
    assert g.GetUnitTypeId(drek)==g.FourCC('Odrt') and drek.visible
    print('PASS original DrekThar creation code: correct unit type (not Outland dirt), original owner/level and active-zone visibility preserved after return.')


def imports_during_arrival():
    _,g=campaign((0,1))
    g.Z00_InitTrig_Import_Mission_Data()
    g.Z00_udg_QuestDyingWishProgress=2
    g.RC_CollectStory()
    g.RC_sourceMap=1
    g.RC_nextArea=2
    g.RC_SeedStory()
    g.Z00_udg_QuestDyingWishProgress=0
    g.Z00_udg_TransitionSource=0
    g.Z00_udg_TransitionTargetArea=0
    # Imports run as part of arrival, not as a new outgoing door request.
    g.RC_transitionPending=True
    g.WORLD.time=0
    g.Z00_Trig_Import_All_Actions()
    assert g.Z00_udg_TransitionSource==2
    assert g.Z00_udg_TransitionTargetArea==2
    assert g.Z00_udg_QuestDyingWishProgress==2
    print('PASS original Import_All executes during pending arrival: cached source, entry area and live mission progress are decoded without the outgoing-door cooldown blocking them.')


def voice_wait_during_travel():
    for travelling in (False,True):
        _,g=campaign((0,1))
        counts={'reset':0,'remove':0}
        g.SetSpeechVolumeGroupsBJ=lambda:None
        g.TransmissionFromUnitWithNameBJ=lambda *args:None
        def reset(): counts['reset']+=1
        def remove(trigger): counts['remove']+=1
        def wait(sound,seconds):
            if travelling:
                g.RC_map=1
                g.UZ_generation[0]+=1
        g.VolumeGroupResetBJ=reset
        g.QueuedTriggerRemoveBJ=remove
        g.WaitForSoundBJ=wait
        g.Z00_Trig_HarpyThreat_CaravanFound_Q_Actions()
        expected=0 if travelling else 1
        assert counts=={'reset':expected,'remove':expected},(travelling,counts)
    print('PASS original caravan voice callback: normal completion cleans up; resuming a voice wait after travel cannot reset the new scene audio or touch its queue.')


if __name__=='__main__':
    original_player_setup()
    original_cave_conditions()
    manual_save_quests()
    original_drekthar_spawn()
    imports_during_arrival()
    voice_wait_during_travel()

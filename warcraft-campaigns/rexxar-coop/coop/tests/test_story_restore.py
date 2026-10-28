"""Decoded save -> original imports -> original quest journal reconstruction."""
import re
import sys
from pathlib import Path
from test_campaign_integration import campaign
from test_unified import setup,start

script=Path(sys.argv[1]).with_suffix('.j').read_text()


def quest_triggers(g,zone):
    prefix=f'Z{zone:02}_'
    names=re.findall(r'^function ('+prefix+r'InitTrig_Quest_\w+_(?:Create(?:Req\d+)?|Sync)) takes',script,re.M)
    for name in names:g[name]()
    return names


def saved_journal():
    for players in [(0,),(1,),(0,1),(0,1,2,3)]:
        _,g=campaign(players)
        g.Z00_udg_QuestDyingWishProgress=3
        g.Z00_udg_QuestSealTunnelProgress=4
        g.Z00_udg_QuestEarnKeepProgress=2
        g.Z00_udg_QuestEarnKeepProgress1=True
        for r in range(len(players)):
            g.SetPlayerState(g.RC_Player(r),g.PLAYER_STATE_RESOURCE_GOLD,777+17*r)
            g.SetPlayerState(g.RC_Player(r),g.PLAYER_STATE_RESOURCE_LUMBER,35+r)
        g.RC_SaveAll(False)
        assert g.RC_saveOK
        codes=[g.RC_checkpointCode[r] for r in range(len(players))]
        _,h=setup(players)
        for r,code in enumerate(codes):assert h.RC_LoadCheckpoint(code,r)
        start(h)
        # Reproduce source globals/player setup at the FIRST entry of a new
        # session, not just assignment of already-decoded progress variables.
        h.UZ_entering=True;h.RC_ready=False;h.RC_transitionPending=True
        h.Z00_InitGlobals()
        for name in ('SetPlayerColorBJ','SetPlayerOnScoreScreenBJ','EnableCreepSleepBJ'):
            h[name]=lambda *args:None
        h.Z00_Trig_Init_01_Players_Actions()
        h.RC_Alliances()
        h.Z00_InitTrig_Import_Mission_Data()
        assert len(quest_triggers(h,0))==36
        h.RC_SeedStory()
        h.Z00_Trig_Import_All_Actions()
        h.Z00_Trig_Sync_Quests_Actions()
        q=h.Z00_udg_QuestDyingWish
        assert q is not None and q.title=='Последняя воля'
        assert q.discovered and q.completed and q['items'][1].completed
        q=h.Z00_udg_QuestSealTunnel
        assert q.discovered and not q.completed
        assert [q['items'][i].completed for i in (1,2,3)]==[True,True,False]
        for r in range(len(players)):
            p=h.RC_Player(r)
            assert h.GetPlayerState(p,h.PLAYER_STATE_RESOURCE_GOLD)==777+17*r
            assert h.GetPlayerState(p,h.PLAYER_STATE_RESOURCE_LUMBER)==35+r
            assert h.GetPlayerAlliance(h.Z00_udg_P03_Thrall,p,h.ALLIANCE_PASSIVE)
        # Enemy-bank initialization remains possible; only party money is kept.
        h.RC_Resource(10,h.PLAYER_STATE_RESOURCE_GOLD,1500)
        assert h.GetPlayerState(10,h.PLAYER_STATE_RESOURCE_GOLD)==1500
    print('PASS fresh-session original act-I imports and all 36 quest create/sync triggers: finished delivery, cave objectives still awaiting turn-in, per-player gold/lumber, Horde allies and NPC resources.')


def cinematic_exit():
    for players in [(1,),(0,1,2,3)]:
        _,g=campaign(players)
        g.RC_CinematicEx(True,g.RC_force,0.3)
        assert g.RC_cinematicMode
        for r in range(len(players)):
            g.PauseUnit(g.RC_hero[r],True)
            g.SetUnitInvulnerable(g.RC_hero[r],True)
            g.UZ_ShowUnit(g.RC_hero[r],False)
        g.RC_CinematicEx(False,g.RC_force,0.3)
        assert not g.RC_cinematicMode and not g.WORLD.cinematic.enabled
        assert g.WORLD.cinematic.fade==0.3
        for r in range(len(players)):
            assert not g.IsUnitPaused(g.RC_hero[r]) and g.RC_hero[r].visible
            assert not g.RC_hero[r].invulnerable
    print('PASS custom-duration cinematic exit, including solo blue: state/party control/visibility/vulnerability restored and requested fade preserved.')


def second_act_journal():
    for players in [(1,),(0,1,2,3)]:
        _,g=setup(players)
        g.RC_map=5;g.RC_defaultLevel=8
        start(g);g.Z05_InitGlobals()
        g.Z05_udg_QuestSurvivorsProgress=3
        g.Z05_udg_QuestKhanProgress=4
        g.Z05_udg_QuestFirstBloodProgress=5
        g.Z05_udg_QuestStandardProgress=2
        g.Z05_udg_QuestStandardProgress1=True
        g.Z05_udg_QuestStandardProgress2=False
        g.Z05_udg_QuestStandardProgress3=True
        g.RC_SaveAll(False)
        assert g.RC_saveOK
        codes=[g.RC_checkpointCode[r] for r in range(len(players))]
        _,h=setup(players)
        for r,code in enumerate(codes):assert h.RC_LoadCheckpoint(code,r)
        start(h)
        h.UZ_entering=True;h.RC_transitionPending=True
        h.Z05_InitGlobals()
        h.Z05_InitTrig_Import_Mission_Data()
        names=quest_triggers(h,5)
        assert len(names)==29
        h.RC_SeedStory();h.Z05_Trig_Import_All_Actions()
        h.Z05_Trig_Sync_Quests_Actions()
        assert h.Z05_udg_QuestSurvivorsProgress==3
        q=h.Z05_udg_QuestKhan
        assert q.completed and all(q['items'][i].completed for i in (1,2))
        q=h.Z05_udg_QuestFirstBlood
        assert not q.completed and [q['items'][i].completed for i in (1,2,3,4)]==[True,True,True,False]
        q=h.Z05_udg_QuestStandard
        assert not q.completed and [q['items'][i].completed for i in (1,2,3,4)]==[True,False,True,False]
    print('PASS fresh-session act-II original import/sync, the Serpents/Survivors cache alias, completed Khan quest, incremental First Blood objectives and three independent Standard objectives.')


saved_journal()
cinematic_exit()
second_act_journal()

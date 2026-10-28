"""Native-spell event dispatch and deferred choices for the classic talent book."""
import sys
from test_unified import setup,start


def cast(g,role,node):
    hero=g.RC_hero[role]
    ability=g.RC_talentAbility[role*10+node]
    # The real engine exposes the nested Aspb spell at level 1. Its actual
    # list/order/requirements are checked independently in the MPQ audit.
    g.UnitAddAbility(hero,ability)
    g.WORLD.events.unit=hero;g.WORLD.events.player=hero.owner
    g.WORLD.events.spell=ability
    g.EmitUnitEvent(g.EVENT_PLAYER_UNIT_SPELL_EFFECT,hero,g.WORLD.events)


def book_choices():
    _,g=setup();start(g)
    for role in range(4):
        hero=g.RC_hero[role]
        assert g.GetUnitAbilityLevel(hero,g.RC_talentBook[role])==1
        assert g.GetUnitAbilityLevel(hero,g.FourCC('R5Ta'))==0
        assert all(g.GetPlayerTechCount(hero.owner,g.RC_talentTech[role*10+n],True)==0 for n in range(10))
        cast(g,role,0);g.RC_CommitTalents()
        assert g.RC_talents[role]==0
        g.SetHeroLevel(hero,4,False);g.RC_ProgressTick(role)
        assert [g.GetPlayerTechCount(hero.owner,g.RC_talentTech[role*10+n],True) for n in range(10)]==[1,1]+[0]*8
        before=g.RC_talents[role]
        cast(g,role,1)
        assert g.RC_talents[role]==before and g.RC_pendingTalent[role]==2
        # Repeated orders cannot replace the first pending choice.
        cast(g,role,0);assert g.RC_pendingTalent[role]==2
        g.RC_CommitTalents()
        assert g.RC_TalentChoice(role,0)==2
        assert [g.GetPlayerTechCount(hero.owner,g.RC_talentTech[role*10+n],True) for n in (0,1)]==[0,1]
        cast(g,role,0);g.RC_CommitTalents();assert g.RC_TalentChoice(role,0)==2
    # Two players can select at the same time without sharing pending state.
    for role in (0,1):g.SetHeroLevel(g.RC_hero[role],8,False)
    cast(g,0,2);cast(g,1,3);g.RC_CommitTalents()
    assert g.RC_TalentChoice(0,1)==1 and g.RC_TalentChoice(1,1)==2
    g.RC_SaveAll(False);codes=[g.RC_checkpointCode[r] for r in range(4)]
    _,h=setup()
    for role,code in enumerate(codes):assert h.RC_LoadCheckpoint(code,role)
    start(h)
    for role in range(4):
        h.RC_ProgressTick(role)
        assert h.RC_talents[role]==g.RC_talents[role]
        assert h.GetUnitAbilityLevel(h.RC_hero[role],h.RC_talentBook[role])==1
        assert h.GetPlayerTechCount(h.RC_Player(role),h.RC_talentTech[role*10],True)==0
        assert h.GetPlayerTechCount(h.RC_Player(role),h.RC_talentTech[role*10+1],True)==1
    print('PASS all four talent books: level requirements, two choices per tier, one permanent selection, deferred tech changes, first-order wins, simultaneous players and save/load restore.')


book_choices()

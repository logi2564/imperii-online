"""Point-loss rollback, progression and the lifetime of one-shot skill effects."""
from test_unified import setup,start
from test_kits import cast,ticks,enemy
import test_progress


def fresh(ignored=None):
    _,g=setup();start(g)
    for role in range(4):g.SetUnitPosition(g.RC_hero[role],100,200)
    return g


def failed_learning():
    for role in range(4):
        g=fresh();hero=g.RC_hero[role]
        cast_id=g.RC_skill[role*5];learn_id=g.RC_learnSkill[role*5]
        original=g.UnitAddAbility
        def blocked(unit,raw):
            if raw==learn_id:return False
            return original(unit,raw)
        g.UnitAddAbility=blocked;before=hero.points
        assert not g.RC_LearnRank(role,0)
        assert hero.points==before and g.GetUnitAbilityLevel(hero,cast_id)==0
        g.UnitAddAbility=original
        assert g.RC_LearnRank(role,0)
        g.SetHeroLevel(hero,3,False);before=hero.points
        set_level=g.SetUnitAbilityLevel
        g.SetUnitAbilityLevel=lambda unit,raw,rank: 0 if raw==learn_id else set_level(unit,raw,rank)
        assert not g.RC_LearnRank(role,0)
        assert hero.points==before
        assert g.GetUnitAbilityLevel(hero,cast_id)==1 and g.GetUnitAbilityLevel(hero,learn_id)==1
    print('PASS all four heroes: failed native learn-proxy installation/upgrade rolls both abilities back and never spends a skill point.')


def transient_effects():
    for role,skill,duration in [(2,0,0.75),(0,3,0.8),(1,0,0.5)]:
        g=fresh();target=g.RC_hero[0];target.hp=200
        cast(g,role,skill,x=450,y=200,target=target)
        if role==1:ticks(g,10)
        effect=g.WORLD.effects[len(g.WORLD.effects)]
        clock=g.WORLD.lastTimer
        assert clock.duration==duration and not effect.destroyed
        g.WORLD.expiredTimer=clock;clock.action()
        assert effect.destroyed and clock.destroyed
        assert g.LoadEffectHandle(g.RC_table,g.GetHandleId(clock),901) is None
    print('PASS fire cone, stampede impact and healing pulse survive their creation frame, expire on their own timer and release effect/timer handles.')


failed_learning()
transient_effects()
test_progress.fresh=fresh
test_progress.experience(None)

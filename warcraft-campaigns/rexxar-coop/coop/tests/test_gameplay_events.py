"""Registered event paths, conservative XP-native contracts, and the new codec.
No native Warcraft process is run: engine boundaries remain explicit mocks.
"""
import random,sys
from test_runtime import setup,begin,stats,chat
from test_kits import enemy,ticks

def registered_events(path):
    _,g=setup(path);begin(g)
    assert sum(r.event==g.EVENT_PLAYER_UNIT_DEATH for _,r in g.WORLD.unitEvents.items())==16
    assert sum(r.event==g.EVENT_PLAYER_HERO_SKILL for _,r in g.WORLD.unitEvents.items())==4
    for role in range(4):
        hero=g.RC_hero[role];g.SetHeroLevel(hero,20,False)
        for skill in range(4):
            for rank in range(1,4 if skill==3 else 6):
                before=hero.points
                g.SelectHeroSkill(hero,g.RC_learnSkill[role*5+skill])
                assert hero.points==before-1
                assert g.GetUnitAbilityLevel(hero,g.RC_skill[role*5+skill])==rank,(role,skill,rank)
                assert hero.permanent[g.RC_skill[role*5+skill]]
                g.UnitModifySkillPoints(hero,1)
        g.EmitUnitEvent(g.EVENT_PLAYER_UNIT_SPELL_EFFECT,hero,g._lua.table_from(dict(spell=g.FourCC('R5Sk'),x=0,y=0)))
        assert g.RC_progressPanel[role].visible,'K button did not reach registered spell event'
    # Cast all four Q abilities through the actual registered SPELL_EFFECT entry.
    for role in range(4):
        _,h=setup(path);begin(h)
        for n in range(4):h.SetUnitPosition(h.RC_hero[n],100,200)
        u=h.RC_hero[role];assert h.RC_LearnRank(role,0)
        a=enemy(h,300,200);h.RC_hero[0].hp=100
        target=h.RC_hero[0] if role==1 else a
        h.EmitUnitEvent(h.EVENT_PLAYER_UNIT_SPELL_EFFECT,u,h._lua.table_from(dict(spell=h.RC_skill[role*5],target=target,x=500,y=200)))
        ticks(h,35)
        assert h.RC_hero[0].hp>100 if role==1 else a.hp<1000,(role,'Learned Q has no effect')
    # A native installation failure refunds a native purchase and leaves no
    # locked-in learned proxy; a failed K purchase spends nothing either.
    _,g=setup(path);begin(g);u=g.RC_hero[0];points=u.points
    g.WORLD.rejectAbility=g.RC_skill[0]
    g.SelectHeroSkill(u,g.RC_learnSkill[0]);assert u.points==points
    assert g.GetUnitAbilityLevel(u,g.RC_learnSkill[0])==0
    assert not g.RC_LearnRank(0,0) and u.points==points
    g.WORLD.rejectAbility=None;assert g.RC_LearnRank(0,0) and u.points==points-1
    points=u.points;chat(g,0,'-learn W')
    assert g.GetUnitAbilityLevel(u,g.RC_skill[1])==1 and u.points==points-1
    chat(g,0,'-learn garbage');assert u.points==points-1
    chat(g,0,'-progress');assert any('REXXAR VI FIX' in text for _,text in g.WORLD.messages.items())
    g.SetHeroLevel(u,8,False);assert g.RC_LearnRank(0,0)
    g.UnitRemoveAbility(u,g.RC_learnSkill[0]);points=u.points
    g.SelectHeroSkill(u,g.RC_learnSkill[0])
    assert u.points==points and g.GetUnitAbilityLevel(u,g.RC_skill[0])==2
    assert g.GetUnitAbilityLevel(u,g.RC_learnSkill[0])==2
    g.SelectHeroSkill(u,g.RC_learnSkill[0])
    assert u.points==points-1 and g.GetUnitAbilityLevel(u,g.RC_skill[0])==3
    print('PASS: all 16 skills learn through registered native HERO_SKILL events at every rank; Q effects for all four heroes and K route through SPELL_EFFECT; permanent cast buttons; native/K installation failures do not lose points.')

def experience_and_replacement(path):
    lua,g=setup(path);begin(g)
    g.WORLD.strictSuspension=True;g.WORLD.rejectCorpseRange=True
    for n in range(4):g.SetUnitPosition(g.RC_hero[n],100,200)
    before=[g.RC_hero[n].xp for n in range(4)]
    g.SetHeroXP(g.RC_hero[0],9999,False)
    assert g.RC_hero[0].xp==before[0],'Strict test native must reject suspended writes'
    a=enemy(g,200,200)
    g.UnitDamageTarget(g.RC_hero[0],a,2000,False,False,None,None,None)
    assert [g.RC_hero[n].xp-before[n] for n in range(4)]==[32]*4
    assert all(g.RC_hero[n].suspended for n in range(4))
    for _ in range(28):
        a=enemy(g,200,200);a.level=7
        g.UnitDamageTarget(g.RC_hero[1],a,2000,False,False,None,None,None)
    assert all(g.RC_hero[n].level>=4 and g.RC_hero[n].points>2 for n in range(4))
    assert all(g.RC_GiveTalent(n,0,1) for n in range(4))
    for role in range(4):
        assert g.RC_LearnRank(role,0)
        u=g.RC_hero[role];g.UnitAddItemToSlotById(u,g.FourCC('ankh'),2)
        before=stats(g,role);g.RC_SourceRemove(u)
        assert g.GetUnitTypeId(u)!=0 and not u.visible and u.paused
        actor=g.CreateUnit(0,g.RC_heroType[role],100,200,0)
        g.RC_Adopt(role,actor)
        assert stats(g,role)==before and u.removed
        assert g.GetUnitAbilityLevel(actor,g.RC_learnSkill[role*5])==1
    print('PASS: registered combat deaths award full XP with suspended-write and corpse-range failures simulated; actual level/point/talent unlocks; source deletion/recruitment preserves XP, every learned skill, points and items.')

def compression(path):
    _,g=setup(path)
    rng=random.Random(726)
    samples=['C4'+'ABC123'*22,'C4'+'_'*140,'C4'+'0'*140]
    for length in (94,106,110,118,142):
        for _ in range(60):samples.append('C4'+''.join(rng.choice('0000000123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz-_') for _ in range(length-2)))
    shorter=0
    for sample in samples:
        code=g.RC_CompactCode(sample);old=g.RC_RLECode(sample)
        assert len(code)<=len(old)
        assert g.RC_ExpandCode(code)==sample
        shorter+=len(code)<len(old)
    for malformed in ('Z6~11','Z6A~00','Z6A~13','Z6A~2Z','Z6A~1_~1_~1_','Z6A~1','Z5A~14'):
        assert g.RC_ExpandCode(malformed)=='',malformed
    assert shorter>0
    print('PASS: Z6 back-references losslessly round-trip 303 dense/sparse/mixed-case payloads, always choose a code no longer than Z5, reject malformed references/overruns; old envelopes retained.')

if __name__=='__main__':
    # Lupa globals do not expose their runtime automatically.
    original=setup
    def setup(path):
        lua,g=original(path);g._lua=lua;return lua,g
    registered_events(sys.argv[1]);experience_and_replacement(sys.argv[1]);compression(sys.argv[1])

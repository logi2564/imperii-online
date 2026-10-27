"""Real generated JASS: learn points, per-player talent dialogs, XP and persistence.
Native game UI/pathfinding/art still require client testing; they are not mocked QA.
"""
import sys,math
from test_runtime import setup,begin,chat,stats
from test_kits import cast,ticks,enemy,fresh

def near(a,b):assert abs(a-b)<.001,(a,b)
def choose(path,role,tier,option):
    g=fresh(path);g.SetHeroLevel(g.RC_hero[role],20,False)
    assert g.RC_GiveTalent(role,tier,option)
    assert not g.RC_GiveTalent(role,tier,3-option),'Two talents in one tier'
    return g

def click(g,role,index,player=None):
    g.WORLD.events.panel=g.RC_progressPanel[role]
    g.WORLD.events.player=g.RC_Owner(role) if player is None else player
    g.WORLD.events.button=g.RC_progressButton[role*8+index]
    g.RC_ProgressClick()

def learning(path):
    g=fresh(path)
    for role in range(4):
        hero=g.RC_hero[role]
        assert hero.points==2 and all(g.GetUnitAbilityLevel(hero,g.RC_skill[role*5+n])==0 for n in range(5))
        assert g.GetUnitAbilityLevel(hero,g.FourCC('R5Sk')) and g.GetUnitAbilityLevel(hero,g.FourCC('R5Ta'))
        g.RC_Learn(hero,g.RC_oldSkill[role*4]);assert hero.points==2,'Original script stole starting points'
        assert not g.RC_LearnRank(role,3),'Ultimate at level two'
        assert g.RC_LearnRank(role,2) and hero.points==1,'Cannot learn previously zero-rank E'
        assert not g.RC_LearnRank(role,2),'Rank two E before hero level three'
        assert g.RC_LearnRank(role,0) and hero.points==0
        assert not g.RC_LearnRank(role,1),'Free skill purchase without point'
        g.SetHeroLevel(hero,20,False)
        for n in range(5):
            cap=3 if n==3 else 10 if n==4 else 5
            while g.GetUnitAbilityLevel(hero,g.RC_skill[role*5+n])<cap:
                g.UnitModifySkillPoints(hero,1)
                assert g.RC_LearnRank(role,n),(role,n)
            assert not g.RC_LearnRank(role,n),'Exceeded rank cap'
        # Actor handover and restoring zero skills retain the explicit K route.
        before=stats(g,role);actor=g.CreateUnit(g.RC_Owner(role),g.RC_heroType[role],100,200,0)
        g.RC_Adopt(role,actor);assert stats(g,role)==before
    h=fresh(path);h.RC_OpenProgress(0,0,0);before=h.RC_hero[0].points
    click(h,0,0,player=3);assert h.RC_hero[0].points==before,'Foreign player bought a skill'
    click(h,0,0);assert h.RC_hero[0].points==before-1
    print('PASS: all four heroes start with two FREE points; original script purchases cannot spend them; K learns all five skills with level/point/rank guards, including after actor handover; dialog ownership enforced.')

def dialogs(path):
    g=fresh(path);assert not g.RC_GiveTalent(0,0,1)
    for role in range(4):
        g.SetHeroLevel(g.RC_hero[role],4,False)
        assert not g.RC_GiveTalent(role,1,1),'Locked talent tier'
        g.RC_OpenProgress(role,1,0);click(g,role,0)
        assert g.RC_progressMode[role]==2
        mask=g.RC_talents[role];click(g,role,0,player=(3 if role==0 else 0))
        assert g.RC_talents[role]==mask
        click(g,role,1);assert g.RC_TalentChoice(role,0)==2
        assert not g.RC_GiveTalent(role,0,1)
    # Distinct panels and mode/tier state must not overwrite another player.
    g.SetHeroLevel(g.RC_hero[0],8,False);g.SetHeroLevel(g.RC_hero[1],12,False)
    g.RC_OpenProgress(0,2,1);g.RC_OpenProgress(1,2,2)
    click(g,0,0);click(g,1,1)
    assert g.RC_TalentChoice(0,1)==1 and g.RC_TalentChoice(1,2)==2
    g.SetHeroLevel(g.RC_hero[0],20,False)
    for tier in range(5):
        if g.RC_TalentChoice(0,tier)==0:assert g.RC_GiveTalent(0,tier,1)
    g.RC_talentAnnounced[0]=0;before=len(g.WORLD.messages);g.RC_ProgressTick(0)
    assert len(g.WORLD.messages)==before,'Announced talents when all tiers already chosen'
    print('PASS: talent levels 4/8/12/16/20, one of two options per tier, separate simultaneous player panels, stale/foreign choices refused.')

def experience(path):
    g=fresh(path)
    assert all(g.RC_hero[n].suspended for n in range(4))
    for role in range(4):g.RC_XPHandicapPercent(g.RC_Player(role),7);assert g.WORLD.players[g.RC_Player(role)].xp==1
    start=[g.RC_hero[n].xp for n in range(4)]
    def kill(u,killer=None):
        u.hp=0;g.WORLD.events.unit=u;g.WORLD.events.killer=g.RC_hero[0] if killer is None else killer;g.RC_KillExperience()
    a=enemy(g);a.level=1;kill(a)
    assert [g.RC_hero[n].xp-start[n] for n in range(4)]==[32]*4
    assert len(g.WORLD.tags)==4 and sum(1 for _,v in g.WORLD.tags.items() if v.visible)==1
    b=enemy(g);b.level=5;kill(b)
    assert all(g.RC_hero[n].xp==start[n]+96 for n in range(4))
    g.RC_hero[3].x=5000;g.RC_hero[2].hp=0
    c=enemy(g);kill(c);assert g.RC_hero[0].xp==start[0]+128 and g.RC_hero[3].xp==start[3]+96 and g.RC_hero[2].xp==start[2]+96
    current=g.RC_hero[0].xp
    for attr in ('summoned','illusion'):
        u=enemy(g);u[attr]=True;kill(u)
    friendly=g.CreateUnit(8,g.FourCC('hfoo'),100,200,0);kill(friendly)
    u=enemy(g);g.WORLD.events.unit=u;g.WORLD.events.killer=None;g.RC_KillExperience()
    assert g.RC_hero[0].xp==current,'Invalid death farmed XP'
    g.RC_StoryCinematic=lambda:True;kill(enemy(g));assert g.RC_hero[0].xp==current
    g.RC_StoryCinematic=lambda:False
    hero=g.RC_hero[0];old_points=hero.points
    for _ in range(25):kill(enemy(g))
    assert hero.level>=4 and hero.points>old_points and g.RC_GiveTalent(0,0,1),'Kills did not unlock real levels/points/talents'
    # Full four-hero XP remains even when one player controls all four.
    h=fresh(path)
    for player in (1,2,3):h.WORLD.players[player].controller='computer'
    u=enemy(h);u.hp=0;h.WORLD.events.unit=u;h.WORLD.events.killer=h.RC_hero[0];h.RC_KillExperience()
    assert h.RC_hero[0].xp==232 and all(h.RC_hero[n].xp==200 for n in range(1,4)), 'Closed slots gained XP'
    print('PASS: actual kill XP +32 (level-1) and +64 (level-5) to EACH nearby living hero, no shared-XP/player handicap penalty, actual level/skill/talent unlocks; dead/far heroes, summons, illusions, allies, unknown killer and cinematics excluded; local floating feedback.')

def node_effects(path):
    # Every advertised node is exercised through an actual cast/timer/outcome.
    tested=[]
    def node(role,tier,choice):tested.append((role,tier,choice));return choose(path,role,tier,choice)
    # Rexxar
    g=node(0,0,1);a=enemy(g);cast(g,0,0);ticks(g,35);near(a.hp,1000-2*85*1.25)
    g=node(0,0,2);cast(g,0,1);pets=[u for _,u in g.WORLD.units.items() if u.summoned];assert all(u.maxhp==1375 for u in pets)
    g=node(0,1,1);a=enemy(g);cast(g,0,2,target=a);ticks(g,70);assert a.hp==790 and any(g.RK_kind[n]==3 for n in range(1,65))
    g=node(0,1,2);a=enemy(g);g.RC_hero[0].hp=100;cast(g,0,2,target=a);a.hp=0;ticks(g,1);near(g.RC_hero[0].hp,340)
    g=node(0,2,1);cast(g,0,1);assert all(g.GetUnitAbilityLevel(u,g.FourCC('R5Pd'))==1 for _,u in g.WORLD.units.items() if u.summoned)
    g=node(0,2,2);a=enemy(g);cast(g,0,2,target=a);ticks(g,10);near(a.hp,955)
    g=node(0,3,1);a=enemy(g);cast(g,0,3);assert any(u.order=='thunderbolt' for _,u in g.WORLD.units.items())
    g=node(0,3,2);a=enemy(g);b=enemy(g,500,200);cast(g,0,2,target=a);a.hp=0;ticks(g,1);near(b.hp,720)
    g=node(0,4,1);a=enemy(g);cast(g,0,0);ticks(g,35);assert a.hp<1000-2*85
    g=node(0,4,2);cast(g,0,3);assert sum(1 for _,u in g.WORLD.units.items() if u.duration==12)==5
    # Rokhan
    g=node(1,0,1);a=g.RC_hero[0];a.hp=200;cast(g,1,0,target=a);ticks(g,30);near(a.hp,200+(85+3*26)*1.3)
    g=node(1,0,2);a=g.RC_hero[0];a.hp=200;a.x=1000;cast(g,1,1,x=450);ticks(g,10);near(a.hp,230)
    g=node(1,1,1);a=g.RC_hero[0];cast(g,1,0,target=a);assert a.cleansed
    g=node(1,1,2);a=g.RC_hero[0];a.mana=0;cast(g,1,2,target=a);ticks(g,70);near(a.mana,125)
    g=node(1,2,1);a=g.RC_hero[0];a.hp=200;cast(g,1,1,x=100);ticks(g,10);near(a.hp,245)
    g=node(1,2,2);a=enemy(g,100);cast(g,1,3,x=100);ticks(g,10);near(a.hp,913)
    g=node(1,3,1);a=enemy(g,100);cast(g,1,1,x=100);ticks(g,10);near(a.hp,980)
    g=node(1,3,2);a=g.RC_hero[0];a.hp=100;cast(g,1,3,x=100);ticks(g,10);near(a.hp,172.8)
    g=node(1,4,1);cast(g,1,2,target=g.RC_hero[0]);assert sum(g.RK_kind[n]==7 for n in range(1,65))==2
    g=node(1,4,2)
    for role in (0,2,3):g.RC_hero[role].hp=0
    cast(g,1,3,x=100);assert all(g.RC_hero[role].hp==400 for role in (0,2,3))
    # Chen
    g=node(2,0,1);a=enemy(g);cast(g,2,0);ticks(g,65);cast(g,2,1);ticks(g,10);near(a.hp,1000-85-190*1.6)
    g=node(2,0,2);a=enemy(g);cast(g,2,0);near(a.hp,1000-85*1.25)
    g=node(2,1,1);a=enemy(g,780);cast(g,2,1);ticks(g,10);near(a.hp,810)
    g=node(2,1,2);cast(g,2,2,x=900);ticks(g,20);near(g.RC_hero[2].x,700)
    g=node(2,2,1);a=enemy(g);cast(g,2,0);cast(g,2,1);ticks(g,10);assert any(g.GetUnitAbilityLevel(u,g.FourCC('RSt2')) for _,u in g.WORLD.units.items())
    g=node(2,2,2);g.RC_hero[2].hp=100
    for x in (200,300,400):enemy(g,x)
    cast(g,2,2);ticks(g,15);near(g.RC_hero[2].hp,260)
    g=node(2,3,1);a=enemy(g);cast(g,2,3);ticks(g,10);near(a.hp,935)
    g=node(2,3,2);a=enemy(g);cast(g,2,1);ticks(g,10);assert g.LoadReal(g.RC_table,a.handle,301)>g.RC_skillTime
    g=node(2,4,1);a=enemy(g,930);cast(g,2,3);ticks(g,70);assert a.hp<1000 and any(g.RK_kind[n]==12 for n in range(1,65))
    g=node(2,4,2);a=enemy(g);cast(g,2,1);ticks(g,10);near(a.hp,620)
    # Cairne
    g=node(3,0,1);a=enemy(g);cast(g,3,0);ticks(g,15);near(a.hp,1000-85*1.25)
    g=node(3,0,2);cast(g,3,1);assert g.GetUnitAbilityLevel(g.RC_hero[3],g.FourCC('R5Ar'))==1;ticks(g,60);assert g.GetUnitAbilityLevel(g.RC_hero[3],g.FourCC('R5Ar'))==0
    g=node(3,1,1);a=enemy(g,150);cast(g,3,2);g.UnitDamageTarget(a,g.RC_hero[3],200,False,False,None,None,None);ticks(g,50);near(a.hp,766)
    g=node(3,1,2);a=enemy(g,450,400);cast(g,3,0);ticks(g,15);near(a.hp,915)
    g=node(3,2,1);g.RC_hero[3].hp=100;cast(g,3,1);ticks(g,60);near(g.RC_hero[3].hp,280)
    g=node(3,2,2);a=enemy(g);cast(g,3,0);ticks(g,15);assert any(g.GetUnitAbilityLevel(u,g.FourCC('RSt2')) for _,u in g.WORLD.units.items())
    g=node(3,3,1);a=enemy(g,550);cast(g,3,2);ticks(g,50);near(a.hp,916)
    g=node(3,3,2);a=g.RC_hero[0];a.hp=200;cast(g,3,3,x=100);ticks(g,10);near(a.hp,215)
    g=node(3,4,1);a=enemy(g);cast(g,3,0);ticks(g,15);near(a.hp,745)
    g=node(3,4,2);a=g.RC_hero[0];a.hp=100;cast(g,3,2);ticks(g,50);near(a.hp,142)
    # Anchor is specifically a death-return spell: it must outlive its caster.
    g=choose(path,1,4,1);caster=g.RC_hero[1];cast(g,1,2,target=caster)
    anchored=[g.RK_target[n] for n in range(1,65) if g.RK_kind[n]==7]
    assert len(anchored)==2
    for u in anchored:u.hp=0
    ticks(g,70);assert all(u.hp>0 for u in anchored),'Caster death cancelled soul anchors'
    assert len(set(tested))==40
    print('PASS: all FORTY distinct talents exercised through spells, timers, damage/heal amounts, pets, range/duration changes, extra projectiles, double anchors, resurrection and temporary armour cleanup.')

def persistence(first,second):
    g=fresh(first)
    masks=[]
    for role in range(4):
        g.SetHeroLevel(g.RC_hero[role],20,False)
        for tier in range(5):assert g.RC_GiveTalent(role,tier,1+(role+tier)%2)
        masks.append(g.RC_talents[role])
    g.RC_Transition(5,1);codes=[g.RC_checkpointCode[n] for n in range(4)]
    assert all(c.startswith('Z5') and len('-load '+c)<=127 for c in codes)
    _,h=setup(second)
    for c in codes:chat(h,0,'-load '+c)
    begin(h);assert [h.RC_talents[n] for n in range(4)]==masks
    for role in range(4):
        actor=h.CreateUnit(h.RC_Owner(role),h.RC_heroType[role],100,200,0);h.RC_Adopt(role,actor)
        assert h.RC_talents[role]==masks[role]
    # Build real legacy envelopes by removing ONLY the two new talent chars.
    _,old=setup(second)
    for code in codes:
        raw=g.RC_ExpandCode(code);old.RC_codeOK=True
        legacy=old.RC_Seal('C2'+raw[2:14]+raw[16:89]+raw[91:-3])
        assert len(legacy)==102
        chat(old,0,'-load '+old.RC_CompactCode(legacy))
    begin(old);assert old.RC_started and all(old.RC_talents[n]==0 for n in range(4))
    _,invalid=setup(second);raw=g.RC_ExpandCode(codes[0]);invalid.RC_codeOK=True
    bad=invalid.RC_Seal(raw[:89]+'__'+raw[91:-3]);chat(invalid,0,'-load '+invalid.RC_CompactCode(bad))
    assert not invalid.RC_checkpointLoaded,'Invalid base-3 talent state committed'
    print('PASS: all hero talent choices survive new Z5/C4 codes, map transition and narrative actor handover; real Z3/C2 payloads remain loadable with unspent talents; invalid talent masks rejected atomically.')

if __name__=='__main__':
    learning(sys.argv[1]);dialogs(sys.argv[1]);experience(sys.argv[1]);node_effects(sys.argv[1]);persistence(sys.argv[1],sys.argv[2])

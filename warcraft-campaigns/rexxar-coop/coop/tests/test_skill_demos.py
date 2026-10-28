"""Rehearsal mechanics/cleanup and isolation; graphics still require Warcraft."""
import json,sys
from pathlib import Path
from test_unified import setup,start


def live(g):
    return [u for _,u in g.WORLD.units.items() if not u.removed]


def demos():
    _,g=setup()
    saved=[g.RC_talents[r] for r in range(4)]
    for skill in range(4):
        for p in range(4):
            g.UM_details[p]=True
            old=g.UM_unit[p]
            g.WORLD.events.unit=old;g.WORLD.events.player=p
            g.WORLD.events.spell=g.UM_detailAbility[p*4+skill]
            g.UM_Spell()
            assert g.UM_pending[p]==14+skill and not old.removed
        g.UM_Input()
        assert not g.RC_started and g.RC_training and g.UM_demoCount==4
        actors=[g.UM_demoHero[p] for p in range(4)]
        triggers=[g.UM_demoDamage[p] for p in range(4)]
        for _ in range(40):g.UM_DemoTick()
        assert all(g.UM_demoCast[p] for p in range(4))
        assert all(triggers[p].destroyed is not True for p in range(4))
        # Distinct live results, rather than merely a successful callback:
        # axes/cone/fissure hurt enemies; healing benefits its caster; pets
        # and a destructible ward exist; the anchor lets its subject die.
        if skill==0:
            for p in (0,2,3):
                assert any(u.hp<1000 for _,u in g.UM_demoEnemies[p].items())
            assert actors[1].hp>450
        elif skill==1:
            assert any(u.summoned and u.owner==0 for u in live(g))
            assert any(u.id==g.FourCC('ohwd') for u in live(g))
        elif skill==2:
            assert actors[1].hp<=0.405
        for _ in range(80):g.UM_DemoTick()
        assert not g.RC_training and g.UM_demoCount==0
        assert all(g.GetUnitTypeId(u)==0 for u in actors)
        assert all(g.RC_hero[r] is None for r in range(4))
        assert all(g.RK_kind[s]==0 for s in range(1,65))
        assert all(t.destroyed for t in triggers)
        assert len(live(g))==4,[(u.owner,u.id) for u in live(g)]
        assert [g.RC_talents[r] for r in range(4)]==saved
    # Swapping classes and entering the campaign cannot retain actors or pets.
    g.UM_StartDemo(0,1);g.UM_StartDemo(2,3)
    g.UM_Choose(0,2)
    assert g.UM_demoCount==0 and not g.RC_training
    g.UM_StartDemo(0,0)
    start(g)
    assert g.RC_started and not g.RC_training and g.UM_demoCount==0
    assert all(g.GetHeroLevel(g.RC_hero[r])==2 and g.GetHeroSkillPoints(g.RC_hero[r])==2 for r in range(4))
    # A rehearsal must also leave decoded progress intact before continuing.
    g.SetHeroLevel(g.RC_hero[0],8,False)
    assert g.RC_LearnRank(0,0) and g.RC_GiveTalent(0,0,2)
    g.UnitAddItemToSlotById(g.RC_hero[0],g.FourCC('shea'),2)
    g.RC_SaveAll(False)
    codes=[g.RC_checkpointCode[r] for r in range(4)]
    _,h=setup()
    h.UM_ready[1]=True
    h.UM_StartDemo(0,1)
    for r,code in enumerate(codes):assert h.RC_LoadCheckpoint(code,r)
    assert h.UM_demoCount==0 and not h.RC_training and not h.UM_ready[1]
    h.UM_StartDemo(0,3)
    for _ in range(30):h.UM_DemoTick()
    start(h)
    assert h.GetHeroLevel(h.RC_hero[0])==8
    assert h.GetUnitAbilityLevel(h.RC_hero[0],h.RC_skill[0])==1
    assert h.RC_talents[0]==2 and h.GetItemTypeId(h.UnitItemInSlot(h.RC_hero[0],2))==h.FourCC('shea')
    print('PASS all sixteen skill rehearsals use shared campaign mechanics, four simultaneous viewers, timeout/cancel/class-swap cleanup and a clean level-2 campaign start.')


def stages():
    from build import ROOT,MAPS
    from storm import Storm
    import unified_terrain as terrain
    out=Path(sys.argv[1]).parent
    points=json.loads((out/'Preview-stages.json').read_text())
    plans=json.loads((out/'Atlas-plan.json').read_text())
    assert len(points)==4 and len({tuple(v) for v in points})==4
    for x,y in points:
        for zone in plans.values():
            # Complete original crop plus a margin stays outside the stage.
            a=-30720+zone['atlasX']*128;b=-30720+zone['atlasY']*128
            X=a+zone['cropWidth']*128;Y=b+zone['cropHeight']*128
            assert x+896<a or x-896>X or y+896<b or y-896>Y
    storm=Storm();terrains=[];paths={};shadows={}
    for name in MAPS:
        archive=storm.open(ROOT/'inputs'/(name+'.w3x'))
        try:
            t=terrain.read(name,storm.read(archive,'war3map.w3e'),storm.read(archive,'war3map.w3i'))
            paths[name]=storm.read(archive,'war3map.wpm');shadows[name]=storm.read(archive,'war3map.shd')
        finally:storm.close(archive)
        t.atlas_x=plans[name]['atlasX'];t.atlas_y=plans[name]['atlasY'];terrains.append(t)
    original,_=terrain.merge(terrains,paths,shadows)
    actual={name:(out/'merged'/name).read_bytes() for name in original}
    header=len(original['war3map.w3e'])-(terrain.SIZE+1)**2*7
    assert actual['war3map.w3e'][:header]==original['war3map.w3e'][:header]
    for t in terrains:
        width,height=t.crop[2:]
        for row in range(height+1):
            a=header+((t.atlas_y+row)*(terrain.SIZE+1)+t.atlas_x)*7
            b=a+(width+1)*7
            assert actual['war3map.w3e'][a:b]==original['war3map.w3e'][a:b],(t.name,'terrain',row)
        for row in range(height*4):
            a=(t.atlas_y*4+row)*terrain.SIZE*4+t.atlas_x*4;b=a+width*4
            assert actual['war3map.wpm'][16+a:16+b]==original['war3map.wpm'][16+a:16+b],(t.name,'pathing',row)
            assert actual['war3map.shd'][a:b]==original['war3map.shd'][a:b],(t.name,'shadow',row)
    print('PASS rehearsal platforms are separate from all seventeen original mission crops; every original terrain vertex, pathing row and shadow row remains unchanged by the platforms.')


demos()
stages()

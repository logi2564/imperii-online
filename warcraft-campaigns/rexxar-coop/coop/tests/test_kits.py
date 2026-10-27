"""Execute actual generated JASS mechanics. Native pathing/art/netcode not emulated."""
import random,sys
from pathlib import Path
from test_runtime import setup,begin,chat

def cast(g,role,skill,x=450,y=200,target=None,rank=2):
    hero=g.RC_hero[role];raw=g.RC_skill[role*5+skill]
    g.UnitAddAbility(hero,raw);g.SetUnitAbilityLevel(hero,raw,rank)
    g.WORLD.events.unit=hero;g.WORLD.events.spell=raw;g.WORLD.events.x=x;g.WORLD.events.y=y;g.WORLD.events.target=target
    g.RC_Spell()

def ticks(g,n):
    for _ in range(n):g.RK_Tick()

def enemy(g,x=450,y=200):return g.CreateUnit(10,g.FourCC('hfoo'),x,y,0)
def fresh(path):
    _,g=setup(path);begin(g)
    for role in range(4):g.SetUnitPosition(g.RC_hero[role],100,200)
    return g

def skills(path):
    # Topor two passes only, independent overlapping casts, enemy-only damage.
    g=fresh(path);a=enemy(g);friend=g.CreateUnit(0,g.FourCC('ogru'),450,200,0)
    cast(g,0,0);cast(g,0,0);ticks(g,35)
    assert a.hp==1000-4*85 and friend.hp==1000,(a.hp,friend.hp)
    assert all(g.RK_kind[n]==0 for n in range(1,65))
    g=fresh(path);a=enemy(g);cast(g,0,2,target=a);cast(g,0,0);ticks(g,35)
    assert a.hp<1000-2*85,'Hunt failed to amplify axe'
    g.RC_hero[0].hp=400;a.hp=0;ticks(g,1);assert g.RC_hero[0].hp>400,'Hunt kill heal missing'
    g=fresh(path);before=len(g.WORLD.units);cast(g,0,1)
    pets=[u for n,u in g.WORLD.units.items() if n>before];assert len(pets)==2 and all(u.summoned and u.duration==22 and u.maxhp>1000 for u in pets)
    a=enemy(g);cast(g,0,3,x=450,y=200);assert a.hp==740 and sum(1 for _,u in g.WORLD.units.items() if u.summoned)==5
    # Thread, destructible healing totem, anchor on a living/dead hero, revive ult.
    g=fresh(path);target=g.RC_hero[0];target.hp=200
    cast(g,1,0,target=target);ticks(g,30);assert target.hp==200+85+3*26,target.hp
    target.hp=200;cast(g,1,1,x=100,y=200);ticks(g,10);assert target.hp==230 and target.cleansed
    ward=next(u for _,u in g.WORLD.units.items() if u.id==g.FourCC('ohwd'));ward.hp=0;ticks(g,10);assert target.hp==230
    cast(g,1,2,target=target);target.hp=10;target.x=800;ticks(g,70);assert target.x==100 and target.hp>=230,(target.x,target.hp)
    target.hp=490;cast(g,1,2,target=target);target.hp=0;ticks(g,70);assert target.hp==490
    target.hp=0;a=enemy(g,100,200);cast(g,1,3,x=100,y=200);assert target.hp==400;ticks(g,80);assert a.hp==584 and target.hp>400
    # Wet cone -> travel barrel combo; dash hits once and stops before a wall.
    g=fresh(path);a=enemy(g);cast(g,2,0);assert a.hp==915 and g.LoadReal(g.RC_table,a.handle,301)>0
    cast(g,2,1);ticks(g,10);assert abs(a.hp-(915-190*1.6))<0.001,a.hp
    g=fresh(path);a=enemy(g,250,200);g.WORLD.wallX=310;cast(g,2,2);ticks(g,15)
    assert a.hp==915 and g.RC_hero[2].x<310 and not g.RC_hero[2].paused,(a.hp,g.RC_hero[2].x)
    g=fresh(path);a=enemy(g,400,200);boss=enemy(g,400,220);boss.hero=True
    cast(g,2,3,x=100,y=200);ticks(g,60);assert a.x<400 and boss.x==400 and a.hp<1000
    # Fissure one hit, taunt/armour cleanup, real counter damage, ancestor zone.
    g=fresh(path);a=enemy(g);cast(g,3,0);ticks(g,15);assert a.hp==915
    a.x=150;cast(g,3,1);ticks(g,10);assert a.target.handle==g.RC_hero[3].handle and g.GetUnitAbilityLevel(g.RC_hero[3],g.RC_armorId[2])==1
    ticks(g,50);assert g.GetUnitAbilityLevel(g.RC_hero[3],g.RC_armorId[2])==0
    hero=g.RC_hero[3];hero.hp=400;cast(g,3,2);g.UnitDamageTarget(a,hero,100,False,False,None,None,None);ticks(g,50)
    assert hero.hp>250 and a.hp<915,(hero.hp,a.hp)
    a.hp=1000;cast(g,3,3);ticks(g,20);assert a.hp==740 and g.GetUnitAbilityLevel(hero,g.RC_armorId[2])==1
    ticks(g,60);assert g.GetUnitAbilityLevel(hero,g.RC_armorId[2])==0
    assert all(g.RK_kind[n]==0 for n in range(1,65))
    # Replacing a narrative actor cleans old skills, not its new learned ranks.
    old=g.RC_hero[0];raw=g.RC_skill[0];g.UnitAddAbility(old,raw);g.SetUnitAbilityLevel(old,raw,3)
    actor=g.CreateUnit(0,g.FourCC('Orex'),0,0,0);g.UnitAddAbility(actor,g.FourCC('Arsg'));g.RC_Adopt(0,actor)
    assert g.GetUnitAbilityLevel(actor,raw)==3 and g.GetUnitAbilityLevel(actor,g.FourCC('Arsg'))==0
    print('PASS: all 16 scripted skills: independent casts, outbound/return hit bounds, hunt/kill heal, ranked pets, pounce, heal thread, destructible cleanse totem, live/dead anchor, drain/revive, wet/fire combo, pathing-bounded dash, vortex boss immunity, fissure, taunt/armour expiry, damage counter, ancestor pulses; actor adoption keeps new kit.')

def balance(path):
    values=[]
    for difficulty in range(3):
        g=fresh(path);a=enemy(g);a.hp=400;g.RC_difficulty=difficulty;g.RC_Balance()
        for _ in range(5):g.RC_BalanceScan()
        expected=[2500,4500,6500][difficulty]
        assert a.maxhp==expected and abs(a.hp-expected*.4)<.001,(difficulty,a.maxhp,a.hp)
        g.RC_Balance();assert a.maxhp==expected,'HP multiplied twice'
        target=g.RC_hero[0];target.hp=1000;g.UnitDamageTarget(a,target,100,False,False,None,None,None)
        assert target.hp==1000-[100,150,200][difficulty],target.hp
        values.append((a.maxhp,target.hp))
        reinforcement=enemy(g)
        for _ in range(4):g.RC_BalanceScan()
        assert reinforcement.maxhp==expected,'New enemy spawn unscaled'
        g.SetUnitOwner(a,0,False)
        for _ in range(4):g.RC_BalanceScan()
        assert a.maxhp==1000,'Rescued unit retains enemy HP bonus'
        # Enemy spell damage + counter itself must not recursively rescale.
        hero=g.RC_hero[3];hero.hp=1000;cast(g,3,2);g.UnitDamageTarget(reinforcement,hero,100,False,False,None,None,None)
        assert max(g.RK_value[n] for n in range(1,65))==[100,150,200][difficulty]
    g=fresh(path)
    for p in (3,4,5):g.WORLD.players[p].controller='computer'
    g.RC_difficulty=2;g.RC_Balance();a=enemy(g)
    for _ in range(4):g.RC_BalanceScan()
    assert a.maxhp==6500,'Solo control of four heroes bypasses party scaling'
    print('PASS: direct enemy max HP 2.5/4.5/6.5x, damage 1/1.5/2x; no compound rescaling/recursion; current life fraction, new spawns, rescue reversal, four-hero solo case, and counter include scaled damage.')

def saves(path):
    lengths=[]
    for local in (0,3,4,5):
        g=fresh(path);g.WORLD.localPlayer=local;before=len(g.WORLD.messages);g.RC_SaveAll(True)
        messages=[t for n,t in g.WORLD.messages.items() if n>before and '-load ' in t]
        assert len(messages)==1 and g.RC_checkpointCode[g.RC_Role(local)] in messages[0],messages
        lengths.append(len(g.RC_checkpointCode[g.RC_Role(local)]))
    g=fresh(path)
    for p in (3,4,5):g.WORLD.players[p].controller='computer'
    before=len(g.WORLD.messages);g.RC_SaveAll(True)
    assert len([t for n,t in g.WORLD.messages.items() if n>before and '-load ' in t])==1
    assert all(g.RC_checkpointCode[n] in g.RC_saveQuest.description for n in range(4))
    assert max(lengths)<50,lengths
    rng=random.Random(4)
    for _ in range(300):
        payload='C2'+''.join(rng.choice('0000000000000'+g.RC_alphabet) for _ in range(100))
        encoded=g.RC_CompactCode(payload)
        assert g.RC_ExpandCode(encoded)==payload and len(encoded)<=102
    for bad in ('Z3.', 'Z3.2','Z3._._','Z3!!!!','Z3.'+'0'*100):assert not g.RC_CheckpointValid(bad)
    g.RC_SaveAll(False);raw=g.RC_ExpandCode(g.RC_checkpointCode[0]);_,target=setup(path)
    assert target.RC_LoadCheckpoint(raw,0),'Uncompressed C2 backward compatibility lost'
    print('PASS: exactly ONE local code line on all four clients and solo host; absent-role backup in F9; early code lengths '+str(lengths)+' versus 102; 300 lossless random-envelope round trips; malformed/oversized envelopes refused; C2 backwards compatible.')

if __name__=='__main__':skills(sys.argv[1]);balance(sys.argv[1]);saves(sys.argv[1])

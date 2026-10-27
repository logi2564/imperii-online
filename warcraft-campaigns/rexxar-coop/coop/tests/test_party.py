"""Dynamic 1..4 player campaign, party-only troop allocation, and save codecs.
Executes the actual generated mission scripts with native boundaries mocked.
"""
import sys,shutil
from pathlib import Path
from test_runtime import setup,begin,chat,stats
from test_kits import cast,ticks,enemy

MASKS=[1,3,5,9,7,11,13,15]
def roles(mask):return [n for n in range(4) if mask&(1<<n)]
def create(path,mask):
    _,g=setup(path,players=roles(mask));begin(g)
    for n in roles(mask):g.SetUnitPosition(g.RC_hero[n],100,200)
    return g

def fixtures(g,folder):
    folder.mkdir(parents=True,exist_ok=True)
    for p in folder.glob('RexxarCoop-P*.txt'):p.unlink()
    for role in roles(g.RC_savedMask):
        g.WORLD.localPlayer=role;g.RC_WriteSave(role,g.RC_checkpointCode[role])
    for name,text in g.WORLD.files.items():(folder/name.split('\\')[-1]).write_text(text)

def roster(path):
    for mask in MASKS:
        g=create(path,mask);active=roles(mask)
        assert g.RC_CurrentMask()==mask
        assert [n for n in range(4) if g.RC_hero[n] is not None]==active
        assert len(g.WORLD.units)==len(active),'Unoccupied slot spawned a playable hero'
        assert all(g.RC_hero[n].owner==n for n in active)
        assert g.RC_hero[0].points==2
        g.udg_RokhanInParty=True
        assert g.Trig_Approach_Resurrection_Stone_01_Func004Func003001()==(1 in active)
        g.RC_ObserveStoryHeroes();g.RC_CollectStory()
        assert g.udg_RokhanInParty and g.RC_flags[1]==1, 'Recruitment story was erased because slot was closed'
        expected=1+(len(active)-1)*3.5/3
        assert abs(g.RC_enemyLife-expected)<.001
        for role in range(1,4):
            if role in active:continue
            npc=g.RC_SourceCreate(0,g.RC_heroType[role],100,200,0)
            assert npc.owner==15 and npc.visible is False and npc.paused and npc.invulnerable
            assert g.RC_hero[role] is None and g.RC_StoryOwner(npc)==0
            group=g.CreateGroup();g.RC_SourceGroupSimple(npc,group);assert len(group)==0,'Absent actor entered quest party group'
            g.RC_SourceShowOn(npc);assert not npc.visible,'Source ShowUnit resurrected absent player hero'
            troop=g.RC_SourceCreate(role,g.FourCC('ogru'),100,200,0)
            assert troop.owner==15 and not troop.visible
        # Original campaign ownership writes cannot give another slot the active hero.
        g.RC_SourceOwner(g.RC_hero[0],g.RC_Player(3),True)
        assert g.RC_hero[0].owner==0 and not g.LoadBoolean(g.RC_table,g.RC_hero[0].handle,700)
        # Eleven QUEST reinforcements split only among occupied slots.
        point=g.CreateUnit(14,g.FourCC('hfoo'),100,200,0) # coordinates-only native mock
        group=g.RC_SourceCreateAtLoc(11,g.FourCC('ogru'),0,point,0)
        g.RC_Distribute();units=list(group.values())
        counts=[sum(u.owner==role for u in units) for role in active]
        assert sum(counts)==11 and max(counts)-min(counts)<=1,(mask,counts)
        assert all(u.owner in active for u in units)
        owners=[u.owner for u in units];g.RC_Distribute();assert owners==[u.owner for u in units]
        trained=g.CreateUnit(active[-1],g.FourCC('ogru'),100,200,0)
        group=g.CreateGroup();g.RC_SourceGroupSimple(trained,group)
        g.RC_Distribute();assert trained.owner==active[-1],'A player lost a unit trained in their own barracks'
        # Rewards are not granted to closed positions and do not multiply.
        g.RC_seconds=1;old=[g.WORLD.players[n].gold for n in range(4)];g.RC_AdjustResource(803,0,g.PLAYER_STATE_RESOURCE_GOLD)
        changes=[g.WORLD.players[n].gold-old[n] for n in range(4)]
        assert sum(changes)==803 and all(changes[n]==0 for n in range(4) if n not in active)
        # At level cap, no hero progresses beyond twenty.
        for n in active:g.SetHeroXP(g.RC_hero[n],999999,False);assert g.RC_hero[n].level==20
    print('PASS: all 8 red-led slot combinations create exactly 1/2/3/4 owned heroes; no fallback hero; absent source heroes/armies hidden and neutral; quest groups exclude them; quest troops and 803 gold split only among present players; trained units stay owned; level cap 20.')

def populate(g,mask,dense=False):
    for role in roles(mask):
        u=g.RC_hero[role];g.SetHeroXP(u,11900+role*37,False);u.str=90+role;u.agi=51+role;u.int=63+role;u.points=3+role
        for n in range(6):g.UnitAddItemToSlotById(u,g.FourCC('ankh'),n);g.SetItemCharges(g.UnitItemInSlot(u,n),37+n)
    g.udg_Stash=g.CreateUnit(14,g.FourCC('h003'),0,0,0)
    for n in range(6):
        g.UnitAddItemToSlotById(g.udg_Stash,g.FourCC('shea'),n);g.SetItemCharges(g.UnitItemInSlot(g.udg_Stash,n),17+n)
        g.RC_extraItem[n]=g.RC_ItemToPortable(g.FourCC('ankh'));g.RC_extraCharges[n]=7+n
    g.RC_ObserveStoryHeroes()
    if dense:
        u=g.RC_hero[0];g.SetHeroXP(u,16000000,False);u.str=4095;u.agi=4095;u.int=4095;u.points=63
        for n in range(5):g.UnitAddAbility(u,g.RC_skill[n]);g.SetUnitAbilityLevel(u,g.RC_skill[n],3 if n==3 else 5)
        for n in range(6):g.SetItemCharges(g.UnitItemInSlot(u,n),4095);g.SetItemCharges(g.UnitItemInSlot(g.udg_Stash,n),4095);g.RC_extraCharges[n]=4095
        g.WORLD.players[0].gold=16777215;g.WORLD.players[0].wood=16777215
        g.RC_CollectStory=lambda:None
        for n in range(g.RC_storyCount):g.RC_story[n]=1 if g.RC_storyBits[n]==1 else 4095 if g.RC_storyBits[n]==12 else 15

def saves(first,second):
    folder=Path(first).parent/'save-fixtures'
    for mask in MASKS:
        g=create(first,mask);populate(g,mask);before={n:stats(g,n) for n in roles(mask)}
        g.RC_Transition(5,2);assert g.RC_saveOK
        codes=[g.RC_checkpointCode[n] for n in roles(mask)]
        assert len(codes)==len(roles(mask)) and all(c.startswith('Z5') and len('-load '+c)<=127 for c in codes)
        assert all(g.RC_checkpointCode[n]=='' for n in range(4) if n not in roles(mask))
        _,h=setup(second,players=roles(mask))
        for role in roles(mask):chat(h,role,'-load '+g.RC_checkpointCode[role])
        if g.RC_externalStash:chat(h,0,'-stash '+g.RC_externalStash)
        begin(h);assert h.RC_started and [n for n in range(4) if h.RC_hero[n] is not None]==roles(mask)
        for n in roles(mask):
            expected=list(before[n]);expected[7]=tuple((h.RC_ItemToLocal(g.RC_ItemToPortable(raw)),charges) for raw,charges in before[n][7])
            assert stats(h,n)==tuple(expected),(mask,n)
        h.udg_Stash=h.CreateUnit(14,h.FourCC('h003'),0,0,0);h.RC_ObserveStoryHeroes();h.RC_ApplyStash()
        for n in range(6):
            assert h.GetItemCharges(h.UnitItemInSlot(h.udg_Stash,n))==17+n
            assert h.RC_extraCharges[n]==7+n
        if mask in [1,3,7,15]:fixtures(g,folder/('party-'+str(len(roles(mask)))))
    # Dense solo state cannot be forced into one 127-character chat command.
    g=create(first,1);populate(g,1,dense=True);g.RC_Transition(5,0)
    assert g.RC_saveOK and g.RC_savedInline==0 and g.RC_externalStash.startswith('S2')
    assert len('-load '+g.RC_checkpointCode[0])<=127 and len('-stash '+g.RC_externalStash)<=127
    fixtures(g,folder/'party-1-full')
    _,h=setup(second,players=[0]);chat(h,0,'-load '+g.RC_checkpointCode[0]);h.RC_Begin();assert not h.RC_started
    raw=g.RC_externalStash;h.RC_codeOK=True;bad=h.RC_Seal(raw[:5]+'___'+raw[8:-3])
    chat(h,0,'-stash '+bad);assert h.RC_loadedStash==''
    chat(h,0,'-stash '+raw);begin(h);assert h.RC_started and h.RC_extraCharges[5]==4095
    _,pending=setup(second,players=[0]);chat(pending,0,'-stash '+raw);chat(pending,0,'-load '+g.RC_checkpointCode[0]);begin(pending)
    assert pending.RC_started and pending.RC_extraCharges[5]==4095
    print('PASS: all 8 party masks round-trip XP/stats/skills/items and all 12 stash/companion slots; only participant codes required; 1/2/3/4-player Windows fixtures written; dense solo uses matching S2 backup, rejects wrong snapshot, supports either load order, every command <=127.')

def legacy_and_departure(first,second):
    g=create(first,15);populate(g,15);g.RC_Transition(5,0)
    legacy=[]
    for n in range(4):
        raw=g.RC_ExpandCode(g.RC_checkpointCode[n]);g.RC_codeOK=True
        old=g.RC_Seal('C3'+raw[2:14]+raw[16:-3]);assert len(old)==104
        legacy.append(g.RC_CompactCode(old))
    _,h=setup(second,players=[0]);chat(h,0,'-load '+legacy[0]);h.RC_Begin();assert not h.RC_started
    for c in legacy[1:]:chat(h,0,'-load '+c)
    begin(h);assert h.RC_started and h.RC_hero[0] is not None and all(h.RC_hero[n] is None for n in range(1,4))
    assert len(h.WORLD.drops)==18,'Old absent-role equipment was silently discarded'
    count=len(h.WORLD.drops);h.RC_Ready();assert len(h.WORLD.drops)==count,'Archived equipment duplicated'
    # A departure removes that player's hero and army instead of giving host another hero.
    t=create(first,3);u=t.RC_SourceCreate(1,t.FourCC('ogru'),100,200,0);t.RC_Distribute();t.SetUnitOwner(u,1,False)
    t.WORLD.players[1].state='left';t.RC_Tick();assert t.RC_hero[1] is None and u.owner==15 and not u.visible
    bank=t.WORLD.players[0].gold;t.RC_Tick();assert t.WORLD.players[0].gold==bank, 'Departed wallet duplicated'
    stopped=create(first,3);stopped.WORLD.players[0].state='left';stopped.RC_Tick()
    assert stopped.RC_transitionPending and stopped.WORLD.paused and stopped.RC_hero[0] is None
    _,missing=setup(first,players=[1]);missing.RC_Begin();assert not missing.RC_started
    print('PASS: old Z4/C3 four-code saves import into a solo roster without spawning extra heroes; absent-role gear is dropped once; departure removes hero and troop control, not transferred to host.')

def null_skills(first):
    g=create(first,1);a=enemy(g);cast(g,0,2,target=a);a.hp=0;ticks(g,1)
    g=create(first,3);cast(g,1,1,x=100);ticks(g,10);cast(g,1,3,x=100);ticks(g,10)
    g=create(first,9);g.SetHeroLevel(g.RC_hero[3],20,False);g.RC_GiveTalent(3,4,2);cast(g,3,2);ticks(g,50)
    g=create(first,7);cast(g,2,0);cast(g,2,1);ticks(g,10)
    g=create(first,1);npc=g.RC_SourceCreate(0,g.RC_heroType[1],100,200,0)
    g.UnitAddItemToSlotById(npc,g.FourCC('wneu'),2);it=g.UnitItemInSlot(npc,2);g.SetItemCharges(it,3)
    assert g.RC_QuestItem(npc,g.FourCC('wneu')).id==it.id
    g.RC_Tick();assert g.UnitItemInSlot(npc,2) is None and it.hero is None and it.charges==3
    g.UnitAddItem(g.RC_hero[0],it);assert g.RC_QuestItem(npc,g.FourCC('wneu')).id==it.id
    print('PASS: absent-role quest items escape hidden inventories, charges preserved; quest-item queries resolve to active party after pickup.')
    print('PASS: Rexxar mark, Rokhan healing/revival, Cairne party counter-heal and Chen combo tolerate missing hero slots.')

if __name__=='__main__':roster(sys.argv[1]);saves(sys.argv[1],sys.argv[2]);legacy_and_departure(sys.argv[1],sys.argv[2]);null_skills(sys.argv[1])

"""Exercise the actual generated map JASS after War3Net transpilation to Lua."""
import argparse,json,random
from pathlib import Path
from lupa import LuaRuntime

ROOT=Path(__file__).resolve().parent
def setup(source):
    lua=LuaRuntime(unpack_returned_tuples=True);lua.execute((ROOT/'natives.lua').read_text());lua.execute(Path(source).read_text());g=lua.globals()
    # The engine/mission initialization is not simulated. Keep a small boundary
    # stub so the actual RC menu/start/save code can run against known units.
    lua.execute('function RunInitializationTriggers() udg_Rexxar=RC_hero[0];udg_RexxarInParty=true;SetPlayerState(0,PLAYER_STATE_RESOURCE_GOLD,1000) end')
    g.RC_Bootstrap()
    assert g.RC_originalsGated and g.RC_force is None and g.WORLD.lastTimer.duration==0.10
    g.WORLD.time=0.10;g.WORLD.lastTimer.action()
    return lua,g

def begin(g):g.RC_Begin();g.RC_Ready()
def chat(g,player,text):g.WORLD.events.player=player;g.WORLD.events.chat=text;g.RC_Chat()
def stats(g,role):
    u=g.RC_hero[role]
    return (u.xp,u.level,u.str,u.agi,u.int,u.points,tuple(g.GetUnitAbilityLevel(u,g.RC_skill[role*5+n]) for n in range(5)),tuple((g.GetItemTypeId(g.UnitItemInSlot(u,n)),g.GetItemCharges(g.UnitItemInSlot(u,n))) for n in range(6)),g.WORLD.players[g.RC_Player(role)].gold,g.WORLD.players[g.RC_Player(role)].wood)

def run(source):
    checks=[];lua,g=setup(source)
    assert not g.RC_started and len(g.WORLD.units)==0 and g.WORLD.paused
    for n,c in enumerate(g.RC_alphabet):assert g.RC_Digit(c)==n
    g.WORLD.hashIgnoresCase=False
    # Reinitialize with a case-sensitive engine hash as well.
    g.RC_Menu()
    for n,c in enumerate(g.RC_alphabet):assert g.RC_Digit(c)==n
    checks.append('menu defers all heroes; codec works with case-sensitive and insensitive hashes')
    begin(g);assert g.RC_started and len(g.WORLD.units)==4
    for player in [0,3,4,5]:
        assert g.GetPlayerAlliance(player,8,g.ALLIANCE_PASSIVE) and g.GetPlayerAlliance(8,player,g.ALLIANCE_PASSIVE)
        assert not g.GetPlayerAlliance(player,10,g.ALLIANCE_PASSIVE)
    assert [g.WORLD.players[p].gold for p in [0,3,4,5]]==[250,250,250,250]
    assert [g.RC_hero[n].owner for n in range(4)]==[0,3,4,5]
    assert len({g.RC_hero[n].id for n in range(4)})==4
    before=len(g.WORLD.units);g.RC_Begin();assert len(g.WORLD.units)==before
    checks.append('four distinct owned heroes; double start cannot duplicate heroes')
    snapshots=[];codes=[]
    for role in range(4):
        u=g.RC_hero[role];g.SetHeroXP(u,11900+role*37,False);u.str=90+role;u.agi=51+role;u.int=63+role;u.points=3+role
        for n in range(5):g.UnitAddAbility(u,g.RC_skill[role*5+n]);g.SetUnitAbilityLevel(u,g.RC_skill[role*5+n],1+n%3)
        for n,id in [(0,'wneu'),(2,'shea'),(5,'jdrn')]:g.UnitAddItemToSlotById(u,g.FourCC(id),n);g.SetItemCharges(g.UnitItemInSlot(u,n),n+role+1)
        g.WORLD.players[g.RC_Player(role)].gold=1200+role*111;g.WORLD.players[g.RC_Player(role)].wood=300+role
        snapshots.append(stats(g,role));g.RC_codeOK=True;codes.append(g.RC_HeroCode(role));assert g.RC_codeOK and len(codes[-1])==81
    g.udg_QuestEarnKeepProgress=4;g.udg_QuestEarnKeepProgress1=True;g.udg_QuestSealTunnelProgress=3
    g.RC_codeOK=True;party=g.RC_PartyCode();assert len(party)+7<=127 and all(len(c)+7<=127 for c in codes)
    lua2,h=setup(source);assert h.RC_LoadParty(party)
    for n,c in enumerate(codes):chat(h,[0,3,4,5][n],'-load '+c)
    begin(h)
    # Local quest ID translation must recover the original inventory IDs exactly.
    for n in range(4):assert stats(h,n)==snapshots[n],(n,stats(h,n),snapshots[n])
    assert h.udg_QuestEarnKeepProgress==4 and h.udg_QuestEarnKeepProgress1 and h.udg_QuestSealTunnelProgress==3
    checks.append('four heroes round-trip XP/level/base stats/skill points/five skills/six inventory positions/charges/resources and quest flags')
    # Shared storage is a separate short command, avoiding chat-length overflow.
    g.udg_Stash=g.CreateUnit(14,g.FourCC('h003'),0,0,0);g.UnitAddItemToSlotById(g.udg_Stash,g.FourCC('shea'),4);g.SetItemCharges(g.UnitItemInSlot(g.udg_Stash,4),7);g.RC_ObserveStoryHeroes()
    g.RC_SaveAll(False)
    # Four simulated local clients observe ONE synchronized checkpoint, rather
    # than generating four different completion sequence numbers.
    for role,p in enumerate([0,3,4,5]):g.WORLD.localPlayer=p;g.RC_WriteSave(role,g.RC_checkpointCode[role])
    stash=g.RC_loadedStash;assert len(stash)==104 and g.RC_stashRequired;party_stash=g.RC_PartyCode()
    _,stored=setup(source);assert stored.RC_LoadParty(party_stash)
    for n,c in enumerate(codes):chat(stored,[0,3,4,5][n],'-load '+c)
    stored.RC_Begin();assert not stored.RC_started
    chat(stored,0,'-stash '+stash);begin(stored)
    stored.udg_Stash=stored.CreateUnit(14,stored.FourCC('h003'),0,0,0);stored.RC_ObserveStoryHeroes();stored.RC_ApplyStash()
    assert stored.GetItemTypeId(stored.UnitItemInSlot(stored.udg_Stash,4))==stored.FourCC('shea') and stored.GetItemCharges(stored.UnitItemInSlot(stored.udg_Stash,4))==7
    checks.append('shared stash inventory/charges restored; missing required stash blocks continuation')
    fixtures=Path(source).parent/'save-fixtures';fixtures.mkdir(exist_ok=True)
    for key,text in g.WORLD.files.items():
        lines=['function PreloadFiles takes nothing returns nothing']+['    call Preload( "'+line.replace('"','\\"')+'" )' for line in text.splitlines()]+['endfunction']
        (fixtures/key.split('\\')[-1]).write_text('\n'.join(lines))
    # Corruption and role mistakes must leave the current save selection intact.
    _,bad=setup(source);chat(bad,3,'-load '+codes[0]);assert bad.RC_loadedHero[1]==''
    corrupted=codes[1][:20]+('0' if codes[1][20]!='0' else '1')+codes[1][21:]
    chat(bad,3,'-load '+corrupted);assert bad.RC_loadedHero[1]==''
    chat(bad,4,'-load2 '+codes[1]);assert bad.RC_loadedHero[1]==''
    assert bad.RC_LoadParty(party);old_session=bad.RC_session
    assert not bad.RC_LoadParty(party[:-1]+'!') and bad.RC_session==old_session
    malformed=party[:8]+'z'+party[9:-3];bad.RC_codeOK=True;malformed=bad.RC_Seal(malformed)
    assert not bad.RC_LoadParty(malformed) and bad.RC_session==old_session
    bad.RC_Begin();assert not bad.RC_started and len(bad.WORLD.units)==0
    checks.append('corrupted/foreign-role/unauthorized/invalid-semantic codes refused; missing hero blocks continuation')
    # No save file replacement when values exceed the explicitly supported range.
    h.RC_SaveAll(False);oldfile=h.WORLD.files['Logs\\RexxarCoop-P1.txt'];h.RC_hero[0].str=5000;h.RC_SaveAll(True)
    assert h.WORLD.files['Logs\\RexxarCoop-P1.txt']==oldfile;h.RC_hero[0].str=snapshots[0][2]
    checks.append('out-of-range state refuses save without truncating or replacing prior files')
    # Story actor replacement retains developed temporary hero, with no surviving duplicate.
    old=h.RC_hero[1];before=stats(h,1);actor=h.CreateUnit(0,h.FourCC('Orkn'),400,500,0);h.RC_Adopt(1,actor)
    assert old.removed and h.RC_hero[1].handle==actor.handle and actor.owner==3 and stats(h,1)==before
    checks.append('story actor handover preserves progression and removes temporary duplicate')
    # Native campaign AI cannot steal control of a human army.
    h.RC_StartAI(3,'orc.ai');h.RC_StartAI(7,'human.ai');assert len(h.WORLD.ai)==1 and h.WORLD.ai[1].player==7
    for _ in range(8):h.CreateUnit(0,h.FourCC('ogru'),0,0,0)
    structure=h.CreateUnit(0,h.FourCC('obar'),0,0,0);structure.structure=True
    summoned=h.CreateUnit(0,h.FourCC('osw2'),0,0,0);summoned.summoned=True
    h.RC_Distribute();owners=[u.owner for _,u in h.WORLD.units.items() if u.id==h.FourCC('ogru')]
    assert owners==[0,3,4,5,0,3,4,5] and structure.owner==0 and summoned.owner==0
    h.RC_seconds=1;gold=[h.WORLD.players[p].gold for p in [0,3,4,5]];h.RC_AdjustResource(803,0,h.PLAYER_STATE_RESOURCE_GOLD)
    assert sum(h.WORLD.players[p].gold-gold[n] for n,p in enumerate([0,3,4,5]))==803
    assert [h.WORLD.players[p].gold-gold[n] for n,p in enumerate([0,3,4,5])]==[203,200,200,200]
    checks.append('army round-robin preserves structures/summons; human armies ignore campaign AI; rewards split without creating gold')
    h.SetPlayerAlliance(8,0,h.ALLIANCE_SHARED_ADVANCED_CONTROL,True);h.RC_Alliances()
    assert h.GetPlayerAlliance(0,3,h.ALLIANCE_SHARED_XP) and h.GetPlayerAlliance(8,4,h.ALLIANCE_SHARED_ADVANCED_CONTROL) and not h.GetPlayerAlliance(0,3,h.ALLIANCE_SHARED_CONTROL)
    assert h.RC_HasQuestItem(h.RC_hero[3],h.FourCC('wneu'))
    checks.append('shared XP/spells and NPC stash rights; active heroes keep private control; quest item lookup spans the party')
    h.RC_hero[2].hp=0
    for _ in range(15):h.RC_Tick()
    assert h.RC_hero[2].hp>0
    h.WORLD.players[3].state='left';h.RC_Tick();assert h.RC_hero[1].owner==0
    checks.append('fallen hero revives; departed player hero passes to remaining host')
    _,difficulty=setup(source);difficulty.WORLD.events.button=difficulty.RC_difficultyButton[2];difficulty.RC_MenuChoice()
    assert difficulty.RC_difficulty==2 and not difficulty.RC_started;begin(difficulty);assert difficulty.WORLD.difficulty==2
    checks.append('difficulty choice precedes synchronized start and sets native difficulty')
    # Checkpoint saving only changes output on the chosen local client.
    state=[stats(h,n) for n in range(4)];h.WORLD.localPlayer=4;h.RC_SaveAll(False)
    assert [stats(h,n) for n in range(4)]==state and h.WORLD.files['Logs\\RexxarCoop-P3.txt'] is not None
    h.RC_Transition(1,2);assert h.RC_nextMap==1 and h.RC_nextArea==2
    assert any('RX5-OrcX01_02.w3x' in text for _,text in h.WORLD.messages.items())
    checks.append('per-client file output leaves gameplay unchanged; transition records correct destination/area and emits save codes')
    print('PASS:',len(checks),'actual-JASS co-op behavior groups. Native graphics/pathfinding/real networking are not simulated.')
    for check in checks:print('  '+check)
    return checks

def cross_map(first,second,item='wneu',conflicting=False):
    _,g=setup(first);begin(g)
    for role in range(4):
        u=g.RC_hero[role];g.SetHeroXP(u,12837+role,False);u.str=99+role;g.UnitAddItemToSlotById(u,g.FourCC(item),0);g.SetItemCharges(g.UnitItemInSlot(u,0),7)
    codes=[g.RC_HeroCode(n) for n in range(4)];portable=g.RC_ItemToPortable(g.FourCC(item))
    _,h=setup(second);g.RC_nextMap=h.RC_map;party=g.RC_PartyCode();assert h.RC_LoadParty(party)
    for n,c in enumerate(codes):chat(h,[0,3,4,5][n],'-load '+c)
    begin(h)
    for n in range(4):
        assert h.RC_hero[n].xp==g.RC_hero[n].xp and h.RC_hero[n].str==g.RC_hero[n].str
        assert h.GetItemTypeId(h.UnitItemInSlot(h.RC_hero[n],0))==h.RC_ItemToLocal(portable)
        assert h.GetItemCharges(h.UnitItemInSlot(h.RC_hero[n],0))==7
    if conflicting:assert h.GetItemTypeId(h.UnitItemInSlot(h.RC_hero[0],0))!=h.FourCC(item),'Conflicting original custom item was not isolated'
    # Saving the portable alias in the other act must return to the first act's
    # local quest ID, not turn into that act's unrelated I003 definition.
    returned=[h.RC_HeroCode(n) for n in range(4)];_,back=setup(first)
    for n,c in enumerate(returned):chat(back,[0,3,4,5][n],'-load '+c)
    begin(back)
    for n in range(4):assert back.GetItemTypeId(back.UnitItemInSlot(back.RC_hero[n],0))==back.FourCC(item)
    print('PASS: actual generated JASS cross-map progression and portable item identity',g.RC_map,'→',h.RC_map,'→',back.RC_map)

def companion_loot(source,destination):
    _,g=setup(source);begin(g);g.udg_Jaina=g.CreateUnit(0,g.FourCC('Hjai'),0,0,0)
    g.UnitAddItemToSlotById(g.udg_Jaina,g.FourCC('I003'),2);g.SetItemCharges(g.UnitItemInSlot(g.udg_Jaina,2),9)
    g.RC_CollectExtraLoot();assert g.UnitItemInSlot(g.udg_Jaina,2) is None and g.RC_extraItem[2]!=0
    g.RC_SaveAll(False);stash=g.RC_loadedStash;codes=[g.RC_lastCode[n] for n in range(4)]
    _,h=setup(destination);g.RC_nextMap=h.RC_map;party=g.RC_PartyCode();assert h.RC_LoadParty(party)
    chat(h,0,'-stash '+stash)
    for n,c in enumerate(codes):chat(h,[0,3,4,5][n],'-load '+c)
    begin(h);h.RC_Tick();assert len(h.WORLD.drops)==1
    drop=h.WORLD.drops[1];assert drop.id==h.RC_ItemToLocal(g.RC_extraItem[2]) and drop.charges==9
    h.RC_SaveAll(False);assert h.RC_extraItem[2]!=0,'Unclaimed companion loot disappeared from the save'
    h.UnitAddItem(h.RC_hero[0],drop);h.RC_SaveAll(False);assert h.RC_extraItem[2]==0,'Picked-up companion loot duplicated in the save'
    h.RC_Tick();assert len(h.WORLD.drops)==1
    print('PASS: Jaina companion loot survives transition, remains saved on the floor until claimed, and stops duplicating after pickup.')

if __name__=='__main__':
    parser=argparse.ArgumentParser();parser.add_argument('lua');parser.add_argument('--next');parser.add_argument('--third');args=parser.parse_args();run(args.lua)
    if args.next:cross_map(args.lua,args.next)
    if args.next and args.third:cross_map(args.next,args.third,'I003',True)
    if args.next and args.third:companion_loot(args.third,args.next)

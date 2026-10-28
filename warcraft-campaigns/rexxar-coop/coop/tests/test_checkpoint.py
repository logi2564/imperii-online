"""Completion-code regressions against actual generated/transpiled mission JASS.

These execute the codec and transition/start handlers, not the native game.
"""
import argparse
from pathlib import Path
from test_runtime import setup,begin,chat,stats

PLAYERS=[0,1,2,3]

def populate(g):
    for role in range(4):
        u=g.RC_hero[role];g.SetHeroXP(u,11900+role*37,False)
        u.str=90+role;u.agi=51+role;u.int=63+role;u.points=3+role
        for n in range(5):g.UnitAddAbility(u,g.RC_skill[role*5+n]);g.SetUnitAbilityLevel(u,g.RC_skill[role*5+n],1+n%3)
        for slot,raw in enumerate(['wneu','shea','jdrn','ankh','ches','afac']):
            g.UnitAddItemToSlotById(u,g.FourCC(raw),slot)
            g.SetItemCharges(g.UnitItemInSlot(u,slot),4095 if slot==5 else slot+role)
        g.WORLD.players[PLAYERS[role]].gold=1200+role*111;g.WORLD.players[PLAYERS[role]].wood=300+role
    g.udg_Stash=g.CreateUnit(14,g.FourCC('h003'),0,0,0)
    for n in range(6):
        g.UnitAddItemToSlotById(g.udg_Stash,g.FourCC('shea'),n)
        g.SetItemCharges(g.UnitItemInSlot(g.udg_Stash,n),n+17)
        g.RC_extraItem[n]=g.RC_ItemToPortable(g.FourCC('ankh'));g.RC_extraCharges[n]=n+7
    g.RC_ObserveStoryHeroes()

def run(first,second):
    _,g=setup(first);begin(g)
    assert all(g.RC_checkpointCode[n]=='' for n in range(4))
    for _ in range(180):g.RC_Tick()
    assert all(g.RC_checkpointCode[n]=='' for n in range(4)),'Unfinished mission emitted automatic completion codes'
    populate(g);before=[stats(g,n) for n in range(4)]
    _,destination=setup(second)
    g.RC_Transition(destination.RC_map,2)
    assert g.RC_saveOK and g.RC_transitionPending and g.WORLD.paused
    codes=[g.RC_checkpointCode[n] for n in range(4)]
    assert all(c.startswith(('Z5','Z6')) and len(g.RC_ExpandCode(c))==106 and len('-load '+c)<=127 for c in codes)
    assert len({g.RC_ExpandCode(c)[3:41] for c in codes})==1
    assert all(c in g.RC_codeQuest[n].description for n,c in enumerate(codes))
    assert all('-load '+c in g.RC_saveQuest.description for c in codes)
    chat(g,0,'-save');g.RC_Transition(destination.RC_map,9)
    assert codes==[g.RC_checkpointCode[n] for n in range(4)],'Completion code changed while players copied it'
    g.WORLD.localPlayer=1;messages=len(g.WORLD.messages);chat(g,1,'-code');assert len(g.WORLD.messages)>messages and '-load '+codes[1] in g.WORLD.messages[len(g.WORLD.messages)]
    _,h=setup(second)
    # Corrupt code, someone else's role, wrong destination: no state mutation.
    chat(h,1,'-load '+codes[0]);assert not h.RC_checkpointLoaded
    chat(h,0,'-load '+codes[0][:-1]+'!');assert not h.RC_checkpointLoaded
    _,wrong=setup(first);chat(wrong,0,'-load '+codes[0]);assert not wrong.RC_checkpointLoaded
    raw=g.RC_ExpandCode(codes[0]);bad=raw[:65]+'__'+raw[67:-3];h.RC_codeOK=True;bad=h.RC_Seal(bad)
    chat(h,0,'-load '+bad);assert not h.RC_checkpointLoaded,'Unknown item index partially committed'
    # The host can enter any role, but all four matching codes are required.
    chat(h,3,'-load '+codes[3]);chat(h,0,'-load '+codes[0]);h.RC_Begin()
    assert not h.RC_started and len(h.WORLD.units)==0
    assert h.RC_checkpointCode[0]==codes[0] and h.RC_checkpointCode[3]==codes[3]
    raw=g.RC_ExpandCode(codes[1]);different=raw[:5]+('002' if raw[5:8]!='002' else '003')+raw[8:-3];h.RC_codeOK=True;different=h.RC_Seal(different)
    chat(h,1,'-load '+different);assert h.RC_checkpointCode[1]==''
    chat(h,0,'-load '+codes[2]);chat(h,1,'-load '+codes[1]);assert h.RC_loadedStash!=''
    # Continuing preserves difficulty even when the initial menu is still open.
    difficulty=h.RC_difficulty;h.WORLD.events.button=h.RC_difficultyButton[(difficulty+1)%3];h.RC_MenuChoice();assert h.RC_difficulty==difficulty
    begin(h)
    for n in range(4):
        actual=stats(h,n)
        expected=list(before[n]);expected[7]=tuple((h.RC_ItemToLocal(g.RC_ItemToPortable(raw)),charges) for raw,charges in before[n][7])
        assert actual==tuple(expected),(n,actual,expected)
    h.udg_Stash=h.CreateUnit(14,h.FourCC('h003'),0,0,0);h.RC_ObserveStoryHeroes();h.RC_ApplyStash()
    for n in range(6):
        assert h.GetItemTypeId(h.UnitItemInSlot(h.udg_Stash,n))==h.RC_ItemToLocal(g.RC_ItemToPortable(g.FourCC('shea')))
        assert h.GetItemCharges(h.UnitItemInSlot(h.udg_Stash,n))==n+17
        assert h.RC_extraItem[n]==g.RC_ItemToPortable(g.FourCC('ankh')) and h.RC_extraCharges[n]==n+7
    assert h.RC_nextArea==2
    loaded=h.RC_checkpointCode[0];chat(h,0,'-load '+codes[0]);assert h.RC_checkpointCode[0]==loaded
    _,reset=setup(second);chat(reset,0,'-load '+codes[0]);chat(reset,1,'-reset');assert reset.RC_checkpointLoaded
    chat(reset,0,'-reset');assert not reset.RC_checkpointLoaded and not reset.RC_partyLoaded and reset.RC_sourceMap==reset.RC_map
    for c in reversed(codes):chat(reset,0,'-load '+c)
    begin(reset);assert reset.RC_started
    # Bit-packed story must preserve the complete supported range and reject
    # overflow instead of emitting a truncated checkpoint.
    for n in range(g.RC_storyCount):
        g.RC_story[n]=1 if g.RC_storyBits[n]==1 else 4095 if g.RC_storyBits[n]==12 else 15
    # The original globals are the source of truth for fields declared here.
    g.RC_CollectStory=lambda:None
    g.RC_codeOK=True;story=g.RC_SmallStory();assert g.RC_codeOK and len(story)==25
    assert g.RC_ReadSmallStory(story)
    assert all(g.RC_tempStory[n]==g.RC_story[n] for n in range(g.RC_storyCount))
    g.RC_story[0]=4096;g.RC_codeOK=True;g.RC_SmallStory();assert not g.RC_codeOK
    # Transition save failure leaves the map playable and the previous files.
    _,failed=setup(first);begin(failed);failed.RC_SaveAll(False)
    oldfile=failed.WORLD.files['Logs\\RexxarCoop-P1.txt'];oldcode=failed.RC_checkpointCode[0]
    failed.RC_hero[0].str=5000;failed.RC_Transition(destination.RC_map,0)
    assert not failed.RC_saveOK and not failed.RC_transitionPending and not failed.WORLD.paused
    assert failed.WORLD.files['Logs\\RexxarCoop-P1.txt']==oldfile and failed.RC_checkpointCode[0]==oldcode
    _,victory=setup(first);begin(victory)
    victory.RC_Victory(0,False,True)
    assert victory.RC_nextMap==5 and victory.RC_saveOK and victory.RC_transitionPending
    once=victory.RC_checkpointCode[0];victory.RC_Victory(0,True,True)
    assert victory.RC_checkpointCode[0]==once,'Duplicate victory replaced the code'
    _,selected=setup(first);begin(selected)
    selected.RC_SetNextLevel('Maps\\FrozenThrone\\Campaign\\OrcX03a.w3x')
    assert selected.RC_nextMap==15 and not selected.RC_transitionPending and selected.RC_checkpointCode[0]==''
    selected.RC_Victory(0,False,False);assert selected.RC_nextMap==15 and selected.RC_saveOK
    print('PASS: Z5 compressed completion checkpoints, C3 with talents and legacy C2-compatible; automatic output at transition; stable/repeatable in-game codes; four-code cross-map XP/stats/skills/full inventories/charges/resources/stash/companion loot; classic chat size; role/map/checkpoint/corruption/unknown-item/missing-code rejection; reset and failed-save recovery; complete packed story range.')

def collision(first,second):
    _,g=setup(first);begin(g)
    for role in range(4):g.UnitAddItemToSlotById(g.RC_hero[role],g.FourCC('I003'),0)
    _,h=setup(second);g.RC_Transition(h.RC_map,0)
    for n in range(4):chat(h,PLAYERS[n],'-load '+g.RC_checkpointCode[n])
    begin(h)
    for n in range(4):assert h.GetItemTypeId(h.UnitItemInSlot(h.RC_hero[n],0))==h.RC_ItemToLocal(g.RC_ItemToPortable(g.FourCC('I003')))!=h.FourCC('I003')
    print('PASS: Z5 codes preserve the real I003 identity collision across generated act-II maps.')

if __name__=='__main__':
    parser=argparse.ArgumentParser();parser.add_argument('first');parser.add_argument('second');parser.add_argument('third');args=parser.parse_args()
    run(args.first,args.second);collision(args.second,args.third)

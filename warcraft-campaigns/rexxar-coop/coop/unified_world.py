"""Stable original-unit slots for the two final-act battlefields.

The generated editor script separates buildings into Create*Buildings functions.
Also retain the six original blockade ships and the final encounter's actors.
Never include the stash: the co-op engine replaces that particular handle.
"""
import hashlib,json,re
from unified_script import FUNCTION

GLOBALS='''
    unit array UW_unit
    integer array UW_count
    integer array UW_chars
    integer array UW_tag
    integer array UW_registered
    boolean array UW_ship
    string UW_snapshot=""
    string UW_decoded=""
    string array UW_loaded
    boolean array UW_resumed
    boolean array UW_ready
'''

CREATE=re.compile(r"(?m)^(\s*set (\w+)\s*=\s*(?:CreateUnit|RC_SourceCreate|UZ_CreateUnit)\(\s*[^,]+,\s*'(.{4})'[^\n]*)")

def layouts(maps):
    result={}
    for name in ('OrcX03a','OrcX03b'):
        m=maps[name];script=m['script'];definitions=m['lookup']['unit']
        def base(raw):
            value=raw.encode();seen=set()
            while value in definitions and value not in seen:
                seen.add(value);parent=definitions[value]['old']
                if parent==value:break
                value=parent
            return value.decode()
        stash=set(re.findall(r'set udg_Stash\s*=\s*(\w+)',script))
        final=set(re.findall(r'GroupAddUnitSimple\(\s*(gg_unit_\w+)\s*,\s*udg_FinalEncounterGroup',script))
        entries=[]
        for f in FUNCTION.finditer(script):
            if not f[1].startswith('Create'):continue
            for ordinal,q in enumerate(CREATE.finditer(f[0])):
                if q[2] in stash:continue
                kind=base(q[3])
                if 'Buildings' in f[1] or kind=='hbsh' or q[2] in final:
                    entries.append(dict(index=len(entries),function=f[1],ordinal=ordinal,variable=q[2],raw=q[3],base=kind,ship=kind=='hbsh'))
        if len(entries)>256:raise ValueError('Final-act world roster exceeds classic slot range')
        signature=json.dumps(entries,sort_keys=True,separators=(',',':')).encode()
        result[m['index']]=dict(name=name,entries=entries,tag=int(hashlib.sha256(signature).hexdigest()[:3],16),chars=4+(len(entries)+5)//6)
    assert sum(e['ship'] for e in result[15]['entries'])==6
    return result

def instrument(code,name,z,layout):
    if layout is None:return code
    chosen={e['ordinal']:e for e in layout['entries'] if e['function']==name}
    matches=list(CREATE.finditer(code))
    for ordinal,q in reversed(list(enumerate(matches))):
        if ordinal in chosen:
            code=code[:q.end()]+f'\n    call UW_Register({q[2]},{z},{chosen[ordinal]["index"]})'+code[q.end():]
    if chosen and not all(n<len(matches) for n in chosen):raise ValueError('Missing original world-unit creation: '+name)
    # Resume through the original skip/cleanup path after it has prepared all
    # scene return locations; never drop an intro halfway through its setup.
    if name=='Trig_Intro_Cinematic_Q_Actions':
        needle=f'    call ConditionalTriggerExecute( Z{z:02}_gg_trg_Intro_Setup )'
        assert needle in code
        code=code.replace(needle,needle+f'\n    if UW_loaded[{z}]!="" then\n        call TriggerExecute(Z{z:02}_gg_trg_Intro_Skipped)\n        return\n    endif')
    if name in ('Trig_Intro_Skipped_Actions','Trig_Intro_Cinematic_Q_Actions'):
        code=re.sub(r'(?m)^(\s*call RC_Cinematic\( false,)',r'    call UW_Restore()\n\1',code)
    if name=='Trig_Gameplay_Actions':
        # Replaying "0 / 6" discovery messages after a resumed battle would
        # contradict the quietly reconstructed journal.
        code=re.sub(r'(?m)^(\s*call QueuedTriggerAddBJ\( Z\d+_gg_trg_Quest_\w+_Discover(?:ed)?_Q, true \))',r'    if not UW_resumed[RC_map] then\n\1\n    endif',code)
    if name=='Trig_Init_02_Units_Actions':
        code=code.replace('\nendfunction',f'\n    set UW_ready[{z}]=true\nendfunction')
    if z==15 and name=='Trig_Create_Battleship_Leaderboard_Actions':
        code=code.replace('\nendfunction','\n    if UW_resumed[15] then\n        call UW_ShipJournal()\n    endif\nendfunction')
    return code

def initialization(layouts):
    lines=[]
    for z,layout in layouts.items():
        lines += [f'    set UW_loaded[{z}]=""',f'    set UW_count[{z}]={len(layout["entries"])}',f'    set UW_chars[{z}]={layout["chars"]}',f'    set UW_tag[{z}]={layout["tag"]}']
        lines += [f'    set UW_ship[{z*256+e["index"]}]=true' for e in layout['entries'] if e['ship']]
    return lines

def adapt_runtime(runtime):
    # Existing C2/C3/C4 and Z3..Z6 remain byte-for-byte compatible inside W1.
    runtime=runtime.replace('    set text = RC_ExpandCode(text)','    set text = UW_Unwrap(text)\n    set text = RC_ExpandCode(text)')
    marker='    local string common\n'
    assert marker in runtime
    runtime=runtime.replace(marker,marker+'    local string world\n',1)
    marker='    set text = UW_Unwrap(text)\n    set text = RC_ExpandCode(text)\n    if not RC_CheckpointValid(text)'
    assert marker in runtime
    runtime=runtime.replace(marker,'    set text = UW_Unwrap(text)\n    set world = UW_decoded\n    set text = RC_ExpandCode(text)\n    if not RC_CheckpointValid(text)',1)
    runtime=runtime.replace('    set common = SubString(text, 3, storyStart + RC_storyChars)','    set common = SubString(text, 3, storyStart + RC_storyChars) + world')
    runtime=runtime.replace('    // Only commit after every field/checksum/catalog index has been validated.', '    // Only commit after every field/checksum/catalog index has been validated.\n    if world=="" and RC_Number(SubString(text,9,10))>=15 and RC_loadedGroup=="" then\n        call RC_Say("Это старый код: герои и вещи восстановятся, но состояние битвы в нём не записано. Область начнётся заново.")\n    endif')
    runtime=runtime.replace('    set RC_checkpointCode[role] = RC_CompactCode(text)','    set UW_loaded[RC_map] = world\n    set RC_checkpointCode[role] = UW_Wrap(RC_CompactCode(text),world)')
    # The party encoder has this exact return; the legacy encoder also can
    # use it harmlessly because its snapshot is empty outside atlas saves.
    runtime=runtime.replace('    return RC_CompactCode(RC_Seal(text))','    return UW_Wrap(RC_CompactCode(RC_Seal(text)),UW_snapshot)')
    runtime=runtime.replace('    call RC_ObserveStoryHeroes()\n    // Manual saves', '    set UW_snapshot=UW_Capture()\n    if not RC_codeOK then\n        call RC_Say("Сохранение отложено: локация ещё не готова. Предыдущее сохранение сохранено.")\n        return\n    endif\n    call RC_ObserveStoryHeroes()\n    // Manual saves')
    runtime=runtime.replace('    set UW_snapshot=UW_Capture()', '    set RC_codeOK=true\n    set UW_snapshot=UW_Capture()')
    # Manual saves wait for a stable scene; original victory callbacks still
    # must save successfully while their ending cinematic is active.
    runtime=runtime.replace('    elseif text == "-save" and RC_started and not RC_transitionPending then\n        call RC_SaveAll(true)', '    elseif text == "-save" and RC_started and not RC_transitionPending then\n        if RC_StoryCinematic() then\n            call RC_Tell(p,8,"Сохранение доступно после окончания сцены. Предыдущее сохранение сохранено.")\n        else\n            call RC_SaveAll(true)\n        endif')
    runtime=runtime.replace('    set RC_savedMask = 15\n', '    set UW_loaded[15]=""\n    set UW_loaded[16]=""\n    set UW_snapshot=""\n    set RC_savedMask = 15\n')
    runtime=runtime.replace('or SubString(payload, 0, 2) == "Z6")','or SubString(payload, 0, 2) == "Z6" or SubString(payload, 0, 2) == "W1")')
    return runtime

"""Shared runtime and namespaced ORIGINAL campaign scripts for the atlas."""
import json,re
from pathlib import Path
from build import ROOT,MAPS,globals_text,initialization,classic_strings,function,calls,hooks,transform,coop_info,player_remap,read_info
from unified_script import FUNCTION,source_parts,namespace,localize,relocate,arguments
from trigger_strings import resolve_string

GLOBALS='''
    integer UM_hostColor=0
    hashtable UZ_state = null
    hashtable UZ_cache = null
    boolean UZ_entering = false
    boolean array UZ_initialized
    boolean array UZ_live
    integer array UZ_generation
    group array UZ_units
    group UZ_travelParty = null
    integer array UZ_timerCount
    integer array UZ_triggerCount
    integer array UZ_questCount
    integer array UZ_itemCount
    integer array UZ_classPlayer
    integer array UZ_playerClass
    rect array UZ_bounds
    real array UZ_startX
    real array UZ_startY
    real UZ_arrivalX = 0
    real UZ_arrivalY = 0
    integer UZ_target = 0
    integer UZ_area = 0
    real UZ_portalReadyAt = 0
    timer UZ_transitionClock = null
    timer UZ_arrivalClock = null
    timer UZ_aiClock = null
    unit array UZ_aiRally
    integer UZ_aiOwner=0
    integer UZ_aiTicks = 0
    boolean UZ_pauseFlag = false
    unit UZ_stash = null
    group UZ_aiScratch = null
'''

def add_after_locals(code,statement):
    lines=code.splitlines();pos=1
    while pos<len(lines)-1 and (not lines[pos].strip() or lines[pos].lstrip().startswith('//') or lines[pos].lstrip().startswith('local ')):pos+=1
    lines.insert(pos,statement)
    return '\n'.join(lines)

def scoped_calls(code,z):
    names={'TriggerRegisterTimerEventSingle':('UZ_TimerSingle',2),'TriggerRegisterTimerEventPeriodic':('UZ_TimerPeriodic',2),'TimerStart':('UZ_TimerStart',4)}
    # Parse spans against a masked source, preserving strings and nested calls.
    from build import mask
    masked=mask(code);edits=[]
    for m in re.finditer(r'\b([A-Za-z_]\w*)\s*\(',masked):
        if m[1] in names:
            new,count=names[m[1]];args=arguments(masked,m.end()-1)
            assert len(args)==count,(m[1],args)
            edits.extend([(m.start(1),m.end(1),new),(args[-1][1],args[-1][1],', '+str(z))])
    for a,b,v in sorted(edits,reverse=True):code=code[:a]+v+code[b:]
    return calls(code,{'CreateTrigger':'UZ_CreateTrigger','DestroyTrigger':'UZ_DestroyTrigger','SaveGameExists':'UZ_SaveGameExists','CopySaveGameBJ':'UZ_CopySave','TriggerRegisterGameSavedEventBJ':'UZ_SavedEvent','SetCampaignMenuRaceBJ':'UZ_CampaignRace','SetMissionAvailable':'UZ_MissionAvailable','PauseTimer':'UZ_PauseTimer','ResumeTimer':'UZ_ResumeTimer','DestroyTimer':'UZ_DestroyTimer','PauseAllUnitsBJ':'UZ_PauseCurrent','DestroyQuest':'UZ_DestroyQuest','CreateQuest':'UZ_CreateQuest','CreateQuestBJ':'UZ_CreateQuestBJ','StoreUnit':'UZ_StoreUnit','StoreUnitBJ':'UZ_StoreUnitBJ','HaveStoredUnit':'UZ_HaveStoredUnit','SetHeroLevel':'UZ_SetHeroLevel'})

def build_zones(maps,terrains,catalog,schema):
    outputs=[];late=[];zone_parts={};perzone_hooks={};reports=[]
    for t in terrains:
        m=maps[t.name];z=m['index'];prefix=f'Z{z:02}_';remap=player_remap(m['script'],m['name'])
        info,players=coop_info(m['data']['war3map.w3i'],remap,[0,1,2,3])
        from build import apply_player_remap
        generated=transform(apply_player_remap(m['script'],remap),m,schema,catalog,players,remap,(ROOT/'runtime/core.j').read_text(),read_info(info)['forces'])
        part=source_parts(m['script'],generated,m['strings'],catalog.raw_maps[t.name],t,z);zone_parts[z]=part
        # Original config is not run inside the atlas. Preserve its actual
        # alliance BJ calls separately from lobby/team/start-position setup.
        team_fn=next((x[0] for x in FUNCTION.finditer(m['script']) if x[1]=='InitCustomTeams'),'')
        alliance_lines=[line for line in team_fn.splitlines() if re.match(r'\s*call SetPlayerAlliance\w*\(',line)]
        alliance_body=apply_player_remap('\n'.join(alliance_lines),remap)
        late.append(f'function UZ_DiplomacyZ{z:02} takes nothing returns nothing\n'+alliance_body+'\nendfunction')
        source_info=read_info(m['data']['war3map.w3i'])
        factions={remap.get(p['id'],p['id']):resolve_string(p['name'],m['strings']).decode() for p in source_info['players'] if p['id']!=0}
        name_lines=[f'    call SetPlayerName(Player({n}),'+json.dumps(factions.get(n,'Нейтральная фракция'),ensure_ascii=False)+')' for n in range(4,12)]
        late.append(f'function UZ_NamesZ{z:02} takes nothing returns nothing\n'+'\n'.join(name_lines)+'\nendfunction')
        source=part['functions'];triggers=re.findall(r'\btrigger\s+(Z\d+_gg_trg_\w+)\s*=',part['globals'])
        guard_count=0
        for name,code in source.items():
            code=scoped_calls(code,z)
            target=re.search(r'set '+prefix+r'udg_TransitionTarget\s*=\s*(\d+)',code)
            area=re.search(r'set '+prefix+r'udg_TransitionTargetArea\s*=\s*(\d+)',code)
            if name.startswith('Trig_Zone_to_') and name.endswith('_Actions') and target and area:
                # Vanilla portal actions disable their periodic trigger and
                # sleep across ChangeLevel. A persistent atlas must not retain
                # that disabled trigger when the party later comes back.
                dest=(0 if z<5 else 5)+int(target[1])-1
                code=code.split('\n',1)[0]+f'\n    call RC_Transition({dest},{int(area[1])})\nendfunction'
            # Only outgoing target assignments are guarded. Import_All reads
            # TransitionTargetArea WHILE entry is pending; blocking that read
            # skips mission imports and the correct arrival point entirely.
            if name.endswith('_Actions') and re.search(r'\bset '+prefix+r'udg_TransitionTarget\s*=',code):
                code=add_after_locals(code,'    if not RC_started or RC_transitionPending or TimerGetElapsed(RC_menuClock)<UZ_portalReadyAt then\n        return\n    endif')
            if re.search(r'\b(?:TriggerSleepAction|PolledWait|TriggerWaitForSound|TransmissionFromUnitWithNameBJ|TransmissionFromUnitBJ)\s*\(',code):
                ret=re.search(r'\breturns (\w+)',code)[1]
                code=code.replace('\n','\n    local integer UZ_stamp=UZ_generation['+str(z)+']\n',1)
                end_return='' if ret=='nothing' else (' false' if ret=='boolean' else ' 0' if ret in ['integer','real'] else ' null')
                # Generated source calls are line-based. Return guards follow
                # every blocking native/BJ; stale scenes cannot move the party.
                code=re.sub(r'(?m)^(\s*call (?:TriggerSleepAction|PolledWait|TriggerWaitForSound|TransmissionFromUnitWithNameBJ|TransmissionFromUnitBJ)\([^\n]*\))',lambda q:q[0]+f'\n    if RC_map!={z} or UZ_generation[{z}]!=UZ_stamp then\n        return{end_return}\n    endif',code)
                guard_count+=1
            outputs.append(code)
        # Reuse the released original story field/flag and diplomacy hooks;
        # remove one-map timer gating and item aliases in favour of atlas state.
        hs=hooks(m,schema);hook_names={x[1] for x in FUNCTION.finditer(hs)}
        hs=namespace(relocate(localize(hs,m['strings'],catalog.raw_maps[t.name]),*t.offset),part['names']|hook_names,prefix)
        hfunc={x[1]:x[0] for x in FUNCTION.finditer(hs)}
        keep=[]
        for name,code in hfunc.items():
            if any(token in name for token in ['DisableOriginal','EnableOriginal']):continue
            if name.endswith('RC_ObserveStoryHeroes'):
                lines=[f'function {name} takes nothing returns nothing']
                for role,hero in enumerate(['Rexxar','Rokhan','Chen','Cairne']):
                    if f'{prefix}udg_{hero}' in part['names'] or 'udg_'+hero in part['names']:
                        lines.extend([f'    if RC_Active({role}) then',f'        if {prefix}udg_{hero}!=null and {prefix}udg_{hero}!=RC_hero[{role}] then',f'            call RC_SuppressUnit({prefix}udg_{hero})','        endif',f'        set {prefix}udg_{hero}=RC_hero[{role}]','    else',f'        set {prefix}udg_{hero}=RC_EnsureAbsent({role})','    endif'])
                if 'udg_Stash' in part['names']:lines.append(f'    set {prefix}udg_Stash=UZ_BindStash({prefix}udg_Stash)')
                code='\n'.join(lines+['endfunction'])
            if name.endswith('RC_CollectExtraLoot'):
                # A travel retains the actual companion and items. Manual
                # checkpoint snapshots may inspect them without deleting loot.
                code=code.replace('            call RemoveItem(it)','')
            keep.append(code)
        perzone_hooks[z]=keep
        # Initialization order from the generated original main, without its
        # second InitBlizzard or one-map co-op bootstrap/config.
        body=part['main'].split('\n',1)[1].rsplit('endfunction',1)[0]
        init_lines=[];environment=[]
        for line in body.splitlines():
            if not line.strip() or 'InitBlizzard(' in line or 'RC_Bootstrap(' in line:continue
            if re.search(r'call\s+'+prefix+r'(?:InitSounds|CreateRegions|CreateCameras|InitTechTree|CreateAllDestructables|CreateAllItems|CreateAllUnits|InitGlobals|InitCustomTriggers)\s*\(',line):init_lines.append(line)
            else:environment.append(line)
        registered=[f'    call UZ_RegisterTrigger({trg},{z})' for trg in triggers]
        # Keep large initializers below the classic VM operation budget by
        # splitting registration into bounded independent ExecuteFunc calls.
        names=[]
        for start in range(0,len(registered),100):
            fn=f'UZ_RegisterZ{z:02}_{start//100}';names.append(fn);late.append('\n'.join([f'function {fn} takes nothing returns nothing']+registered[start:start+100]+['endfunction']))
        late.append('\n'.join([f'function UZ_InitZ{z:02} takes nothing returns nothing']+[re.sub(r'call (\w+)\s*\(\s*\)',r'call ExecuteFunc("\1")',line) for line in init_lines]+[f'    call ExecuteFunc("{n}")' for n in names]+[f'    set UZ_initialized[{z}]=true','endfunction']))
        late.append('\n'.join([f'function UZ_EnvironmentZ{z:02} takes nothing returns nothing']+environment+['endfunction']))
        import_fn=prefix+'Trig_Import_All_Actions' if 'Trig_Import_All_Actions' in source else None
        resume_fn=prefix+'Trig_Resume_Game_Actions' if 'Trig_Resume_Game_Actions' in source else None
        exports=[prefix+'Trig_Export_Mission_Data_Actions'] if 'Trig_Export_Mission_Data_Actions' in source else []
        late.append('\n'.join([f'function UZ_ExportZ{z:02} takes nothing returns nothing']+[f'    call {f}()' for f in exports]+['endfunction']))
        returning=[f'    call {f}()' for f in [import_fn,resume_fn] if f]
        late.append('\n'.join([f'function UZ_ReturnZ{z:02} takes nothing returns nothing']+returning+['endfunction']))
        reports.append(dict(zone=t.name,index=z,sourceFunctions=len(source),triggers=len(triggers),staleSleepGuards=guard_count,returnImport=import_fn,returnResume=resume_fn))
    return zone_parts,'\n\n'.join(outputs),perzone_hooks,'\n\n'.join(late),reports

def dispatch_hooks(zone_parts,perzone_hooks,catalog):
    result=[]
    for codes in perzone_hooks.values():result.extend(codes)
    for fn in ['RC_InitialAlliances','RC_CollectStory','RC_ApplyStory','RC_SeedStory','RC_ObserveStoryHeroes','RC_CollectExtraLoot']:
        lines=[f'function {fn} takes nothing returns nothing']
        for z in range(17):lines += [('    if' if z==0 else '    elseif')+f' RC_map=={z} then',f'        call Z{z:02}_{fn}()']
        result.append('\n'.join(lines+['    endif','endfunction']))
    lines=['function RC_StoryCinematic takes nothing returns boolean']
    for z,part in zone_parts.items():
        if 'udg_InCinematic' in part['names']:lines += [f'    if RC_map=={z} then',f'        return Z{z:02}_udg_InCinematic','    endif']
    result.append('\n'.join(lines+['    return RC_cinematicMode','endfunction']))
    result += ['function RC_DisableOriginals takes nothing returns nothing\n    call UZ_GateZone(RC_map,false)\nendfunction','function RC_EnableOriginals takes nothing returns nothing\n    call UZ_GateZone(RC_map,true)\nendfunction']
    return '\n\n'.join(result)

def replace_fn(script,name,body):
    pattern=r'(?m)^(function '+re.escape(name)+r' takes[^\n]*\n)[\s\S]*?^endfunction\b'
    script,count=re.subn(pattern,lambda m:m[1]+body+'\nendfunction',script)
    if count!=1:raise ValueError('Expected shared function '+name)
    return script

def shared_runtime(m0,catalog,schema,parts,hooks_code):
    runtime=(ROOT/'runtime/core.j').read_text()
    replacements={'// @@GLOBALS@@':'','// @@ITEMS@@':catalog.unified_hooks(),'// @@HOOKS@@':hooks_code,'// @@INIT@@':initialization(m0)}
    for marker,file in [('PARTY','party'),('PROGRESS_BASE','progress-base'),('PROGRESS_MENUS','progress-menus'),('EXPERIENCE','experience'),('SKILLS','skills'),('BALANCE','balance'),('CHECKPOINT','checkpoint'),('PARTY_CHECKPOINT','checkpoint-party')]:replacements['// @@'+marker+'@@']=(ROOT/'runtime'/f'{file}.j').read_text()
    for marker,value in replacements.items():runtime=runtime.replace(marker,value)
    runtime=replace_fn(runtime,'RC_Player','    if role<0 or role>=4 or UZ_classPlayer[role]<0 then\n        return Player(15)\n    endif\n    return Player(UZ_classPlayer[role])')
    runtime=replace_fn(runtime,'RC_Role','    local integer id=GetPlayerId(p)\n    if p==null or id<0 or id>=4 then\n        return -1\n    endif\n    return UZ_playerClass[id]')
    runtime=replace_fn(runtime,'RC_IsPartyPlayer','    return p!=null and GetPlayerId(p)>=0 and GetPlayerId(p)<4')
    runtime=replace_fn(runtime,'RC_Transition','    call UZ_RequestTransition(target,area)')
    runtime=replace_fn(runtime,'RC_StartAI','    call UZ_StartAI(p,script)')
    runtime=runtime.replace('local unit u = CreateUnit(p, id, x, y, facing)','local unit u = UZ_CreateUnit(p, id, x, y, facing)')
    runtime=runtime.replace('        call RC_CheckSourceUnit(u)\n        if RC_started then','        call UZ_TrackUnit(u)\n        call RC_CheckSourceUnit(u)\n        if RC_started then')
    runtime=runtime.replace('    return RestoreUnitLocFacingAngleBJ(key, mission, cache, owner, point, facing)','    return UZ_RestoreCached(key,mission,cache,owner,point,facing)')
    # Preserve cache-backed nonparty story actors across original RemoveUnit.
    code=next(m[0] for m in FUNCTION.finditer(runtime) if m[1]=='RC_SourceRemove')
    runtime=runtime.replace(code,add_after_locals(code,'    if UZ_ProtectCached(u) then\n        return\n    endif'))
    runtime=replace_fn(runtime,'RC_Adopt','    if hero!=null and hero!=RC_hero[role] then\n        call RC_SuppressUnit(hero)\n    endif')
    runtime=runtime.replace('return RK_Alive(u) and not LoadBoolean','return UZ_ActiveUnit(u) and RK_Alive(u) and not LoadBoolean')
    # Global menu/event setup runs once. Remove the one-map start dialog.
    start=runtime.index('    set RC_menu = DialogCreate()');end=runtime.index('    set chat = null',start)
    runtime=runtime[:start]+'    call ExecuteFunc("UM_Open")\n'+runtime[end:]
    runtime=runtime.replace('        call ForceAddPlayer(RC_force, RC_Player(n))','        if RC_Active(n) then\n            call ForceAddPlayer(RC_force,RC_Player(n))\n        endif')
    # Startup is dispatched after all shared allocations; no zone exists yet.
    runtime=replace_fn(runtime,'RC_Bootstrap','    call ExecuteFunc("UZ_Bootstrap")')
    begin='''    local integer n=0
    if RC_started then
        return
    endif
    if not RC_Active(0) then
        call RC_Say("В отряде нужен Рексар. Один игрок выберите его перед стартом.")
        return
    endif
    set RC_liveMask=RC_CurrentMask()
    if RC_partyLoaded then
        loop
            exitwhen n==4
            if RC_InMask(n,RC_savedMask) and RC_checkpointCode[n]=="" then
                call RC_Say("Для продолжения не хватает кода героя "+I2S(n+1)+". Введи -load КОД.")
                return
            endif
            set n=n+1
        endloop
    endif
    set RC_started=true
    call ExecuteFunc("UM_Close")
    set n=0
    loop
        exitwhen n==4
        if RC_Active(n) then
            set RC_hero[n]=CreateUnit(RC_Owner(n),RC_heroType[n],UZ_startX[RC_map]+n*90,UZ_startY[RC_map],0)
            call SetHeroLevel(RC_hero[n],RC_defaultLevel,false)
            call RC_InstallProgress(RC_hero[n])
            call RC_ClearOldSkills(RC_hero[n],n)
            if RC_loadedHero[n]!="" then
                call RC_ApplyHero(n,RC_loadedHero[n])
            endif
        endif
        set n=n+1
    endloop
    call ExecuteFunc("UZ_StartCampaign")'''
    runtime=replace_fn(runtime,'RC_Begin',begin)
    # Source cache/diplomacy routines are in-memory. F9 no longer says rehost.
    runtime=runtime.replace('В следующей карте каждому -load КОД, затем ведущему -start.','Локации меняются внутри партии. Для новой сессии выбери героя и введи его -load КОД.')
    # Every source show/hide is tracked; freezing an inactive region does not
    # overwrite its desired story visibility.
    runtime=calls(runtime,{'ShowUnit':'UZ_ShowUnit'})
    runtime=runtime.replace('if IsPlayerInForce(Player(0), players) then','if players==RC_force or IsPlayerInForce(Player(0), players) then')
    runtime=runtime.replace("if GetUnitAbilityLevel(u, 'Aloc') == 0 and RK_Alive(u)","if UZ_ActiveUnit(u) and GetUnitAbilityLevel(u, 'Aloc') == 0 and RK_Alive(u)")
    runtime=runtime.replace('if ownerRole < 0 then\n        return\n    endif','if not RC_IsPartyPlayer(GetOwningPlayer(u)) then\n        return\n    endif')
    runtime=runtime.replace('elseif not RC_Active(ownerRole) then\n        call RC_SuppressUnit(u)','elseif ownerRole<0 or not RC_Active(ownerRole) then\n        call SetUnitOwner(u,RC_Player(RC_host),true)')
    # A completed checkpoint may resume any of the seventeen atlas regions.
    runtime=runtime.replace('RC_Number(SubString(text, 9, 10)) != RC_map','(RC_Number(SubString(text, 9, 10))>16 or (RC_checkpointLoaded and RC_Number(SubString(text,9,10))!=RC_map))')
    runtime=runtime.replace('    set RC_loadedGroup = common','    set RC_map=RC_Number(SubString(text,9,10))\n    set RC_defaultLevel=2\n    if RC_map>=15 then\n        set RC_defaultLevel=12\n    elseif RC_map>=5 then\n        set RC_defaultLevel=8\n    endif\n    set RC_loadedGroup = common')
    runtime=runtime.replace('Этот код предназначен для другой карты или версии. Откройте указанную при завершении миссию.','Код содержит неверную локацию/сложность либо не совпадает с уже загруженным сохранением.')
    return runtime

def order_functions(script):
    """Classic JASS requires every direct function reference declared first."""
    functions={m[1]:m[0] for m in FUNCTION.finditer(script)}
    from build import mask
    deps={name:{v for v in re.findall(r'\b([A-Za-z_]\w*)\s*\(|\bfunction\s+([A-Za-z_]\w*)',mask(code.split('\n',1)[1])) for v in v if v in functions and v!=name} for name,code in functions.items()}
    done=set();active=[];ordered=[]
    def visit(name):
        if name in done:return
        if name in active:raise ValueError('Direct JASS cycle: '+' -> '.join(active+[name]))
        active.append(name)
        for dep in sorted(deps[name]):visit(dep)
        active.pop();done.add(name);ordered.append(functions[name])
    for name in functions:visit(name)
    return '\n\n'.join(ordered)

def assemble(maps,terrains,catalog,schema):
    import unified_menu
    parts,source,hooks_per_zone,late,reports=build_zones(maps,terrains,catalog,schema)
    shared=shared_runtime(maps[MAPS[0]],catalog,schema,parts,dispatch_hooks(parts,hooks_per_zone,catalog))
    # Menus use canonical class indices and register against real color handles.
    shared=shared.replace('call TriggerRegisterPlayerChatEvent(chat, RC_Player(n),','call TriggerRegisterPlayerChatEvent(chat, Player(n),').replace('call TriggerRegisterPlayerUnitEvent(spells, RC_Player(n),','call TriggerRegisterPlayerUnitEvent(spells, Player(n),')
    shared=shared.replace('            call GroupEnumUnitsOfPlayer(RC_scratch, RC_Player(n), null)','            call GroupClear(RC_scratch)\n            if RC_Active(n) then\n                call GroupEnumUnitsOfPlayer(RC_scratch, RC_Player(n), null)\n            endif')
    shared=shared.replace('        call GroupEnumUnitsOfPlayer(RC_army, RC_Player(role), null)','        call GroupClear(RC_army)\n        if RC_Active(role) then\n            call GroupEnumUnitsOfPlayer(RC_army,RC_Player(role),null)\n        endif')
    shared=replace_fn(shared,'RC_SourceCreateAtLoc','''    local integer n=0
    set bj_lastCreatedGroup=CreateGroup()
    loop
        exitwhen n>=count
        set bj_lastCreatedUnit=RC_SourceCreate(p,id,GetLocationX(point),GetLocationY(point),facing)
        call GroupAddUnit(bj_lastCreatedGroup,bj_lastCreatedUnit)
        set n=n+1
    endloop
    return bj_lastCreatedGroup''')
    # Keep original preflight validation for inventory/save consistency.
    checks=next(m[0] for m in FUNCTION.finditer((ROOT/'runtime/core.j').read_text()) if m[1]=='RC_Begin')
    checks=checks[checks.index('    if RC_pendingStash'):checks.index('    set RC_started = true')]
    shared=shared.replace('    set RC_started=true\n    call ExecuteFunc("UM_Close")',checks+'\n    set RC_started=true\n    call SetGameDifficulty(RC_GetDifficulty())\n    call ExecuteFunc("UM_Close")')
    shared=shared.replace('if RC_IsPartyPlayer(p) and not RC_Active(RC_Role(p)) then','if p!=Player(0) and RC_IsPartyPlayer(p) and not RC_Active(RC_Role(p)) then')
    # Current-map manual snapshots, not external-map transition instructions.
    shared=shared.replace('local string description = "Следующая карта: " + RC_filePrefix + RC_mapName[RC_nextMap] + ".w3x.|nКоды нужны только для состава сохранения.|n"','local string description = "Продолжение в этой же карте. Выбери своего героя, затем -load КОД. Коды одного сохранения:|n"')
    shared=shared.replace('Следующая карта: " + RC_filePrefix + RC_mapName[RC_nextMap] + ".w3x. В ней введи:', 'Продолжение в этой же карте. Выбери героя и введи:')
    shared=shared.replace('После завершения миссии или перехода каждый получит ОДИН код. В следующей карте каждый вводит -load СВОЙ_КОД, затем ведущий -start. Сюжет и тайник уже включены. Здесь появятся коды героев, участвовавших в сохранении.','Переходы между областями работают в этой партии. Для новой игровой сессии: -save, затем в этой же карте выбери своего героя и введи -load СВОЙ_КОД. Все коды должны быть от одного сохранения.')
    shared=shared.replace('В следующей карте каждому -load КОД, затем ведущему -start.','Для новой сессии в этой же карте: выбрать героя, -load КОД, затем готовность V.')
    # Death, balancing and native source HP/XP helpers are confined to the active region.
    shared=shared.replace('if not RC_started or RC_transitionPending or RC_StoryCinematic() or killer == null or dead == null then','if not RC_started or RC_transitionPending or RC_StoryCinematic() or killer == null or dead == null or not UZ_ActiveUnit(dead) then')
    shared=shared.replace('if p == Player(0) and RC_seconds > 0 and gain > 0','if p == Player(0) and not UZ_entering and RC_seconds > 0 and gain > 0')
    shared=shared.replace('call PauseAllUnitsBJ(', 'call UZ_PauseCurrent(')
    shared=shared.replace('            call TriggerRegisterPlayerUnitEvent(t, RC_Player(n), e, filter)','            if RC_Active(n) then\n                call TriggerRegisterPlayerUnitEvent(t,RC_Player(n),e,filter)\n            endif')
    shared=shared.replace('            call TriggerRegisterPlayerEventEndCinematic(t, RC_Player(n))','            if RC_Active(n) then\n                call TriggerRegisterPlayerEventEndCinematic(t,RC_Player(n))\n            endif')
    source_resource=next(m[0] for m in FUNCTION.finditer(shared) if m[1]=='RC_Resource')
    shared=shared.replace(source_resource,add_after_locals(source_resource,'    if UZ_entering and RC_ready and (state==PLAYER_STATE_RESOURCE_GOLD or state==PLAYER_STATE_RESOURCE_LUMBER) then\n        return\n    endif'))
    shared=shared.replace('        call CinematicModeBJ(enabled, RC_force)','''        call CinematicModeBJ(enabled, RC_force)
        if not enabled and RC_started then
            set n=0
            loop
                exitwhen n==4
                if RC_Active(n) and RC_hero[n]!=null then
                    call UZ_ShowUnit(RC_hero[n],true)
                    call PauseUnit(RC_hero[n],false)
                    call SetUnitInvulnerable(RC_hero[n],false)
                    call SetUnitOwner(RC_hero[n],RC_Player(n),true)
                endif
                set n=n+1
            endloop
        endif''')
    shared=shared.replace('Rexxar co-op VI. Enter this one command in the next mission, before -start:','Rexxar VII. In this same map select your hero, enter this command before ready:')
    shared=shared.replace('REXXAR VI FIX','REXXAR VII TEST')
    shared=shared.replace('Красный игрок вышел. Для сюжета нужен Рексар: пересоздайте лобби с красным игроком и последними кодами. Файлы сохранения не перезаписаны.','Игрок с Рексаром вышел. Для сюжета нужен Рексар: создайте новую сессию этой карты и загрузите последние коды. Файлы сохранения не перезаписаны.')
    shared=shared.replace('"Следующая карта: " + RC_filePrefix + RC_mapName[RC_nextMap] + ".w3x.|n-load "','"Эта же карта: выбрать героя, затем -load "')
    shared=shared.replace('"|nПосле кодов состава сохранения: -start."','"|nПосле кодов состава сохранения: готовность V."')
    shared=shared.replace('"|cffffcc00" + RC_filePrefix + RC_mapName[RC_nextMap] + ".w3x|r → -load "','"Продолжение в этой же карте: -load "')
    shared=shared.replace('"Next map: " + RC_mapName[RC_nextMap]','"Location in the same W3X: " + RC_mapName[RC_nextMap]')
    # Keep explicit save destinations coherent for -save in a unified region.
    code=next(m[0] for m in FUNCTION.finditer(shared) if m[1]=='RC_SaveAll')
    shared=shared.replace(code,add_after_locals(code,'    set RC_nextMap=RC_map\n    set RC_nextArea=0'))
    geometry=['function UZ_InitGeometry takes nothing returns nothing']
    for t in terrains:
        m=maps[t.name];z=m['index'];dx,dy=t.offset
        info=read_info(m['data']['war3map.w3i']);host=next(p for p in info['players'] if p['id']==0)
        geometry += [f'    set UZ_units[{z}]=CreateGroup()',f'    set UZ_bounds[{z}]=Rect('+','.join(map(str,t.playable))+')',f'    set UZ_startX[{z}]={host["x"]+dx}',f'    set UZ_startY[{z}]={host["y"]+dy}']
    for r in range(4):
        geometry.append(f"    set UM_unitType[{r}]='uC0{r}'")
        geometry.append(f'    set UM_panel[{r}]="RexxarUI\\\\Hero{r}.tga"')
    for slot in range(12):geometry.append(f"    set UM_ability[{slot}]='uM{slot:02}'")
    for r in range(4):
        for slot in range(4):geometry.append(f"    set UM_detailAbility[{r*4+slot}]='uI{r}{slot}'")
    geometry.append("    set UM_backAbility='uIBk'")
    for index,title in enumerate(['Глава 1: Дуротар','Глава 2: Союзники Орды','Глава 3: Битва за Терамор'],1):
        geometry.append(f'    set UM_actTitle[{index}]='+json.dumps(title,ensure_ascii=False))
    geometry+=['endfunction']
    main='''function main takes nothing returns nothing
    call SetCameraBounds(-29696,-29696,29696,29696,-29696,29696,29696,-29696)
    call SetDayNightModels("Environment\\\\DNC\\\\DNCLordaeron\\\\DNCLordaeronTerrain\\\\DNCLordaeronTerrain.mdl","Environment\\\\DNC\\\\DNCLordaeron\\\\DNCLordaeronUnit\\\\DNCLordaeronUnit.mdl")
    call InitBlizzard()
    call SetMapFlag(MAP_FOG_HIDE_TERRAIN,true)
    call FogEnable(true)
    call FogMaskEnable(true)
    call TimerStart(CreateTimer(),0.1,false,function UZ_Bootstrap)
endfunction'''
    config=['function config takes nothing returns nothing','    call SetMapName("REXXAR VII TEST - 1 TO 4")','    call SetMapDescription("Все 17 локаций. Один сетевой сеанс. Выбор героя, сложности, таланты и уровень до 20. Тестовая версия Warcraft III 1.26.")','    call SetPlayers(12)','    call SetTeams(9)','    call SetGamePlacement(MAP_PLACEMENT_USE_MAP_SETTINGS)']
    info=read_info((__import__('unified_build').atlas_info(maps[MAPS[0]]['data']['war3map.w3i'],'REXXAR VII TEST',*terrains[0].offset)))
    for p in info['players']:
        n=p['id'];config += [f'    call DefineStartLocation({n},{p["x"]},{p["y"]})',f'    call SetPlayerStartLocation(Player({n}),{n})',f'    call ForcePlayerStartLocation(Player({n}),{n})',f'    call SetPlayerColor(Player({n}),ConvertPlayerColor({n}))',f'    call SetPlayerController(Player({n}),'+('MAP_CONTROL_USER' if n<4 else 'MAP_CONTROL_COMPUTER')+')',f'    call SetPlayerTeam(Player({n}),{0 if n<4 else n-3})',f'    call SetPlayerRacePreference(Player({n}),RACE_PREF_ORC)',f'    call SetPlayerRaceSelectable(Player({n}),false)']
        if n<4:config.append(f'    call SetPlayerSlotAvailable(Player({n}),MAP_CONTROL_USER)')
    config+=['endfunction']
    functions='\n\n'.join([(ROOT/'unified-engine-low.j').read_text(),shared,source,late,'\n'.join(geometry),(ROOT/'unified-engine-high.j').read_text(),(ROOT/'unified-menu.j').read_text(),ai_code(maps,catalog),main,'\n'.join(config)])
    globals_block='globals\n'+globals_text(maps[MAPS[0]],len(schema))+GLOBALS+unified_menu.GLOBALS+'\n'.join(p['globals'] for p in parts.values())+'\nendglobals\n'
    result=classic_strings(globals_block+order_functions(functions))
    assert '@@' not in result
    return result,reports


def ai_code(maps,catalog):
    # Adapt original AI faction production to aliased units and active atlas
    # coordinates. No background AI VM is started against the wrong region.
    from formats import read_objects
    choices={}
    stock=json.loads((ROOT/'classic-production.json').read_text())['factories']
    for name,m in maps.items():
        source={raw.encode():[v.encode() for v in ids] for raw,ids in stock.items()}
        for raw,obj in m['lookup']['unit'].items():
            trains=next((x[4].decode() for x in reversed(obj['mods']) if x[0]=='utra'),','.join(stock.get(obj['old'].decode(),[])))
            if trains:source[raw]=[v.encode() for v in trains.split(',') if len(v)==4]
        for raw,ids in source.items():
            alias=catalog.raw_maps[name].get(raw,raw)
            resolved=[catalog.raw_maps[name].get(v,v) for v in ids]
            choices[m['index'],alias]=[v for v in resolved if v[:1].islower()]
    init=['function UZ_AIInit takes nothing returns nothing']
    for (zone,raw),ids in sorted(choices.items()):
        if not ids:continue
        init.append(f"    call SaveInteger(UZ_cache,'{raw.decode()}',{600+zone*32},{len(ids)})")
        for i,rawid in enumerate(ids):init.append(f"    call SaveInteger(UZ_cache,'{raw.decode()}',{601+zone*32+i},'{rawid.decode()}')")
    init+=['endfunction']
    return '\n'.join(init)+'''\nfunction UZ_AIProduceAt takes nothing returns nothing
    local unit factory=GetEnumUnit()
    local integer owner=GetPlayerId(GetOwningPlayer(factory))
    local integer raw=GetUnitTypeId(factory)
    local integer count=LoadInteger(UZ_cache,raw,600+RC_map*32)
    local integer n=LoadInteger(UZ_state,RC_map,50200+owner)
    local unit u
    if RK_Alive(factory) and IsUnitType(factory,UNIT_TYPE_STRUCTURE) and count>0 and LoadBoolean(UZ_state,RC_map,50000+owner) and n<40+RC_difficulty*12 then
        set raw=LoadInteger(UZ_cache,raw,601+RC_map*32+GetRandomInt(0,count-1))
        set u=UZ_CreateUnit(GetOwningPlayer(factory),raw,GetUnitX(factory)+GetRandomReal(-160,160),GetUnitY(factory)-180,270)
        call RC_ScaleLife(u)
        call SaveInteger(UZ_state,RC_map,50200+owner,n+1)
        set u=null
    endif
    set factory=null
endfunction
function UZ_AICount takes nothing returns nothing
    local unit u=GetEnumUnit()
    local integer owner=GetPlayerId(GetOwningPlayer(u))
    if RK_Alive(u) and not IsUnitType(u,UNIT_TYPE_STRUCTURE) then
        call SaveInteger(UZ_state,RC_map,50200+owner,LoadInteger(UZ_state,RC_map,50200+owner)+1)
    endif
    set u=null
endfunction
function UZ_AIProduction takes nothing returns nothing
    local integer n=0
    if ModuloInteger(UZ_aiTicks,8-RC_difficulty*2)!=0 then
        return
    endif
    loop
        exitwhen n==16
        call SaveInteger(UZ_state,RC_map,50200+n,0)
        set n=n+1
    endloop
    call ForGroup(UZ_units[RC_map],function UZ_AICount)
    call ForGroup(UZ_units[RC_map],function UZ_AIProduceAt)
endfunction
'''

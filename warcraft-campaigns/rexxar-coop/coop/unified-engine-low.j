// Shared atlas primitives. No source campaign function is called from here.
function UZ_PartyUnit takes unit u returns boolean
    local integer n=0
    if u == null then
        return false
    endif
    loop
        exitwhen n==4
        if u==RC_hero[n] then
            return true
        endif
        set n=n+1
    endloop
    return u==UZ_stash
endfunction

function UZ_TrackUnit takes unit u returns nothing
    local integer previous=LoadInteger(UZ_state,GetHandleId(u),1)-1
    if u!=null and not UZ_PartyUnit(u) then
        if previous>=0 and previous!=RC_map then
            call GroupRemoveUnit(UZ_units[previous],u)
        endif
        if not HaveSavedBoolean(UZ_state,GetHandleId(u),6) then
            call SaveBoolean(UZ_state,GetHandleId(u),6,true)
        endif
        call GroupAddUnit(UZ_units[RC_map],u)
        call SaveInteger(UZ_state,GetHandleId(u),1,RC_map+1)
    endif
endfunction

function UZ_ActiveUnit takes unit u returns boolean
    local integer z=LoadInteger(UZ_state,GetHandleId(u),1)-1
    return z<0 or z==RC_map or UZ_PartyUnit(u)
endfunction

function UZ_Two takes integer n returns string
    if n<10 then
        return "0"+I2S(n)
    endif
    return I2S(n)
endfunction

function UZ_ShowUnit takes unit u, boolean visible returns nothing
    call SaveBoolean(UZ_state,GetHandleId(u),6,visible)
    call ShowUnit(u,visible)
endfunction

function UZ_CreateUnit takes player p, integer raw, real x, real y, real facing returns unit
    local integer n=0
    local unit u
    if GetPlayerId(p)<4 then
        loop
            exitwhen n==4
            if raw==RC_heroType[n] and RC_hero[n]!=null then
                return RC_hero[n]
            endif
            set n=n+1
        endloop
    endif
    set u=CreateUnit(p,raw,x,y,facing)
    call UZ_TrackUnit(u)
    return u
endfunction

function UZ_SetHeroLevel takes unit u, integer level, boolean eyeCandy returns nothing
    if not UZ_entering or not UZ_PartyUnit(u) then
        call SetHeroLevel(u,level,eyeCandy)
    endif
endfunction

function UZ_TrackTimer takes timer t, integer z returns nothing
    local integer key=GetHandleId(t)
    local integer n
    if not HaveSavedInteger(UZ_state,key,20) then
        set n=UZ_timerCount[z]
        call SaveTimerHandle(UZ_state,z,10000+n,t)
        call SaveInteger(UZ_state,key,20,z+1)
        call SaveInteger(UZ_state,key,21,n)
        set UZ_timerCount[z]=n+1
    endif
endfunction

function UZ_TimerStart takes timer t, real duration, boolean periodic, code action, integer z returns nothing
    call UZ_TrackTimer(t,z)
    call SaveBoolean(UZ_state,GetHandleId(t),22,true)
    call TimerStart(t,duration,periodic,action)
    if not UZ_live[z] then
        call PauseTimer(t)
    endif
endfunction

function UZ_TimerSingle takes trigger trg, real duration, integer z returns nothing
    local timer t=CreateTimer()
    call TriggerRegisterTimerExpireEvent(trg,t)
    call UZ_TimerStart(t,duration,false,null,z)
    set t=null
endfunction

function UZ_TimerPeriodic takes trigger trg, real duration, integer z returns nothing
    local timer t=CreateTimer()
    call TriggerRegisterTimerExpireEvent(trg,t)
    call UZ_TimerStart(t,duration,true,null,z)
    set t=null
endfunction

function UZ_PauseTimer takes timer t returns nothing
    call SaveBoolean(UZ_state,GetHandleId(t),22,false)
    call PauseTimer(t)
endfunction

function UZ_ResumeTimer takes timer t returns nothing
    local integer z=LoadInteger(UZ_state,GetHandleId(t),20)-1
    call SaveBoolean(UZ_state,GetHandleId(t),22,true)
    if z<0 or UZ_live[z] then
        call ResumeTimer(t)
    endif
endfunction

function UZ_DestroyTimer takes timer t returns nothing
    local integer z=LoadInteger(UZ_state,GetHandleId(t),20)-1
    local integer slot=LoadInteger(UZ_state,GetHandleId(t),21)
    if z>=0 then
        call SaveTimerHandle(UZ_state,z,10000+slot,null)
    endif
    call FlushChildHashtable(UZ_state,GetHandleId(t))
    call DestroyTimer(t)
endfunction

function UZ_ZoneTimers takes integer z, boolean active returns nothing
    local integer n=0
    local timer t
    loop
        exitwhen n>=UZ_timerCount[z]
        set t=LoadTimerHandle(UZ_state,z,10000+n)
        if t!=null and LoadBoolean(UZ_state,GetHandleId(t),22) and TimerGetRemaining(t)>0 then
            if active then
                call ResumeTimer(t)
            else
                call PauseTimer(t)
            endif
        endif
        set n=n+1
    endloop
    set t=null
endfunction

function UZ_CreateTrigger takes nothing returns trigger
    local trigger trg=CreateTrigger()
    local integer z=RC_map
    local integer n=UZ_triggerCount[z]
    call SaveTriggerHandle(UZ_state,z,20000+n,trg)
    call SaveInteger(UZ_state,GetHandleId(trg),31,z+1)
    call SaveInteger(UZ_state,GetHandleId(trg),32,n)
    call SaveBoolean(UZ_state,GetHandleId(trg),30,true)
    set UZ_triggerCount[z]=n+1
    return trg
endfunction

function UZ_RegisterTrigger takes trigger trg, integer z returns nothing
    local integer n
    if trg==null then
        return
    endif
    if not HaveSavedInteger(UZ_state,GetHandleId(trg),31) then
        set n=UZ_triggerCount[z]
        call SaveTriggerHandle(UZ_state,z,20000+n,trg)
        call SaveInteger(UZ_state,GetHandleId(trg),31,z+1)
        call SaveInteger(UZ_state,GetHandleId(trg),32,n)
        set UZ_triggerCount[z]=n+1
    endif
    call SaveBoolean(UZ_state,GetHandleId(trg),30,IsTriggerEnabled(trg))
    call DisableTrigger(trg)
endfunction

function UZ_DestroyTrigger takes trigger trg returns nothing
    local integer z=LoadInteger(UZ_state,GetHandleId(trg),31)-1
    if z>=0 then
        call SaveTriggerHandle(UZ_state,z,20000+LoadInteger(UZ_state,GetHandleId(trg),32),null)
    endif
    call FlushChildHashtable(UZ_state,GetHandleId(trg))
    call DestroyTrigger(trg)
endfunction

function UZ_GateZone takes integer z, boolean enable returns nothing
    local integer n=0
    local trigger trg
    loop
        exitwhen n>=UZ_triggerCount[z]
        set trg=LoadTriggerHandle(UZ_state,z,20000+n)
        if trg!=null then
        if enable then
            if LoadBoolean(UZ_state,GetHandleId(trg),30) then
                call EnableTrigger(trg)
            endif
        else
            call SaveBoolean(UZ_state,GetHandleId(trg),30,IsTriggerEnabled(trg))
            call DisableTrigger(trg)
        endif
        endif
        set n=n+1
    endloop
    set trg=null
endfunction

function UZ_FreezeUnit takes nothing returns nothing
    local unit u=GetEnumUnit()
    local integer key=GetHandleId(u)
    if GetUnitTypeId(u)!=0 and not UZ_PartyUnit(u) and not IsUnitInGroup(u,UZ_travelParty) then
        call SaveInteger(UZ_state,key,2,GetPlayerId(GetOwningPlayer(u)))
        call SaveBoolean(UZ_state,key,3,IsUnitPaused(u))
        call SaveBoolean(UZ_state,key,4,not LoadBoolean(UZ_state,key,6))
        call SaveBoolean(UZ_state,key,5,GetUnitAbilityLevel(u,'Avul')>0)
        call PauseUnit(u,true)
        call SetUnitInvulnerable(u,true)
        call ShowUnit(u,false)
        call SetUnitOwner(u,Player(15),false)
    endif
    set u=null
endfunction

function UZ_ThawUnit takes nothing returns nothing
    local unit u=GetEnumUnit()
    local integer key=GetHandleId(u)
    if GetUnitTypeId(u)!=0 and HaveSavedInteger(UZ_state,key,2) and not UZ_PartyUnit(u) and not IsUnitInGroup(u,UZ_travelParty) then
        call SetUnitOwner(u,Player(LoadInteger(UZ_state,key,2)),false)
        call SetUnitInvulnerable(u,LoadBoolean(UZ_state,key,5))
        call ShowUnit(u,not LoadBoolean(UZ_state,key,4))
        call PauseUnit(u,LoadBoolean(UZ_state,key,3))
    endif
    set u=null
endfunction

function UZ_PauseMember takes nothing returns nothing
    call PauseUnit(GetEnumUnit(),UZ_pauseFlag)
endfunction

function UZ_PauseCurrent takes boolean paused returns nothing
    local integer n=0
    set UZ_pauseFlag=paused
    call ForGroup(UZ_units[RC_map],function UZ_PauseMember)
    call ForGroup(UZ_travelParty,function UZ_PauseMember)
    loop
        exitwhen n==4
        if RC_hero[n]!=null then
            call PauseUnit(RC_hero[n],paused)
        endif
        set n=n+1
    endloop
endfunction

function UZ_CreateQuest takes nothing returns quest
    local quest q=CreateQuest()
    local integer n=UZ_questCount[RC_map]
    call SaveInteger(UZ_state,GetHandleId(q),42,RC_map+1)
    call SaveInteger(UZ_state,GetHandleId(q),43,n)
    call SaveQuestHandle(UZ_state,RC_map,30000+n,q)
    set UZ_questCount[RC_map]=n+1
    return q
endfunction

function UZ_CreateQuestBJ takes integer kind, string title, string description, string icon returns quest
    local quest q=CreateQuestBJ(kind,title,description,icon)
    local integer n=UZ_questCount[RC_map]
    call SaveInteger(UZ_state,GetHandleId(q),42,RC_map+1)
    call SaveInteger(UZ_state,GetHandleId(q),43,n)
    call SaveQuestHandle(UZ_state,RC_map,30000+n,q)
    set UZ_questCount[RC_map]=n+1
    return q
endfunction

function UZ_DestroyQuest takes quest q returns nothing
    local integer z=LoadInteger(UZ_state,GetHandleId(q),42)-1
    if z>=0 then
        call SaveQuestHandle(UZ_state,z,30000+LoadInteger(UZ_state,GetHandleId(q),43),null)
    endif
    call FlushChildHashtable(UZ_state,GetHandleId(q))
    call DestroyQuest(q)
endfunction

function UZ_ZoneQuests takes integer z, boolean visible returns nothing
    local integer n=0
    local quest q
    loop
        exitwhen n>=UZ_questCount[z]
        set q=LoadQuestHandle(UZ_state,z,30000+n)
        if q!=null then
        if visible then
            call QuestSetEnabled(q,LoadBoolean(UZ_state,GetHandleId(q),40))
        else
            call SaveBoolean(UZ_state,GetHandleId(q),40,IsQuestEnabled(q))
            call QuestSetEnabled(q,false)
        endif
        endif
        set n=n+1
    endloop
    set q=null
endfunction

function UZ_HideFloorItem takes nothing returns nothing
    local item it=GetEnumItem()
    local integer n=UZ_itemCount[RC_map]
    if not IsItemOwned(it) then
        call SaveItemHandle(UZ_state,RC_map,40000+n,it)
        call SaveBoolean(UZ_state,GetHandleId(it),41,IsItemVisible(it))
        call SetItemVisible(it,false)
        set UZ_itemCount[RC_map]=n+1
    endif
    set it=null
endfunction

function UZ_ShowFloorItems takes integer z returns nothing
    local integer n=0
    local item it
    loop
        exitwhen n>=UZ_itemCount[z]
        set it=LoadItemHandle(UZ_state,z,40000+n)
        if GetItemTypeId(it)!=0 then
            call SetItemVisible(it,LoadBoolean(UZ_state,GetHandleId(it),41))
        endif
        set n=n+1
    endloop
    set UZ_itemCount[z]=0
    set it=null
endfunction

function UZ_StoreUnit takes gamecache cache, string mission, string key, unit u returns boolean
    call SaveUnitHandle(UZ_cache,StringHash(mission),StringHash(key),u)
    call SaveBoolean(UZ_state,GetHandleId(u),50,true)
    return u!=null
endfunction

function UZ_StoreUnitBJ takes unit u, string key, string mission, gamecache cache returns boolean
    return UZ_StoreUnit(cache,mission,key,u)
endfunction

function UZ_HaveStoredUnit takes gamecache cache, string mission, string key returns boolean
    return GetUnitTypeId(LoadUnitHandle(UZ_cache,StringHash(mission),StringHash(key)))!=0
endfunction

function UZ_RestoreCached takes string key, string mission, gamecache cache, player p, location point, real facing returns unit
    local unit u=LoadUnitHandle(UZ_cache,StringHash(mission),StringHash(key))
    if GetUnitTypeId(u)!=0 then
        call SetUnitOwner(u,p,true)
        call UZ_ShowUnit(u,true)
        call PauseUnit(u,false)
        call SetUnitPositionLoc(u,point)
        call SetUnitFacing(u,facing)
        set bj_lastLoadedUnit=u
        call UZ_TrackUnit(u)
        return u
    endif
    set bj_lastLoadedUnit=null
    set u=null
    return null
endfunction

function UZ_ProtectCached takes unit u returns boolean
    if u!=null and not UZ_PartyUnit(u) and LoadBoolean(UZ_state,GetHandleId(u),50) then
        call PauseUnit(u,true)
        call UZ_ShowUnit(u,false)
        return true
    endif
    return false
endfunction

function UZ_BindStash takes unit candidate returns unit
    if UZ_stash==null or GetUnitTypeId(UZ_stash)==0 then
        set UZ_stash=candidate
    endif
    if candidate!=null and candidate!=UZ_stash then
        call ShowUnit(candidate,false)
        call PauseUnit(candidate,true)
        call SetUnitOwner(candidate,Player(15),false)
    endif
    set RC_stash=UZ_stash
    return UZ_stash
endfunction

function UZ_TransitionTimer takes nothing returns nothing
    call ExecuteFunc("UZ_Travel")
endfunction

function UZ_AllNearDoor takes nothing returns boolean
    local integer n=0
    local real dx
    local real dy
    local unit leader=RC_hero[0]
    loop
        exitwhen n==4
        if UZ_classPlayer[n]>=0 and RC_hero[n]!=null and not IsUnitType(RC_hero[n],UNIT_TYPE_DEAD) then
            set dx=GetUnitX(RC_hero[n])-GetUnitX(leader)
            set dy=GetUnitY(RC_hero[n])-GetUnitY(leader)
            if dx*dx+dy*dy>1440000 then
                set leader=null
                return false
            endif
        endif
        set n=n+1
    endloop
    set leader=null
    return true
endfunction

function UZ_RequestTransition takes integer target, integer area returns nothing
    if not RC_started or RC_transitionPending or target<0 or target>=17 or TimerGetElapsed(RC_menuClock)<UZ_portalReadyAt then
        return
    endif
    if target<15 and RC_act[target]==RC_act[RC_map] and not UZ_AllNearDoor() then
        call ExecuteFunc("UZ_CancelDoor")
        return
    endif
    set UZ_target=target
    set UZ_area=area
    set RC_transitionPending=true
    call TimerStart(UZ_transitionClock,0.05,false,function UZ_TransitionTimer)
endfunction

function UZ_StartAI takes player p, string name returns nothing
    local integer id=GetPlayerId(p)
    if id>=4 and id<16 then
        call SaveBoolean(UZ_state,RC_map,50000+id,true)
        call SaveStr(UZ_state,RC_map,50100+id,name)
    endif
endfunction

// Single-player save folders and profile unlocks must never branch network
// gameplay on files present on one participant's computer.
function UZ_SaveGameExists takes string path returns boolean
    return false
endfunction
function UZ_CopySave takes string sourcePath, string destinationPath returns boolean
    return false
endfunction
function UZ_SavedEvent takes trigger trg returns event
    return null
endfunction
function UZ_CampaignRace takes integer campaignNumber returns nothing
endfunction
function UZ_MissionAvailable takes integer campaignNumber, integer missionNumber, boolean available returns nothing
endfunction

function UZ_UnitAppeared takes nothing returns nothing
    if RC_started and GetEnteringUnit()!=null then
        call UZ_TrackUnit(GetEnteringUnit())
    endif
endfunction

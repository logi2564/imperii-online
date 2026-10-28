function UZ_CollectTraveller takes nothing returns nothing
    local unit u=GetEnumUnit()
    if GetUnitTypeId(u)!=0 and not IsUnitType(u,UNIT_TYPE_STRUCTURE) and GetUnitAbilityLevel(u,'Aloc')==0 and not LoadBoolean(RC_table,GetHandleId(u),700) then
        call GroupAddUnit(UZ_travelParty,u)
    endif
    set u=null
endfunction

function UZ_CollectParty takes nothing returns nothing
    local integer n=0
    local group scan=CreateGroup()
    call GroupClear(UZ_travelParty)
    loop
        exitwhen n==4
        call GroupEnumUnitsOfPlayer(scan,Player(n),null)
        call ForGroup(scan,function UZ_CollectTraveller)
        set n=n+1
    endloop
    call DestroyGroup(scan)
    set scan=null
endfunction

function UZ_MoveTraveller takes nothing returns nothing
    local unit u=GetEnumUnit()
    local integer rank=LoadInteger(UZ_state,99,0)
    if GetUnitTypeId(u)!=0 then
        call UZ_TrackUnit(u)
        call SetUnitPosition(u,UZ_arrivalX+ModuloInteger(rank,6)*90-180,UZ_arrivalY-(rank/6)*90)
        call IssueImmediateOrder(u,"stop")
        call SaveInteger(UZ_state,99,0,rank+1)
    endif
    set u=null
endfunction

function UZ_PlaceParty takes nothing returns nothing
    local integer n=0
    local unit leader=RC_hero[0]
    if leader==null then
        set leader=RC_hero[RC_host]
    endif
    if leader!=null then
        set UZ_arrivalX=GetUnitX(leader)
        set UZ_arrivalY=GetUnitY(leader)
    else
        set UZ_arrivalX=UZ_startX[RC_map]
        set UZ_arrivalY=UZ_startY[RC_map]
    endif
    call SaveInteger(UZ_state,99,0,0)
    call ForGroup(UZ_travelParty,function UZ_MoveTraveller)
    loop
        exitwhen n==4
        if RC_Active(n) then
            if IsUnitType(RC_hero[n],UNIT_TYPE_DEAD) then
                call ReviveHero(RC_hero[n],UZ_arrivalX+n*90,UZ_arrivalY,true)
            endif
            call SetUnitPosition(RC_hero[n],UZ_arrivalX+n*90,UZ_arrivalY)
        endif
        set n=n+1
    endloop
    if UZ_stash!=null then
        call SetUnitPathing(UZ_stash,false)
        call SetUnitPosition(UZ_stash,UZ_arrivalX-250,UZ_arrivalY-200)
    endif
    set RC_revivalX=UZ_arrivalX
    set RC_revivalY=UZ_arrivalY
    set leader=null
endfunction

function UZ_Diplomacy takes integer z, boolean save returns nothing
    local integer a=0
    local integer b
    local integer flag
    local integer key
    loop
        exitwhen a==16
        set b=0
        loop
            exitwhen b==16
            set flag=0
            loop
                exitwhen flag==10
                set key=a*160+b*10+flag
                if save then
                    call SaveBoolean(UZ_cache,100+z,key,GetPlayerAlliance(Player(a),Player(b),ConvertAllianceType(flag)))
                elseif UZ_initialized[z] and LoadBoolean(UZ_state,z,91) then
                    call SetPlayerAlliance(Player(a),Player(b),ConvertAllianceType(flag),LoadBoolean(UZ_cache,100+z,key))
                else
                    call SetPlayerAlliance(Player(a),Player(b),ConvertAllianceType(flag),a==b or (a<4 and b<4 and (flag==0 or flag==4 or flag==5)))
                endif
                set flag=flag+1
            endloop
            set b=b+1
        endloop
        set a=a+1
    endloop
    if save then
        call SaveBoolean(UZ_state,z,91,true)
    endif
endfunction

function UZ_SaveAct takes integer act returns nothing
    local integer n=0
    loop
        exitwhen n==RC_storyCount
        call SaveInteger(UZ_cache,200+act,n,RC_story[n])
        set n=n+1
    endloop
endfunction

function UZ_LoadAct takes integer act returns nothing
    local integer n=0
    loop
        exitwhen n==RC_storyCount
        set RC_story[n]=LoadInteger(UZ_cache,200+act,n)
        set n=n+1
    endloop
endfunction

function UZ_StopEffects takes nothing returns nothing
    local integer n=1
    loop
        exitwhen n>64
        if RK_kind[n]!=0 then
            call RK_End(n)
        endif
        set n=n+1
    endloop
    set RC_huntTarget=null
    set RC_huntUntil=0
endfunction

function UZ_FinishEntry takes nothing returns nothing
    if not UZ_entering then
        return
    endif
    call RC_ObserveStoryHeroes()
    call UZ_CollectParty()
    call UZ_PlaceParty()
    call RC_Alliances()
    call RC_Balance()
    call RC_InitialArmy()
    call RC_Distribute()
    set UZ_entering=false
    set RC_transitionPending=false
    set UZ_portalReadyAt=TimerGetElapsed(RC_menuClock)+3.0
    if not RC_StoryCinematic() then
        call UZ_PauseCurrent(false)
        call RC_Cinematic(false,RC_force)
        call RC_CameraHome()
        call CinematicFadeBJ(bj_CINEFADETYPE_FADEIN,0.35,"ReplaceableTextures\\CameraMasks\\White_mask.tga",0,0,0,0)
    endif
    if not RC_ready then
        call RC_Ready()
    endif
    call RC_Say("Локация: "+RC_mapName[RC_map]+". Отряд и его вещи перенесены внутри партии.")
endfunction

function UZ_Enter takes integer z, boolean freshStart returns nothing
    local boolean first=not UZ_initialized[z]
    set RC_map=z
    set UZ_entering=true
    set RC_transitionPending=true
    set bj_mapInitialPlayableArea=UZ_bounds[z]
    call UZ_Diplomacy(z,false)
    call ExecuteFunc("UZ_EnvironmentZ"+UZ_Two(z))
    if first then
        call ExecuteFunc("UZ_InitZ"+UZ_Two(z))
        if not UZ_initialized[z] then
            call RC_Say("Не завершилась инициализация локации "+RC_mapName[z]+". Отряд сохранён в памяти; отправьте этот текст разработчику.")
            set UZ_entering=false
            set RC_transitionPending=false
            return
        endif
        call RC_InitialAlliances()
    else
        call ForGroup(UZ_units[z],function UZ_ThawUnit)
        call UZ_ShowFloorItems(z)
        call UZ_ZoneQuests(z,true)
    endif
    call RC_SeedStory()
    if RC_partyLoaded then
        call RC_ApplyStory()
    endif
    call RC_ObserveStoryHeroes()
    set UZ_live[z]=true
    call UZ_GateZone(z,true)
    call UZ_ZoneTimers(z,true)
    if first then
        call ExecuteFunc("Z"+UZ_Two(z)+"_RunInitializationTriggers")
    else
        call ExecuteFunc("UZ_ReturnZ"+UZ_Two(z))
    endif
    call TimerStart(UZ_arrivalClock,0.75,false,function UZ_FinishEntry)
endfunction

function UZ_Travel takes nothing returns nothing
    local integer old=RC_map
    local integer n=0
    if not RC_started or not RC_transitionPending then
        return
    endif
    call UZ_CollectParty()
    call RC_Cinematic(false,RC_force)
    call UZ_StopEffects()
    call RC_CollectStory()
    call ExecuteFunc("UZ_ExportZ"+UZ_Two(old))
    call UZ_SaveAct(RC_act[old])
    call UZ_Diplomacy(old,true)
    call UZ_GateZone(old,false)
    set UZ_live[old]=false
    set UZ_generation[old]=UZ_generation[old]+1
    call UZ_ZoneTimers(old,false)
    call UZ_ZoneQuests(old,false)
    call QueuedTriggerClearBJ()
    call EnumItemsInRect(UZ_bounds[old],null,function UZ_HideFloorItem)
    call ForGroup(UZ_units[old],function UZ_FreezeUnit)
    call UZ_PauseCurrent(true)
    set RC_sourceMap=old
    set RC_nextMap=UZ_target
    set RC_nextArea=UZ_area
    set RC_partyLoaded=true
    if RC_act[old]!=RC_act[UZ_target] then
        call UZ_LoadAct(RC_act[UZ_target])
    endif
    set n=0
    loop
        exitwhen n==4
        if RC_hero[n]!=null then
            call SetUnitPosition(RC_hero[n],UZ_startX[UZ_target]+n*90,UZ_startY[UZ_target])
        endif
        set n=n+1
    endloop
    call UZ_Enter(UZ_target,false)
endfunction

function UZ_StartCampaign takes nothing returns nothing
    call UZ_CollectParty()
    call UZ_Enter(RC_map,true)
endfunction

function UZ_AIOrder takes nothing returns nothing
    local unit u=GetEnumUnit()
    local integer owner=GetPlayerId(GetOwningPlayer(u))
    local integer n=0
    local real d
    local real best=999999999
    local unit target=null
    if not RK_Alive(u) or IsUnitPaused(u) or IsUnitType(u,UNIT_TYPE_STRUCTURE) or IsUnitType(u,UNIT_TYPE_PEON) or GetUnitAbilityLevel(u,'Aloc')>0 or not LoadBoolean(UZ_state,RC_map,50000+owner) then
        set u=null
        return
    endif
    if not IsUnitEnemy(u,RC_Player(0)) then
        set target=UZ_aiRally[owner]
        if RK_Alive(target) and (GetUnitCurrentOrder(u)==0 or GetUnitCurrentOrder(u)==OrderId("stop")) then
            call IssuePointOrder(u,"attack",GetUnitX(target),GetUnitY(target))
        endif
        set u=null
        set target=null
        return
    endif
    loop
        exitwhen n==4
        if RC_Active(n) and RK_Alive(RC_hero[n]) then
            set d=(GetUnitX(u)-GetUnitX(RC_hero[n]))*(GetUnitX(u)-GetUnitX(RC_hero[n]))+(GetUnitY(u)-GetUnitY(RC_hero[n]))*(GetUnitY(u)-GetUnitY(RC_hero[n]))
            if d<best then
                set best=d
                set target=RC_hero[n]
            endif
        endif
        set n=n+1
    endloop
    if target!=null and (GetUnitCurrentOrder(u)==0 or GetUnitCurrentOrder(u)==OrderId("stop")) then
        if best<9000000 or RC_map>=15 then
            call IssuePointOrder(u,"attack",GetUnitX(target),GetUnitY(target))
        endif
    endif
    set u=null
    set target=null
endfunction

function UZ_AIChooseGoal takes nothing returns nothing
    local unit u=GetEnumUnit()
    if RK_Alive(u) and IsUnitEnemy(u,Player(UZ_aiOwner)) and GetUnitAbilityLevel(u,'Avul')==0 and GetUnitAbilityLevel(u,'Aloc')==0 then
        if UZ_aiRally[UZ_aiOwner]==null or (IsUnitType(u,UNIT_TYPE_STRUCTURE) and not IsUnitType(UZ_aiRally[UZ_aiOwner],UNIT_TYPE_STRUCTURE)) then
            set UZ_aiRally[UZ_aiOwner]=u
        endif
    endif
    set u=null
endfunction

function UZ_AITick takes nothing returns nothing
    local integer n=4
    if not RC_started or RC_transitionPending or RC_StoryCinematic() then
        return
    endif
    set UZ_aiTicks=UZ_aiTicks+1
    loop
        exitwhen n==16
        if LoadBoolean(UZ_state,RC_map,50000+n) then
            set UZ_aiRally[n]=null
            set UZ_aiOwner=n
            call ForGroup(UZ_units[RC_map],function UZ_AIChooseGoal)
        endif
        set n=n+1
    endloop
    call ForGroup(UZ_units[RC_map],function UZ_AIOrder)
    call ExecuteFunc("UZ_AIProduction")
endfunction

function UZ_Bootstrap takes nothing returns nothing
    local integer p=0
    local integer role=0
    local trigger spawned=CreateTrigger()
    set UZ_state=InitHashtable()
    set UZ_cache=InitHashtable()
    set UZ_travelParty=CreateGroup()
    set UZ_aiScratch=CreateGroup()
    set UZ_transitionClock=CreateTimer()
    set UZ_arrivalClock=CreateTimer()
    set UZ_aiClock=CreateTimer()
    loop
        exitwhen role==4
        set UZ_classPlayer[role]=-1
        set UZ_playerClass[role]=-1
        set role=role+1
    endloop
    set role=0
    loop
        exitwhen p==4
        if GetPlayerController(Player(p))==MAP_CONTROL_USER and GetPlayerSlotState(Player(p))==PLAYER_SLOT_STATE_PLAYING then
            set UZ_classPlayer[role]=p
            set UZ_playerClass[p]=role
            set role=role+1
        endif
        set p=p+1
    endloop
    set RC_host=0
    set UM_hostColor=UZ_classPlayer[0]
    call ExecuteFunc("UZ_InitGeometry")
    call ExecuteFunc("UZ_AIInit")
    call TriggerRegisterEnterRectSimple(spawned,GetWorldBounds())
    call TriggerAddAction(spawned,function UZ_UnitAppeared)
    set spawned=null
    call RC_Menu()
    call TimerStart(UZ_aiClock,3,true,function UZ_AITick)
endfunction

function UZ_CancelDoor takes nothing returns nothing
    call RC_Say("Соберите живых героев у входа (не дальше 1200 от Рексара), затем войдите снова.")
    call UZ_PauseCurrent(false)
    call RC_Cinematic(false,RC_force)
    call CinematicFadeBJ(bj_CINEFADETYPE_FADEIN,0.2,"ReplaceableTextures\\CameraMasks\\White_mask.tga",0,0,0,0)
endfunction

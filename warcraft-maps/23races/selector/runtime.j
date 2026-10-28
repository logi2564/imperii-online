// Classic 1.26 only. Camera/filter/tag visibility branches are local UI;
// units, trees, timers and command-card input are created synchronously.
// @@GLOBALS@@

function AS_Active takes integer p returns boolean
    return GetPlayerController(Player(p)) == MAP_CONTROL_USER and GetPlayerSlotState(Player(p)) == PLAYER_SLOT_STATE_PLAYING
endfunction

function AS_Number takes integer n returns string
    if n < 10 then
        return "0" + I2S(n)
    endif
    return I2S(n)
endfunction

function AS_Ground takes real x, real y returns real
    local location point = Location(x,y)
    local real z = GetLocationZ(point)
    call RemoveLocation(point)
    set point = null
    return z
endfunction

function AS_SelectControl takes integer p returns nothing
    if GetLocalPlayer() == Player(p) and udg_AS_Control[p] != null then
        if not IsUnitSelected(udg_AS_Control[p],Player(p)) then
            call ClearSelection()
            call SelectUnit(udg_AS_Control[p],true)
        endif
    endif
endfunction

function AS_Camera takes integer p returns nothing
    local real cx = udg_AS_StageX[p]+200
    local real cy = udg_AS_StageY[p]-600
    if GetLocalPlayer() == Player(p) then
        call SetCameraBounds(cx-16,cy-16,cx+16,cy+16,cx-16,cy+16,cx+16,cy-16)
        call SetCameraPosition(cx,cy)
        call SetCameraField(CAMERA_FIELD_TARGET_DISTANCE, 2000, 0)
        call SetCameraField(CAMERA_FIELD_ANGLE_OF_ATTACK, 315, 0)
        call SetCameraField(CAMERA_FIELD_ROTATION, 90, 0)
        call SetCameraField(CAMERA_FIELD_FIELD_OF_VIEW, 70, 0)
        call SetCameraField(CAMERA_FIELD_ZOFFSET, udg_AS_StageOffset[p], 0)
        call SetCameraField(CAMERA_FIELD_FARZ, 4200, 0)
        call AS_SelectControl(p)
    endif
endfunction

function AS_Panel takes integer p returns nothing
    local string texture = "AS\\Panels\\race" + AS_Number(udg_AS_Choice[p]) + ".tga"
    if udg_AS_Ready[p] then
        set texture = "AS\\Panels\\ready" + AS_Number(udg_AS_Choice[p]) + ".tga"
    endif
    if GetLocalPlayer() == Player(p) then
        call ShowInterface(true, 0)
        call EnableSelect(true, true)
        call SetCineFilterTexture(texture)
        call SetCineFilterBlendMode(BLEND_MODE_BLEND)
        call SetCineFilterTexMapFlags(TEXMAP_FLAG_NONE)
        call SetCineFilterStartUV(0, 0, 1, 1)
        call SetCineFilterEndUV(0, 0, 1, 1)
        call SetCineFilterStartColor(255, 255, 255, 255)
        call SetCineFilterEndColor(255, 255, 255, 255)
        call SetCineFilterDuration(0)
        call DisplayCineFilter(true)
    endif
endfunction

function AS_RemoveActors takes integer p returns nothing
    local unit u = FirstOfGroup(udg_AS_Actors[p])
    loop
        exitwhen u == null
        call GroupRemoveUnit(udg_AS_Actors[p], u)
        call RemoveUnit(u)
        set u = FirstOfGroup(udg_AS_Actors[p])
    endloop
endfunction

function AS_UpdateControl takes integer p returns nothing
    local unit old = udg_AS_Control[p]
    local integer raw = udg_AS_ControlType[udg_AS_Choice[p]]
    if GetUnitTypeId(old) != raw then
        if GetLocalPlayer() == Player(p) then
            call ClearSelection()
        endif
        if old != null then
            call RemoveUnit(old)
        endif
        set udg_AS_Control[p] = CreateUnit(Player(p),raw,udg_AS_StageX[p]+200,udg_AS_StageY[p]-850,225)
        call SetUnitFlyHeight(udg_AS_Control[p],udg_AS_StageZ[p]-AS_Ground(GetUnitX(udg_AS_Control[p]),GetUnitY(udg_AS_Control[p])),0)
        call SetUnitPathing(udg_AS_Control[p],false)
        call SetUnitInvulnerable(udg_AS_Control[p],true)
        // No move/stop/attack buttons may displace the twelve menu commands.
        call UnitRemoveAbility(udg_AS_Control[p],'Amov')
        call UnitRemoveAbility(udg_AS_Control[p],'Aatk')
    endif
    call AS_SelectControl(p)
    set old = null
endfunction

function AS_Preview takes integer p returns nothing
    local integer choice = udg_AS_Choice[p]
    local integer n = 0
    local integer raw
    local real x
    local real y
    local unit u
    call AS_RemoveActors(p)
    set u = CreateUnit(Player(PLAYER_NEUTRAL_PASSIVE), 'qPln', udg_AS_StageX[p], udg_AS_StageY[p], 0)
    call SetUnitFlyHeight(u,udg_AS_StageZ[p]-AS_Ground(udg_AS_StageX[p],udg_AS_StageY[p]),0)
    call PauseUnit(u,true)
    call SetUnitPathing(u,false)
    call GroupAddUnit(udg_AS_Actors[p],u)
    loop
        exitwhen n == 12
        set raw = udg_AS_PreviewType[choice * 12 + n]
        if raw != 0 then
            set x = udg_AS_StageX[p] + udg_AS_PreviewX[n]
            set y = udg_AS_StageY[p] + udg_AS_PreviewY[n]
            set u = CreateUnit(Player(PLAYER_NEUTRAL_PASSIVE), raw, x, y, 225)
            call SetUnitFlyHeight(u,udg_AS_StageZ[p]-AS_Ground(x,y),0)
            call SetUnitColor(u, ConvertPlayerColor(p))
            call SetUnitInvulnerable(u, true)
            call SetUnitPathing(u, false)
            call PauseUnit(u, true)
            call SetUnitAnimation(u, "stand")
            call GroupAddUnit(udg_AS_Actors[p], u)
        endif
        set n = n + 1
    endloop
    call AS_UpdateControl(p)
    call AS_Panel(p)
    set u = null
endfunction

// @@CATALOG@@
// @@ORIGINAL_GATES@@
// @@APPLY_RACES@@

function AS_PauseWorldUnit takes nothing returns nothing
    local unit u = GetEnumUnit()
    call SaveBoolean(udg_AS_State, GetHandleId(u), 0, IsUnitPaused(u))
    call PauseUnit(u, true)
    set u = null
endfunction

function AS_ResumeWorldUnit takes nothing returns nothing
    local unit u = GetEnumUnit()
    if GetUnitTypeId(u) != 0 then
        call PauseUnit(u, LoadBoolean(udg_AS_State, GetHandleId(u), 0))
    endif
    set u = null
endfunction

function AS_ResumeWorker takes nothing returns nothing
    call PauseUnit(GetEnumUnit(), false)
endfunction

function AS_SelectWorker takes nothing returns nothing
    call SelectUnit(GetEnumUnit(), true)
endfunction

function AS_ClosePlayer takes integer p returns nothing
    call AS_RemoveActors(p)
    call RemoveUnit(udg_AS_Control[p])
    set udg_AS_Control[p] = null
    if GetLocalPlayer() == Player(p) then
        call DisplayCineFilter(false)
        call ShowInterface(true, 0)
        call EnableSelect(true, true)
        call ResetToGameCamera(0)
        call SetCameraBounds(-27904.+GetCameraMargin(CAMERA_MARGIN_LEFT),-28672.+GetCameraMargin(CAMERA_MARGIN_BOTTOM),27904.-GetCameraMargin(CAMERA_MARGIN_RIGHT),30720.-GetCameraMargin(CAMERA_MARGIN_TOP),-27904.+GetCameraMargin(CAMERA_MARGIN_LEFT),30720.-GetCameraMargin(CAMERA_MARGIN_TOP),27904.-GetCameraMargin(CAMERA_MARGIN_RIGHT),-28672.+GetCameraMargin(CAMERA_MARGIN_BOTTOM))
        call PanCameraToTimed(udg_AS_SpawnX[p], udg_AS_SpawnY[p], 0)
        call ClearSelection()
        call ForGroup(udg_AS_Workers[p], function AS_SelectWorker)
    endif
endfunction

function AS_Finish takes nothing returns nothing
    local integer p = 0
    local integer n = 0
    if not udg_AS_Running then
        return
    endif
    set udg_AS_Running = false
    call DisableTrigger(udg_AS_Spells)
    call PauseTimer(udg_AS_InputTimer)
    call PauseTimer(udg_AS_Deadline)
    call DestroyTimerDialog(udg_AS_Countdown)
    call PauseTimer(udg_AS_TickTimer)
    call PauseTimer(udg_AS_CameraTimer)
    call ForGroup(udg_AS_World, function AS_ResumeWorldUnit)
    loop
        exitwhen p == 12
        if udg_AS_Entered[p] then
            call ForGroup(udg_AS_Workers[p], function AS_ResumeWorker)
            call AS_ClosePlayer(p)
            call DestroyGroup(udg_AS_Actors[p])
            call DestroyGroup(udg_AS_Workers[p])
            set udg_AS_Actors[p] = null
            set udg_AS_Workers[p] = null
            set udg_AS_Selector[p] = null
        endif
        set p = p + 1
    endloop
    loop
        exitwhen n >= udg_AS_TreeCount
        call RemoveDestructable(udg_AS_Tree[n])
        set udg_AS_Tree[n] = null
        set n = n + 1
    endloop
    call FogEnable(udg_AS_WasFog)
    call FogMaskEnable(udg_AS_WasFogMask)
    call DestroyGroup(udg_AS_World)
    set udg_AS_World = null
    call PauseTimer(udg_AS_Clock)
    call AS_RestoreOriginals()
    call DisplayTimedTextToForce(bj_FORCE_ALL_PLAYERS, 8, "|cffffcc00Расы выбраны. Игра начинается!|r")
endfunction

function AS_AllReady takes nothing returns boolean
    local integer p = 0
    loop
        exitwhen p == 12
        if AS_Active(p) and not udg_AS_Ready[p] then
            return false
        endif
        set p = p + 1
    endloop
    return true
endfunction

function AS_Confirm takes integer p returns nothing
    local group created
    local unit u
    if not udg_AS_Running or not AS_Active(p) or udg_AS_Ready[p] then
        return
    endif
    // A repeated click, held key, timeout, or other player's input cannot issue
    // the original five-worker reward twice.
    set udg_AS_Ready[p] = true
    call PauseUnit(udg_AS_Control[p],true)
    call AS_ApplyRace(p, udg_AS_Choice[p])
    set created = GetLastCreatedGroup()
    call GroupAddGroup(created, udg_AS_Workers[p])
    set u = FirstOfGroup(created)
    loop
        exitwhen u == null
        call GroupRemoveUnit(created, u)
        call PauseUnit(u, true)
        set u = FirstOfGroup(created)
    endloop
    call AS_Panel(p)
    if AS_AllReady() then
        call AS_Finish()
    endif
    set created = null
    set u = null
endfunction

function AS_Choose takes integer p, integer choice returns nothing
    if not udg_AS_Running or not AS_Active(p) or udg_AS_Ready[p] or choice < 0 or choice >= 34 then
        return
    endif
    if choice == udg_AS_Choice[p] then
        return
    endif
    set udg_AS_Choice[p] = choice
    call AS_Preview(p)
endfunction

function AS_Browse takes integer p, integer delta returns nothing
    if TimerGetElapsed(udg_AS_Clock) < udg_AS_NextInput[p] then
        return
    endif
    set udg_AS_NextInput[p] = TimerGetElapsed(udg_AS_Clock) + 0.18
    if delta == 0 then
        call AS_Choose(p,GetRandomInt(0,33))
    else
        call AS_Choose(p,ModuloInteger(udg_AS_Choice[p]+delta+34,34))
    endif
endfunction

function AS_FlushInputs takes nothing returns nothing
    local integer p = 0
    local integer action
    local integer page
    local boolean confirm
    loop
        exitwhen p == 12 or not udg_AS_Running
        set action = udg_AS_Pending[p]
        set udg_AS_Pending[p] = 0
        set confirm = udg_AS_PendingConfirm[p]
        set udg_AS_PendingConfirm[p] = false
        if AS_Active(p) and not udg_AS_Ready[p] then
            if action >= 1 and action <= 34 then
                call AS_Choose(p,action-1)
            elseif action == 101 or action == 102 then
                set page = udg_AS_Choice[p] / 8
                if action == 101 then
                    set page = ModuloInteger(page+4,5)
                else
                    set page = ModuloInteger(page+1,5)
                endif
                call AS_Choose(p,page*8)
            elseif action == 103 then
                call AS_Browse(p,0)
            elseif action == 105 then
                call AS_Browse(p,-1)
            elseif action == 106 then
                call AS_Browse(p,1)
            endif
            if confirm then
                call AS_Confirm(p)
            endif
        endif
        set p = p + 1
    endloop
endfunction

function AS_Spell takes nothing returns nothing
    local unit caster = GetTriggerUnit()
    local integer p = GetPlayerId(GetOwningPlayer(caster))
    local integer spell = GetSpellAbilityId()
    local integer n = 0
    if p < 0 or p >= 12 or not udg_AS_Running or not AS_Active(p) or udg_AS_Ready[p] or caster != udg_AS_Control[p] then
        set caster = null
        return
    endif
    loop
        exitwhen n == 34
        if spell == udg_AS_RaceAbility[n] then
            set udg_AS_Pending[p] = n+1
            set caster = null
            return
        endif
        set n = n+1
    endloop
    if spell == 'qPrv' then
        set udg_AS_Pending[p] = 101
    elseif spell == 'qNxt' then
        set udg_AS_Pending[p] = 102
    elseif spell == 'qRnd' then
        set udg_AS_Pending[p] = 103
    elseif spell == 'qPck' then
        set udg_AS_PendingConfirm[p] = true
    endif
    // The caster is replaced only from AS_FlushInputs, after the native spell
    // callback has returned. No unit/UI teardown inside the cast stack.
    set caster = null
endfunction

function AS_Key takes nothing returns nothing
    local integer p = GetPlayerId(GetTriggerPlayer())
    if not udg_AS_Running or udg_AS_Ready[p] then
        return
    endif
    if GetTriggerEventId() == EVENT_PLAYER_ARROW_LEFT_DOWN then
        set udg_AS_Pending[p] = 105
    elseif GetTriggerEventId() == EVENT_PLAYER_ARROW_RIGHT_DOWN then
        set udg_AS_Pending[p] = 106
    elseif GetTriggerEventId() == EVENT_PLAYER_ARROW_DOWN_DOWN then
        set udg_AS_Pending[p] = 103
    elseif GetTriggerEventId() == EVENT_PLAYER_ARROW_UP_DOWN then
        set udg_AS_PendingConfirm[p] = true
    endif
endfunction

function AS_Leave takes nothing returns nothing
    local integer p = GetPlayerId(GetTriggerPlayer())
    if udg_AS_Running and udg_AS_Entered[p] then
        set udg_AS_Ready[p] = true
        call AS_RemoveActors(p)
        if AS_AllReady() then
            call AS_Finish()
        endif
    endif
endfunction

function AS_Tick takes nothing returns nothing
    local integer p = 0
    if not udg_AS_Running then
        return
    endif
    set udg_AS_Remaining = udg_AS_Remaining - 1
    if udg_AS_Remaining <= 0 then
        loop
            exitwhen p == 12 or not udg_AS_Running
            if AS_Active(p) and not udg_AS_Ready[p] then
                call AS_Confirm(p)
            endif
            set p = p + 1
        endloop
    elseif AS_AllReady() then
        call AS_Finish()
    endif
endfunction

function AS_CameraTick takes nothing returns nothing
    local integer p = 0
    loop
        exitwhen p == 12
        if udg_AS_Entered[p] and AS_Active(p) then
            call AS_Camera(p)
        endif
        set p = p + 1
    endloop
endfunction

function AS_FindSelector takes integer p returns nothing
    local group scan = CreateGroup()
    local unit u
    call GroupEnumUnitsOfPlayer(scan,Player(p),null)
    loop
        set u = FirstOfGroup(scan)
        exitwhen u == null
        call GroupRemoveUnit(scan,u)
        if GetUnitTypeId(u) == 'n00B' then
            set udg_AS_Selector[p] = u
            set udg_AS_SpawnX[p] = GetUnitX(u)
            set udg_AS_SpawnY[p] = GetUnitY(u)
        endif
    endloop
    call DestroyGroup(scan)
    set scan = null
    set u = null
endfunction

function AS_SetupPlayer takes integer p returns nothing
    local integer n = 0
    local real angle
    local real x
    local real y
    set udg_AS_Entered[p] = true
    set udg_AS_Choice[p] = 9
    set udg_AS_Actors[p] = CreateGroup()
    set udg_AS_Workers[p] = CreateGroup()
    set udg_AS_StageOffset[p] = udg_AS_StageZ[p]-AS_Ground(udg_AS_StageX[p]+200,udg_AS_StageY[p]-600)
    set udg_AS_SpawnX[p] = GetStartLocationX(GetPlayerStartLocation(Player(p)))
    set udg_AS_SpawnY[p] = GetStartLocationY(GetPlayerStartLocation(Player(p)))
    call AS_FindSelector(p)
    loop
        exitwhen n == 24
        set angle = I2R(n)*15*bj_DEGTORAD
        set x = udg_AS_StageX[p] + Cos(angle)*1450
        set y = udg_AS_StageY[p] + Sin(angle)*1150
        set udg_AS_Tree[udg_AS_TreeCount] = CreateDestructableZ('LTlt',x,y,udg_AS_StageZ[p],I2R(n)*39,1.05,ModuloInteger(n,4))
        set udg_AS_TreeCount = udg_AS_TreeCount + 1
        set n = n + 1
    endloop
    if GetLocalPlayer() == Player(p) then
        call EnableUserControl(true)
        call EnableUserUI(true)
        call ShowInterface(true,0)
        call EnableSelect(true,true)
    endif
    call AS_Camera(p)
    call AS_Preview(p)
endfunction

function AS_SetupNext takes nothing returns nothing
    local integer p = udg_AS_SetupIndex
    if p < 12 then
        if AS_Active(p) then
            call AS_SetupPlayer(p)
        endif
        set udg_AS_SetupIndex = p + 1
        call TimerStart(udg_AS_SetupTimer,0.03,false,function AS_SetupNext)
    else
        set udg_AS_Running = true
        call TimerStart(udg_AS_InputTimer,0.03,true,function AS_FlushInputs)
        call TimerStart(udg_AS_Deadline,90,false,null)
        call TimerDialogDisplay(udg_AS_Countdown,true)
        call TimerStart(udg_AS_TickTimer,1,true,function AS_Tick)
        call TimerStart(udg_AS_CameraTimer,0.05,true,function AS_CameraTick)
        if AS_AllReady() then
            call AS_Finish()
        endif
    endif
endfunction

function AS_Bootstrap takes nothing returns nothing
    local trigger keys = CreateTrigger()
    local trigger leaving = CreateTrigger()
    local integer p = 0
    local rect world = GetWorldBounds()
    set udg_AS_State = InitHashtable()
    set udg_AS_World = CreateGroup()
    call GroupEnumUnitsInRect(udg_AS_World,world,null)
    call RemoveRect(world)
    call ForGroup(udg_AS_World,function AS_PauseWorldUnit)
    call AS_FreezeOriginals()
    set udg_AS_WasFog = IsFogEnabled()
    set udg_AS_WasFogMask = IsFogMaskEnabled()
    call FogEnable(false)
    call FogMaskEnable(false)
    call AS_InitCatalog()
    set udg_AS_Remaining = 90
    set udg_AS_Clock = CreateTimer()
    set udg_AS_SetupTimer = CreateTimer()
    set udg_AS_TickTimer = CreateTimer()
    set udg_AS_CameraTimer = CreateTimer()
    set udg_AS_InputTimer = CreateTimer()
    set udg_AS_Deadline = CreateTimer()
    set udg_AS_Countdown = CreateTimerDialog(udg_AS_Deadline)
    call TimerDialogSetTitle(udg_AS_Countdown,"Выбор расы")
    call TimerDialogSetTimeColor(udg_AS_Countdown,240,206,110,255)
    call TimerStart(udg_AS_Clock,86400,false,null)
    set udg_AS_Spells = CreateTrigger()
    call TriggerAddAction(udg_AS_Spells,function AS_Spell)
    call TriggerAddAction(keys,function AS_Key)
    call TriggerAddAction(leaving,function AS_Leave)
    loop
        exitwhen p == 12
        call TriggerRegisterPlayerUnitEvent(udg_AS_Spells,Player(p),EVENT_PLAYER_UNIT_SPELL_EFFECT,null)
        call TriggerRegisterPlayerEvent(keys,Player(p),EVENT_PLAYER_ARROW_LEFT_DOWN)
        call TriggerRegisterPlayerEvent(keys,Player(p),EVENT_PLAYER_ARROW_RIGHT_DOWN)
        call TriggerRegisterPlayerEvent(keys,Player(p),EVENT_PLAYER_ARROW_DOWN_DOWN)
        call TriggerRegisterPlayerEvent(keys,Player(p),EVENT_PLAYER_ARROW_UP_DOWN)
        call TriggerRegisterPlayerEvent(leaving,Player(p),EVENT_PLAYER_LEAVE)
        set p = p + 1
    endloop
    call TimerStart(udg_AS_SetupTimer,0.03,false,function AS_SetupNext)
    set keys = null
    set leaving = null
    set world = null
endfunction

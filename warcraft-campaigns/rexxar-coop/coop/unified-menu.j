function UM_Refresh takes nothing returns nothing
    local integer p=0
    local integer r
    local string state
    call LeaderboardClear(UM_board)
    call LeaderboardSetLabel(UM_board,UM_actTitle[RC_act[RC_map]]+" • "+RC_difficultyName[RC_difficulty])
    loop
        exitwhen p==4
        set r=UZ_playerClass[p]
        if r>=0 then
            if UM_ready[p] then
                set state=" [ГОТОВ]"
            else
                set state=" [выбирает]"
            endif
            call LeaderboardAddItem(UM_board,GetPlayerName(Player(p))+": "+RC_heroName[r]+state,0,Player(p))
        endif
        set p=p+1
    endloop
endfunction

function UM_Info takes integer p returns nothing
    if UZ_playerClass[p]>=0 then
        set UM_details[p]=true
        call UM_Replace(p)
    endif
endfunction

function UM_Replace takes integer p returns nothing
    local integer r=UZ_playerClass[p]
    local integer i=0
    if UM_unit[p]!=null then
        call RemoveUnit(UM_unit[p])
    endif
    set UM_unit[p]=CreateUnit(Player(p),UM_unitType[r],UZ_startX[0]+p*160,UZ_startY[0],270)
    call UnitRemoveAbility(UM_unit[p],'Amov')
    call UnitRemoveAbility(UM_unit[p],'Aatk')
    call SetUnitPathing(UM_unit[p],false)
    if UM_details[p] then
        loop
            exitwhen i==12
            call UnitRemoveAbility(UM_unit[p],UM_ability[i])
            set i=i+1
        endloop
        set i=0
        loop
            exitwhen i==4
            call UnitAddAbility(UM_unit[p],UM_detailAbility[r*4+i])
            set i=i+1
        endloop
        call UnitAddAbility(UM_unit[p],UM_backAbility)
    endif
    if GetLocalPlayer()==Player(p) then
        call ClearSelection()
        call SelectUnit(UM_unit[p],true)
        call SetCameraPosition(GetUnitX(UM_unit[p]),GetUnitY(UM_unit[p]))
        call SetCameraField(CAMERA_FIELD_TARGET_DISTANCE,900,0)
        call SetCineFilterTexture(UM_panel[r])
        call SetCineFilterBlendMode(BLEND_MODE_BLEND)
        call SetCineFilterTexMapFlags(TEXMAP_FLAG_NONE)
        call SetCineFilterStartUV(0,0,1,1)
        call SetCineFilterEndUV(0,0,1,1)
        call SetCineFilterStartColor(255,255,255,255)
        call SetCineFilterEndColor(255,255,255,255)
        call SetCineFilterDuration(0)
        call DisplayCineFilter(true)
    endif
endfunction

function UM_Choose takes integer p, integer role returns nothing
    local integer old=UZ_playerClass[p]
    local integer other=UZ_classPlayer[role]
    if RC_checkpointLoaded then
        call RC_Tell(Player(p),10,"После загрузки кода герой закреплён. Для новой игры ведущему: -reset.")
        return
    endif
    if other>=0 and other!=p and UM_ready[other] then
        call RC_Tell(Player(p),8,"Этот герой уже подтверждён другим игроком.")
        return
    endif
    call UM_StopDemo(p)
    if other>=0 and other!=p then
        call UM_StopDemo(other)
    endif
    set UM_ready[p]=false
    set UM_details[p]=false
    set UZ_classPlayer[old]=other
    set UZ_classPlayer[role]=p
    set UZ_playerClass[p]=role
    if other>=0 and other!=p then
        set UZ_playerClass[other]=old
        set UM_ready[other]=false
        call UM_Replace(other)
    endif
    set RC_host=UZ_playerClass[UM_hostColor]
    call UM_Replace(p)
endfunction

function UM_AfterLoad takes nothing returns nothing
    local integer p=0
    // A newly accepted save changes the chapter/difficulty for the whole
    // party. Old ready votes and rehearsal actors must not carry across.
    loop
        exitwhen p==4
        call UM_StopDemo(p)
        set UM_ready[p]=false
        set p=p+1
    endloop
    set UM_act=RC_act[RC_map]-1
    call UM_Refresh()
endfunction

function UM_Input takes nothing returns nothing
    local integer p=0
    local integer action
    local integer j
    local integer r
    local boolean allReady=true
    set UM_scheduled=false
    if RC_started then
        return
    endif
    loop
        exitwhen p==4
        set action=UM_pending[p]
        set UM_pending[p]=0
        if action>0 and UZ_playerClass[p]>=0 then
            if action<=4 then
                call UM_Choose(p,action-1)
            elseif action<=8 then
                if p!=UM_hostColor then
                    call RC_Tell(Player(p),6,"Сложность и акт выбирает ведущий.")
                elseif RC_checkpointLoaded then
                    call RC_Tell(Player(p),8,"Сложность и локация загружены из кода. Новая игра: -reset.")
                else
                    if action<=7 then
                        set RC_difficulty=action-5
                    else
                        set UM_act=ModuloInteger(UM_act+1,3)
                        if UM_act==0 then
                            set RC_map=0
                            set RC_defaultLevel=2
                        elseif UM_act==1 then
                            set RC_map=5
                            set RC_defaultLevel=8
                        else
                            set RC_map=15
                            set RC_defaultLevel=12
                        endif
                        set RC_sourceMap=RC_map
                        set RC_nextMap=RC_map
                    endif
                    set j=0
                    loop
                        exitwhen j==4
                        set UM_ready[j]=false
                        set j=j+1
                    endloop
                    call RC_Say(UM_actTitle[RC_act[RC_map]]+", "+RC_difficultyName[RC_difficulty]+". Подтвердите готовность (V).")
                endif
            elseif action==9 then
                call RC_Tell(Player(p),25,"Q/W/E/R — герой; A/S/D — сложность; F — акт. V — готовность. Между локациями отряд переходит вместе без перезапуска. Сохранение на другую игровую сессию: -save; загрузка до старта: -load КОД. K — навыки, T — таланты.")
            elseif action==10 then
                call UM_Info(p)
            elseif action==11 then
                call RC_Tell(Player(p),25,"Продолжение: выбери своего героя (Q/W/E/R), затем напиши -load КОД. Все вводят коды одного сохранения; потом V. Локация и сложность выбираются из сохранения автоматически.")
            elseif action==12 then
                set UM_ready[p]=not UM_ready[p]
            elseif action==13 then
                call UM_StopDemo(p)
                set UM_details[p]=false
                call UM_Replace(p)
            elseif action>=14 and action<=17 then
                call UM_StartDemo(p,action-14)
            endif
        endif
        if UZ_playerClass[p]>=0 and not UM_ready[p] then
            set allReady=false
        endif
        set p=p+1
    endloop
    call UM_Refresh()
    if allReady then
        call RC_Begin()
    endif
endfunction

function UM_Spell takes nothing returns nothing
    local integer p=GetPlayerId(GetTriggerPlayer())
    local integer i=0
    if RC_started or p<0 or p>=4 or GetTriggerUnit()!=UM_unit[p] then
        return
    endif
    if UM_details[p] then
        if GetSpellAbilityId()==UM_backAbility then
            set UM_pending[p]=13
        else
            loop
                exitwhen i==4
                if GetSpellAbilityId()==UM_detailAbility[UZ_playerClass[p]*4+i] then
                    set UM_pending[p]=14+i
                    exitwhen true
                endif
                set i=i+1
            endloop
        endif
        if UM_pending[p]>0 and not UM_scheduled then
            set UM_scheduled=true
            call TimerStart(UM_inputClock,0.05,false,function UM_Input)
        endif
        return
    endif
    loop
        exitwhen i==12
        if GetSpellAbilityId()==UM_ability[i] then
            set UM_pending[p]=i+1
            if not UM_scheduled then
                set UM_scheduled=true
                call TimerStart(UM_inputClock,0.05,false,function UM_Input)
            endif
            return
        endif
        set i=i+1
    endloop
endfunction

function UM_KeepSelection takes nothing returns nothing
    local integer p=0
    if RC_started then
        return
    endif
    loop
        exitwhen p==4
        if UZ_playerClass[p]>=0 and GetLocalPlayer()==Player(p) then
            if not IsUnitSelected(UM_unit[p],Player(p)) then
                call ClearSelection()
                call SelectUnit(UM_unit[p],true)
            endif
        endif
        set p=p+1
    endloop
endfunction

function UM_Close takes nothing returns nothing
    local integer p=0
    call PauseTimer(UM_clock)
    call PauseTimer(UM_inputClock)
    call PauseTimer(UM_demoClock)
    call LeaderboardDisplay(UM_board,false)
    call DisplayCineFilter(false)
    loop
        exitwhen p==4
        call UM_StopDemo(p)
        if UM_unit[p]!=null then
            call RemoveUnit(UM_unit[p])
            set UM_unit[p]=null
        endif
        set p=p+1
    endloop
endfunction

function UM_Open takes nothing returns nothing
    local trigger t=CreateTrigger()
    local integer p=0
    set UM_board=CreateLeaderboard()
    set UM_clock=CreateTimer()
    set UM_inputClock=CreateTimer()
    set UM_demoClock=CreateTimer()
    loop
        exitwhen p==4
        if UZ_playerClass[p]>=0 then
            call TriggerRegisterPlayerUnitEvent(t,Player(p),EVENT_PLAYER_UNIT_SPELL_EFFECT,null)
            call PlayerSetLeaderboard(Player(p),UM_board)
            call UM_Replace(p)
        endif
        set p=p+1
    endloop
    call TriggerAddAction(t,function UM_Spell)
    call UM_Refresh()
    call LeaderboardDisplay(UM_board,true)
    call TimerStart(UM_clock,0.35,true,function UM_KeepSelection)
    call TimerStart(UM_demoClock,0.1,true,function UM_DemoTick)
    call RC_Say("Выберите героя обычными кнопками Q/W/E/R. Ведущий: A/S/D — сложность, F — акт. Всем V — готовность. Один игрок должен взять Рексара. Наведите мышь на кнопки для описаний.")
    set t=null
endfunction

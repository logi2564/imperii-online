// Rehearsals call the actual skill mechanics, with progress kept untouched.
function UM_RemoveDemoUnit takes nothing returns nothing
    local unit u=GetEnumUnit()
    if u!=UM_unit[UM_demoOwner] then
        call GroupRemoveUnit(RC_damageUnits,u)
        call FlushChildHashtable(RC_table,GetHandleId(u))
        call RemoveUnit(u)
    endif
    set u=null
endfunction

function UM_StopDemo takes integer p returns nothing
    local integer slot=1
    local integer role=UM_demoRole[p]
    local group scan
    if UM_demoHero[p]==null then
        return
    endif
    loop
        exitwhen slot>64
        if RK_kind[slot]!=0 and RK_caster[slot]==UM_demoHero[p] then
            call RK_End(slot)
        endif
        set slot=slot+1
    endloop
    set UM_demoOwner=p
    set scan=CreateGroup()
    call GroupEnumUnitsOfPlayer(scan,Player(p),null)
    call ForGroup(scan,function UM_RemoveDemoUnit)
    call DestroyGroup(scan)
    call ForGroup(UM_demoEnemies[p],function UM_RemoveDemoUnit)
    call DestroyGroup(UM_demoEnemies[p])
    set UM_demoEnemies[p]=null
    call DestroyTrigger(UM_demoDamage[p])
    set UM_demoDamage[p]=null
    if RC_hero[role]==UM_demoHero[p] then
        set RC_hero[role]=null
    endif
    set UM_demoHero[p]=null
    set UM_demoCount=UM_demoCount-1
    set RC_training=UM_demoCount>0
    if role==0 then
        set RC_huntTarget=null
        set RC_huntUntil=0
    endif
    if not RC_started and GetLocalPlayer()==Player(p) and UM_unit[p]!=null then
        call SetCameraPosition(GetUnitX(UM_unit[p]),GetUnitY(UM_unit[p]))
        call SetCameraField(CAMERA_FIELD_TARGET_DISTANCE,900,0)
        call DisplayCineFilter(true)
    endif
    set scan=null
endfunction

function UM_StartDemo takes integer p, integer skill returns nothing
    local integer role=UZ_playerClass[p]
    local integer n=0
    local unit enemy
    local unit hero
    if RC_started or role<0 or skill<0 or skill>3 then
        return
    endif
    call UM_StopDemo(p)
    set UM_ready[p]=false
    set UM_demoRole[p]=role
    set UM_demoSkill[p]=skill
    set UM_demoAge[p]=0
    set UM_demoCast[p]=false
    set UM_demoHit[p]=false
    set UM_demoEnemies[p]=CreateGroup()
    set hero=CreateUnit(Player(p),RC_heroType[role],UM_stageX[p]-250,UM_stageY[p],0)
    set UM_demoHero[p]=hero
    set RC_hero[role]=hero
    set UM_demoCount=UM_demoCount+1
    set RC_training=true
    call SetHeroLevel(hero,20,false)
    call UnitModifySkillPoints(hero,-GetHeroSkillPoints(hero))
    call UnitRemoveAbility(hero,'Aatk')
    call SetUnitPathing(hero,false)
    call SetWidgetLife(hero,GetUnitState(hero,UNIT_STATE_MAX_LIFE)*0.45)
    call UnitAddAbility(hero,RC_skill[role*5+skill])
    call SetUnitAbilityLevel(hero,RC_skill[role*5+skill],3)
    // These registrations end with the rehearsal, rather than accumulating
    // removed hero handles on the campaign's permanent damage trigger.
    set UM_demoDamage[p]=CreateTrigger()
    call TriggerRegisterUnitEvent(UM_demoDamage[p],hero,EVENT_UNIT_DAMAGED)
    call TriggerAddAction(UM_demoDamage[p],function RC_Damaged)
    loop
        exitwhen n==3
        set enemy=CreateUnit(Player(12),'hfoo',UM_stageX[p]+160,UM_stageY[p]+(n-1)*140,180)
        call SetUnitPathing(enemy,false)
        call GroupAddUnit(UM_demoEnemies[p],enemy)
        call SetPlayerAlliance(Player(p),Player(12),ALLIANCE_PASSIVE,false)
        call SetPlayerAlliance(Player(12),Player(p),ALLIANCE_PASSIVE,false)
        if role==3 then
            call IssueTargetOrder(enemy,"attack",hero)
        else
            call PauseUnit(enemy,true)
        endif
        set n=n+1
    endloop
    if GetLocalPlayer()==Player(p) then
        call DisplayCineFilter(false)
        call SetCameraPosition(UM_stageX[p],UM_stageY[p])
        call SetCameraField(CAMERA_FIELD_TARGET_DISTANCE,1500,0)
    endif
    call RC_Tell(Player(p),10,"Показ: "+RC_skillName[role*5+skill]+" (ранг 3). Q/W/E/R — другой приём, B — назад. Прогресс отряда не меняется.")
    set hero=null
    set enemy=null
endfunction

function UM_DemoTick takes nothing returns nothing
    local integer p=0
    local integer role
    local integer skill
    local unit target
    if RC_started then
        return
    endif
    loop
        exitwhen p==4
        if UM_demoHero[p]!=null then
            set UM_demoAge[p]=UM_demoAge[p]+0.1
            set role=UM_demoRole[p]
            set skill=UM_demoSkill[p]
            if not UM_demoCast[p] and UM_demoAge[p]>=0.3 then
                set UM_demoCast[p]=true
                set target=FirstOfGroup(UM_demoEnemies[p])
                if role==1 then
                    set target=UM_demoHero[p]
                endif
                call SetUnitAnimation(UM_demoHero[p],"spell")
                call RK_Cast(UM_demoHero[p],target,RC_skill[role*5+skill],UM_stageX[p]+160,UM_stageY[p])
            endif
            if not UM_demoHit[p] and UM_demoAge[p]>=2 then
                set UM_demoHit[p]=true
                if (role==1 and skill==2) or (role==3 and skill==2) then
                    set target=FirstOfGroup(UM_demoEnemies[p])
                    if role==1 then
                        call UnitDamageTarget(target,UM_demoHero[p],GetUnitState(UM_demoHero[p],UNIT_STATE_MAX_LIFE)*3,false,false,ATTACK_TYPE_CHAOS,DAMAGE_TYPE_UNIVERSAL,WEAPON_TYPE_WHOKNOWS)
                    else
                        call UnitDamageTarget(target,UM_demoHero[p],120,false,false,ATTACK_TYPE_CHAOS,DAMAGE_TYPE_UNIVERSAL,WEAPON_TYPE_WHOKNOWS)
                    endif
                endif
            endif
            if UM_demoAge[p]>=10 then
                call UM_StopDemo(p)
            endif
        endif
        set p=p+1
    endloop
    if RC_training then
        call RK_Tick()
    endif
    set target=null
endfunction

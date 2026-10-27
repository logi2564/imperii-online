// Four heroes always exist, even when absent players' heroes belong to host.
// Max life is changed on actual units; no >100% player handicap is assumed.
function RC_EnemyUnit takes unit u returns boolean
    return RK_Alive(u) and not RC_IsPartyPlayer(GetOwningPlayer(u)) and IsUnitEnemy(u, RC_Player(0)) and GetUnitAbilityLevel(u, 'Aloc') == 0
endfunction

function RC_ScaleLife takes unit u returns nothing
    local integer bits = LoadInteger(RC_table, GetHandleId(u), 410)
    local integer oldBits = bits
    local integer desired = 0
    local integer bit = 0
    local real bonus = 0
    local real base
    local real fraction
    // The previous bonus is stored separately from actual max life, preserving
    // source handicap, hero attribute growth and the current HP fraction.
    if oldBits > 0 then
        set bonus = (oldBits - 1) * 25.0
    endif
    set base = GetUnitState(u, UNIT_STATE_MAX_LIFE) - bonus
    set fraction = GetWidgetLife(u) / GetUnitState(u, UNIT_STATE_MAX_LIFE)
    if RC_EnemyUnit(u) then
        set desired = R2I(base * (RC_enemyLife - 1.0) / 25.0 + 0.5)
        if desired > 65535 then
            set desired = 65535
        endif
    endif
    if oldBits == desired + 1 then
        return
    endif
    set bits = oldBits - 1
    if bits < 0 then
        set bits = 0
    endif
    loop
        exitwhen bit == 16
        if ModuloInteger(bits, 2) == 1 then
            call UnitRemoveAbility(u, RC_hpBit[bit])
        endif
        set bits = bits / 2
        set bit = bit + 1
    endloop
    set bits = desired
    set bit = 0
    loop
        exitwhen bit == 16
        if ModuloInteger(bits, 2) == 1 then
            call UnitAddAbility(u, RC_hpBit[bit])
        endif
        set bits = bits / 2
        set bit = bit + 1
    endloop
    call SaveInteger(RC_table, GetHandleId(u), 410, desired + 1)
    call SetWidgetLife(u, GetUnitState(u, UNIT_STATE_MAX_LIFE) * fraction)
endfunction

function RC_Damaged takes nothing returns nothing
    local unit victim = GetTriggerUnit()
    local unit source = GetEventDamageSource()
    local real amount = GetEventDamage()
    local real scaled = amount
    local integer slot = 1
    if RC_damageBusy or amount <= 0 or source == null or not RC_started or RC_transitionPending then
        set victim = null
        set source = null
        return
    endif
    if RC_EnemyUnit(source) and RC_IsPartyPlayer(GetOwningPlayer(victim)) then
        set scaled = amount * RC_enemyDamage
        if RC_enemyDamage > 1 then
            // Damage event has already applied armour/resistance to amount.
            // Add only the difference with universal damage, once, recursively guarded.
            set RC_damageBusy = true
            call UnitDamageTarget(source, victim, scaled - amount, false, false, ATTACK_TYPE_CHAOS, DAMAGE_TYPE_UNIVERSAL, WEAPON_TYPE_WHOKNOWS)
            set RC_damageBusy = false
        endif
    endif
    loop
        exitwhen slot > 64
        if RK_kind[slot] == 15 and RK_caster[slot] == victim and source != victim then
            set RK_value[slot] = RK_value[slot] + scaled
        endif
        set slot = slot + 1
    endloop
    set victim = null
    set source = null
endfunction

function RC_BalanceScan takes nothing returns nothing
    local integer owners = 0
    local integer processed = 0
    local unit u
    // At most 64 units and four owner enumerations per callback. Keep the
    // pending group for the next callback instead of a giant loading loop.
    loop
        exitwhen processed >= 64 or owners >= 4
        set u = FirstOfGroup(RC_balanceGroup)
        if u == null then
            call GroupEnumUnitsOfPlayer(RC_balanceGroup, Player(RC_scanOwner), null)
            set RC_scanOwner = ModuloInteger(RC_scanOwner + 1, 16)
            set owners = owners + 1
            set u = FirstOfGroup(RC_balanceGroup)
        endif
        if u != null then
            call GroupRemoveUnit(RC_balanceGroup, u)
            if GetUnitAbilityLevel(u, 'Aloc') == 0 and RK_Alive(u) then
                if not IsUnitType(u, UNIT_TYPE_SUMMONED) then
                    call RC_ScaleLife(u)
                endif
                if RC_IsPartyPlayer(GetOwningPlayer(u)) and not IsUnitInGroup(u, RC_damageUnits) then
                    call GroupAddUnit(RC_damageUnits, u)
                    call TriggerRegisterUnitEvent(RC_damageTrigger, u, EVENT_UNIT_DAMAGED)
                endif
            endif
            set processed = processed + 1
        endif
    endloop
    set u = null
endfunction

function RC_Balance takes nothing returns nothing
    local integer role = 0
    if RC_difficulty == 0 then
        set RC_enemyLife = 2.5
        set RC_enemyDamage = 1.0
    elseif RC_difficulty == 1 then
        set RC_enemyLife = 4.5
        set RC_enemyDamage = 1.5
    else
        set RC_enemyLife = 6.5
        set RC_enemyDamage = 2.0
    endif
    if RC_map == 16 then
        // Final map already has four Horde armies rather than four lone heroes.
        set RC_enemyLife = 1.4 + RC_difficulty * 0.7
        set RC_enemyDamage = 1.0 + RC_difficulty * 0.3
    endif
    loop
        exitwhen role == 4
        call SetPlayerHandicapXP(RC_Player(role), RC_xpRate)
        call SetPlayerState(RC_Player(role), PLAYER_STATE_RESOURCE_FOOD_CAP, 100)
        if not IsUnitInGroup(RC_hero[role], RC_damageUnits) then
            call GroupAddUnit(RC_damageUnits, RC_hero[role])
            call TriggerRegisterUnitEvent(RC_damageTrigger, RC_hero[role], EVENT_UNIT_DAMAGED)
        endif
        set role = role + 1
    endloop
    call TimerStart(RC_balanceTimer, 0.25, true, function RC_BalanceScan)
    call RC_Say("Баланс на четырёх героев: " + RC_difficultyName[RC_difficulty] + ". Здоровье врагов ×" + R2SW(RC_enemyLife, 1, 1) + ", урон ×" + R2SW(RC_enemyDamage, 1, 1) + ". Опыт и общие награды делятся.")
endfunction

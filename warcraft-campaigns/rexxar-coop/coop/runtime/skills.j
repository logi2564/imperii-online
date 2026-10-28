// Independent cast slots: two zones/projectiles never overwrite one another.
// These mechanics use only classic 1.26 APIs and built-in effect resources.
function RK_ExpireVisual takes nothing returns nothing
    local timer clock = GetExpiredTimer()
    local integer key = GetHandleId(clock)
    local effect visual = LoadEffectHandle(RC_table,key,901)
    call DestroyEffect(visual)
    call FlushChildHashtable(RC_table,key)
    call DestroyTimer(clock)
    set visual = null
    set clock = null
endfunction

function RK_KeepVisual takes effect visual, real duration returns nothing
    local timer clock = CreateTimer()
    // Missile/impact models without a death sequence disappeared when their
    // effect was destroyed on the same tick it was created.
    call SaveEffectHandle(RC_table,GetHandleId(clock),901,visual)
    call TimerStart(clock,duration,false,function RK_ExpireVisual)
    set clock = null
endfunction

function RK_Alive takes unit u returns boolean
    return u != null and GetUnitTypeId(u) != 0 and GetWidgetLife(u) > 0.405
endfunction

function RK_Enemy takes unit caster, unit u returns boolean
    return RK_Alive(u) and not LoadBoolean(RC_table, GetHandleId(u), 700) and IsUnitEnemy(u, GetOwningPlayer(caster)) and GetUnitAbilityLevel(u, 'Aloc') == 0
endfunction

function RK_Heal takes unit u, real amount returns nothing
    if RK_Alive(u) then
        call SetWidgetLife(u, GetWidgetLife(u) + amount)
    endif
endfunction

function RK_Hit takes unit caster, unit u, real amount returns nothing
    if RK_Enemy(caster, u) then
        call UnitDamageTarget(caster, u, amount, false, false, ATTACK_TYPE_MAGIC, DAMAGE_TYPE_MAGIC, WEAPON_TYPE_WHOKNOWS)
    endif
endfunction

function RK_Debuff takes unit caster, unit target, boolean stun returns nothing
    local unit dummy
    if not RK_Enemy(caster, target) or IsUnitType(target, UNIT_TYPE_STRUCTURE) then
        return
    endif
    set dummy = CreateUnit(GetOwningPlayer(caster), 'rD40', GetUnitX(target), GetUnitY(target), 0)
    call UnitAddType(dummy, UNIT_TYPE_SUMMONED)
    if stun then
        if (caster == RC_hero[2] and RC_HasTalent(2, 2, 1)) or (caster == RC_hero[3] and RC_HasTalent(3, 2, 2)) then
            call UnitAddAbility(dummy, 'RSt2')
        else
            call UnitAddAbility(dummy, 'RStn')
        endif
        call IssueTargetOrder(dummy, "thunderbolt", target)
    else
        call UnitAddAbility(dummy, 'RSlw')
        call IssueTargetOrder(dummy, "slow", target)
    endif
    call UnitApplyTimedLife(dummy, 'BTLF', 1.5)
    set dummy = null
endfunction

function RK_Armor takes unit u, integer rank, integer delta returns nothing
    local integer count = LoadInteger(RC_table, GetHandleId(u), 500 + rank) + delta
    if count < 0 then
        set count = 0
    endif
    call SaveInteger(RC_table, GetHandleId(u), 500 + rank, count)
    if count > 0 then
        call UnitAddAbility(u, RC_armorId[rank])
    else
        call UnitRemoveAbility(u, RC_armorId[rank])
    endif
endfunction

function RK_Area takes unit caster, real x, real y, real radius, real amount, boolean stun, real wetBonus, boolean huntBonus returns nothing
    local unit u
    local real bonus
    call GroupEnumUnitsInRange(RC_skillGroup, x, y, radius, null)
    loop
        set u = FirstOfGroup(RC_skillGroup)
        exitwhen u == null
        call GroupRemoveUnit(RC_skillGroup, u)
        if RK_Enemy(caster, u) then
            set bonus = 1.0
            if LoadReal(RC_table, GetHandleId(u), 301) > RC_skillTime then
                set bonus = bonus + wetBonus
            endif
            if huntBonus and u == RC_huntTarget and RC_huntUntil > RC_skillTime then
                set bonus = bonus + 0.5
            endif
            call RK_Hit(caster, u, amount * bonus)
            if stun then
                call RK_Debuff(caster, u, true)
            endif
        endif
    endloop
endfunction

function RK_End takes integer slot returns nothing
    local unit u
    if RK_kind[slot] == 11 and GetUnitTypeId(RK_caster[slot]) != 0 then
        call PauseUnit(RK_caster[slot], false)
    endif
    if RK_kind[slot] == 14 or RK_kind[slot] == 16 then
        loop
            set u = FirstOfGroup(RK_hits[slot])
            exitwhen u == null
            call GroupRemoveUnit(RK_hits[slot], u)
            call RK_Armor(u, RK_rank[slot], -1)
        endloop
    endif
    if RK_kind[slot] == 14 then
        call UnitRemoveAbility(RK_caster[slot], 'R5Ar')
    endif
    call DestroyGroup(RK_hits[slot])
    call DestroyEffect(RK_visual[slot])
    call RemoveUnit(RK_marker[slot])
    set RK_hits[slot] = null
    set RK_visual[slot] = null
    set RK_marker[slot] = null
    set RK_caster[slot] = null
    set RK_target[slot] = null
    set RK_kind[slot] = 0
    set u = null
endfunction

function RK_New takes unit caster, integer kind, integer rank, real x, real y, real duration returns integer
    local integer slot = 1
    loop
        exitwhen slot > 64 or RK_kind[slot] == 0
        set slot = slot + 1
    endloop
    if slot > 64 then
        return 0
    endif
    set RK_kind[slot] = kind
    set RK_rank[slot] = rank
    set RK_caster[slot] = caster
    set RK_target[slot] = null
    set RK_x[slot] = x
    set RK_y[slot] = y
    set RK_age[slot] = 0
    set RK_limit[slot] = duration
    set RK_value[slot] = 0
    set RK_phase[slot] = 0
    set RK_hits[slot] = CreateGroup()
    return slot
endfunction

function RK_Marker takes integer slot, string model returns nothing
    set RK_marker[slot] = CreateUnit(GetOwningPlayer(RK_caster[slot]), 'rD40', RK_x[slot], RK_y[slot], 0)
    call UnitAddType(RK_marker[slot], UNIT_TYPE_SUMMONED)
    set RK_visual[slot] = AddSpecialEffectTarget(model, RK_marker[slot], "origin")
endfunction

function RK_Pet takes unit caster, integer rawId, real x, real y, integer rank, real seconds returns nothing
    local unit pet = CreateUnit(GetOwningPlayer(caster), rawId, x, y, GetUnitFacing(caster))
    local integer health = (90 + 50 * rank) / 25
    local integer bit = 0
    if RC_HasTalent(0, 0, 2) then
        set health = health + 8
    endif
    call UnitAddType(pet, UNIT_TYPE_SUMMONED)
    // Native companions have different base health; rank adds fixed bonus HP.
    loop
        exitwhen bit == 16
        if ModuloInteger(health, 2) == 1 then
            call UnitAddAbility(pet, RC_hpBit[bit])
        endif
        set health = health / 2
        set bit = bit + 1
    endloop
    call SetWidgetLife(pet, GetUnitState(pet, UNIT_STATE_MAX_LIFE))
    call UnitAddAbility(pet, 'RP00' + rank)
    if RC_HasTalent(0, 2, 1) then
        call UnitAddAbility(pet, 'R5Pd')
    endif
    call UnitApplyTimedLife(pet, 'BTLF', seconds)
    if RK_Alive(RC_huntTarget) and RC_huntUntil > RC_skillTime then
        call IssueTargetOrder(pet, "attack", RC_huntTarget)
    else
        call IssuePointOrder(pet, "attack", x + 250.0 * Cos(GetUnitFacing(caster) * bj_DEGTORAD), y + 250.0 * Sin(GetUnitFacing(caster) * bj_DEGTORAD))
    endif
    set pet = null
endfunction

function RK_Pulse takes integer slot, integer step returns nothing
    local integer kind = RK_kind[slot]
    local integer rank = RK_rank[slot]
    local unit caster = RK_caster[slot]
    local unit target = RK_target[slot]
    local unit u
    local integer n = 0
    local real x = RK_x[slot]
    local real y = RK_y[slot]
    local real amount
    local real dx
    local real dy
    local real distance
    local real radius = 450
    if kind == 6 then
        set radius = radius + RC_TalentBonus(1, 0, 2, 150)
    endif
    if kind == 3 then
        if not RK_Alive(target) then
            loop
                exitwhen n == 4
                if RC_hero[n] != null and IsUnitInRangeXY(RC_hero[n], x, y, 700) then
                    call RK_Heal(RC_hero[n], GetUnitState(RC_hero[n], UNIT_STATE_MAX_LIFE) * (0.12 + RC_TalentBonus(0, 1, 2, 0.12)))
                endif
                set n = n + 1
            endloop
            if RC_HasTalent(0, 3, 2) then
                call RK_Area(caster, x, y, 300, 120.0 + 8.0 * GetHeroLevel(caster), false, 0, false)
            endif
            set RK_age[slot] = RK_limit[slot]
        else
            set RK_x[slot] = GetUnitX(target)
            set RK_y[slot] = GetUnitY(target)
            if ModuloInteger(step, 10) == 0 then
                call RK_Hit(caster, target, (12.0 + 9.0 * rank) * (1.0 + RC_TalentBonus(0, 2, 2, 0.5)))
                call RK_Debuff(caster, target, false)
            endif
        endif
    elseif kind == 5 then
        if not RK_Alive(target) or not IsUnitInRange(caster, target, 1100) then
            set RK_age[slot] = RK_limit[slot]
        elseif ModuloInteger(step, 10) == 0 then
            call RK_Heal(target, (10.0 + 8.0 * rank) * (1.0 + RC_TalentBonus(1, 0, 1, 0.3)))
            call RK_KeepVisual(AddSpecialEffectTarget("Abilities\\Spells\\Orc\\HealingWave\\HealingWaveTarget.mdl", target, "origin"),0.5)
        endif
    elseif kind == 6 or kind == 8 or kind == 16 then
        if kind == 6 and not RK_Alive(RK_marker[slot]) then
            set RK_age[slot] = RK_limit[slot]
        else
            if ModuloInteger(step, 10) == 0 then
                set n = 0
                loop
                    exitwhen n == 4
                    set u = RC_hero[n]
                    if u != null and IsUnitInRangeXY(u, x, y, radius) then
                        if kind == 6 then
                            call RK_Heal(u, 12.0 + 9.0 * rank + RC_TalentBonus(1, 2, 1, 15))
                            call UnitRemoveBuffs(u, false, true)
                        elseif kind == 8 then
                            set amount = 18.0 + 17.0 * rank
                            if RC_HasTalent(1, 3, 2) and GetWidgetLife(u) < GetUnitState(u, UNIT_STATE_MAX_LIFE) * 0.35 then
                                set amount = amount * 1.4
                            endif
                            call RK_Heal(u, amount)
                        endif
                        if kind == 16 and RC_HasTalent(3, 3, 2) then
                            call RK_Heal(u, GetUnitState(u, UNIT_STATE_MAX_LIFE) * 0.015)
                        endif
                        if kind == 16 and not IsUnitInGroup(u, RK_hits[slot]) then
                            call GroupAddUnit(RK_hits[slot], u)
                            call RK_Armor(u, rank, 1)
                        endif
                    elseif kind == 16 and IsUnitInGroup(u, RK_hits[slot]) then
                        call GroupRemoveUnit(RK_hits[slot], u)
                        call RK_Armor(u, rank, -1)
                    endif
                    set n = n + 1
                endloop
                if kind == 6 and RC_HasTalent(1, 3, 1) then
                    call RK_Area(caster, x, y, radius, 20, false, 0, false)
                elseif kind == 8 then
                    call RK_Area(caster, x, y, 450, 18.0 + 17.0 * rank + RC_TalentBonus(1, 2, 2, 35), false, 0, false)
                elseif kind == 16 and ModuloInteger(step, 20) == 0 then
                    call RK_Area(caster, x, y, 450, 100.0 + 80.0 * rank, true, 0, false)
                    call DestroyEffect(AddSpecialEffect("Abilities\\Spells\\Orc\\WarStomp\\WarStompCaster.mdl", x, y))
                endif
            endif
        endif
    elseif kind == 7 then
        if RK_age[slot] + 0.001 >= RK_limit[slot] then
            if not RK_Alive(target) and GetUnitTypeId(target) != 0 then
                call ReviveHero(target, x, y, true)
                call SetWidgetLife(target, RK_value[slot])
            elseif RK_Alive(target) then
                call SetUnitPosition(target, x, y)
                call SetWidgetLife(target, RMaxBJ(GetWidgetLife(target), RK_value[slot]))
            endif
            if RC_HasTalent(1, 1, 2) then
                call SetUnitState(target, UNIT_STATE_MANA, RMinBJ(GetUnitState(target, UNIT_STATE_MAX_MANA), GetUnitState(target, UNIT_STATE_MANA) + GetUnitState(target, UNIT_STATE_MAX_MANA) * 0.25))
            endif
            call DestroyEffect(AddSpecialEffect("Abilities\\Spells\\Human\\MassTeleport\\MassTeleportTarget.mdl", x, y))
        endif
    elseif kind == 12 then
        set radius = 380 + RC_TalentBonus(2, 4, 1, 120)
        if ModuloInteger(step, 10) == 0 then
            call RK_Area(caster, x, y, radius, (18.0 + 17.0 * rank) * (1.0 + RC_TalentBonus(2, 3, 1, 0.25)), false, 0.5, false)
        endif
        call GroupEnumUnitsInRange(RC_skillGroup, x, y, radius, null)
        loop
            set u = FirstOfGroup(RC_skillGroup)
            exitwhen u == null
            call GroupRemoveUnit(RC_skillGroup, u)
            if RK_Enemy(caster, u) and not IsUnitType(u, UNIT_TYPE_HERO) and not IsUnitType(u, UNIT_TYPE_STRUCTURE) and not IsUnitPaused(u) and not IsUnitType(u, UNIT_TYPE_FLYING) then
                set dx = x - GetUnitX(u)
                set dy = y - GetUnitY(u)
                set distance = SquareRoot(dx * dx + dy * dy)
                if distance > 65 and not IsTerrainPathable(GetUnitX(u) + dx / distance * 12, GetUnitY(u) + dy / distance * 12, PATHING_TYPE_WALKABILITY) then
                    call SetUnitPosition(u, GetUnitX(u) + dx / distance * 12, GetUnitY(u) + dy / distance * 12)
                endif
            endif
        endloop
    elseif kind == 14 then
        if ModuloInteger(step, 10) == 0 then
            if RC_HasTalent(3, 2, 1) then
                call RK_Heal(caster, GetUnitState(caster, UNIT_STATE_MAX_LIFE) * 0.03)
            endif
            call GroupEnumUnitsInRange(RC_skillGroup, GetUnitX(caster), GetUnitY(caster), 420, null)
            loop
                set u = FirstOfGroup(RC_skillGroup)
                exitwhen u == null
                call GroupRemoveUnit(RC_skillGroup, u)
                if RK_Enemy(caster, u) and not IsUnitType(u, UNIT_TYPE_HERO) and not IsUnitType(u, UNIT_TYPE_STRUCTURE) and not IsUnitPaused(u) then
                    call IssueTargetOrder(u, "attack", caster)
                endif
            endloop
        endif
    elseif kind == 15 and RK_age[slot] + 0.001 >= RK_limit[slot] then
        set amount = RMinBJ(180.0 + 60.0 * rank, 60.0 + 12.0 * rank + RK_value[slot] * (0.35 + RC_TalentBonus(3, 1, 1, 0.15)))
        call RK_Heal(caster, amount)
        call RK_Area(caster, GetUnitX(caster), GetUnitY(caster), 330 + RC_TalentBonus(3, 3, 1, 150), amount, true, 0, false)
        if RC_HasTalent(3, 4, 2) then
            loop
                exitwhen n == 4
                if RC_hero[n] != null and RC_hero[n] != caster and IsUnitInRange(caster, RC_hero[n], 650) then
                    call RK_Heal(RC_hero[n], amount * 0.5)
                endif
                set n = n + 1
            endloop
        endif
        call DestroyEffect(AddSpecialEffectTarget("Abilities\\Spells\\Orc\\WarStomp\\WarStompCaster.mdl", caster, "origin"))
    endif
    set caster = null
    set target = null
    set u = null
endfunction

function RK_Move takes integer slot returns nothing
    local integer kind = RK_kind[slot]
    local unit caster = RK_caster[slot]
    local unit u
    local real x = RK_x[slot]
    local real y = RK_y[slot]
    local real dx = RK_dx[slot]
    local real dy = RK_dy[slot]
    local real amount = 35.0 + 25.0 * RK_rank[slot]
    local real distance
    local real radius = 140
    if kind == 1 then
        set amount = amount * (1.0 + RC_TalentBonus(0, 0, 1, 0.25))
    elseif kind == 13 then
        set amount = amount * (1.0 + RC_TalentBonus(3, 0, 1, 0.25))
        set radius = radius + RC_TalentBonus(3, 1, 2, 80)
    endif
    if kind == 1 and RK_phase[slot] == 1 then
        set dx = GetUnitX(caster) - x
        set dy = GetUnitY(caster) - y
        set distance = SquareRoot(dx * dx + dy * dy)
        if distance < 75 then
            set RK_age[slot] = RK_limit[slot]
            set caster = null
            return
        endif
        set dx = dx / distance
        set dy = dy / distance
    endif
    if kind == 11 then
        set distance = RMinBJ(42, RMaxBJ(0, (RK_limit[slot] - RK_age[slot] + 0.1) * 420))
        // Sample each 21 units; do not dash through a thin pathing wall.
        if IsTerrainPathable(x + dx * 21, y + dy * 21, PATHING_TYPE_WALKABILITY) or IsTerrainPathable(x + dx * distance, y + dy * distance, PATHING_TYPE_WALKABILITY) then
            set RK_age[slot] = RK_limit[slot]
            set caster = null
            return
        endif
        set x = x + dx * distance
        set y = y + dy * distance
        call SetUnitPosition(caster, x, y)
        set x = GetUnitX(caster)
        set y = GetUnitY(caster)
    else
        set distance = 70
        if kind == 10 then
            set distance = RMinBJ(70, RMaxBJ(0, (RK_limit[slot] - RK_age[slot] + 0.1) * 700))
        endif
        set x = x + dx * distance
        set y = y + dy * distance
        call SetUnitX(RK_marker[slot], x)
        call SetUnitY(RK_marker[slot], y)
    endif
    set RK_x[slot] = x
    set RK_y[slot] = y
    if kind == 10 then
        if RK_age[slot] + 0.001 >= RK_limit[slot] then
            call RK_Area(caster, x, y, 280 + RC_TalentBonus(2, 1, 1, 100), 90.0 + 50.0 * RK_rank[slot], false, 0.6, false)
            call GroupEnumUnitsInRange(RC_skillGroup, x, y, 280 + RC_TalentBonus(2, 1, 1, 100), null)
            loop
                set u = FirstOfGroup(RC_skillGroup)
                exitwhen u == null
                call GroupRemoveUnit(RC_skillGroup, u)
                if LoadReal(RC_table, GetHandleId(u), 301) > RC_skillTime then
                    call RK_Debuff(caster, u, true)
                endif
                if RC_HasTalent(2, 3, 2) and RK_Enemy(caster, u) then
                    call SaveReal(RC_table, GetHandleId(u), 301, RMaxBJ(LoadReal(RC_table, GetHandleId(u), 301), RC_skillTime + 4))
                endif
            endloop
            call DestroyEffect(AddSpecialEffect("Abilities\\Spells\\Other\\Incinerate\\FireLordDeathExplode.mdl", x, y))
        endif
    else
        call GroupEnumUnitsInRange(RC_skillGroup, x, y, radius, null)
        loop
            set u = FirstOfGroup(RC_skillGroup)
            exitwhen u == null
            call GroupRemoveUnit(RC_skillGroup, u)
            if RK_Enemy(caster, u) and not IsUnitInGroup(u, RK_hits[slot]) then
                call GroupAddUnit(RK_hits[slot], u)
                if kind == 1 and u == RC_huntTarget and RC_huntUntil > RC_skillTime then
                    call RK_Hit(caster, u, amount * 1.5)
                elseif kind == 11 and LoadReal(RC_table, GetHandleId(u), 301) > RC_skillTime then
                    call RK_Hit(caster, u, amount * 1.4)
                else
                    call RK_Hit(caster, u, amount)
                endif
                if kind == 11 and RC_HasTalent(2, 2, 2) and RK_value[slot] < 2 then
                    set RK_value[slot] = RK_value[slot] + 1
                    call RK_Heal(caster, GetUnitState(caster, UNIT_STATE_MAX_LIFE) * 0.08)
                endif
                if kind == 13 then
                    call RK_Debuff(caster, u, true)
                endif
            endif
        endloop
        if kind == 1 and RK_phase[slot] == 0 and RK_age[slot] + 0.001 >= 1 then
            set RK_phase[slot] = 1
            call GroupClear(RK_hits[slot])
        endif
    endif
    set caster = null
    set u = null
endfunction

function RK_Tick takes nothing returns nothing
    local integer slot = 1
    local integer step
    if (not RC_started and not RC_training) or RC_StoryCinematic() then
        return
    endif
    set RC_skillTime = RC_skillTime + 0.1
    loop
        exitwhen slot > 64
        if RK_kind[slot] != 0 then
            if RC_transitionPending or not RC_IsPartyPlayer(GetOwningPlayer(RK_caster[slot])) or GetUnitTypeId(RK_caster[slot]) == 0 or (not RK_Alive(RK_caster[slot]) and RK_kind[slot] != 7) then
                call RK_End(slot)
            else
                set RK_age[slot] = RK_age[slot] + 0.1
                set step = R2I(RK_age[slot] * 10 + 0.01)
                if RK_kind[slot] == 1 or RK_kind[slot] == 10 or RK_kind[slot] == 11 or RK_kind[slot] == 13 then
                    call RK_Move(slot)
                else
                    call RK_Pulse(slot, step)
                endif
                if RK_age[slot] + 0.001 >= RK_limit[slot] then
                    call RK_End(slot)
                endif
            endif
        endif
        set slot = slot + 1
    endloop
endfunction

function RK_Launch takes unit caster, integer kind, integer rank, real x, real y, real spread returns nothing
    local integer slot = RK_New(caster, kind, rank, GetUnitX(caster), GetUnitY(caster), 6)
    local real dx = x - GetUnitX(caster)
    local real dy = y - GetUnitY(caster)
    local real distance = SquareRoot(dx * dx + dy * dy)
    local real angle = Atan2(dy, dx) + spread
    if slot == 0 then
        return
    endif
    if distance < 1 then
        set angle = GetUnitFacing(caster) * bj_DEGTORAD + spread
    endif
    set RK_dx[slot] = Cos(angle)
    set RK_dy[slot] = Sin(angle)
    if kind == 1 then
        set RK_limit[slot] = 3
        call RK_Marker(slot, "Abilities\\Weapons\\RexxarMissile\\RexxarMissile.mdl")
    elseif kind == 10 then
        set RK_limit[slot] = RMaxBJ(0.1, RMinBJ(700, distance) / 700)
        call RK_Marker(slot, "Abilities\\Weapons\\BrewmasterMissile\\BrewmasterMissile.mdl")
    elseif kind == 11 then
        set RK_limit[slot] = RMaxBJ(0.1, RMinBJ(420 + RC_TalentBonus(2, 1, 2, 180), distance) / 420)
        call PauseUnit(caster, true)
        set RK_visual[slot] = AddSpecialEffectTarget("Abilities\\Spells\\Other\\ImmolationRed\\ImmolationRedTarget.mdl", caster, "origin")
    else
        set RK_limit[slot] = 0.9
        call RK_Marker(slot, "Abilities\\Spells\\Orc\\Shockwave\\ShockwaveMissile.mdl")
    endif
endfunction

function RK_Cast takes unit caster, unit target, integer abilityId, real x, real y returns nothing
    local integer role = 0
    local integer skill = 0
    local integer kind
    local integer rank = GetUnitAbilityLevel(caster, abilityId)
    local integer slot = 0
    local integer n = 0
    local real dx
    local real dy
    local real distance
    local real angle
    local real nearest = 600
    local unit partner = null
    local unit u
    loop
        exitwhen role == 4 or RC_hero[role] == caster
        set role = role + 1
    endloop
    if role == 4 or rank == 0 or RC_transitionPending or RC_StoryCinematic() then
        set caster = null
        set target = null
        return
    endif
    if RC_QueueTalent(role,abilityId) then
        set caster = null
        set target = null
        return
    endif
    if abilityId == 'R5Sk' or abilityId == 'R5Ta' then
        if abilityId == 'R5Sk' then
            call RC_OpenProgress(role, 0, 0)
        else
            call RC_OpenProgress(role, 1, 0)
        endif
        set caster = null
        set target = null
        return
    endif
    loop
        exitwhen skill == 4 or RC_skill[role * 5 + skill] == abilityId
        set skill = skill + 1
    endloop
    if skill == 4 then
        set caster = null
        set target = null
        return
    endif
    set kind = role * 4 + skill + 1
    if kind == 5 or kind == 7 then
        if not RK_Alive(target) or not IsUnitType(target, UNIT_TYPE_HERO) or IsUnitEnemy(target, GetOwningPlayer(caster)) then
            set caster = null
            set target = null
            return
        endif
    endif
    if kind == 3 and not RK_Enemy(caster, target) then
        set caster = null
        set target = null
        return
    endif
    if kind == 2 then
        call RK_Pet(caster, 'osw2', GetUnitX(caster) - 80, GetUnitY(caster), rank, 22)
        call RK_Pet(caster, 'nqb1', GetUnitX(caster) + 80, GetUnitY(caster), rank, 22)
    elseif kind == 4 then
        loop
            exitwhen n == 3 + R2I(RC_TalentBonus(0, 4, 2, 2))
            call RK_Pet(caster, 'osw2', x + 90 * Cos(n * 6.283185 / (3.0 + RC_TalentBonus(0, 4, 2, 2))), y + 90 * Sin(n * 6.283185 / (3.0 + RC_TalentBonus(0, 4, 2, 2))), rank, 12)
            set n = n + 1
        endloop
        call RK_Area(caster, x, y, 280, 100.0 + 80.0 * rank, RC_HasTalent(0, 3, 1), 0, true)
        call RK_KeepVisual(AddSpecialEffect("Abilities\\Spells\\Other\\Stampede\\StampedeMissileDeath.mdl", x, y),0.8)
    elseif kind == 9 then
        set angle = Atan2(y - GetUnitY(caster), x - GetUnitX(caster))
        call GroupEnumUnitsInRange(RC_skillGroup, GetUnitX(caster), GetUnitY(caster), 550, null)
        loop
            set u = FirstOfGroup(RC_skillGroup)
            exitwhen u == null
            call GroupRemoveUnit(RC_skillGroup, u)
            set dx = GetUnitX(u) - GetUnitX(caster)
            set dy = GetUnitY(u) - GetUnitY(caster)
            if RK_Enemy(caster, u) and (dx * Cos(angle) + dy * Sin(angle)) >= SquareRoot(dx * dx + dy * dy) * 0.65 then
                call RK_Hit(caster, u, (35.0 + 25.0 * rank) * (1.0 + RC_TalentBonus(2, 0, 2, 0.25)))
                call RK_Debuff(caster, u, false)
                call SaveReal(RC_table, GetHandleId(u), 301, RC_skillTime + 6 + RC_TalentBonus(2, 0, 1, 3))
            endif
        endloop
        call RK_KeepVisual(AddSpecialEffectTarget("Abilities\\Spells\\Other\\BreathOfFire\\BreathOfFireMissile.mdl", caster, "origin"),0.75)
    elseif kind == 1 or kind == 10 or kind == 11 or kind == 13 then
        call RK_Launch(caster, kind, rank, x, y, 0)
        if (kind == 1 and RC_HasTalent(0, 4, 1)) or (kind == 13 and RC_HasTalent(3, 4, 1)) then
            call RK_Launch(caster, kind, rank, x, y, 0.22)
            call RK_Launch(caster, kind, rank, x, y, -0.22)
        elseif kind == 10 and RC_HasTalent(2, 4, 2) then
            call RK_Launch(caster, kind, rank, x, y, 0.08)
        endif
    else
        if kind == 3 or kind == 5 or kind == 7 then
            set x = GetUnitX(target)
            set y = GetUnitY(target)
        elseif kind == 14 or kind == 15 or kind == 16 then
            set x = GetUnitX(caster)
            set y = GetUnitY(caster)
        endif
        set slot = RK_New(caster, kind, rank, x, y, 6)
        if slot == 0 then
            set caster = null
            set target = null
            return
        endif
        set RK_target[slot] = target
        if kind == 3 then
            set RC_huntTarget = target
            set RK_limit[slot] = 6 + RC_TalentBonus(0, 1, 1, 3)
            set RC_huntUntil = RC_skillTime + RK_limit[slot]
            call RK_Debuff(caster, target, false)
            set RK_visual[slot] = AddSpecialEffectTarget("Abilities\\Spells\\Other\\Aneu\\AneuTarget.mdl", target, "overhead")
        elseif kind == 5 then
            set RK_limit[slot] = 3
            call RK_Heal(target, (35.0 + 25.0 * rank) * (1.0 + RC_TalentBonus(1, 0, 1, 0.3)))
            if RC_HasTalent(1, 1, 1) then
                call UnitRemoveBuffs(target, false, true)
            endif
            set RK_visual[slot] = AddSpecialEffectTarget("Abilities\\Spells\\Orc\\SpiritLink\\SpiritLinkTarget.mdl", target, "chest")
        elseif kind == 6 then
            set RK_limit[slot] = 8
            set RK_marker[slot] = CreateUnit(GetOwningPlayer(caster), 'ohwd', x, y, 0)
            call UnitAddType(RK_marker[slot], UNIT_TYPE_SUMMONED)
            // Remove the native ward heal: only the specified scripted pulses apply.
            call UnitRemoveAbility(RK_marker[slot], 'Aoar')
        elseif kind == 7 then
            set RK_limit[slot] = 7
            set RK_value[slot] = RMinBJ(GetWidgetLife(target), GetUnitState(target, UNIT_STATE_MAX_LIFE) * (0.35 + 0.07 * rank))
            set RK_visual[slot] = AddSpecialEffectTarget("Abilities\\Spells\\Orc\\SpiritLink\\SpiritLinkTarget.mdl", target, "origin")
            if RC_HasTalent(1, 4, 1) then
                loop
                    exitwhen n == 4
                    set u = RC_hero[n]
                    if u != target and RK_Alive(u) and IsUnitInRange(u, target, nearest) then
                        set dx = GetUnitX(u) - x
                        set dy = GetUnitY(u) - y
                        set nearest = SquareRoot(dx * dx + dy * dy)
                        set partner = u
                    endif
                    set n = n + 1
                endloop
                if partner != null then
                    set slot = RK_New(caster, 7, rank, GetUnitX(partner), GetUnitY(partner), 7)
                    if slot != 0 then
                        set RK_target[slot] = partner
                        set RK_value[slot] = RMinBJ(GetWidgetLife(partner), GetUnitState(partner, UNIT_STATE_MAX_LIFE) * (0.35 + 0.07 * rank))
                        set RK_visual[slot] = AddSpecialEffectTarget("Abilities\\Spells\\Orc\\SpiritLink\\SpiritLinkTarget.mdl", partner, "origin")
                    endif
                endif
            endif
        elseif kind == 8 then
            set RK_limit[slot] = 8
            set RK_visual[slot] = AddSpecialEffect("Abilities\\Spells\\Other\\Monsoon\\MonsoonRain.mdl", x, y)
            loop
                exitwhen n == 4
                if RC_hero[n] != null and not RK_Alive(RC_hero[n]) and IsUnitInRangeXY(RC_hero[n], x, y, 700) then
                    call ReviveHero(RC_hero[n], x, y, true)
                    call SetWidgetLife(RC_hero[n], GetUnitState(RC_hero[n], UNIT_STATE_MAX_LIFE) * 0.4)
                    exitwhen not RC_HasTalent(1, 4, 2)
                endif
                set n = n + 1
            endloop
        elseif kind == 12 then
            set RK_limit[slot] = 6 + RC_TalentBonus(2, 4, 1, 2)
            set RK_visual[slot] = AddSpecialEffect("Abilities\\Spells\\Human\\FlameStrike\\FlameStrike1.mdl", x, y)
        elseif kind == 14 then
            call GroupAddUnit(RK_hits[slot], caster)
            call RK_Armor(caster, rank, 1)
            if RC_HasTalent(3, 0, 2) then
                call UnitAddAbility(caster, 'R5Ar')
            endif
            set RK_visual[slot] = AddSpecialEffectTarget("Abilities\\Spells\\Human\\Defend\\DefendCaster.mdl", caster, "origin")
        elseif kind == 15 then
            set RK_limit[slot] = 5
            set RK_visual[slot] = AddSpecialEffectTarget("Abilities\\Spells\\Orc\\SpiritLink\\SpiritLinkTarget.mdl", caster, "origin")
        elseif kind == 16 then
            set RK_limit[slot] = 8
            set RK_visual[slot] = AddSpecialEffect("Abilities\\Spells\\Orc\\EarthQuake\\EarthQuakeTarget.mdl", x, y)
        endif
    endif
    set caster = null
    set target = null
    set partner = null
    set u = null
endfunction

function RC_Spell takes nothing returns nothing
    call RK_Cast(GetTriggerUnit(),GetSpellTargetUnit(),GetSpellAbilityId(),GetSpellTargetX(),GetSpellTargetY())
endfunction

// Scripted stock-skill purchases must not spend the player's unassigned points.
// NPC/cinematic actors keep stock spells until adoption strips that old kit.
function RC_Learn takes unit hero, integer abilityId returns nothing
    local integer role = 0
    local integer slot = 0
    local integer rank = GetUnitAbilityLevel(hero, abilityId) + 1
    loop
        exitwhen role == 4
        if hero == RC_hero[role] then
            return
        endif
        set role = role + 1
    endloop
    set role = 0
    loop
        exitwhen role == 4
        set slot = 0
        loop
            exitwhen slot == 4
            if RC_oldSkill[role * 4 + slot] == abilityId and GetUnitTypeId(hero) == RC_heroType[role] then
                call UnitAddAbility(hero, abilityId)
                call SetUnitAbilityLevel(hero, abilityId, rank)
                return
            endif
            set slot = slot + 1
        endloop
        set role = role + 1
    endloop
    call SelectHeroSkill(hero, abilityId)
endfunction

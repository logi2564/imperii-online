// Only occupied human slots receive a playable hero. Narrative actors are
// neutral, hidden and inert outside cinematics; no extra controllable heroes.
function RC_InMask takes integer role, integer bits returns boolean
    loop
        exitwhen role <= 0
        set bits = bits / 2
        set role = role - 1
    endloop
    return ModuloInteger(bits, 2) == 1
endfunction

function RC_MaskCount takes integer bits returns integer
    local integer count = 0
    loop
        exitwhen bits <= 0
        set count = count + ModuloInteger(bits, 2)
        set bits = bits / 2
    endloop
    return count
endfunction

function RC_CurrentMask takes nothing returns integer
    local integer role = 0
    local integer power = 1
    local integer bits = 0
    loop
        exitwhen role == 4
        if RC_Active(role) then
            set bits = bits + power
        endif
        set power = power * 2
        set role = role + 1
    endloop
    return bits
endfunction

function RC_PartRank takes integer role, integer bits returns integer
    local integer n = 0
    local integer rank = 0
    loop
        exitwhen n >= role
        if RC_InMask(n, bits) then
            set rank = rank + 1
        endif
        set n = n + 1
    endloop
    return rank
endfunction

function RC_ArmyOwner takes integer sequence returns player
    local integer n = 0
    local integer rank = ModuloInteger(sequence, RC_MaskCount(RC_CurrentMask()))
    loop
        exitwhen n == 4
        if RC_Active(n) then
            if rank == 0 then
                return RC_Player(n)
            endif
            set rank = rank - 1
        endif
        set n = n + 1
    endloop
    return RC_Player(RC_host)
endfunction

function RC_TypeRole takes unit u returns integer
    local integer role = 0
    loop
        exitwhen role == 4
        if GetUnitTypeId(u) == RC_heroType[role] then
            return role
        endif
        set role = role + 1
    endloop
    return -1
endfunction

function RC_DropItems takes unit u returns nothing
    local integer slot = 0
    local item it
    local unit leader = RC_hero[RC_host]
    loop
        exitwhen slot == 6
        set it = UnitItemInSlot(u, slot)
        if it != null then
            call UnitRemoveItem(u, it)
            call SetItemPosition(it, GetUnitX(leader) + slot * 35, GetUnitY(leader) + 100)
        endif
        set slot = slot + 1
    endloop
    set it = null
    set leader = null
endfunction

function RC_SuppressUnit takes unit u returns nothing
    local integer role
    if u == null or GetUnitTypeId(u) == 0 then
        return
    endif
    if not LoadBoolean(RC_table, GetHandleId(u), 700) then
        call SaveInteger(RC_table, GetHandleId(u), 701, GetPlayerId(GetOwningPlayer(u)) + 1)
        call SaveBoolean(RC_table, GetHandleId(u), 700, true)
        call GroupAddUnit(RC_hiddenActors, u)
    endif
    set role = RC_TypeRole(u)
    if role >= 0 and not RC_Active(role) then
        call GroupAddUnit(RC_hiddenLoot, u)
    endif
    call RC_DropItems(u)
    call SetUnitOwner(u, Player(15), false)
    call SetUnitInvulnerable(u, true)
    call SetUnitPathing(u, false)
    call PauseUnit(u, not RC_cinematicMode)
    call ShowUnit(u, false)
endfunction

function RC_DepartedBank takes integer role returns nothing
    local integer count = RC_MaskCount(RC_CurrentMask())
    local integer n = 0
    local integer gold = GetPlayerState(RC_Player(role), PLAYER_STATE_RESOURCE_GOLD)
    local integer wood = GetPlayerState(RC_Player(role), PLAYER_STATE_RESOURCE_LUMBER)
    if count < 1 then
        return
    endif
    call SetPlayerState(RC_Player(role), PLAYER_STATE_RESOURCE_GOLD, 0)
    call SetPlayerState(RC_Player(role), PLAYER_STATE_RESOURCE_LUMBER, 0)
    loop
        exitwhen n == 4
        if RC_Active(n) then
            call SetPlayerState(RC_Player(n), PLAYER_STATE_RESOURCE_GOLD, GetPlayerState(RC_Player(n), PLAYER_STATE_RESOURCE_GOLD) + gold / count)
            call SetPlayerState(RC_Player(n), PLAYER_STATE_RESOURCE_LUMBER, GetPlayerState(RC_Player(n), PLAYER_STATE_RESOURCE_LUMBER) + wood / count)
        endif
        set n = n + 1
    endloop
    call SetPlayerState(RC_Player(RC_host), PLAYER_STATE_RESOURCE_GOLD, GetPlayerState(RC_Player(RC_host), PLAYER_STATE_RESOURCE_GOLD) + ModuloInteger(gold, count))
    call SetPlayerState(RC_Player(RC_host), PLAYER_STATE_RESOURCE_LUMBER, GetPlayerState(RC_Player(RC_host), PLAYER_STATE_RESOURCE_LUMBER) + ModuloInteger(wood, count))
endfunction

function RC_AbsentActor takes integer role, unit u returns nothing
    if RC_hero[role] == u then
        call RC_DepartedBank(role)
        set RC_hero[role] = null
    endif
    set RC_storyActor[role] = u
    call RC_SuppressUnit(u)
endfunction

// Some original quests award items directly to a companion global even when
// that companion was not restored. Keep a neutral target for those writes;
// RC_DrainHiddenItems delivers its loot to the actual party, not a null unit.
function RC_EnsureAbsent takes integer role returns unit
    if RC_storyActor[role] == null or GetUnitTypeId(RC_storyActor[role]) == 0 then
        set RC_storyActor[role] = CreateUnit(Player(15), RC_heroType[role], GetUnitX(RC_hero[RC_host]), GetUnitY(RC_hero[RC_host]), 0)
        call RC_SuppressUnit(RC_storyActor[role])
    endif
    return RC_storyActor[role]
endfunction

function RC_StoryOwner takes unit u returns player
    local integer original
    if RC_started and u != null then
        set original = LoadInteger(RC_table, GetHandleId(u), 701)
        if original > 0 then
            return Player(original - 1)
        endif
    endif
    return GetOwningPlayer(u)
endfunction

function RC_CheckSourceUnit takes unit u returns nothing
    local integer role
    local integer ownerRole
    if not RC_started or u == null or GetUnitTypeId(u) == 0 then
        return
    endif
    set ownerRole = RC_Role(GetOwningPlayer(u))
    if ownerRole < 0 then
        return
    endif
    set role = RC_TypeRole(u)
    if role >= 0 and RC_Active(role) and u == RC_hero[role] then
        if GetOwningPlayer(u) != RC_Player(role) then
            call SetUnitOwner(u, RC_Player(role), true)
        endif
        return
    endif
    if role >= 0 and not RC_Active(role) then
        call RC_SuppressUnit(u)
    elseif not RC_Active(ownerRole) then
        call RC_SuppressUnit(u)

    endif
endfunction

function RC_MarkShared takes unit u returns nothing
    local integer role
    if u == null or GetUnitTypeId(u) == 0 then
        return
    endif
    set role = RC_Role(GetOwningPlayer(u))
    if role >= 0 and RC_Active(role) and not IsUnitType(u, UNIT_TYPE_HERO) and not IsUnitType(u, UNIT_TYPE_STRUCTURE) and not IsUnitType(u, UNIT_TYPE_SUMMONED) then
        call GroupAddUnit(RC_pendingArmy, u)
    endif
endfunction

function RC_SourceCreate takes player p, integer id, real x, real y, real facing returns unit
    local unit u = CreateUnit(p, id, x, y, facing)
    call RC_CheckSourceUnit(u)
    if RC_started then
        call RC_MarkShared(u)
    endif
    return u
endfunction

function RC_SourceCreateAtLoc takes integer count, integer id, player p, location point, real facing returns group
    local group created = CreateNUnitsAtLoc(count, id, p, point, facing)
    local group scan = CreateGroup()
    local unit u
    call GroupAddGroup(created, scan)
    loop
        set u = FirstOfGroup(scan)
        exitwhen u == null
        call GroupRemoveUnit(scan, u)
        call RC_CheckSourceUnit(u)
        if RC_started then
            call RC_MarkShared(u)
        endif
    endloop
    call DestroyGroup(scan)
    set scan = null
    set u = null
    return created
endfunction

function RC_SourceCreateFacing takes integer count, integer id, player p, location point, location target returns group
    return RC_SourceCreateAtLoc(count, id, p, point, AngleBetweenPoints(point, target))
endfunction

function RC_SourceOwner takes unit u, player p, boolean colour returns nothing
    if RC_started and u != null and LoadBoolean(RC_table, GetHandleId(u), 700) and not RC_IsPartyPlayer(p) then
        call SaveBoolean(RC_table, GetHandleId(u), 700, false)
        call SaveInteger(RC_table, GetHandleId(u), 701, 0)
        call GroupRemoveUnit(RC_hiddenActors, u)
        call GroupRemoveUnit(RC_hiddenLoot, u)
        call SetUnitPathing(u, true)
        call SetUnitInvulnerable(u, false)
        call PauseUnit(u, false)
        call ShowUnit(u, true)
    endif
    call SetUnitOwner(u, p, colour)
    call RC_CheckSourceUnit(u)
    if RC_started then
        call RC_MarkShared(u)
    endif
endfunction

function RC_SourceShow takes unit u, boolean visible returns nothing
    call RC_CheckSourceUnit(u)
    if RC_started and u != null and LoadBoolean(RC_table, GetHandleId(u), 700) then
        call ShowUnit(u, visible and RC_cinematicMode)
        call PauseUnit(u, not RC_cinematicMode)
    else
        call ShowUnit(u, visible)
    endif
endfunction

function RC_SourceShowOn takes unit u returns nothing
    call RC_SourceShow(u, true)
endfunction

function RC_SourceShowOff takes unit u returns nothing
    call RC_SourceShow(u, false)
endfunction

function RC_SourceGroupAdd takes group destination, unit u returns nothing
    call RC_CheckSourceUnit(u)
    if RC_started and u != null and LoadBoolean(RC_table, GetHandleId(u), 700) then
        return
    endif
    call GroupAddUnit(destination, u)
endfunction

function RC_SourceGroupSimple takes unit u, group destination returns nothing
    call RC_SourceGroupAdd(destination, u)
endfunction

function RC_SourceGroupMerge takes group source, group destination returns nothing
    local group scan = CreateGroup()
    local unit u
    call GroupAddGroup(source, scan)
    loop
        set u = FirstOfGroup(scan)
        exitwhen u == null
        call GroupRemoveUnit(scan, u)
        call RC_SourceGroupAdd(destination, u)
    endloop
    call DestroyGroup(scan)
    set scan = null
    set u = null
endfunction

function RC_HideStoryActors takes nothing returns nothing
    local group scan = CreateGroup()
    local unit u
    call GroupAddGroup(RC_hiddenActors, scan)
    loop
        set u = FirstOfGroup(scan)
        exitwhen u == null
        call GroupRemoveUnit(scan, u)
        call ShowUnit(u, false)
        call PauseUnit(u, true)
    endloop
    call DestroyGroup(scan)
    set scan = null
    set u = null
endfunction

function RC_DrainHiddenItems takes nothing returns nothing
    local group scan
    local unit u
    if RC_cinematicMode then
        return
    endif
    set scan = CreateGroup()
    call GroupAddGroup(RC_hiddenLoot, scan)
    loop
        set u = FirstOfGroup(scan)
        exitwhen u == null
        call GroupRemoveUnit(scan, u)
        if GetUnitTypeId(u) == 0 then
            call GroupRemoveUnit(RC_hiddenLoot, u)
        else
            call RC_DropItems(u)
        endif
    endloop
    call DestroyGroup(scan)
    set scan = null
    set u = null
endfunction

function RC_InitialArmy takes nothing returns nothing
    local integer role = 0
    local unit u
    loop
        exitwhen role == 4
        call GroupEnumUnitsOfPlayer(RC_army, RC_Player(role), null)
        loop
            set u = FirstOfGroup(RC_army)
            exitwhen u == null
            call GroupRemoveUnit(RC_army, u)
            call RC_CheckSourceUnit(u)
            if not RC_armyInitialized then
                call RC_MarkShared(u)
            endif
        endloop
        set role = role + 1
    endloop
    set RC_armyInitialized = true
endfunction

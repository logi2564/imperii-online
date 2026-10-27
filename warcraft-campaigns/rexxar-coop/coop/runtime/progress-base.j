// Role-based talent state survives replacement of the cinematic hero handle.
function RC_TalentChoice takes integer role, integer tier returns integer
    local integer value = RC_talents[role]
    loop
        exitwhen tier <= 0
        set value = value / 3
        set tier = tier - 1
    endloop
    return ModuloInteger(value, 3)
endfunction

function RC_HasTalent takes integer role, integer tier, integer choice returns boolean
    return RC_hero[role] != null and GetHeroLevel(RC_hero[role]) >= RC_talentLevel[tier] and RC_TalentChoice(role, tier) == choice
endfunction

function RC_TalentBonus takes integer role, integer tier, integer choice, real amount returns real
    if RC_HasTalent(role, tier, choice) then
        return amount
    endif
    return 0.0
endfunction

function RC_GiveTalent takes integer role, integer tier, integer choice returns boolean
    local integer power = 1
    local integer n = 0
    if not RC_started or RC_transitionPending or role < 0 or role > 3 or tier < 0 or tier > 4 or choice < 1 or choice > 2 then
        return false
    endif
    if RC_hero[role] == null or GetHeroLevel(RC_hero[role]) < RC_talentLevel[tier] or RC_TalentChoice(role, tier) != 0 then
        return false
    endif
    loop
        exitwhen n == tier
        set power = power * 3
        set n = n + 1
    endloop
    set RC_talents[role] = RC_talents[role] + choice * power
    call RC_Tell(RC_Owner(role), 15, "Талант: " + RC_talentName[role * 10 + tier * 2 + choice - 1] + ". " + RC_talentText[role * 10 + tier * 2 + choice - 1])
    return true
endfunction

function RC_InstallProgress takes unit hero returns nothing
    call UnitAddAbility(hero, 'R5Sk')
    call UnitAddAbility(hero, 'R5Ta')
    // All automatic kill experience is replaced by explicit party awards.
    call SuspendHeroXP(hero, true)
endfunction

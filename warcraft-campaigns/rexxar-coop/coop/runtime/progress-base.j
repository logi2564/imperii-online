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

// Never rely on SetHeroXP bypassing the native suspension. Source campaign
// level-cap callbacks must not suspend the hero in the middle of this write.
function RC_WriteXP takes unit hero, integer experience, boolean effects returns nothing
    set RC_writingXP = true
    call SuspendHeroXP(hero, false)
    call SetHeroXP(hero, experience, effects)
    call SuspendHeroXP(hero, true)
    set RC_writingXP = false
endfunction

function RC_SetSkillRank takes integer role, integer skill, integer rank returns boolean
    local unit hero = RC_hero[role]
    local integer id = RC_skill[role * 5 + skill]
    local integer learned = RC_learnSkill[role * 5 + skill]
    local integer previous = GetUnitAbilityLevel(hero, id)
    if rank > 0 then
        if GetUnitAbilityLevel(hero, id) == 0 then
            call UnitAddAbility(hero, id)
        endif
        call SetUnitAbilityLevel(hero, id, rank)
        if GetUnitAbilityLevel(hero, id) != rank then
            if previous == 0 then
                call UnitRemoveAbility(hero, id)
            else
                call SetUnitAbilityLevel(hero, id, previous)
            endif
            set hero = null
            return false
        endif
        call UnitMakeAbilityPermanent(hero, true, id)
        if learned != id then
            if GetUnitAbilityLevel(hero, learned) == 0 then
                call UnitAddAbility(hero, learned)
            endif
            call SetUnitAbilityLevel(hero, learned, rank)
            call UnitMakeAbilityPermanent(hero, true, learned)
        endif
    else
        call UnitRemoveAbility(hero, id)
        if learned != id then
            call UnitRemoveAbility(hero, learned)
        endif
    endif
    if GetUnitAbilityLevel(hero, id) != rank then
        set hero = null
        return false
    endif
    set RC_skillRanks[role * 5 + skill] = rank
    set hero = null
    return true
endfunction

function RC_InstallProgress takes unit hero returns nothing
    call UnitAddAbility(hero, 'R5Sk')
    call UnitAddAbility(hero, 'R5Ta')
    call UnitMakeAbilityPermanent(hero, true, 'R5Sk')
    call UnitMakeAbilityPermanent(hero, true, 'R5Ta')
    // All automatic kill experience is replaced by explicit party awards.
    call SuspendHeroXP(hero, true)
endfunction

// Campaign scripts set 7..20% XP and neutral-creep falloff can reduce it again.
// Disable automatic XP for our four actual heroes; each nearby living role gets
// the full explicit kill reward, once. Cinematic/quest scripted deaths give none.
function RC_XPHandicap takes player p, real factor returns nothing
    if RC_IsPartyPlayer(p) then
        call SetPlayerHandicapXP(p, 1.0)
    else
        call SetPlayerHandicapXP(p, factor)
    endif
endfunction

function RC_XPHandicapPercent takes player p, real percent returns nothing
    call RC_XPHandicap(p, percent * 0.01)
endfunction

function RC_SuspendExperience takes unit hero, boolean flag returns nothing
    local integer role = 0
    loop
        exitwhen role == 4
        if hero == RC_hero[role] then
            if not RC_writingXP then
                call SuspendHeroXP(hero, true)
            endif
            return
        endif
        set role = role + 1
    endloop
    call SuspendHeroXP(hero, flag)
endfunction

function RC_SuspendExperienceBJ takes boolean flag, unit hero returns nothing
    call RC_SuspendExperience(hero, not flag)
endfunction

function RC_KillExperience takes nothing returns nothing
    local unit dead = GetTriggerUnit()
    local unit killer = GetKillingUnit()
    local integer award
    local integer role = 0
    local real dx
    local real dy
    local integer before
    local texttag floating
    if not RC_started or RC_transitionPending or RC_StoryCinematic() or killer == null or dead == null then
        set dead = null
        set killer = null
        return
    endif
    if not RC_IsPartyPlayer(GetOwningPlayer(killer)) or not RC_Active(RC_Role(GetOwningPlayer(killer))) or not IsUnitEnemy(dead, GetOwningPlayer(killer)) or IsUnitType(dead, UNIT_TYPE_SUMMONED) or IsUnitIllusion(dead) or GetUnitAbilityLevel(dead, 'Aloc') > 0 then
        set dead = null
        set killer = null
        return
    endif
    set award = 24 + 8 * GetUnitLevel(dead)
    if IsUnitType(dead, UNIT_TYPE_HERO) then
        set award = award + 40
    elseif IsUnitType(dead, UNIT_TYPE_STRUCTURE) then
        set award = 12 + 4 * GetUnitLevel(dead)
    endif
    loop
        exitwhen role == 4
        if RC_Active(role) and RC_hero[role] != null and GetWidgetLife(RC_hero[role]) > 0.405 and GetHeroLevel(RC_hero[role]) < 20 then
            // Coordinate distance also works for corpses; do not depend on a
            // living-unit range query after the native death event.
            set dx = GetUnitX(dead) - GetUnitX(RC_hero[role])
            set dy = GetUnitY(dead) - GetUnitY(RC_hero[role])
            if dx * dx + dy * dy <= 2560000 then
            set before = GetHeroXP(RC_hero[role])
            call RC_WriteXP(RC_hero[role], before + award, true)
            if GetHeroXP(RC_hero[role]) > before then
            set floating = CreateTextTag()
            call SetTextTagText(floating, "+" + I2S(award) + " опыта", 0.024)
            call SetTextTagPosUnit(floating, RC_hero[role], 64)
            call SetTextTagColor(floating, 190, 125, 255, 255)
            call SetTextTagVelocity(floating, 0, 0.025)
            call SetTextTagPermanent(floating, false)
            call SetTextTagLifespan(floating, 1.5)
            call SetTextTagFadepoint(floating, 1.0)
            // All handles are created synchronously; only visibility is local UI.
            call SetTextTagVisibility(floating, GetLocalPlayer() == RC_Owner(role))
            else
                call RC_Tell(RC_Owner(role), 10, "Опыт не начислен: проверь, что загружена карта REXXAR VI FIX. Команда -progress покажет состояние героя.")
            endif
            endif
        endif
        set role = role + 1
    endloop
    set floating = null
    set dead = null
    set killer = null
endfunction

function RC_InitExperience takes nothing returns nothing
    local trigger deaths = CreateTrigger()
    local integer n = 0
    loop
        exitwhen n == 16
        call TriggerRegisterPlayerUnitEvent(deaths, Player(n), EVENT_PLAYER_UNIT_DEATH, null)
        set n = n + 1
    endloop
    call TriggerAddAction(deaths, function RC_KillExperience)
    set deaths = null
endfunction

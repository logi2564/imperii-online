function RC_LearnRank takes integer role, integer skill returns boolean
    local unit hero = RC_hero[role]
    local integer rank
    local integer required
    local integer maximum = 5
    local integer abilityId
    if not RC_started or RC_transitionPending or hero == null or skill < 0 or skill > 4 then
        set hero = null
        return false
    endif
    set abilityId = RC_skill[role * 5 + skill]
    set rank = GetUnitAbilityLevel(hero, abilityId)
    if skill == 3 then
        set maximum = 3
        set required = 6 + rank * 6
    elseif skill == 4 then
        set maximum = 10
        set required = 1 + rank * 2
    else
        set required = 1 + rank * 2
    endif
    if GetHeroSkillPoints(hero) < 1 or rank >= maximum or GetHeroLevel(hero) < required then
        set hero = null
        return false
    endif
    // Install a normal cast ability, and mirror its hidden native learn entry.
    // Spend the point only after verifying the installed rank.
    if not RC_SetSkillRank(role, skill, rank + 1) then
        set hero = null
        return false
    endif
    call UnitModifySkillPoints(hero, -1)
    call RC_Tell(RC_Owner(role), 10, RC_skillName[role * 5 + skill] + ": ранг " + I2S(rank + 1) + ". Осталось очков: " + I2S(GetHeroSkillPoints(hero)))
    set hero = null
    return true
endfunction

function RC_NativeLearn takes nothing returns nothing
    local unit hero = GetLearningUnit()
    local integer id = GetLearnedSkill()
    local integer role = 0
    local integer skill = 0
    local integer rank = GetLearnedSkillLevel()
    local integer current
    loop
        exitwhen role == 4 or RC_hero[role] == hero
        set role = role + 1
    endloop
    if role == 4 or not RC_started or RC_transitionPending then
        set hero = null
        return
    endif
    loop
        exitwhen skill == 4 or RC_learnSkill[role * 5 + skill] == id
        set skill = skill + 1
    endloop
    if skill < 4 then
        set current = GetUnitAbilityLevel(hero, RC_skill[role * 5 + skill])
        // A restored/K-learned cast can be ahead of a stale native learn entry.
        // Resynchronize it without downgrading the skill or charging twice.
        if rank <= current then
            call SetUnitAbilityLevel(hero, id, current)
            call UnitModifySkillPoints(hero, 1)
            set hero = null
            return
        endif
        if not RC_SetSkillRank(role, skill, rank) then
            if current == 0 then
                call UnitRemoveAbility(hero, id)
            else
                call SetUnitAbilityLevel(hero, id, current)
            endif
            call UnitModifySkillPoints(hero, 1)
            call RC_Tell(RC_Owner(role), 15, "Навык не установился; очко возвращено. Открой K или -skills.")
        else
            call RC_Tell(RC_Owner(role), 10, RC_skillName[role * 5 + skill] + ": изучен ранг " + I2S(rank) + ". Кнопка навыка — в нижнем ряду героя.")
        endif
    endif
    set hero = null
endfunction

function RC_OpenProgress takes integer role, integer mode, integer tier returns nothing
    local integer n = 0
    local integer choice
    local integer index
    local integer required
    local integer rank
    local string text
    local dialog panel = RC_progressPanel[role]
    if not RC_started or RC_transitionPending or role < 0 or role > 3 or RC_hero[role] == null or RC_StoryCinematic() then
        set panel = null
        return
    endif
    call DialogClear(panel)
    set RC_progressMode[role] = mode
    set RC_progressTier[role] = tier
    if mode == 0 then
        call DialogSetMessage(panel, RC_heroName[role] + "|nОчки навыков: " + I2S(GetHeroSkillPoints(RC_hero[role])) + ". Уровень: " + I2S(GetHeroLevel(RC_hero[role])))
        loop
            exitwhen n == 5
            set rank = GetUnitAbilityLevel(RC_hero[role], RC_skill[role * 5 + n])
            set required = 1 + rank * 2
            if n == 3 then
                set required = 6 + rank * 6
            endif
            set text = RC_skillName[role * 5 + n] + " [" + I2S(rank) + "]"
            if (n == 3 and rank >= 3) or (n == 4 and rank >= 10) or (n != 3 and n != 4 and rank >= 5) then
                set text = text + " — максимум"
            else
                set text = text + " → нужен ур. " + I2S(required)
            endif
            set RC_progressButton[role * 8 + n] = DialogAddButton(panel, text, 49 + n)
            set n = n + 1
        endloop
    elseif mode == 1 then
        call DialogSetMessage(panel, RC_heroName[role] + "|nТаланты: один выбор на каждом из уровней 4 / 8 / 12 / 16 / 20.")
        loop
            exitwhen n == 5
            set choice = RC_TalentChoice(role, n)
            set text = "Уровень " + I2S(RC_talentLevel[n]) + ": "
            if choice > 0 then
                set text = text + RC_talentName[role * 10 + n * 2 + choice - 1]
            elseif GetHeroLevel(RC_hero[role]) < RC_talentLevel[n] then
                set text = text + "ещё закрыт"
            else
                set text = text + "ВЫБРАТЬ"
            endif
            set RC_progressButton[role * 8 + n] = DialogAddButton(panel, text, 49 + n)
            set n = n + 1
        endloop
    else
        set index = role * 10 + tier * 2
        call DialogSetMessage(panel, "Уровень " + I2S(RC_talentLevel[tier]) + ": выбери один талант.|n1. " + RC_talentText[index] + "|n2. " + RC_talentText[index + 1])
        set RC_progressButton[role * 8] = DialogAddButton(panel, RC_talentName[index], 49)
        set RC_progressButton[role * 8 + 1] = DialogAddButton(panel, RC_talentName[index + 1], 50)
        set RC_progressButton[role * 8 + 2] = DialogAddButton(panel, "Назад", 66)
    endif
    set RC_progressButton[role * 8 + 7] = DialogAddButton(panel, "Закрыть", 27)
    call DialogDisplay(RC_Owner(role), panel, true)
    set panel = null
endfunction

function RC_ProgressClick takes nothing returns nothing
    local integer role = 0
    local integer n = 0
    local button clicked = GetClickedButton()
    local dialog panel = GetClickedDialog()
    loop
        exitwhen role == 4 or RC_progressPanel[role] == panel
        set role = role + 1
    endloop
    if role == 4 or GetTriggerPlayer() != RC_Owner(role) or not RC_started or RC_transitionPending or RC_StoryCinematic() then
        set clicked = null
        set panel = null
        return
    endif
    call DialogDisplay(RC_Owner(role), panel, false)
    if clicked != RC_progressButton[role * 8 + 7] then
        loop
            exitwhen n == 5 or clicked == RC_progressButton[role * 8 + n]
            set n = n + 1
        endloop
        if RC_progressMode[role] == 0 and n < 5 then
            if not RC_LearnRank(role, n) then
                call RC_Tell(RC_Owner(role), 10, "Нужно свободное очко и требуемый уровень героя; навык не должен быть максимального ранга.")
            endif
            call RC_OpenProgress(role, 0, 0)
        elseif RC_progressMode[role] == 1 and n < 5 then
            if GetHeroLevel(RC_hero[role]) >= RC_talentLevel[n] and RC_TalentChoice(role, n) == 0 then
                call RC_OpenProgress(role, 2, n)
            else
                call RC_OpenProgress(role, 1, 0)
            endif
        elseif RC_progressMode[role] == 2 then
            if n < 2 then
                call RC_GiveTalent(role, RC_progressTier[role], n + 1)
            endif
            call RC_OpenProgress(role, 1, 0)
        endif
    endif
    set clicked = null
    set panel = null
endfunction

function RC_InitProgress takes nothing returns nothing
    local integer role = 0
    local trigger clicks = CreateTrigger()
    local trigger learned = CreateTrigger()
    call TriggerAddAction(clicks, function RC_ProgressClick)
    call TriggerAddAction(learned, function RC_NativeLearn)
    loop
        exitwhen role == 4
        set RC_progressPanel[role] = DialogCreate()
        call TriggerRegisterDialogEvent(clicks, RC_progressPanel[role])
        call TriggerRegisterPlayerUnitEvent(learned, RC_Player(role), EVENT_PLAYER_HERO_SKILL, null)
        set role = role + 1
    endloop
    set clicks = null
    set learned = null
endfunction

function RC_ProgressTick takes integer role returns nothing
    local integer tiers = GetHeroLevel(RC_hero[role]) / 4
    local integer n = 0
    local boolean available = false
    if tiers > 5 then
        set tiers = 5
    endif
    if tiers > RC_talentAnnounced[role] then
        set RC_talentAnnounced[role] = tiers
        loop
            exitwhen n >= tiers
            if RC_TalentChoice(role, n) == 0 then
                set available = true
            endif
            set n = n + 1
        endloop
        if RC_Active(role) and available then
            call RC_Tell(RC_Player(role), 20, "Доступен новый ряд талантов! Нажми кнопку «Таланты» (T) у героя или введи -talents.")
        endif
    endif
endfunction

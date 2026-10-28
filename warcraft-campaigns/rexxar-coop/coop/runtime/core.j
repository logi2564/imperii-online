// Rexxar co-op runtime. Classic 1.26 natives only. All gameplay changes run
// synchronously; GetLocalPlayer is used solely for local UI/file output.
// @@GLOBALS@@

function RC_Player takes integer role returns player
    return Player(role)
endfunction

function RC_Role takes player p returns integer
    local integer id
    if p == null then
        return -1
    endif
    set id = GetPlayerId(p)
    if id >= 0 and id < 4 then
        return id
    endif
    return -1
endfunction

function RC_IsPartyPlayer takes player p returns boolean
    return RC_Role(p) >= 0
endfunction

function RC_Active takes integer role returns boolean
    return GetPlayerController(RC_Player(role)) == MAP_CONTROL_USER and GetPlayerSlotState(RC_Player(role)) == PLAYER_SLOT_STATE_PLAYING
endfunction

function RC_Owner takes integer role returns player
    return RC_Player(role)
endfunction

// Text natives are executed only on the recipient's client. No handles,
// timers or gameplay state are created inside this local UI branch.
function RC_Tell takes player recipient, real seconds, string text returns nothing
    if GetLocalPlayer() == recipient then
        call DisplayTimedTextToPlayer(recipient, 0, 0, seconds, text)
    endif
endfunction

function RC_Say takes string text returns nothing
    call DisplayTimedTextToForce(RC_force, 25.0, text)
endfunction

function RC_Digit takes string c returns integer
    local integer column = 0
    local integer digit
    // The second key distinguishes case even on case-insensitive StringHash
    // implementations. Validate the recovered character, not just the hash.
    if StringCase(c, true) != c then
        set column = 1
    endif
    set digit = LoadInteger(RC_digits, StringHash(c), column) - 1
    if digit >= 0 and digit < 64 and SubString(RC_alphabet, digit, digit + 1) == c then
        return digit
    endif
    return -1
endfunction

function RC_Pack takes integer value, integer width returns string
    local string out = ""
    local integer digit
    if value < 0 then
        set RC_codeOK = false
        set value = 0
    endif
    loop
        exitwhen width == 0
        set digit = ModuloInteger(value, 64)
        set out = SubString(RC_alphabet, digit, digit + 1) + out
        set value = value / 64
        set width = width - 1
    endloop
    if value != 0 then
        set RC_codeOK = false
    endif
    return out
endfunction

function RC_Number takes string text returns integer
    local integer n = 0
    local integer v = 0
    local integer d
    loop
        exitwhen n >= StringLength(text)
        set d = RC_Digit(SubString(text, n, n + 1))
        if d < 0 then
            set RC_codeOK = false
            return 0
        endif
        if v > (2147483647 - d) / 64 then
            set RC_codeOK = false
            return 0
        endif
        set v = v * 64 + d
        set n = n + 1
    endloop
    return v
endfunction

function RC_Checksum takes string text returns integer
    local integer n = 0
    local integer hash = 19
    local integer d
    loop
        exitwhen n >= StringLength(text)
        set d = RC_Digit(SubString(text, n, n + 1))
        if d < 0 then
            set RC_codeOK = false
            return 0
        endif
        set hash = ModuloInteger(hash * 73 + d + 1, 262139)
        set n = n + 1
    endloop
    return hash
endfunction

function RC_Seal takes string text returns string
    return text + RC_Pack(RC_Checksum(text), 3)
endfunction

function RC_Valid takes string text, integer length, string kind returns boolean
    local integer check
    local integer actual
    set RC_codeOK = true
    if StringLength(text) != length or (SubString(text, 0, 2) != kind + "1" and not (kind == "S" and length == 108 and SubString(text, 0, 2) == "S2")) then
        return false
    endif
    set check = RC_Number(SubString(text, length - 3, length))
    set actual = RC_Checksum(SubString(text, 0, length - 3))
    return RC_codeOK and check == actual
endfunction

// @@ITEMS@@

// @@PARTY@@

function RC_ClearInventory takes unit hero returns nothing
    local integer n = 0
    loop
        exitwhen n == 6
        call RemoveItem(UnitItemInSlot(hero, n))
        set n = n + 1
    endloop
endfunction

function RC_HeroCode takes integer role returns string
    local unit hero = RC_hero[role]
    local integer n = 0
    local item it
    local string payload = "H1" + RC_Pack(role, 1) + RC_Pack(RC_session, 2) + RC_Pack(RC_map, 1)
    if hero == null then
        set RC_codeOK = false
        return ""
    endif
    set payload = payload + RC_Pack(GetHeroXP(hero), 4) + RC_Pack(GetHeroStr(hero, false), 2) + RC_Pack(GetHeroAgi(hero, false), 2) + RC_Pack(GetHeroInt(hero, false), 2) + RC_Pack(GetHeroSkillPoints(hero), 1)
    loop
        exitwhen n == 5
        set payload = payload + RC_Pack(GetUnitAbilityLevel(hero, RC_skill[role * 5 + n]), 1)
        set n = n + 1
    endloop
    set payload = payload + RC_Pack(GetPlayerState(RC_Player(role), PLAYER_STATE_RESOURCE_GOLD), 4) + RC_Pack(GetPlayerState(RC_Player(role), PLAYER_STATE_RESOURCE_LUMBER), 4)
    set n = 0
    loop
        exitwhen n == 6
        set it = UnitItemInSlot(hero, n)
        set payload = payload + RC_Pack(RC_ItemToPortable(GetItemTypeId(it)), 6) + RC_Pack(GetItemCharges(it), 2)
        set n = n + 1
    endloop
    set hero = null
    set it = null
    return RC_Seal(payload)
endfunction

function RC_ClearOldSkills takes unit hero, integer role returns nothing
    local integer n = 0
    loop
        exitwhen n == 4
        call UnitRemoveAbility(hero, RC_oldSkill[role * 4 + n])
        set n = n + 1
    endloop
    call UnitRemoveAbility(hero, 'RCA0' + role)
endfunction

// @@PROGRESS_BASE@@

function RC_ApplyHero takes integer role, string payload returns nothing
    local unit hero = RC_hero[role]
    local integer n = 0
    local integer pos = 25
    local integer level
    local integer id
    local integer charges
    local item it
    call RC_ClearOldSkills(hero, role)
    call RC_WriteXP(hero, RC_Number(SubString(payload, 6, 10)), false)
    loop
        exitwhen n == 5
        set level = RC_Number(SubString(payload, 17 + n, 18 + n))
        call RC_SetSkillRank(role, n, level)
        set n = n + 1
    endloop
    call UnitModifySkillPoints(hero, RC_Number(SubString(payload, 16, 17)) - GetHeroSkillPoints(hero))
    call RC_ClearInventory(hero)
    set pos = 30
    set n = 0
    loop
        exitwhen n == 6
        set id = RC_ItemToLocal(RC_Number(SubString(payload, pos, pos + 6)))
        set charges = RC_Number(SubString(payload, pos + 6, pos + 8))
        if id != 0 then
            // UnitAddItemToSlotById preserves empty inventory positions too.
            call UnitAddItemToSlotById(hero, id, n)
            set it = UnitItemInSlot(hero, n)
            call SetItemCharges(it, charges)
        endif
        set n = n + 1
        set pos = pos + 8
    endloop
    call SetPlayerState(RC_Player(role), PLAYER_STATE_RESOURCE_GOLD, RC_Number(SubString(payload, 22, 26)))
    call SetPlayerState(RC_Player(role), PLAYER_STATE_RESOURCE_LUMBER, RC_Number(SubString(payload, 26, 30)))
    // Skill/item installation may itself adjust attributes; enforce the saved
    // base values last so permanent bonuses are not applied a second time.
    call SetHeroStr(hero, RC_Number(SubString(payload, 10, 12)), true)
    call SetHeroAgi(hero, RC_Number(SubString(payload, 12, 14)), true)
    call SetHeroInt(hero, RC_Number(SubString(payload, 14, 16)), true)
    call RC_InstallProgress(hero)
    set hero = null
    set it = null
endfunction

function RC_Adopt takes integer role, unit hero returns nothing
    local unit old = RC_hero[role]
    local string payload
    local integer n = 0
    local item it
    if not RC_Active(role) then
        call RC_AbsentActor(role, hero)
        set old = null
        return
    endif
    if hero != old then
        set RC_codeOK = true
        set payload = RC_HeroCode(role)
        loop
            exitwhen n == 6
            set it = UnitItemInSlot(hero, n)
            call UnitRemoveItem(hero, it)
            call SetItemPosition(it, GetUnitX(hero), GetUnitY(hero))
            set n = n + 1
        endloop
        set RC_hero[role] = hero
        if RC_codeOK then
            call RC_ApplyHero(role, payload)
        endif
        call RC_ClearInventory(old)
        call RemoveUnit(old)
    endif
    if GetOwningPlayer(hero) != RC_Owner(role) then
        call SetUnitOwner(hero, RC_Owner(role), true)
    endif
    call RC_ClearOldSkills(hero, role)
    call RC_InstallProgress(hero)
    set old = null
    set it = null
endfunction

// The original campaign deletes and recreates companions during recruitment.
// Keep the old gameplay handle until RC_Adopt has copied its progression.
function RC_SourceRemove takes unit u returns nothing
    local integer role = 0
    if RC_started then
        loop
            exitwhen role == 4
            if u != null and u == RC_hero[role] then
                call ShowUnit(u, false)
                call PauseUnit(u, true)
                return
            endif
            set role = role + 1
        endloop
    endif
    call RemoveUnit(u)
endfunction

// @@HOOKS@@

// @@PROGRESS_MENUS@@

// @@EXPERIENCE@@

// @@SKILLS@@

function RC_ItemCarried takes item it returns boolean
    local integer role = 0
    local integer slot
    if it == null then
        return false
    endif
    loop
        exitwhen role == 4
        set slot = 0
        loop
            exitwhen slot == 6
            if RC_hero[role] != null and UnitItemInSlot(RC_hero[role], slot) == it then
                return true
            endif
            set slot = slot + 1
        endloop
        set role = role + 1
    endloop
    set slot = 0
    if RC_stash != null then
        loop
            exitwhen slot == 6
            if UnitItemInSlot(RC_stash, slot) == it then
                return true
            endif
            set slot = slot + 1
        endloop
    endif
    return false
endfunction

function RC_StashCode takes nothing returns string
    local string payload = "S1" + RC_Pack(RC_session, 2) + RC_Pack(RC_map, 1)
    local integer n = 0
    local item it
    set RC_stashRequired = false
    loop
        exitwhen n == 6
        if RC_stash != null then
            set it = UnitItemInSlot(RC_stash, n)
            if it != null then
                set RC_stashRequired = true
            endif
            set payload = payload + RC_Pack(RC_ItemToPortable(GetItemTypeId(it)), 6) + RC_Pack(GetItemCharges(it), 2)
        elseif RC_loadedStash != "" then
            set payload = payload + SubString(RC_loadedStash, 5 + n * 8, 13 + n * 8)
            if RC_Number(SubString(RC_loadedStash, 5 + n * 8, 11 + n * 8)) != 0 then
                set RC_stashRequired = true
            endif
        else
            set payload = payload + "00000000"
        endif
        set n = n + 1
    endloop
    set n = 0
    loop
        exitwhen n == 6
        if RC_extraDrop[n] != null then
            if GetItemTypeId(RC_extraDrop[n]) == 0 or RC_ItemCarried(RC_extraDrop[n]) then
                set RC_extraItem[n] = 0
                set RC_extraCharges[n] = 0
                set RC_extraDrop[n] = null
            endif
        endif
        if RC_extraItem[n] != 0 then
            set RC_stashRequired = true
        endif
        set payload = payload + RC_Pack(RC_extraItem[n], 6) + RC_Pack(RC_extraCharges[n], 2)
        set n = n + 1
    endloop
    set it = null
    return RC_Seal(payload)
endfunction

function RC_ApplyStash takes nothing returns nothing
    local integer n = 0
    local integer pos = 5
    local integer id
    if RC_stash == null or RC_stash == RC_stashApplied or RC_loadedStash == "" then
        return
    endif
    call RC_ClearInventory(RC_stash)
    loop
        exitwhen n == 6
        set id = RC_ItemToLocal(RC_Number(SubString(RC_loadedStash, pos, pos + 6)))
        if id != 0 then
            call UnitAddItemToSlotById(RC_stash, id, n)
            call SetItemCharges(UnitItemInSlot(RC_stash, n), RC_Number(SubString(RC_loadedStash, pos + 6, pos + 8)))
        endif
        set pos = pos + 8
        set n = n + 1
    endloop
    set RC_stashApplied = RC_stash
endfunction

function RC_PartyCode takes nothing returns string
    local integer n = 0
    local string payload = "P1" + RC_Pack(RC_session, 2) + RC_Pack(RC_map, 1) + RC_Pack(RC_nextMap, 1) + RC_Pack(RC_nextArea, 2) + RC_Pack(RC_difficulty, 1)
    call RC_CollectStory()
    loop
        exitwhen n == RC_storyCount
        set payload = payload + RC_Pack(RC_story[n], 2)
        set n = n + 1
    endloop
    set n = 0
    loop
        exitwhen n == 4
        set payload = payload + RC_Pack(RC_flags[n], 1)
        set n = n + 1
    endloop
    if RC_stashRequired then
        set payload = payload + "1"
    else
        set payload = payload + "0"
    endif
    return RC_Seal(payload)
endfunction

// @@CHECKPOINT@@

function RC_WriteSave takes integer role, string payload returns nothing
    // Only file/visual natives occur in this local branch. No unit, item,
    // resource, random-number or handle state is changed locally.
    if GetLocalPlayer() == RC_Owner(role) then
        call PreloadGenClear()
        call PreloadGenStart()
        call Preload("Rexxar co-op VI. Enter this one command in the next mission, before -start:")
        call Preload("-load " + payload)
        if role == RC_host and RC_externalStash != "" then
            call Preload("-stash " + RC_externalStash)
        endif
        call Preload("Next map: " + RC_mapName[RC_nextMap])
        call PreloadGenEnd("Logs\\RexxarCoop-P" + I2S(role + 1) + ".txt")
    endif
endfunction

function RC_SaveAll takes boolean verbose returns nothing
    local integer n = 0
    local string stashCode
    local string storyCode
    local string description = "Следующая карта: " + RC_filePrefix + RC_mapName[RC_nextMap] + ".w3x.|nКоды нужны только для состава сохранения.|n"
    local boolean overflow = false
    set RC_saveOK = false
    call RC_ObserveStoryHeroes()
    loop
        exitwhen n == 4
        if RC_Active(n) and (RC_hero[n] == null or GetUnitTypeId(RC_hero[n]) == 0) then
            call RC_Say("Сохранение отложено: герой меняется в сцене. Предыдущие файлы сохранены.")
            return
        endif
        set n = n + 1
    endloop
    set RC_codeOK = true
    set stashCode = RC_StashCode()
    set storyCode = RC_SmallStory()
    set RC_savedMask = RC_CurrentMask()
    set RC_savedInline = 1
    set RC_externalStash = ""
    set RC_checkpoint = ModuloInteger(RC_checkpoint + 1, 262144)
    set n = 0
    loop
        exitwhen n == 4
        if RC_Active(n) then
            set RC_lastCode[n] = RC_HeroCode(n)
            set RC_checkpointPart[n] = RC_PartyCheckpoint(n, RC_lastCode[n], storyCode, stashCode)
            if StringLength(RC_checkpointPart[n]) + 6 > 127 then
                set overflow = true
            endif
        endif
        set n = n + 1
    endloop
    if overflow and RC_codeOK then
        set RC_savedInline = 0
        set RC_externalStash = RC_ExternalStash(stashCode)
        set n = 0
        loop
            exitwhen n == 4
            if RC_Active(n) then
                set RC_checkpointPart[n] = RC_PartyCheckpoint(n, RC_lastCode[n], storyCode, stashCode)
            endif
            set n = n + 1
        endloop
    endif
    set n = 0
    loop
        exitwhen n == 4
        if RC_Active(n) then
            if not RC_codeOK or not RC_CheckpointValid(RC_checkpointPart[n]) or StringLength(RC_checkpointPart[n]) + 6 > 127 then
                set RC_codeOK = false
            endif
        endif
        set n = n + 1
    endloop
    if not RC_codeOK then
        call RC_Say("Сохранение не записано: значение вышло за пределы формата. Предыдущие файлы сохранены.")
        return
    endif
    set n = 0
    loop
        exitwhen n == 4
        call QuestSetDiscovered(RC_codeQuest[n], RC_Active(n))
        if RC_Active(n) then
            set RC_checkpointCode[n] = RC_checkpointPart[n]
            set RC_checkpointPart[n] = ""
            set description = description + "|nГерой " + I2S(n + 1) + ": -load " + RC_checkpointCode[n]
            call QuestSetDescription(RC_codeQuest[n], "Следующая карта: " + RC_filePrefix + RC_mapName[RC_nextMap] + ".w3x.|n-load " + RC_checkpointCode[n] + "|nПосле кодов состава сохранения: -start.")
            call RC_WriteSave(n, RC_checkpointCode[n])
            if verbose then
                call RC_ShowCode(n)
            endif
        else
            set RC_checkpointCode[n] = ""
            set RC_checkpointPart[n] = ""
        endif
        set n = n + 1
    endloop
    if RC_externalStash != "" then
        set description = description + "|nОбщий тайник: -stash " + RC_externalStash
    endif
    if verbose then
        call RC_Say("Коды готовы. Свой код: -code. Резервная копия: F9 → Сохранение отряда.")
    endif
    call QuestSetDescription(RC_saveQuest, description)
    set RC_loadedStash = stashCode
    set RC_saveOK = true
endfunction

function RC_LoadParty takes string payload returns boolean
    local integer n = 0
    if not RC_Valid(payload, 17 + RC_storyCount * 2, "P") then
        return false
    endif
    // Validate all semantic fields before mutating an existing loaded party.
    if RC_Number(SubString(payload, 4, 5)) > 16 or RC_Number(SubString(payload, 5, 6)) > 16 or RC_Number(SubString(payload, 8, 9)) > 2 then
        return false
    endif
    loop
        exitwhen n == 4
        if RC_Number(SubString(payload, 9 + RC_storyCount * 2 + n, 10 + RC_storyCount * 2 + n)) > 1 then
            return false
        endif
        set n = n + 1
    endloop
    set n = 0
    if RC_Number(SubString(payload, 13 + RC_storyCount * 2, 14 + RC_storyCount * 2)) > 1 then
        return false
    endif
    set RC_session = RC_Number(SubString(payload, 2, 4))
    set RC_sourceMap = RC_Number(SubString(payload, 4, 5))
    set RC_nextMap = RC_Number(SubString(payload, 5, 6))
    set RC_nextArea = RC_Number(SubString(payload, 6, 8))
    set RC_difficulty = RC_Number(SubString(payload, 8, 9))
    if RC_sourceMap > 16 or RC_nextMap > 16 or RC_difficulty > 2 then
        return false
    endif
    loop
        exitwhen n == RC_storyCount
        set RC_story[n] = RC_Number(SubString(payload, 9 + n * 2, 11 + n * 2))
        set n = n + 1
    endloop
    set n = 0
    loop
        exitwhen n == 4
        set RC_flags[n] = RC_Number(SubString(payload, 9 + RC_storyCount * 2 + n, 10 + RC_storyCount * 2 + n))
        if RC_flags[n] > 1 then
            return false
        endif
        set n = n + 1
    endloop
    set RC_partyLoaded = true
    set RC_stashRequired = RC_Number(SubString(payload, 13 + RC_storyCount * 2, 14 + RC_storyCount * 2)) == 1
    return RC_codeOK
endfunction

function RC_GetDifficulty takes nothing returns gamedifficulty
    if RC_difficulty == 0 then
        return MAP_DIFFICULTY_EASY
    elseif RC_difficulty == 2 then
        return MAP_DIFFICULTY_HARD
    endif
    return MAP_DIFFICULTY_NORMAL
endfunction

function RC_GetForce takes player p returns force
    if RC_IsPartyPlayer(p) then
        return RC_force
    endif
    return GetForceOfPlayer(p)
endfunction

function RC_UnitOwned takes unit u, player p returns boolean
    if p == Player(0) then
        return RC_IsPartyPlayer(GetOwningPlayer(u))
    endif
    return IsUnitOwnedByPlayer(u, p)
endfunction

function RC_PartyHero takes unit u returns boolean
    local integer n = 0
    if u == null then
        return false
    endif
    if LoadBoolean(RC_table, GetHandleId(u), 700) and RC_TypeRole(u) >= 0 then
        return true
    endif
    loop
        exitwhen n == 4
        if RC_hero[n] == u then
            return true
        endif
        set n = n + 1
    endloop
    return false
endfunction

function RC_QuestItem takes unit u, integer id returns item
    local integer role = 0
    local integer slot
    local item it
    if RC_PartyHero(u) then
        set it = GetItemOfTypeFromUnitBJ(u, id)
        if it != null then
            return it
        endif
        loop
            exitwhen role == 4
            set slot = 0
            loop
                exitwhen slot == 6
                set it = null
                if RC_hero[role] != null then
                    set it = UnitItemInSlot(RC_hero[role], slot)
                endif
                if GetItemTypeId(it) == id then
                    return it
                endif
                set slot = slot + 1
            endloop
            set role = role + 1
        endloop
        return null
    endif
    return GetItemOfTypeFromUnitBJ(u, id)
endfunction

function RC_HasQuestItem takes unit u, integer id returns boolean
    return RC_QuestItem(u, id) != null
endfunction

function RC_RegisterUnitEvent takes trigger t, player p, playerunitevent e, boolexpr filter returns nothing
    local integer n = 0
    if p == Player(0) then
        loop
            exitwhen n == 4
            call TriggerRegisterPlayerUnitEvent(t, RC_Player(n), e, filter)
            set n = n + 1
        endloop
    else
        call TriggerRegisterPlayerUnitEvent(t, p, e, filter)
    endif
endfunction

function RC_RegisterSkip takes trigger t, player p returns nothing
    local integer n = 0
    if p == Player(0) then
        loop
            exitwhen n == 4
            call TriggerRegisterPlayerEventEndCinematic(t, RC_Player(n))
            set n = n + 1
        endloop
    else
        call TriggerRegisterPlayerEventEndCinematic(t, p)
    endif
endfunction

function RC_CameraHome takes nothing returns nothing
    local integer n = 0
    loop
        exitwhen n == 4
        if RC_Active(n) and RC_hero[n] != null then
            call PanCameraToTimedForPlayer(RC_Player(n), GetUnitX(RC_hero[n]), GetUnitY(RC_hero[n]), 0.0)
            call SelectUnitForPlayerSingle(RC_hero[n], RC_Player(n))
        endif
        set n = n + 1
    endloop
endfunction

function RC_Cinematic takes boolean enabled, force players returns nothing
    local integer n = 0
    set RC_cinematicMode = enabled
    if not enabled then
        call RC_HideStoryActors()
    endif
    if IsPlayerInForce(Player(0), players) then
        if enabled then
            loop
                exitwhen n == 4
                if RC_hero[n] != null then
                    call IssueImmediateOrder(RC_hero[n], "stop")
                endif
                if RC_progressPanel[n] != null then
                    call DialogDisplay(RC_Owner(n), RC_progressPanel[n], false)
                endif
                set n = n + 1
            endloop
        endif
        call CinematicModeBJ(enabled, RC_force)
        if not enabled then
            call RC_CameraHome()
        endif
    else
        call CinematicModeBJ(enabled, players)
    endif
endfunction

function RC_CameraSetup takes boolean pan, camerasetup setup, player p, real duration returns nothing
    local integer n = 0
    if p == Player(0) then
        loop
            exitwhen n == 4
            call CameraSetupApplyForPlayer(pan, setup, RC_Player(n), duration)
            set n = n + 1
        endloop
    else
        call CameraSetupApplyForPlayer(pan, setup, p, duration)
    endif
endfunction

function RC_UnitsOfPlayer takes player p returns group
    local group out = CreateGroup()
    local integer n = 0
    local unit u
    if p == Player(0) then
        loop
            exitwhen n == 4
            call GroupEnumUnitsOfPlayer(RC_scratch, RC_Player(n), null)
            loop
                set u = FirstOfGroup(RC_scratch)
                exitwhen u == null
                call GroupRemoveUnit(RC_scratch, u)
                call GroupAddUnit(out, u)
            endloop
            set n = n + 1
        endloop
    else
        call GroupEnumUnitsOfPlayer(out, p, null)
    endif
    return out
endfunction

function RC_InitCache takes string name returns gamecache
    set bj_lastCreatedGameCache = RC_cache
    return RC_cache
endfunction

function RC_ReloadCache takes nothing returns boolean
    return true
endfunction

function RC_SaveCache takes gamecache cache returns boolean
    return true
endfunction

function RC_RestoreHero takes string key, string mission, gamecache cache, player owner, location point, real facing returns unit
    local integer role = -1
    if key == "Rexxar" or key == "TransitionRexxar" then
        set role = 0
    elseif key == "Rokhan" or key == "TransitionRokhan" then
        set role = 1
    elseif key == "Chen" or key == "TransitionChen" then
        set role = 2
    elseif key == "Cairne" or key == "TransitionCairne" then
        set role = 3
    endif
    if role >= 0 then
        if RC_Active(role) then
            set bj_lastLoadedUnit = RC_hero[role]
        else
            if RC_storyActor[role] == null or GetUnitTypeId(RC_storyActor[role]) == 0 then
                set RC_storyActor[role] = CreateUnit(Player(15), RC_heroType[role], GetLocationX(point), GetLocationY(point), facing)
            endif
            set bj_lastLoadedUnit = RC_storyActor[role]
            call RC_SuppressUnit(bj_lastLoadedUnit)
        endif
        call SetUnitPositionLoc(bj_lastLoadedUnit, point)
        call SetUnitFacing(bj_lastLoadedUnit, facing)
        return bj_lastLoadedUnit
    endif
    return RestoreUnitLocFacingAngleBJ(key, mission, cache, owner, point, facing)
endfunction

function RC_StartAI takes player p, string script returns nothing
    if not RC_IsPartyPlayer(p) then
        call StartCampaignAI(p, script)
    endif
endfunction

function RC_Resource takes player p, playerstate state, integer value returns nothing
    local integer gain = value - GetPlayerState(p, state)
    local integer n = 0
    local integer count = 0
    local integer share
    if p == Player(0) and RC_seconds > 0 and gain > 0 and (state == PLAYER_STATE_RESOURCE_GOLD or state == PLAYER_STATE_RESOURCE_LUMBER) then
        loop
            exitwhen n == 4
            if RC_Active(n) then
                set count = count + 1
            endif
            set n = n + 1
        endloop
        if count > 0 then
            set share = gain / count
            set n = 0
            loop
                exitwhen n == 4
                if RC_Active(n) then
                    call SetPlayerState(RC_Player(n), state, GetPlayerState(RC_Player(n), state) + share)
                endif
                set n = n + 1
            endloop
            call SetPlayerState(RC_Player(RC_host), state, GetPlayerState(RC_Player(RC_host), state) + gain - share * count)
            return
        endif
    endif
    call SetPlayerState(p, state, value)
endfunction

function RC_AdjustResource takes integer delta, player p, playerstate state returns nothing
    call RC_Resource(p, state, GetPlayerState(p, state) + delta)
endfunction

function RC_Transition takes integer target, integer area returns nothing
    if RC_transitionPending then
        return
    endif
    set RC_nextMap = target
    set RC_nextArea = area
    call RC_CollectExtraLoot()
    call RC_SaveAll(true)
    if not RC_saveOK then
        return
    endif
    call RC_Say("|cffffcc00Миссия завершена / переход в область: " + RC_filePrefix + RC_mapName[target] + ".w3x|r|nКоды выданы. Создайте эту карту по сети: каждому -load СВОЙ_КОД, ведущему затем -start.")
    call RC_Cinematic(false, RC_force)
    call CinematicFadeBJ(bj_CINEFADETYPE_FADEIN, 0.5, "ReplaceableTextures\\CameraMasks\\White_mask.tga", 0, 0, 0, 0)
    set RC_transitionPending = true
    call RC_DisableOriginals()
    call PauseAllUnitsBJ(true)
endfunction

function RC_ChangeLevel takes string name, boolean scores returns nothing
    local integer n = 0
    loop
        exitwhen n == 17
        if StringCase(name, false) == StringCase(RC_mapName[n], false) or StringCase(name, false) == StringCase("Maps\\FrozenThrone\\Campaign\\" + RC_mapName[n] + ".w3x", false) or StringCase(name, false) == StringCase(RC_mapName[n] + ".w3x", false) then
            call RC_Transition(n, 0)
            return
        endif
        set n = n + 1
    endloop
    call RC_SaveAll(true)
    call RC_Say("Завершён этап. Прогресс сохранён. Следующая миссия: " + name)
endfunction

function RC_Victory takes player p, boolean showDialog, boolean scores returns nothing
    if RC_IsPartyPlayer(p) and not RC_Active(RC_Role(p)) then
        return
    endif
    if RC_transitionPending then
        return
    endif
    // Act I's original Next_Level_Run has no SetNextLevel call at all: the
    // single-player campaign screen used to select Act II. Resolve that edge
    // explicitly so completion codes are accepted by the next act.
    if RC_nextMap == RC_map then
        if RC_act[RC_map] == 1 then
            set RC_nextMap = 5
        elseif RC_act[RC_map] == 2 then
            set RC_nextMap = 15
        elseif RC_map == 15 then
            set RC_nextMap = 16
        endif
    endif
    if RC_nextMap != RC_map then
        call RC_Transition(RC_nextMap, 0)
        return
    endif
    call RC_SaveAll(true)
    if not RC_saveOK then
        return
    endif
    call RC_Say("|cff55ff88Победа отряда!|r Код каждого героя показан в игре. Повторить: -code; резервная копия — F9.")
    call RC_Cinematic(false, RC_force)
    call CinematicFadeBJ(bj_CINEFADETYPE_FADEIN, 0.5, "ReplaceableTextures\\CameraMasks\\White_mask.tga", 0, 0, 0, 0)
    set RC_transitionPending = true
    call RC_DisableOriginals()
    call PauseAllUnitsBJ(true)
endfunction

function RC_SetNextLevel takes string name returns nothing
    local integer n = 0
    // SetNextLevel only selects a destination. Victory later emits ONE stable
    // checkpoint; it must not issue a second, different code immediately after.
    loop
        exitwhen n == 17
        if StringCase(name, false) == StringCase(RC_mapName[n], false) or StringCase(name, false) == StringCase("Maps\\FrozenThrone\\Campaign\\" + RC_mapName[n] + ".w3x", false) or StringCase(name, false) == StringCase(RC_mapName[n] + ".w3x", false) then
            set RC_nextMap = n
            set RC_nextArea = 0
            return
        endif
        set n = n + 1
    endloop
endfunction

function RC_Defeat takes player p, string message returns nothing
    if RC_IsPartyPlayer(p) and not RC_Active(RC_Role(p)) then
        return
    endif
    call RC_Say("|cffff5555Поражение отряда: |r" + message + "|nСоздайте карту заново и загрузите последние коды из Logs. Предыдущее автосохранение не перезаписано.")
    call PauseAllUnitsBJ(true)
    call RC_DisableOriginals()
    call PauseTimer(RC_tickTimer)
endfunction

function RC_SetAlliance takes player a, player b, alliancetype flag, boolean value returns nothing
    // Repeatedly changing shared vision is expensive on large classic maps.
    // Mirror story changes, but leave an already-correct alliance untouched.
    if GetPlayerAlliance(a, b, flag) != value then
        call SetPlayerAlliance(a, b, flag, value)
    endif
endfunction

function RC_Alliances takes nothing returns nothing
    local integer a = 0
    local integer b
    local integer id
    local boolean allied
    loop
        exitwhen a == 4
        set id = 0
        loop
            exitwhen id == 16
            if not RC_IsPartyPlayer(Player(id)) then
                set allied = GetPlayerAlliance(Player(0), Player(id), ALLIANCE_PASSIVE)
                call RC_SetAlliance(RC_Player(a), Player(id), ALLIANCE_PASSIVE, allied)
                call RC_SetAlliance(RC_Player(a), Player(id), ALLIANCE_SHARED_VISION, GetPlayerAlliance(Player(0), Player(id), ALLIANCE_SHARED_VISION))
                call RC_SetAlliance(RC_Player(a), Player(id), ALLIANCE_SHARED_CONTROL, GetPlayerAlliance(Player(0), Player(id), ALLIANCE_SHARED_CONTROL))
                call RC_SetAlliance(RC_Player(a), Player(id), ALLIANCE_SHARED_ADVANCED_CONTROL, GetPlayerAlliance(Player(0), Player(id), ALLIANCE_SHARED_ADVANCED_CONTROL))
                call RC_SetAlliance(RC_Player(a), Player(id), ALLIANCE_SHARED_XP, GetPlayerAlliance(Player(0), Player(id), ALLIANCE_SHARED_XP))
                call RC_SetAlliance(RC_Player(a), Player(id), ALLIANCE_SHARED_SPELLS, GetPlayerAlliance(Player(0), Player(id), ALLIANCE_SHARED_SPELLS))
                set allied = GetPlayerAlliance(Player(id), Player(0), ALLIANCE_PASSIVE)
                call RC_SetAlliance(Player(id), RC_Player(a), ALLIANCE_PASSIVE, allied)
                call RC_SetAlliance(Player(id), RC_Player(a), ALLIANCE_SHARED_VISION, GetPlayerAlliance(Player(id), Player(0), ALLIANCE_SHARED_VISION))
                call RC_SetAlliance(Player(id), RC_Player(a), ALLIANCE_SHARED_CONTROL, GetPlayerAlliance(Player(id), Player(0), ALLIANCE_SHARED_CONTROL))
                call RC_SetAlliance(Player(id), RC_Player(a), ALLIANCE_SHARED_ADVANCED_CONTROL, GetPlayerAlliance(Player(id), Player(0), ALLIANCE_SHARED_ADVANCED_CONTROL))
                call RC_SetAlliance(Player(id), RC_Player(a), ALLIANCE_SHARED_XP, GetPlayerAlliance(Player(id), Player(0), ALLIANCE_SHARED_XP))
                call RC_SetAlliance(Player(id), RC_Player(a), ALLIANCE_SHARED_SPELLS, GetPlayerAlliance(Player(id), Player(0), ALLIANCE_SHARED_SPELLS))
            endif
            set id = id + 1
        endloop
        set b = 0
        loop
            exitwhen b == 4
            if a != b then
                call RC_SetAlliance(RC_Player(a), RC_Player(b), ALLIANCE_PASSIVE, true)
                call RC_SetAlliance(RC_Player(a), RC_Player(b), ALLIANCE_SHARED_VISION, true)
                call RC_SetAlliance(RC_Player(a), RC_Player(b), ALLIANCE_SHARED_XP, true)
                call RC_SetAlliance(RC_Player(a), RC_Player(b), ALLIANCE_SHARED_SPELLS, true)
                call RC_SetAlliance(RC_Player(a), RC_Player(b), ALLIANCE_SHARED_CONTROL, false)
                call RC_SetAlliance(RC_Player(a), RC_Player(b), ALLIANCE_SHARED_ADVANCED_CONTROL, false)
            endif
            set b = b + 1
        endloop
        set a = a + 1
    endloop
endfunction

// @@BALANCE@@

function RC_Distribute takes nothing returns nothing
    local unit u
    local group deferred = CreateGroup()
    if RC_MaskCount(RC_CurrentMask()) == 0 then
        call DestroyGroup(deferred)
        set deferred = null
        return
    endif
    loop
        set u = FirstOfGroup(RC_pendingArmy)
        exitwhen u == null
        call GroupRemoveUnit(RC_pendingArmy, u)
        if GetUnitTypeId(u) != 0 and GetWidgetLife(u) > 0.405 and RC_IsPartyPlayer(GetOwningPlayer(u)) and not IsUnitType(u, UNIT_TYPE_HERO) and not IsUnitType(u, UNIT_TYPE_STRUCTURE) and not IsUnitType(u, UNIT_TYPE_SUMMONED) and not LoadBoolean(RC_table, GetHandleId(u), 1) then
            if IsUnitPaused(u) then
                call GroupAddUnit(deferred, u)
            else
                call SetUnitOwner(u, RC_ArmyOwner(RC_armyCounter), true)
                set RC_armyCounter = RC_armyCounter + 1
                call SaveBoolean(RC_table, GetHandleId(u), 1, true)
            endif
        endif
    endloop
    call GroupAddGroup(deferred, RC_pendingArmy)
    call DestroyGroup(deferred)
    set deferred = null
    set u = null
endfunction

function RC_Tick takes nothing returns nothing
    local integer n = 0
    local unit u
    if RC_transitionPending then
        return
    endif
    if not RC_Active(RC_host) then
        loop
            exitwhen n == 4
            if RC_Active(n) then
                set RC_host = n
                exitwhen true
            endif
            set n = n + 1
        endloop
    endif
    if not RC_Active(0) then
        if RC_hero[0] != null then
            call RC_AbsentActor(0, RC_hero[0])
        endif
        set RC_transitionPending = true
        call RC_DisableOriginals()
        call PauseAllUnitsBJ(true)
        call PauseTimer(RC_tickTimer)
        call PauseTimer(RC_skillTimer)
        call PauseTimer(RC_balanceTimer)
        call RC_Say("Красный игрок вышел. Для сюжета нужен Рексар: пересоздайте лобби с красным игроком и последними кодами. Файлы сохранения не перезаписаны.")
        return
    endif
    call RC_Alliances()
    call RC_ObserveStoryHeroes()
    if RC_liveMask != RC_CurrentMask() then
        set RC_liveMask = RC_CurrentMask()
        call RC_InitialArmy()
        call RC_Balance()
    endif
    call RC_ApplyStash()
    set n = 0
    loop
        exitwhen n == 4
        if RC_hero[n] != null and not RC_Active(n) then
            call RC_AbsentActor(n, RC_hero[n])
        endif
        if RC_hero[n] != null then
        if GetOwningPlayer(RC_hero[n]) != RC_Owner(n) then
            call SetUnitOwner(RC_hero[n], RC_Owner(n), true)
        endif
        if not RC_StoryCinematic() then
            if GetWidgetLife(RC_hero[n]) <= 0.405 then
                set RC_deadSeconds[n] = RC_deadSeconds[n] + 1
                if RC_deadSeconds[n] >= 15 then
                    call ReviveHero(RC_hero[n], RC_revivalX, RC_revivalY, true)
                    call SetUnitState(RC_hero[n], UNIT_STATE_MANA, GetUnitState(RC_hero[n], UNIT_STATE_MAX_MANA) * 0.5)
                    set RC_deadSeconds[n] = 0
                endif
            else
                set RC_deadSeconds[n] = 0
                if n == 0 then
                    set RC_revivalX = GetUnitX(RC_hero[n])
                    set RC_revivalY = GetUnitY(RC_hero[n])
                endif
            endif
        endif
        call RC_ProgressTick(n)
        endif
        set n = n + 1
    endloop
    if not RC_StoryCinematic() then
        call RC_DrainHiddenItems()
        set n = 0
        loop
            exitwhen n == 6
            if RC_extraItem[n] != 0 and RC_extraDrop[n] == null then
                set RC_extraDrop[n] = CreateItem(RC_ItemToLocal(RC_extraItem[n]), GetUnitX(RC_hero[0]) + n * 35.0, GetUnitY(RC_hero[0]) + 80.0)
                call SetItemCharges(RC_extraDrop[n], RC_extraCharges[n])
            endif
            set n = n + 1
        endloop
    endif
    set RC_seconds = RC_seconds + 1
    if ModuloInteger(RC_seconds, 5) == 0 and not RC_StoryCinematic() then
        call RC_Distribute()
    endif
endfunction

function RC_DropArchivedItems takes integer role returns nothing
    local integer n = 0
    local integer raw
    local integer pos
    local item it
    local string payload = RC_loadedHero[role]
    if RC_Active(role) or payload == "" or RC_archivedItemsDropped[role] then
        return
    endif
    set RC_archivedItemsDropped[role] = true
    loop
        exitwhen n == 6
        set pos = 30 + n * 8
        set raw = RC_ItemToLocal(RC_Number(SubString(payload, pos, pos + 6)))
        if raw != 0 then
            set it = CreateItem(raw, GetUnitX(RC_hero[RC_host]) + n * 40, GetUnitY(RC_hero[RC_host]) + 100 + role * 55)
            call SetItemCharges(it, RC_Number(SubString(payload, pos + 6, pos + 8)))
        endif
        set n = n + 1
    endloop
    set it = null
endfunction

function RC_ArchivedBank takes nothing returns nothing
    local integer role = 0
    local integer gold = 0
    local integer wood = 0
    local integer count = RC_MaskCount(RC_CurrentMask())
    loop
        exitwhen role == 4
        if not RC_Active(role) and RC_loadedHero[role] != "" then
            set gold = gold + RC_Number(SubString(RC_loadedHero[role], 22, 26))
            set wood = wood + RC_Number(SubString(RC_loadedHero[role], 26, 30))
        endif
        set role = role + 1
    endloop
    set role = 0
    loop
        exitwhen role == 4
        if RC_Active(role) then
            call SetPlayerState(RC_Player(role), PLAYER_STATE_RESOURCE_GOLD, GetPlayerState(RC_Player(role), PLAYER_STATE_RESOURCE_GOLD) + gold / count)
            call SetPlayerState(RC_Player(role), PLAYER_STATE_RESOURCE_LUMBER, GetPlayerState(RC_Player(role), PLAYER_STATE_RESOURCE_LUMBER) + wood / count)
        endif
        set role = role + 1
    endloop
    call SetPlayerState(RC_Player(RC_host), PLAYER_STATE_RESOURCE_GOLD, GetPlayerState(RC_Player(RC_host), PLAYER_STATE_RESOURCE_GOLD) + ModuloInteger(gold, count))
    call SetPlayerState(RC_Player(RC_host), PLAYER_STATE_RESOURCE_LUMBER, GetPlayerState(RC_Player(RC_host), PLAYER_STATE_RESOURCE_LUMBER) + ModuloInteger(wood, count))
endfunction

function RC_Ready takes nothing returns nothing
    local integer n = 0
    local integer count = 0
    local integer gold = GetPlayerState(Player(0), PLAYER_STATE_RESOURCE_GOLD)
    local integer wood = GetPlayerState(Player(0), PLAYER_STATE_RESOURCE_LUMBER)
    local boolean fresh = not RC_partyLoaded
    if RC_ready then
        return
    endif
    set RC_ready = true
    loop
        exitwhen n == 4
        if RC_loadedHero[n] != "" then
            set fresh = false
        endif
        if RC_Active(n) then
            set count = count + 1
        endif
        set n = n + 1
    endloop
    if fresh and count > 0 then
        set n = 0
        loop
            exitwhen n == 4
            if RC_Active(n) then
                call SetPlayerState(RC_Player(n), PLAYER_STATE_RESOURCE_GOLD, gold / count)
                call SetPlayerState(RC_Player(n), PLAYER_STATE_RESOURCE_LUMBER, wood / count)
            else
                call SetPlayerState(RC_Player(n), PLAYER_STATE_RESOURCE_GOLD, 0)
                call SetPlayerState(RC_Player(n), PLAYER_STATE_RESOURCE_LUMBER, 0)
            endif
            set n = n + 1
        endloop
        call SetPlayerState(RC_Player(RC_host), PLAYER_STATE_RESOURCE_GOLD, GetPlayerState(RC_Player(RC_host), PLAYER_STATE_RESOURCE_GOLD) + ModuloInteger(gold, count))
        call SetPlayerState(RC_Player(RC_host), PLAYER_STATE_RESOURCE_LUMBER, GetPlayerState(RC_Player(RC_host), PLAYER_STATE_RESOURCE_LUMBER) + ModuloInteger(wood, count))
    endif
    set n = 0
    call RC_ObserveStoryHeroes()
    call RC_ApplyStash()
    call RC_Alliances()
    call RC_Balance()
    loop
        exitwhen n == 4
        if RC_Active(n) and RC_loadedHero[n] != "" then
            call RC_ApplyHero(n, RC_loadedHero[n])
        endif
        call RC_DropArchivedItems(n)
        if RC_Active(n) then
            call RC_Tell(RC_Player(n), 30, "Твой герой: " + RC_heroName[n] + ". Обучение: кнопка K. Таланты: кнопка T (уровни 4/8/12/16/20). Сохранение: -save; свой код: -code; запасные коды: F9.")
        endif
        set n = n + 1
    endloop
    call RC_ArchivedBank()
    call RC_InitialArmy()
    call RC_Distribute()
    call TimerStart(RC_tickTimer, 1.0, true, function RC_Tick)
    call TimerStart(RC_skillTimer, 0.1, true, function RK_Tick)
endfunction

function RC_Begin takes nothing returns nothing
    local integer n = 0
    local real x = GetStartLocationX(GetPlayerStartLocation(Player(0)))
    local real y = GetStartLocationY(GetPlayerStartLocation(Player(0)))
    if RC_started then
        return
    endif
    if not RC_Active(0) then
        call RC_Say("Для сюжета нужен красный игрок (Рексар). Остальные три места можно закрыть.")
        return
    endif
    set RC_liveMask = RC_CurrentMask()
    if RC_pendingStash != "" and not RC_checkpointLoaded then
        call RC_Say("Тайник ожидает код героя: введи -load КОД. Для новой игры сначала -reset.")
        return
    endif
    if RC_checkpointLoaded then
        loop
            exitwhen n == 4
            if RC_InMask(n, RC_savedMask) and RC_checkpointCode[n] == "" then
                call RC_Say("Для продолжения не хватает кода героя " + I2S(n + 1) + ". Каждый вводит -load СВОЙ_КОД; код отсутствующего игрока может ввести ведущий.")
                return
            endif
            set n = n + 1
        endloop
        set n = 0
    endif
    if RC_partyLoaded and RC_stashRequired and RC_loadedStash == "" then
        call RC_Say("В этом сохранении есть вещи в тайнике. Ведущему нужно ввести -stash КОД; начало отменено, чтобы не потерять вещи.")
        return
    endif
    if RC_loadedStash != "" and RC_Number(SubString(RC_loadedStash, 2, 4)) != RC_session then
        call RC_Say("Тайник относится к другому отряду. Загрузите правильный -stash КОД.")
        return
    endif
    loop
        exitwhen n == 4
        if RC_partyLoaded and RC_Active(n) and RC_InMask(n, RC_savedMask) and RC_loadedHero[n] == "" then
            call RC_Say("Для продолжения нужен код героя " + I2S(n + 1) + ". Введите -load или -load" + I2S(n + 1) + " КОД до старта.")
            return
        endif
        if RC_partyLoaded and RC_loadedHero[n] != "" and RC_Number(SubString(RC_loadedHero[n], 3, 5)) != RC_session then
            call RC_Say("Код героя " + I2S(n + 1) + " относится к другому отряду. Начало отменено.")
            return
        endif
        set n = n + 1
    endloop
    set RC_started = true
    call DialogDisplay(RC_Player(RC_host), RC_menu, false)
    call PauseAllUnitsBJ(false)
    call RC_SeedStory()
    if RC_partyLoaded and RC_act[RC_sourceMap] == RC_act[RC_map] then
        call RC_ApplyStory()
    endif
    set n = 0
    loop
        exitwhen n == 4
        if RC_Active(n) then
        set RC_hero[n] = CreateUnit(RC_Owner(n), RC_heroType[n], x + n * 90.0, y, 0.0)
        call SetHeroLevel(RC_hero[n], RC_defaultLevel, false)
        call RC_InstallProgress(RC_hero[n])
        call RC_ClearOldSkills(RC_hero[n], n)
        if RC_Active(n) and RC_loadedHero[n] != "" then
            call RC_ApplyHero(n, RC_loadedHero[n])
        endif
        endif
        set n = n + 1
    endloop
    call RC_InitialArmy()
    call RC_EnableOriginals()
    call SetGameDifficulty(RC_GetDifficulty())
    call ExecuteFunc("RunInitializationTriggers")
    call TimerStart(CreateTimer(), 1.0, false, function RC_Ready)
endfunction

function RC_MenuChoice takes nothing returns nothing
    local button clicked = GetClickedButton()
    local integer n = 0
    loop
        exitwhen n == 3
        if clicked == RC_difficultyButton[n] then
            if not RC_partyLoaded then
                set RC_difficulty = n
            endif
            call RC_Say("Сложность: " + RC_difficultyName[RC_difficulty] + ". Начало: -start. Продолжение: каждый вводит -load СВОЙ_КОД из конца предыдущей миссии.")
            set clicked = null
            return
        endif
        set n = n + 1
    endloop
    call RC_Begin()
    set clicked = null
endfunction

function RC_Chat takes nothing returns nothing
    local player p = GetTriggerPlayer()
    local integer role = RC_Role(p)
    local string text = GetEventPlayerChatString()
    local string payload
    local integer requested = -1
    local integer n
    if text == "-progress" and RC_started and role >= 0 and RC_hero[role] != null then
        call RC_Tell(p, 30, "REXXAR VI FIX. Уровень " + I2S(GetHeroLevel(RC_hero[role])) + "/20; опыт " + I2S(GetHeroXP(RC_hero[role])) + "; очки навыков " + I2S(GetHeroSkillPoints(RC_hero[role])) + ". Обучение: K / -skills; таланты: T / -talents.")
    elseif SubString(text, 0, 7) == "-learn " and RC_started and role >= 0 then
        set payload = StringCase(SubString(text, 7, StringLength(text)), false)
        set n = -1
        if payload == "q" or payload == "1" then
            set n = 0
        elseif payload == "w" or payload == "2" then
            set n = 1
        elseif payload == "e" or payload == "3" then
            set n = 2
        elseif payload == "r" or payload == "4" then
            set n = 3
        elseif payload == "5" then
            set n = 4
        endif
        if n < 0 or not RC_LearnRank(role, n) then
            call RC_Tell(p, 15, "Обучение: -learn q / w / e / r / 5. Нужны свободное очко и требуемый уровень; при ошибке очко не тратится.")
        endif
    elseif (text == "-skills" or text == "-skill") and RC_started then
        call RC_OpenProgress(role, 0, 0)
    elseif (text == "-talents" or text == "-таланты") and RC_started then
        call RC_OpenProgress(role, 1, 0)
    elseif text == "-code" and RC_started then
        call RC_ShowCode(role)
    elseif text == "-codes" and RC_started and role == RC_host then
        set n = 0
        loop
            exitwhen n == 4
            call RC_Tell(p, 120, "Герой " + I2S(n + 1) + ": -load " + RC_checkpointCode[n])
            set n = n + 1
        endloop
    elseif text == "-reset" and not RC_started and role == RC_host then
        call RC_ResetCheckpoint()
    elseif text == "-save" and RC_started and not RC_transitionPending then
        call RC_SaveAll(true)
    elseif text == "-start" and p == RC_Player(RC_host) then
        call RC_Begin()
    elseif SubString(text, 0, 7) == "-party " and not RC_started and not RC_checkpointLoaded and p == RC_Player(RC_host) then
        if RC_LoadParty(SubString(text, 7, StringLength(text))) then
            call RC_Say("Прогресс отряда принят. Сложность: " + RC_difficultyName[RC_difficulty] + ". Загрузите героев и введите -start.")
        else
            call RC_Say("Неверный код отряда: длина, версия или контрольная сумма.")
        endif
    elseif SubString(text, 0, 7) == "-stash " and not RC_started and p == RC_Player(RC_host) then
        if RC_AcceptStash(SubString(text, 7, StringLength(text))) then
            call RC_Say("Код тайника принят. После кодов сохранённого состава ведущий вводит -start.")
        else
            call RC_Say("Код тайника не принят: проверь версию и завершение миссии.")
        endif
    elseif SubString(text, 0, 6) == "-load " and not RC_started then
        set requested = role
        set payload = SubString(text, 6, StringLength(text))
        if (SubString(payload, 0, 2) == "C2" or SubString(payload, 0, 2) == "Z3" or SubString(payload, 0, 2) == "C3" or SubString(payload, 0, 2) == "Z4" or SubString(payload, 0, 2) == "C4" or SubString(payload, 0, 2) == "Z5" or SubString(payload, 0, 2) == "Z6") then
            if not RC_LoadCheckpoint(payload, role) then
                call RC_Say("Код не принят. Проверь карту, номер героя и все символы; введи код из того же завершения миссии, что остальные.")
            endif
            return
        endif
    elseif SubString(text, 0, 5) == "-load" and SubString(text, 6, 7) == " " and not RC_started then
        set requested = S2I(SubString(text, 5, 6)) - 1
        set payload = SubString(text, 7, StringLength(text))
        if p != RC_Player(RC_host) and requested != role then
            set requested = -1
        endif
    endif
    if requested >= 0 and requested < 4 and not RC_checkpointLoaded then
        if RC_Valid(payload, 81, "H") and RC_Number(SubString(payload, 2, 3)) == requested then
            set RC_loadedHero[requested] = payload
            call RC_Say("Герой " + I2S(requested + 1) + " загружен: " + RC_heroName[requested] + ".")
        else
            call RC_Say("Код героя не принят: проверь версию, номер героя и контрольную сумму.")
        endif
    endif
    set p = null
endfunction

function RC_Menu takes nothing returns nothing
    local trigger chat = CreateTrigger()
    local trigger choices = CreateTrigger()
    local trigger spells = CreateTrigger()
    local integer n = 0
    local integer column
    local string character
    set RC_cache = InitGameCache("RexxarCoop.w3v")
    call FlushGameCache(RC_cache)
    set RC_table = InitHashtable()
    set RC_digits = InitHashtable()
    set RC_items = InitHashtable()
    set RC_codec = InitHashtable()
    loop
        exitwhen n == 64
        set character = SubString(RC_alphabet, n, n + 1)
        set column = 0
        if StringCase(character, true) != character then
            set column = 1
        endif
        call SaveInteger(RC_digits, StringHash(character), column, n + 1)
        set n = n + 1
    endloop
    call RC_InitItems()
    set n = 0
    set RC_scratch = CreateGroup()
    set RC_army = CreateGroup()
    set RC_hiddenActors = CreateGroup()
    set RC_hiddenLoot = CreateGroup()
    set RC_pendingArmy = CreateGroup()
    set RC_skillGroup = CreateGroup()
    set RC_balanceGroup = CreateGroup()
    set RC_damageUnits = CreateGroup()
    set RC_damageTrigger = CreateTrigger()
    call TriggerAddAction(RC_damageTrigger, function RC_Damaged)
    set RC_skillTimer = CreateTimer()
    set RC_balanceTimer = CreateTimer()
    set RC_tickTimer = CreateTimer()
    if RC_menuClock == null then
        set RC_menuClock = CreateTimer()
        call TimerStart(RC_menuClock, 86400.0, false, null)
    endif
    set RC_force = CreateForce()
    loop
        exitwhen n == 4
        call ForceAddPlayer(RC_force, RC_Player(n))
        call TriggerRegisterPlayerChatEvent(chat, RC_Player(n), "-", false)
        call TriggerRegisterPlayerUnitEvent(spells, RC_Player(n), EVENT_PLAYER_UNIT_SPELL_EFFECT, null)
        set n = n + 1
    endloop
    call TriggerAddAction(chat, function RC_Chat)
    call TriggerAddAction(spells, function RC_Spell)
    // @@INIT@@
    call RC_InitProgress()
    call RC_InitExperience()
    if not RC_originalsGated then
        call RC_DisableOriginals()
        set RC_originalsGated = true
    endif
    call PauseAllUnitsBJ(true)
    call RC_InitialAlliances()
    set RC_saveQuest = CreateQuest()
    call QuestSetTitle(RC_saveQuest, "Сохранение отряда")
    call QuestSetDescription(RC_saveQuest, "После завершения миссии или перехода каждый получит ОДИН код. В следующей карте каждый вводит -load СВОЙ_КОД, затем ведущий -start. Сюжет и тайник уже включены. Здесь появятся коды героев, участвовавших в сохранении.")
    call QuestSetIconPath(RC_saveQuest, "ReplaceableTextures\\CommandButtons\\BTNScroll.blp")
    call QuestSetRequired(RC_saveQuest, false)
    call QuestSetDiscovered(RC_saveQuest, true)
    set n = 0
    loop
        exitwhen n == 4
        set RC_codeQuest[n] = CreateQuest()
        call QuestSetTitle(RC_codeQuest[n], "Код продолжения: герой " + I2S(n + 1))
        call QuestSetDescription(RC_codeQuest[n], "Код будет выдан после прохождения миссии или перехода в другую область. Отдельные команды для сюжета и тайника не нужны.")
        call QuestSetRequired(RC_codeQuest[n], false)
        call QuestSetDiscovered(RC_codeQuest[n], RC_Active(n))
        set n = n + 1
    endloop
    set RC_helpQuest = CreateQuest()
    call QuestSetTitle(RC_helpQuest, "Герои и правила")
    call QuestSetDescription(RC_helpQuest, "Кнопка K — изучение Q/W/E/R за очки героя. Кнопка T — пять рядов талантов с выбором на уровнях 4/8/12/16/20. Опыт за убийство: 24 + 8 за уровень врага каждому живому герою рядом (1600). Рексар — возвращающийся топор и охота; Рокхан — тотем и якорь души; Чэнь — мокрые метки и огненные связки; Кэрн — броня и накопление урона для ответного удара.|nУ каждого свои вещи и навыки. Квестовые войска делятся между присутствующими. Герой возрождается через 15 сек. Сюжетные спутники заменяют временных с переносом развития.|nВ конце миссии получи код. Повторить: -code, копия: F9. В следующей карте каждому -load КОД, затем ведущему -start.")
    call QuestSetIconPath(RC_helpQuest, "ReplaceableTextures\\CommandButtons\\BTNBeastMaster.blp")
    call QuestSetRequired(RC_helpQuest, false)
    call QuestSetDiscovered(RC_helpQuest, true)
    set RC_menu = DialogCreate()
    call DialogSetMessage(RC_menu, "Рексар: от 1 до 4 игроков|nВыбери сложность. Сохранения вводятся в чат до -start.")
    set RC_difficultyButton[0] = DialogAddButton(RC_menu, "Лёгкая", 0)
    set RC_difficultyButton[1] = DialogAddButton(RC_menu, "Обычная", 0)
    set RC_difficultyButton[2] = DialogAddButton(RC_menu, "Тяжёлая", 0)
    call DialogAddButton(RC_menu, "Начать новую — обычная", 0)
    call TriggerRegisterDialogEvent(choices, RC_menu)
    call TriggerAddAction(choices, function RC_MenuChoice)
    call DialogDisplay(RC_Player(RC_host), RC_menu, true)
    call RC_Say("Новая игра: выбрать сложность, затем -start. Продолжение: каждый вводит -load СВОЙ_КОД из конца предыдущей миссии; затем ведущий -start.")
    set chat = null
    set choices = null
    set spells = null
endfunction

function RC_Bootstrap takes nothing returns nothing
    // Gate original timers immediately, but defer runtime allocation and dialog
    // display until the engine has left the map-loading/main JASS thread.
    call RC_DisableOriginals()
    set RC_originalsGated = true
    set RC_menuClock = CreateTimer()
    call TimerStart(RC_menuClock, 86400.0, false, null)
    call TimerStart(CreateTimer(), 0.10, false, function RC_Menu)
endfunction

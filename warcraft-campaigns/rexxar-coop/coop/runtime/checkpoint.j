// C2: one chat-sized checkpoint per hero. Shared story is repeated in every
// code; the twelve stash/companion slots are split into four three-slot parts.
// All four codes must match before starting, including for absent roles.
function RC_ItemCompact takes integer raw returns integer
    local integer index
    if raw == 0 then
        return 0
    endif
    set index = LoadInteger(RC_items, raw, 2)
    if index == 0 then
        set RC_codeOK = false
    endif
    return index
endfunction

function RC_ItemExpand takes integer index returns integer
    if index < 0 or index >= RC_itemCount then
        set RC_codeOK = false
        return 0
    endif
    return LoadInteger(RC_items, index, 3)
endfunction

function RC_BitsPut takes integer value, integer width returns nothing
    if value < 0 then
        set RC_codeOK = false
        return
    endif
    loop
        exitwhen width == 0
        set RC_bitValue = RC_bitValue + ModuloInteger(value, 2) * RC_bitPower
        set RC_bitPower = RC_bitPower * 2
        set value = value / 2
        set width = width - 1
        if RC_bitPower == 64 then
            set RC_bitText = RC_bitText + RC_Pack(RC_bitValue, 1)
            set RC_bitValue = 0
            set RC_bitPower = 1
        endif
    endloop
    if value != 0 then
        set RC_codeOK = false
    endif
endfunction

function RC_BitsGet takes integer width returns integer
    local integer value = 0
    local integer power = 1
    loop
        exitwhen width == 0
        if RC_bitPower == 1 then
            set RC_bitValue = RC_Number(SubString(RC_bitText, RC_bitPosition, RC_bitPosition + 1))
            set RC_bitPosition = RC_bitPosition + 1
            set RC_bitPower = 64
        endif
        set value = value + ModuloInteger(RC_bitValue, 2) * power
        set RC_bitValue = RC_bitValue / 2
        set RC_bitPower = RC_bitPower / 2
        set power = power * 2
        set width = width - 1
    endloop
    return value
endfunction

function RC_SmallStory takes nothing returns string
    local integer n = 0
    set RC_bitValue = 0
    set RC_bitPower = 1
    set RC_bitText = ""
    call RC_CollectStory()
    loop
        exitwhen n == RC_storyCount
        call RC_BitsPut(RC_story[n], RC_storyBits[n])
        set n = n + 1
    endloop
    if RC_bitPower != 1 then
        set RC_bitText = RC_bitText + RC_Pack(RC_bitValue, 1)
    endif
    return RC_bitText
endfunction

function RC_ReadSmallStory takes string text returns boolean
    local integer n = 0
    set RC_bitValue = 0
    set RC_bitPower = 1
    set RC_bitPosition = 0
    set RC_bitText = text
    loop
        exitwhen n == RC_storyCount
        set RC_tempStory[n] = RC_BitsGet(RC_storyBits[n])
        set n = n + 1
    endloop
    return RC_codeOK and RC_bitValue == 0 and RC_bitPosition == RC_storyChars
endfunction

function RC_MakeCheckpoint takes integer role, string hero, string story, string stash returns string
    local integer n = 0
    local integer pos
    local integer flags = RC_flags[0] + RC_flags[1] * 2 + RC_flags[2] * 4 + RC_flags[3] * 8
    local string text = "C2" + RC_Pack(role, 1) + RC_Pack(RC_session, 2) + RC_Pack(RC_checkpoint, 3) + RC_Pack(RC_map, 1) + RC_Pack(RC_nextMap, 1) + RC_Pack(RC_nextArea, 2) + RC_Pack(RC_difficulty, 1) + RC_Pack(flags, 1) + story + SubString(hero, 6, 30)
    loop
        exitwhen n == 6
        set pos = 30 + n * 8
        set text = text + RC_Pack(RC_ItemCompact(RC_Number(SubString(hero, pos, pos + 6))), 2) + SubString(hero, pos + 6, pos + 8)
        set n = n + 1
    endloop
    set n = 0
    loop
        exitwhen n == 3
        set pos = 5 + (role * 3 + n) * 8
        set text = text + RC_Pack(RC_ItemCompact(RC_Number(SubString(stash, pos, pos + 6))), 2) + SubString(stash, pos + 6, pos + 8)
        set n = n + 1
    endloop
    return RC_Seal(text)
endfunction

function RC_CheckpointValid takes string text returns boolean
    local integer check
    local integer actual
    set RC_codeOK = true
    if StringLength(text) != RC_checkpointLength or SubString(text, 0, 2) != "C2" then
        return false
    endif
    set check = RC_Number(SubString(text, RC_checkpointLength - 3, RC_checkpointLength))
    set actual = RC_Checksum(SubString(text, 0, RC_checkpointLength - 3))
    return RC_codeOK and check == actual
endfunction

function RC_LoadCheckpoint takes string text, integer sender returns boolean
    local integer role
    local integer n = 0
    local integer pos = 14 + RC_storyChars
    local integer id
    local integer flags
    local string hero
    local string part = ""
    local string stash
    local string common
    if not RC_CheckpointValid(text) then
        return false
    endif
    set role = RC_Number(SubString(text, 2, 3))
    if role > 3 or (sender != RC_host and sender != role) then
        return false
    endif
    if RC_Number(SubString(text, 8, 9)) > 16 or RC_Number(SubString(text, 9, 10)) != RC_map or RC_Number(SubString(text, 12, 13)) > 2 or RC_Number(SubString(text, 13, 14)) > 15 then
        call RC_Say("Этот код предназначен для другой карты или версии. Откройте указанную при завершении миссию.")
        return false
    endif
    set common = SubString(text, 3, 14 + RC_storyChars)
    if RC_loadedGroup != "" and RC_loadedGroup != common then
        call RC_Say("Коды из разных завершений миссии смешаны. Введите четыре кода одного прохождения. Ведущий может очистить выбор: -reset.")
        return false
    endif
    if not RC_ReadSmallStory(SubString(text, 14, 14 + RC_storyChars)) then
        return false
    endif
    set hero = "H1" + SubString(text, 2, 5) + SubString(text, 8, 9) + SubString(text, pos, pos + 24)
    set pos = pos + 24
    loop
        exitwhen n == 6
        set id = RC_ItemExpand(RC_Number(SubString(text, pos, pos + 2)))
        set hero = hero + RC_Pack(id, 6) + SubString(text, pos + 2, pos + 4)
        set pos = pos + 4
        set n = n + 1
    endloop
    set n = 0
    loop
        exitwhen n == 3
        set id = RC_ItemExpand(RC_Number(SubString(text, pos, pos + 2)))
        set part = part + RC_Pack(id, 6) + SubString(text, pos + 2, pos + 4)
        set pos = pos + 4
        set n = n + 1
    endloop
    set hero = RC_Seal(hero)
    if not RC_codeOK then
        return false
    endif
    // Only commit after every field/checksum/catalog index has been validated.
    set RC_loadedGroup = common
    set RC_checkpointLoaded = true
    set RC_partyLoaded = true
    set RC_session = RC_Number(SubString(text, 3, 5))
    set RC_checkpoint = RC_Number(SubString(text, 5, 8))
    set RC_sourceMap = RC_Number(SubString(text, 8, 9))
    set RC_nextMap = RC_map
    set RC_nextArea = RC_Number(SubString(text, 10, 12))
    set RC_difficulty = RC_Number(SubString(text, 12, 13))
    set flags = RC_Number(SubString(text, 13, 14))
    set n = 0
    loop
        exitwhen n == 4
        set RC_flags[n] = ModuloInteger(flags, 2)
        set flags = flags / 2
        set n = n + 1
    endloop
    set n = 0
    loop
        exitwhen n == RC_storyCount
        set RC_story[n] = RC_tempStory[n]
        set n = n + 1
    endloop
    set RC_loadedHero[role] = hero
    set RC_checkpointPart[role] = part
    set RC_checkpointCode[role] = text
    set stash = "S1" + RC_Pack(RC_session, 2) + RC_Pack(RC_sourceMap, 1)
    set n = 0
    loop
        exitwhen n == 4
        if RC_checkpointPart[n] == "" then
            call RC_Say("Код героя " + I2S(role + 1) + " принят. Нужны коды всех четырёх героев; после них ведущий вводит -start.")
            return true
        endif
        set stash = stash + RC_checkpointPart[n]
        set n = n + 1
    endloop
    set RC_loadedStash = RC_Seal(stash)
    set n = 0
    loop
        exitwhen n == 6
        set RC_extraItem[n] = RC_Number(SubString(stash, 53 + n * 8, 59 + n * 8))
        set RC_extraCharges[n] = RC_Number(SubString(stash, 59 + n * 8, 61 + n * 8))
        set n = n + 1
    endloop
    call RC_Say("|cff55ff88Все четыре кода приняты: герои, сюжет и тайник. Ведущий вводит -start.|r")
    return true
endfunction

function RC_ShowCode takes integer role returns nothing
    if RC_checkpointCode[role] == "" then
        call DisplayTimedTextToPlayer(RC_Owner(role), 0, 0, 25, "Код появится после прохождения миссии или перехода в другую область.")
        return
    endif
    call DisplayTimedTextToPlayer(RC_Owner(role), 0, 0, 120, "|cffffcc00Следующая карта: RC-" + RC_mapName[RC_nextMap] + ".w3x. В ней введи:|r")
    call DisplayTimedTextToPlayer(RC_Owner(role), 0, 0, 120, "-load " + RC_checkpointCode[role])
endfunction

function RC_ResetCheckpoint takes nothing returns nothing
    local integer n = 0
    set RC_loadedGroup = ""
    set RC_checkpointLoaded = false
    set RC_partyLoaded = false
    set RC_stashRequired = false
    set RC_loadedStash = ""
    set RC_sourceMap = RC_map
    set RC_nextMap = RC_map
    set RC_nextArea = 0
    set RC_checkpoint = 0
    loop
        exitwhen n == 4
        set RC_loadedHero[n] = ""
        set RC_checkpointCode[n] = ""
        set RC_checkpointPart[n] = ""
        set RC_flags[n] = 0
        set n = n + 1
    endloop
    set RC_flags[0] = 1
    set n = 0
    loop
        exitwhen n == RC_storyCount
        set RC_story[n] = 0
        set n = n + 1
    endloop
    set n = 0
    loop
        exitwhen n == 6
        set RC_extraItem[n] = 0
        set RC_extraCharges[n] = 0
        set n = n + 1
    endloop
    call RC_Say("Выбор сохранений очищен. Можно заново ввести четыре кода одного прохождения.")
endfunction

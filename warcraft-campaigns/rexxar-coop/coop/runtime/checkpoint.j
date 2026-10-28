// C3/Z4: one chat-sized checkpoint per hero, including five talent picks. Shared story is repeated in every
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

// Z3/C2 and Z4/C3 use the same lossless run-length envelope. A dot followed by one
// alphabet digit encodes 3..63 zeroes; malformed envelopes never reach state.
function RC_RLECode takes string text returns string
    local string out = "Z3"
    local integer pos = 2
    local integer count
    if SubString(text, 0, 2) == "C3" then
        set out = "Z4"
    elseif SubString(text, 0, 2) == "C4" then
        set out = "Z5"
    endif
    loop
        exitwhen pos >= StringLength(text)
        set count = 0
        loop
            exitwhen pos + count >= StringLength(text) or count == 63 or SubString(text, pos + count, pos + count + 1) != "0"
            set count = count + 1
        endloop
        if count >= 3 then
            set out = out + "." + SubString(RC_alphabet, count, count + 1)
            set pos = pos + count
        else
            set out = out + SubString(text, pos, pos + 1)
            set pos = pos + 1
        endif
    endloop
    return out
endfunction

// Z6 adds short back-references to repeated non-zero data. A hash table finds
// one candidate per position; no quadratic sliding-window scan in classic JASS.
// Keep the old envelope whenever it is shorter. Both expand to the SAME C4.
function RC_CompactCode takes string text returns string
    local string fallback = RC_RLECode(text)
    local string out = "Z6"
    local string prefix
    local integer pos = 2
    local integer previous
    local integer count
    local integer zeroes
    local integer key
    if SubString(text, 0, 2) != "C4" then
        return fallback
    endif
    call FlushChildHashtable(RC_codec, 0)
    loop
        exitwhen pos >= StringLength(text)
        set count = 0
        if pos + 4 <= StringLength(text) then
            set prefix = SubString(text, pos, pos + 4)
            set key = StringHash(prefix)
            set previous = LoadInteger(RC_codec, 0, key)
            call SaveInteger(RC_codec, 0, key, pos)
            if previous >= 2 and previous < pos and pos - previous <= 63 and SubString(text, previous, previous + 4) == prefix then
                loop
                    exitwhen count == 63 or pos + count >= StringLength(text) or SubString(text, previous + count, previous + count + 1) != SubString(text, pos + count, pos + count + 1)
                    set count = count + 1
                endloop
            endif
        endif
        set zeroes = 0
        loop
            exitwhen zeroes == 63 or pos + zeroes >= StringLength(text) or SubString(text, pos + zeroes, pos + zeroes + 1) != "0"
            set zeroes = zeroes + 1
        endloop
        if count >= 4 and count > zeroes then
            set out = out + "~" + RC_Pack(pos - previous, 1) + RC_Pack(count, 1)
            set pos = pos + count
        elseif zeroes >= 3 then
            set out = out + "." + RC_Pack(zeroes, 1)
            set pos = pos + zeroes
        else
            set out = out + SubString(text, pos, pos + 1)
            set pos = pos + 1
        endif
    endloop
    if StringLength(out) < StringLength(fallback) then
        return out
    endif
    return fallback
endfunction

function RC_ExpandCode takes string text returns string
    local string out = "C2"
    local string c
    local integer pos = 2
    local integer count
    local integer distance
    local integer maximum = RC_checkpointLength - 2
    if SubString(text, 0, 2) == "Z5" or SubString(text, 0, 2) == "Z6" then
        set out = "C4"
        set maximum = 142
    elseif SubString(text, 0, 2) == "Z4" then
        set out = "C3"
        set maximum = RC_checkpointLength
    elseif SubString(text, 0, 2) != "Z3" then
        return text
    endif
    loop
        exitwhen pos >= StringLength(text)
        set c = SubString(text, pos, pos + 1)
        if c == "~" and SubString(text, 0, 2) == "Z6" then
            if pos + 2 >= StringLength(text) then
                return ""
            endif
            set distance = RC_Digit(SubString(text, pos + 1, pos + 2))
            set count = RC_Digit(SubString(text, pos + 2, pos + 3))
            if distance < 1 or distance > StringLength(out) - 2 or count < 4 or StringLength(out) + count > maximum then
                return ""
            endif
            loop
                exitwhen count == 0
                set out = out + SubString(out, StringLength(out) - distance, StringLength(out) - distance + 1)
                set count = count - 1
            endloop
            set pos = pos + 3
        elseif c == "." then
            if pos + 1 >= StringLength(text) then
                return ""
            endif
            set count = RC_Digit(SubString(text, pos + 1, pos + 2))
            if count < 3 or StringLength(out) + count > maximum then
                return ""
            endif
            loop
                exitwhen count == 0
                set out = out + "0"
                set count = count - 1
            endloop
            set pos = pos + 2
        else
            if RC_Digit(c) < 0 then
                return ""
            endif
            set out = out + c
            set pos = pos + 1
        endif
        if StringLength(out) > maximum then
            return ""
        endif
    endloop
    return out
endfunction

function RC_MakeCheckpoint takes integer role, string hero, string story, string stash returns string
    local integer n = 0
    local integer pos
    local integer flags = RC_flags[0] + RC_flags[1] * 2 + RC_flags[2] * 4 + RC_flags[3] * 8
    local string text = "C3" + RC_Pack(role, 1) + RC_Pack(RC_session, 2) + RC_Pack(RC_checkpoint, 3) + RC_Pack(RC_map, 1) + RC_Pack(RC_nextMap, 1) + RC_Pack(RC_nextArea, 2) + RC_Pack(RC_difficulty, 1) + RC_Pack(flags, 1) + story + SubString(hero, 6, 30)
    loop
        exitwhen n == 6
        set pos = 30 + n * 8
        set text = text + RC_Pack(RC_ItemCompact(RC_Number(SubString(hero, pos, pos + 6))), 2) + SubString(hero, pos + 6, pos + 8)
        set n = n + 1
    endloop
    if RC_talents[role] < 0 or RC_talents[role] > 242 then
        set RC_codeOK = false
    endif
    set text = text + RC_Pack(RC_talents[role], 2)
    set n = 0
    loop
        exitwhen n == 3
        set pos = 5 + (role * 3 + n) * 8
        set text = text + RC_Pack(RC_ItemCompact(RC_Number(SubString(stash, pos, pos + 6))), 2) + SubString(stash, pos + 6, pos + 8)
        set n = n + 1
    endloop
    return RC_CompactCode(RC_Seal(text))
endfunction

function RC_CheckpointValid takes string text returns boolean
    local integer check
    local integer actual
    local integer expected = RC_checkpointLength
    local integer bits
    local integer inlineMode
    set RC_codeOK = true
    set text = RC_ExpandCode(text)
    if SubString(text, 0, 2) == "C4" then
        set bits = RC_Number(SubString(text, 14, 15))
        set inlineMode = RC_Number(SubString(text, 15, 16))
        if bits < 1 or bits > 15 or inlineMode > 1 or not RC_InMask(RC_Number(SubString(text, 2, 3)), bits) then
            return false
        endif
        set expected = 94
        if inlineMode == 1 then
            set expected = expected + (12 / RC_MaskCount(bits)) * 4
        endif
    elseif SubString(text, 0, 2) == "C2" then
        set expected = expected - 2
    elseif SubString(text, 0, 2) != "C3" then
        return false
    endif
    if StringLength(text) != expected then
        return false
    endif
    set check = RC_Number(SubString(text, expected - 3, expected))
    set actual = RC_Checksum(SubString(text, 0, expected - 3))
    return RC_codeOK and check == actual
endfunction

// @@PARTY_CHECKPOINT@@

function RC_LoadCheckpoint takes string text, integer sender returns boolean
    local integer role
    local integer n = 0
    local integer pos = 14 + RC_storyChars
    local integer id
    local integer flags
    local integer talentValue = 0
    local integer bits = 15
    local integer inlineMode = 1
    local integer storyStart = 14
    local integer slots = 3
    local string hero
    local string part = ""
    local string stash
    local string common
    set text = RC_ExpandCode(text)
    if not RC_CheckpointValid(text) then
        return false
    endif
    if SubString(text, 0, 2) == "C4" then
        set bits = RC_Number(SubString(text, 14, 15))
        set inlineMode = RC_Number(SubString(text, 15, 16))
        set storyStart = 16
        set slots = 0
        if inlineMode == 1 then
            set slots = 12 / RC_MaskCount(bits)
        endif
    endif
    set pos = storyStart + RC_storyChars
    set role = RC_Number(SubString(text, 2, 3))
    if role > 3 or (sender != RC_host and sender != role) then
        return false
    endif
    if RC_Number(SubString(text, 8, 9)) > 16 or RC_Number(SubString(text, 9, 10)) != RC_map or RC_Number(SubString(text, 12, 13)) > 2 or RC_Number(SubString(text, 13, 14)) > 15 then
        call RC_Say("Этот код предназначен для другой карты или версии. Откройте указанную при завершении миссию.")
        return false
    endif
    set common = SubString(text, 3, storyStart + RC_storyChars)
    if RC_loadedGroup != "" and RC_loadedGroup != common then
        call RC_Say("Коды из разных завершений миссии смешаны. Введите четыре кода одного прохождения. Ведущий может очистить выбор: -reset.")
        return false
    endif
    if not RC_ReadSmallStory(SubString(text, storyStart, storyStart + RC_storyChars)) then
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
    if SubString(text, 0, 2) == "C3" or SubString(text, 0, 2) == "C4" then
        set talentValue = RC_Number(SubString(text, pos, pos + 2))
        set pos = pos + 2
        if talentValue > 242 then
            return false
        endif
    endif
    set n = 0
    loop
        exitwhen n == slots
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
    set RC_savedMask = bits
    set RC_savedInline = inlineMode
    set RC_stashRequired = true
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
    set RC_talents[role] = talentValue
    set RC_loadedHero[role] = hero
    set RC_checkpointPart[role] = part
    set RC_checkpointCode[role] = RC_CompactCode(text)
    set stash = "S1" + RC_Pack(RC_session, 2) + RC_Pack(RC_sourceMap, 1)
    set n = 0
    loop
        exitwhen n == 4
        if RC_InMask(n, RC_savedMask) then
            if RC_checkpointCode[n] == "" then
                call RC_Say("Код героя " + I2S(role + 1) + " принят. Нужны остальные коды состава этого сохранения.")
                return true
            endif
            set stash = stash + RC_checkpointPart[n]
        endif
        set n = n + 1
    endloop
    if inlineMode == 0 then
        if RC_pendingStash != "" then
            call RC_AcceptStash(RC_pendingStash)
        endif
        call RC_Say("Коды героев приняты. Для заполненного тайника нужен -stash КОД из того же сохранения, затем -start.")
        return true
    endif
    set RC_loadedStash = RC_Seal(stash)
    set n = 0
    loop
        exitwhen n == 6
        set RC_extraItem[n] = RC_Number(SubString(stash, 53 + n * 8, 59 + n * 8))
        set RC_extraCharges[n] = RC_Number(SubString(stash, 59 + n * 8, 61 + n * 8))
        set n = n + 1
    endloop
    call RC_Say("|cff55ff88Все коды сохранённого состава приняты: герои, сюжет и тайник. Ведущий вводит -start.|r")
    return true
endfunction

function RC_ShowCode takes integer role returns nothing
    if RC_checkpointCode[role] == "" then
        call RC_Tell(RC_Owner(role), 25, "Код появится после завершения или команды -save.")
        return
    endif
    call RC_Tell(RC_Owner(role), 120, "|cffffcc00" + RC_filePrefix + RC_mapName[RC_nextMap] + ".w3x|r → -load " + RC_checkpointCode[role])
    if role == RC_host and RC_externalStash != "" then
        call RC_Tell(RC_Owner(role), 120, "Дополнительно для тайника: -stash " + RC_externalStash)
    endif
endfunction

function RC_ResetCheckpoint takes nothing returns nothing
    local integer n = 0
    set RC_savedMask = 15
    set RC_savedInline = 1
    set RC_pendingStash = ""
    set RC_externalStash = ""
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
        set RC_talents[n] = 0
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

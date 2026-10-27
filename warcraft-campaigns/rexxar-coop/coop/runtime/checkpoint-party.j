// C4/Z5 carries the saved party mask. Inline stash is split only among roles
// actually present. A dense solo stash uses one extra S2 command (never >127).
function RC_ExternalStash takes string stash returns string
    return RC_Seal("S2" + SubString(stash, 2, 5) + RC_Pack(RC_checkpoint, 3) + RC_Pack(RC_nextMap, 1) + SubString(stash, 5, 101))
endfunction

function RC_AcceptStash takes string text returns boolean
    local string canonical
    local integer n = 0
    if RC_Valid(text, 108, "S") and SubString(text, 0, 2) == "S2" then
        if not RC_checkpointLoaded then
            set RC_pendingStash = text
            return true
        endif
        if RC_Number(SubString(text, 2, 4)) != RC_session or RC_Number(SubString(text, 4, 5)) != RC_sourceMap or RC_Number(SubString(text, 5, 8)) != RC_checkpoint or RC_Number(SubString(text, 8, 9)) != RC_map or RC_savedInline != 0 then
            return false
        endif
        set canonical = RC_Seal("S1" + SubString(text, 2, 5) + SubString(text, 9, 105))
    elseif not RC_checkpointLoaded and RC_Valid(text, 104, "S") and SubString(text, 0, 2) == "S1" then
        set canonical = text
    else
        return false
    endif
    set RC_loadedStash = canonical
    set RC_stashRequired = true
    set RC_pendingStash = ""
    loop
        exitwhen n == 6
        set RC_extraItem[n] = RC_Number(SubString(canonical, 53 + n * 8, 59 + n * 8))
        set RC_extraCharges[n] = RC_Number(SubString(canonical, 59 + n * 8, 61 + n * 8))
        set n = n + 1
    endloop
    return true
endfunction

function RC_PartyCheckpoint takes integer role, string hero, string story, string stash returns string
    local integer n = 0
    local integer pos
    local integer slots = 0
    local integer offset = 0
    local integer flags = RC_flags[0] + RC_flags[1] * 2 + RC_flags[2] * 4 + RC_flags[3] * 8
    local string text = "C4" + RC_Pack(role, 1) + RC_Pack(RC_session, 2) + RC_Pack(RC_checkpoint, 3) + RC_Pack(RC_map, 1) + RC_Pack(RC_nextMap, 1) + RC_Pack(RC_nextArea, 2) + RC_Pack(RC_difficulty, 1) + RC_Pack(flags, 1) + RC_Pack(RC_savedMask, 1) + RC_Pack(RC_savedInline, 1) + story + SubString(hero, 6, 30)
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
    if RC_savedInline == 1 then
        set slots = 12 / RC_MaskCount(RC_savedMask)
        set offset = RC_PartRank(role, RC_savedMask) * slots
    endif
    set n = 0
    loop
        exitwhen n == slots
        set pos = 5 + (offset + n) * 8
        set text = text + RC_Pack(RC_ItemCompact(RC_Number(SubString(stash, pos, pos + 6))), 2) + SubString(stash, pos + 6, pos + 8)
        set n = n + 1
    endloop
    return RC_CompactCode(RC_Seal(text))
endfunction

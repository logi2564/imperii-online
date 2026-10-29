// W1 is a checked world-state envelope around an unchanged legacy hero code.
// Only classic natives; every kill/ownership change runs on all clients.
function UW_Register takes unit u, integer z, integer index returns nothing
    set UW_unit[z*256+index]=u
    set UW_registered[z]=UW_registered[z]+1
endfunction

function UW_Bit takes integer value, integer bit returns boolean
    loop
        exitwhen bit==0
        set value=value/2
        set bit=bit-1
    endloop
    return ModuloInteger(value,2)==1
endfunction

function UW_Wrap takes string inner, string world returns string
    local string encoded
    local string check
    if world=="" then
        return inner
    endif
    set encoded=RC_RLECode("C4"+world)
    set encoded=SubString(encoded,2,StringLength(encoded))
    if StringLength(encoded)>63 then
        set RC_codeOK=false
        return ""
    endif
    set check=RC_Pack(RC_Checksum("W1"+world+RC_ExpandCode(inner)),3)
    return "W1"+RC_Pack(StringLength(encoded),1)+encoded+inner+check
endfunction

function UW_Unwrap takes string saved returns string
    local integer length
    local integer z
    local string world
    local string inner
    local string check
    set UW_decoded=""
    if SubString(saved,0,2)!="W1" then
        return saved
    endif
    set RC_codeOK=true
    if StringLength(saved)>121 or StringLength(saved)<12 then
        return ""
    endif
    set length=RC_Digit(SubString(saved,2,3))
    if length<1 or length>StringLength(saved)-8 then
        return ""
    endif
    set world=RC_ExpandCode("Z5"+SubString(saved,3,3+length))
    set world=SubString(world,2,StringLength(world))
    set inner=RC_ExpandCode(SubString(saved,3+length,StringLength(saved)-3))
    if SubString(inner,0,2)!="C4" then
        return ""
    endif
    set z=RC_Number(SubString(inner,9,10))
    if z<15 or z>16 or StringLength(world)!=UW_chars[z] then
        return ""
    endif
    if RC_Number(SubString(world,0,2))!=UW_tag[z] then
        return ""
    endif
    // Upper flag bits and unused tail bits must be canonical, too.
    if RC_Number(SubString(world,2,4))>=256 or (z==15 and RC_Number(SubString(world,2,4))>=8) then
        return ""
    endif
    if ModuloInteger(UW_count[z],6)!=0 and RC_Number(SubString(world,StringLength(world)-1,StringLength(world)))>=R2I(Pow(2,ModuloInteger(UW_count[z],6))) then
        return ""
    endif
    set check=RC_Pack(RC_Checksum("W1"+world+inner),3)
    if not RC_codeOK or check!=SubString(saved,StringLength(saved)-3,StringLength(saved)) then
        return ""
    endif
    set UW_decoded=world
    return inner
endfunction

function UW_Capture takes nothing returns string
    local integer z=RC_map
    local integer n=0
    local integer value=0
    local integer power=1
    local string out
    if z<15 then
        return ""
    endif
    if not UW_ready[z] or UW_registered[z]!=UW_count[z] then
        set RC_codeOK=false
        return ""
    endif
    set out=RC_Pack(UW_tag[z],2)+RC_Pack(UW_Flags(),2)
    loop
        exitwhen n==UW_count[z]
        if not RK_Alive(UW_unit[z*256+n]) then
            set value=value+power
        endif
        set power=power*2
        if power==64 then
            set out=out+RC_Pack(value,1)
            set power=1
            set value=0
        endif
        set n=n+1
    endloop
    if power!=1 then
        set out=out+RC_Pack(value,1)
    endif
    return out
endfunction

function UW_Restore takes nothing returns nothing
    local integer z=RC_map
    local integer n=0
    local integer flags
    local integer value=0
    local integer ships=0
    local unit u
    local string world=UW_loaded[z]
    if world=="" or not UW_ready[z] then
        return
    endif
    set flags=RC_Number(SubString(world,2,4))
    call UZ_GateZone(z,false)
    loop
        exitwhen n==UW_count[z]
        if ModuloInteger(n,6)==0 then
            set value=RC_Number(SubString(world,4+n/6,5+n/6))
        endif
        set u=UW_unit[z*256+n]
        if ModuloInteger(value,2)==1 then
            // Reconstruct deaths without replaying quest/death rewards.
            call UW_Detach(u)
            if RK_Alive(u) then
                call KillUnit(u)
            endif
            if UW_ship[z*256+n] then
                set ships=ships+1
            endif
        endif
        set value=value/2
        set n=n+1
    endloop
    call UZ_GateZone(z,true)
    set UW_resumed[z]=true
    set UW_loaded[z]=""
    call UW_Apply(flags,ships)
    call RC_Alliances()
    set u=null
endfunction

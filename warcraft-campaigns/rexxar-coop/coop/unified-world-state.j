function UW_Flags takes nothing returns integer
    local integer flags=0
    if RC_map==15 then
        if IsQuestDiscovered(Z15_udg_QuestSeasOfBlood) then
            set flags=flags+1
        endif
        if IsQuestCompleted(Z15_udg_QuestSeasOfBlood) then
            set flags=flags+2
        endif
        if RC_IsPartyPlayer(GetOwningPlayer(Z15_gg_unit_nshp_0060)) then
            set flags=flags+4
        endif
    elseif RC_map==16 then
        if IsQuestDiscovered(Z16_udg_QuestLastAdmiral) then
            set flags=flags+1
        endif
        if IsQuestCompleted(Z16_udg_QuestLastAdmiral) then
            set flags=flags+2
        endif
        if Z16_udg_NorthDestroyed then
            set flags=flags+4
        endif
        if Z16_udg_MainDestroyed then
            set flags=flags+8
        endif
        if Z16_udg_EastDestroyed then
            set flags=flags+16
        endif
        if Z16_udg_KulTirasNorthDestroyed then
            set flags=flags+32
        endif
        if Z16_udg_KulTirasMainDestroyed then
            set flags=flags+64
        endif
        if Z16_udg_KulTirasEastDestroyed then
            set flags=flags+128
        endif
    endif
    return flags
endfunction

function UW_Detach takes unit u returns nothing
    if RC_map==15 then
        call GroupRemoveUnit(Z15_udg_BattleshipGroup,u)
        call GroupRemoveUnit(Z15_udg_KeyBuildingGroup,u)
    elseif RC_map==16 then
        call GroupRemoveUnit(Z16_udg_OrcNorthBuildingGroup,u)
        call GroupRemoveUnit(Z16_udg_OrcMainBuildingGroup,u)
        call GroupRemoveUnit(Z16_udg_OrcEastBuildingGroup,u)
        call GroupRemoveUnit(Z16_udg_KulTirasNorthBuildingGroup,u)
        call GroupRemoveUnit(Z16_udg_KulTirasMainBuildingGroup,u)
        call GroupRemoveUnit(Z16_udg_KulTirasEastBuildingGroup,u)
        call GroupRemoveUnit(Z16_udg_FinalEncounterGroup,u)
    endif
endfunction

function UW_ShipJournal takes nothing returns nothing
    local integer count=Z15_udg_LBBattleshipsDestroyed
    call ConditionalTriggerExecute(Z15_gg_trg_Quest_Seas_of_Blood_Create)
    call QuestSetDiscovered(Z15_udg_QuestSeasOfBlood,true)
    call QuestItemSetCompleted(Z15_udg_QuestSeasReq1,RC_IsPartyPlayer(GetOwningPlayer(Z15_gg_unit_nshp_0060)))
    call QuestItemSetCompleted(Z15_udg_QuestSeasReq2,count==6)
    call QuestItemSetDescription(Z15_udg_QuestSeasReq2,"Потопите штурмовые корабли ("+I2S(count)+" из 6)")
    if Z15_udg_LBBattleshipLeaderboard!=null then
        call LeaderboardSetPlayerItemLabelBJ(Z15_udg_AP1_Player,Z15_udg_LBBattleshipLeaderboard,"Кораблей потоплено: |cffffffff"+I2S(count)+"/6|r")
    endif
endfunction

function UW_Apply takes integer flags, integer ships returns nothing
    if RC_map==15 then
        set Z15_udg_LBBattleshipsDestroyed=ships
        if UW_Bit(flags,2) then
            call SetUnitOwner(Z15_gg_unit_nshp_0060,RC_Player(0),true)
        endif
        call UW_ShipJournal()
        call QuestSetDiscovered(Z15_udg_QuestSeasOfBlood,UW_Bit(flags,0))
        call QuestSetCompleted(Z15_udg_QuestSeasOfBlood,UW_Bit(flags,1))
        if UW_Bit(flags,2) then
            // Re-enable the original ferry/fleet system; the fresh map has
            // no dynamic friendly ships from the previous game session.
            call TriggerExecute(Z15_gg_trg_Activate_Shipyard)
        endif
        if ships==6 then
            call ConditionalTriggerExecute(Z15_gg_trg_Victory)
        endif
    elseif RC_map==16 then
        set Z16_udg_NorthDestroyed=UW_Bit(flags,2)
        set Z16_udg_MainDestroyed=UW_Bit(flags,3)
        set Z16_udg_EastDestroyed=UW_Bit(flags,4)
        set Z16_udg_KulTirasNorthDestroyed=UW_Bit(flags,5)
        set Z16_udg_KulTirasMainDestroyed=UW_Bit(flags,6)
        set Z16_udg_KulTirasEastDestroyed=UW_Bit(flags,7)
        call ConditionalTriggerExecute(Z16_gg_trg_Quest_LastAdmiral_Create)
        call QuestSetDiscovered(Z16_udg_QuestLastAdmiral,UW_Bit(flags,0))
        call QuestSetCompleted(Z16_udg_QuestLastAdmiral,UW_Bit(flags,1))
        call QuestItemSetCompleted(Z16_udg_QuestAdmiralReq1,UW_Bit(flags,1))
        call QuestItemSetCompleted(Z16_udg_QuestAdmiralReq2,UW_Bit(flags,1))
        if Z16_udg_NorthDestroyed or Z16_udg_MainDestroyed or Z16_udg_EastDestroyed then
            call ConditionalTriggerExecute(Z16_gg_trg_Retarget_Human_Forces)
        endif
        if not RK_Alive(Z16_udg_Proudmoore) then
            call ConditionalTriggerExecute(Z16_gg_trg_Victory)
        endif
    endif
endfunction

function DGW_Message takes integer p, string s returns nothing
    call DisplayTimedTextToPlayer(Player(p),0,0,12,s)
endfunction

function DGW_Cell takes integer row, integer col, string text returns nothing
    local multiboarditem item=MultiboardGetItem(DGW_Board,row,col)
    call MultiboardSetItemStyle(item,true,false)
    call MultiboardSetItemValue(item,text)
    if col==0 then
        call MultiboardSetItemWidth(item,0.14)
    else
        call MultiboardSetItemWidth(item,0.065)
    endif
    call MultiboardReleaseItem(item)
    set item=null
endfunction

function DGW_ClearTree takes nothing returns nothing
    call RemoveDestructable(GetEnumDestructable())
endfunction

function DGW_ScanCapital takes integer p returns integer
    local group g=CreateGroup()
    local unit u
    local integer count=0
    local integer tier=0
    local integer t
    call GroupEnumUnitsOfPlayer(g,Player(p),null)
    set DGW_Main[p]=null
    loop
        set u=FirstOfGroup(g)
        exitwhen u==null
        call GroupRemoveUnit(g,u)
        if GetWidgetLife(u)>0.405 and LoadInteger(DGW_Data,GetUnitTypeId(u),1)==2 then
            set count=count+1
            set t=LoadInteger(DGW_Data,GetUnitTypeId(u),3)
            if t>tier then
                set tier=t
                set DGW_Main[p]=u
            endif
        endif
    endloop
    set DGW_Tier[p]=tier
    call DestroyGroup(g)
    set g=null
    set u=null
    return count
endfunction

function DGW_Win takes integer winner returns nothing
    local integer i=0
    if DGW_Ended then
        return
    endif
    set DGW_Ended=true
    call DisplayTimedTextToForce(bj_FORCE_ALL_PLAYERS,30,"|cffffcc00Победитель: "+GetPlayerName(Player(winner))+" — "+DGW_RaceName[DGW_Race[winner]]+"!|r")
    loop
        exitwhen i>=12
        if DGW_Active[i] then
            if i==winner then
                call CustomVictoryBJ(Player(i),true,true)
            elseif DGW_Alive[i] then
                call CustomDefeatBJ(Player(i),"Победил другой владыка.")
            endif
        endif
        set i=i+1
    endloop
endfunction

function DGW_CheckVictory takes nothing returns nothing
    local integer p=0
    local integer alive=0
    local integer last=-1
    if DGW_Ended or not DGW_Begun or DGW_Pending>0 or DGW_InitialPlayers<2 then
        return
    endif
    loop
        exitwhen p>=12
        if DGW_Alive[p] and DGW_Chosen[p] then
            set alive=alive+1
            set last=p
        endif
        set p=p+1
    endloop
    if alive==1 then
        call DGW_Win(last)
    endif
endfunction

function DGW_SpawnRace takes integer p, integer r returns nothing
    local real x=DGW_StartX[p]
    local real y=DGW_StartY[p]
    local integer i=0
    local unit u
    local unit mine
    local rect area
    if not DGW_Active[p] or not DGW_Chosen[p] or not DGW_Alive[p] or r<1 or r>16 or DGW_Ended then
        return
    endif
    call DialogDisplay(Player(p),DGW_Dialog[p],false)
    call DialogClear(DGW_Dialog[p])
    set area=Rect(x-500,y-500,x+500,y+500)
    call EnumDestructablesInRect(area,null,function DGW_ClearTree)
    call RemoveRect(area)
    set area=null
    set DGW_Main[p]=CreateUnit(Player(p),DGW_HQ1[r],x,y,270)
    set DGW_Tier[p]=1
    set u=CreateUnit(Player(p),DGW_Farm[r],x+288,y+256,270)
    set DGW_BarracksUnit[p]=CreateUnit(Player(p),DGW_Barracks[r],x-288,y+256,270)
    set DGW_AltarUnit[p]=CreateUnit(Player(p),DGW_Altar[r],x+288,y-256,270)
    set mine=CreateUnit(Player(PLAYER_NEUTRAL_PASSIVE),'ngol',x-384,y-256,270)
    call SetResourceAmount(mine,40000)
    loop
        exitwhen i>=5
        set u=CreateUnit(Player(p),DGW_Worker[r],x-180+i*65,y-150,270)
        call IssueTargetOrder(u,"harvest",mine)
        set i=i+1
    endloop
    set i=0
    loop
        exitwhen i>=3
        set u=CreateUnit(Player(p),DGW_Army[r*8],x-100+i*90,y-340,270)
        set i=i+1
    endloop
    set u=CreateUnit(Player(p),DGW_ChampionType[r],x,y-290,270)
    call SetPlayerTechMaxAllowed(Player(p),DGW_ChampionType[r],1)
    call SetPlayerTechMaxAllowed(Player(p),DGW_GodType[r],1)
    call SetPlayerTechMaxAllowed(Player(p),DGW_Worker[r],18)
    call SetPlayerTechMaxAllowed(Player(p),DGW_Farm[r]+5,10)
    call SetPlayerState(Player(p),PLAYER_STATE_RESOURCE_GOLD,750)
    call SetPlayerState(Player(p),PLAYER_STATE_RESOURCE_LUMBER,400)
    call SetPlayerState(Player(p),PLAYER_STATE_FOOD_CAP_CEILING,200)
    set DGW_Faith[p]=10
    call PanCameraToTimedForPlayer(Player(p),x,y,0)
    call SetCameraFieldForPlayer(Player(p),CAMERA_FIELD_TARGET_DISTANCE,2300,0)
    call SelectUnitForPlayerSingle(u,Player(p))
    call DGW_Message(p,"|cffffcc00"+DGW_RaceName[r]+"|r: "+DGW_Trait[r])
    call DGW_Message(p,"Развивай столицу, добывай ресурсы и захватывай святилища. Бог: цитадель III + 800 золота + 350 дерева + 150 веры; кнопка V в алтаре. Подробности — F9.")
    set mine=null
    set u=null
endfunction

function DGW_BeginMatch takes nothing returns nothing
    local integer p=0
    if DGW_Begun or DGW_Pending>0 or DGW_Ended then
        return
    endif
    set DGW_Begun=true
    set DGW_Time=0
    loop
        exitwhen p>=12
        if DGW_Active[p] and DGW_Alive[p] and DGW_Chosen[p] then
            call DGW_SpawnRace(p,DGW_Race[p])
        endif
        set p=p+1
    endloop
    call DisplayTimedTextToForce(bj_FORCE_ALL_PLAYERS,12,"|cffffcc00Все выбрали расы. Партия началась — удачи!|r")
endfunction

function DGW_ChooseRace takes integer p, integer r returns nothing
    if p<0 or p>=12 or r<1 or r>16 then
        return
    endif
    if not DGW_Active[p] or not DGW_Alive[p] or DGW_Chosen[p] or DGW_Begun or DGW_Ended then
        return
    endif
    set DGW_Race[p]=r
    set DGW_Chosen[p]=true
    set DGW_Pending=DGW_Pending-1
    call DialogDisplay(Player(p),DGW_Dialog[p],false)
    call DGW_Message(p,"Раса выбрана: "+DGW_RaceName[r]+". Ждём остальных — все начнут одновременно.")
    call DGW_BeginMatch()
endfunction

function DGW_ShowMenu takes integer p returns nothing
    local integer i=0
    local integer r
    if not DGW_Active[p] or DGW_Chosen[p] or not DGW_Alive[p] then
        return
    endif
    call DialogClear(DGW_Dialog[p])
    call DialogSetMessage(DGW_Dialog[p],"Боги и Империи — выбери расу ("+I2S(DGW_Page[p]+1)+"/2)")
    loop
        exitwhen i>=8
        set r=DGW_Page[p]*8+i+1
        set DGW_Button[p*12+i]=DialogAddButton(DGW_Dialog[p],DGW_RaceName[r],0)
        set i=i+1
    endloop
    set DGW_Button[p*12+8]=DialogAddButton(DGW_Dialog[p],"Следующие / предыдущие расы",0)
    set DGW_Button[p*12+9]=DialogAddButton(DGW_Dialog[p],"Случайная раса",0)
    call DialogDisplay(Player(p),DGW_Dialog[p],true)
endfunction

function DGW_MenuClick takes nothing returns nothing
    local integer p=GetPlayerId(GetTriggerPlayer())
    local button b=GetClickedButton()
    local integer i=0
    if p<0 or p>=12 or not DGW_Active[p] or DGW_Chosen[p] then
        set b=null
        return
    endif
    loop
        exitwhen i>=8
        if b==DGW_Button[p*12+i] then
            call DGW_ChooseRace(p,DGW_Page[p]*8+i+1)
            set b=null
            return
        endif
        set i=i+1
    endloop
    if b==DGW_Button[p*12+8] then
        set DGW_Page[p]=1-DGW_Page[p]
        call DGW_ShowMenu(p)
    elseif b==DGW_Button[p*12+9] then
        call DGW_ChooseRace(p,GetRandomInt(1,16))
    endif
    set b=null
endfunction

function DGW_TryAscend takes integer p returns boolean
    local integer r=DGW_Race[p]
    local unit u=DGW_AltarUnit[p]
    if not DGW_Alive[p] or r==0 or DGW_Ascended[p] then
        call DGW_Message(p,"Бог уже призван. Павшего бога можно воскресить в алтаре.")
        set u=null
        return false
    endif
    call DGW_ScanCapital(p)
    if DGW_Tier[p]<3 or u==null or GetWidgetLife(u)<=0.405 then
        call DGW_Message(p,"Для вознесения нужны цитадель III ступени и действующий алтарь.")
        set u=null
        return false
    endif
    if DGW_Faith[p]<150 or GetPlayerState(Player(p),PLAYER_STATE_RESOURCE_GOLD)<800 or GetPlayerState(Player(p),PLAYER_STATE_RESOURCE_LUMBER)<350 then
        call DGW_Message(p,"Вознесение стоит 800 золота, 350 дерева и 150 веры.")
        set u=null
        return false
    endif
    set DGW_Ascended[p]=true
    set DGW_Faith[p]=DGW_Faith[p]-150
    call SetPlayerState(Player(p),PLAYER_STATE_RESOURCE_GOLD,GetPlayerState(Player(p),PLAYER_STATE_RESOURCE_GOLD)-800)
    call SetPlayerState(Player(p),PLAYER_STATE_RESOURCE_LUMBER,GetPlayerState(Player(p),PLAYER_STATE_RESOURCE_LUMBER)-350)
    set DGW_God[p]=CreateUnit(Player(p),DGW_GodType[r],GetUnitX(u),GetUnitY(u)-210,270)
    call SetHeroLevel(DGW_God[p],6,false)
    call SelectHeroSkill(DGW_God[p],LoadInteger(DGW_Data,r,11))
    call DestroyEffect(AddSpecialEffect("Abilities\\Spells\\Human\\Resurrect\\ResurrectTarget.mdl",GetUnitX(u),GetUnitY(u)))
    call DisplayTimedTextToForce(bj_FORCE_ALL_PLAYERS,12,"|cffffcc00"+DGW_GodName[r]+" вступает в битву!|r")
    set u=null
    return true
endfunction

function DGW_SpellCast takes nothing returns nothing
    local unit caster=GetTriggerUnit()
    local player owner=GetOwningPlayer(caster)
    local integer p=GetPlayerId(owner)
    local integer r
    local integer mode
    local integer id=GetSpellAbilityId()
    local real x
    local real y
    local real damage
    local real healing
    local real hp
    local integer hits=0
    local integer i=0
    local integer summon=0
    local unit u
    local group g
    if p<0 or p>=12 or not DGW_Alive[p] then
        set caster=null
        set owner=null
        return
    endif
    set r=DGW_Race[p]
    if id=='ZG00' and LoadInteger(DGW_Data,GetUnitTypeId(caster),1)==3 and GetUnitTypeId(caster)==DGW_Altar[r] then
        set DGW_AltarUnit[p]=caster
        call DGW_TryAscend(p)
    elseif r>0 and id==DGW_Spell[r] and caster==DGW_God[p] then
        set mode=r-1
        set x=GetSpellTargetX()
        set y=GetSpellTargetY()
        set damage=330
        set healing=0
        if mode==0 then
            set damage=220
            set healing=260
        elseif mode==3 or mode==13 then
            set damage=100
            set healing=430
        elseif mode==5 or mode==14 then
            set damage=540
        endif
        call DestroyEffect(AddSpecialEffect("Abilities\\Spells\\Human\\Thunderclap\\ThunderClapCaster.mdl",x,y))
        set g=CreateGroup()
        call GroupEnumUnitsInRange(g,x,y,420,null)
        loop
            set u=FirstOfGroup(g)
            exitwhen u==null
            call GroupRemoveUnit(g,u)
            if GetWidgetLife(u)>0.405 and not IsUnitType(u,UNIT_TYPE_MAGIC_IMMUNE) then
                if IsUnitEnemy(u,owner) and GetUnitAbilityLevel(u,'Avul')==0 then
                    set hp=damage
                    if mode==8 and IsUnitType(u,UNIT_TYPE_STRUCTURE) then
                        set hp=hp*2
                    endif
                    call UnitDamageTarget(caster,u,hp,true,false,ATTACK_TYPE_MAGIC,DAMAGE_TYPE_MAGIC,null)
                    set hits=hits+1
                    if mode==2 then
                        call SetUnitState(u,UNIT_STATE_MANA,RMaxBJ(0,GetUnitState(u,UNIT_STATE_MANA)-120))
                    elseif mode==15 and not IsUnitType(u,UNIT_TYPE_STRUCTURE) then
                        call SetUnitPosition(u,GetUnitX(u)*0.45+x*0.55,GetUnitY(u)*0.45+y*0.55)
                    endif
                elseif IsUnitAlly(u,owner) then
                    set hp=healing
                    if (mode==4 or mode==9) and IsUnitType(u,UNIT_TYPE_STRUCTURE) then
                        set hp=700
                    endif
                    call SetWidgetLife(u,RMinBJ(GetUnitState(u,UNIT_STATE_MAX_LIFE),GetWidgetLife(u)+hp))
                    if mode==3 then
                        call SetUnitState(u,UNIT_STATE_MANA,RMinBJ(GetUnitState(u,UNIT_STATE_MAX_MANA),GetUnitState(u,UNIT_STATE_MANA)+120))
                    elseif mode==13 then
                        call UnitRemoveBuffs(u,false,true)
                    endif
                endif
            endif
        endloop
        call DestroyGroup(g)
        if mode==6 then
            set summon='nwat'
            set i=3
        elseif mode==7 then
            set summon='osw1'
            set i=4
        elseif mode==10 then
            set summon='ucs1'
            set i=6
        elseif mode==11 then
            set summon='ninf'
            set i=1
        elseif mode==12 then
            call SetWidgetLife(caster,RMinBJ(GetUnitState(caster,UNIT_STATE_MAX_LIFE),GetWidgetLife(caster)+60*hits))
        endif
        loop
            exitwhen i<=0
            set u=CreateUnit(owner,summon,x+GetRandomReal(-90,90),y+GetRandomReal(-90,90),270)
            call UnitApplyTimedLife(u,'BTLF',40)
            call SetUnitUseFood(u,false)
            set i=i-1
        endloop
        if mode==9 then
            set DGW_Faith[p]=DGW_Faith[p]+IMinBJ(hits,15)
        endif
        set g=null
        set u=null
    endif
    set caster=null
    set owner=null
endfunction

function DGW_ShrineTick takes nothing returns nothing
    local integer s=0
    local integer found
    local integer p
    local integer i
    local boolean contested
    local group g=CreateGroup()
    local unit u
    loop
        exitwhen s>=5
        set found=-1
        set contested=false
        call GroupEnumUnitsInRange(g,DGW_ShrineX[s],DGW_ShrineY[s],420,null)
        loop
            set u=FirstOfGroup(g)
            exitwhen u==null
            call GroupRemoveUnit(g,u)
            set p=GetPlayerId(GetOwningPlayer(u))
            if p>=0 and p<12 and DGW_Alive[p] and DGW_Chosen[p] and GetWidgetLife(u)>0.405 and not IsUnitType(u,UNIT_TYPE_STRUCTURE) and not IsUnitType(u,UNIT_TYPE_PEON) then
                if found==-1 then
                    set found=p
                elseif found!=p then
                    set contested=true
                endif
            endif
        endloop
        if found>=0 and not contested then
            if DGW_CapturePlayer[s]!=found then
                set DGW_CapturePlayer[s]=found
                set DGW_CaptureTime[s]=2
            else
                set DGW_CaptureTime[s]=DGW_CaptureTime[s]+2
            endif
            if DGW_CaptureTime[s]>=10 and GetOwningPlayer(DGW_Shrine[s])!=Player(found) then
                call SetUnitOwner(DGW_Shrine[s],Player(found),true)
                call DGW_Message(found,"|cffffcc00Святилище захвачено: +25 золота, +5 дерева и +5 веры каждые 5 секунд.|r")
                call PingMinimapForPlayer(Player(found),DGW_ShrineX[s],DGW_ShrineY[s],3)
            endif
        else
            set DGW_CapturePlayer[s]=-1
            set DGW_CaptureTime[s]=0
        endif
        set s=s+1
    endloop
    call DestroyGroup(g)
    set g=null
    set u=null
endfunction

function DGW_Death takes nothing returns nothing
    local unit dead=GetTriggerUnit()
    local unit killer=GetKillingUnit()
    local integer p
    local integer amount=3
    if killer!=null and IsUnitEnemy(dead,GetOwningPlayer(killer)) then
        set p=GetPlayerId(GetOwningPlayer(killer))
        if p>=0 and p<12 and DGW_Alive[p] and DGW_Chosen[p] then
            if IsUnitType(dead,UNIT_TYPE_HERO) then
                set amount=20
            elseif IsUnitType(dead,UNIT_TYPE_STRUCTURE) then
                set amount=8
            elseif IsUnitType(dead,UNIT_TYPE_PEON) then
                set amount=1
            endif
            if DGW_Race[p]==8 then
                set amount=amount+2
            endif
            set DGW_Faith[p]=DGW_Faith[p]+amount
            if GetPlayerId(GetOwningPlayer(dead))==PLAYER_NEUTRAL_AGGRESSIVE then
                call SetPlayerState(Player(p),PLAYER_STATE_RESOURCE_GOLD,GetPlayerState(Player(p),PLAYER_STATE_RESOURCE_GOLD)+30)
            endif
        endif
    endif
    set dead=null
    set killer=null
endfunction

function DGW_Produced takes nothing returns nothing
    local unit u=GetTrainedUnit()
    local integer kind
    local integer p
    if u==null then
        set u=GetConstructedStructure()
    endif
    if u==null then
        set u=GetRevivingUnit()
    endif
    if u!=null then
        set p=GetPlayerId(GetOwningPlayer(u))
        set kind=LoadInteger(DGW_Data,GetUnitTypeId(u),1)
        if p>=0 and p<12 then
            if GetUnitTypeId(u)==DGW_Altar[DGW_Race[p]] then
                set DGW_AltarUnit[p]=u
            elseif GetUnitTypeId(u)==DGW_Barracks[DGW_Race[p]] then
                set DGW_BarracksUnit[p]=u
            endif
        endif
        call IssueImmediateOrder(u,"healon")
        call IssueImmediateOrder(u,"slowon")
    endif
    set u=null
endfunction

function DGW_Income takes nothing returns nothing
    local integer p=0
    local integer s=0
    local integer r
    local integer alive=0
    local integer gold
    local integer wood
    loop
        exitwhen p>=12
        set DGW_ShrineCount[p]=0
        set p=p+1
    endloop
    loop
        exitwhen s>=5
        set p=GetPlayerId(GetOwningPlayer(DGW_Shrine[s]))
        if p>=0 and p<12 and DGW_Alive[p] then
            set DGW_ShrineCount[p]=DGW_ShrineCount[p]+1
        endif
        set s=s+1
    endloop
    set p=0
    loop
        exitwhen p>=12
        if DGW_Alive[p] and DGW_Chosen[p] then
            if DGW_ScanCapital(p)==0 then
                set DGW_Alive[p]=false
                call CustomDefeatBJ(Player(p),"Все твои столицы уничтожены.")
            else
                set r=DGW_Race[p]
                set gold=35+15*DGW_Tier[p]+25*DGW_ShrineCount[p]
                set wood=10+10*DGW_Tier[p]+5*DGW_ShrineCount[p]
                if r==1 or r==10 then
                    set gold=gold+10
                endif
                if r==5 then
                    set wood=wood+8
                endif
                call SetPlayerState(Player(p),PLAYER_STATE_RESOURCE_GOLD,GetPlayerState(Player(p),PLAYER_STATE_RESOURCE_GOLD)+gold)
                call SetPlayerState(Player(p),PLAYER_STATE_RESOURCE_LUMBER,GetPlayerState(Player(p),PLAYER_STATE_RESOURCE_LUMBER)+wood)
                set DGW_Faith[p]=DGW_Faith[p]+2+5*DGW_ShrineCount[p]
                if DGW_Time>=1200 and DGW_ShrineCount[p]>=3 and DGW_God[p]!=null and GetWidgetLife(DGW_God[p])>0.405 then
                    set DGW_Hold[p]=DGW_Hold[p]+5
                    if DGW_Hold[p]==5 then
                        call DisplayTimedTextToForce(bj_FORCE_ALL_PLAYERS,12,GetPlayerName(Player(p))+" начал удержание трёх святилищ! До победы 120 секунд.")
                    endif
                    if DGW_Hold[p]>=120 and DGW_InitialPlayers>=2 then
                        call DGW_Win(p)
                        return
                    endif
                else
                    set DGW_Hold[p]=0
                endif
                call DGW_Cell(p+1,0,GetPlayerName(Player(p)))
                call DGW_Cell(p+1,1,I2S(DGW_Tier[p])+" / "+I2S(DGW_ShrineCount[p]))
                call DGW_Cell(p+1,2,I2S(GetPlayerState(Player(p),PLAYER_STATE_RESOURCE_GOLD)))
                call DGW_Cell(p+1,3,I2S(DGW_Faith[p]))
                call DGW_Cell(p+1,4,I2S(DGW_Hold[p])+" / 120")
            endif
        elseif DGW_Active[p] then
            call DGW_Cell(p+1,0,GetPlayerName(Player(p)))
            if DGW_Chosen[p] then
                call DGW_Cell(p+1,1,"Выбыл")
            else
                call DGW_Cell(p+1,1,"Выбирает")
            endif
        endif
        set p=p+1
    endloop
    call DGW_CheckVictory()
endfunction

function DGW_AI takes nothing returns nothing
    local integer p=0
    local integer r
    local integer target
    local integer i
    local integer role
    local integer tier
    local unit u
    local unit enemy
    local group g=CreateGroup()
    loop
        exitwhen p>=12
        if DGW_Alive[p] and DGW_Chosen[p] and GetPlayerController(Player(p))==MAP_CONTROL_COMPUTER then
            set r=DGW_Race[p]
            set tier=DGW_Tier[p]
            if tier<3 and DGW_Time>=DGW_AINextUpgrade[p] then
                if tier==1 then
                    if IssueImmediateOrderById(DGW_Main[p],DGW_HQ2[r]) then
                        set DGW_AINextUpgrade[p]=DGW_Time+65
                    endif
                else
                    if IssueImmediateOrderById(DGW_Main[p],DGW_HQ3[r]) then
                        set DGW_AINextUpgrade[p]=DGW_Time+85
                    endif
                endif
            endif
            if tier>=3 and not DGW_Ascended[p] then
                call DGW_TryAscend(p)
            endif
            set role=0
            if tier>=3 then
                set role=7
            elseif tier>=2 then
                set role=3
            endif
            if ModuloInteger(DGW_Time,70)==0 then
                set role=1
            endif
            call IssueImmediateOrderById(DGW_BarracksUnit[p],DGW_Army[r*8+role])
            set target=-1
            set enemy=null
            set i=0
            loop
                exitwhen i>=12
                if i!=p and DGW_Alive[i] and DGW_Chosen[i] and DGW_Main[i]!=null then
                    if enemy==null or (GetUnitX(DGW_Main[i])-DGW_StartX[p])*(GetUnitX(DGW_Main[i])-DGW_StartX[p])+(GetUnitY(DGW_Main[i])-DGW_StartY[p])*(GetUnitY(DGW_Main[i])-DGW_StartY[p])<(GetUnitX(enemy)-DGW_StartX[p])*(GetUnitX(enemy)-DGW_StartX[p])+(GetUnitY(enemy)-DGW_StartY[p])*(GetUnitY(enemy)-DGW_StartY[p]) then
                        set enemy=DGW_Main[i]
                        set target=i
                    endif
                endif
                set i=i+1
            endloop
            if enemy!=null then
                call GroupEnumUnitsOfPlayer(g,Player(p),null)
                loop
                    set u=FirstOfGroup(g)
                    exitwhen u==null
                    call GroupRemoveUnit(g,u)
                    if GetWidgetLife(u)>0.405 and not IsUnitType(u,UNIT_TYPE_PEON) and not IsUnitType(u,UNIT_TYPE_STRUCTURE) then
                        if GetUnitCurrentOrder(u)==0 then
                            call IssuePointOrder(u,"attack",GetUnitX(enemy),GetUnitY(enemy))
                        endif
                    endif
                endloop
                if DGW_God[p]!=null and GetWidgetLife(DGW_God[p])>0.405 then
                    call IssuePointOrder(DGW_God[p],"channel",GetUnitX(enemy),GetUnitY(enemy))
                endif
            endif
        endif
        set p=p+1
    endloop
    call DestroyGroup(g)
    set g=null
    set enemy=null
    set u=null
endfunction

function DGW_Chat takes nothing returns nothing
    local integer p=GetPlayerId(GetTriggerPlayer())
    local string s=GetEventPlayerChatString()
    local real zoom
    if p<0 or p>=12 then
        return
    endif
    if s=="-race" then
        call DGW_ShowMenu(p)
    elseif s=="-info" then
        call DGW_Message(p,DGW_RaceName[DGW_Race[p]]+" | Ступень: "+I2S(DGW_Tier[p])+" | Вера: "+I2S(DGW_Faith[p])+" | Святилища: "+I2S(DGW_ShrineCount[p]))
    elseif SubString(s,0,5)=="-cam " then
        set zoom=RMaxBJ(1200,RMinBJ(3200,S2R(SubString(s,5,StringLength(s)))))
        call SetCameraFieldForPlayer(Player(p),CAMERA_FIELD_TARGET_DISTANCE,zoom,0.3)
    elseif s=="-help" then
        call DGW_Message(p,"-race: открыть выбор до старта; -info: вера и развитие; -cam 2300: высота камеры. Полные правила: F9. Последняя столица уничтожена — поражение. III ступень и 150 веры открывают вознесение в алтаре (V).")
    endif
    set s=null
endfunction

function DGW_Leave takes nothing returns nothing
    local integer p=GetPlayerId(GetTriggerPlayer())
    if p>=0 and p<12 and DGW_Active[p] and DGW_Alive[p] then
        set DGW_Alive[p]=false
        if not DGW_Chosen[p] then
            set DGW_Pending=DGW_Pending-1
        endif
        call DGW_BeginMatch()
        call DGW_CheckVictory()
    endif
endfunction

function DGW_Tick takes nothing returns nothing
    local integer p=0
    if DGW_Ended then
        return
    endif
    set DGW_Time=DGW_Time+1
    if DGW_Time==2 then
        loop
            exitwhen p>=12
            if DGW_Active[p] and GetPlayerController(Player(p))==MAP_CONTROL_USER then
                call DGW_ShowMenu(p)
            endif
            set p=p+1
        endloop
    elseif DGW_Time==5 or DGW_Time==90 then
        loop
            exitwhen p>=12
            if DGW_Active[p] and DGW_Alive[p] and not DGW_Chosen[p] and (DGW_Time==90 or GetPlayerController(Player(p))==MAP_CONTROL_COMPUTER) then
                call DGW_ChooseRace(p,GetRandomInt(1,16))
            endif
            set p=p+1
        endloop
    endif
    if not DGW_Begun or DGW_Time==0 then
        return
    endif
    if ModuloInteger(DGW_Time,2)==0 then
        call DGW_ShrineTick()
    endif
    if ModuloInteger(DGW_Time,5)==0 then
        call DGW_Income()
    endif
    if ModuloInteger(DGW_Time,35)==0 then
        call DGW_AI()
    endif
endfunction

function InitTrig_DGW_Expansion takes nothing returns nothing
    local trigger clock=CreateTrigger()
    local trigger menu=CreateTrigger()
    local trigger spells=CreateTrigger()
    local trigger deaths=CreateTrigger()
    local trigger chat=CreateTrigger()
    local trigger leave=CreateTrigger()
    local trigger produced=CreateTrigger()
    local integer p=0
    local integer j
    local integer i=0
    local quest q
    local unit u
    call DGW_LoadData()
    set DGW_Board=CreateMultiboard()
    call MultiboardSetTitleText(DGW_Board,"Боги и Империи — FFA | Ступень/Святилища | Золото | Вера | Удержание")
    call MultiboardSetRowCount(DGW_Board,13)
    call MultiboardSetColumnCount(DGW_Board,5)
    call DGW_Cell(0,0,"Игрок")
    call DGW_Cell(0,1,"Ступ./Свят.")
    call DGW_Cell(0,2,"Золото")
    call DGW_Cell(0,3,"Вера")
    call DGW_Cell(0,4,"Удержание")
    loop
        exitwhen p>=12
        set DGW_Dialog[p]=DialogCreate()
        call TriggerRegisterDialogEvent(menu,DGW_Dialog[p])
        set DGW_Active[p]=GetPlayerSlotState(Player(p))==PLAYER_SLOT_STATE_PLAYING and (GetPlayerController(Player(p))==MAP_CONTROL_USER or GetPlayerController(Player(p))==MAP_CONTROL_COMPUTER)
        set DGW_Alive[p]=DGW_Active[p]
        if DGW_Active[p] then
            set DGW_InitialPlayers=DGW_InitialPlayers+1
            set DGW_Pending=DGW_Pending+1
            call TriggerRegisterPlayerChatEvent(chat,Player(p),"-",false)
            call TriggerRegisterPlayerEvent(leave,Player(p),EVENT_PLAYER_LEAVE)
            call SetPlayerState(Player(p),PLAYER_STATE_ALLIED_VICTORY,0)
        endif
        set j=0
        loop
            exitwhen j>=12
            if p!=j then
                call SetPlayerAllianceStateBJ(Player(p),Player(j),bj_ALLIANCE_UNALLIED)
                call SetPlayerAlliance(Player(p),Player(j),ALLIANCE_SHARED_VISION,false)
                call SetPlayerAlliance(Player(p),Player(j),ALLIANCE_SHARED_CONTROL,false)
            endif
            set j=j+1
        endloop
        set p=p+1
    endloop
    loop
        exitwhen i>=5
        set DGW_Shrine[i]=CreateUnit(Player(PLAYER_NEUTRAL_PASSIVE),'dS00',DGW_ShrineX[i],DGW_ShrineY[i],270)
        set DGW_CapturePlayer[i]=-1
        set u=CreateUnit(Player(PLAYER_NEUTRAL_AGGRESSIVE),'ogru',DGW_ShrineX[i]+220,DGW_ShrineY[i]+140,270)
        set u=CreateUnit(Player(PLAYER_NEUTRAL_AGGRESSIVE),'ogru',DGW_ShrineX[i]-220,DGW_ShrineY[i]+140,270)
        set u=CreateUnit(Player(PLAYER_NEUTRAL_AGGRESSIVE),'nftt',DGW_ShrineX[i],DGW_ShrineY[i]+270,270)
        set i=i+1
    endloop
    call TriggerRegisterTimerEvent(clock,1,true)
    call TriggerAddAction(clock,function DGW_Tick)
    call TriggerAddAction(menu,function DGW_MenuClick)
    call TriggerRegisterAnyUnitEventBJ(spells,EVENT_PLAYER_UNIT_SPELL_EFFECT)
    call TriggerAddAction(spells,function DGW_SpellCast)
    call TriggerRegisterAnyUnitEventBJ(deaths,EVENT_PLAYER_UNIT_DEATH)
    call TriggerAddAction(deaths,function DGW_Death)
    call TriggerAddAction(chat,function DGW_Chat)
    call TriggerAddAction(leave,function DGW_Leave)
    call TriggerRegisterAnyUnitEventBJ(produced,EVENT_PLAYER_UNIT_TRAIN_FINISH)
    call TriggerRegisterAnyUnitEventBJ(produced,EVENT_PLAYER_UNIT_CONSTRUCT_FINISH)
    call TriggerRegisterAnyUnitEventBJ(produced,EVENT_PLAYER_HERO_REVIVE_FINISH)
    call TriggerAddAction(produced,function DGW_Produced)
    set q=CreateQuest()
    call QuestSetTitle(q,"Боги и Империи: как играть")
    call QuestSetRequired(q,true)
    call QuestSetDiscovered(q,true)
    call QuestSetDescription(q,"Выбери одну из 16 рас в окне при старте. На выбор 90 секунд, затем выбирается случайная. Каждый развивается у себя: рабочие добывают золото, пассивный доход даёт также дерево. Строй войска, жилища, святилища и мастерские, исследуй оружие и броню. Столицу можно улучшить дважды. Потеря всех столиц означает поражение, последний живой игрок побеждает. У компьютеров есть простой базовый противник; опытный человек играет сильнее.")
    set q=CreateQuest()
    call QuestSetTitle(q,"Боги, вера и святилища")
    call QuestSetRequired(q,true)
    call QuestSetDiscovered(q,true)
    call QuestSetDescription(q,"За убийства, время и захваченные святилища ты получаешь веру. В центре карты и по четырём сторонам стоят 5 святилищ: держи рядом боевой отряд 10 секунд без врагов. Рабочие не захватывают точки. Цитадель III, 800 золота, 350 дерева и 150 веры позволяют призвать одного бога кнопкой V в алтаре. Его особая способность — на Z. Павших героев можно воскресить в алтаре. С 20-й минуты действует вторая победа: удерживай 3 святилища 120 секунд подряд с живым богом.")
    set q=CreateQuest()
    call QuestSetTitle(q,"Управление")
    call QuestSetRequired(q,false)
    call QuestSetDiscovered(q,true)
    call QuestSetDescription(q,"Кнопка F9 — правила. -race открывает выбор, пока раса ещё не выбрана. -info показывает твоё развитие и веру. -cam 2300 меняет высоту камеры (1200–3200). Боги возносятся в алтаре кнопкой V, их особая сила — на Z. Потеряв чемпиона или бога, выбери алтарь для воскрешения. Компьютерные игроки подходят для тренировки; для полноценной FFA пригласи друзей.")
    call MultiboardDisplay(DGW_Board,true)
    set q=null
    set u=null
    set clock=null
    set menu=null
    set spells=null
    set deaths=null
    set chat=null
    set leave=null
    set produced=null
endfunction

function SDIsUnit takes unit u returns boolean
return u!=null and SDObjects!=null and LoadBoolean(SDObjects,GetHandleId(u),0)
endfunction

function SDWorldGate takes nothing returns boolean
if SDActive and GetTriggerUnit()!=null then
if GetPlayerId(GetOwningPlayer(GetTriggerUnit()))==13 or GetPlayerId(GetOwningPlayer(GetTriggerUnit()))==14 then
return false
endif
endif
return not SDCreating and not SDRunning and not SDIsUnit(GetTriggerUnit())
endfunction

function SDWorldTrigger takes nothing returns trigger
local trigger t=CreateTrigger()
if SDWorldExpression==null then
set SDWorldExpression=Condition(function SDWorldGate)
endif
call TriggerAddCondition(t,SDWorldExpression)
return t
endfunction

function SDSceneGate takes nothing returns boolean
return SDActive and (GetTriggerUnit()==null or SDIsUnit(GetTriggerUnit()))
endfunction

function SDRecord takes integer id,integer index returns nothing
if index>=0 and index<8192 and not HaveSavedBoolean(SDTouches,id,index) then
call SaveBoolean(SDTouches,id,index,true)
if SDDirtyCount<200000 then
call SaveInteger(SDTouches,-1,SDDirtyCount,id)
call SaveInteger(SDTouches,-2,SDDirtyCount,index)
set SDDirtyCount=SDDirtyCount+1
endif
endif
endfunction

function SDClampX takes real x returns real
return RMaxBJ(-1600,RMinBJ(1600,x))
endfunction

function SDClampY takes real y returns real
return RMaxBJ(13200,RMinBJ(15800,y))
endfunction

function SDPlayer takes integer id returns player
if id==0 then
return Player(13)
elseif id==1 then
return Player(14)
endif
return Player(id)
endfunction

function SDPlayerId takes player p returns integer
if GetPlayerId(p)==13 then
return 0
elseif GetPlayerId(p)==14 then
return 1
endif
return GetPlayerId(p)
endfunction

function SDController takes player p returns mapcontrol
if GetPlayerId(p)==13 then
return MAP_CONTROL_USER
elseif GetPlayerId(p)==14 then
return MAP_CONTROL_COMPUTER
endif
return GetPlayerController(p)
endfunction

function SDSlotState takes player p returns playerslotstate
if GetPlayerId(p)==13 or GetPlayerId(p)==14 then
return PLAYER_SLOT_STATE_PLAYING
endif
return GetPlayerSlotState(p)
endfunction

function SDSold takes nothing returns unit
if SDInitializing then
return SDActor
endif
return GetSoldUnit()
endfunction

function SDBuyer takes nothing returns unit
if SDInitializing then
return SDFakeBuyer
endif
return GetBuyingUnit()
endfunction

function SDTriggerUnit takes nothing returns unit
if SDInitializing then
return SDActor
endif
return GetTriggerUnit()
endfunction

function SDTriggerPlayer takes nothing returns player
if SDInitializing then
return Player(13)
endif
return GetTriggerPlayer()
endfunction

function SDTriggerEvent takes nothing returns eventid
if SDInitializing then
return EVENT_PLAYER_UNIT_SELL
endif
return GetTriggerEventId()
endfunction

function SDUnitType takes unit u returns integer
if SDInitializing and u==SDActor then
return SDActorBase
endif
return GetUnitTypeId(u)
endfunction

function SDAbility takes integer raw returns integer
local integer mapped=LoadInteger(SDMeta,1,raw)
if mapped!=0 then
return mapped
endif
return raw
endfunction

function SDSpellId takes nothing returns integer
local integer raw=GetSpellAbilityId()
local integer mapped=LoadInteger(SDMeta,2,raw)
if mapped!=0 then
return mapped
endif
return raw
endfunction

function SDAbilityLevel takes unit u,integer raw returns integer
local integer level=GetUnitAbilityLevel(u,SDAbility(raw))
if level==0 then
return GetUnitAbilityLevel(u,raw)
endif
return level
endfunction

function SDAddAbility takes unit u,integer raw returns boolean
if not SDIsUnit(u) then
return false
endif
return UnitAddAbility(u,SDAbility(raw))
endfunction

function SDRemoveAbility takes unit u,integer raw returns boolean
if not SDIsUnit(u) then
return false
endif
return UnitRemoveAbility(u,SDAbility(raw))
endfunction

function SDSetAbility takes unit u,integer raw,integer level returns integer
if not SDIsUnit(u) then
return 0
endif
return SetUnitAbilityLevel(u,SDAbility(raw),level)
endfunction

function SDPermanentAbility takes unit u,boolean flag,integer raw returns boolean
if not SDIsUnit(u) then
return false
endif
return UnitMakeAbilityPermanent(u,flag,SDAbility(raw))
endfunction

function SDPlayerAbility takes player p,integer raw,boolean flag returns nothing
if GetPlayerId(p)==13 or GetPlayerId(p)==14 then
call SetPlayerAbilityAvailable(p,SDAbility(raw),flag)
endif
endfunction

function SDRectX takes rect r returns real
return 0.
endfunction

function SDRectY takes rect r returns real
return 14500.
endfunction

function SDFilter takes nothing returns boolean
return SDIsUnit(GetFilterUnit())
endfunction

function SDFilterExpression takes boolexpr expression returns boolexpr
if expression==null then
return SDTrackExpr(Condition(function SDFilter))
endif
return SDTrackExpr(And(SDTrackExpr(Condition(function SDFilter)),expression))
endfunction

function SDEnumRange takes group g,real x,real y,real radius,boolexpr expression returns nothing
call GroupEnumUnitsInRange(g,x,y,radius,SDFilterExpression(expression))
endfunction

function SDEnumRangeLoc takes group g,location point,real radius,boolexpr expression returns nothing
call GroupEnumUnitsInRangeOfLoc(g,point,radius,SDFilterExpression(expression))
endfunction

function SDEnumRect takes group g,rect r,boolexpr expression returns nothing
call GroupEnumUnitsInRect(g,r,SDFilterExpression(expression))
endfunction

function SDEnumPlayer takes group g,player p,boolexpr expression returns nothing
call GroupEnumUnitsOfPlayer(g,p,SDFilterExpression(expression))
endfunction

function SDNewUnit takes player owner,integer raw,real x,real y,real facing returns unit
local unit u=null
local player actual=Player(13)
if GetPlayerId(owner)!=13 then
set actual=Player(14)
endif
if SDUnitCount>=2000 then
return null
endif
set SDCreating=true
set u=CreateUnit(actual,raw,SDClampX(x),SDClampY(y),facing)
set SDCreating=false
call SDTrackUnit(u)
call SetUnitPathing(u,false)
return u
endfunction

function SDSetX takes unit u,real x returns nothing
if SDIsUnit(u) then
call SetUnitX(u,SDClampX(x))
endif
endfunction

function SDSetY takes unit u,real y returns nothing
if SDIsUnit(u) then
call SetUnitY(u,SDClampY(y))
endif
endfunction

function SDSetPosition takes unit u,real x,real y returns nothing
if SDIsUnit(u) then
call SetUnitPosition(u,SDClampX(x),SDClampY(y))
endif
endfunction

function SDSetPositionLoc takes unit u,location p returns nothing
if SDIsUnit(u) and p!=null then
call SDSetPosition(u,GetLocationX(p),GetLocationY(p))
endif
endfunction

function SDNewTimer takes nothing returns timer
return SDTrackTimer(CreateTimer())
endfunction

function SDNewTrigger takes nothing returns trigger
local trigger t=SDTrackTrigger(CreateTrigger())
call TriggerAddCondition(t,SDTrackExpr(Condition(function SDSceneGate)))
return t
endfunction

function SDNewForce takes nothing returns force
return SDTrackForce(CreateForce())
endfunction

function SDNewLocation takes real x,real y returns location
return SDTrackLocation(Location(SDClampX(x),SDClampY(y)))
endfunction

function SDNewRect takes real x1,real y1,real x2,real y2 returns rect
return SDTrackRect(Rect(SDClampX(x1),SDClampY(y1),SDClampX(x2),SDClampY(y2)))
endfunction

function SDNewHashtable takes nothing returns hashtable
return SDTrackHashtable(InitHashtable())
endfunction

function SDRegisterPlayerUnitEvent takes trigger t,player p,playerunitevent eventType,boolexpr expression returns event
local integer key=100000+GetHandleId(eventType)*32+GetPlayerId(p)
if LoadBoolean(SDObjects,GetHandleId(t),key) then
return null
endif
call SaveBoolean(SDObjects,GetHandleId(t),key,true)
return TriggerRegisterPlayerUnitEvent(t,p,eventType,expression)
endfunction

// @@SD_MANAGER_GLOBALS@@
integer array SDRequests
integer array SDRequestSkill
integer array SDRequestMode
integer array SDCursors
integer array SDSpellRaw
integer array SDSpellActor
integer array SDSpellLevel
integer array SDSpellTarget
boolean array SDSpellAlly
string array SDSpellOrder
integer array SDOriginalAbility
integer array SDAliasAbility
integer SDAbilityCount=0
integer SDManaAbility=0
integer SDLifeAbility=0
integer SDLastViewer=-1
boolean SDAllianceAB=false
boolean SDAllianceBA=false
integer SDPhase=0
integer SDTicks=0
integer SDWatching=-1
unit SDEnemy=null
unit SDFriend=null
timer SDManagerTimer=null
boolean array STRefresh
// @@SD_MANAGER_FUNCTIONS@@

function SDRefreshViews takes nothing returns nothing
local integer p=0
loop
exitwhen p==10
set STRefresh[p]=true
set p=p+1
endloop
endfunction

function SDStop takes nothing returns nothing
local boolean hadDemo=SDActive
set SDActive=false
set SDInitializing=false
set SDRunning=false
set SDGeneration=SDGeneration+1
set SDCreating=true
// @@SD_CLEAN_RESOURCES@@
set SDClearCursor=0
loop
exitwhen SDClearCursor>=SDDirtyCount
call ExecuteFunc("SDArrayClearBatch")
endloop
set SDDirtyCount=0
call SDReleaseBank()
call FlushParentHashtable(SDTouches)
call FlushParentHashtable(SDObjects)
set SDCreating=false
if hadDemo then
call SetPlayerAlliance(Player(13),Player(14),ALLIANCE_PASSIVE,SDAllianceAB)
call SetPlayerAlliance(Player(14),Player(13),ALLIANCE_PASSIVE,SDAllianceBA)
endif
set SDActor=null
set SDEnemy=null
set SDFriend=null
set SDFakeBuyer=null
set SDViewer=-1
set SDPhase=0
call SDRefreshViews()
endfunction

function SDRequest takes integer p,integer h,integer skill,integer mode returns nothing
if GGVPhase!=0 then
return
endif
set SDRequests[p]=h
set SDRequestSkill[p]=skill
set SDRequestMode[p]=mode
set SDCursors[p]=0
if SDActive and SDViewer!=p then
set GGVStatus[p]="Демонстрация другого игрока заканчивается. Ты в очереди на показ."
set GGVDirty[p]=true
endif
if SDActive and SDViewer==p then
call SDStop()
endif
endfunction

function SDCancel takes integer p returns nothing
set SDRequests[p]=-1
if SDActive and SDViewer==p then
call SDStop()
endif
endfunction

function SDConvertActorAbilities takes nothing returns nothing
local integer i=0
local integer level=0
loop
exitwhen i>=SDAbilityCount
set level=GetUnitAbilityLevel(SDActor,SDOriginalAbility[i])
if level>0 then
call UnitRemoveAbility(SDActor,SDOriginalAbility[i])
call UnitAddAbility(SDActor,SDAliasAbility[i])
call SetUnitAbilityLevel(SDActor,SDAliasAbility[i],level)
endif
set i=i+1
endloop
endfunction

function SDStart takes integer p,integer h,integer s returns nothing
local fogmodifier fog=null
local rect area=null
set SDAllianceAB=GetPlayerAlliance(Player(13),Player(14),ALLIANCE_PASSIVE)
set SDAllianceBA=GetPlayerAlliance(Player(14),Player(13),ALLIANCE_PASSIVE)
set SDViewer=p
set SDWatching=s
set SDIndex=s
set SDCastRaw=SDSpellRaw[s]
set SDCastSeen=false
set SDActorBase=GGMHeroRaw[h]
set SDActive=true
set SDRunning=true
call SDInitializeBank()
set SDActor=SDNewUnit(Player(13),SDSpellActor[s],650,14500,90)
call SDConvertActorAbilities()
call SetUnitPathing(SDActor,false)
call SetHeroLevel(SDActor,100,false)
call UnitAddAbility(SDActor,SDManaAbility)
call UnitAddAbility(SDActor,SDLifeAbility)
set SDFakeBuyer=SDNewUnit(Player(13),'h01A',650,14500,0)
set SDInitializing=true
call SDX_Trig_Hero_Select_Actions()
set SDInitializing=false
call SetUnitPosition(SDActor,650,14500)
call SetUnitInvulnerable(SDActor,false)
call SDAddAbility(SDActor,SDCastRaw)
call SDSetAbility(SDActor,SDCastRaw,SDSpellLevel[s])
call SetUnitState(SDActor,UNIT_STATE_MANA,GetUnitState(SDActor,UNIT_STATE_MAX_MANA))
call UnitResetCooldown(SDActor)
set SDEnemy=SDNewUnit(Player(14),'Hpal',650,15100,270)
set SDFriend=SDNewUnit(Player(13),'Hpal',1000,14900,270)
call SetHeroLevel(SDEnemy,100,false)
call SetHeroLevel(SDFriend,100,false)
call UnitAddAbility(SDEnemy,SDLifeAbility)
call UnitAddAbility(SDFriend,SDLifeAbility)
call SetPlayerAlliance(Player(13),Player(14),ALLIANCE_PASSIVE,false)
call SetPlayerAlliance(Player(14),Player(13),ALLIANCE_PASSIVE,false)
set area=SDNewRect(-1800,13000,1800,15900)
set fog=SDTrackFog(CreateFogModifierRect(Player(p),FOG_OF_WAR_VISIBLE,area,true,false))
call FogModifierStart(fog)
set fog=SDTrackFog(CreateFogModifierRect(Player(13),FOG_OF_WAR_VISIBLE,area,true,false))
call FogModifierStart(fog)
set fog=SDTrackFog(CreateFogModifierRect(Player(14),FOG_OF_WAR_VISIBLE,area,true,false))
call FogModifierStart(fog)
set SDRunning=false
set SDTicks=0
set SDPhase=1
call SDRefreshViews()
set fog=null
set area=null
endfunction

function SDWatch takes nothing returns nothing
if SDActive and GetTriggerUnit()==SDActor and SDSpellId()==SDCastRaw then
set SDCastSeen=true
set GGVStatus[SDViewer]="Применяется: "+GGMSkillName[SDWatching]
set GGVDirty[SDViewer]=true
endif
endfunction

function SDSummon takes nothing returns nothing
if SDActive and SDIsUnit(GetSummoningUnit()) then
call SDTrackUnit(GetSummonedUnit())
call SetUnitPathing(GetSummonedUnit(),false)
endif
endfunction

function SDPlay takes nothing returns nothing
local string order=SDSpellOrder[SDWatching]
local unit target=SDEnemy
local boolean issued=false
if SDSpellAlly[SDWatching] then
set target=SDFriend
call SetUnitState(SDFriend,UNIT_STATE_LIFE,GetUnitState(SDFriend,UNIT_STATE_MAX_LIFE)*0.45)
endif
call SetUnitState(SDActor,UNIT_STATE_MANA,GetUnitState(SDActor,UNIT_STATE_MAX_MANA))
call UnitResetCooldown(SDActor)
if order!="" then
if SDSpellTarget[SDWatching]==0 then
set issued=IssueImmediateOrder(SDActor,order)
elseif SDSpellTarget[SDWatching]==1 then
set issued=IssueTargetOrder(SDActor,order,target)
else
set issued=IssuePointOrder(SDActor,order,GetUnitX(target),GetUnitY(target))
endif
if not issued then
set issued=IssueTargetOrder(SDActor,order,target)
endif
if not issued then
set issued=IssuePointOrder(SDActor,order,GetUnitX(target),GetUnitY(target))
endif
if not issued then
set issued=IssueImmediateOrder(SDActor,order)
endif
set GGVStatus[SDViewer]="Герой готовит: "+GGMSkillName[SDWatching]
else
set GGVStatus[SDViewer]="Пассивное или особое умение. Показ взаимодействия с манекеном."
call IssueTargetOrder(SDActor,"attack",SDEnemy)
endif
call IssueTargetOrder(SDEnemy,"attack",SDActor)
set GGVDirty[SDViewer]=true
set target=null
endfunction

function SDTick takes nothing returns nothing
local integer p=0
local integer h=0
local integer s=0
local integer n=0
if GGVPhase!=0 then
if SDActive then
call SDStop()
endif
return
endif
if SDActive then
if not GGVOpenState[SDViewer] or (GGVScreen[SDViewer]!=3 and GGVScreen[SDViewer]!=4) then
call SDCancel(SDViewer)
return
endif
set SDTicks=SDTicks+1
if SDTicks==6 then
call SDPlay()
elseif SDTicks==25 and SDSpellOrder[SDWatching]!="" and not SDCastSeen then
set GGVStatus[SDViewer]="Не удалось показать навык автоматически: "+GGMSkillName[SDWatching]+". Можно выбрать другой навык."
set GGVDirty[SDViewer]=true
elseif SDTicks>=65 then
set SDLastViewer=SDViewer
set SDCursors[SDViewer]=ModuloInteger(SDCursors[SDViewer]+1,4)
call SDStop()
endif
return
endif
loop
exitwhen n==10
set p=ModuloInteger(SDLastViewer+1+n,10)
if GetPlayerController(Player(p))==MAP_CONTROL_USER and GetPlayerSlotState(Player(p))==PLAYER_SLOT_STATE_PLAYING and not GGVDropped[p] and GGVOpenState[p] and (GGVScreen[p]==3 or GGVScreen[p]==4) and SDRequests[p]>=0 then
set h=SDRequests[p]
set s=SDRequestSkill[p]
if SDRequestMode[p]==1 then
set s=GGMHeroSkillStart[h]+SDCursors[p]
endif
set GGVStatus[p]="Демонстрация: "+GGMSkillName[s]
call SDStart(p,h,s)
return
endif
set n=n+1
endloop
endfunction

function SDInit takes nothing returns nothing
local trigger watch=CreateTrigger()
local trigger summons=CreateTrigger()
local integer p=0
set SDObjects=InitHashtable()
set SDTouches=InitHashtable()
set SDMeta=InitHashtable()
// @@SD_METADATA@@
loop
exitwhen p==10
set SDRequests[p]=-1
set p=p+1
endloop
call TriggerRegisterPlayerUnitEvent(watch,Player(13),EVENT_PLAYER_UNIT_SPELL_EFFECT,null)
call TriggerAddAction(watch,function SDWatch)
call TriggerRegisterPlayerUnitEvent(summons,Player(13),EVENT_PLAYER_UNIT_SUMMON,null)
call TriggerRegisterPlayerUnitEvent(summons,Player(14),EVENT_PLAYER_UNIT_SUMMON,null)
call TriggerAddAction(summons,function SDSummon)
set SDManagerTimer=CreateTimer()
call TimerStart(SDManagerTimer,0.1,true,function SDTick)
set watch=null
set summons=null
endfunction

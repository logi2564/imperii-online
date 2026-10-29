// @@GLOBALS_BEGIN@@
integer GGMHeroCount=0
integer GGMAliasCount=0
integer array GGMAliasRaw
integer array GGMAliasHero
integer array GGMHeroRaw
integer array GGMHeroRole
integer array GGMHeroTavern
integer array GGMHeroSkillStart
integer array GGMHeroSkillCount
integer array GGMHeroAboutStart
integer array GGMHeroAboutCount
string array GGMHeroName
string array GGMHeroAbout
string array GGMRoleName
string array GGMSkillName
integer array GGMSkillTextStart
integer array GGMSkillTextCount
string array GGMSkillText
integer GGVPhase=0
integer GGVMode=1
integer GGVGoal=25
integer GGVPendingGoal=0
integer GGVLaunchStep=0
integer GGVTicks=0
boolean GGVStarted=false
boolean array GGVDropped
integer array GGVChoice
integer array GGVTeam
boolean array GGVReady
integer array GGVFamilyOwner
integer array GGVFamily
integer array GGVHeroButton
integer array GGVSkillButton
integer array GGVControllerType
integer array GGVControlRaw
integer GGVGenericType=0
integer GGVFloorType=0
boolean array GGVOpenState
boolean array GGVSaveCam
unit array GGVControl
unit array GGVFloor
fogmodifier array GGVFog
real array GGVX
real array GGVY
real array GGVZ
real array GGVOffset
boolean array GGVDirty
integer array GGVScreen
integer array GGVRole
integer array GGVPage
integer array GGVHero
integer array GGVSkill
integer array GGVTextPage
integer array GGVRevision
integer array GGVBindRaw
integer array GGVBindAction
integer array GGVBindValue
integer array GGVPendingAction
integer array GGVPendingValue
integer array GGVPendingRevision
boolean array GGVSent
boolean array GGVAcknowledged
boolean array GGVEntered
boolean array GGVEnterCalled
string array GGVStatus
multiboard array GGVInfo
integer array GGVInfoRow
multiboard GGVGameBoard=null
timer GGVInputTimer=null
timer GGVCameraTimer=null
timer GGVSpawnTimer=null
// @@GLOBALS_END@@

function GGVActive takes integer p returns boolean
return p>=0 and p<10 and not GGVDropped[p] and GetPlayerController(Player(p))==MAP_CONTROL_USER and GetPlayerSlotState(Player(p))==PLAYER_SLOT_STATE_PLAYING
endfunction

function GGVHost takes nothing returns integer
local integer p=0
loop
exitwhen p==10
if GGVActive(p) then
return p
endif
set p=p+1
endloop
return -1
endfunction

function GGVCount takes nothing returns integer
local integer p=0
local integer count=0
loop
exitwhen p==10
if GGVActive(p) then
set count=count+1
endif
set p=p+1
endloop
return count
endfunction

function GGVFindHero takes integer raw returns integer
local integer h=0
loop
exitwhen h>=GGMHeroCount
if GGMHeroRaw[h]==raw then
return h
endif
set h=h+1
endloop
set h=0
loop
exitwhen h>=GGMAliasCount
if GGMAliasRaw[h]==raw then
return GGMAliasHero[h]
endif
set h=h+1
endloop
return -1
endfunction

function GGVAvailable takes integer p,integer h returns boolean
local integer owner
if h<0 or h>=GGMHeroCount then
return false
endif
set owner=GGVFamilyOwner[GGVFamily[h]]
return GetPlayerTechMaxAllowed(Player(p),GGMHeroRaw[h])!=0 and (owner<0 or owner==p)
endfunction

function GGVAllReady takes nothing returns boolean
local integer p=0
local integer a=0
local integer b=0
loop
exitwhen p==10
if GGVActive(p) then
if GGVChoice[p]<0 or not GGVReady[p] then
return false
endif
if GGVTeam[p]==1 then
set a=a+1
else
set b=b+1
endif
endif
set p=p+1
endloop
return a<=5 and b<=5 and (GGVMode!=2 or (a>0 and b>0))
endfunction

function GGVGround takes real x,real y returns real
local location l=Location(x,y)
local real z=GetLocationZ(l)
call RemoveLocation(l)
set l=null
return z
endfunction

function GGVLine takes integer p,string text returns nothing
local multiboarditem rowItem=null
if GGVInfoRow[p]>=32 then
call MultiboardSetRowCount(GGVInfo[p],GGVInfoRow[p]+1)
endif
set rowItem=MultiboardGetItem(GGVInfo[p],GGVInfoRow[p],0)
call MultiboardSetItemValue(rowItem,text)
call MultiboardSetItemWidth(rowItem,0.34)
call MultiboardSetItemStyle(rowItem,true,false)
call MultiboardReleaseItem(rowItem)
set GGVInfoRow[p]=GGVInfoRow[p]+1
set rowItem=null
endfunction

function GGVParagraph takes integer p,string text returns nothing
local integer n=0
local integer first=0
local string word=""
local string line=""
local string c=""
loop
exitwhen n>StringLength(text)
set c=SubString(text,n,n+1)
if c==" " or c=="\n" or n==StringLength(text) then
set word=SubString(text,first,n)
if StringLength(line)+StringLength(word)>72 and line!="" then
call GGVLine(p,line)
set line=""
endif
if word!="" then
if line!="" then
set line=line+" "
endif
set line=line+word
endif
if c=="\n" then
call GGVLine(p,line)
set line=""
endif
set first=n+1
endif
set n=n+1
endloop
if line!="" then
call GGVLine(p,line)
endif
endfunction

function GGVBoard takes integer p returns nothing
local integer q=0
local integer h=GGVHero[p]
local integer s=GGVSkill[p]
local string state=""
call MultiboardSetRowCount(GGVInfo[p],32)
set GGVInfoRow[p]=0
if GGVScreen[p]==4 then
call MultiboardSetTitleText(GGVInfo[p],"Навыки героя")
call GGVParagraph(p,GGMSkillName[s])
call GGVLine(p,"Часть "+I2S(GGVTextPage[p]+1)+" / "+I2S(GGMSkillTextCount[s]))
call GGVParagraph(p,GGMSkillText[GGMSkillTextStart[s]+GGVTextPage[p]])
elseif GGVScreen[p]==3 then
call MultiboardSetTitleText(GGVInfo[p],GGMHeroName[h])
call GGVLine(p,"Роль: "+GGMRoleName[GGMHeroRole[h]])
if GGVAvailable(p,h) then
call GGVLine(p,"|cff7dda87Доступен для выбора|r")
else
call GGVLine(p,"|cffff8d83Занят или закрыт правилами карты|r")
endif
call GGVParagraph(p,GGMHeroAbout[GGMHeroAboutStart[h]])
call GGVLine(p,"Иконки снизу открывают описание навыков.")
else
call MultiboardSetTitleText(GGVInfo[p],"Подготовка матча")
if GGVMode==1 then
call GGVLine(p,"Арена • цель: "+I2S(GGVGoal)+" очков")
else
call GGVLine(p,"Эпицентр • до "+I2S(GGVGoal)+" побед")
endif
call GGVLine(p,"Твоя команда: "+I2S(GGVTeam[p]))
loop
exitwhen q==10
if GGVActive(q) then
set state="выбирает"
if GGVReady[q] then
set state="ГОТОВ"
endif
call GGVParagraph(p,GetPlayerName(Player(q))+" • команда "+I2S(GGVTeam[q])+" • "+state)
endif
set q=q+1
endloop
if GGVPhase==0 then
if GGVAllReady() then
call GGVLine(p,"Все готовы. Ведущий может начать бой.")
else
call GGVLine(p,"Закрепи героя, затем нажми «Готов».")
endif
elseif GGVPhase==1 then
call GGVLine(p,"Запуск: создание героев и вход в бой.")
else
call GGVLine(p,"Матч идёт. Здесь доступен просмотр.")
endif
endif
if GGVChoice[p]>=0 then
call GGVParagraph(p,"Твой выбор: "+GGMHeroName[GGVChoice[p]])
endif
if GGVStatus[p]!="" then
call GGVParagraph(p,GGVStatus[p])
endif
call MultiboardSetRowCount(GGVInfo[p],GGVInfoRow[p])
if GetLocalPlayer()==Player(p) then
if GGVGameBoard!=null then
call MultiboardDisplay(GGVGameBoard,false)
endif
call MultiboardDisplay(GGVInfo[p],true)
call MultiboardMinimize(GGVInfo[p],false)
endif
endfunction

function GGVCamera takes integer p returns nothing
local real x=GGVX[p]+200
local real y=GGVY[p]-600
if GetLocalPlayer()==Player(p) then
call SetCameraBounds(x-16,y-16,x+16,y+16,x-16,y+16,x+16,y-16)
call SetCameraPosition(x,y)
call SetCameraField(CAMERA_FIELD_TARGET_DISTANCE,2200,0)
call SetCameraField(CAMERA_FIELD_ANGLE_OF_ATTACK,315,0)
call SetCameraField(CAMERA_FIELD_ROTATION,90,0)
call SetCameraField(CAMERA_FIELD_FIELD_OF_VIEW,70,0)
call SetCameraField(CAMERA_FIELD_ZOFFSET,GGVOffset[p],0)
call SetCameraField(CAMERA_FIELD_FARZ,4500,0)
if not IsUnitSelected(GGVControl[p],Player(p)) then
call ClearSelection()
call SelectUnit(GGVControl[p],true)
endif
endif
endfunction

function GGVPanel takes integer p returns nothing
local string path="GGV\\Panels\\main.tga"
local string n=I2S(GGVHero[p])
if GGVScreen[p]==1 or GGVScreen[p]==2 then
set path="GGV\\Panels\\roles.tga"
elseif GGVScreen[p]==3 or GGVScreen[p]==4 then
if GGVHero[p]<10 then
set n="0"+n
endif
set path="GGV\\Panels\\hero"+n+".tga"
endif
if GetLocalPlayer()==Player(p) then
call ShowInterface(true,0)
call SetCineFilterTexture(path)
call SetCineFilterBlendMode(BLEND_MODE_BLEND)
call SetCineFilterTexMapFlags(TEXMAP_FLAG_NONE)
call SetCineFilterStartUV(0,0,1,1)
call SetCineFilterEndUV(0,0,1,1)
call SetCineFilterStartColor(255,255,255,255)
call SetCineFilterEndColor(255,255,255,255)
call SetCineFilterDuration(0)
call DisplayCineFilter(true)
endif
endfunction

function GGVBind takes integer p,integer slot,integer raw,integer action,integer value returns nothing
call UnitAddAbility(GGVControl[p],raw)
set GGVBindRaw[p*12+slot]=raw
set GGVBindAction[p*12+slot]=action
set GGVBindValue[p*12+slot]=value
endfunction

function GGVButton takes integer p,integer slot,integer action,integer value,integer variant returns nothing
call GGVBind(p,slot,GGVControlRaw[action*120+slot*10+variant],action,value)
endfunction

function GGVReadyButton takes integer p,integer slot returns nothing
local integer state=0
if GGVReady[p] then
set state=1
endif
call GGVButton(p,slot,11,0,state)
endfunction

function GGVStartButton takes integer p returns nothing
if p==GGVHost() and GGVPhase<2 then
call GGVButton(p,11,12,0,0)
else
call GGVButton(p,11,6,0,0)
endif
endfunction

function GGVRender takes integer p returns nothing
local integer raw=GGVGenericType
local integer slot=0
local integer i=0
local integer ordinal=0
local integer first=0
local unit old=GGVControl[p]
if not GGVOpenState[p] then
return
endif
if GGVScreen[p]==3 or GGVScreen[p]==4 then
set raw=GGVControllerType[GGVHero[p]]
endif
loop
exitwhen slot==12
if GGVBindRaw[p*12+slot]!=0 and old!=null then
call UnitRemoveAbility(old,GGVBindRaw[p*12+slot])
endif
set GGVBindRaw[p*12+slot]=0
set GGVBindAction[p*12+slot]=0
set slot=slot+1
endloop
if GetUnitTypeId(old)!=raw then
if old!=null then
call RemoveUnit(old)
endif
set GGVControl[p]=CreateUnit(Player(p),raw,GGVX[p]+200,GGVY[p]-700,225)
call SetUnitFlyHeight(GGVControl[p],GGVZ[p]-GGVGround(GGVX[p]+200,GGVY[p]-700),0)
call SetUnitPathing(GGVControl[p],false)
call SetUnitInvulnerable(GGVControl[p],true)
call UnitRemoveAbility(GGVControl[p],'Amov')
call UnitRemoveAbility(GGVControl[p],'Aatk')
call SetUnitAnimation(GGVControl[p],"stand")
endif
set GGVRevision[p]=GGVRevision[p]+1
if GGVScreen[p]==0 then
call GGVButton(p,0,1,0,0)
call GGVButton(p,1,2,0,0)
call GGVButton(p,2,3,0,0)
call GGVButton(p,3,4,0,0)
call GGVButton(p,4,5,0,0)
call GGVButton(p,5,6,0,0)
call GGVButton(p,6,7,0,0)
call GGVButton(p,7,8,0,0)
call GGVButton(p,8,9,0,0)
call GGVButton(p,9,10,0,0)
call GGVReadyButton(p,10)
elseif GGVScreen[p]==1 then
loop
exitwhen i==8
call GGVButton(p,i,14,i,i)
set i=i+1
endloop
call GGVButton(p,8,13,0,0)
call GGVButton(p,9,9,0,0)
call GGVReadyButton(p,10)
elseif GGVScreen[p]==2 then
loop
exitwhen i==GGMHeroCount
if GGMHeroRole[i]==GGVRole[p] then
if ordinal>=GGVPage[p]*8 and ordinal<GGVPage[p]*8+8 then
call GGVBind(p,ModuloInteger(ordinal,8),GGVHeroButton[i],17,i)
endif
set ordinal=ordinal+1
endif
set i=i+1
endloop
if GGVPage[p]>0 then
call GGVButton(p,8,15,0,0)
endif
if ordinal>(GGVPage[p]+1)*8 then
call GGVButton(p,9,16,0,0)
endif
call GGVButton(p,10,13,0,0)
elseif GGVScreen[p]==3 then
set first=GGMHeroSkillStart[GGVHero[p]]+GGVPage[p]*4
set i=first
loop
exitwhen i>=first+4 or i>=GGMHeroSkillStart[GGVHero[p]]+GGMHeroSkillCount[GGVHero[p]]
call GGVBind(p,i-first,GGVSkillButton[i],18,i)
set i=i+1
endloop
if GGVPage[p]>0 then
call GGVButton(p,4,19,0,0)
endif
if GGMHeroSkillCount[GGVHero[p]]>(GGVPage[p]+1)*4 then
call GGVButton(p,5,20,0,0)
endif
call GGVButton(p,6,21,0,0)
call GGVButton(p,7,4,0,0)
if GGVChoice[p]>=0 then
call GGVButton(p,8,10,0,0)
else
call GGVButton(p,8,22,0,0)
endif
call GGVReadyButton(p,9)
call GGVButton(p,10,1,0,0)
elseif GGVScreen[p]==4 then
call GGVButton(p,0,25,0,0)
call GGVButton(p,1,26,0,0)
if GGVTextPage[p]>0 then
call GGVButton(p,2,23,0,0)
endif
if GGVTextPage[p]+1<GGMSkillTextCount[GGVSkill[p]] then
call GGVButton(p,3,24,0,0)
endif
call GGVButton(p,4,27,0,0)
call GGVButton(p,5,21,0,0)
call GGVButton(p,6,8,0,0)
call GGVButton(p,7,4,0,0)
if GGVChoice[p]>=0 then
call GGVButton(p,8,10,0,0)
else
call GGVButton(p,8,22,0,0)
endif
call GGVReadyButton(p,9)
call GGVButton(p,10,1,0,0)
endif
call GGVStartButton(p)
call GGVPanel(p)
call GGVBoard(p)
set GGVDirty[p]=false
call GGVCamera(p)
set old=null
endfunction

function GGVOpen takes integer p returns nothing
if not GGVActive(p) then
return
endif
if not GGVOpenState[p] then
set GGVSaveCam[p]=udg_Camlock_On[p+1]
set udg_Camlock_On[p+1]=false
set GGVOpenState[p]=true
set GGVFloor[p]=CreateUnit(Player(PLAYER_NEUTRAL_PASSIVE),GGVFloorType,GGVX[p],GGVY[p],0)
call SetUnitFlyHeight(GGVFloor[p],GGVZ[p]-GGVGround(GGVX[p],GGVY[p]),0)
call SetUnitPathing(GGVFloor[p],false)
set GGVFog[p]=CreateFogModifierRadius(Player(p),FOG_OF_WAR_VISIBLE,GGVX[p],GGVY[p],3200,false,false)
call FogModifierStart(GGVFog[p])
endif
call GGVRender(p)
endfunction

function GGVClose takes integer p returns nothing
if not GGVOpenState[p] then
return
endif
set GGVOpenState[p]=false
set GGVRevision[p]=GGVRevision[p]+1
set GGVPendingAction[p]=0
call RemoveUnit(GGVControl[p])
call RemoveUnit(GGVFloor[p])
call FogModifierStop(GGVFog[p])
call DestroyFogModifier(GGVFog[p])
set GGVControl[p]=null
set GGVFloor[p]=null
set GGVFog[p]=null
set udg_Camlock_On[p+1]=GGVSaveCam[p]
if GetLocalPlayer()==Player(p) then
call DisplayCineFilter(false)
call MultiboardDisplay(GGVInfo[p],false)
if GGVGameBoard!=null then
call MultiboardDisplay(GGVGameBoard,true)
endif
call ResetToGameCamera(0)
call SetCameraBounds(-12032+GetCameraMargin(CAMERA_MARGIN_LEFT),-10624+GetCameraMargin(CAMERA_MARGIN_BOTTOM),12032-GetCameraMargin(CAMERA_MARGIN_RIGHT),12928-GetCameraMargin(CAMERA_MARGIN_TOP),-12032+GetCameraMargin(CAMERA_MARGIN_LEFT),12928-GetCameraMargin(CAMERA_MARGIN_TOP),12032-GetCameraMargin(CAMERA_MARGIN_RIGHT),-10624+GetCameraMargin(CAMERA_MARGIN_BOTTOM))
call ClearSelection()
if udg_Player[p+1]!=null then
call SelectUnit(udg_Player[p+1],true)
call PanCameraTo(GetUnitX(udg_Player[p+1]),GetUnitY(udg_Player[p+1]))
endif
endif
endfunction

function GGVAssignTeams takes nothing returns nothing
local integer p=0
local integer a=0
local integer b=5
local integer q=0
call ForceClear(udg_ForceA)
call ForceClear(udg_ForceB)
loop
exitwhen p==10
if GGVActive(p) then
if GGVTeam[p]==1 then
set a=a+1
call ForceAddPlayer(udg_ForceA,Player(p))
set udg_PlayerNumber[p+1]=a
else
set b=b+1
call ForceAddPlayer(udg_ForceB,Player(p))
set udg_PlayerNumber[p+1]=b
endif
endif
set p=p+1
endloop
set p=0
loop
exitwhen p==10
if not GGVActive(p) then
if a<5 then
set a=a+1
call ForceAddPlayer(udg_ForceA,Player(p))
set udg_PlayerNumber[p+1]=a
else
set b=b+1
call ForceAddPlayer(udg_ForceB,Player(p))
set udg_PlayerNumber[p+1]=b
endif
endif
set q=0
loop
exitwhen q==10
call SetPlayerAllianceStateBJ(Player(p),Player(q),0)
set q=q+1
endloop
set p=p+1
endloop
set p=3
loop
exitwhen p>13
if p!=8 then
call MultiboardSetItemValueBJ(bj_lastCreatedMultiboard,2,p,"")
endif
set p=p+1
endloop
set p=0
loop
exitwhen p==10
if GGVActive(p) then
set q=2+udg_PlayerNumber[p+1]
if GGVTeam[p]==2 then
set q=q+1
endif
call MultiboardSetItemValueBJ(bj_lastCreatedMultiboard,2,q,udg_Color[p+1]+GetPlayerName(Player(p))+"|r")
endif
set p=p+1
endloop
endfunction

function GGVOnHeroSold takes nothing returns nothing
local unit sold=GetSoldUnit()
local integer p=GetPlayerId(GetOwningPlayer(sold))
local integer hero=-1
if GGVPhase==1 and p>=0 and p<10 and GGVChoice[p]>=0 and udg_Player[p+1]!=null then
set hero=GGVFindHero(GetUnitTypeId(udg_Player[p+1]))
if hero>=0 and GGVFamily[hero]==GGVFamily[GGVChoice[p]] then
set GGVAcknowledged[p]=true
endif
endif
set sold=null
endfunction

function GGVSpawnTick takes nothing returns nothing
local integer p=0
local integer accepted=0
local integer entered=0
local integer raw=0
local unit shop=null
local unit portal=null
local boolean issued=false
if GGVPhase!=1 then
call PauseTimer(GGVSpawnTimer)
return
endif
set GGVTicks=GGVTicks+1
if GGVTicks<18 then
return
endif
loop
exitwhen p==10
if GGVActive(p) then
if GGVAcknowledged[p] and udg_Player[p+1]!=null then
set accepted=accepted+1
elseif udg_Player[p+1]==null and GGVChoice[p]>=0 and not GGVSent[p] then
set raw=GGMHeroRaw[GGVChoice[p]]
set shop=udg_Starrrrr[GGMHeroTavern[GGVChoice[p]]]
if shop!=null then
set GGVSent[p]=true
call AddUnitToStock(shop,raw,1,1)
set issued=IssueNeutralImmediateOrderById(Player(p),shop,raw)
if not issued and udg_Player[p+1]==null then
set GGVSent[p]=false
endif
endif
endif
endif
set p=p+1
endloop
if accepted==GGVCount() and GGVLaunchStep==0 then
set GGVLaunchStep=1
if GGVMode==1 then
set p=0
loop
exitwhen p==10
if GGVActive(p) then
call TimerStart(udg_Hero_RestartTimer[p+1],0.2,false,null)
endif
set p=p+1
endloop
else
call TimerStart(udg_Hero_RestartTimer[1],0.5,false,null)
endif
endif
if GGVLaunchStep==1 and GGVMode==1 then
set p=0
loop
exitwhen p==10
if GGVActive(p) then
if udg_ISUNITREADY[p+1] and not GGVEnterCalled[p] then
set portal=gg_unit_n00M_0038
if GGVTeam[p]==2 then
set portal=gg_unit_n00M_0039
endif
set GGVEnterCalled[p]=true
call GV_Restart_1_Actions(Player(p),portal)
set GGVEntered[p]=udg_ISUNITSTARTED[p+1]
endif
if GGVEntered[p] then
set entered=entered+1
endif
endif
set p=p+1
endloop
if entered==GGVCount() then
set GGVPhase=2
call PauseTimer(GGVSpawnTimer)
set p=0
loop
exitwhen p==10
call GGVClose(p)
set p=p+1
endloop
endif
elseif GGVLaunchStep==1 and GGVMode==2 and udg_System_Round>0 then
set GGVPhase=2
call PauseTimer(GGVSpawnTimer)
set p=0
loop
exitwhen p==10
call GGVClose(p)
set p=p+1
endloop
endif
if GGVTicks>150 and GGVPhase==1 then
call PauseTimer(GGVSpawnTimer)
set p=0
loop
exitwhen p==10
if GGVActive(p) then
set GGVStatus[p]="Запуск не завершён. Герой: "+I2S(accepted)+" / "+I2S(GGVCount())+". Уже созданные герои повторно не выдаются. Ведущий может повторить вход."
set GGVScreen[p]=0
call GGVOpen(p)
endif
set p=p+1
endloop
endif
set shop=null
set portal=null
endfunction

function GGVLaunch takes integer p returns nothing
local integer q=0
if p!=GGVHost() or GGVPhase==2 then
set GGVStatus[p]="Начать матч может ведущий до начала боя."
return
endif
if not GGVAllReady() then
set GGVStatus[p]="Нужны готовность всех игроков и корректные команды. В Эпицентре необходим соперник."
return
endif
if GGVPhase==1 then
set q=0
loop
exitwhen q==10
if udg_Player[q+1]==null then
set GGVSent[q]=false
set GGVAcknowledged[q]=false
endif
call GGVClose(q)
set q=q+1
endloop
set GGVTicks=18
call TimerStart(GGVSpawnTimer,0.2,true,function GGVSpawnTick)
return
endif
set GGVPhase=1
set GGVLaunchStep=0
set GGVTicks=0
loop
exitwhen q==10
call GGVClose(q)
set q=q+1
endloop
if GGVMode==1 then
call TriggerExecute(gg_trg_Mode_Team)
else
call TriggerExecute(gg_trg_Mode_Epiccenter)
endif
call GGVAssignTeams()
set GGVPendingGoal=GGVGoal
if GGVMode==1 then
call TriggerExecute(gg_trg_kill_set_Team)
else
call TriggerExecute(gg_trg_kill_set_Epiccenter)
endif
set GGVPendingGoal=0
set GGVGameBoard=bj_lastCreatedMultiboard
call PauseTimer(udg_SelectForcingTimer)
set q=1
loop
exitwhen q>10
call PauseTimer(udg_Hero_RestartTimer[q])
set q=q+1
endloop
call TimerStart(GGVSpawnTimer,0.2,true,function GGVSpawnTick)
endfunction

function GGVRelease takes integer p returns nothing
if GGVChoice[p]>=0 then
if GGVFamilyOwner[GGVFamily[GGVChoice[p]]]==p then
set GGVFamilyOwner[GGVFamily[GGVChoice[p]]]=-1
endif
endif
set GGVChoice[p]=-1
set GGVReady[p]=false
if udg_Player[p+1]==null then
set GGVSent[p]=false
set GGVAcknowledged[p]=false
endif
endfunction

function GGVAction takes integer p,integer action,integer value returns nothing
local integer q=0
local integer h=GGVHero[p]
local integer n=0
if not GGVActive(p) or not GGVOpenState[p] then
return
endif
set GGVStatus[p]=""
if action==6 then
call GGVClose(p)
return
elseif action==12 then
call GGVLaunch(p)
if GGVOpenState[p] then
call GGVRender(p)
endif
return
elseif action==1 then
set GGVScreen[p]=1
elseif action==2 or action==3 or action==5 then
if p==GGVHost() and GGVPhase==0 then
if action==2 then
set GGVMode=1
set GGVGoal=25
elseif action==3 then
set GGVMode=2
set GGVGoal=5
elseif GGVMode==1 then
if GGVGoal==10 then
set GGVGoal=25
elseif GGVGoal==25 then
set GGVGoal=50
elseif GGVGoal==50 then
set GGVGoal=75
else
set GGVGoal=10
endif
else
if GGVGoal==5 then
set GGVGoal=7
elseif GGVGoal==7 then
set GGVGoal=9
elseif GGVGoal==9 then
set GGVGoal=12
else
set GGVGoal=5
endif
endif
loop
exitwhen q==10
set GGVReady[q]=false
set q=q+1
endloop
else
set GGVStatus[p]="Режим и цель меняет ведущий до запуска матча."
endif
elseif action==4 then
if GGVPhase==0 then
set GGVTeam[p]=3-GGVTeam[p]
set GGVReady[p]=false
endif
elseif action==7 then
set GGVScreen[p]=0
set GGVStatus[p]="Выбери героя, закрепи выбор и нажми «Готов». Ведущий начинает бой. Меню не приостанавливает игру."
elseif action==8 then
if udg_Camlock_Distance[p+1]<3000 then
set udg_Camlock_Distance[p+1]=3800
elseif udg_Camlock_Distance[p+1]<4500 then
set udg_Camlock_Distance[p+1]=5000
else
set udg_Camlock_Distance[p+1]=2600
endif
set GGVStatus[p]="Расстояние камеры в бою: "+I2S(R2I(udg_Camlock_Distance[p+1]))
elseif action==9 then
set h=GGVChoice[p]
if GGVPhase==2 then
set h=GGVFindHero(GetUnitTypeId(udg_Player[p+1]))
endif
if h>=0 then
set GGVHero[p]=h
set GGVScreen[p]=3
set GGVPage[p]=0
else
set GGVScreen[p]=1
endif
elseif action==10 then
if GGVPhase<2 and udg_Player[p+1]==null then
call GGVRelease(p)
set GGVScreen[p]=1
else
set GGVStatus[p]="Боевой герой уже создан. Во время матча доступен только просмотр."
endif
elseif action==11 then
if GGVPhase<2 and GGVChoice[p]>=0 then
set GGVReady[p]=not GGVReady[p]
else
set GGVStatus[p]="Сначала закрепи одного героя."
endif
elseif action==13 then
set GGVScreen[p]=0
elseif action==14 then
set GGVRole[p]=value
set GGVPage[p]=0
set GGVScreen[p]=2
elseif action==15 then
set GGVPage[p]=GGVPage[p]-1
elseif action==16 then
set GGVPage[p]=GGVPage[p]+1
elseif action==17 then
set GGVHero[p]=value
set GGVPage[p]=0
set GGVScreen[p]=3
elseif action==18 then
set GGVSkill[p]=value
set GGVTextPage[p]=0
set GGVScreen[p]=4
elseif action==19 then
set GGVPage[p]=GGVPage[p]-1
elseif action==20 then
set GGVPage[p]=GGVPage[p]+1
elseif action==21 or action==27 then
set GGVScreen[p]=3
elseif action==22 then
if GGVPhase==2 or udg_Player[p+1]!=null then
set GGVStatus[p]="В бою нельзя создать второго героя."
elseif GGVChoice[p]>=0 then
set GGVStatus[p]="Герой уже закреплён. Для замены нажми «Изменить выбор»."
elseif not GGVAvailable(p,h) then
set GGVStatus[p]="Герой или его другой облик уже занят либо закрыт правилами карты."
else
set GGVFamilyOwner[GGVFamily[h]]=p
set GGVChoice[p]=h
set GGVReady[p]=false
set GGVStatus[p]="Выбор закреплён. Теперь нажми «Готов»."
endif
elseif action==23 then
set GGVTextPage[p]=GGVTextPage[p]-1
elseif action==24 then
set GGVTextPage[p]=GGVTextPage[p]+1
elseif action==25 or action==26 then
set n=GGMHeroSkillCount[h]
set q=GGVSkill[p]-GGMHeroSkillStart[h]
if action==25 then
set q=ModuloInteger(q+n-1,n)
else
set q=ModuloInteger(q+1,n)
endif
set GGVSkill[p]=GGMHeroSkillStart[h]+q
set GGVTextPage[p]=0
endif
set q=0
loop
exitwhen q==10
set GGVDirty[q]=true
set q=q+1
endloop
call GGVRender(p)
endfunction

function GGVFlush takes nothing returns nothing
local integer p=0
local integer action=0
loop
exitwhen p==10
set action=GGVPendingAction[p]
set GGVPendingAction[p]=0
if action!=0 and GGVPendingRevision[p]==GGVRevision[p] then
call GGVAction(p,action,GGVPendingValue[p])
endif
set p=p+1
endloop
endfunction

function GGVSpell takes nothing returns nothing
local unit caster=GetTriggerUnit()
local integer p=GetPlayerId(GetOwningPlayer(caster))
local integer raw=GetSpellAbilityId()
local integer slot=0
if not GGVActive(p) or not GGVOpenState[p] or caster!=GGVControl[p] then
set caster=null
return
endif
loop
exitwhen slot==12
if GGVBindRaw[p*12+slot]==raw then
set GGVPendingAction[p]=GGVBindAction[p*12+slot]
set GGVPendingValue[p]=GGVBindValue[p*12+slot]
set GGVPendingRevision[p]=GGVRevision[p]
exitwhen true
endif
set slot=slot+1
endloop
set caster=null
endfunction

function GGVChat takes nothing returns nothing
local integer p=GetPlayerId(GetTriggerPlayer())
if GetEventPlayerChatString()=="-skills" then
set GGVHero[p]=GGVFindHero(GetUnitTypeId(udg_Player[p+1]))
if GGVHero[p]<0 then
set GGVHero[p]=0
set GGVScreen[p]=1
else
set GGVScreen[p]=3
set GGVPage[p]=0
endif
call GGVOpen(p)
elseif GGVOpenState[p] then
call GGVClose(p)
else
set GGVScreen[p]=0
call GGVOpen(p)
endif
endfunction

function GGVLeave takes nothing returns nothing
local integer p=GetPlayerId(GetTriggerPlayer())
local integer q=0
set GGVDropped[p]=true
if GGVPhase<2 and udg_Player[p+1]==null then
call GGVRelease(p)
endif
call GGVClose(p)
loop
exitwhen q==10
if GGVActive(q) and GGVOpenState[q] then
call GGVRender(q)
endif
set q=q+1
endloop
endfunction

function GGVCameraTick takes nothing returns nothing
local integer p=0
loop
exitwhen p==10
if GGVActive(p) and GGVOpenState[p] then
call GGVCamera(p)
if GGVDirty[p] then
call GGVBoard(p)
set GGVDirty[p]=false
endif
endif
set p=p+1
endloop
endfunction

function GGVStart takes nothing returns nothing
local integer p=0
local integer n=0
if GGVStarted then
return
endif
set GGVStarted=true
call DisableTrigger(gg_trg_Mode_Team)
call DisableTrigger(gg_trg_Mode_Epiccenter)
call DisableTrigger(gg_trg_Mode_Banpick)
loop
exitwhen p==10
if GGVActive(p) then
set GGVTeam[p]=ModuloInteger(n,2)+1
set n=n+1
call GGVOpen(p)
endif
set p=p+1
endloop
endfunction

function GGVInit takes nothing returns nothing
local trigger spells=CreateTrigger()
local trigger chats=CreateTrigger()
local trigger leaves=CreateTrigger()
local integer p=0
// @@DATA_INIT@@
set GGVInputTimer=CreateTimer()
set GGVCameraTimer=CreateTimer()
set GGVSpawnTimer=CreateTimer()
loop
exitwhen p==GGMHeroCount
set GGVFamilyOwner[p]=-1
set p=p+1
endloop
set p=0
loop
exitwhen p==10
set GGVChoice[p]=-1
set GGVStatus[p]=""
set GGVX[p]=-11500+I2R(ModuloInteger(p,5))*5500
set GGVY[p]=7000
if p>=5 then
set GGVY[p]=-12500
endif
set GGVZ[p]=GGVGround(GGVX[p],GGVY[p])+2000
set GGVOffset[p]=GGVZ[p]-GGVGround(GGVX[p]+200,GGVY[p]-600)
set GGVInfo[p]=CreateMultiboard()
call MultiboardSetColumnCount(GGVInfo[p],1)
call MultiboardSetRowCount(GGVInfo[p],32)
call TriggerRegisterPlayerUnitEvent(spells,Player(p),EVENT_PLAYER_UNIT_SPELL_EFFECT,null)
call TriggerRegisterPlayerChatEvent(chats,Player(p),"-menu",true)
call TriggerRegisterPlayerChatEvent(chats,Player(p),"-skills",true)
call TriggerRegisterPlayerEvent(leaves,Player(p),EVENT_PLAYER_LEAVE)
set p=p+1
endloop
call TriggerAddAction(spells,function GGVSpell)
call TriggerAddAction(chats,function GGVChat)
call TriggerAddAction(leaves,function GGVLeave)
call TimerStart(GGVInputTimer,0.05,true,function GGVFlush)
call TimerStart(GGVCameraTimer,0.25,true,function GGVCameraTick)
set spells=null
set chats=null
set leaves=null
endfunction

// @@ST_GLOBALS@@
unit array STWidgets
integer array STWidgetAction
integer array STWidgetValue
integer array STWidgetCount
integer array STButtonRaw
integer array STHeroRaw
integer array STSkillRaw
integer array STRoleRaw
integer STPanelRaw=0
unit array STPanel
texttag array STText
// @@ST_FUNCTIONS@@

function STX takes integer p returns real
if SDActive and SDViewer==p then
return 0.
endif
return GGVX[p]
endfunction

function STY takes integer p returns real
if SDActive and SDViewer==p then
return 14500.
endif
return GGVY[p]
endfunction

function STZ takes integer p returns real
if SDActive and SDViewer==p then
return GGVGround(0,14500)
endif
return GGVZ[p]
endfunction

function STClear takes integer p returns nothing
local integer i=0
loop
exitwhen i>=STWidgetCount[p]
call RemoveUnit(STWidgets[p*16+i])
set STWidgets[p*16+i]=null
set i=i+1
endloop
set STWidgetCount[p]=0
call RemoveUnit(STPanel[p])
set STPanel[p]=null
endfunction

function STPlace takes unit u,integer p,real x,real y returns nothing
local real wx=STX(p)+x
local real wy=STY(p)+y*0.70710678
call SetUnitPosition(u,wx,wy)
call SetUnitFlyHeight(u,STZ(p)+350+y*0.70710678-GGVGround(wx,wy),0)
call SetUnitPathing(u,false)
call SetUnitInvulnerable(u,true)
endfunction

function STWidget takes integer p,integer raw,integer action,integer value,real x,real y returns nothing
local integer index=p*16+STWidgetCount[p]
local unit u=null
if STWidgetCount[p]>=16 or raw==0 then
return
endif
set u=CreateUnit(Player(p),raw,STX(p)+x,STY(p)+y*0.70710678,0)
call STPlace(u,p,x,y)
if action==0 then
call UnitAddAbility(u,'Aloc')
endif
set STWidgets[index]=u
set STWidgetAction[index]=action
set STWidgetValue[index]=value
set STWidgetCount[p]=STWidgetCount[p]+1
set u=null
endfunction

function STButton takes integer p,integer action,real x,real y returns nothing
call STWidget(p,STButtonRaw[action],action,0,x,y)
endfunction

function STWrite takes integer p,string text returns nothing
local integer n=0
local integer first=0
local integer part=0
local integer count=StringLength(text)
local string line=""
local string word=""
local string block=""
local string c=""
local real top=350
if GGVScreen[p]==1 or GGVScreen[p]==2 then
set top=650
endif
loop
exitwhen part==4
call SetTextTagText(STText[p*4+part],"",0.026)
if GetLocalPlayer()==Player(p) then
call SetTextTagVisibility(STText[p*4+part],true)
endif
set part=part+1
endloop
set part=0
loop
exitwhen n>count or part>=4
set c=SubString(text,n,n+1)
if c==" " or c=="\n" or n==count then
set word=SubString(text,first,n)
if StringLength(line)+StringLength(word)>72 and line!="" then
set block=block+line+"\n"
set line=""
endif
if StringLength(block)+StringLength(line)+StringLength(word)>205 then
call SetTextTagText(STText[p*4+part],block+line,0.026)
set block=""
set line=""
set part=part+1
endif
if word!="" then
if line!="" then
set line=line+" "
endif
set line=line+word
endif
if c=="\n" then
set block=block+line+"\n"
set line=""
endif
set first=n+1
endif
set n=n+1
endloop
if part<4 then
call SetTextTagText(STText[p*4+part],block+line,0.026)
endif
set part=0
loop
exitwhen part==4
call SetTextTagPos(STText[p*4+part],STX(p)-1300,STY(p)+(top-I2R(part)*220)*0.70710678,STZ(p)+350+(top-I2R(part)*220)*0.70710678-GGVGround(STX(p)-1300,STY(p)+(top-I2R(part)*220)*0.70710678))
set part=part+1
endloop
endfunction

function STModeName takes nothing returns string
if GGVMode==2 then
return "Эпицентр"
elseif GGVMode==3 then
return "Каждый за себя"
endif
return "Арена"
endfunction

function STInfo takes integer p returns nothing
local integer q=0
local integer h=GGVHero[p]
local integer s=GGVSkill[p]
local string text=""
if GGVScreen[p]==1 then
set text="Выбери роль"
elseif GGVScreen[p]==2 then
set text=GGMRoleName[GGVRole[p]]+" • страница "+I2S(GGVPage[p]+1)
elseif GGVScreen[p]==3 then
set text=GGMHeroName[h]+"\n"+GGMHeroAbout[GGMHeroAboutStart[h]]+"\n\nНажми на иконку навыка для применения."
elseif GGVScreen[p]==4 then
set text=GGMSkillName[s]+"\n"+GGMSkillText[GGMSkillTextStart[s]+GGVTextPage[p]]
elseif GGVScreen[p]==5 then
set text="Режим: "+STModeName()+"\nЦель: "+I2S(GGVGoal)+"\n"
if p==GGVHost() and GGVPhase==0 then
set text=text+"Выбери правила крупной карточкой. Изменения требуют подтверждения игроков."
else
set text=text+"Правила выбирает ведущий: "+GetPlayerName(Player(GGVHost()))
endif
elseif GGVScreen[p]==6 then
set text=STModeName()+" • "+I2S(GGVGoal)+"\n\n"
loop
exitwhen q==10
if GGVActive(q) then
if GGVReady[q] then
set text=text+GetPlayerName(Player(q))+": ГОТОВ\n"
else
set text=text+GetPlayerName(Player(q))+": выбирает\n"
endif
endif
set q=q+1
endloop
if GGVAllReady() then
set text=text+"\nВедущий может начать бой."
endif
else
set text="Режим: "+STModeName()+" • "+I2S(GGVGoal)
endif
if GGVStatus[p]!="" then
set text=text+"\n\n"+GGVStatus[p]
endif
call STWrite(p,text)
endfunction

function GGVCamera takes integer p returns nothing
local real x=STX(p)
local real y=STY(p)
if GetLocalPlayer()==Player(p) then
call SetCameraBounds(x-8,y-8,x+8,y+8,x-8,y+8,x+8,y-8)
call SetCameraPosition(x,y)
call SetCameraField(CAMERA_FIELD_TARGET_DISTANCE,2200,0)
call SetCameraField(CAMERA_FIELD_ANGLE_OF_ATTACK,315,0)
call SetCameraField(CAMERA_FIELD_ROTATION,90,0)
call SetCameraField(CAMERA_FIELD_FIELD_OF_VIEW,70,0)
call SetCameraField(CAMERA_FIELD_ZOFFSET,STZ(p)+350-GGVGround(x,y),0)
call SetCameraField(CAMERA_FIELD_FARZ,7500,0)
endif
endfunction

function GGVPanel takes integer p returns nothing
if GetLocalPlayer()==Player(p) then
call DisplayCineFilter(false)
call ShowInterface(false,0)
call EnableUserControl(true)
call EnableSelect(true,true)
call EnableDragSelect(false,false)
call MultiboardDisplay(GGVInfo[p],false)
endif
endfunction

function GGVBoard takes integer p returns nothing
call STInfo(p)
endfunction

function GGVRender takes integer p returns nothing
local integer i=0
local integer ordinal=0
local integer first=0
local integer h=GGVHero[p]
local integer action=0
local real x=0
local real y=0
if not GGVOpenState[p] then
return
endif
call STClear(p)
call RemoveUnit(GGVControl[p])
set GGVControl[p]=null
set GGVRevision[p]=GGVRevision[p]+1
set STPanel[p]=CreateUnit(Player(p),STPanelRaw,STX(p),STY(p),0)
call STPlace(STPanel[p],p,0,0)
call UnitAddAbility(STPanel[p],'Aloc')
if not (SDActive and SDViewer==p) then
set GGVControl[p]=CreateUnit(Player(p),GGVControllerType[h],STX(p)+700,STY(p)+200,225)
call UnitAddAbility(GGVControl[p],'Aloc')
call SetUnitFlyHeight(GGVControl[p],STZ(p)-GGVGround(STX(p)+700,STY(p)+200),0)
call SetUnitInvulnerable(GGVControl[p],true)
call SetUnitPathing(GGVControl[p],false)
endif
if GGVScreen[p]==0 then
call STButton(p,1,-650,100)
call STButton(p,30,-650,-180)
call STButton(p,31,-650,-460)
elseif GGVScreen[p]==1 then
loop
exitwhen i==8
set x=-980+I2R(ModuloInteger(i,2))*750
set y=430-I2R(i/2)*260
call STWidget(p,STRoleRaw[i],14,i,x,y)
set i=i+1
endloop
call STButton(p,13,800,-650)
elseif GGVScreen[p]==2 then
loop
exitwhen i>=GGMHeroCount
if GGMHeroRole[i]==GGVRole[p] then
if ordinal>=GGVPage[p]*6 and ordinal<GGVPage[p]*6+6 then
set first=ModuloInteger(ordinal,6)
set x=-980+I2R(ModuloInteger(first,2))*750
set y=400-I2R(first/2)*290
call STWidget(p,STHeroRaw[i],17,i,x,y)
endif
set ordinal=ordinal+1
endif
set i=i+1
endloop
if GGVPage[p]>0 then
call STButton(p,15,-980,-650)
endif
if ordinal>(GGVPage[p]+1)*6 then
call STButton(p,16,-200,-650)
endif
call STButton(p,1,800,-650)
elseif GGVScreen[p]==3 then
set first=GGMHeroSkillStart[h]+GGVPage[p]*4
loop
exitwhen i==4 or first+i>=GGMHeroSkillStart[h]+GGMHeroSkillCount[h]
set x=-1000+I2R(ModuloInteger(i,2))*560
set y=-120-I2R(i/2)*210
call STWidget(p,STSkillRaw[first+i],18,first+i,x,y)
set i=i+1
endloop
call STButton(p,1,-980,-650)
if GGVPage[p]>0 then
call STButton(p,19,800,-350)
endif
if GGMHeroSkillCount[h]>(GGVPage[p]+1)*4 then
call STButton(p,20,800,-80)
endif
if GGVPhase==0 then
call STButton(p,22,-180,-650)
else
call STButton(p,6,-180,-650)
endif
elseif GGVScreen[p]==4 then
call STButton(p,27,-980,-650)
if GGVTextPage[p]>0 then
call STButton(p,23,800,350)
endif
if GGVTextPage[p]+1<GGMSkillTextCount[GGVSkill[p]] then
call STButton(p,24,800,80)
endif
if GGVPhase==0 then
call STButton(p,32,800,-350)
call STButton(p,22,-180,-650)
endif
elseif GGVScreen[p]==5 then
if p==GGVHost() and GGVPhase==0 then
call STButton(p,2,800,400)
call STButton(p,3,800,120)
call STButton(p,28,800,-160)
call STButton(p,5,-950,-300)
endif
if GGVMode!=3 and GGVPhase==0 then
call STButton(p,4,-950,-40)
endif
call STButton(p,13,-950,-650)
call STButton(p,31,800,-650)
elseif GGVScreen[p]==6 then
if GGVPhase==0 then
call STButton(p,10,800,350)
call STButton(p,30,800,70)
if not GGVReady[p] then
call STButton(p,11,800,-210)
elseif p==GGVHost() then
call STButton(p,12,800,-210)
endif
else
call STButton(p,6,800,-210)
endif
call STButton(p,13,-950,-650)
endif
call GGVPanel(p)
call STInfo(p)
call GGVCamera(p)
set GGVDirty[p]=false
endfunction

function STSelected takes nothing returns nothing
local integer p=GetPlayerId(GetTriggerPlayer())
local integer i=0
if not GGVActive(p) or not GGVOpenState[p] then
return
endif
loop
exitwhen i>=STWidgetCount[p]
if STWidgets[p*16+i]==GetTriggerUnit() and STWidgetAction[p*16+i]!=0 then
set GGVPendingAction[p]=STWidgetAction[p*16+i]
set GGVPendingValue[p]=STWidgetValue[p*16+i]
set GGVPendingRevision[p]=GGVRevision[p]
if GetLocalPlayer()==Player(p) then
call ClearSelection()
endif
exitwhen true
endif
set i=i+1
endloop
endfunction

function STInit takes nothing returns nothing
local trigger selected=CreateTrigger()
local integer p=0
local integer i=0
// @@ST_DATA@@
loop
exitwhen p==10
call TriggerRegisterPlayerUnitEvent(selected,Player(p),EVENT_PLAYER_UNIT_SELECTED,null)
set i=0
loop
exitwhen i==4
set STText[p*4+i]=CreateTextTag()
call SetTextTagPermanent(STText[p*4+i],true)
call SetTextTagColor(STText[p*4+i],241,235,213,255)
call SetTextTagVisibility(STText[p*4+i],false)
set i=i+1
endloop
set p=p+1
endloop
call TriggerAddAction(selected,function STSelected)
set selected=null
endfunction

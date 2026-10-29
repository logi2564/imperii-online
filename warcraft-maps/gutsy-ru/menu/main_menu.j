// GGG_MENU_GLOBALS_BEGIN
dialog array GGMDialog
button array GGMButton
integer array GGMAction
integer array GGMValue
integer array GGMButtons
integer array GGMScreen
integer array GGMRole
integer array GGMPage
integer array GGMListPage
integer array GGMHero
integer array GGMSkill
integer array GGMTextPage
integer array GGMMode
integer array GGMSkipPopup
boolean GGMStarted=false
boolean GGMLaunching=false
integer GGMGoalPending=0
integer GGMHeroCount=0
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
// GGG_MENU_GLOBALS_END

function GGMNotice takes integer p,string text returns nothing
call DisplayTimedTextToPlayer(Player(p),0,0,8,text)
endfunction

function GGMHost takes nothing returns integer
local integer p=0
loop
exitwhen p>=10
if GetPlayerController(Player(p))==MAP_CONTROL_USER and GetPlayerSlotState(Player(p))==PLAYER_SLOT_STATE_PLAYING then
return p
endif
set p=p+1
endloop
return -1
endfunction

function GGMAllPlayers takes nothing returns boolean
local integer p=0
loop
exitwhen p>=10
if GetPlayerController(Player(p))!=MAP_CONTROL_USER or GetPlayerSlotState(Player(p))!=PLAYER_SLOT_STATE_PLAYING then
return false
endif
set p=p+1
endloop
return true
endfunction

function GGMTitle takes integer p,string title returns nothing
call DialogClear(GGMDialog[p])
set GGMButtons[p]=0
call DialogSetMessage(GGMDialog[p],title)
endfunction

function GGMAdd takes integer p,string label,integer action,integer value returns nothing
local integer slot=p*12+GGMButtons[p]
set GGMButton[slot]=DialogAddButton(GGMDialog[p],label,0)
set GGMAction[slot]=action
set GGMValue[slot]=value
set GGMButtons[p]=GGMButtons[p]+1
endfunction

function GGMAvailable takes integer p,integer h returns boolean
return h>=0 and h<GGMHeroCount and GetPlayerTechMaxAllowed(Player(p),GGMHeroRaw[h])!=0
endfunction

function GGMModeName takes integer mode returns string
if mode==1 then
return "Арена"
elseif mode==2 then
return "Эпицентр"
endif
return "Драфт: запреты и выбор"
endfunction

function GGMDraw takes integer p returns nothing
local integer i=0
local integer first=0
local integer count=0
local integer h=GGMHero[p]
local integer s=GGMSkill[p]
local integer page=GGMTextPage[p]
local string label=""
if GGMScreen[p]==0 then
call GGMTitle(p,"GGG — главное меню\nНастрой игру или изучи героев до старта.")
if p==GGMHost() and udg_System_Gamemode==10 and not GGMLaunching then
call GGMAdd(p,"Настроить и начать матч",1,0)
endif
call GGMAdd(p,"Герои и навыки",2,0)
call GGMAdd(p,"Как играть",11,0)
call GGMAdd(p,"Личные настройки",12,0)
call GGMAdd(p,"Закрыть",0,0)
elseif GGMScreen[p]==1 then
call GGMTitle(p,"Режим матча\nАрена: убийства, монстры и захват баз.\nЭпицентр: раунды до победы команды.\nДрафт: запреты и выбор для полного лобби.")
call GGMAdd(p,"Арена",3,1)
call GGMAdd(p,"Эпицентр",3,2)
call GGMAdd(p,"Драфт (10 игроков)",3,3)
call GGMAdd(p,"Назад",10,0)
elseif GGMScreen[p]==2 then
call GGMTitle(p,GGMModeName(GGMMode[p])+"\nВыбери цель. Нажатие запустит подготовку матча.")
if GGMMode[p]==2 then
call GGMAdd(p,"До 5 побед",4,5)
call GGMAdd(p,"До 7 побед",4,7)
call GGMAdd(p,"До 9 побед",4,9)
call GGMAdd(p,"До 12 побед",4,12)
else
call GGMAdd(p,"До 10 очков — короткая",4,10)
call GGMAdd(p,"До 25 очков",4,25)
call GGMAdd(p,"До 50 очков",4,50)
call GGMAdd(p,"До 75 очков — длинная",4,75)
endif
call GGMAdd(p,"Назад к режимам",1,0)
elseif GGMScreen[p]==3 then
call GGMTitle(p,"Каталог героев\nВыбери роль. Просмотр ничего не покупает.")
loop
exitwhen i>=8
call GGMAdd(p,GGMRoleName[i],5,i)
set i=i+1
endloop
call GGMAdd(p,"Главное меню",10,0)
call GGMAdd(p,"Закрыть",0,0)
elseif GGMScreen[p]==4 then
call GGMTitle(p,GGMRoleName[GGMRole[p]]+" — страница "+I2S(GGMPage[p]+1)+"\nСначала описание; выбор подтверждается отдельно.")
loop
exitwhen i>=GGMHeroCount
if GGMHeroRole[i]==GGMRole[p] then
if count>=GGMPage[p]*6 and count<GGMPage[p]*6+6 then
set label=GGMHeroName[i]
if not GGMAvailable(p,i) then
set label=label+" [недоступен]"
endif
call GGMAdd(p,label,6,i)
endif
set count=count+1
endif
set i=i+1
endloop
if GGMPage[p]>0 then
call GGMAdd(p,"< Предыдущие",7,-1)
endif
if count>(GGMPage[p]+1)*6 then
call GGMAdd(p,"Следующие >",7,1)
endif
call GGMAdd(p,"К ролям",2,0)
call GGMAdd(p,"Закрыть",0,0)
elseif GGMScreen[p]==5 then
call GGMTitle(p,GGMHeroName[h]+"\n"+GGMHeroAbout[GGMHeroAboutStart[h]+page])
set first=GGMHeroSkillStart[h]+GGMPage[p]*4
set i=first
loop
exitwhen i>=GGMHeroSkillStart[h]+GGMHeroSkillCount[h] or i>=first+4
call GGMAdd(p,GGMSkillName[i],8,i)
set i=i+1
endloop
if GGMPage[p]>0 then
call GGMAdd(p,"< Другие навыки",7,-1)
endif
if GGMHeroSkillCount[h]>(GGMPage[p]+1)*4 then
call GGMAdd(p,"Ещё навыки >",7,1)
endif
if GGMHeroAboutCount[h]>1 then
call GGMAdd(p,"Ещё о герое",13,0)
endif
call GGMAdd(p,"Выбрать / подтвердить",9,h)
call GGMAdd(p,"Показать модель на карте",14,h)
call GGMAdd(p,"Назад к героям",15,0)
call GGMAdd(p,"Закрыть",0,0)
elseif GGMScreen[p]==6 then
call GGMTitle(p,GGMSkillName[s]+"\n"+GGMSkillText[GGMSkillTextStart[s]+page]+"\n"+I2S(page+1)+" / "+I2S(GGMSkillTextCount[s]))
if page>0 then
call GGMAdd(p,"< Предыдущая часть",16,-1)
endif
if page+1<GGMSkillTextCount[s] then
call GGMAdd(p,"Следующая часть >",16,1)
endif
call GGMAdd(p,"К навыкам героя",17,0)
call GGMAdd(p,"Закрыть",0,0)
elseif GGMScreen[p]==7 then
call GGMTitle(p,"Как играть\nВыбери героя. Затем коснись круглого устройства призыва, чтобы выйти из комнаты ожидания.\nУбивай монстров, усиливай героя и выполняй цель режима.\nКоманда -menu возвращает это меню; -skills показывает навыки твоего героя.\nКаталог до старта не ограничен временем.")
call GGMAdd(p,"Назад",10,0)
elseif GGMScreen[p]==8 then
call GGMTitle(p,"Личные настройки\nКамера меняется только у тебя. Подсказки меню не видны другим игрокам.")
call GGMAdd(p,"Камера: ближе",18,2600)
call GGMAdd(p,"Камера: обычная",18,3800)
call GGMAdd(p,"Камера: дальше",18,5000)
if IsPlayerInForce(Player(p),udg_DoummalGroup) then
call GGMAdd(p,"Периодическая справка: ВКЛ",19,0)
else
call GGMAdd(p,"Периодическая справка: ВЫКЛ",19,1)
endif
call GGMAdd(p,"Назад",10,0)
endif
call DialogDisplay(Player(p),GGMDialog[p],true)
endfunction

function GGMLaunch takes integer p,integer goal returns nothing
local integer mode=GGMMode[p]
local integer i=0
if p!=GGMHost() or GGMLaunching or udg_System_Gamemode!=10 then
call GGMNotice(p,"Настройка матча уже завершена или доступна другому ведущему.")
return
endif
if mode==3 and not GGMAllPlayers() then
call GGMNotice(p,"Исходный драфт рассчитан на 10 игроков. Для игры с другом выбери Арену или Эпицентр.")
return
endif
if (mode==2 and (goal<5 or goal>12)) or (mode!=2 and (goal<10 or goal>99)) then
return
endif
if not IsTriggerEnabled(gg_trg_Mode_Team) then
call GGMNotice(p,"Подготовка карты ещё идёт. Открой -menu через несколько секунд.")
return
endif
set GGMLaunching=true
if mode==1 then
call TriggerExecute(gg_trg_Mode_Team)
elseif mode==2 then
call TriggerExecute(gg_trg_Mode_Epiccenter)
else
call TriggerExecute(gg_trg_Mode_Banpick)
endif
set GGMGoalPending=goal
if mode==1 then
call TriggerExecute(gg_trg_kill_set_Team)
elseif mode==2 then
call TriggerExecute(gg_trg_kill_set_Epiccenter)
else
call TriggerExecute(gg_trg_kill_set_Banpick)
endif
set GGMGoalPending=0
loop
exitwhen i>=10
if GetPlayerController(Player(i))==MAP_CONTROL_USER and GetPlayerSlotState(Player(i))==PLAYER_SLOT_STATE_PLAYING then
call DialogDisplay(Player(i),GGMDialog[i],false)
set GGMScreen[i]=3
call GGMDraw(i)
endif
set i=i+1
endloop
endfunction

function GGMModel takes integer p,integer h returns nothing
local group g=CreateGroup()
local unit u=null
local unit target=null
call GroupEnumUnitsInRect(g,gg_rct_Loc_SelUnit,null)
loop
set u=FirstOfGroup(g)
exitwhen u==null
call GroupRemoveUnit(g,u)
if GetUnitTypeId(u)==GGMHeroRaw[h] then
set target=u
exitwhen true
endif
endloop
call DestroyGroup(g)
if target==null and GetUnitTypeId(udg_Player[p+1])==GGMHeroRaw[h] then
set target=udg_Player[p+1]
endif
if target!=null then
call DialogDisplay(Player(p),GGMDialog[p],false)
call PanCameraToTimedForPlayer(Player(p),GetUnitX(target),GetUnitY(target),0.3)
if not udg_Banpickmode then
set GGMSkipPopup[p]=GGMHeroRaw[h]
call SelectUnitForPlayerSingle(target,Player(p))
endif
else
call GGMNotice(p,"Модель доступна на площадке выбора после настройки матча. Описания можно читать уже сейчас.")
call GGMDraw(p)
endif
set target=null
set u=null
set g=null
endfunction

function GGMConfirm takes integer p,integer h returns nothing
local unit shop=udg_Starrrrr[GGMHeroTavern[h]]
local boolean ordered=false
if udg_Player[p+1]!=null and not udg_TESTMODE then
call GGMNotice(p,"Герой уже выбран. Каталог доступен для просмотра.")
call GGMDraw(p)
elseif udg_Banpickended then
call GGMNotice(p,"После драфта возьми героя на базе команды двойным выбором. Покажу его на карте.")
call GGMModel(p,h)
elseif shop==null or GetUnitTypeId(shop)==0 then
call GGMNotice(p,"Сначала ведущий выбирает режим и цель матча. Сейчас доступен просмотр героев.")
call GGMDraw(p)
elseif not GGMAvailable(p,h) then
call GGMNotice(p,"Герой уже занят, запрещён или ещё закрыт правилами карты.")
call GGMDraw(p)
elseif udg_Banpickmode and not udg_Banpickended and (udg_PickBanUnit==null or GetOwningPlayer(udg_PickBanUnit)!=Player(p)) then
call GGMNotice(p,"Сейчас ход другого игрока драфта. Навыки можно изучать без выбора.")
call GGMDraw(p)
else
set ordered=IssueNeutralImmediateOrderById(Player(p),shop,GGMHeroRaw[h])
if not ordered then
call GGMNotice(p,"Выбор пока недоступен. Проверь время выбора и наличие героя в таверне.")
call GGMDraw(p)
endif
endif
set shop=null
endfunction

function GGMClick takes nothing returns nothing
local integer p=GetPlayerId(GetTriggerPlayer())
local integer i=0
local integer slot=0
local integer action=-1
local integer value=0
loop
exitwhen i>=GGMButtons[p]
set slot=p*12+i
if GetClickedButton()==GGMButton[slot] then
set action=GGMAction[slot]
set value=GGMValue[slot]
exitwhen true
endif
set i=i+1
endloop
if action<0 or action==0 then
return
elseif action==4 then
call GGMLaunch(p,value)
return
elseif action==9 then
call GGMConfirm(p,value)
return
elseif action==14 then
call GGMModel(p,value)
return
elseif action==1 then
set GGMScreen[p]=1
elseif action==2 then
set GGMScreen[p]=3
elseif action==3 then
set GGMMode[p]=value
set GGMScreen[p]=2
elseif action==5 then
set GGMRole[p]=value
set GGMPage[p]=0
set GGMScreen[p]=4
elseif action==6 then
set GGMHero[p]=value
set GGMListPage[p]=GGMPage[p]
set GGMPage[p]=0
set GGMTextPage[p]=0
set GGMScreen[p]=5
elseif action==7 then
set GGMPage[p]=GGMPage[p]+value
elseif action==8 then
set GGMSkill[p]=value
set GGMTextPage[p]=0
set GGMScreen[p]=6
elseif action==10 then
set GGMScreen[p]=0
elseif action==11 then
set GGMScreen[p]=7
elseif action==12 then
set GGMScreen[p]=8
elseif action==13 then
set GGMTextPage[p]=ModuloInteger(GGMTextPage[p]+1,GGMHeroAboutCount[GGMHero[p]])
elseif action==15 then
set GGMScreen[p]=4
set GGMPage[p]=GGMListPage[p]
elseif action==16 then
set GGMTextPage[p]=GGMTextPage[p]+value
elseif action==17 then
set GGMScreen[p]=5
set GGMTextPage[p]=0
elseif action==18 then
set udg_Camlock_Distance[p+1]=I2R(value)
if GetLocalPlayer()==Player(p) then
call SetCameraField(CAMERA_FIELD_TARGET_DISTANCE,I2R(value),0.3)
endif
elseif action==19 then
if value==0 then
call ForceRemovePlayer(udg_DoummalGroup,Player(p))
else
call ForceAddPlayer(udg_DoummalGroup,Player(p))
endif
endif
call GGMDraw(p)
endfunction

function GGMChat takes nothing returns nothing
local integer p=GetPlayerId(GetTriggerPlayer())
local integer h=0
if GetEventPlayerChatString()=="-skills" then
loop
exitwhen h>=GGMHeroCount or GGMHeroRaw[h]==GetUnitTypeId(udg_Player[p+1])
set h=h+1
endloop
if h<GGMHeroCount then
set GGMHero[p]=h
set GGMPage[p]=0
set GGMTextPage[p]=0
set GGMScreen[p]=5
else
set GGMScreen[p]=3
endif
else
set GGMScreen[p]=0
endif
call GGMDraw(p)
endfunction

function GGMSelected takes nothing returns nothing
local integer p=GetPlayerId(GetTriggerPlayer())
local integer raw=GetUnitTypeId(GetTriggerUnit())
local integer h=0
if GGMSkipPopup[p]==raw then
set GGMSkipPopup[p]=0
return
endif
if udg_Player[p+1]!=null or udg_Banpickmode or not RectContainsUnit(gg_rct_Loc_SelUnit,GetTriggerUnit()) then
return
endif
loop
exitwhen h>=GGMHeroCount or GGMHeroRaw[h]==raw
set h=h+1
endloop
if h<GGMHeroCount then
set GGMHero[p]=h
set GGMPage[p]=0
set GGMTextPage[p]=0
set GGMScreen[p]=5
call GGMDraw(p)
endif
endfunction

function GGMStart takes nothing returns nothing
local integer p=0
if GGMStarted then
return
endif
set GGMStarted=true
loop
exitwhen p>=10
if GetPlayerController(Player(p))==MAP_CONTROL_USER and GetPlayerSlotState(Player(p))==PLAYER_SLOT_STATE_PLAYING then
set GGMScreen[p]=0
call GGMDraw(p)
endif
set p=p+1
endloop
endfunction

function GGMInit takes nothing returns nothing
local trigger clicks=CreateTrigger()
local trigger chats=CreateTrigger()
local trigger selected=CreateTrigger()
local integer p=0
// GGG_DATA_INIT
loop
exitwhen p>=10
set GGMDialog[p]=DialogCreate()
call TriggerRegisterDialogEvent(clicks,GGMDialog[p])
call TriggerRegisterPlayerChatEvent(chats,Player(p),"-menu",true)
call TriggerRegisterPlayerChatEvent(chats,Player(p),"-skills",true)
call TriggerRegisterPlayerUnitEvent(selected,Player(p),EVENT_PLAYER_UNIT_SELECTED,null)
set p=p+1
endloop
call TriggerAddAction(clicks,function GGMClick)
call TriggerAddAction(chats,function GGMChat)
call TriggerAddAction(selected,function GGMSelected)
set clicks=null
set chats=null
set selected=null
endfunction

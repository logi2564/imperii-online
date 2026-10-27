-- Controlled native mocks. These test state transitions, not graphics, engine
-- pathfinding, actual game-cache behavior or real multiplayer synchronization.
function __jarray(default) return setmetatable({}, {__index=function() return default end}) end
function FourCC(s) local v=0 for n=1,4 do v=v*256+s:byte(n) end return v end
function Player(n) return n end
WORLD={players={},units={},events={},messages={},files={},ai={},drops={},time=0,localPlayer=0,hashIgnoresCase=true}
for n=0,15 do WORLD.players[n]={controller='computer',state='playing',gold=0,wood=0,hp=1,xp=1,alliances={}} end
for _,n in ipairs({0,1,2,3}) do WORLD.players[n].controller='user' end
MAP_CONTROL_USER='user';PLAYER_SLOT_STATE_PLAYING='playing'
PLAYER_STATE_RESOURCE_GOLD='gold';PLAYER_STATE_RESOURCE_LUMBER='wood';PLAYER_STATE_RESOURCE_FOOD_CAP='food'
MAP_DIFFICULTY_EASY=0;MAP_DIFFICULTY_NORMAL=1;MAP_DIFFICULTY_HARD=2
UNIT_STATE_MAX_LIFE='maxhp';UNIT_STATE_MANA='mana';UNIT_STATE_MAX_MANA='maxmana'
UNIT_TYPE_HERO='hero';UNIT_TYPE_STRUCTURE='structure';UNIT_TYPE_SUMMONED='summoned'
ALLIANCE_PASSIVE='passive';ALLIANCE_SHARED_VISION='vision';ALLIANCE_SHARED_CONTROL='control';ALLIANCE_SHARED_ADVANCED_CONTROL='advanced'
ALLIANCE_SHARED_XP='sharexp';ALLIANCE_SHARED_SPELLS='sharespells'
EVENT_PLAYER_UNIT_SPELL_EFFECT='spell'
ATTACK_TYPE_MAGIC='magic';DAMAGE_TYPE_FIRE='fire';WEAPON_TYPE_WHOKNOWS='unknown'
function GetPlayerId(p) return p end
function GetPlayerController(p) return WORLD.players[p].controller end
function GetPlayerSlotState(p) return WORLD.players[p].state end
function GetPlayerState(p,s) return WORLD.players[p][s] or 0 end
function SetPlayerState(p,s,v) WORLD.players[p][s]=v end
function GetPlayerHandicap(p) return WORLD.players[p].hp end
function SetPlayerHandicap(p,v) WORLD.players[p].hp=v end
function SetPlayerHandicapXP(p,v) WORLD.players[p].xp=v end
function SetGameDifficulty(v) WORLD.difficulty=v end
function StringLength(s) return #s end
function SubString(s,a,b) return s:sub(a+1,b) end
function StringCase(s,upper) return upper and s:upper() or s:lower() end
function StringHash(s) if WORLD.hashIgnoresCase then s=s:upper() end local v=1 for n=1,#s do v=(v*31+s:byte(n))%2147483647 end return v end
function ModuloInteger(a,b) return a%b end
function I2S(v) return tostring(math.floor(v)) end
function S2I(v) return math.floor(tonumber(v) or 0) end
function GetRandomInt(a,b) return 177 end
function InitHashtable() return {} end
function SaveInteger(t,p,c,v) t[p]=t[p] or {};t[p][c]=v end
function LoadInteger(t,p,c) return t[p] and t[p][c] or 0 end
function SaveBoolean(t,p,c,v) t[p]=t[p] or {};t[p][c]=v end
function LoadBoolean(t,p,c) return t[p] and t[p][c] or false end
function GetHandleId(h) return h.handle end
function InitGameCache(s) return {} end
function FlushGameCache(t) for k in pairs(t) do t[k]=nil end end
function StoreInteger(t,m,k,v) t[m]=t[m] or {};t[m][k]=v end
function StoreBoolean(t,m,k,v) t[m]=t[m] or {};t[m][k]=v end
function CreateTrigger() return {actions={}} end
function TriggerAddAction(t,f) table.insert(t.actions,f) end
function TriggerRegisterPlayerChatEvent(...) end
function TriggerRegisterPlayerUnitEvent(...) end
function TriggerRegisterPlayerEventEndCinematic(...) end
function TriggerRegisterDialogEvent(...) end
function TriggerRegisterTimerEventSingle(...) end
function IsTriggerEnabled(t) return t and t.enabled or false end
function DisableTrigger(t) if t then t.enabled=false end end
function EnableTrigger(t) if t then t.enabled=true end end
function CreateTimer() return {} end
function TimerStart(t,d,repeated,action) t.duration=d;t.action=action;t.started=WORLD.time;WORLD.lastTimer=t end
function TimerGetElapsed(t) return WORLD.time-(t.started or 0) end
function PauseTimer(t) t.paused=true end
function PauseAllUnitsBJ(v) WORLD.paused=v end
function CreateForce() return {} end
function ForceAddPlayer(f,p) f[p]=true end
function IsPlayerInForce(p,f) return f[p] or false end
function DisplayTimedTextToForce(f,d,s) table.insert(WORLD.messages,s) end
function DisplayTimedTextToPlayer(p,x,y,d,s) table.insert(WORLD.messages,s) end
function CreateQuest() return {} end
function QuestSetTitle(q,s) q.title=s end
function QuestSetDescription(q,s) q.description=s end
function QuestSetRequired(q,v) q.required=v end
function QuestSetDiscovered(q,v) q.discovered=v end
function QuestSetIconPath(q,s) q.icon=s end
function DialogCreate() return {buttons={}} end
function DialogSetMessage(d,s) d.message=s end
function DialogAddButton(d,s,key) local b={text=s};table.insert(d.buttons,b);return b end
function DialogDisplay(p,d,v) d.visible=v end
function GetClickedButton() return WORLD.events.button end
function GetTriggerPlayer() return WORLD.events.player end
function GetEventPlayerChatString() return WORLD.events.chat or '' end
function GetTriggerUnit() return WORLD.events.unit end
function GetSpellAbilityId() return WORLD.events.spell end
function GetSpellTargetX() return WORLD.events.x end
function GetSpellTargetY() return WORLD.events.y end
function ExecuteFunc(name) return _G[name]() end
function CreateUnit(p,id,x,y,f)
 local u={owner=p,id=id,x=x,y=y,facing=f,hp=1000,maxhp=1000,mana=500,maxmana=500,str=14,agi=12,int=16,xp=0,level=1,points=1,abilities={},items={},hero=(id==FourCC('Orex') or id==FourCC('Orkn') or id==FourCC('Nsjs') or id==FourCC('Ocb2')),handle=#WORLD.units+1}
 table.insert(WORLD.units,u);return u
end
function GetHeroXP(u) return u.xp end
function GetHeroLevel(u) return u.level end
function SetHeroXP(u,xp,fx) local old=u.level;u.xp=xp;u.level=1 while u.level<20 and 50*(u.level+1)*(u.level+2)-100<=xp do u.level=u.level+1 end u.points=math.max(0,u.points+u.level-old) end
function SetHeroLevel(u,n,fx) u.level=n;u.xp=n==1 and 0 or 50*n*(n+1)-100;u.points=n end
function GetHeroStr(u,b) return u.str end
function GetHeroAgi(u,b) return u.agi end
function GetHeroInt(u,b) return u.int end
function SetHeroStr(u,v,b) u.str=v end
function SetHeroAgi(u,v,b) u.agi=v end
function SetHeroInt(u,v,b) u.int=v end
function GetHeroSkillPoints(u) return u.points end
function UnitModifySkillPoints(u,n) u.points=u.points+n;return true end
function SelectHeroSkill(u,id) u.abilities[id]=(u.abilities[id] or 0)+1;u.points=math.max(0,u.points-1) end
function GetUnitAbilityLevel(u,id) return u.abilities[id] or 0 end
function UnitAddAbility(u,id) if u.abilities[id] then return false end u.abilities[id]=1;return true end
function UnitRemoveAbility(u,id) u.abilities[id]=nil;return true end
function SetUnitAbilityLevel(u,id,n) u.abilities[id]=n;return n end
function SuspendHeroXP(u,v) u.suspended=v end
function UnitItemInSlot(u,n) return u.items[n] end
function GetItemTypeId(it) return it and not it.removed and it.id or 0 end
function GetItemCharges(it) return it and it.charges or 0 end
function RemoveItem(it) if it then it.removed=true;if it.hero then it.hero.items[it.slot]=nil end end end
function UnitAddItemToSlotById(u,id,n) if u.items[n] then return false end local it={id=id,charges=0,hero=u,slot=n};u.items[n]=it;return true end
function UnitAddItem(u,it) for n=0,5 do if not u.items[n] then u.items[n]=it;it.hero=u;it.slot=n;return true end end return false end
function CreateItem(id,x,y) local it={id=id,charges=0,x=x,y=y};table.insert(WORLD.drops,it);return it end
function SetItemCharges(it,v) if it then it.charges=v end end
function UnitRemoveItem(u,it) if it then u.items[it.slot]=nil;it.hero=nil end end
function SetItemPosition(it,x,y) if it then it.x=x;it.y=y end end
function RemoveUnit(u) if u then u.removed=true end end
function GetOwningPlayer(u) return u.owner end
function GetUnitTypeId(u) return u and not u.removed and u.id or 0 end
function SetUnitOwner(u,p,c) u.owner=p end
function GetWidgetLife(u) return u and u.hp or 0 end
function SetWidgetLife(u,v) u.hp=math.min(u.maxhp,v) end
function GetUnitState(u,s) return u[s] or 0 end
function SetUnitState(u,s,v) u[s]=v end
function GetUnitX(u) return u.x end
function GetUnitY(u) return u.y end
function GetUnitFacing(u) return u.facing end
function SetUnitFacing(u,v) u.facing=v end
function SetUnitPositionLoc(u,p) if p then u.x=p.x;u.y=p.y end end
function IsUnitType(u,t) return u[t] or false end
function IsUnitPaused(u) return u.paused or false end
function IsUnitInRange(a,b,r) return (a.x-b.x)^2+(a.y-b.y)^2<=r*r end
function IsPlayerEnemy(p,q) return p~=q and not GetPlayerAlliance(p,q,ALLIANCE_PASSIVE) end
function IsUnitEnemy(u,p) return IsPlayerEnemy(u.owner,p) end
function GetPlayerAlliance(p,q,flag) local a=WORLD.players[p].alliances[q];return a and a[flag] or false end
function SetPlayerAlliance(p,q,flag,v) WORLD.players[p].alliances[q]=WORLD.players[p].alliances[q] or {};WORLD.players[p].alliances[q][flag]=v end
function UnitApplyTimedLife(u,b,d) u.duration=d;u.summoned=true end
function UnitAddType(u,t) u[t]=true;return true end
function GetItemOfTypeFromUnitBJ(u,id) for n=0,5 do if u.items[n] and u.items[n].id==id then return u.items[n] end end return nil end
function UnitRemoveBuffs(u,a,b) u.cleansed=true end
function UnitDamageTarget(c,u,amount,...) u.hp=u.hp-amount;return true end
function AddSpecialEffect(...) return {} end
function AddSpecialEffectTarget(...) return {} end
function DestroyEffect(e) end
function ReviveHero(u,x,y,b) u.hp=u.maxhp;u.x=x;u.y=y;return true end
function GetPlayerStartLocation(p) return p end
function GetStartLocationX(p) return 100 end
function GetStartLocationY(p) return 200 end
function IssueImmediateOrder(u,s) return true end
function PanCameraToTimedForPlayer(...) end
function SelectUnitForPlayerSingle(...) end
function CinematicModeBJ(...) end
function CinematicFadeBJ(...) end
bj_CINEFADETYPE_FADEIN=1
function CameraSetupApplyForPlayer(...) end
function StartCampaignAI(p,s) table.insert(WORLD.ai,{player=p,script=s}) end
function CreateGroup() return {} end
function GroupAddUnit(g,u) table.insert(g,u) end
function GroupEnumUnitsOfPlayer(g,p,filter) for n=#g,1,-1 do g[n]=nil end for _,u in ipairs(WORLD.units) do if u.owner==p and not u.removed then table.insert(g,u) end end end
function GroupEnumUnitsInRange(g,x,y,r,filter) for n=#g,1,-1 do g[n]=nil end for _,u in ipairs(WORLD.units) do if not u.removed and (u.x-x)^2+(u.y-y)^2<=r*r then table.insert(g,u) end end end
function FirstOfGroup(g) return g[1] end
function GroupRemoveUnit(g,u) for n,v in ipairs(g) do if v==u then table.remove(g,n);return end end end
function GetLocalPlayer() return WORLD.localPlayer end
function PreloadGenClear() WORLD.preloads={} end
function PreloadGenStart() end
function Preload(s) table.insert(WORLD.preloads,s) end
function PreloadGenEnd(path) WORLD.files[path]=table.concat(WORLD.preloads,'\n') end
-- Classic skill/balance behavior boundaries (effects/pathfinding still mocked).
UNIT_TYPE_FLYING='flying';EVENT_UNIT_DAMAGED='damaged';PATHING_TYPE_WALKABILITY='walk'
ATTACK_TYPE_CHAOS='chaos';DAMAGE_TYPE_UNIVERSAL='universal';DAMAGE_TYPE_MAGIC='magic'
bj_DEGTORAD=math.pi/180
function R2I(v) return math.modf(v) end
function R2SW(v,w,p) return string.format('%.'..p..'f',v) end
function RMinBJ(a,b) return math.min(a,b) end
function RMaxBJ(a,b) return math.max(a,b) end
function Cos(v) return math.cos(v) end
function Sin(v) return math.sin(v) end
function Atan2(y,x) return math.atan(y,x) end
function SquareRoot(v) return math.sqrt(v) end
function SaveReal(t,p,c,v) SaveInteger(t,p,c,v) end
function LoadReal(t,p,c) return LoadInteger(t,p,c) end
function GetSpellTargetUnit() return WORLD.events.target end
function IsUnitInRangeXY(u,x,y,r) return (u.x-x)^2+(u.y-y)^2<=r*r end
function SetUnitX(u,x) u.x=x end
function SetUnitY(u,y) u.y=y end
function SetUnitPosition(u,x,y) u.x=x;u.y=y end
function IsTerrainPathable(x,y,t) return WORLD.wallX and x>=WORLD.wallX or false end
function PauseUnit(u,v) u.paused=v end
function IssueTargetOrder(u,s,t) u.order=s;u.target=t;return true end
function IssuePointOrder(u,s,x,y) u.order=s;return true end
function DestroyGroup(g) g.destroyed=true end
function GroupClear(g) for n=#g,1,-1 do g[n]=nil end end
function IsUnitInGroup(u,g) for _,v in ipairs(g) do if v==u then return true end end return false end
function TriggerRegisterUnitEvent(t,u,e) u.damageTrigger=t end
function GetEventDamage() return WORLD.events.damage or 0 end
function GetEventDamageSource() return WORLD.events.source end
local oldAdd,oldRemove=UnitAddAbility,UnitRemoveAbility
local function hpBonus(id)
 local n=id-FourCC('RH00')
 -- RH00..RH09, RH10..RH15 use ASCII decimal, not linear rawcodes.
 for bit=0,15 do if id==FourCC(string.format('RH%02d',bit)) then return 25*2^bit end end
 return 0
end
function UnitAddAbility(u,id) local ok=oldAdd(u,id);if ok then u.maxhp=u.maxhp+hpBonus(id) end return ok end
function UnitRemoveAbility(u,id) if u.abilities[id] then u.maxhp=u.maxhp-hpBonus(id) end return oldRemove(u,id) end
function UnitDamageTarget(c,u,amount,...)
 local old=WORLD.events
 WORLD.events={unit=u,source=c,damage=amount}
 if u.damageTrigger then for _,f in ipairs(u.damageTrigger.actions) do f() end end
 u.hp=u.hp-amount
 WORLD.events=old
 return true
end
EVENT_PLAYER_UNIT_DEATH='death'
function GetUnitLevel(u) return u.level end
function GetKillingUnit() return WORLD.events.killer end
function IsUnitIllusion(u) return u.illusion or false end
function DialogClear(d) d.buttons={} end
function GetClickedDialog() return WORLD.events.panel end
function CreateTextTag() WORLD.tags=WORLD.tags or {};local t={};table.insert(WORLD.tags,t);return t end
function SetTextTagText(t,s,size) t.text=s end
function SetTextTagPosUnit(t,u,h) t.unit=u end
function SetTextTagColor(...) end
function SetTextTagVelocity(...) end
function SetTextTagPermanent(...) end
function SetTextTagLifespan(...) end
function SetTextTagFadepoint(...) end
function SetTextTagVisibility(t,v) t.visible=v end
function I2R(v) return v end
function ShowUnit(u,v) if u then u.visible=v end end
function SetUnitInvulnerable(u,v) if u then u.invulnerable=v end end
function SetUnitPathing(u,v) if u then u.pathing=v end end
function GetLocationX(p) return p.x end
function GetLocationY(p) return p.y end
function AngleBetweenPoints(a,b) return math.atan(b.y-a.y,b.x-a.x)*180/math.pi end
function GroupAddGroup(source,destination) for _,u in ipairs(source) do if not IsUnitInGroup(u,destination) then table.insert(destination,u) end end end
function GroupAddUnit(g,u) if u and not IsUnitInGroup(u,g) then table.insert(g,u) end end
function CreateNUnitsAtLoc(count,id,p,point,facing)
 local g=CreateGroup()
 for n=1,count do bj_lastCreatedUnit=CreateUnit(p,id,point.x,point.y,facing);GroupAddUnit(g,bj_lastCreatedUnit) end
 bj_lastCreatedGroup=g;return g
end

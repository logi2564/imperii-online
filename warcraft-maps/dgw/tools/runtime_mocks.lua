function __jarray(v) return setmetatable({},{__index=function() return v end}) end
function FourCC(s) local n=0 for i=1,4 do n=n*256+string.byte(s,i) end return n end
function Player(p) return p end
PLAYER_NEUTRAL_AGGRESSIVE=12; PLAYER_NEUTRAL_PASSIVE=15
PLAYER_STATE_RESOURCE_GOLD='gold';PLAYER_STATE_RESOURCE_LUMBER='wood';PLAYER_STATE_FOOD_CAP_CEILING='food'
UNIT_STATE_MANA='mana';UNIT_STATE_MAX_MANA='maxmana';UNIT_STATE_MAX_LIFE='maxhp'
UNIT_TYPE_HERO='hero';UNIT_TYPE_STRUCTURE='structure';UNIT_TYPE_PEON='worker';UNIT_TYPE_MAGIC_IMMUNE='immune'
MAP_CONTROL_USER='user';MAP_CONTROL_COMPUTER='computer';PLAYER_SLOT_STATE_PLAYING='playing'
bj_FORCE_ALL_PLAYERS={}; bj_ALLIANCE_UNALLIED=0
WORLD={units={},players={},victories={},defeats={},defs={},events={},damageCalls=0}
for p=0,15 do WORLD.players[p]={gold=0,wood=0,controller='user',playing=true} end
function InitHashtable() return {} end
function SaveInteger(t,p,c,v) if not t[p] then t[p]={} end t[p][c]=v end
function LoadInteger(t,p,c) return t[p] and t[p][c] or 0 end
function GetPlayerId(p) return p end
function GetPlayerName(p) return 'Player '..p end
function GetPlayerController(p) return WORLD.players[p].controller end
function GetPlayerSlotState(p) return WORLD.players[p].playing and 'playing' or 'empty' end
function GetPlayerState(p,s) return WORLD.players[p][s] or 0 end
function SetPlayerState(p,s,v) WORLD.players[p][s]=v end
function CreateUnit(p,id,x,y,f)
 local d=WORLD.defs[id] or {};local u={owner=p,id=id,x=x,y=y,hp=d.hp or 1000,maxhp=d.hp or 1000,mana=500,maxmana=650,worker=d.worker,structure=d.structure,hero=d.hero,immune=false,abilities=d.abilities or {}}
 table.insert(WORLD.units,u);return u
end
function GetOwningPlayer(u) return u.owner end
function GetUnitTypeId(u) return u and u.id or 0 end
function GetUnitX(u) return u.x end
function GetUnitY(u) return u.y end
function GetWidgetLife(u) return u and u.hp or 0 end
function SetWidgetLife(u,v) u.hp=v end
function GetUnitState(u,s) return u[s] or 0 end
function SetUnitState(u,s,v) u[s]=v end
function SetUnitPosition(u,x,y) u.x=x;u.y=y end
function IsUnitType(u,k) return u[k]==true end
function GetUnitAbilityLevel(u,id) return u.abilities[id] and 1 or 0 end
function IsUnitEnemy(u,p) return u.owner~=p and u.owner~=PLAYER_NEUTRAL_PASSIVE end
function IsUnitAlly(u,p) return u.owner==p end
function SetUnitOwner(u,p,c) u.owner=p end
function GetUnitCurrentOrder(u) return 0 end
function UnitDamageTarget(c,u,damage,...) u.hp=u.hp-damage;WORLD.damageCalls=WORLD.damageCalls+1;return true end
function UnitRemoveBuffs(u,a,b) u.cleansed=true end
function SetUnitUseFood(u,flag) u.food=flag end
function UnitApplyTimedLife(u,b,d) u.duration=d end
function CreateGroup() return {} end
function GroupEnumUnitsOfPlayer(g,p,f) for i=#g,1,-1 do g[i]=nil end for _,u in ipairs(WORLD.units) do if u.owner==p then g[#g+1]=u end end end
function GroupEnumUnitsInRange(g,x,y,r,f) for i=#g,1,-1 do g[i]=nil end for _,u in ipairs(WORLD.units) do if (u.x-x)^2+(u.y-y)^2<=r*r then g[#g+1]=u end end end
function FirstOfGroup(g) return g[1] end
function GroupRemoveUnit(g,u) for i,x in ipairs(g) do if x==u then table.remove(g,i);return end end end
function DestroyGroup(g) end
function DialogCreate() return {buttons={}} end
function DialogClear(d) d.buttons={} end
function DialogAddButton(d,s,h) local b={text=s,dialog=d};table.insert(d.buttons,b);return b end
function DialogDisplay(p,d,flag) if d then d.visible=flag end end
function DialogSetMessage(d,s) d.message=s end
function GetClickedButton() return WORLD.events.button end
function GetTriggerPlayer() return WORLD.events.player end
function GetTriggerUnit() return WORLD.events.unit end
function GetKillingUnit() return WORLD.events.killer end
function GetSpellAbilityId() return WORLD.events.spell end
function GetSpellTargetX() return WORLD.events.x end
function GetSpellTargetY() return WORLD.events.y end
function GetEventPlayerChatString() return WORLD.events.chat or '' end
function GetTrainedUnit() return WORLD.events.trained end
function GetConstructedStructure() return WORLD.events.constructed end
function GetRevivingUnit() return WORLD.events.revived end
function CustomVictoryBJ(p,a,b) table.insert(WORLD.victories,p) end
function CustomDefeatBJ(p,s) table.insert(WORLD.defeats,p) end
function I2S(n) return tostring(n) end
function S2R(n) return tonumber(n) or 0 end
function SubString(s,a,b) return string.sub(s,a+1,b) end
function StringLength(s) return #s end
function IMinBJ(a,b) return math.min(a,b) end
function RMinBJ(a,b) return math.min(a,b) end
function RMaxBJ(a,b) return math.max(a,b) end
function ModuloInteger(a,b) return a%b end
function GetRandomInt(a,b) return a end
function GetRandomReal(a,b) return (a+b)/2 end
function Rect(a,b,c,d) return {} end
function EnumDestructablesInRect(r,f,c) end
function RemoveRect(r) end
function IssueImmediateOrder(u,o) return true end
function IssueImmediateOrderById(u,o) return false end
function IssueTargetOrder(u,o,target) return true end
function IssuePointOrder(u,o,x,y) return true end
function AddSpecialEffect(p,x,y) return {} end
function DestroyEffect(e) end
function SetHeroLevel(u,l,flag) u.level=l end
function SelectHeroSkill(u,s) u.skill=s end
function DisplayTimedTextToPlayer(...) end
function DisplayTimedTextToForce(...) end
function PanCameraToTimedForPlayer(...) end
function SetCameraFieldForPlayer(...) end
function SelectUnitForPlayerSingle(...) end
function SetPlayerTechMaxAllowed(...) end
function SetResourceAmount(...) end
function PingMinimapForPlayer(...) end
function MultiboardGetItem(...) return {} end
function MultiboardSetItemStyle(...) end
function MultiboardSetItemValue(...) end
function MultiboardSetItemWidth(...) end
function MultiboardReleaseItem(...) end

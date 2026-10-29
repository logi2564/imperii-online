-- Atlas-specific native boundaries. Source mission initialization, rendering,
-- pathfinding and actual network transport remain outside this harness.
local seq=100000
local function handle(t) seq=seq+1;t.handle=seq;return t end
for _,name in ipairs({'CreateTrigger','CreateTimer','CreateQuest','DialogCreate','CreateForce','CreateGroup','InitGameCache'}) do
 local original=_G[name];_G[name]=function(...) return handle(original(...)) end
end
function GetHandleId(h) if h==nil then return 0 elseif type(h)=='number' then return 200000+h elseif not h.handle then handle(h) end return h.handle end
for _,kind in ipairs({'Unit','Timer','Trigger','Quest','Item','Effect'}) do
 _G['Save'..kind..'Handle']=function(t,p,c,v) SaveInteger(t,p,c,v) end
 _G['Load'..kind..'Handle']=function(t,p,c) return t[p] and t[p][c] or nil end
end
function GetExpiredTimer() return WORLD.expiredTimer end
function HaveSavedInteger(t,p,c) return t[p] and t[p][c]~=nil or false end
HaveSavedBoolean=HaveSavedInteger
function SaveStr(t,p,c,v) SaveInteger(t,p,c,v) end
function LoadStr(t,p,c) return t[p] and t[p][c] or '' end
function ResumeTimer(t) t.paused=false end
function TimerGetRemaining(t) if t.destroyed then error('Destroyed timer was used') end return t.remaining or t.duration end
function DestroyTimer(t) t.destroyed=true end
function TriggerRegisterTimerExpireEvent(t,clock) t.clock=clock end
function ForGroup(g,action) local before=WORLD.enum;local copy={} for _,u in ipairs(g) do table.insert(copy,u) end for _,u in ipairs(copy) do WORLD.enum=u;action() end WORLD.enum=before end
function GetEnumUnit() return WORLD.enum end
function Rect(x,y,X,Y) return handle({minx=x,miny=y,maxx=X,maxy=Y}) end
function GetPlayerName(p) return WORLD.players[p].name or 'Player '..p end
function SetPlayerName(p,name) WORLD.players[p].name=name end
function Location(x,y) return handle({x=x,y=y}) end
function GetRectMinX(r) return r.minx end
function GetRectMinY(r) return r.miny end
function GetRectMaxX(r) return r.maxx end
function GetRectMaxY(r) return r.maxy end
function GetRectCenterX(r) return (r.minx+r.maxx)/2 end
function GetRectCenterY(r) return (r.miny+r.maxy)/2 end
ALLIANCE_HELP_REQUEST='help';ALLIANCE_HELP_RESPONSE='helpresponse'
PLAYER_NEUTRAL_AGGRESSIVE=12;PLAYER_NEUTRAL_PASSIVE=15
UNIT_STATE_LIFE='hp'
function GetStoredInteger(c,m,k) return c[m] and c[m][k] or 0 end
GetStoredReal=GetStoredInteger
function GetStoredBoolean(c,m,k) return c[m] and c[m][k] or false end
function GetStoredString(c,m,k) return c[m] and c[m][k] or '' end
function Condition(f) return f end
function TriggerAddCondition(t,f) table.insert(t.conditions,f) end
function TriggerEvaluate(t)
 if not t or t.destroyed then return false end
 local before=WORLD.events.trigger;WORLD.events.trigger=t
 local result=true
 for _,f in ipairs(t.conditions) do if not f() then result=false;break end end
 WORLD.events.trigger=before
 return result
end
function TriggerExecute(t)
 local before=WORLD.events.trigger;WORLD.events.trigger=t
 for _,f in ipairs(t.actions) do f() end
 WORLD.events.trigger=before
end
function GetTriggeringTrigger() return WORLD.events.trigger end
function EmitUnitEvent(event,u,fields)
 local before=WORLD.events;local fired={}
 WORLD.events=fields or {};WORLD.events.unit=u;WORLD.events.player=u.owner
 for _,reg in ipairs(WORLD.unitEvents) do
  local t=reg.trigger
  if reg.event==event and ((reg.unit~=nil and reg.unit==u) or (reg.unit==nil and reg.player==u.owner)) and not fired[t] and t.enabled~=false and not t.destroyed then
   fired[t]=true
   if TriggerEvaluate(t) then TriggerExecute(t) end
  end
 end
 WORLD.events=before
end
EVENT_UNIT_DEATH='unitdeath'
function TriggerRegisterUnitEvent(t,u,event)
 if event==EVENT_UNIT_DAMAGED then u.damageTrigger=t
 else table.insert(WORLD.unitEvents,{trigger=t,unit=u,event=event}) end
end
function DoNothing() end
function QuestSetCompleted(q,v) q.completed=v end
function QuestCreateItem(q)
 local item=handle({quest=q,completed=false})
 q.items=q.items or {};table.insert(q.items,item)
 return item
end
function QuestItemSetDescription(item,s) item.description=s end
function QuestItemSetCompleted(item,v) item.completed=v end
function IsQuestItemCompleted(item) return item.completed==true end
function CreateLeaderboard() return handle({items={}}) end
function LeaderboardClear(b) b.items={} end
function LeaderboardSetLabel(b,s) b.title=s end
function LeaderboardAddItem(b,s,v,p) b.items[p]=s end
function LeaderboardDisplay(b,v) b.visible=v end
function PlayerSetLeaderboard(p,b) WORLD.players[p].board=b end
function ClearSelection() WORLD.selected=nil end
function SelectUnit(u,b) WORLD.selected=u end
function IsUnitSelected(u,p) return WORLD.selected==u end
function SetCameraPosition(...) end
function SetCameraField(...) end
function SetUnitAnimation(u,name) u.animation=name end
function Filter(f) return f end
function DestroyBoolExpr(f) end
function GetFilterUnit() return WORLD.filterUnit end
function GetDyingUnit() return GetTriggerUnit() end
function IsUnitIdType(raw,kind)
 for _,u in ipairs(WORLD.units) do if u.id==raw and u[kind] then return true end end
 return false
end
function GroupEnumUnitsOfPlayer(g,p,filter)
 for n=#g,1,-1 do g[n]=nil end
 local previous=WORLD.filterUnit
 for _,u in ipairs(WORLD.units) do
  if u.owner==p and not u.removed then
   WORLD.filterUnit=u
   if filter==nil or filter() then table.insert(g,u) end
  end
 end
 WORLD.filterUnit=previous
end
function KillUnit(u)
 if u and not u.removed and u.hp>0.405 then
  u.hp=0
  EmitUnitEvent(EVENT_PLAYER_UNIT_DEATH,u,{killer=nil})
  EmitUnitEvent(EVENT_UNIT_DEATH,u,{killer=nil})
 end
end
function IsQuestDiscovered(q) return q and q.discovered or false end
function IsQuestCompleted(q) return q and q.completed or false end
function LeaderboardGetPlayerIndex(b,p) return p end
function LeaderboardSetItemLabel(b,i,s) b.items[i]=s end
function LeaderboardHasPlayerItem(b,p) return b.items[p]~=nil end
function LeaderboardRemovePlayerItem(b,p) b.items[p]=nil end
function LeaderboardGetItemCount(b) local n=0 for _ in pairs(b.items) do n=n+1 end return n end
function LeaderboardGetLabelText(b) return b.title or '' end
function LeaderboardSetSizeByItemCount(b,n) b.size=n end
function LeaderboardSetValueColor(...) end
function LeaderboardSetLabelColor(...) end
function LeaderboardSetStyle(...) end
function CommandAI(p,command,data)
 WORLD.commands=WORLD.commands or {}
 table.insert(WORLD.commands,{player=p,command=command,data=data})
end
function UnitShareVision(u,p,v) u.vision=u.vision or {};u.vision[p]=v end
function IssuePointOrderLoc(u,order,point) return IssuePointOrder(u,order,point.x,point.y) end
function RemoveGuardPosition(u) u.guarded=false end
function AddItemToStock(u,raw,current,max) u.stock=u.stock or {};u.stock[raw]=current end
function Pow(a,b) return a^b end
CAMERA_FIELD_TARGET_DISTANCE='distance';UNIT_TYPE_DEAD='dead';UNIT_TYPE_PEON='peon'
local originalType=IsUnitType
function IsUnitType(u,t) if not u then return false end if t==UNIT_TYPE_DEAD then return u.hp<=0.405 end return originalType(u,t) end
function QuestSetEnabled(q,v) q.enabled=v end
function IsQuestEnabled(q) return q.enabled~=false end
function DestroyQuest(q) q.destroyed=true end
function IsItemOwned(it) return it.hero~=nil end
function IsItemVisible(it) return it.visible~=false end
function SetItemVisible(it,v) it.visible=v end
function GetEnumItem() return WORLD.enumItem end
function EnumItemsInRect(r,filter,action) for _,it in ipairs(WORLD.drops) do if not it.removed and not it.hero and it.x>=r.minx and it.y>=r.miny and it.x<=r.maxx and it.y<=r.maxy then WORLD.enumItem=it;action() end end end
function ConvertAllianceType(n) return ({'passive','help','helpresponse','sharexp','sharespells','vision','control','advanced','rescuable','forcedvision'})[n+1] end
function QueuedTriggerClearBJ() WORLD.queueCleared=(WORLD.queueCleared or 0)+1 end
function GetUnitCurrentOrder(u) return u.currentOrder or 0 end
function OrderId(s) return s end
function GetRandomReal(a,b) return (a+b)/2 end
function GetRandomInt(a,b) return a end
function SetCineFilterTexture(s) WORLD.panel=s end
function SetCineFilterBlendMode(...) end
function SetCineFilterTexMapFlags(...) end
function SetCineFilterStartUV(...) end
function SetCineFilterEndUV(...) end
function SetCineFilterStartColor(...) end
function SetCineFilterEndColor(...) end
function SetCineFilterDuration(...) end
function DisplayCineFilter(b) WORLD.panelVisible=b end
BLEND_MODE_BLEND='blend';TEXMAP_FLAG_NONE='none'

function TriggerRegisterEnterRectSimple(t,r) WORLD.spawnTrigger=t end
function GetWorldBounds() return Rect(-30720,-30720,30720,30720) end
function GetEnteringUnit() return WORLD.events.entering end

function DestroyTrigger(t) t.destroyed=true;t.enabled=false end

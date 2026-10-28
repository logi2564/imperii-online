-- Native boundary only: this does not simulate rendering, mouse hit testing,
-- pathfinding, engine memory limits or actual network synchronization.
function __jarray(v) return setmetatable({}, {__index=function() return v end}) end
function FourCC(s) local n=0 for i=1,4 do n=n*256+s:byte(i) end return n end
W={next=0,units={},trees={},players={},events={},time=0,localPlayer=0,messages={},timers={},playerEvents={},trackEvents={},tech={},fog=true,mask=true,resources={},models={},assetLoads={}}
function LoadSelectorResource(path)
 if path:sub(1,3):lower()=='as\\' then
  assert(W.resources[path:lower()], 'Missing selector resource in delivered MPQ: '..path)
  table.insert(W.assetLoads,path)
 end
end
local function handle(o) W.next=W.next+1;o.handle=W.next;return o end
for p=0,15 do W.players[p]={controller='user',state='playing'};W.tech[p]={} end
MAP_CONTROL_USER='user';PLAYER_SLOT_STATE_PLAYING='playing';PLAYER_NEUTRAL_PASSIVE=15
EVENT_PLAYER_ARROW_LEFT_DOWN='left';EVENT_PLAYER_ARROW_RIGHT_DOWN='right';EVENT_PLAYER_ARROW_DOWN_DOWN='down';EVENT_PLAYER_ARROW_UP_DOWN='up';EVENT_PLAYER_LEAVE='leave'
bj_UNIT_FACING=270;bj_DEGTORAD=math.pi/180;bj_FORCE_ALL_PLAYERS='all'
function Player(p) return p end
function GetPlayerId(p) return p end
function GetPlayerController(p) return W.players[p].controller end
function GetPlayerSlotState(p) return W.players[p].state end
function GetLocalPlayer() return W.localPlayer end
function GetPlayerName(p) return 'P'..p end
function GetTriggerPlayer() return W.events.player end
function GetTriggerEventId() return W.events.event end
function GetTriggeringTrackable() return W.events.trackable end
function GetHandleId(h) assert(h,'missing handle');return h.handle end
function InitHashtable() return {} end
function SaveInteger(t,p,k,v) t[p]=t[p] or {};t[p][k]=v end
function LoadInteger(t,p,k) return t[p] and t[p][k] or 0 end
function SaveBoolean(t,p,k,v) t[p]=t[p] or {};t[p][k]=v end
function LoadBoolean(t,p,k) return t[p] and t[p][k] or false end
function CreateTrigger() return handle({enabled=true,actions={}}) end
function IsTriggerEnabled(t) return t.enabled end
function DisableTrigger(t) t.enabled=false end
function EnableTrigger(t) t.enabled=true end
function TriggerAddAction(t,f) table.insert(t.actions,f) end
function TriggerRegisterTimerExpireEvent(t,timer) timer.eventTrigger=t end
function TriggerRegisterPlayerEvent(t,p,e) table.insert(W.playerEvents,{trigger=t,player=p,event=e}) end
function TriggerRegisterTrackableHitEvent(t,track) table.insert(W.trackEvents,{trigger=t,trackable=track}) end
function EmitKey(p,key)
 W.events={player=p,event=key}
 for _,r in ipairs(W.playerEvents) do if r.player==p and r.event==key and r.trigger.enabled then for _,a in ipairs(r.trigger.actions) do a() end end end
end
function EmitTrack(track)
 W.events={trackable=track}
 for _,r in ipairs(W.trackEvents) do if r.trackable==track and r.trigger.enabled then for _,a in ipairs(r.trigger.actions) do a() end end end
end
function CreateTimer() local t=handle({});table.insert(W.timers,t);return t end
function TimerStart(t,delay,periodic,action) t.started=W.time;t.delay=delay;t.periodic=periodic;t.action=action;t.paused=false end
function TimerGetElapsed(t) return W.time-(t.started or W.time) end
function PauseTimer(t) t.paused=true end
function CreateGroup() return {} end
function GroupAddUnit(g,u) g[u]=true end
function GroupRemoveUnit(g,u) g[u]=nil end
function FirstOfGroup(g) return next(g) end
function DestroyGroup(g) end
function GroupAddGroup(a,b) for u in pairs(a) do b[u]=true end end
function ForGroup(g,f) local old=W.enum;local snapshot={} for u in pairs(g) do table.insert(snapshot,u) end for _,u in ipairs(snapshot) do W.enum=u;f() end W.enum=old end
function GetEnumUnit() return W.enum end
function GroupEnumUnitsInRect(g,r,filter) for _,u in ipairs(W.units) do if not u.removed then g[u]=true end end end
function GroupEnumUnitsOfPlayer(g,p,filter) for _,u in ipairs(W.units) do if u.owner==p and not u.removed then g[u]=true end end end
function CreateUnit(p,raw,x,y,facing) if W.models[raw] then LoadSelectorResource(W.models[raw]) end local u=handle({owner=p,raw=raw,x=x,y=y,paused=false});table.insert(W.units,u);return u end
function GetUnitTypeId(u) return u and not u.removed and u.raw or 0 end
function GetUnitX(u) return u.x end
function GetUnitY(u) return u.y end
function GetOwningPlayer(u) return u.owner end
function RemoveUnit(u) if u then u.removed=true end end
function IsUnitPaused(u) return u.paused end
function PauseUnit(u,v) u.paused=v end
function SetUnitFlyHeight(u,v,rate) u.flyHeight=v end
function CreateNUnitsAtLoc(n,raw,p,loc,facing) W.lastGroup=CreateGroup();for i=1,n do GroupAddUnit(W.lastGroup,CreateUnit(p,raw,loc.x,loc.y,facing)) end end
function GetLastCreatedGroup() return W.lastGroup end
function SetPlayerTechResearched(p,raw,level) W.tech[p][raw]=level end
function GetPlayerStartLocation(p) return p end
function GetStartLocationX(p) return p*100 end
function GetStartLocationY(p) return p*100 end
function Location(x,y) return {x=x,y=y} end
function RemoveLocation(loc) end
function GetLocationZ(loc) return 0 end
function GetWorldBounds() return {} end
function RemoveRect(r) end
function IsFogEnabled() return W.fog end
function IsFogMaskEnabled() return W.mask end
function FogEnable(v) W.fog=v end
function FogMaskEnable(v) W.mask=v end
function CreateDestructableZ(raw,x,y,z,face,scale,var) local t=handle({raw=raw,x=x,y=y,z=z});table.insert(W.trees,t);return t end
function RemoveDestructable(t) t.removed=true end
function CreateTrackable(model,x,y,facing) LoadSelectorResource(model);return handle({model=model,x=x,y=y}) end
function CreateTextTag() return handle({}) end
function DestroyTextTag(t) t.destroyed=true end
function SetTextTagVisibility(t,v) t.visible=v end
function SetTextTagText(t,text,size) t.text=text end
function SetCineFilterTexture(texture) LoadSelectorResource(texture);W.texture=texture end
function DisplayCineFilter(v) W.filter=v end
function DisplayTimedTextToForce(force,duration,text) table.insert(W.messages,text) end
function ModuloInteger(n,d) return n%d end
function I2S(n) return tostring(math.floor(n)) end
function I2R(n) return n end
function Cos(n) return math.cos(n) end
function Sin(n) return math.sin(n) end
function GetRandomInt(a,b) return (a+b)//2 end
function ConvertPlayerColor(p) return p end
function GetCameraMargin(...) return 0 end
for _,name in ipairs({'SetCameraBounds','SetCameraPosition','SetCameraField','ClearSelection','ShowInterface','EnableSelect','SetCineFilterBlendMode','SetCineFilterTexMapFlags','SetCineFilterStartUV','SetCineFilterEndUV','SetCineFilterStartColor','SetCineFilterEndColor','SetCineFilterDuration','SetUnitColor','SetUnitInvulnerable','SetUnitPathing','SetUnitAnimation','SelectUnit','ResetToGameCamera','PanCameraToTimed','SetTextTagPos','SetTextTagColor','SetTextTagPermanent'}) do _G[name]=function(...) end end

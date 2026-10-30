"""Explicit native boundary for the original spell rehearsal namespace."""
import re

# Native constructors/destructors for objects owned exclusively by a rehearsal.
RESOURCES={
 'unit':('Unit','RemoveUnit'), 'timer':('Timer','DestroyTimer'),
 'trigger':('Trigger','DestroyTrigger'), 'effect':('Effect','DestroyEffect'),
 'group':('Group','DestroyGroup'), 'force':('Force','DestroyForce'),
 'location':('Location','RemoveLocation'), 'rect':('Rect','RemoveRect'),
 'region':('Region','RemoveRegion'), 'item':('Item','RemoveItem'),
 'destructable':('Destructable','RemoveDestructable'),
 'lightning':('Lightning','DestroyLightning'), 'texttag':('TextTag','DestroyTextTag'),
 'fogmodifier':('Fog','DestroyFogModifier'), 'boolexpr':('Expr','DestroyBoolExpr'),
 'hashtable':('Hashtable',None), 'timerdialog':('TimerDialog','DestroyTimerDialog'),
 'multiboard':('Board','DestroyMultiboard'), 'sound':('Sound',None),
 'quest':('Quest','DestroyQuest'), 'dialog':('Dialog','DialogDestroy'),
}
CREATORS={'CreateUnit':'unit','CreateUnitAtLoc':'unit','CreateUnitAtLocByName':'unit','CreateBlightedGoldmine':'unit',
 'CreateTimer':'timer','CreateTrigger':'trigger','AddSpecialEffect':'effect','AddSpecialEffectLoc':'effect',
 'AddSpecialEffectTarget':'effect','CreateGroup':'group','CreateForce':'force',
 'Location':'location','GetUnitLoc':'location','GetOrderPointLoc':'location','GetSpellTargetLoc':'location',
 'Rect':'rect','CreateRegion':'region','CreateItem':'item','UnitAddItemById':'item',
 'CreateDestructable':'destructable','CreateDestructableZ':'destructable',
 'CreateDeadDestructable':'destructable','CreateDeadDestructableZ':'destructable',
 'AddLightning':'lightning','AddLightningEx':'lightning','CreateTextTag':'texttag',
 'CreateFogModifierRect':'fogmodifier','CreateFogModifierRadius':'fogmodifier',
 'CreateFogModifierRadiusLoc':'fogmodifier','Condition':'boolexpr','Filter':'boolexpr',
 'And':'boolexpr','Or':'boolexpr','Not':'boolexpr','InitHashtable':'hashtable',
 'CreateTimerDialog':'timerdialog','CreateMultiboard':'multiboard',
 'CreateSound':'sound','CreateSoundFilenameWithLabel':'sound','CreateSoundFromLabel':'sound',
 'CreateQuest':'quest','DialogCreate':'dialog'}
CUSTOM={'CreateUnit':'SDNewUnit','CreateTimer':'SDNewTimer','CreateTrigger':'SDNewTrigger',
 'Location':'SDNewLocation','Rect':'SDNewRect','CreateForce':'SDNewForce',
 'InitHashtable':'SDNewHashtable','Player':'SDPlayer','GetPlayerId':'SDPlayerId',
 'GetSoldUnit':'SDSold','GetBuyingUnit':'SDBuyer','GetTriggerUnit':'SDTriggerUnit',
 'GetTriggerPlayer':'SDTriggerPlayer','GetTriggerEventId':'SDTriggerEvent',
 'GetUnitTypeId':'SDUnitType','GetPlayerController':'SDController',
 'GetPlayerSlotState':'SDSlotState','GetSpellAbilityId':'SDSpellId',
 'GetUnitAbilityLevel':'SDAbilityLevel','UnitAddAbility':'SDAddAbility',
 'UnitRemoveAbility':'SDRemoveAbility','SetUnitAbilityLevel':'SDSetAbility',
 'UnitMakeAbilityPermanent':'SDPermanentAbility','SetPlayerAbilityAvailable':'SDPlayerAbility',
 'TriggerRegisterPlayerUnitEvent':'SDRegisterPlayerUnitEvent',
 'GetRectCenterX':'SDRectX','GetRectCenterY':'SDRectY',
 'SetUnitX':'SDSetX','SetUnitY':'SDSetY','SetUnitPosition':'SDSetPosition','SetUnitPositionLoc':'SDSetPositionLoc',
 'GroupEnumUnitsInRange':'SDEnumRange','GroupEnumUnitsInRangeOfLoc':'SDEnumRangeLoc',
 'GroupEnumUnitsInRect':'SDEnumRect','GroupEnumUnitsOfPlayer':'SDEnumPlayer',
 'GetRandomReal':'GetRandomReal','GetRandomInt':'GetRandomInt'}


def default(kind):return '0' if kind=='integer' else '0.' if kind=='real' else 'false' if kind=='boolean' else '""' if kind=='string' else 'null'


def resource_globals():
    rows=['hashtable SDObjects=null','boolexpr SDWorldExpression=null','hashtable SDTouches=null','hashtable SDMeta=null',
          'integer SDDirtyCount=0','integer array SDDirtyVar','integer array SDDirtyIndex',
          'integer SDClearCursor=0','integer SDClearId=0','integer SDClearIndex=0',
          'boolean SDActive=false','boolean SDRunning=false','boolean SDCreating=false',
          'boolean SDInitializing=false','integer SDGeneration=0','unit SDActor=null',
          'unit SDFakeBuyer=null','integer SDActorBase=0','integer SDViewer=-1',
          'integer SDIndex=0','integer SDCastRaw=0','boolean SDCastSeen=false']
    for kind,(label,_) in RESOURCES.items():rows+=['integer SD'+label+'Count=0',kind+' array SD'+label+'List']
    return '\n'.join(rows)


def resource_code():
    rows=[]
    for kind,(label,destroy) in RESOURCES.items():
        rows.append(f'''function SDTrack{label} takes {kind} object returns {kind}
if object!=null then
if SD{label}Count<8000 then
set SD{label}List[SD{label}Count]=object
call SaveBoolean(SDObjects,GetHandleId(object),0,true)
call SaveInteger(SDObjects,GetHandleId(object),{100+list(RESOURCES).index(kind)},SD{label}Count)
set SD{label}Count=SD{label}Count+1
endif
endif
return object
endfunction''')
        if destroy:
            rows.append(f'''function SDSafe{destroy} takes {kind} object returns nothing
if object!=null and LoadBoolean(SDObjects,GetHandleId(object),0) then
call SaveBoolean(SDObjects,GetHandleId(object),0,false)
set SD{label}List[LoadInteger(SDObjects,GetHandleId(object),{100+list(RESOURCES).index(kind)})]=null
call {destroy}(object)
endif
endfunction''')
        cleanup='call '+destroy+'(SD'+label+'List[i])' if destroy else (
            'call FlushParentHashtable(SD'+label+'List[i])' if kind=='hashtable' else 'call StopSound(SD'+label+'List[i],true,false)\ncall KillSoundWhenDone(SD'+label+'List[i])')
        rows.append(f'''function SDClean{label} takes nothing returns nothing
local integer i=0
loop
exitwhen i>=SD{label}Count
if SD{label}List[i]!=null and LoadBoolean(SDObjects,GetHandleId(SD{label}List[i]),0) then
call SaveBoolean(SDObjects,GetHandleId(SD{label}List[i]),0,false)
{cleanup}
endif
set SD{label}List[i]=null
set i=i+1
endloop
set SD{label}Count=0
endfunction''')
    return '\n'.join(rows)


def wrappers(calls,signatures,private):
    names={};code=[];blocked=[];checked=[];constructors=[]
    destroy_names={v[1]:kind for kind,v in RESOURCES.items() if v[1]}
    for name in sorted(calls):
        if name not in signatures:continue
        if name in CUSTOM:
            if CUSTOM[name]!=name:names[name]=CUSTOM[name]
            continue
        args,returns=signatures[name]
        params=[] if args=='nothing' else [x.strip().split() for x in args.split(',')]
        ids=[v[-1] for v in params];types=[v[0] for v in params]
        call=name+'('+','.join(ids)+')'
        rows=[]
        if name in CREATORS:
            kind=CREATORS[name];label=RESOURCES[kind][0]
            rows=['local '+returns+' result='+call,'call SDTrack'+label+'(result)','return result'];constructors.append(name)
            if name=='UnitAddItemById':
                rows=['local item result=null','if not SDIsUnit('+ids[0]+') then','return null','endif',
                      'set result='+call,'call SDTrackItem(result)','return result']
        elif name in destroy_names:
            kind=destroy_names[name];label=RESOURCES[kind][0]
            names[name]='SDSafe'+name;checked.append(name);continue
        elif name.startswith(('Display','SetCamera','PanCamera','SelectUnit','ClearSelection','EnableUser',
                'ShowInterface','SetCine','StartSound','PlayMusic','StopMusic','SetMusic','SetSound',
                'StopSound','KillSoundWhenDone','AttachSoundToUnit','SetAmbient','NewSoundEnvironment','SetDayNight','SetTerrain','SetSky','FogEnable','FogMask',
                'SetTimeOfDay','SetFloatGameState','SetMap','SetGame','EndGame','ChangeLevel','SaveGame',
                'ReloadGame','Preload','LoadGame','RestartGame','PauseGame','RemovePlayer',
                'SetPlayerName','SetPlayerColor','SetPlayerAlliance','SetAllyColorFilter',
                'MultiboardDisplay','TimerDialogDisplay','DialogDisplay','QuestSet','QuestItemSet',
                'FlashQuest','PingMinimap','DestroyFog','AddItemToAllStock','RemoveItemFromAllStock',
                'Cinematic','SetUnitFog','SetBlight','TerrainDeform','UnitShareVision','SetWater')) or name in ('TriggerSleepAction','SetPlayerController','SetPlayerSlotAvailable','SetPlayerRacePreference'):
            rows=['return'+(' '+default(returns) if returns!='nothing' else '')];blocked.append(name)
        elif name in ('UnitDamageTarget','UnitDamagePoint'):
            if name=='UnitDamagePoint':rows=['return false']
            else:rows=['if not SDIsUnit('+ids[0]+') or '+ids[1]+'==null or not LoadBoolean(SDObjects,GetHandleId('+ids[1]+'),0) then','return false','endif','return '+call]
            checked.append(name)
        elif name.startswith(('SetPlayer','AdjustPlayer','AddPlayer','RemovePlayer')):
            player=next((v[-1] for v in params if v[0]=='player'),None)
            if not player:rows=['return'+(' '+default(returns) if returns!='nothing' else '')]
            else:rows=['if GetPlayerId('+player+')!=13 and GetPlayerId('+player+')!=14 then',
                       'return'+(' '+default(returns) if returns!='nothing' else ''),'endif',
                       ('return ' if returns!='nothing' else 'call ')+call]
            checked.append(name)
        elif types and types[0] in ('unit','widget','item','destructable','trigger','group','force','timer','effect','lightning','rect','region','hashtable','texttag','timerdialog','multiboard') and not name.startswith(('Get','Have','Load','Count','FirstOf','Save','TriggerRegister','TriggerAdd')) and not (name.startswith('Is') and not name.startswith('Issue')):
            # Every mutation of a handle must name a scene-owned object.
            rows=['if '+ids[0]+'==null or not LoadBoolean(SDObjects,GetHandleId('+ids[0]+'),0) then',
                  'return'+(' '+default(returns) if returns!='nothing' else ''),'endif',
                  ('return ' if returns!='nothing' else 'call ')+call];checked.append(name)
        else:continue
        wrapper='SDN_'+name;names[name]=wrapper
        code.append('function '+wrapper+' takes '+args+' returns '+returns+'\n'+'\n'.join(rows)+'\nendfunction')
    return '\n'.join(code),names,dict(blockedUiAndWorldNatives=blocked,ownedHandleMutations=checked,trackedConstructors=constructors)

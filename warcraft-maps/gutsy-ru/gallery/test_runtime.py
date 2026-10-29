"""Run the delivered JASS and original start/sale/portal handlers at native boundaries.

No Warcraft renderer, pathfinder, damage system or network is simulated here.
Unlike MENU I's test, hero creation is not an assignment in a purchase stub:
the actual map sale handler and its seven hero initialization partitions run.
"""
import copy
import hashlib
import importlib.util
import json
import re
import sys
from collections import defaultdict
from pathlib import Path

HERE=Path(__file__).resolve().parent
sys.path.insert(0,str(HERE.parent/'tools'))
from storm import Storm
from classic_data import read_objects

spec=importlib.util.spec_from_file_location('old_menu_test',HERE.parent/'menu/test_menu.py')
old=importlib.util.module_from_spec(spec);spec.loader.exec_module(old)


def translate(source):
    """Controlled plain-JASS subset, retaining original handler statements."""
    rows=[];depth=0;local_names=set();global_assignments=[]
    for raw in source.splitlines():
        line=raw.strip()
        if not line or line.startswith('//'):continue
        line=re.sub(r'^(if|elseif|exitwhen)\(',r'\1 (',line)
        line=re.sub(r'\)then$',') then',line)
        if line.startswith('function '):
            match=re.match(r'function (\w+) takes (.*?) returns (\w+)',line)
            name,args,return_type=match.groups()
            params=[] if args=='nothing' else [a.strip().split()[-1] for a in args.split(',')]
            rows.append(f'def {name}({",".join(params)}):');depth=1;local_names=set(params)
            global_assignments=[];insert=len(rows);continue
        if line=='endfunction':
            if global_assignments:rows.insert(insert,'    global '+','.join(sorted(set(global_assignments))))
            depth=0;continue
        local=re.match(r'local (\w+) (\w+)(?:=(.*))?$',line)
        if local:
            kind,name,value=local.groups();local_names.add(name)
            if value is None:value='0' if kind in ('integer','real') else 'false' if kind=='boolean' else '""' if kind=='string' else 'null'
            line=name+'='+value
        assignment=re.match(r'set (\w+)\s*=',line)
        if assignment and assignment[1] not in local_names:global_assignments.append(assignment[1])
        if line in ('endif','endloop'):
            depth-=1;continue
        if line.startswith('elseif '):
            depth-=1;line='elif '+old.expression(line[7:-5])+':'
        elif line=='else':depth-=1;line='else:'
        elif line.startswith('if '):line='if '+old.expression(line[3:-5])+':'
        elif line=='loop':line='while True:'
        elif line.startswith('exitwhen '):line='if '+old.expression(line[9:])+': break'
        else:
            line=re.sub(r'^(?:set|call) ','',line)
            # Warcraft's legacy boolean != null means != zero; Python's
            # boolean != None would incorrectly make false conditions true.
            if return_type=='boolean' and line.startswith('return') and line.endswith('!=null'):line=line[:-6]
            line=old.expression(line)
        rows.append('    '*depth+line)
        if line.endswith(':'):
            depth+=1
            rows.append('    '*depth+'pass')
    return '\n'.join(rows)


class Handle(dict):
    __hash__=object.__hash__
    __eq__=object.__eq__


class Engine:
    cache={}
    def __init__(self,out,players=(0,),local=0):
        self.out=Path(out);self.players=set(players);self.local=local
        self.e={};self.events={};self.units=[];self.timers=[];self.clock=0.;self.serial=0
        self.alliances={};self.unit_events=[];self.sell_events=[];self.timer_events=defaultdict(list)
        self.orders=[];self.gold=defaultdict(int);self.lumber=defaultdict(int);self.initializations=defaultdict(int)
        self.registration=[];self.boundaries=[];self.selected={};self.ui_textures=[];self.tech=defaultdict(lambda:-1)
        self.missing_sale=False;self.reject_orders=False;self.in_spell=False
        self.hashtable={};self.hashtable_serial=0
        key=(str(self.out.resolve()),(self.out/'Gallery.j').stat().st_mtime_ns)
        if key not in self.cache:
            data=json.loads((self.out/'Gallery-data.json').read_text())
            script=(self.out/'Gallery.j').read_text()
            st=Storm();arc=st.open(self.out/'GGG-RU-GALLERY-FIX.w3x')
            try:
                files=set(st.read(arc,'(listfile)').decode().splitlines())
                abilities={o['new'].decode():{m[0]:m for m in o['mods']} for o in read_objects(st.read(arc,'war3map.w3a'),True)[1]}
                units={o['new'].decode():{m[0]:m for m in o['mods']} for o in read_objects(st.read(arc,'war3map.w3u'))[1]}
            finally:st.close(arc)
            self.cache[key]=(data,script,files,abilities,units)
        self.data,self.script,self.files,self.ui_abilities,self.ui_units=self.cache[key]
        self.load()

    def h(self,kind,**values):
        self.serial+=1;return Handle(kind=kind,id=self.serial,**values)

    def unit(self,p,raw,x=0,y=0,facing=0):
        result=self.h('unit',owner=p,raw=raw,x=x,y=y,removed=False,invulnerable=False,
                      paused=False,abilities={'Amov':1,'Aatk':1},items=[],level=1,buffs=set(),scale=1.)
        self.units.append(result);return result

    def remove(self,u):
        if u:
            assert not self.in_spell,'Replacing the caster inside its native spell callback'
            u['removed']=True;self.selected.pop(u,None)

    def group(self):return self.h('group',members=[])
    def force(self):return self.h('force',members=set())
    def rect(self,a,b,c,d):return self.h('rect',a=a,b=b,c=c,d=d)
    def loc(self,x,y):return self.h('location',x=x,y=y)
    def center(self,r):return self.loc((r['a']+r['c'])/2,(r['b']+r['d'])/2)
    def rect_units(self,r,filter_=None):
        g=self.group()
        for u in list(self.units):
            if not u['removed'] and r['a']<=u['x']<=r['c'] and r['b']<=u['y']<=r['d']:
                previous=self.events.get('filter_unit');self.events['filter_unit']=u
                if filter_ is None or filter_():g['members'].append(u)
                self.events['filter_unit']=previous
        return g

    def foreach(self,collection,fn,kind):
        old_value=self.events.get(kind)
        for value in list(collection['members']):self.events[kind]=value;fn()
        self.events[kind]=old_value

    def all_ally(self,p,q):
        if p==q:return True
        return self.alliances.get((p,q),0)>0

    def timer(self):
        t=self.h('timer',active=False,generation=0);self.timers.append(t);return t

    def timer_start(self,t,delay,periodic,fn):
        assert t is not None
        t.update(active=True,due=self.clock+max(float(delay),.001),periodic=periodic,delay=max(float(delay),.001),callback=fn,generation=t['generation']+1)

    def pause(self,t):
        if t:t.update(active=False,generation=t['generation']+1)

    def execute(self,t):
        previous=self.events.get('trigger');self.events['trigger']=t
        for fn in list(t['actions']):fn()
        self.events['trigger']=previous

    def advance(self,seconds):
        target=self.clock+seconds;count=0
        while True:
            due=[t for t in self.timers if t['active'] and t['due']<=target]
            if not due:break
            t=min(due,key=lambda v:v['due']);self.clock=t['due'];generation=t['generation']
            previous=self.events;self.events={'timer':t}
            if t.get('callback'):t['callback']()
            for trigger in self.timer_events[t]:
                if trigger['enabled'] and all(fn() for fn in trigger['conditions']):self.execute(trigger)
            self.events=previous
            if generation==t['generation']:
                if t.get('periodic'):t['due']=self.clock+t['delay']
                else:t['active']=False
            count+=1;assert count<100000,'Unbounded native timer loop'
        self.clock=target

    def issue(self,p,shop,raw):
        if self.reject_orders or self.tech[p,raw]==0:return False
        assert self.e['GGVPhase']==1,'Purchase outside launching phase'
        assert self.e['GGVChoice'][p]>=0
        self.orders.append((p,raw))
        if self.missing_sale:return True
        self.sell(p,raw,shop)
        return True

    def sell(self,p,raw,shop=None):
        sold=self.unit(p,raw,shop['x'] if shop else 0,shop['y'] if shop else 0)
        buyer=next((u for u in self.units if u['owner']==p and u['raw']=='h01A' and not u['removed']),None)
        previous=self.events;self.events={'player':p,'sold':sold,'unit':shop,'buyer':buyer,'event':'sell'}
        for t in self.sell_events:
            if t['enabled'] and all(fn() for fn in t['conditions']):self.execute(t)
        self.events=previous
        return sold

    def add_ability(self,u,raw):
        if u['raw'] in self.ui_units:
            assert raw in self.ui_abilities or raw=='Avul',('Missing command-card object',raw)
        u['abilities'][raw]=1;return True

    def create_n(self,n,raw,p,loc,facing):
        assert loc is not None,(raw,'missing location in map fixture')
        g=self.group()
        for _ in range(n):
            u=self.unit(p,raw,loc['x'],loc['y'],facing);g['members'].append(u);self.e['bj_lastCreatedUnit']=u
        self.e['bj_lastCreatedGroup']=g

    def add_item(self,raw,u):
        item=self.h('item',raw=raw,charges=0);u['items'].append(item);self.e['bj_lastCreatedItem']=item;return item

    def register(self,*args):self.registration.append(args);return self.h('registration')
    def effect(self,*args):self.e['bj_lastCreatedEffect']=self.h('effect');return self.e['bj_lastCreatedEffect']
    def board(self):return self.h('board',rows=32,columns=1,items={},visible=False)
    def board_item(self,b,row,column):
        assert 0<=row<b['rows'] and 0<=column<b['columns'],('Out of bounds native multiboard access',row,column,b['rows'],b['columns'])
        return self.h('boarditem',board=b,row=row,column=column)
    def board_value(self,item,value):item['board']['items'][(item['row'],item['column'])]=value
    def create_board_bj(self,cols,rows,title):
        b=self.board();b.update(columns=cols,rows=rows,title=title);self.e['bj_lastCreatedMultiboard']=b;return b

    def create_trigger(self):return self.h('trigger',enabled=True,actions=[],conditions=[])

    def begin_timer_bj(self,t,periodic,delay):
        self.timer_start(t,delay,periodic,None);self.e['bj_lastStartedTimer']=t

    def init_globals(self,text):
        pattern=r'(?m)^(?:constant )?(\w+)\s+(?:(array)\s+)?(\w+)(?:=(.*))?$'
        for kind,array,name,value in re.findall(pattern,text):
            if kind in ('globals','endglobals'):continue
            default=0 if kind in ('integer','real') else False if kind=='boolean' else '' if kind=='string' else None
            if array:self.e[name]=defaultdict(lambda v=default:v)
            else:
                self.e[name]=default
                if value:
                    try:self.e[name]=eval(old.expression(value),self.e)
                    except (NameError,TypeError,SyntaxError):pass

    def bind_natives(self):
        e=self.e
        def no_op(*args):return None
        def modify_resource(amount,p,which):
            (self.gold if which=='gold' else self.lumber)[p]+=amount
        def set_resource(p,which,amount):(self.gold if which=='gold' else self.lumber).__setitem__(p,amount)
        def resource(p,which):return (self.gold if which=='gold' else self.lumber)[p]
        def quest(*args):e['bj_lastCreatedQuest']=self.h('quest')
        def timer_dialog(t,title):e['bj_lastCreatedTimerDialog']=self.h('timerdialog',timer=t,title=title)
        def source_trigger_boundary(name):
            def run():
                self.boundaries.append(name)
                if name=='Trig_Round_start_Epiccenter_Actions':e['udg_System_Round']+=1
            return run
        def getstate(u,which):return u.get('states',{}).get(which,1000.)
        def table_save(t,p,c,v):self.hashtable[t,p,c]=v
        def table_load(t,p,c):return self.hashtable.get((t,p,c))
        e.update(dict(
            InitHashtable=lambda:self.h('hashtable'),GetHandleId=lambda h:h['id'] if h else 0,
            StringHash=lambda s:sum((n+1)*ord(c) for n,c in enumerate(s)),
            SaveInteger=table_save,SaveReal=table_save,SaveUnitHandle=table_save,SaveTimerHandle=table_save,
            LoadInteger=lambda t,p,c:table_load(t,p,c) or 0,LoadReal=lambda t,p,c:table_load(t,p,c) or 0.,LoadUnitHandle=table_load,
            FlushChildHashtable=lambda t,p:[self.hashtable.pop(k) for k in list(self.hashtable) if k[:2]==(t,p)],
            RemoveSavedInteger=lambda t,p,c:self.hashtable.pop((t,p,c),None),
            CreateTextTagLocBJ=lambda *args:e.__setitem__('bj_lastCreatedTextTag',self.h('texttag')),
            SetUnitAbilityLevelSwapped=lambda a,u,l:u['abilities'].__setitem__(a,l),
            SetUnitLifePercentBJ=lambda u,v:u.setdefault('states',{}).__setitem__('UNIT_STATE_LIFE',10*v),
            SetUnitManaPercentBJ=lambda u,v:u.setdefault('states',{}).__setitem__('UNIT_STATE_MANA',10*v),
            GetUnitState=getstate,GetUnitStateSwap=lambda which,u:getstate(u,which),
            ModifyHeroSkillPoints=lambda u,operation,n:u.update(skillpoints=(u.get('skillpoints',0)+n if operation==0 else u.get('skillpoints',0)-n if operation==1 else n)),
            PauseUnit=lambda u,v:u.update(paused=v),KillUnit=lambda u:u.update(dead=True),
            ShowUnitHide=lambda u:u.update(hidden=True),ShowUnitShow=lambda u:u.update(hidden=False),
            SetPlayerStateBJ=lambda p,state,v:set_resource(p,state,v),IAbsBJ=abs,
            PolledWait=lambda delay:None,
            DialogClear=no_op,DialogSetMessage=no_op,DialogAddButtonBJ=no_op,DialogDisplayBJ=no_op,
            CustomDefeatBJ=no_op,
            SetUnitVertexColorBJ=no_op,TimerDialogSetTitleColorBJ=no_op,ShieldCap=no_op,
            TriggerRegisterPlayerEventEndCinematic=self.register,TriggerRegisterPlayerKeyEventBJ=self.register,
            TriggerRegisterPlayerSelectionEventBJ=self.register,TriggerRegisterTimerEventPeriodic=self.register,
            TriggerRegisterVariableEvent=self.register,UnitResetCooldown=no_op,UnitShareVisionBJ=no_op,
            Player=lambda p:p,GetPlayerId=lambda p:p if p is not None else -1,GetLocalPlayer=lambda:self.local,
            GetPlayerController=lambda p:'human' if p in self.players else 'none',
            GetPlayerSlotState=lambda p:'playing' if p in self.players else 'empty',
            GetPlayerName=lambda p:'P'+str(p),SetPlayerName=no_op,
            GetTriggerPlayer=lambda:self.events.get('player'),GetTriggerUnit=lambda:self.events.get('unit'),
            GetSoldUnit=lambda:self.events.get('sold'),GetBuyingUnit=lambda:self.events.get('buyer'),
            GetSpellAbilityId=lambda:self.events.get('spell'),GetTriggeringTrigger=lambda:self.events.get('trigger'),
            GetExpiredTimer=lambda:self.events.get('timer'),GetEventPlayerChatString=lambda:self.events.get('chat',''),
            GetEnumPlayer=lambda:self.events.get('enum_player'),GetEnumUnit=lambda:self.events.get('enum_unit'),
            GetFilterPlayer=lambda:self.events.get('enum_player'),GetFilterUnit=lambda:self.events.get('filter_unit'),
            CreateTrigger=self.create_trigger,DestroyTrigger=lambda t:t.update(enabled=False,actions=[],conditions=[]),TriggerAddAction=lambda t,f:t['actions'].append(f),
            DialogCreate=lambda:self.h('unused-original-dialog'),
            TriggerAddCondition=lambda t,f:t['conditions'].append(f),Condition=lambda fn:fn,
            DisableTrigger=lambda t:t.update(enabled=False),EnableTrigger=lambda t:t.update(enabled=True),
            IsTriggerEnabled=lambda t:t['enabled'],TriggerExecute=self.execute,
            ConditionalTriggerExecute=lambda t:self.execute(t) if t['enabled'] and all(fn() for fn in t['conditions']) else None,
            ExecuteFunc=lambda n:e[n](),TriggerRegisterPlayerUnitEvent=lambda t,p,event,filter_:self.unit_events.append((t,p,event)),
            TriggerRegisterAnyUnitEventBJ=lambda t,event:self.sell_events.append(t) if event=='sell' else self.register(t,event),
            TriggerRegisterTimerExpireEvent=lambda t,timer:self.timer_events[timer].append(t),
            TriggerRegisterPlayerEvent=self.register,TriggerRegisterPlayerChatEvent=self.register,
            TriggerRegisterUnitEvent=self.register,TriggerRegisterUnitLifeEvent=self.register,
            CreateTimer=self.timer,TimerStart=self.timer_start,PauseTimer=self.pause,DestroyTimer=self.pause,
            StartTimerBJ=self.begin_timer_bj,PauseTimerBJ=lambda paused,t:self.pause(t),
            CreateTimerDialogBJ=timer_dialog,DestroyTimerDialog=no_op,TimerDialogDisplay=no_op,
            TimerDialogDisplayForPlayerBJ=no_op,TimerDialogSetTitle=no_op,
            CreateForce=self.force,ForceClear=lambda f:f['members'].clear(),ForceAddPlayer=lambda f,p:f['members'].add(p),
            ForceRemovePlayer=lambda f,p:f['members'].discard(p),IsPlayerInForce=lambda p,f:bool(f and p in f['members']),
            IsPlayerInForceBJ=lambda p,f:bool(f and p in f['members']),ForForce=lambda f,fn:self.foreach(f,fn,'enum_player'),
            ForcePickRandomPlayer=lambda f:min(f['members']) if f['members'] else None,
            SetForceAllianceStateBJ=lambda a,b,state:[self.alliances.__setitem__((p,q),state) for p in a['members'] for q in b['members']],
            SetPlayerAllianceStateBJ=lambda p,q,state:self.alliances.__setitem__((p,q),state),SetPlayerAlliance=no_op,
            IsPlayerAlly=self.all_ally,IsUnitAlly=lambda u,p:self.all_ally(u['owner'],p),
            CreateGroup=self.group,GroupAddUnit=lambda g,u:g['members'].append(u),
            GroupRemoveUnit=lambda g,u:g['members'].remove(u) if u in g['members'] else None,
            FirstOfGroup=lambda g:g['members'][0] if g['members'] else None,DestroyGroup=no_op,
            ForGroupBJ=lambda g,fn:self.foreach(g,fn,'enum_unit'),ForGroup=lambda g,fn:self.foreach(g,fn,'enum_unit'),
            GetUnitsInRectAll=lambda r:self.rect_units(r),GetUnitsInRectMatching=lambda r,fn:self.rect_units(r,fn),
            GroupPickRandomUnit=lambda g:g['members'][0] if g['members'] else None,
            Rect=self.rect,GetRectCenter=self.center,GetRandomLocInRect=self.center,
            GetRectCenterX=lambda r:(r['a']+r['c'])/2,GetRectCenterY=lambda r:(r['b']+r['d'])/2,
            Location=self.loc,GetLocationX=lambda l:l['x'],GetLocationY=lambda l:l['y'],GetLocationZ=lambda l:0,
            RemoveLocation=no_op,OffsetLocation=lambda l,x,y:self.loc(l['x']+x,l['y']+y),
            PolarProjectionBJ=lambda l,d,a:self.loc(l['x']+d,l['y']),
            CreateUnit=self.unit,CreateNUnitsAtLoc=self.create_n,RemoveUnit=self.remove,
            GetUnitTypeId=lambda u:u['raw'] if u and not u['removed'] else 0,
            GetOwningPlayer=lambda u:u['owner'] if u else None,SetUnitOwner=lambda u,p,c:u.update(owner=p),
            GetUnitX=lambda u:u['x'],GetUnitY=lambda u:u['y'],GetUnitLoc=lambda u:self.loc(u['x'],u['y']),
            GetUnitName=lambda u:u['raw'] if u else '',GetHeroProperName=lambda u:u['raw'],
            GetUnitLevel=lambda u:u['level'],GetHeroLevel=lambda u:u['level'],
            SetHeroLevelBJ=lambda u,level,effect:u.update(level=level),SetHeroLevel=lambda u,l,f:u.update(level=l),
            GetHeroStr=lambda u,bonuses:50,GetHeroAgi=lambda u,bonuses:50,GetHeroInt=lambda u,bonuses:50,
            UnitAddAbility=self.add_ability,UnitRemoveAbility=lambda u,a:u['abilities'].pop(a,None) if u else None,
            SetUnitAbilityLevel=lambda u,a,l:u['abilities'].__setitem__(a,l),GetUnitAbilityLevel=lambda u,a:u['abilities'].get(a,0),
            UnitMakeAbilityPermanent=no_op,SetPlayerAbilityAvailableBJ=no_op,
            SetPlayerUnitAvailableBJ=lambda raw,v,p:self.tech.__setitem__((p,raw),-1 if v else 0),
            GetPlayerTechMaxAllowed=lambda p,raw:self.tech[p,raw],SetPlayerTechResearched=no_op,
            SetPlayerTechResearchedSwap=no_op,SetPlayerTechMaxAllowed=lambda p,r,v:self.tech.__setitem__((p,r),v),
            IsUnitOwnedByPlayer=lambda u,p:bool(u and u['owner']==p),
            IsUnitType=lambda u,kind:bool(u and (u['raw'][0].isupper() if kind=='hero' else u['removed'] if kind=='dead' else False)),
            UnitHasBuffBJ=lambda u,b:bool(u and b in u['buffs']),
            SetUnitInvulnerable=lambda u,v:u.update(invulnerable=v),SetUnitPathing=no_op,
            SetUnitAnimation=no_op,SetUnitFlyHeight=lambda u,z,r:u.update(height=z),
            SetUnitPositionLoc=lambda u,l:u.update(x=l['x'],y=l['y']),SetUnitColor=no_op,SetUnitVertexColor=no_op,
            IssueTargetOrderById=lambda u,o,t:True,UnitApplyTimedLifeBJ=no_op,UnitApplyTimedLife=no_op,
            UnitAddItemByIdSwapped=self.add_item,SetItemCharges=lambda item,v:item.update(charges=v),
            AdjustPlayerStateBJ=modify_resource,SetPlayerState=set_resource,GetPlayerState=resource,
            CreateQuestBJ=quest,QuestSetDescription=no_op,QuestMessageBJ=no_op,FlashQuestDialogButton=no_op,
            CreateMultiboard=self.board,CreateMultiboardBJ=self.create_board_bj,
            MultiboardSetRowCount=lambda b,r:b.update(rows=r),MultiboardSetColumnCount=lambda b,c:b.update(columns=c),
            MultiboardSetTitleText=lambda b,t:b.update(title=t),MultiboardGetItem=self.board_item,
            MultiboardSetItemValue=self.board_value,MultiboardSetItemWidth=no_op,MultiboardSetItemStyle=no_op,
            MultiboardReleaseItem=no_op,MultiboardDisplay=lambda b,v:b.update(visible=v),MultiboardMinimize=no_op,
            MultiboardSetItemValueBJ=lambda b,c,r,v:b['items'].__setitem__((r-1,c-1),v),
            MultiboardSetItemStyleBJ=no_op,MultiboardSetItemIconBJ=no_op,MultiboardSetItemWidthBJ=no_op,
            AddSpecialEffectLocBJ=self.effect,AddSpecialEffectTargetUnitBJ=self.effect,DestroyEffect=no_op,
            PlaySoundBJ=no_op,PlayMusicBJ=no_op,SetMusicVolumeBJ=no_op,StopMusic=no_op,PlayMusic=no_op,
            AddUnitToStock=no_op,IssueNeutralImmediateOrderById=self.issue,
            SelectUnitForPlayerSingle=lambda u,p:self.selected.update({u:True}),ClearSelection=lambda:self.selected.clear(),
            IsUnitSelected=lambda u,p:self.selected.get(u,False),SelectUnit=lambda u,v:self.selected.__setitem__(u,v),
            CreateFogModifierRadius=lambda *args:self.h('fog'),FogModifierStart=no_op,FogModifierStop=no_op,DestroyFogModifier=no_op,
            CreateFogModifierRectBJ=lambda *args:e.__setitem__('bj_lastCreatedFogModifier',self.h('fog')),
            StringLength=lambda s:len(s.encode('utf8','surrogateescape')),
            SubString=lambda s,a,b:s.encode('utf8','surrogateescape')[a:b].decode('utf8','surrogateescape'),
            SubStringBJ=lambda s,a,b:s.encode('utf8','surrogateescape')[a-1:b].decode('utf8','surrogateescape'),
            ModuloInteger=lambda a,b:a%b,I2S=lambda n:str(int(n)),I2R=float,R2I=int,S2I=lambda s:int(s) if s and re.fullmatch(r'-?\d+',s) else 0,
            RAbsBJ=abs,GetRandomInt=lambda a,b:a,GetRandomReal=lambda a,b:(a+b)/2,
            GetBooleanAnd=lambda a,b:a and b,GetBooleanOr=lambda a,b:a or b,
            GetForceOfPlayer=lambda p:self.h('force',members={p}),
            SetCineFilterTexture=lambda path:self.ui_textures.append(path),
            GetCameraMargin=lambda *args:0,
            ReviveHeroLoc=lambda u,l,f:u.update(removed=False,x=l['x'],y=l['y']),
            DisplayTimedTextToForce=no_op,DisplayTextToForce=no_op,ShowTextTagForceBJ=no_op,
            Assets_UseSoundByPath__MakeSound=lambda *args:self.h('sound'),
            CreateShield=lambda *args:e.__setitem__('LastShield',1),CreateDR=no_op,
            Delaystop=no_op,FilterUnit2=no_op,SetUnitTimeScalePercent=no_op,
            Trig_Round_start_Epiccenter_Actions=source_trigger_boundary('Trig_Round_start_Epiccenter_Actions'),
        ))
        camera=['ShowInterface','SetCameraBounds','SetCameraPosition','SetCameraField','SetCineFilterBlendMode',
                'SetCineFilterTexMapFlags','SetCineFilterStartUV','SetCineFilterEndUV','SetCineFilterStartColor',
                'SetCineFilterEndColor','SetCineFilterDuration','DisplayCineFilter','ResetToGameCamera','PanCameraTo',
                'PanCameraToTimedLocForPlayer','SetCameraFieldForPlayer','PingMinimapLocForForceEx','SetUserControlForceOn']
        for name in camera:e[name]=no_op
        constants={'MAP_CONTROL_USER':'human','MAP_CONTROL_COMPUTER':'computer','PLAYER_SLOT_STATE_PLAYING':'playing',
                   'PLAYER_SLOT_STATE_EMPTY':'empty','PLAYER_NEUTRAL_PASSIVE':15,'PLAYER_NEUTRAL_AGGRESSIVE':12,
                   'UNIT_TYPE_HERO':'hero','UNIT_TYPE_DEAD':'dead','EVENT_PLAYER_UNIT_SELL':'sell',
                   'EVENT_PLAYER_UNIT_SPELL_EFFECT':'spell','PLAYER_STATE_RESOURCE_GOLD':'gold','PLAYER_STATE_RESOURCE_LUMBER':'lumber',
                   'bj_UNIT_FACING':270,'TRUE':True,'FALSE':False,'FOG_OF_WAR_VISIBLE':1,'BLEND_MODE_BLEND':1,'TEXMAP_FLAG_NONE':0}
        e.update(constants)
        for name in set(re.findall(r'\b(?:EVENT_\w+|CAMERA_\w+|UNIT_STATE_\w+|PLAYER_COLOR_\w+)\b',self.script)):
            e.setdefault(name,name)

    def load(self):
        self.bind_natives()
        globals_=self.script[:self.script.index('endglobals')]
        self.init_globals(globals_)
        self.bind_natives()
        cached=getattr(Engine,'compiled_cache',None)
        if cached is None or cached[0]!=self.script:
            f={m[1]:m[0] for m in re.finditer(r'^function (\w+) takes .*?^endfunction',self.script,re.M|re.S)}
            selected=set(n for n in f if n.startswith(('GGV','GGMData','GV_Restart_1_','Trig_Hero_Select_')))
            roots=['InitGlobals','InitTrig_Hero_Select','InitTrig_Restart_Timer','InitTrig_Round_start_Epiccenter',
                   'Trig_Restart_Timer_Actions','Trig_Mode_Team_Actions','Trig_Mode_Epiccenter_Actions',
                   'Trig_kill_set_Team_Actions','Trig_kill_set_Epiccenter_Actions','Trig_kill_set_Team2_Actions',
                   'Trig_Start_Func158A','Trig_skin_master_key_Func002A','Trig_Special_Character_Select_Actions']
            todo=roots[:]
            while todo:
                name=todo.pop()
                if name in selected or name not in f:continue
                selected.add(name)
                for call in re.findall(r'\b(\w+)\(',f[name]):
                    if call in f:todo.append(call)
                for callback in re.findall(r'function (\w+)',f[name]):
                    if callback in f:todo.append(callback)
                for trigger in re.findall(r'TriggerExecute\(gg_trg_(\w+)\)',f[name]):todo.append('Trig_'+trigger+'_Actions')
            # Combat round logic is an explicitly instrumented boundary. Startup,
            # sale, hero partitions and original arena-entry statements run fully.
            selected.discard('Trig_Round_start_Epiccenter_Actions')
            source='\n'.join(f[n] for n in f if n in selected)
            python=translate(source)
            (self.out/'Gallery-runtime-test.py').write_text(python)
            compiled=compile(python,'<delivered-gallery-and-original-handlers>','exec')
            self.compiled_cache=(self.script,source,compiled)
            Engine.compiled_cache=self.compiled_cache
        _,source,compiled=Engine.compiled_cache
        exec(compiled,self.e)
        self.e['InitGlobals']()
        # Real map fixtures supplied by its original region/unit generation.
        for name,args in re.findall(r'set (gg_rct_\w+)=Rect\(([^\n]+)\)',self.script):
            try:self.e[name]=self.rect(*[float(v) for v in args.split(',')])
            except ValueError:pass
        for name in re.findall(r'\bgg_unit_\w+',source):
            if not self.e.get(name):self.e[name]=self.unit(15,name.split('_')[2],-7800,12400)
        for name in re.findall(r'\bgg_trg_\w+',source):
            trigger=self.create_trigger();trigger['name']=name
            action='Trig_'+name[7:]+'_Actions'
            if action in self.e:trigger['actions'].append(self.e[action])
            self.e[name]=trigger
        self.e['bj_FORCE_ALL_PLAYERS']=self.h('force',members=set(self.players))
        self.foreach(self.e['bj_FORCE_ALL_PLAYERS'],self.e['Trig_Start_Func158A'],'enum_player')
        self.e['bj_mapInitialPlayableArea']=self.rect(-16000,-16000,16000,16000)
        for p in range(1,13):
            self.e['udg_MarketLocation'][p]=self.loc(p*100,12500)
            self.e['udg_Color'][p]=''
            self.e['udg_Camlock_On'][p]=True
            self.e['udg_Camlock_Distance'][p]=3800
        self.e['udg_System_Gamemode']=10
        self.e['InitTrig_Hero_Select']()
        self.e['InitTrig_Restart_Timer']()
        self.e['InitTrig_Round_start_Epiccenter']()
        system=self.e['gg_trg_kill_set_Team2']
        self.timer_events[self.e['udg_Timer_SystemPolledWait'][0]].append(system)
        self.e['GGVInit']();self.e['GGVStart']()

    def click(self,p,action,value=None):
        u=self.e['GGVControl'][p]
        for slot in range(12):
            if self.e['GGVBindAction'][p*12+slot]==action and (value is None or self.e['GGVBindValue'][p*12+slot]==value):
                raw=self.e['GGVBindRaw'][p*12+slot]
                assert raw in u['abilities'] and raw in self.ui_abilities
                meta=self.ui_abilities[raw]
                assert int.from_bytes(meta['abpx'][4],'little')+4*int.from_bytes(meta['abpy'][4],'little')==slot
                old_events=self.events;self.events={'unit':u,'player':p,'spell':raw}
                self.in_spell=True
                self.e['GGVSpell']()
                self.in_spell=False;self.events=old_events
                assert not u['removed'],'Spell callback destroyed native caster'
                self.e['GGVFlush']()
                return
        raise AssertionError(('unreachable native button',p,action,value,self.e['GGVScreen'][p]))

    def choose(self,p,h):
        self.e['GGVScreen'][p]=2;self.e['GGVRole'][p]=self.data['heroes'][h]['role']
        ordinal=[i for i,v in enumerate(self.data['heroes']) if v['role']==self.data['heroes'][h]['role']].index(h)
        self.e['GGVPage'][p]=ordinal//8;self.e['GGVRender'](p)
        self.click(p,17,h);self.click(p,22);self.click(p,11)


def test(out):
    out=Path(out)
    engine=Engine(out)
    engine.choose(0,15)
    assert engine.e['GGVChoice'][0]==15 and not engine.orders
    engine.e['GGVAction'](0,22,0)
    assert not engine.orders
    engine.click(0,12)
    engine.advance(8)
    assert engine.e['GGVPhase']==2,(engine.e['GGVPhase'],engine.e['GGVStatus'][0])
    hero=engine.e['udg_Player'][1]
    assert hero and hero['raw']=='H00D' and not hero['invulnerable']
    assert engine.e['udg_ISUNITSTARTED'][1] and not engine.e['udg_TESTMODE']
    assert len(engine.orders)==1 and engine.gold[0]==3000
    inventory=len(hero['items']);money=engine.gold[0];registrations=len(engine.registration)
    second=engine.sell(0,'H005')
    assert second['removed'] and engine.e['udg_Player'][1] is hero
    assert len(hero['items'])==inventory and engine.gold[0]==money and len(engine.registration)==registrations
    # The actual cards expose every role, hero, ability and description page.
    browse=Engine(out)
    heroes=skills=pages=0
    for h,entry in enumerate(browse.data['heroes']):
        browse.e['GGVScreen'][0]=2;browse.e['GGVRole'][0]=entry['role']
        ordinal=[i for i,v in enumerate(browse.data['heroes']) if v['role']==entry['role']].index(h)
        browse.e['GGVPage'][0]=ordinal//8;browse.e['GGVRender'](0)
        browse.click(0,17,h);heroes+=1
        assert browse.e['GGVControl'][0]['raw']==entry['controller']
        assert browse.e['GGVControllerType'][h][0].islower(), 'A preview must not enter F1 hero lists'
        for ordinal,skill in enumerate(entry['skills']):
            browse.e['GGVPage'][0]=ordinal//4;browse.e['GGVRender'](0)
            browse.click(0,18,skill['index']);skills+=1
            for page in range(browse.e['GGMSkillTextCount'][skill['index']]):
                assert browse.e['GGVTextPage'][0]==page
                text=browse.e['GGMSkillText'][browse.e['GGMSkillTextStart'][skill['index']]+page]
                assert text and '\ufffd' not in text
                assert all('\udc80'>c or c>'\udcff' for c in ''.join(browse.e['GGVInfo'][0]['items'].values()))
                pages+=1
                if page+1<browse.e['GGMSkillTextCount'][skill['index']]:browse.click(0,24)
            browse.click(0,27)
        browse.click(0,1)
    assert not browse.orders and browse.e['udg_Player'][1] is None

    # Independent reservations, skins, permissions, readiness and a departed host.
    team=Engine(out,(0,1,2))
    team.choose(0,15)
    team.e['SetPlayerUnitAvailableBJ']('H06V',True,1)
    team.e['GGVScreen'][1]=3;team.e['GGVHero'][1]=74;team.e['GGVRender'](1)
    team.click(1,22)
    assert team.e['GGVChoice'][1]==-1, 'Same hero family reserved twice'
    team.choose(1,3)
    team.click(0,12)
    assert team.e['GGVPhase']==0,'Started before the last player was ready'
    team.choose(2,12)
    team.e['GGVLaunch'](1)
    assert team.e['GGVPhase']==0,'Non-host started match'
    team.click(0,12);team.advance(8)
    assert team.e['GGVPhase']==2 and len(team.orders)==3
    for p in team.players:
        assert team.e['udg_ISUNITSTARTED'][p+1] and not team.e['udg_Player'][p+1]['invulnerable']
    assert team.all_ally(0,2) and not team.all_ally(0,1)
    for p in team.players:
        hero=team.e['udg_Player'][p+1]
        team.e['GGVOpen'](p);team.e['GGVAction'](p,22,0);team.e['GGVAction'](p,12,0)
        assert team.e['udg_Player'][p+1] is hero
    assert len(team.orders)==3
    leave=Engine(out,(0,1));leave.choose(0,15);leave.choose(1,3)
    leave.players.remove(0);leave.events={'player':0};leave.e['GGVLeave']()
    assert leave.e['GGVFamilyOwner'][15]==-1 and leave.e['GGVHost']()==1
    leave.click(1,12);leave.advance(8)
    assert leave.e['GGVPhase']==2 and len(leave.orders)==1

    # Both actual mode/score handlers and real sale initialization run. Only
    # Epiccenter's subsequent combat-round action is the declared boundary.
    epic=Engine(out,(0,1))
    epic.click(0,3)
    epic.choose(0,15);epic.choose(1,3)
    epic.click(0,12);epic.advance(8)
    assert epic.e['GGVPhase']==2 and len(epic.orders)==2
    assert epic.boundaries==['Trig_Round_start_Epiccenter_Actions']
    assert epic.e['udg_killgoal']==5
    solo_epic=Engine(out);solo_epic.click(0,3);solo_epic.choose(0,15);solo_epic.click(0,12)
    assert solo_epic.e['GGVPhase']==0
    full=Engine(out,tuple(range(10)))
    for p,h in enumerate(range(10)):full.choose(p,h)
    full.click(0,12);full.advance(8)
    assert full.e['GGVPhase']==2 and len(full.orders)==10
    assert len({full.e['udg_Player'][p+1]['id'] for p in range(10)})==10
    full.e['GetPlayerName']=lambda p:'|cffffcc00Игрок123456789 (Жанна д’Арк — Правительница)|r'
    full.e['GGVOpen'](0)
    full.e['GGVStatus'][0]='Проверка длинных имён, состояния запуска и полного списка игроков.'
    full.e['GGVBoard'](0)
    assert full.e['GGVInfo'][0]['rows']==full.e['GGVInfoRow'][0]

    # A successful native order is not an acknowledgement of initialized hero.
    missing=Engine(out);missing.choose(0,15);missing.missing_sale=True
    missing.click(0,12);missing.advance(32)
    assert missing.e['GGVPhase']==1 and len(missing.orders)==1
    assert missing.e['GGVOpenState'][0] and not missing.e['GGVAcknowledged'][0]
    missing.missing_sale=False;missing.click(0,12);missing.advance(8)
    assert len(missing.orders)==2 and missing.e['GGVPhase']==2
    late=missing.sell(0,'H00D')
    assert late['removed'] and missing.gold[0]==3000,'Late duplicate must not award anything'
    changed=Engine(out);changed.choose(0,15);changed.missing_sale=True
    changed.click(0,12);changed.advance(32);changed.click(0,10)
    changed.choose(0,3);changed.missing_sale=False;changed.click(0,12);changed.advance(8)
    assert changed.e['GGVPhase']==2 and changed.e['udg_Player'][1]['raw']=='H005'
    assert len(changed.orders)==2
    rejected=Engine(out);rejected.choose(0,15);rejected.reject_orders=True
    rejected.click(0,12);rejected.advance(5)
    assert not rejected.orders and not rejected.e['GGVAcknowledged'][0]
    rejected.reject_orders=False;rejected.advance(5)
    assert rejected.e['GGVPhase']==2 and len(rejected.orders)==1
    wrong=Engine(out);wrong.choose(0,15);wrong.click(0,12);wrong.advance(3.2)
    unreserved=wrong.sell(0,'H005')
    assert unreserved['removed'] and wrong.e['udg_Player'][1] is None and wrong.gold[0]==0
    wrong.advance(5)
    assert wrong.e['GGVPhase']==2 and wrong.e['udg_Player'][1]['raw']=='H00D'

    initialized=[];locked=[]
    for h,entry in enumerate(engine.data['heroes']):
        one=Engine(out)
        if one.e['GetPlayerTechMaxAllowed'](0,entry['raw'])==0:
            locked.append(entry['raw'])
            one.e['GGVHero'][0]=h;one.e['GGVScreen'][0]=3;one.e['GGVRender'](0);one.click(0,22)
            assert one.e['GGVChoice'][0]==-1,'Native source lock bypassed'
            # Exercise the source's authorized-unlock branch as a fixture;
            # the menu itself never changes the original unlock permissions.
            if entry['raw']=='H07A':one.e['Trig_Special_Character_Select_Actions']()
            else:one.foreach(one.e['bj_FORCE_ALL_PLAYERS'],one.e['Trig_skin_master_key_Func002A'],'enum_player')
        one.choose(0,h);one.click(0,12);one.advance(8)
        assert one.e['GGVPhase']==2,(h,entry['raw'],one.e['GGVStatus'][0])
        assert one.e['udg_Player'][1] and one.e['GGVAcknowledged'][0] and one.e['udg_ISUNITSTARTED'][1]
        assert len(one.orders)==1,(h,'duplicate native order')
        initialized.append(entry['raw'])
    report=dict(sha256=hashlib.sha256((out/'GGG-RU-GALLERY-FIX.w3x').read_bytes()).hexdigest(),
                nativeWarcraftTested=False,actualOriginalSaleAndPortalHandlers=True,
                singlePlayerOneHeroAndBattleEntry=True,duplicateSaleRejectedBeforeRewards=True,
                heroesTraversed=heroes,skillsTraversed=skills,pagesTraversed=pages,
                arenaPlayersTested=[1,2,3,10],epiccenterPlayersTested=2,
                actualHeroInitializations=initialized,sourceLockedHeroes=locked,
                familyReservationAndHostLeave=True,readyAndHostGates=True,
                sourceTeamAlliancesChecked=True,acceptedOrderNotAcknowledgement=True,
                explicitRetryAndChangedChoiceRecoverMissingSale=True,
                rejectedOrdersRecoverWithoutDuplicateHero=True,unreservedManualSaleRejected=True)
    (out/'Gallery-tests.json').write_text(json.dumps(report,indent=2))
    print(json.dumps(report))


if __name__=='__main__':test(sys.argv[1])

"""Run shipped selectable-card input and scene lifecycle at native boundaries.

The renderer, actual native spell engine and network are not simulated. Source
spell callbacks can be driven by explicit spell events, not substituted FX.
"""
import importlib.util
import hashlib
import json
import math
import re
import sys
from collections import defaultdict
from pathlib import Path

HERE=Path(__file__).resolve().parent
sys.path.insert(0,str(HERE.parent/'gallery'));sys.path.insert(0,str(HERE.parent/'tools'))
from data import slk
from storm import Storm
spec=importlib.util.spec_from_file_location('gallery_runtime',HERE.parent/'gallery/test_runtime.py')
gallery=importlib.util.module_from_spec(spec);spec.loader.exec_module(gallery)


class Studio(gallery.Engine):
    SCRIPT_NAME='Studio.j'
    MAP_NAME='GGG-RU-STUDIO-TEST.w3x'
    EXTRA_PREFIXES=('ST','SD')
    EXTRA_ROOTS=('Trig_Mode_Surv_Actions','Trig_kill_set_Surv_Actions')
    meta_cache={}

    def __init__(self,out,players=(0,),local=0):
        self.unit_specific=[];self.spell_events=[];self.player_names={}
        key=str(Path(out).resolve())
        if key not in self.meta_cache:
            st=Storm();a=st.open(Path(out)/self.MAP_NAME)
            try:abilities=slk(st.read(a,'units\\unitabilities.slk'))
            finally:st.close(a)
            self.meta_cache[key]=abilities
        self.base_abilities=self.meta_cache[key]
        super().__init__(out,players,local)

    def unit(self,p,raw,x=0,y=0,facing=0):
        result=super().unit(p,raw,x,y,facing)
        result['states']={'UNIT_STATE_MAX_LIFE':1000.,'UNIT_STATE_LIFE':1000.,
                          'UNIT_STATE_MAX_MANA':2000.,'UNIT_STATE_MANA':2000.}
        for ability in self.base_abilities.get(raw,{}).get('abillist','').split(','):
            if ability not in ('','_'):result['abilities'][ability]=1
        return result

    def add_ability(self,u,raw):
        u['abilities'][raw]=1
        if raw==self.e.get('SDManaAbility'):u['states']['UNIT_STATE_MAX_MANA']=20000.
        if raw==self.e.get('SDLifeAbility'):
            u['states']['UNIT_STATE_MAX_LIFE']=200000.;u['states']['UNIT_STATE_LIFE']=200000.
        return True

    def enumerate(self,g,predicate,filter_):
        g['members'].clear()
        for u in list(self.units):
            if u['removed'] or not predicate(u):continue
            previous=self.events.get('filter_unit');self.events['filter_unit']=u
            if filter_ is None or filter_():g['members'].append(u)
            self.events['filter_unit']=previous

    def bind_natives(self):
        super().bind_natives();e=self.e
        common=(HERE.parent/'tests/reference/common.j').read_text()
        for kind,name,value in re.findall(r'(?m)^\s*constant\s+(\w+)\s+(\w+)\s*=\s*([^\n]+)',common):
            if name in e:continue
            if 'Convert' in value:e[name]=name
            else:
                try:e[name]=eval(gallery.old.expression(value.split('//')[0].strip()),e)
                except (NameError,TypeError,SyntaxError):pass
        # Shared immutable Blizzard constants use their shipped 1.26 values.
        reference=(HERE.parent/'tests/reference/Blizzard.j').read_text()
        for kind,name,value in re.findall(r'(?m)^\s*constant\s+(\w+)\s+(bj_\w+)\s*=\s*([^\n]+)',reference):
            try:e[name]=eval(gallery.old.expression(value.split('//')[0].strip()),e)
            except (NameError,TypeError,SyntaxError):pass
        def no_op(*args):return None
        def handle_id(h):
            if h is None:return 0
            if isinstance(h,dict):return h['id']
            if isinstance(h,int):return h
            return sum((i+1)*ord(c) for i,c in enumerate(str(h)))
        def save(t,p,c,v):self.hashtable[t,p,c]=v;return True
        def load(t,p,c,default=None):return self.hashtable.get((t,p,c),default)
        def flush(t):
            for key in list(self.hashtable):
                if key[0] is t:self.hashtable.pop(key)
        def own_state(u,state,v):
            if u:u['states'][state]=v
        def effect_target(path,u,point):return self.h('effect',path=path,unit=u,point=point)
        def add_condition(t,c):t['conditions'].append(c);return self.h('triggercondition')
        def tag():return self.h('texttag',text='',visible=False)
        def set_tag(t,text,size):
            if t:t.update(text=text,size=size)
        def set_alliance(p,q,kind,flag):self.alliances[p,q]=3 if flag else 0
        def timer_event(trigger,delay,periodic):
            timer=self.timer();self.timer_events[timer].append(trigger)
            self.timer_start(timer,delay,periodic,None)
            trigger.setdefault('owned_timers',[]).append(timer)
            return self.h('registration',timer=timer)
        def destroy_trigger(trigger):
            for timer in trigger.get('owned_timers',[]):self.pause(timer)
            trigger.update(enabled=False,actions=[],conditions=[])
        def damage(source,target,amount,*flags):
            if target and not target['invulnerable']:
                target['states']['UNIT_STATE_LIFE']-=amount
            return True
        e.update(dict(
            defaultdict=defaultdict,
            GetHandleId=handle_id,HaveSavedBoolean=lambda t,p,c:(t,p,c) in self.hashtable,
            HaveSavedInteger=lambda t,p,c:(t,p,c) in self.hashtable,
            HaveSavedReal=lambda t,p,c:(t,p,c) in self.hashtable,
            SaveBoolean=save,LoadBoolean=lambda t,p,c:load(t,p,c,False),SaveInteger=save,
            SaveReal=save,SaveString=save,LoadStr=lambda t,p,c:load(t,p,c,''),
            SaveTimerHandle=save,LoadTimerHandle=load,SaveTriggerHandle=save,LoadTriggerHandle=load,
            SaveEffectHandle=save,LoadEffectHandle=load,SaveGroupHandle=save,LoadGroupHandle=load,
            SaveUnitHandle=save,LoadUnitHandle=load,SavePlayerHandle=save,LoadPlayerHandle=load,
            SaveLocationHandle=save,LoadLocationHandle=load,FlushParentHashtable=flush,
            RemoveSavedReal=lambda t,p,c:self.hashtable.pop((t,p,c),None),
            CreateTextTag=tag,SetTextTagText=set_tag,SetTextTagPermanent=no_op,
            SetTextTagVisibility=lambda t,v:t.update(visible=v) if t else None,
            SetTextTagColor=no_op,SetTextTagPos=lambda t,x,y,z:t.update(x=x,y=y,z=z) if t else None,
            DestroyTextTag=lambda t:t.update(destroyed=True),
            And=lambda a,b:lambda:(a() if a else True) and (b() if b else True),
            Or=lambda a,b:lambda:(a() if a else False) or (b() if b else False),Not=lambda a:lambda:not a(),
            Filter=lambda c:c,DestroyBoolExpr=no_op,DestroyCondition=no_op,DestroyFilter=no_op,
            TriggerAddCondition=add_condition,TriggerRemoveAction=no_op,
            TriggerEvaluate=lambda t:all(fn() for fn in t['conditions']),
            IsUnitHidden=lambda u:bool(u and u.get('hidden')),ShowUnit=lambda u,v:u.update(hidden=not v),
            SetUnitScale=lambda u,x,y,z:u.update(scale=x),SetUnitX=lambda u,x:u.update(x=x),
            SetUnitY=lambda u,y:u.update(y=y),SetUnitPosition=lambda u,x,y:u.update(x=x,y=y),
            GetUnitFacing=lambda u:u.get('facing',90),SetUnitFacing=lambda u,a:u.update(facing=a),
            GetUnitMoveSpeed=lambda u:u.get('speed',300),SetUnitMoveSpeed=lambda u,s:u.update(speed=s),
            GetUnitState=lambda u,s:u['states'].get(s,0.) if u else 0.,SetUnitState=own_state,
            GetWidgetLife=lambda u:u['states']['UNIT_STATE_LIFE'] if u else 0.,
            GetUnitX=lambda u:u['x'] if u else 0.,GetUnitY=lambda u:u['y'] if u else 0.,
            GetUnitLoc=lambda u:self.loc(u['x'] if u else 0.,u['y'] if u else 0.),
            SetWidgetLife=lambda u,v:own_state(u,'UNIT_STATE_LIFE',v),
            GetUnitFlyHeight=lambda u:u.get('height',0),GetUnitUserData=lambda u:u.get('userdata',0),
            SetUnitUserData=lambda u,v:u.update(userdata=v),
            GetUnitDefaultMoveSpeed=lambda u:300.,GetPlayerHandicap=lambda p:1.,GetPlayerHandicapXP=lambda p:1.,
            GetPlayerAlliance=lambda p,q,k:self.alliances.get((p,q),0)>0,SetPlayerAlliance=set_alliance,
            GetPlayerName=lambda p:self.player_names.get(p,'P'+str(p)),
            GetTriggerEventId=lambda:self.events.get('event','sell'),
            TriggerRegisterUnitEvent=lambda t,u,event:self.unit_specific.append((t,u,event)) or self.h('registration'),
            TriggerRegisterVariableEvent=lambda *args:self.register(*args),
            TriggerRegisterTimerEvent=timer_event,
            DestroyTrigger=destroy_trigger,
            CreateFogModifierRect=lambda *args:self.h('fog'),
            CreateSound=lambda path,*args:self.h('sound',path=path),
            CreateTimerDialog=lambda timer:self.h('timerdialog',timer=timer),
            CreateItem=lambda raw,x,y:self.h('item',raw=raw,x=x,y=y,charges=1,removed=False),
            CreateUnitAtLoc=lambda p,r,l,f:self.unit(p,r,l['x'],l['y'],f),
            AddSpecialEffectLoc=lambda path,l:self.h('effect',path=path,x=l['x'],y=l['y']),
            GetItemTypeId=lambda i:i['raw'] if i and not i.get('removed') else 0,
            GetItemX=lambda i:i['x'],GetItemY=lambda i:i['y'],GetItemCharges=lambda i:i['charges'],
            SetItemPosition=lambda i,x,y:i.update(x=x,y=y),
            GetSpellAbilityUnit=lambda:self.events.get('unit'),
            IsUnitEnemy=lambda u,p:not self.all_ally(u['owner'],p),
            IsPlayerEnemy=lambda p,q:not self.all_ally(p,q),
            IsUnitInGroup=lambda u,g:u in g['members'],IsUnitPaused=lambda u:u['paused'],
            IsUnitVisible=lambda u,p:not u.get('hidden',False),IsVisibleToPlayer=lambda *a:True,
            IsUnitIllusion=lambda u:False,IsTerrainPathable=lambda *a:False,
            IsUnitInRangeXY=lambda u,x,y,r:(u['x']-x)**2+(u['y']-y)**2<=r*r,
            IsUnitInRange=lambda u,v,r:(u['x']-v['x'])**2+(u['y']-v['y'])**2<=r*r,
            IsUnitInRangeLoc=lambda u,l,r:(u['x']-l['x'])**2+(u['y']-l['y'])**2<=r*r,
            GetHeroXP=lambda u:u.get('xp',0),GetHeroSkillPoints=lambda u:u.get('skillpoints',0),
            AddHeroXP=lambda u,xp,eye:u.update(xp=u.get('xp',0)+xp),
            GetUnitDefaultFlyHeight=lambda u:0.,GetUnitCurrentOrder=lambda u:u.get('order',0),
            GetPlayerTechCount=lambda *a:0,GetSoundDuration=lambda s:1000,GetSoundFileDuration=lambda p:1000,
            TimerGetRemaining=lambda t:max(0.,t.get('due',self.clock)-self.clock),
            SaveSoundHandle=save,LoadSoundHandle=load,SaveTextTagHandle=save,LoadTextTagHandle=load,
            SaveStr=save,RemoveSavedHandle=lambda t,p,c:self.hashtable.pop((t,p,c),None),
            MultiboardGetColumnCount=lambda b:b['columns'],MultiboardGetRowCount=lambda b:b['rows'],
            GetObjectName=str,R2S=str,S2R=lambda s:float(s or 0),
            UnitDamageTarget=damage,
            SetHeroStr=lambda u,v,b:u.update(strength=v),SetHeroAgi=lambda u,v,b:u.update(agility=v),
            SetHeroInt=lambda u,v,b:u.update(intelligence=v),
            SetUnitFacingTimed=lambda u,a,t:u.update(facing=a),
            GetCameraTargetPositionX=lambda:0.,GetCameraTargetPositionY=lambda:14500.,
            GetEventDamageSource=lambda:self.events.get('damager'),GetEventDamage=lambda:self.events.get('damage',0.),
            GetIssuedOrderId=lambda:self.events.get('order',0),
            GetOrderPointLoc=lambda:self.loc(self.events.get('tx',650),self.events.get('ty',15100)),
            GetOrderTargetUnit=lambda:self.events.get('target'),GetOrderTargetItem=lambda:self.events.get('item'),
            GetManipulatedItem=lambda:self.events.get('item'),
            UnitItemInSlot=lambda u,i:u['items'][i] if i<len(u['items']) else None,
            UnitAddItem=lambda u,i:u['items'].append(i) or True,
            UnitAddItemById=lambda u,r:self.add_item(r,u),
            GetSpellTargetUnit=lambda:self.events.get('target'),GetSpellTargetX=lambda:self.events.get('tx',650),
            GetSpellTargetY=lambda:self.events.get('ty',15100),GetSpellTargetLoc=lambda:self.loc(self.events.get('tx',650),self.events.get('ty',15100)),
            GetSummoningUnit=lambda:self.events.get('summoner'),GetSummonedUnit=lambda:self.events.get('summoned'),
            GetAttacker=lambda:self.events.get('attacker'),GetDyingUnit=lambda:self.events.get('dying'),
            AddSpecialEffect=lambda path,x,y:self.h('effect',path=path,x=x,y=y),AddSpecialEffectTarget=effect_target,
            CreateRegion=lambda:self.h('region'),RegionAddRect=no_op,DestroyForce=no_op,RemoveRect=no_op,
            RemoveRegion=no_op,RemoveItem=lambda i:i.update(removed=True),RemoveDestructable=no_op,
            DestroyLightning=no_op,DestroyMultiboard=no_op,DestroyQuest=no_op,DialogDestroy=no_op,
            GroupClear=lambda g:g['members'].clear(),
            GroupEnumUnitsInRange=lambda g,x,y,r,f:self.enumerate(g,lambda u:(u['x']-x)**2+(u['y']-y)**2<=r*r,f),
            GroupEnumUnitsInRangeOfLoc=lambda g,l,r,f:self.enumerate(g,lambda u:(u['x']-l['x'])**2+(u['y']-l['y'])**2<=r*r,f),
            GroupEnumUnitsInRect=lambda g,r,f:self.enumerate(g,lambda u:r['a']<=u['x']<=r['c'] and r['b']<=u['y']<=r['d'],f),
            GroupEnumUnitsOfPlayer=lambda g,p,f:self.enumerate(g,lambda u:u['owner']==p,f),
            GetRectMinX=lambda r:r['a'],GetRectMaxX=lambda r:r['c'],GetRectMinY=lambda r:r['b'],GetRectMaxY=lambda r:r['d'],
            RMaxBJ=max,RMinBJ=min,IMaxBJ=max,IMinBJ=min,SquareRoot=math.sqrt,Pow=pow,
            Cos=math.cos,Sin=math.sin,Tan=math.tan,Atan2=math.atan2,Atan=math.atan,
            TriggerRegisterEnterRegion=lambda *args:self.register(*args),TriggerRegisterLeaveRegion=lambda *args:self.register(*args),
            IssueImmediateOrder=lambda u,o:True,IssuePointOrder=lambda u,o,x,y:True,IssueTargetOrder=lambda u,o,target:True,
            IssuePointOrderByIdLoc=lambda u,o,l:True,IssuePointOrderLoc=lambda u,o,l:True,
            IssueImmediateOrderById=lambda u,o:True,
            UnitResetCooldown=no_op,StopSound=no_op,KillSoundWhenDone=no_op,
            EnableUserControl=no_op,EnableSelect=no_op,EnableDragSelect=no_op,
        ))
        # Explicit native rendering/audio boundaries; no FX or spell outcome
        # is synthesized by these presentation-only calls.
        for name in ('AddUnitAnimationProperties','CameraSetSourceNoise','CameraSetSourceNoiseEx',
                     'CameraSetTargetNoise','CameraSetTargetNoiseEx','CameraSetupApplyForceDuration',
                     'MultiboardSetItemIcon','RemoveItemFromAllStock','ResetUnitLookAt',
                     'SetPlayerAbilityAvailable','SetTextTagFadepoint','SetTextTagLifespan',
                     'SetTextTagPosUnit','SetTextTagVelocity','SetUnitAnimationByIndex',
                     'SetUnitAnimationWithRarity','SetUnitLookAt','SetUnitPropWindow','SetUnitTimeScale',
                     'TimerDialogSetTitleColor','UnitRemoveBuffs','UnitRemoveBuffsEx'):
            e[name]=no_op
        # Condition-expression handles are represented as callable objects;
        # they still need stable identities for the scene ownership boundary.
        old_handle=e['GetHandleId']
        e['GetHandleId']=lambda h:id(h) if callable(h) else old_handle(h)
        e['ALLIANCE_PASSIVE']='passive'

    def click(self,p,action,value=None):
        for i in range(self.e['STWidgetCount'][p]):
            index=p*16+i
            if self.e['STWidgetAction'][index]!=action:continue
            if value is not None and self.e['STWidgetValue'][index]!=value:continue
            u=self.e['STWidgets'][index]
            old=self.events;self.events={'player':p,'unit':u,'event':'selected'}
            self.in_spell=True;self.e['STSelected']();self.in_spell=False;self.events=old
            assert not u['removed'],'Removed selected object inside its native input callback'
            self.e['GGVFlush']()
            return
        raise AssertionError(('missing selectable card',p,action,value,self.e['GGVScreen'][p]))

    def choose(self,p,h):
        self.e['GGVScreen'][p]=2;self.e['GGVRole'][p]=self.data['heroes'][h]['role']
        ordinal=[i for i,v in enumerate(self.data['heroes']) if v['role']==self.data['heroes'][h]['role']].index(h)
        self.e['GGVPage'][p]=ordinal//6;self.e['GGVRender'](p)
        self.click(p,17,h);self.click(p,22)

    def spell_event(self,unit,raw,event='effect'):
        """Deliver an explicit engine event, without synthesizing spell damage.

        Actual native order acceptance/cast timing is outside this harness.
        Both the source registered handlers and the effect watcher run here.
        """
        unit_event=self.e['EVENT_UNIT_SPELL_'+event.upper()]
        player_event=self.e['EVENT_PLAYER_UNIT_SPELL_'+event.upper()]
        previous=self.events
        self.events={'unit':unit,'player':unit['owner'],'spell':self.e['SDAbility'](raw),
                     'target':self.e['SDEnemy'],'tx':650.,'ty':15100.,'event':unit_event}
        triggers=[t for t,u,kind in self.unit_specific if u is unit and kind==unit_event]
        triggers += [t for t,p,kind in self.unit_events if p==unit['owner'] and kind==player_event]
        seen=set()
        for trigger in triggers:
            if trigger in seen:continue
            seen.add(trigger)
            self.events['trigger']=trigger
            if trigger['enabled'] and all(fn() for fn in trigger['conditions']):self.execute(trigger)
        self.events=previous
        return len(seen)


def test(out):
    out=Path(out)
    e=Studio(out,(0,1))
    assert e.e['STWidgetCount'][0]==3 and e.e['STWidgetCount'][1]==3
    e.click(1,30)
    assert e.e['GGVScreen'][1]==5
    assert 2 not in [e.e['STWidgetAction'][16+i] for i in range(e.e['STWidgetCount'][1])]
    e.e['GGVAction'](1,28,0);assert e.e['GGVMode']==1
    e.choose(0,15)
    e.click(0,12);assert e.e['GGVPhase']==0,'Started before other player chose'
    e.choose(1,3)
    e.e['GGVLaunch'](1);assert e.e['GGVPhase']==0,'Nonhost started game'
    e.click(0,12);e.advance(8)
    assert e.e['GGVPhase']==2 and len(e.orders)==2 and not e.e['SDActive']
    real_hero=e.e['udg_Player'][1];inventory=len(real_hero['items']);gold=e.gold[0]
    duplicate=e.sell(0,'H005')
    assert duplicate['removed'] and e.e['udg_Player'][1] is real_hero
    assert len(real_hero['items'])==inventory and e.gold[0]==gold
    print('Selectable cards, permissions, readiness and one actual source hero: OK',flush=True)

    modes=[]
    for mode,action,source_mode in [(1,2,1.),(2,3,2.),(3,28,0.)]:
        x=Studio(out,(0,1));x.click(0,30);x.click(0,action)
        x.choose(0,15);x.choose(1,3);x.click(0,12);x.advance(8)
        assert x.e['GGVPhase']==2 and len(x.orders)==2
        assert x.e['udg_System_Gamemode']==source_mode and not x.e['udg_TESTMODE']
        if mode==2:assert x.boundaries==['Trig_Round_start_Epiccenter_Actions']
        else:assert x.e['udg_ISUNITSTARTED'][1] and x.e['udg_ISUNITSTARTED'][2]
        if mode==3:assert not x.all_ally(0,1)
        modes.append(mode)
    for n in (1,3,10):
        x=Studio(out,tuple(range(n)))
        for p in range(n):x.choose(p,p)
        x.click(0,12);x.advance(8)
        assert x.e['GGVPhase']==2 and len(x.orders)==n
    x=Studio(out,(0,1));x.choose(0,15);x.choose(1,3);x.click(0,30);x.click(0,3)
    assert not x.e['GGVReady'][0] and not x.e['GGVReady'][1]
    x.players.remove(0);x.events={'player':0};x.e['GGVLeave']()
    assert x.e['GGVHost']()==1 and x.e['GGVFamilyOwner'][15]==-1
    print('Three original modes, 1/2/3/10 players and departed host: OK',flush=True)

    browse=Studio(out);heroes=skills=pages=0
    for h,entry in enumerate(browse.data['heroes']):
        browse.e['GGVScreen'][0]=2;browse.e['GGVRole'][0]=entry['role']
        ordinal=[i for i,v in enumerate(browse.data['heroes']) if v['role']==entry['role']].index(h)
        browse.e['GGVPage'][0]=ordinal//6;browse.e['GGVRender'](0)
        browse.click(0,17,h);heroes+=1
        for ordinal,skill in enumerate(entry['skills']):
            browse.e['GGVPage'][0]=ordinal//4;browse.e['GGVRender'](0)
            browse.click(0,18,skill['index']);skills+=1
            for page in range(browse.e['GGMSkillTextCount'][skill['index']]):
                assert browse.e['GGVTextPage'][0]==page
                for i in range(4):
                    text=browse.e['STText'][i]['text']
                    assert '\ufffd' not in text and not any(0xdc80<=ord(c)<=0xdcff for c in text)
                    assert len(text.encode())<256,('Native texttag length',h,skill['index'],len(text.encode()))
                pages+=1
                if page+1<browse.e['GGMSkillTextCount'][skill['index']]:browse.click(0,24)
            browse.click(0,27)
        browse.click(0,1)
    assert (heroes,skills,pages)==(81,808,2365)
    assert not browse.orders and browse.e['udg_Player'][1] is None
    print('81 heroes, 808 skill entries and 2365 readable text pages: OK',flush=True)

    scene=Studio(out,(0,1))
    scene.e['GGVScreen'][0]=2;scene.e['GGVRole'][0]=1;scene.e['GGVPage'][0]=0;scene.e['GGVRender'](0)
    scene.click(0,17,15);scene.advance(.2)
    actor=scene.e['SDActor']
    assert scene.e['SDActive'] and scene.e['SDV_udg_Saber_Caster'] is actor
    assert all(scene.e['udg_Player'][p+1] is None for p in range(10))
    assert scene.e['udg_Saber_Caster'] is None
    # An order accepted by a stub is never considered a demonstrated cast.
    scene.advance(2.6)
    assert not scene.e['SDCastSeen'] and 'Не удалось' in scene.e['GGVStatus'][0]
    # Explicit engine events reach real cloned source callbacks and watcher.
    scene.spell_event(actor,'A05Q','channel');scene.spell_event(actor,'A05Q')
    assert scene.e['SDCastSeen']
    scene.click(0,18,147);scene.advance(.2)
    actor=scene.e['SDActor'];effects=scene.e['SDEffectCount']
    scene.spell_event(actor,'A02Y','channel')
    assert scene.e['SDEffectCount']>effects,'Original Saber channel FX did not run'
    scene.spell_event(actor,'A02Y');scene.advance(.1)
    assert scene.e['SDCastSeen'] and not scene.orders and not scene.gold[0]
    owned=[scene.e['SDUnitList'][i] for i in range(scene.e['SDUnitCount'])]
    scene.e['SDStop']()
    assert all(u is None or u['removed'] for u in owned)
    for kind in ('Unit','Timer','Trigger','Effect','Group','Location','Expr'):
        assert scene.e['SD'+kind+'Count']==0,kind
    assert scene.e['SDDirtyCount']==0 and not scene.e['SDRunning'] and not scene.e['SDActive']
    assert scene.e['SDV_udg_Saber_Caster'] is None
    scene.choose(0,15);scene.choose(1,3);scene.click(0,12);scene.advance(8)
    assert scene.e['GGVPhase']==2 and len(scene.orders)==2 and not scene.e['SDActive']
    print('Real isolated source callbacks, cast confirmation, cleanup and subsequent battle: OK',flush=True)

    queue=Studio(out,(0,1))
    for p,h in [(0,15),(1,3)]:
        queue.e['GGVScreen'][p]=2;queue.e['GGVRole'][p]=queue.data['heroes'][h]['role']
        queue.e['GGVPage'][p]=0;queue.e['GGVRender'](p);queue.click(p,17,h)
        if p==0:queue.advance(.2)
    assert queue.e['SDViewer']==0 and 'очереди' in queue.e['GGVStatus'][1]
    queue.advance(7);assert queue.e['SDViewer']==1 and queue.e['SDWatching']==31
    queue.advance(7);assert queue.e['SDViewer']==0 and queue.e['SDWatching']==147
    queue.e['SDStop']()
    print('Two viewers take turns, then advance automatically to next source skill: OK',flush=True)

    report=dict(sha256=hashlib.sha256((out/Studio.MAP_NAME).read_bytes()).hexdigest(),
                nativeWarcraftTested=False,nativeRenderingAndSpellEngineSimulated=False,
                synchronizedSelectionHandlers=True,hostAndReadinessGates=True,
                originalModeHandlers=modes,arenaPlayersTested=[1,2,3,10],
                duplicateHeroRejectedBeforeRewards=True,hostLeave=True,
                heroesTraversed=heroes,skillsTraversed=skills,pagesTraversed=pages,
                actualOriginalSaleAndPortalHandlers=True,
                originalClonedSpellCallbacks=['Saber: A05Q effect','Saber: A02Y channel/effect'],
                castEventRequiredForDemoSuccess=True,sceneResourcesAndSparseArraysCleaned=True,
                battleAfterSceneCleanup=True,roundRobinDemoQueueAndSkillRotation=True)
    (out/'Studio-tests.json').write_text(json.dumps(report,indent=2))
    print(json.dumps(report))


if __name__=='__main__':test(sys.argv[1])

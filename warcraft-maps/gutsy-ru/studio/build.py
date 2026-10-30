"""Build the classic selectable-card UI and isolated original spell rehearsal."""
import hashlib
import ctypes
import importlib.util
import json
import re
import shutil
import struct
import subprocess
import sys
import tempfile
from pathlib import Path

HERE=Path(__file__).resolve().parent;ROOT=HERE.parent
sys.path.insert(0,str(ROOT/'gallery'));sys.path.insert(0,str(ROOT/'tools'))
from storm import Storm
from classic_data import read_objects,write_objects
from data import slk
from catalog import encode_jass
from objects import Codes
from sandbox import compile_namespace,functions
from sandbox_natives import resource_globals,resource_code,RESOURCES
from cards import build as build_cards
from metadata import build as build_metadata

spec=importlib.util.spec_from_file_location('gallery_builder',ROOT/'gallery/build.py')
gallery=importlib.util.module_from_spec(spec);spec.loader.exec_module(gallery)


def data_functions(statements,prefix):
    bodies=[];calls=[]
    for first in range(0,len(statements),60):
        name=prefix+str(first//60)
        bodies.append('function '+name+' takes nothing returns nothing\n'+'\n'.join(statements[first:first+60])+'\nendfunction')
        calls.append('call ExecuteFunc("'+name+'")')
    return '\n'.join(bodies),'\n'.join(calls)


def ui_patch(script,cards,metadata):
    changes=[]
    def replace_fn(name,new):
        nonlocal script
        old=re.search(r'^function '+name+r' takes .*?^endfunction',script,re.M|re.S)[0]
        assert script.count(old)==1
        script=script.replace(old,new,1);changes.append(dict(function=name,before=old,after=new))
    raw=(HERE/'ui.j').read_text();globals_,raw=raw.split('// @@ST_FUNCTIONS@@')
    globals_=globals_.replace('// @@ST_GLOBALS@@','')
    statements=[]
    def rawcode(name,index,value):statements.append('set '+name+'['+str(index)+"]='"+value+"'")
    for key,value in cards['buttons'].items():rawcode('STButtonRaw',key,value)
    for name,key in [('STHeroRaw','heroes'),('STSkillRaw','skills'),('STRoleRaw','roles')]:
        for i,value in enumerate(cards[key]):rawcode(name,i,value)
    statements.append("set STPanelRaw='"+cards['panel']+"'")
    generated,calls=data_functions(statements,'STData')
    raw=raw.replace('// @@ST_DATA@@',calls+'\ncall SDInit()')
    overrides=functions(raw)
    for name in ('GGVCamera','GGVPanel','GGVBoard','GGVRender'):replace_fn(name,overrides.pop(name))
    ready=re.search(r'^function GGVAllReady takes .*?^endfunction',script,re.M|re.S)[0]
    replace_fn('GGVAllReady',ready.replace('return a<=5 and b<=5 and (GGVMode!=2 or (a>0 and b>0))',
        'return GGVMode==3 or (a<=5 and b<=5 and (GGVMode!=2 or (a>0 and b>0)))'))
    helper='\n'.join(overrides.values())
    anchor='function GGVBoard takes integer p returns nothing'
    script=script.replace(anchor,'// STUDIO_UI_HELPERS_BEGIN\n'+generated+'\n'+helper+'\n// STUDIO_UI_HELPERS_END\n'+anchor,1)
    old_action=re.search(r'^function GGVAction takes .*?^endfunction',script,re.M|re.S)[0]
    legacy=old_action.replace('function GGVAction','function GGVLegacyAction',1)
    action='''function GGVAction takes integer p,integer action,integer value returns nothing
local integer h=GGVHero[p]
local integer q=0
if not GGVActive(p) or not GGVOpenState[p] then
return
endif
if action==30 or action==31 then
set GGVScreen[p]=5
if action==31 then
set GGVScreen[p]=6
endif
call SDCancel(p)
call GGVRender(p)
return
elseif action==28 then
if p==GGVHost() and GGVPhase==0 then
set GGVMode=3
set GGVGoal=25
loop
exitwhen q==10
set GGVReady[q]=false
set GGVDirty[q]=true
set q=q+1
endloop
endif
call GGVRender(p)
return
elseif action==32 then
call SDRequest(p,h,GGVSkill[p],2)
return
elseif action==5 and GGVMode==3 then
set GGVMode=1
call GGVLegacyAction(p,action,value)
set GGVMode=3
call GGVRender(p)
return
elseif action==22 then
call GGVLegacyAction(p,action,value)
if GGVChoice[p]==h then
set GGVReady[p]=true
set GGVScreen[p]=6
call SDCancel(p)
call GGVRender(p)
endif
return
endif
call GGVLegacyAction(p,action,value)
if action==17 then
call SDRequest(p,value,GGMHeroSkillStart[value],1)
elseif action==18 then
call SDRequest(p,h,value,2)
elseif GGVScreen[p]!=3 and GGVScreen[p]!=4 then
call SDCancel(p)
endif
endfunction'''
    replace_fn('GGVAction',legacy+'\n'+action)
    old_close=re.search(r'^function GGVClose takes .*?^endfunction',script,re.M|re.S)[0]
    close=old_close.replace('function GGVClose','function GGVLegacyClose',1)
    close+='''
function GGVClose takes integer p returns nothing
local integer i=0
call SDCancel(p)
call STClear(p)
loop
exitwhen i==4
call SetTextTagVisibility(STText[p*4+i],false)
set i=i+1
endloop
if GetLocalPlayer()==Player(p) then
call ShowInterface(true,0)
call EnableDragSelect(true,true)
endif
call GGVLegacyClose(p)
endfunction'''
    replace_fn('GGVClose',close)
    body=re.search(r'^function GGVInit takes .*?^endfunction',script,re.M|re.S)[0]
    replace_fn('GGVInit',body.replace('\nendfunction','\ncall ExecuteFunc("STInit")\nendfunction'))
    camera_tick='''function GGVCameraTick takes nothing returns nothing
local integer p=0
loop
exitwhen p==10
if GGVActive(p) and GGVOpenState[p] then
if STRefresh[p] then
set STRefresh[p]=false
call GGVRender(p)
else
call GGVCamera(p)
if GGVDirty[p] then
call GGVBoard(p)
set GGVDirty[p]=false
endif
endif
endif
set p=p+1
endloop
endfunction'''
    replace_fn('GGVCameraTick',camera_tick)
    launch=re.search(r'^function GGVLaunch takes .*?^endfunction',script,re.M|re.S)[0]
    launch=launch.replace('set GGVPhase=1','call SDStop()\nset GGVPhase=1',1)
    launch=launch.replace('if GGVMode==1 then\ncall TriggerExecute(gg_trg_Mode_Team)\nelse',
        'if GGVMode==3 then\ncall TriggerExecute(gg_trg_Mode_Surv)\nelseif GGVMode==1 then\ncall TriggerExecute(gg_trg_Mode_Team)\nelse')
    launch=launch.replace('call GGVAssignTeams()','if GGVMode!=3 then\ncall GGVAssignTeams()\nendif')
    launch=launch.replace('if GGVMode==1 then\ncall TriggerExecute(gg_trg_kill_set_Team)\nelse',
        'if GGVMode==3 then\ncall TriggerExecute(gg_trg_kill_set_Surv)\nelseif GGVMode==1 then\ncall TriggerExecute(gg_trg_kill_set_Team)\nelse')
    replace_fn('GGVLaunch',launch)
    spawn=re.search(r'^function GGVSpawnTick takes .*?^endfunction',script,re.M|re.S)[0]
    spawn=spawn.replace('if GGVMode==1 then\nset p=0','if GGVMode!=2 then\nset p=0',1)
    hook='if GGVLaunchStep==1 and GGVMode==1 then'
    ffa='''if GGVLaunchStep==1 and GGVMode==3 then
set p=0
loop
exitwhen p==10
if GGVActive(p) and udg_ISUNITSTARTED[p+1] then
set entered=entered+1
endif
set p=p+1
endloop
if entered==GGVCount() then
set GGVPhase=2
call PauseTimer(GGVSpawnTimer)
endif
endif
'''
    replace_fn('GGVSpawnTick',spawn.replace(hook,ffa+hook,1))
    score=re.search(r'^function Trig_kill_set_Surv_Actions takes .*?^endfunction',script,re.M|re.S)[0]
    line=next(l for l in score.splitlines() if l.startswith('set udg_killgoal='))
    replace_fn('Trig_kill_set_Surv_Actions',score.replace(line,'if GGVPendingGoal>0 then\nset udg_killgoal=GGVPendingGoal\nelse\n'+line+'\nendif',1))
    return script,globals_,changes


def build(base,out,pjass):
    base,out=Path(base),Path(out);out.mkdir(parents=True,exist_ok=True)
    # Preserve the audited translation and battle-start changes as the base.
    gallery.build(base,out,pjass)
    print("Studio: translation and battle backend ready",flush=True)
    data=json.loads((out/'Gallery-data.json').read_text())
    st=Storm();arc=st.open(out/'GGG-RU-GALLERY-FIX.w3x')
    try:
        unit_objects=read_objects(st.read(arc,'war3map.w3u'))
        used=set(slk(st.read(arc,'units\\unitdata.slk')))|set(slk(st.read(arc,'units\\abilitydata.slk')))
        for name,leveled in [('war3map.w3u',False),('war3map.w3a',True)]:
            for table in read_objects(st.read(arc,name),leveled):
                for obj in table:used.update([obj['old'].decode(),obj['new'].decode()])
        ui_units,assets,cards=build_cards(st,arc,data,used,out)
        print("Studio: graphical cards rendered",flush=True)
        meta_edits,metadata=build_metadata(st,arc,data,Codes(used))
        print("Studio: spell aliases prepared",flush=True)
        old_import=st.read(arc,'war3map.imp')
        info=st.read(arc,'war3map.w3i')
    finally:st.close(arc)
    arc=st.open(base)
    try:original=st.read(arc,'war3map.j').decode()
    finally:st.close(arc)
    ref=ROOT/'tests/reference'
    print("Studio: compiling isolated original spell logic",flush=True)
    sd_globals,sd_code,sd_report=compile_namespace(original,(ref/'Blizzard.j').read_text(),(ref/'common.j').read_text())
    early=resource_code()+'\n'+(HERE/'scene_base.j').read_text()
    manager=(HERE/'scene_manager.j').read_text();manager_globals,manager=manager.split('// @@SD_MANAGER_FUNCTIONS@@')
    manager_globals=manager_globals.replace('// @@SD_MANAGER_GLOBALS@@','')
    cleanup='\n'.join('call SDClean'+RESOURCES[k][0]+'()' for k in [
        'timer','trigger','unit','effect','lightning','texttag','fogmodifier','group','force','location',
        'rect','region','item','destructable','timerdialog','multiboard','quest','dialog','sound','boolexpr','hashtable'])
    manager=manager.replace('// @@SD_CLEAN_RESOURCES@@',cleanup)
    lines=[]
    for i,(raw,alias) in enumerate(metadata['aliases'].items()):
        lines+=['call SaveInteger(SDMeta,1,'+repr(raw)+','+repr(alias)+')',
                'call SaveInteger(SDMeta,2,'+repr(alias)+','+repr(raw)+')',
                'set SDOriginalAbility['+str(i)+']='+repr(raw),
                'set SDAliasAbility['+str(i)+']='+repr(alias)]
    lines+=['set SDAbilityCount='+str(len(metadata['aliases'])),
            'set SDManaAbility='+repr(metadata['helper']['mana']),
            'set SDLifeAbility='+repr(metadata['helper']['life'])]
    for skill in metadata['skills']:
        idx=str(skill['index'])
        for name,key in [('SDSpellRaw','raw'),('SDSpellActor','actor')]:lines+=['set '+name+'['+idx+']='+repr(skill[key])]
        for name,key in [('SDSpellLevel','level'),('SDSpellTarget','target')]:lines+=['set '+name+'['+idx+']='+str(skill[key])]
        lines+=['set SDSpellOrder['+idx+']='+encode_jass(skill['order']),
                'set SDSpellAlly['+idx+']='+str(skill['ally']).lower()]
    generated,calls=data_functions(lines,'SDMetaData')
    manager=manager.replace('// @@SD_METADATA@@',calls)
    script=(out/'Gallery.j').read_text()
    script=script.replace('CreateTrigger(','SDWorldTrigger(')
    script,ui_globals,changes=ui_patch(script,cards,metadata)
    script=script.replace('endglobals','// STUDIO_GLOBALS_BEGIN\n'+resource_globals()+'\n'+sd_globals+'\n'+manager_globals+'\n'+ui_globals+'\n// STUDIO_GLOBALS_END\nendglobals',1)
    first=script.index('function ');script=script[:first]+'// STUDIO_EARLY_FUNCTIONS_BEGIN\n'+early+'\n// STUDIO_EARLY_FUNCTIONS_END\n'+script[first:]
    marker=script.index('// GALLERY_FUNCTIONS_BEGIN')
    script=script[:marker]+'// STUDIO_FUNCTIONS_BEGIN\n'+sd_code+'\n'+generated+'\n'+manager+'\n// STUDIO_FUNCTIONS_END\n'+script[marker:]
    script=re.sub(r'(?m)^(call SDX_KB\([^\n]+),null\)$',r'\1,false)',script)
    (out/'Studio.j').write_text(script)
    result=subprocess.run([str(pjass),'+shadow',str(ref/'common.j'),str(ref/'Blizzard.j'),str(out/'Studio.j')],stdout=subprocess.PIPE,stderr=subprocess.STDOUT,text=True)
    (out/'Studio-compiler.txt').write_text(result.stdout)
    assert result.returncode==0,result.stdout[-18000:]
    target=out/'GGG-RU-STUDIO-TEST.w3x';shutil.copyfile(out/'GGG-RU-GALLERY-FIX.w3x',target)
    # The original archive has only 4096 hash slots; selectable cards exceed it.
    st.lib.SFileSetMaxFileCount.argtypes=[ctypes.c_void_p,ctypes.c_uint32]
    capacity=st.open(target,False)
    try:assert st.lib.SFileSetMaxFileCount(capacity,16384),'Cannot expand classic MPQ file table'
    finally:st.close(capacity)
    title='GGG RU STUDIO TEST';end=info.index(0,12)
    edits={**meta_edits,'war3map.j':script.encode(),'war3map.w3i':info[:12]+title.encode()+info[end:],
           'war3map.w3u':write_objects([unit_objects[0],unit_objects[1]+ui_units]),
           'war3map.imp':struct.pack('<II',1,struct.unpack_from('<I',old_import,4)[0]+len(assets))+old_import[8:]+b''.join(b'\r'+n.encode()+b'\0' for n in assets)}
    edits.update({name:file.read_bytes() for name,file in assets.items()})
    with tempfile.TemporaryDirectory(prefix='ggg-studio-') as d:st.replace(target,edits,d)
    blob=bytearray(target.read_bytes());end=blob.index(0,8);header=blob[:8]+title.encode()+b'\0'+blob[end+1:end+9]
    blob[:512]=header+bytes(512-len(header));target.write_bytes(blob)
    report=dict(sha256=hashlib.sha256(target.read_bytes()).hexdigest(),bytes=target.stat().st_size,
                nativeWarcraftTested=False,strictJassCompilerClean=True,sandbox=sd_report,
                nativeUiInput='synchronized unit selection',noFrameMemoryWrites=True,
                automaticOriginalSpellDemonstrations=True,gameModes=['arena','epiccenter','ffa'],
                cards=len(ui_units),newAssets=len(assets),aliases=len(metadata['aliases']))
    for name,value in [('Studio-report.json',report),('Studio-cards.json',cards),
                       ('Studio-metadata.json',metadata),('Studio-ui-patches.json',changes)]:
        (out/name).write_text(json.dumps(value,ensure_ascii=False,indent=2))
    print(json.dumps(report,ensure_ascii=False))


if __name__=='__main__':build(*sys.argv[1:4])

"""Build the nonmodal native gallery and keep the original gameplay init path."""
import hashlib
import importlib.util
import json
import re
import shutil
import struct
import subprocess
import sys
import tempfile
from pathlib import Path

HERE=Path(__file__).resolve().parent
ROOT=HERE.parent
sys.path.insert(0,str(ROOT/'tools'))
from storm import Storm
from catalog import encode_jass
from classic_data import read_objects,write_objects
from data import prepare,slk
from objects import build as build_objects
from assets import build as build_assets

spec=importlib.util.spec_from_file_location('old_menu_builder',ROOT/'menu/build_menu.py')
old=importlib.util.module_from_spec(spec);spec.loader.exec_module(old)


def generated_data(data,bindings,generic,floor):
    functions,init,counts=old.generated_data(data)
    lines=[]
    def raw(name,index,value):lines.append(f"set {name}[{index}]='{value}'")
    for h,hero in enumerate(data['heroes']):
        raw('GGVHeroButton',h,hero['button']);raw('GGVControllerType',h,hero['controller'])
        lines.append(f"set GGVFamily[{h}]={hero['family']}")
        for skill in hero['skills']:raw('GGVSkillButton',skill['index'],skill['button'])
    for index,value in bindings:raw('GGVControlRaw',index,value)
    for first in range(0,len(lines),80):
        name='GGVData'+str(first//80)
        functions+=f'\nfunction {name} takes nothing returns nothing\n'+'\n'.join(lines[first:first+80])+'\nendfunction\n'
        init+='\ncall ExecuteFunc("'+name+'")'
    init+=f"\nset GGVGenericType='{generic}'\nset GGVFloorType='{floor}'"
    return functions,init,counts


def portal_clone(script):
    originals=re.findall(r'^function (Trig_Restart_1_\w+) takes nothing returns \w+\n.*?^endfunction',script,re.M|re.S)
    names={name:'GV_'+name[5:] for name in originals}
    clones=[]
    for name,target in names.items():
        body=re.search(r'^function '+name+r' takes .*?^endfunction',script,re.M|re.S)[0]
        body=body.replace('function '+name+' takes nothing','function '+target+' takes player gvPlayer,unit gvPortal',1)
        body=body.replace('GetTriggerPlayer()','gvPlayer').replace('GetTriggerUnit()','gvPortal')
        for source,dest in names.items():body=re.sub(r'\b'+source+r'\(\)',dest+'(gvPlayer,gvPortal)',body)
        assert not re.search(r'GetTrigger(?:Player|Unit)\(',body),name
        clones.append(body)
    assert 'Trig_Restart_1_Actions' in names
    return '\n'.join(clones),len(clones)


def enhance(script,data,bindings,generic,floor):
    script=script.replace('\r\n','\n');patches=[]
    def patch(old,new,label):
        nonlocal script
        assert script.count(old)==1,(label,script.count(old))
        script=script.replace(old,new,1);patches.append(dict(label=label,before=old,after=new))
    def fn(name,transform,label):
        body=re.search(r'^function '+name+r' takes .*?^endfunction',script,re.M|re.S)[0]
        new=transform(body);assert body!=new,label
        patch(body,new,label)
    # Explicit false preserves the original zero branch in nine inherited calls.
    calls=re.findall(r'(?m)^call KB\([^\n]+,null\)$',script);assert len(calls)==9
    for index,call in enumerate(calls):
        new=call[:-5]+'false)';script=script.replace(call,new,1)
        patches.append(dict(label='Typed knockback argument '+str(index+1),before=call,after=new))
    for name in ['Trig_kill_set_Team_Actions','Trig_kill_set_Epiccenter_Actions']:
        def score(body):
            line=next(v for v in body.splitlines() if v.startswith('set udg_killgoal='))
            return body.replace(line,'if GGVPendingGoal>0 then\nset udg_killgoal=GGVPendingGoal\nelse\n'+line+'\nendif',1)
        fn(name,score,'Button goal input: '+name)
    fn('Trig_Mode_Team_Func044C',lambda b: re.sub(r'(?m)^return.*$','return false',b),'Disable implicit multiple-hero solo sandbox')
    def hero(body):
        anchor='local integer i\n'
        guard='if a!=null and udg_Player[1+GetPlayerId(p)]!=null then\ncall RemoveUnit(a)\nreturn\nendif\n'
        guard+='if a!=null and GGVPhase==1 then\nif GGVChoice[GetPlayerId(p)]<0 or GetUnitTypeId(a)!=GGMHeroRaw[GGVChoice[GetPlayerId(p)]] then\ncall RemoveUnit(a)\nreturn\nendif\nendif\n'
        assert anchor in body
        body=body.replace(anchor,anchor+guard,1)
        auto='call StartTimerBJ(udg_Hero_RestartTimer[1],false,.0)'
        assert body.count(auto)==1
        body=body.replace(auto,'if GGVPhase!=1 then\n'+auto+'\nendif')
        return body.replace('\nendfunction','\ncall ExecuteFunc("GGVOnHeroSold")\nendfunction')
    fn('Trig_Hero_Select_Actions',hero,'Reject duplicate heroes; acknowledge full initialization; gate early epic start')
    def startup(body):
        body=body.replace('call QuestMessageBJ(bj_FORCE_ALL_PLAYERS,6,"|c00ff0000Красный игрок|r|c00ffff80, введите «epiccenter», затем «-12», чтобы начать игру.")','call DisplayTimedTextToForce(bj_FORCE_ALL_PLAYERS,8.,"Подготовка открыта. Герой → выбор → готовность → начало боя. Меню: -menu.")')
        return body.replace('\nendfunction','\ncall ExecuteFunc("GGVStart")\nendfunction')
    fn('Trig_Start_Actions',startup,'Start nonmodal preparation after original loading')
    fn('main',lambda b:b.replace('call ConditionalTriggerExecute(gg_trg_Load)','call ExecuteFunc("GGVInit")\ncall ConditionalTriggerExecute(gg_trg_Load)'),'Initialize gallery before original load')
    blank='set bj_forLoopAIndex=1\nset bj_forLoopAIndexEnd=14\nloop\nexitwhen bj_forLoopAIndex>bj_forLoopAIndexEnd\ncall BJDebugMsg(" ")\nset bj_forLoopAIndex=bj_forLoopAIndex+1\nendloop'
    patch(blank,'// Gallery: no empty chat spam.','Remove fourteen empty messages')
    fn('Trig_kill_set_Team2_Actions',lambda b:b.replace('У вас есть 60 секунд, чтобы выбрать героя!.','Подтверждённые герои входят в бой после подготовки.'),'Correct obsolete selection prompt')
    interface=json.loads((HERE/'interface-texts.json').read_text())
    for name in dict.fromkeys(item['function'] for item in interface):
        def polish_interface(body):
            for item in interface:
                if item['function']==name:
                    before,after=encode_jass(item['before']),encode_jass(item['after'])
                    assert body.count(before)==1,(name,item['before'])
                    body=body.replace(before,after,1)
            return body
        fn(name,polish_interface,'Reviewed Russian interface: '+name)
    clones,clone_count=portal_clone(script)
    module=(HERE/'runtime.j').read_text()
    globals_,runtime=module.split('// @@GLOBALS_END@@',1)
    globals_=globals_.replace('// @@GLOBALS_BEGIN@@','')
    generated,init,counts=generated_data(data,bindings,generic,floor)
    runtime=generated+'\n'+clones+'\n'+runtime.replace('// @@DATA_INIT@@',init)
    globalblock='// GALLERY_GLOBALS_BEGIN\n'+globals_+'\n// GALLERY_GLOBALS_END\n'
    functionblock='// GALLERY_FUNCTIONS_BEGIN\n'+runtime+'\n// GALLERY_FUNCTIONS_END\n'
    script=script.replace('endglobals',globalblock+'endglobals',1)
    script=script.replace('function main takes nothing returns nothing',functionblock+'function main takes nothing returns nothing',1)
    counts['parameterizedPortalFunctions']=clone_count
    return script,patches,counts


def build(base,out,pjass):
    base,out=Path(base),Path(out);out.mkdir(parents=True,exist_ok=True)
    st=Storm();arc=st.open(base)
    try:
        names=st.read(arc,'(listfile)').decode().splitlines()
        original={name:st.read(arc,name) for name in names if not name.startswith('(')}
        data,edits,editorial=prepare(st,arc)
        used=set(slk(st.read(arc,'units\\abilitydata.slk')))|set(slk(st.read(arc,'units\\unitdata.slk')))
        original_units=read_objects(st.read(arc,'war3map.w3u'))
        original_abilities=read_objects(st.read(arc,'war3map.w3a'),True)
        for tables in [original_units,original_abilities]:
            for table in tables:
                for obj in table:used.update([obj['old'].decode(),obj['new'].decode()])
        units,abilities,bindings,generic,floor=build_objects(data,used)
        assets=build_assets(st,arc,data,out)
    finally:st.close(arc)
    script,patches,counts=enhance(original['war3map.j'].decode(),data,bindings,generic,floor)
    target=out/'GGG-RU-GALLERY-FIX.w3x';shutil.copyfile(base,target)
    info=original['war3map.w3i'];end=info.index(0,12);title='GGG RU GALLERY FIX'
    edits.update({'war3map.j':script.encode(),'war3map.w3i':info[:12]+title.encode()+info[end:]})
    edits['war3map.w3u']=write_objects([original_units[0],original_units[1]+units])
    edits['war3map.w3a']=write_objects([original_abilities[0],original_abilities[1]+abilities],True)
    oldimp=original.get('war3map.imp')
    if oldimp:
        edits['war3map.imp']=struct.pack('<II',1,struct.unpack_from('<I',oldimp,4)[0]+len(assets))+oldimp[8:]+b''.join(b'\r'+name.encode()+b'\0' for name in assets)
    else:edits['war3map.imp']=struct.pack('<II',1,len(assets))+b''.join(b'\r'+name.encode()+b'\0' for name in assets)
    edits.update({name:path.read_bytes() for name,path in assets.items()})
    with tempfile.TemporaryDirectory(prefix='ggg-gallery-') as d:st.replace(target,edits,d)
    blob=bytearray(target.read_bytes());end=blob.index(0,8);header=blob[:8]+title.encode()+b'\0'+blob[end+1:end+9]
    blob[:512]=header+bytes(512-len(header));target.write_bytes(blob)
    (out/'Gallery.j').write_text(script)
    restored=re.sub(r'(?ms)^// GALLERY_GLOBALS_BEGIN\n.*?^// GALLERY_GLOBALS_END\n','',script)
    restored=re.sub(r'(?ms)^// GALLERY_FUNCTIONS_BEGIN\n.*?^// GALLERY_FUNCTIONS_END\n','',restored)
    for patch in reversed(patches):restored=restored.replace(patch['after'],patch['before'],1)
    assert restored==original['war3map.j'].decode().replace('\r\n','\n'),'Unreviewed gameplay change'
    ref=ROOT/'tests/reference'
    result=subprocess.run([str(pjass),'+shadow',str(ref/'common.j'),str(ref/'Blizzard.j'),str(out/'Gallery.j')],stdout=subprocess.PIPE,stderr=subprocess.STDOUT,text=True)
    (out/'Gallery-compiler.txt').write_text(result.stdout)
    assert result.returncode==0,result.stdout[-16000:]
    arc=st.open(target)
    try:
        for name,value in original.items():assert st.read(arc,name)==edits.get(name,value),name
        for name,path in assets.items():assert st.read(arc,name)==path.read_bytes(),name
        assert st.read(arc,'war3map.wts') is None
        for name,leveled,added in [('war3map.w3u',False,units),('war3map.w3a',True,abilities)]:
            source=read_objects(original[name],leveled);actual=read_objects(st.read(arc,name),leveled)
            assert actual[0]==source[0] and actual[1][:len(source[1])]==source[1]
            assert actual[1][len(source[1]):]==added
    finally:st.close(arc)
    report=dict(**counts,**editorial,sourceBaseSha256=hashlib.sha256(base.read_bytes()).hexdigest(),
                sha256=hashlib.sha256(target.read_bytes()).hexdigest(),bytes=target.stat().st_size,
                nativeWarcraftTested=False,strictJassCompilerClean=True,newControlUnits=len(units),
                newMenuAbilities=len(abilities),newAssets=len(assets),originalFilesRetained=len(original),
                originalObjectStatisticsUnchanged=True,nonmodalNativeCommandCard=True,
                patches=[p['label'] for p in patches])
    (out/'Gallery-report.json').write_text(json.dumps(report,ensure_ascii=False,indent=2))
    (out/'Gallery-data.json').write_text(json.dumps(data,ensure_ascii=False,indent=2))
    (out/'Gallery-patches.json').write_text(json.dumps(patches,ensure_ascii=False,indent=2))
    (out/'Gallery-bindings.json').write_text(json.dumps(dict(bindings=bindings,generic=generic,floor=floor),indent=2))
    print(json.dumps(report,ensure_ascii=False))


if __name__=='__main__':build(*sys.argv[1:4])

"""Exercise callback names and lexical binding after classic-loader reduction."""
from collections import defaultdict
import importlib.util
from pathlib import Path
from types import SimpleNamespace
import sys

HERE=Path(__file__).resolve().parent
sys.path.insert(0,str(HERE))
sys.path.insert(0,str(HERE.parent/'gallery'))
from sandbox import compile_namespace

SOURCE='''globals
integer udg_Value=4
integer array udg_History
integer udg_System_Gamemode=0
real udg_Signal=0.
trigger gg_trg_Signal=null
endglobals
function InitGlobals takes nothing returns nothing
set udg_Value=4
endfunction
function Leaf takes nothing returns boolean
return udg_Value==4
endfunction
function Pinned takes nothing returns boolean
return Leaf()
endfunction
function InitTrig_Signal takes nothing returns nothing
set gg_trg_Signal=CreateTrigger()
call TriggerRegisterVariableEvent(gg_trg_Signal,"udg_Signal",EQUAL,1.)
call TriggerAddCondition(gg_trg_Signal,Condition(function Pinned))
endfunction
function jasshelper__initstructs_test takes nothing returns nothing
endfunction
function Trig_Start_Actions takes nothing returns nothing
set udg_System_Gamemode=0
endfunction
function Trig_Hero_Select_Actions takes nothing returns nothing
local integer udg_Value=99
set udg_History[1]=5
if Leaf() then
set udg_Signal=1.
endif
call EnableTrigger(gg_trg_Signal)
endfunction
'''


def test():
    ref=HERE.parent/'tests/reference'
    declarations,code,report=compile_namespace(SOURCE,(ref/'Blizzard.j').read_text(),(ref/'common.j').read_text())
    spec=importlib.util.spec_from_file_location('gallery_optimizer_test',HERE.parent/'gallery/test_runtime.py')
    gallery=importlib.util.module_from_spec(spec);spec.loader.exec_module(gallery)
    env={'SDActive':True,'SDRunning':False,'SDObjects':object(),'EQUAL':0,
         'defaultdict':defaultdict,'SDRecord':lambda *a:None,
         'SDNewTrigger':lambda:dict(id=1,conditions=[],enabled=True),
         'GetHandleId':lambda t:t['id'],'LoadBoolean':lambda *a:True,
         'EnableTrigger':lambda t:t.update(enabled=True),
         'Condition':lambda fn:fn,'SDTrackExpr':lambda fn:fn,
         'TriggerAddCondition':lambda t,fn:t['conditions'].append(fn)}
    registrations=[]
    env['TriggerRegisterVariableEvent']=lambda t,name,*a:registrations.append((t,name))
    env['ExecuteFunc']=lambda name:env[name]()
    gallery.Engine.init_globals(SimpleNamespace(e=env),declarations)
    exec(compile(gallery.translate(code),'<actual-reduced-namespace>','exec'),env)
    env['SDInitializeBank']()
    env['SDX_Trig_Hero_Select_Actions']()
    def state(name):
        entry=report['privateStorage'][name];value=env[entry['variable']]
        return value if entry['index'] is None else value[entry['index']]
    assert state('udg_Value')==4,'Caller local captured the inlined global'
    assert state('udg_History')[1]==5
    assert state('udg_Signal')==1.,'Source condition did not execute'
    assert report['privateStorage']['udg_Signal']['index'] is None
    assert registrations[0][1]==report['privateStorage']['udg_Signal']['variable']
    callback=registrations[0][0]['conditions'][0]
    assert callback() is True,'Address-taken condition was removed or misbound'
    assert report['inlinedConditions']==1 and report['foldedTriggerInitializers']==1
    print('Reduced namespace: original binding, local shadow, watched real and real callback execution OK')


if __name__=='__main__':test()

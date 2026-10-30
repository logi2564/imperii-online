"""Compile original GGG hero/ability logic into a separate rehearsal namespace.

No replacement spell animation or guessed damage routine is generated here.
The selected original handlers, helpers and timer callbacks are renamed together.
All their mutable globals and Blizzard helper temporaries are private. Native
mutations cross the explicit scene-resource boundary in sandbox_natives.py.
"""
import hashlib
import re
from pathlib import Path

HERE=Path(__file__).resolve().parent
STRING=re.compile(r'"(?:[^"\\]|\\.)*"')
FUNCTION=re.compile(r'^function (\w+) takes (.*?) returns (\w+)\n.*?^endfunction',re.M|re.S)
GLOBAL=re.compile(r'^\s*(constant )?(\w+)\s+(array )?(\w+)(?:\s*=\s*(.*))?$',re.M)


def functions(source):return {m[1]:m[0] for m in FUNCTION.finditer(source.replace('\r\n','\n'))}


def globals_(source):
    header=source[source.index('globals')+7:source.index('endglobals')]
    return {m[4]:dict(type=m[2],array=bool(m[3]),constant=bool(m[1]),initial=m[5])
            for m in GLOBAL.finditer(header) if not m[0].strip().startswith('//')}


def masked(text):return STRING.sub(lambda m:' '*len(m[0]),text)


def default(kind):return '0' if kind=='integer' else '0.' if kind=='real' else 'false' if kind=='boolean' else '""' if kind=='string' else 'null'


def balanced(text,start):
    depth=1;p=start+1
    while depth:
        if text[p]=='[':depth+=1
        elif text[p]==']':depth-=1
        p+=1
    return p


def compile_namespace(source,blizzard,common):
    from sandbox_natives import wrappers
    source=source.replace("\r\n","\n")
    original=functions(source);library=functions(blizzard)
    all_functions={**library,**original}
    all_globals={**globals_(blizzard),**globals_(source)}
    struct=next(n for n in original if n.startswith('jasshelper__initstructs'))
    seed=[]
    for line in original['Trig_Start_Actions'].splitlines():
        if line.startswith('call ') and not line.startswith('call ForForce('):continue
        seed.append(line)
    seed='\n'.join(seed).replace('function Trig_Start_Actions','function SDSeedOriginalStartFields',1)
    all_functions['SDSeedOriginalStartFields']=seed
    roots=['Trig_Hero_Select_Actions',struct,'SDSeedOriginalStartFields']
    selected=set();todo=roots[:]
    while todo:
        name=todo.pop()
        if name in selected or name not in all_functions:continue
        selected.add(name);body=all_functions[name]
        plain=masked(body)
        todo.extend(n for n in re.findall(r'\b(\w+)\s*\(',plain) if n in all_functions)
        todo.extend(n for n in re.findall(r'\bfunction (\w+)',plain) if n in all_functions)
        for target in re.findall(r'\bgg_trg_(\w+)',plain):
            if 'InitTrig_'+target in original:todo.append('InitTrig_'+target)
        todo.extend(re.findall(r'ExecuteFunc\("(\w+)"\)',body))
    selected.discard('InitGlobals')
    code='\n'.join(all_functions[n] for n in selected)
    used=set(re.findall(r'\b[A-Za-z_]\w*\b',masked(code)))&all_globals.keys()
    writes=set(re.findall(r'\bset (\w+)(?:\[|\s*=)',masked(code)))
    # Sound resources are read-only originals; audio mutations/playback are
    # suppressed at the native scene boundary. Immutable engine enums remain
    # the exact original constants, rather than manufacturing invalid handles.
    private={n:v for n,v in all_globals.items() if n in used and not v['constant']
             and not (n.startswith('gg_snd_') and n not in writes)
}
    # Initializers of library globals can themselves name other globals.
    changed=True
    while changed:
        changed=False
        for entry in list(private.values()):
            for n in re.findall(r'\b[A-Za-z_]\w*\b',entry['initial'] or ''):
                if n in all_globals and n not in private and not all_globals[n]['constant']:
                    private[n]=all_globals[n];changed=True
    fn_names={n:'SDX_'+n for n in selected}
    var_names={n:'SDV_'+n for n in private}
    native_signatures={}
    for m in re.finditer(r'(?m)^(?:constant\s+)?native\s+(\w+)\s+takes (.*?)\s+returns (\w+)',common):
        native_signatures[m[1]]=(m[2],m[3])
    direct_calls=set(re.findall(r'\b(\w+)\s*\(',masked(code)))
    native_code,native_names,native_report=wrappers(direct_calls,native_signatures,private)
    rename={**fn_names,**var_names,**native_names}
    def replace(text,locals_=()):
        strings=[]
        def hide(m):
            token=m[0];literal=token[1:-1]
            if literal in fn_names:token='"'+fn_names[literal]+'"'
            elif literal in var_names:token='"'+var_names[literal]+'"'
            strings.append(token);return f'@@{len(strings)-1}@@'
        text=STRING.sub(hide,text)
        text=re.sub(r'\b[A-Za-z_]\w*\b',lambda m:rename.get(m[0],m[0]) if m[0] not in locals_ else m[0],text)
        return re.sub(r'@@(\d+)@@',lambda m:strings[int(m[1])],text)
    arrays={n:i for i,(n,v) in enumerate(private.items()) if v['array']}
    declarations=[]
    for name,v in private.items():
        declarations.append(v['type']+(' array ' if v['array'] else ' ')+var_names[name]+('='+default(v['type']) if not v['array'] else ''))
    # Scalar declaration values are restored before every scene. Array entries
    # are cleared from a list of actually written indexes, never 8192*N sweeps.
    init=[]
    for name,v in private.items():
        if not v['array']:
            init.append('set '+var_names[name]+'='+replace(v['initial'] or default(v['type'])))
    initializers=[]
    for first in range(0,len(init),60):
        name='SDDefaults'+str(first//60)
        initializers.append(f'function {name} takes nothing returns nothing\n'+'\n'.join(init[first:first+60])+'\nendfunction')
    # Release scalar references too, especially hashtables which have no
    # DestroyHashtable native. Clearing must never replay allocating defaults.
    release=['set '+var_names[n]+'='+default(v['type']) for n,v in private.items() if not v['array']]
    release_functions=[]
    for first in range(0,len(release),60):
        release_functions.append('function SDRelease'+str(first//60)+' takes nothing returns nothing\n'+
                                 '\n'.join(release[first:first+60])+'\nendfunction')
    release_functions.append('function SDReleaseBank takes nothing returns nothing\n'+
        '\n'.join('call ExecuteFunc("SDRelease'+str(i)+'")' for i in range(len(release_functions)))+'\nendfunction')
    restore=[]
    for name,index in arrays.items():
        restore.append((index,'set '+var_names[name]+'[SDClearIndex]='+default(private[name]['type'])))
    clear_funcs=[]
    for first in range(0,len(restore),40):
        rows=restore[first:first+40]
        clear_funcs.append('function SDArrayClear'+str(first//40)+' takes nothing returns nothing\n'+
            '\n'.join(('if' if i==0 else 'elseif')+' SDClearId=='+str(index)+' then\n'+statement
                      for i,(index,statement) in enumerate(rows))+'\nendif\nendfunction')
    clear_dispatch=[]
    for first in range(0,len(restore),40):
        rows=restore[first:first+40];clear_dispatch.append(('if' if first==0 else 'elseif')+
            ' SDClearId<='+str(rows[-1][0])+' then\ncall SDArrayClear'+str(first//40)+'()')
    clear_funcs.append('function SDArrayClearDispatch takes nothing returns nothing\n'+'\n'.join(clear_dispatch)+'\nendif\nendfunction')
    clear_funcs.append('function SDArrayClearBatch takes nothing returns nothing\nlocal integer count=0\nloop\nexitwhen SDClearCursor>=SDDirtyCount or count>=80\nset SDClearId=LoadInteger(SDTouches,-1,SDClearCursor)\nset SDClearIndex=LoadInteger(SDTouches,-2,SDClearCursor)\ncall SDArrayClearDispatch()\nset SDClearCursor=SDClearCursor+1\nset count=count+1\nendloop\nendfunction')
    compiled=[];recorded=0
    # Preserve the original definition order (including Blizzard helpers).
    for name,body in all_functions.items():
        if name not in selected:continue
        body='\n'.join(line.strip() for line in body.splitlines())
        if name=='PolledWait':body='function PolledWait takes real duration returns nothing\nreturn\nendfunction'
        match=FUNCTION.match(body);args,returns=match[2],match[3]
        locals_=set(re.findall(r'(?m)^local \w+ (\w+)',body))
        locals_.update(a.strip().split()[-1] for a in args.split(',') if args!='nothing')
        source_lines=body.splitlines();local_end=1
        while local_end<len(source_lines) and (not source_lines[local_end] or source_lines[local_end].startswith(('local ','//'))):local_end+=1
        rows=[replace(source_lines[0],locals_)]+[replace(v,locals_) for v in source_lines[1:local_end]]
        rows+=['local boolean sdPrevious=SDRunning','local integer sdIndex=0',
               'if not SDActive then','return'+(' '+default(returns) if returns!='nothing' else ''),'endif','set SDRunning=true']
        for line in source_lines[local_end:-1]:
            m=re.match(r'set (\w+)\[',line)
            if m and m[1] in arrays:
                end=balanced(line,m.end()-1);index=line[m.end():end-1];rhs=line[end+1:]
                if rhs.strip() not in ('0','0.','0.0','false','null','""'):
                    rows+=['set sdIndex='+replace(index,locals_),
                           'call SDRecord('+str(arrays[m[1]])+',sdIndex)',
                           'set '+var_names[m[1]]+'[sdIndex]='+replace(rhs,locals_)]
                    recorded+=1;continue
            if line.startswith('return'):
                # Returning source expressions can call nested helpers, which
                # must still see the preview boundary flag while evaluating.
                expression=line[6:].strip()
                if expression:
                    # A typed return helper is inserted via a function-local.
                    rows.append('set sdReturn='+replace(expression,locals_))
                rows.append('set SDRunning=sdPrevious and SDActive')
                rows.append('return'+(' sdReturn' if expression else ''))
            else:rows.append(replace(line,locals_))
        rows+=['set SDRunning=sdPrevious and SDActive','endfunction']
        if returns!='nothing':rows.insert(local_end,'local '+returns+' sdReturn='+default(returns))
        compiled.append('\n'.join(rows))
    # Filter InitGlobals, retaining its loop scaffolding and only our globals.
    init_body=original['InitGlobals'];lines=init_body.splitlines();filtered=[]
    init_locals=set(re.findall(r'(?m)^local \w+\s+(\w+)',init_body))
    for line in lines:
        m=re.match(r'set (\w+)',line)
        if m and m[1] not in private and m[1] not in init_locals and m[1] not in ('bj_forLoopAIndex','bj_forLoopAIndexEnd','bj_forLoopBIndex','bj_forLoopBIndexEnd'):continue
        filtered.append(line)
    init_body='\n'.join(filtered).replace('function InitGlobals','function SDOriginalGlobals',1)
    # The initializer has no callbacks or game side effects beyond private data.
    init_body=replace(init_body)
    # Its array writes join the exact same sparse reset list.
    processed=[]
    for line in init_body.splitlines():
        m=re.match(r'set (SDV_\w+)\[',line)
        if m and m[1][4:] in arrays:
            end=balanced(line,m.end()-1);index=line[m.end():end-1];rhs=line[end+1:]
            if rhs.strip() not in ('0','0.','0.0','false','null','""'):
                processed+=['set sdIndex='+index,'call SDRecord('+str(arrays[m[1][4:]])+',sdIndex)',
                            'set '+m[1]+'[sdIndex]='+rhs];continue
        processed.append(line)
    processed.insert(1,'local integer sdIndex=0');init_body='\n'.join(processed)
    init_calls='\n'.join('call ExecuteFunc("SDDefaults'+str(i)+'")' for i in range(len(initializers)))
    init_calls+='\ncall ExecuteFunc("SDOriginalGlobals")\ncall ExecuteFunc("'+fn_names[struct]+'")'
    # All original initialization entries required by referenced trigger handles.
    trigger_inits=[n for n in selected if n.startswith('InitTrig_')]
    trigger_calls='\n'.join('call ExecuteFunc("'+fn_names[n]+'")' for n in sorted(trigger_inits))
    setup=['function SDInitializeBank takes nothing returns nothing',init_calls]
    for n,v in private.items():
        if n.startswith('gg_unit_') and n.split('_')[2][0].islower():
            setup+=['set '+var_names[n]+"=SDNewUnit(Player(13),'"+n.split('_')[2]+"',0,14500,0)",'call ShowUnit('+var_names[n]+',false)']
        if n.startswith('gg_rct_'):setup+=['set '+var_names[n]+'=SDNewRect(-1800,13000,1800,15900)']
    for n in ('bj_mapInitialPlayableArea',):
        if n in private:setup+=['set '+var_names[n]+'=SDNewRect(-1800,13000,1800,15900)']
    for n in ('bj_FORCE_ALL_PLAYERS','udg_ForceA','udg_ForceB'):
        if n in private:
            setup+=['set '+var_names[n]+'=SDNewForce()','call ForceAddPlayer('+var_names[n]+',Player(13))']
            if n!='udg_ForceA':setup+=['call ForceAddPlayer('+var_names[n]+',Player(14))']
    if 'bj_FORCE_PLAYER' in private:
        for i in range(16):setup+=['call SDRecord('+str(arrays['bj_FORCE_PLAYER'])+','+str(i)+')',
                                   'set SDV_bj_FORCE_PLAYER['+str(i)+']=SDNewForce()',
                                   'call ForceAddPlayer(SDV_bj_FORCE_PLAYER['+str(i)+'],SDPlayer('+str(i)+'))']
    if 'udg_MarketLocation' in private:
        setup+=['call SDRecord('+str(arrays['udg_MarketLocation'])+',1)',
                'set SDV_udg_MarketLocation[1]=SDNewLocation(0,14500)']
    for n in ('udg_Hashtable','bj_lastCreatedHashtable'):
        if n in private:setup+=['set '+var_names[n]+'=SDNewHashtable()']
    if 'udg_System_Gamemode' in private:setup+=['set SDV_udg_System_Gamemode=0']
    setup+=[trigger_calls,'call SDX_SDSeedOriginalStartFields()','set SDV_udg_System_Gamemode=0','endfunction']
    scalar_groups='\n'.join(initializers)
    report=dict(originalFunctions=len(original),clonedFunctions=len(selected),privateGlobals=len(private),
                privateArrays=len(arrays),instrumentedArrayWrites=recorded,
                sourceNamespaceSha256=hashlib.sha256(source.encode()).hexdigest(),
                nativeBoundary=native_report,initializationTriggers=len(trigger_inits))
    return '\n'.join(declarations),native_code+'\n'+'\n'.join(clear_funcs+release_functions)+'\n'+scalar_groups+'\n'+init_body+'\n'+'\n'.join(compiled)+'\n'+'\n'.join(setup),report

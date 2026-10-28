"""Namespace and relocate original mission code, without touching strings blindly."""
import json,re
from build import mask
from unified_terrain import material

FUNCTION=re.compile(r'^function (\w+) takes[^\n]*\n[\s\S]*?^endfunction\b',re.M)
TOKEN=re.compile(r'\b[A-Za-z_]\w*\b')
STRING=re.compile(r'"(?:[^"\\]|\\.)*"')

def declarations(script):
    block=script[script.index('globals')+7:script.index('endglobals')]
    return [(m[1],m[2],bool(m[3]),m[4]) for m in re.finditer(r'(?m)^\s*((constant\s+)?[A-Za-z_]\w*)\s+(array\s+)?([A-Za-z_]\w*)',mask(block))]

def namespace(script,names,prefix):
    masked=mask(script);changes=[]
    for m in TOKEN.finditer(masked):
        if m[0] in names:changes.append((m.start(),m.end(),prefix+m[0]))
    # ExecuteFunc and queued trigger names are string-valued references.
    for m in STRING.finditer(script):
        if m[0][1:-1] in names:changes.append((m.start(),m.end(),'"'+prefix+m[0][1:-1]+'"'))
    for start,end,value in sorted(changes,reverse=True):script=script[:start]+value+script[end:]
    return script

def localize(script,strings,raw_map):
    def string(m):
        value=m[0][1:-1];ref=re.fullmatch(r'TRIGSTR_(\d+)',value)
        if ref:return json.dumps(strings.get(int(ref[1]),m[0].encode()).decode(),ensure_ascii=False)
        if len(value)==4 and value.encode() in raw_map:return '"'+raw_map[value.encode()].decode()+'"'
        return m[0]
    changes=[]
    lexical=re.compile(r'//[^\r\n]*|"(?:[^"\\]|\\.)*"|\'(?:[^\'\\]|\\.)*\'')
    for m in lexical.finditer(script):
        if m[0].startswith('"'):changes.append((m.start(),m.end(),string(m)))
        elif m[0].startswith("'") and len(m[0])==6:
            raw=m[0][1:-1].encode();value=raw_map.get(raw)
            if value is None and raw.decode() in __import__('unified_terrain').MATERIALS:value=material(raw)
            if value is not None:changes.append((m.start(),m.end(),"'"+value.decode()+"'"))
    for a,b,value in reversed(changes):script=script[:a]+value+script[b:]
    return script

# Only absolute, numeric arguments are offset. Computed world coordinates such
# as GetUnitX(u)+100 already contain the offset and must never receive it twice.
XY={
 'Location':(0,1),'Rect':(0,1,2,3),
 'CreateUnit':(2,3),'RC_SourceCreate':(2,3),
 'CreateDestructable':(1,2),'CreateDeadDestructable':(1,2),
 'CreateDestructableZ':(1,2),'CreateDeadDestructableZ':(1,2),'CreateItem':(1,2),
 'SetUnitPosition':(1,2),'SetUnitX':(1,),'SetUnitY':(1,),
 'CameraSetupSetDestPosition':(1,2),'DefineStartLocation':(1,2),
 'SetCameraPosition':(0,1),'PanCameraToTimed':(0,1),'PanCameraTo':(0,1),
 'SetSoundPosition':(1,2),'SetItemPosition':(1,2),
 'CreateFogModifierRadius':(2,3),'SetBlight':(1,2),
 'AddSpecialEffect':(1,2),'CreateUbersplat':(0,1),
 'IssuePointOrder':(2,3),'IssuePointOrderById':(2,3),
 'SetCameraBounds':tuple(range(8))}
Y_ONLY={'SetUnitY'}

def arguments(masked,start):
    depth=1;begin=start+1;parts=[]
    for pos in range(start+1,len(masked)):
        c=masked[pos]
        if c=='(':depth+=1
        elif c==')':
            depth-=1
            if depth==0:return parts+[(begin,pos)]
        elif c==',' and depth==1:parts.append((begin,pos));begin=pos+1
    raise ValueError('Unbalanced call in original source')

def relocate(script,dx,dy):
    masked=mask(script);changes=[]
    for m in re.finditer(r'\b([A-Za-z_]\w*)\s*\(',masked):
        name=m[1]
        if name not in XY:continue
        args=arguments(masked,m.end()-1)
        for rank,index in enumerate(XY[name]):
            if index>=len(args):raise ValueError('Missing coordinate argument: '+name)
            a,b=args[index];value=script[a:b].strip()
            if name!='SetCameraBounds' and not re.fullmatch(r'[-+\d.eE ()]+',value):continue
            offset=dy if name in Y_ONLY or rank%2 else dx
            changes.append((a,b,' ('+value+') + '+format(offset,'.1f')+' '))
    # No two selected coordinate arguments may overlap. Nested computed calls
    # are skipped above, which also keeps the emitted expressions straightforward.
    ordered=sorted(changes)
    assert all(ordered[n][1]<=ordered[n+1][0] for n in range(len(ordered)-1))
    for a,b,value in reversed(ordered):script=script[:a]+value+script[b:]
    return script

def source_parts(original,generated,strings,raw_map,terrain,index):
    prefix=f'Z{index:02}_'
    originals={m[1] for m in FUNCTION.finditer(original)}
    names=originals|{d[3] for d in declarations(original)}
    globals_text=original[original.index('globals')+7:original.index('endglobals')]
    functions={m[1]:m[0] for m in FUNCTION.finditer(generated) if m[1] in originals}
    def convert(text):return namespace(relocate(localize(text,strings,raw_map),*terrain.offset),names,prefix)
    converted={name:convert(text) for name,text in functions.items() if name not in {'main','config'}}
    return dict(prefix=prefix,names=names,globals=convert(globals_text),functions=converted,main=convert(functions['main']),config=convert(functions['config']))

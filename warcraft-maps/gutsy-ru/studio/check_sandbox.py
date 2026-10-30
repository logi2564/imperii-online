"""Developer compile probe; does not publish an untested scene runtime."""
import json
import re
import subprocess
import sys
from pathlib import Path

HERE=Path(__file__).resolve().parent
sys.path.insert(0,str(HERE.parent/'gallery'))
from sandbox import compile_namespace
from sandbox_natives import resource_globals,resource_code

def probe(source,out,pjass):
    source,out=Path(source),Path(out);out.mkdir(parents=True,exist_ok=True)
    ref=HERE.parent/'tests/reference'
    raw=source.read_text();bliz=(ref/'Blizzard.j').read_text();common=(ref/'common.j').read_text()
    globals_,functions,report=compile_namespace(raw,bliz,common)
    early=resource_code()+'\n'+(HERE/'scene_base.j').read_text()
    # The world boundary exists before original trigger constructors reference it.
    edited=raw.replace('CreateTrigger(', 'SDWorldTrigger(')
    edited=edited.replace('endglobals',resource_globals()+'\n'+globals_+'\nendglobals',1)
    first=edited.index('function ')
    edited=edited[:first]+early+'\n'+edited[first:]
    main=edited.index('function main takes nothing returns nothing')
    edited=edited[:main]+functions+'\n'+edited[main:]
    # Rehearsal does not call any of the legacy untyped knockback arguments.
    edited=re.sub(r'(?m)^(call (?:SDX_)?KB\([^\n]+),null\)$',r'\1,false)',edited)
    path=out/'Sandbox.j';path.write_text(edited)
    (out/'Sandbox-report.json').write_text(json.dumps(report,indent=2))
    p=subprocess.run([str(pjass),'+shadow',str(ref/'common.j'),str(ref/'Blizzard.j'),str(path)],stdout=subprocess.PIPE,stderr=subprocess.STDOUT,text=True)
    (out/'Sandbox-compiler.txt').write_text(p.stdout)
    print(json.dumps({k:v for k,v in report.items() if k!='nativeBoundary'}))
    print(p.stdout[-20000:])
    return p.returncode

if __name__=='__main__':sys.exit(probe(*sys.argv[1:4]))

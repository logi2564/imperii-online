"""Reject new compiler diagnostics, explicitly retaining original legacy ones."""
import json,re,subprocess,sys
from pathlib import Path
from storm import Storm

source,out,pjass,reference=map(Path,sys.argv[1:5]);st=Storm();diagnostics=[]
for label,map_path in [('Original',source),('Russian',out/'Gutsy-Geoid-Game-RU-v1.0.5.w3x')]:
    h=st.open(map_path)
    try:script=st.read(h,'war3map.j')
    finally:st.close(h)
    path=out/(label+'.j');path.write_bytes(script)
    result=subprocess.run([str(pjass),'+shadow',str(reference/'common.j'),str(reference/'Blizzard.j'),str(path)],stdout=subprocess.PIPE,stderr=subprocess.STDOUT,text=True)
    (out/(label+'-compiler.txt')).write_text(result.stdout)
    errors=re.findall(r':(\d+): (.+)',result.stdout)
    assert len(errors)==9 and all(message=='Cannot convert null to boolean in parameter pat in call to KB' for _,message in errors),(label,result.returncode,errors)
    # Encoding actual newlines inside a source string as \n shifts line
    # numbers. Match each diagnostic to its unchanged function/statement.
    lines=script.decode().split('\n');scope='';scopes=[]
    for line in lines:
        found=re.match(r'^function (\w+) takes',line)
        if found:scope=found[1]
        scopes.append(scope)
    statements=[(scopes[int(n)-1],lines[int(n)-1].strip(),message) for n,message in errors]
    diagnostics.append(dict(lines=errors,statements=statements))
assert diagnostics[0]['statements']==diagnostics[1]['statements'],diagnostics
(out/'Compiler-report.json').write_text(json.dumps(dict(originalLegacyTypeDiagnostics=diagnostics[0],russianLegacyTypeDiagnostics=diagnostics[1],newDiagnostics=0,strictCompilerClean=False,nativeWarcraftTested=False),ensure_ascii=False,indent=2))
print('PASS comparison: all nine original null-to-boolean KB diagnostics remain in the same functions/statements; zero new diagnostics. This is not a clean strict compile or a native-client test.')

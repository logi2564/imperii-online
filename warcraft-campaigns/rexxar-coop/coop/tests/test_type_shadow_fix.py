"""Strict declaration regression and exact-delta candidate checks, not engine QA."""
import hashlib,json,os,re,subprocess,sys
from pathlib import Path
sys.path.insert(0,str(Path(__file__).resolve().parents[1]))
from type_shadow_fix import read_map,retitle,legacy_identifiers,title_config,data_digest,REJECTED_DATA,REJECTED_SCRIPT,REJECTED_METADATA,FILE,TITLE
from test_lobby import execute_config,host_info,problems

out=Path(sys.argv[1]);root=out/'type-fix';ref=Path(__file__).resolve().parent/'reference';pjass=os.environ['PJASS']
def check(path,strict):
    return subprocess.run([pjass]+(['+shadow'] if strict else [])+[str(ref/'common.j'),str(ref/'Blizzard.j'),str(path)],capture_output=True,text=True)

ordinary=check(root/'rejected-B.j',False);strict=check(root/'rejected-B.j',True)
assert ordinary.returncode==0,ordinary.stdout+ordinary.stderr
assert strict.returncode!=0 and 'dialog shadows type' in strict.stdout and 'ability shadows type' in strict.stdout,strict.stdout+strict.stderr
assert strict.stdout.count('shadows type')==2
accepted=check(root/'candidate.j',True);assert accepted.returncode==0,accepted.stdout+accepted.stderr
data=read_map(root/FILE);script=data['war3map.j'].decode()
assert hashlib.sha256(title_config(legacy_identifiers(script),'CHECK B - COOP').encode()).hexdigest()==REJECTED_SCRIPT
assert data_digest(data)==REJECTED_DATA and hashlib.sha256(retitle(data['war3map.w3i'],'SHARED')).hexdigest()==REJECTED_METADATA
lua=root/'config.lua';world=execute_config(script,lua,os.environ.get('DOTNET','dotnet'));assert not problems(host_info(data['war3map.w3i']),world)
assert world.name==TITLE and 'call RC_Bootstrap()' in script
report=json.loads((root/'Type-fix.json').read_text());assert hashlib.sha256((root/FILE).read_bytes()).hexdigest()==report['candidate']['sha256']
assert report['userReported']['AOpensLobby'] and not report['userReported']['BOpensLobby'] and report['nativeWarcraftTested'] is False
proof='PASS: actual user-rejected B script reconstructed by pinned SHA256; ordinary pjass accepts it, +shadow detects exactly dialog/ability type-name collisions; corrected full candidate passes +shadow. Only two gameplay identifiers and identifying title differ; all terrain/assets/objects/lobby data match B. Four-human config executed. Native Warcraft/IrinaBot candidate acceptance is NOT tested.'
(root/'Type-fix-check.txt').write_text(proof+'\n');(root/'Strict-negative-check.txt').write_text(strict.stdout+strict.stderr);print(proof)

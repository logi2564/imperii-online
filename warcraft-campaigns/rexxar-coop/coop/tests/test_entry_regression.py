"""Classic identifier guards and intentionally revised standard-colour lobby."""
import hashlib,json,os,re,subprocess,sys
from pathlib import Path
sys.path.insert(0,str(Path(__file__).resolve().parents[1]))
from storm import Storm
from formats import read_info
from lobby_probe import retitle
out=Path(sys.argv[1]);root=Path(__file__).resolve().parent;fixtures=root/'fixtures';storm=Storm()
# Standard sequential human slots; full NPC/config validation is in test_lobby.
archive=storm.open(out/'Maps/RX6-OrcX01.w3x')
try:info=storm.read(archive,'war3map.w3i');script=storm.read(archive,'war3map.j').decode()
finally:storm.close(archive)
parsed=read_info(info)
assert [p['id'] for p in parsed['players'] if p['controller']==1]==[0,1,2,3]
assert 'call RC_Bootstrap()' in script and 'boolean showDialog' in script and 'integer abilityId' in script
# Catch omission of +shadow using a negative declaration canary as well.
canary=out/'type-canary.j';canary.write_text('function Canary takes boolean dialog returns nothing\n    local integer ability = 0\nendfunction\n')
result=subprocess.run([os.environ['PJASS'],'+shadow',str(root/'reference/common.j'),str(root/'reference/Blizzard.j'),str(canary)],capture_output=True,text=True)
assert result.returncode!=0 and 'dialog shadows type' in result.stdout and 'ability shadows type' in result.stdout
proof='PASS: explicit red/blue/teal/purple roles, full bootstrap and known identifier fixes retained; +shadow rejects deliberate type-shadow canary. Colour/NPC remapping is intentional; native entry of VI still needs client verification.'
(out/'Entry-regression-check.txt').write_text(proof+'\n');print(proof)

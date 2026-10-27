"""Keep native-confirmed C lobby structure while intentionally changing gameplay."""
import hashlib,json,os,re,subprocess,sys
from pathlib import Path
sys.path.insert(0,str(Path(__file__).resolve().parents[1]))
from storm import Storm
from formats import read_info
from lobby_probe import retitle
out=Path(sys.argv[1]);root=Path(__file__).resolve().parent;fixtures=root/'fixtures';storm=Storm()
# Compare the exact accepted lobby, disregarding only the identifying title.
archive=storm.open(out/'Maps/RX4-OrcX01.w3x')
try:info=storm.read(archive,'war3map.w3i');script=storm.read(archive,'war3map.j').decode()
finally:storm.close(archive)
assert retitle(info,'SHARED')==retitle((fixtures/'accepted-C.w3i').read_bytes(),'SHARED')
def config(text):
    text=re.search(r'^function config takes[\s\S]*?^endfunction',text,re.M)[0]
    return re.sub(r'call SetMap(?:Name|Description)\([^\n]*\)','',text)
assert config(script)==config((fixtures/'accepted-C-config.j').read_text())
# Catch omission of +shadow using a negative declaration canary as well.
canary=out/'type-canary.j';canary.write_text('function Canary takes boolean dialog returns nothing\n    local integer ability = 0\nendfunction\n')
result=subprocess.run([os.environ['PJASS'],'+shadow',str(root/'reference/common.j'),str(root/'reference/Blizzard.j'),str(canary)],capture_output=True,text=True)
assert result.returncode!=0 and 'dialog shadows type' in result.stdout and 'ability shadows type' in result.stdout
proof='PASS: first mission retains EXACT native-confirmed C lobby metadata/config except name/description; new gameplay is NOT substituted with stale C bytes. +shadow rejects deliberate type-shadow regression canary. All full mission scripts are checked separately. New gameplay native acceptance still requires client testing.'
(out/'Entry-regression-check.txt').write_text(proof+'\n');print(proof)

"""Check the native-test pair's isolation, not whether Warcraft accepts it."""
import hashlib,json,os,re,struct,sys
from pathlib import Path
sys.path.insert(0,str(Path(__file__).resolve().parents[1]))
from formats import read_info
from storm import Storm
from lobby_probe import retitle
from test_lobby import host_info,execute_config,problems

out=Path(sys.argv[1]);root=out/'entrycheck';storm=Storm();records=[]
for label in ['A-Entry','B-Coop']:
    path=root/(label+'.w3x');a=storm.open(path)
    try:
        names=(storm.read(a,'(listfile)') or b'').decode().splitlines()
        data={name:storm.read(a,name) for name in names if not name.startswith('(')}
    finally:storm.close(a)
    info=data['war3map.w3i'];script=data['war3map.j'].decode();world=execute_config(script,root/'scripts'/(label+'.lua'),os.environ.get('DOTNET','dotnet'))
    assert not problems(host_info(info),world),(label,problems(host_info(info),world))
    cfg=re.search(r'^function config takes[\s\S]*?^endfunction',script,re.M)[0]
    normal_cfg=re.sub(r'call SetMapName\("[^"\n]*"\)','call SetMapName("SHARED")',cfg)
    normal_info=retitle(info,'SHARED')
    records.append((data,normal_cfg,normal_info))
    if label=='A-Entry':
        assert len(script.encode())<20000 and 'function RC_' not in script and 'call RC_' not in script
        assert set(re.findall(r'^function (\w+) takes',script,re.M))=={'main','config'}
    else:assert 'call RC_Bootstrap()' in script and 'function RC_LoadCheckpoint takes' in script
    raw=path.read_bytes();end=raw.index(0,8);assert raw[8:end].decode()==world.name
    assert struct.unpack_from('<I',raw,end+5)[0]==4
assert records[0][1:]==records[1][1:],'Lobby data/config differ beyond the identifying title'
left,right=records[0][0],records[1][0];assert set(left)==set(right)
assert {n for n in left if left[n]!=right[n]}=={'war3map.j','war3map.w3i'}
manifest=json.loads((root/'Entry-check.json').read_text());assert manifest['nativeWarcraftTested'] is False
for row in manifest['maps']:assert hashlib.sha256((root/row['file']).read_bytes()).hexdigest()==row['sha256']
proof='PASS: controlled A/B pair retains identical terrain/assets/objects and identical lobby records/config except identifying titles. A has only main/config; B retains actual co-op code. Four humans and explicit colours checked by executing config; published file hashes verified. Native Warcraft/IrinaBot acceptance is NOT tested.'
(root/'Entry-check.txt').write_text(proof+'\n');print(proof)

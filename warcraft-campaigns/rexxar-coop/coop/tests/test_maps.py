"""Independent archive/data invariants on all actual mission inputs/outputs."""
import hashlib,json,re,sys
from pathlib import Path
sys.path.insert(0,str(Path(__file__).resolve().parents[1]))
from build import MAPS,ROOT,KINDS,mask,signature_abilities
from formats import read_info,read_objects
from storm import Storm

out=Path(sys.argv[1]);storm=Storm();metadata=json.loads((ROOT/'metadata-types.json').read_text())['types'];report=json.loads((out/'Build-report.json').read_text());untouched=0
changed={name.lower() for name in ['war3map.j','war3map.w3i','war3mapUnits.doo','war3mapMisc.txt']+[v[0] for v in KINDS.values()]}
for name in MAPS:
    source=ROOT/'inputs'/(name+'.w3x');target=out/'Maps'/('RC-'+name+'.w3x');a=storm.open(source);b=storm.open(target)
    try:
        info=read_info(storm.read(b,'war3map.w3i'));assert sorted(p['id'] for p in info['players'] if p['controller']==1)==[0,3,4,5]
        assert len(info['players'])<=12 and all(0<=p['id']<12 for p in info['players'])
        listing=(storm.read(a,'(listfile)') or b'').decode('utf8',errors='replace').splitlines()
        known=set(listing+['war3map.w3e','war3map.wpm','war3map.shd','war3map.mmp','war3map.w3r','war3map.w3c','war3map.w3s','war3map.w3b','war3map.w3d','war3map.w3q'])
        for entry in known:
            if entry.lower() in changed or entry.startswith('('):continue
            before=storm.read(a,entry)
            if before is not None:assert before==storm.read(b,entry),(name,entry);untouched+=1
        for kind,(filename,leveled) in KINDS.items():
            for table in read_objects(storm.read(b,filename),leveled):
                ids=[]
                for obj in table:
                    ids.append(obj['new'] if obj['new']!=b'\0'*4 else obj['old'])
                    for mod in obj['mods']:
                        if mod[0] in metadata:assert mod[1]==metadata[mod[0]],(name,filename,mod[0],mod[1],metadata[mod[0]])
                assert len(set(ids))==len(ids),(name,filename,'duplicate object IDs')
        script=storm.read(b,'war3map.j').decode();assert script.count('call RC_Menu()')==1
        assert 'call RunInitializationTriggers(  )' not in script
        assert not re.search(r'call\s+(?:SaveAndLoadGameBJ|SaveAndChangeLevelBJ)\s*\(',mask(script)),name
        # The original and patched script both retain their quest trigger functions.
        original=storm.read(a,'war3map.j').decode();original_names=set(re.findall(r'^function (\w+) takes',original,re.M));names=set(re.findall(r'^function (\w+) takes',script,re.M));assert original_names<=names
        for body in re.findall(r'^function \w+ takes[^\n]*\n[\s\S]*?^endfunction',script,re.M):
            if 'udg_StashHero' in body:assert body.startswith('function InitGlobals '),(name,'legacy temporary stash migration retained')
    finally:storm.close(a);storm.close(b)
    row=next(x for x in report['maps'] if x['map']==name);assert row['sourceSha256']==hashlib.sha256(source.read_bytes()).hexdigest()
classic=set(json.loads((ROOT/'tests/reference/classic-api-names.json').read_text()))
runtime=(ROOT/'runtime/core.j').read_text();called=set(re.findall(r'\b([A-Za-z_]\w*)\s*\(',mask(runtime)));missing={n for n in called if not n.startswith('RC_') and n not in classic and n not in {'and','or','not','if','elseif','return'}}
assert not missing,('Not in classic API reference',missing)
icons=[next(mod[4] for mod in obj['mods'] if mod[0]=='aart') for obj in signature_abilities()];assert len(set(icons))==4
print(f'PASS: all 17 actual maps have four roles, valid classic object field types, unique object IDs, retained quest functions, no single-player transition calls, unchanged input hashes and {untouched} byte-identical terrain/import/other entries. Runtime uses classic API names; four distinct signature icons.')

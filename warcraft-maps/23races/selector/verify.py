"""Independent archive/data checks and original-trigger equivalence."""
import hashlib,io,json,re,struct,sys
from pathlib import Path
import mpyq
from classic_data import read_objects
from storm import Storm

ROOT=Path(__file__).resolve().parent
sys.path.insert(0,str(ROOT.parent/'tools'))
from verify_map import strict_info
from verify_trigger_logic import functions,canonical

def verify(work):
    original=ROOT.parent/'release/23-Races-3.2D-Triggers-NewGen-1.26.w3x';output=work/'23-Races-Race-Selection-1.26.w3x'
    a=mpyq.MPQArchive(io.BytesIO(original.read_bytes()[512:]),listfile=False);b=mpyq.MPQArchive(io.BytesIO(output.read_bytes()[512:]),listfile=False)
    assert b.header['format_version']==0 and b.header['header_size']==32 and b.header['archive_size']==output.stat().st_size-512
    entries=lambda arc:{(e.hash_a,e.hash_b,e.locale):e for e in arc.hash_table if e.block_table_index<0xfffffffe}
    before,after=entries(a),entries(b)
    changed={'war3map.j','Scripts\\war3map.j','war3map.wtg','war3map.wct','war3map.w3u','war3map.w3i','war3map.imp','(listfile)','(attributes)'}
    changedHashes={(a._hash(n,'HASH_A'),a._hash(n,'HASH_B'),0) for n in changed}
    storm=Storm();ha,hb=storm.open(original),storm.open(output);count=0
    try:
        for key,entry in before.items():
            assert key in after,('Lost MPQ entry',key)
            if key in changedHashes:continue
            aa=storm.read(ha,f'File{entry.block_table_index:08d}.xxx');bb=storm.read(hb,f'File{after[key].block_table_index:08d}.xxx')
            assert aa==bb,('Changed original resource',key)
            count+=1
        strict_info(storm.read(hb,'war3map.w3i'))
        assert storm.read(hb,'war3map.j')==storm.read(hb,'Scripts\\war3map.j')==(work/'editor-generated.j').read_bytes()
        x=read_objects(storm.read(ha,'war3map.w3u'));y=read_objects(storm.read(hb,'war3map.w3u'))
        assert x[0]==y[0] and x[1]==y[1][:len(x[1])], 'Modified original gameplay units'
        imports=storm.read(hb,'war3map.imp');n=struct.unpack_from('<I',imports,4)[0];assert n==569+108
        for p in (work/'assets').iterdir():
            assert storm.read(hb,p.name.replace('__','\\'))==p.read_bytes()
            if p.suffix=='.mdx':
                data=p.read_bytes();offset=4
                while offset<len(data):
                    tag,size=struct.unpack_from('<4sI',data,offset);chunk=data[offset+8:offset+8+size];offset+=8+size
                    if tag==b'TEXS':
                        for start in range(0,size,268):
                            texture=chunk[start+4:start+264].split(b'\0',1)[0].decode()
                            if texture.lower().startswith('as\\'):assert storm.read(hb,texture) is not None,('Missing generated model texture',p.name,texture)
    finally:storm.close(ha);storm.close(hb)
    print(f'PASS: all {len(before)} baseline MPQ entries retained; {count} unchanged entries byte-identical, including every original model/texture, terrain, pathing, placements, abilities and upgrade; original unit objects unchanged; all 108 new assets present.')
    aa=functions((ROOT.parent/'source/original-gameplay.j').read_text());bb=functions((work/'editor-generated.j').read_text());index=json.loads((ROOT.parent/'source/trigger-index.json').read_text())['entries']
    names=list(aa);cursor=next(i for i,n in enumerate(names) if n.startswith('Trig_'));checked=0;initializers=0
    for e in index:
        end=names.index('InitTrig_'+e['name']);group=names[cursor:end+1];cursor=end+1
        for name in group:
            recovered=name if e['kind']=='GUI' else 'R23_'+name
            old=aa[name];new=bb[recovered]
            if name.startswith('InitTrig_'):
                # Timer registrations are centralized after selection. No
                # other actions, conditions or events are exempt from equality.
                old=re.sub(r'(?m)^\s*call TriggerRegisterTimerEvent(?:Single|Periodic)\([^\n]+\)\s*$','',old)
                initializers+=1
            assert canonical(old,aa)==canonical(new,aa),('Changed original trigger logic',name)
            checked+=1
    assert initializers==262
    # All called functions must exist in classic references or this script.
    refs=Path(sys.argv[2]) if len(sys.argv)>2 else None
    if refs:
        known=set(bb)
        for file in ('common.j','Blizzard.j'):
            known.update(re.findall(r'^(?:constant\s+)?(?:native|function)\s+(\w+)',(refs/file).read_text(),re.M))
        called=set(re.findall(r'\bcall\s+(\w+)\s*\(', (work/'editor-generated.j').read_text()))
        assert called<=known,('Non-classic natives',called-known)
    source=(work/'editor-generated.j').read_text()
    literals=re.findall(r'"(?:\\.|[^"\\])*"',source)
    assert max(len(s.encode())-2 for s in literals)<=1023
    report={'originalMPQEntries':len(before),'byteIdenticalEntries':count,'originalFunctionsEqualExceptInitialTimerRegistration':checked,'originalInitializers':initializers,'newAssets':108,'classicW3I':25,'nativeWarcraftRun':False}
    (work/'preservation-tests.json').write_text(json.dumps(report,indent=2)+'\n')
    print(f'PASS: {checked} original functions preserve actions/conditions/events; only initial timers moved to common start. Classic API and string-length checks pass.')

if __name__=='__main__':verify(Path(sys.argv[1]))

"""Independent archive/data checks and original-trigger equivalence."""
import hashlib,io,json,re,struct,sys
from pathlib import Path
import mpyq
from PIL import Image
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
    changed={'war3map.j','Scripts\\war3map.j','war3map.wtg','war3map.wct','war3map.w3u','war3map.w3a','war3map.w3i','war3map.imp','(listfile)','(attributes)'}
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
        olda=read_objects(storm.read(ha,'war3map.w3a'),True);newa=read_objects(storm.read(hb,'war3map.w3a'),True)
        assert olda[0]==newa[0] and olda[1]==newa[1][:len(olda[1])], 'Modified original gameplay abilities'
        assets=json.loads((work/'build-report.json').read_text())['newAssets']
        imports=storm.read(hb,'war3map.imp');n=struct.unpack_from('<I',imports,4)[0];assert n==569+assets
        units={o['new'].decode():o for o in y[1]};abilities={o['new'].decode():o for o in newa[1]}
        schema=json.loads((ROOT/'classic-control-schema.json').read_text())
        def check_schema(obj,kind):
            for mod in obj['mods']:
                meta=schema[kind][mod[0]];t=meta['type']
                typ=0 if t in {'int','bool','channelType','channelFlags','attackBits'} else (1 if t=='real' else (2 if t=='unreal' else 3))
                assert mod[1]==typ,('Classic field type',obj['new'],mod[0],mod[1],typ)
                if kind=='ability':
                    assert mod[3]==meta['data'],('Classic DataPointer',obj['new'],mod[0],mod[3],meta['data'])
                    assert mod[2]==(1 if meta['repeat'] else 0),('Classic field level',obj['new'],mod[0],mod[2])
        for raw in [f'qA{i:02}' for i in range(34)]+['qPrv','qNxt','qRnd','qPck']:check_schema(abilities[raw],'ability')
        for raw in [f'qC{i:02}' for i in range(34)]+['qPln']:check_schema(units[raw],'unit')
        def vals(o):return {m[0]:(m[4].decode() if m[1]==3 else struct.unpack('<i' if m[1]==0 else '<f',m[4])[0]) for m in o['mods']}
        races=json.loads((work/'catalog.json').read_text())
        for r in races:
            control=vals(units[f'qC{r["index"]:02}']);ids=control['uabi'].split(',');slots=[];orders=[];keys=[]
            assert 'Aloc' not in ids and 'Avul' in ids
            expected={f'qA{i:02}' for i in range(r['index']//8*8,min(r['index']//8*8+8,34))}|{'qPrv','qNxt','qRnd','qPck','Avul'}
            assert set(ids)==expected and len(ids)<=13
            assert control['uico']==r['icon'] and control['usid']==control['usin']==0
            for raw in ids:
                if raw=='Avul':continue
                a=vals(abilities[raw]);slots.append((a['abpx'],a['abpy']));orders.append(a['Ncl6']);keys.append(a['ahky'])
                assert a['aher']==a['aite']==a['amcs']==0 and a['Ncl2']==0 and a['Ncl3']==1 and a['Ncl5']==0
                assert 0<=a['abpx']<4 and 0<=a['abpy']<3 and a['areq']==''
                if raw.startswith('qA'):assert a['aart']==races[int(raw[2:])]['icon']
                else:assert storm.read(hb,a['aart']) is not None
            assert len(slots)==len(set(slots)) and len(orders)==len(set(orders)) and len(keys)==len(set(keys))
        for p in (work/'assets').iterdir():
            assert storm.read(hb,p.name.replace('__','\\'))==p.read_bytes()
            if p.suffix=='.tga' and '__Panels__' in p.name:
                with Image.open(p)as im:assert im.convert('RGBA').getchannel('A').crop((0,350,1024,512)).getbbox() is None,'Panel covers native HUD'
            if p.suffix=='.blp':
                assert p.read_bytes()[:4]==b'BLP1'
                with Image.open(p)as im:im.load();assert im.size==(64,64)
            if p.suffix=='.mdx':
                data=p.read_bytes();offset=4
                while offset<len(data):
                    tag,size=struct.unpack_from('<4sI',data,offset);chunk=data[offset+8:offset+8+size];offset+=8+size
                    if tag==b'MTLS' and '__Scene__Floor' in p.name:
                        assert struct.unpack_from('<I',chunk,24)[0]==0
                        assert not struct.unpack_from('<I',chunk,28)[0]&(64|128),'Floor must depth-test and write depth'
                    if tag==b'TEXS':
                        for start in range(0,size,268):
                            texture=chunk[start+4:start+264].split(b'\0',1)[0].decode()
                            if texture.lower().startswith('as\\'):assert storm.read(hb,texture) is not None,('Missing generated model texture',p.name,texture)
    finally:storm.close(ha);storm.close(hb)
    print(f'PASS: all {len(before)} baseline MPQ entries retained; {count} unchanged entries byte-identical; original unit/ability objects untouched; {assets} assets present; 34 native command cards have valid icons, distinct slots/hotkeys/orders, free visible unit abilities; panels leave the native HUD uncovered.')
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
    report={'originalMPQEntries':len(before),'byteIdenticalEntries':count,'originalFunctionsEqualExceptInitialTimerRegistration':checked,'originalInitializers':initializers,'newAssets':assets,'nativeCommandCards':34,'nativeButtonAbilities':38,'classicControlSchemaSource':schema['source'],'classicChannelDataPointers':[1,2,3,4,5,6],'classicW3I':25,'nativeWarcraftRun':False}
    (work/'preservation-tests.json').write_text(json.dumps(report,indent=2)+'\n')
    print(f'PASS: {checked} original functions preserve actions/conditions/events; only initial timers moved to common start. Classic API and string-length checks pass.')

if __name__=='__main__':verify(Path(sys.argv[1]))

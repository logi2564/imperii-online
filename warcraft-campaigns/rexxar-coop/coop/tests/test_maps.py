"""Independent archive/data invariants on all actual mission inputs/outputs."""
import hashlib,json,re,sys
from pathlib import Path
sys.path.insert(0,str(Path(__file__).resolve().parents[1]))
from build import MAPS,ROOT,KINDS,mask,classic_strings,FILE_PREFIX
from formats import read_info,read_objects
from storm import Storm

out=Path(sys.argv[1]);storm=Storm();metadata=json.loads((ROOT/'metadata-types.json').read_text())['types'];report=json.loads((out/'Build-report.json').read_text());untouched=0
changed={name.lower() for name in ['war3map.j','war3map.w3i','war3mapUnits.doo','war3mapMisc.txt']+[v[0] for v in KINDS.values()]}
for name in MAPS:
    source=ROOT/'inputs'/(name+'.w3x');target=out/'Maps'/(FILE_PREFIX+name+'.w3x');a=storm.open(source);b=storm.open(target)
    try:
        info=read_info(storm.read(b,'war3map.w3i'));assert sorted(p['id'] for p in info['players'] if p['controller']==1)==[0,1,2,3]
        assert len(info['players'])<=12 and all(0<=p['id']<12 for p in info['players'])
        assert [p['id'] for p in info['players']]==sorted(p['id'] for p in info['players'])
        assert all(0<=p['low']<4096 and 0<=p['high']<4096 for p in info['players'])
        members=0
        for force in info['forces']:
            assert not members&force['members'];members|=force['members']
        assert members==sum(1<<p['id'] for p in info['players'])
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
        import kits
        ability_tables=read_objects(storm.read(b,'war3map.w3a'),True)
        lookup={o['new']:o for o in ability_tables[1]}
        unit_tables=read_objects(storm.read(b,'war3map.w3u'),False)
        for role,hero_id in enumerate(kits.HEROES):
            hero=next(o for o in unit_tables[0] if o['old']==hero_id.encode())
            assert next(m[4].decode() for m in hero['mods'] if m[0]=='uhab')==','.join([kits.learn_id(role,n) for n in range(4)]+['Aamk'])
            orders=[];learn_orders=[]
            for slot in range(4):
                obj=lookup[kits.skill_id(role,slot).encode()]
                assert obj['old']==b'ANcl'
                values={(mod[0],mod[2]):mod[4] for mod in obj['mods']}
                import struct
                assert struct.unpack('<i',values[('aher',0)])[0]==0
                learn={(mod[0],mod[2]):mod[4] for mod in lookup[kits.learn_id(role,slot).encode()]['mods']}
                assert struct.unpack('<i',learn[('aher',0)])[0]==1
                assert struct.unpack('<i',learn[('Ncl3',1)])[0]==0
                assert learn[('ahky',0)]==b'' and learn[('arhk',0)]==values[('arhk',0)]
                assert struct.unpack('<i',values[('Ncl3',1)])[0]==1
                learn_orders.append(learn[('Ncl6',1)])
                assert struct.unpack('<i',values[('alev',0)])[0]==(3 if slot==3 else 5)
                assert struct.unpack('<i',values[('arlv',0)])[0]==(6 if slot==3 else 1)
                orders.append(values[('Ncl6',1)])
            assert len(set(orders))==4,(name,role,'Channel order collision')
            assert len(set(learn_orders))==4 and not set(orders)&set(learn_orders),(name,role,'Hidden learning proxy intercepts cast order')
            for menu_id in [b'R5Sk',b'R5Ta']:
                values={(mod[0],mod[2]):mod[4] for mod in lookup[menu_id]['mods']}
                assert values[('Ncl6',1)] not in orders
                assert values[('Ncl6',1)] not in learn_orders
                assert struct.unpack('<i',values[('aher',0)])[0]==0
        misc=storm.read(b,'war3mapMisc.txt');assert re.search(rb'(?mi)^MaxHeroLevel=20\s*$',misc),(name,'hero level cap not twenty')
        script=storm.read(b,'war3map.j').decode();assert script.count('call RC_Bootstrap()')==1
        # pjass does NOT enforce classic Warcraft's UTF-8 byte literal limit.
        tokens=re.findall(r'//[^\r\n]*|"(?:[^"\\]|\\.)*"',script)
        assert all(len(t[1:-1].encode())<=1023 for t in tokens if t.startswith('"')),(name,'oversized classic literal')
        for fname,body in re.findall(r'^function ((?:RC_|RK_)\w+) takes[^\n]*\n([\s\S]*?)^endfunction',script,re.M):
            assert len(body.encode())<24576,(name,fname,'oversized injected function')
        main=re.search(r'^function main takes[\s\S]*?^endfunction',script,re.M)[0]
        assert 'call RC_Menu()' not in main and 'call RC_Bootstrap()' in main
        assert 'call RunInitializationTriggers(  )' not in script
        assert not re.search(r'call\s+(?:SaveAndLoadGameBJ|SaveAndChangeLevelBJ)\s*\(',mask(script)),name
        # The original and patched script both retain their quest trigger functions.
        original=storm.read(a,'war3map.j').decode();original_names=set(re.findall(r'^function (\w+) takes',original,re.M));names=set(re.findall(r'^function (\w+) takes',script,re.M));assert original_names<=names
        for body in re.findall(r'^function \w+ takes[^\n]*\n[\s\S]*?^endfunction',script,re.M):
            if 'udg_StashHero' in body:assert body.startswith('function InitGlobals '),(name,'legacy temporary stash migration retained')
    finally:storm.close(a);storm.close(b)
    row=next(x for x in report['maps'] if x['map']==name);assert row['sourceSha256']==hashlib.sha256(source.read_bytes()).hexdigest()
classic=set(json.loads((ROOT/'tests/reference/classic-api-names.json').read_text()))
# Preserve Unicode and escaped quotes/backslashes while splitting by serialized
# bytes. This is the loading regression that the generic syntax parser missed.
sample='call SomeNative("'+('Текст\\"\\\\'*180)+'") // "comment stays literal"'
short=classic_strings(sample)
assert short.endswith('// "comment stays literal"') and '" + "' in short
assert all(len(t[1:-1].encode())<=1023 for t in re.findall(r'"(?:[^"\\]|\\.)*"',short))
literal_parts=re.findall(r'"((?:[^"\\]|\\.)*)"',short.split(' //')[0])
assert ''.join(literal_parts)==('Текст\\"\\\\'*180)
runtime='\n'.join(p.read_text() for p in (ROOT/'runtime').glob('*.j'));called=set(re.findall(r'\b([A-Za-z_]\w*)\s*\(',mask(runtime)));missing={n for n in called if not n.startswith(('RC_','RK_')) and n not in classic and n not in {'and','or','not','if','elseif','return'}}
assert not missing,('Not in classic API reference',missing)
from kits import abilities
from talents import TREES
assert sum(len(pair) for tree in TREES for pair in tree)==40
cast_ids={kits.skill_id(role,slot).encode() for role in range(4) for slot in range(4)}
icons=[next(mod[4] for mod in obj['mods'] if mod[0]=='aart') for obj in abilities() if obj['new'] in cast_ids];assert len(icons)==16 and len(set(icons))==16
print(f'PASS: all 17 actual maps: classic object metadata types, unique IDs, four roles, retained quest functions, strict literal sizes, classic API, and {untouched} byte-identical terrain/import entries; sixteen distinct skill icons.')

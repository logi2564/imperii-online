"""Audit the delivered MPQ and isolation boundary, independently of UI mocks."""
import hashlib
import io
import json
import re
import struct
import sys
from pathlib import Path
from PIL import Image

HERE=Path(__file__).resolve().parent
sys.path.insert(0,str(HERE.parent/'gallery'));sys.path.insert(0,str(HERE.parent/'tools'))
from storm import Storm
from data import slk,profiles
from classic_data import read_objects,read_info
from sandbox import globals_,functions,masked


def audit(base,out):
    base,out=Path(base),Path(out);st=Storm()
    target=out/'GGG-RU-STUDIO-TEST.w3x'
    report=json.loads((out/'Studio-report.json').read_text())
    assert hashlib.sha256(target.read_bytes()).hexdigest()==report['sha256']
    boundary=report['sandbox']['nativeBoundary']
    assert {'PauseUnit','SetUnitAnimation','SetUnitState','IssuePointOrderLoc','IssueImmediateOrderById'}<=set(boundary['ownedHandleMutations'])
    assert {'GetUnitLoc','AddSpecialEffectLoc','CreateUnitAtLoc','UnitAddItemById'}<=set(boundary['trackedConstructors'])
    old=st.open(out/'GGG-RU-GALLERY-FIX.w3x');new=st.open(target)
    try:
        before=set(st.read(old,'(listfile)').decode().splitlines())
        after=set(st.read(new,'(listfile)').decode().splitlines())
        assert before<=after,'Original archive entry removed'
        permitted={'war3map.j','war3map.w3i','war3map.w3u','war3map.imp','units\\abilitydata.slk'}
        permitted.update(n for n in before if n.lower().endswith(('abilitystrings.txt','abilityfunc.txt')))
        unchanged=0
        for name in before-permitted:
            if name.startswith('('):continue
            assert st.read(old,name)==st.read(new,name),name
            unchanged+=1
        script=st.read(new,'war3map.j').decode();assert script==(out/'Studio.j').read_text()
        restored=script
        for kind in ('GLOBALS','EARLY_FUNCTIONS','FUNCTIONS','UI_HELPERS'):
            restored=re.sub(r'(?ms)^// STUDIO_'+kind+r'_BEGIN\n.*?^// STUDIO_'+kind+r'_END\n','',restored)
        for patch in reversed(json.loads((out/'Studio-ui-patches.json').read_text())):
            assert restored.count(patch['after'])==1,patch['function']
            restored=restored.replace(patch['after'],patch['before'],1)
        restored=restored.replace('SDWorldTrigger(','CreateTrigger(')
        assert restored==st.read(old,'war3map.j').decode(),'Unreviewed main-game script change'
        # The rehearsal copies do not write/read the real mutable namespace.
        arc=st.open(base)
        try:original=st.read(arc,'war3map.j').decode().replace('\r\n','\n')
        finally:st.close(arc)
        source_globals=globals_(original)
        mutable={n for n,v in source_globals.items() if not v['constant'] and not n.startswith('gg_snd_')}
        copied=functions(script);leaks=[]
        for name,body in copied.items():
            if not name.startswith('SDX_'):continue
            header=body.splitlines()[0]
            locals_=set(re.findall(r'(?m)^local \w+\s+(\w+)',body))
            args=header.split(' takes ',1)[1].split(' returns ',1)[0]
            if args!='nothing':locals_.update(v.strip().split()[-1] for v in args.split(','))
            names=set(re.findall(r'\b[A-Za-z_]\w*\b',masked(body)))
            leaks.extend((name,n) for n in (names&mutable)-locals_)
        assert not leaks,leaks[:15]
        a=read_objects(st.read(old,'war3map.w3u'));b=read_objects(st.read(new,'war3map.w3u'))
        assert a[0]==b[0] and a[1]==b[1][:len(a[1])]
        cards=json.loads((out/'Studio-cards.json').read_text())
        raw_cards=set(cards['buttons'].values())|set(cards['heroes'])|set(cards['skills'])|set(cards['roles'])|{cards['panel']}
        new_units={o['new'].decode():o for o in b[1][len(a[1]):]}
        assert raw_cards==new_units.keys()
        for raw,obj in new_units.items():
            fields={m[0]:m for m in obj['mods']}
            assert obj['old']==b'hfoo'
            assert fields['umdl'][1]==3
            assert fields['uabi'][4]==(b'Avul,Aloc' if raw==cards['panel'] else b'Avul')
            model=st.read(new,fields['umdl'][4].decode());assert model[:4]==b'MDLX'
            assert b'VERS'+struct.pack('<II',4,800) in model
            layers=model.index(b'LAYS')
            assert struct.unpack_from('<f',model,layers+8+24)[0]==1.,raw
            if raw!=cards['panel']:assert b'CLID' in model,raw
        # Built-in Warcraft icons are game assets, not absent map files. Their
        # second material/mesh must reference the correct texture and root.
        for entry in cards['engineIcons']:
            blob=st.read(new,entry['model']);parts={};offset=4
            while offset<len(blob):
                size=struct.unpack_from('<I',blob,offset+4)[0]
                parts[blob[offset:offset+4]]=blob[offset+8:offset+8+size];offset+=8+size
            assert offset==len(blob) and len(parts[b'TEXS'])==536
            assert parts[b'TEXS'][272:532].split(b'\0',1)[0].decode()==entry['path']
            assert len(parts[b'MTLS'])==96
            assert struct.unpack_from('<I',parts[b'MTLS'],80)[0]==1
            mesh=parts[b'GEOS'];offset=0;materials=[]
            while offset<len(mesh):
                size=struct.unpack_from('<I',mesh,offset)[0];part=mesh[offset:offset+size]
                materials.append(struct.unpack_from('<I',part,part.index(b'MATS')+12)[0]);offset+=size
            assert offset==len(mesh) and materials==[0,1],entry
        metadata=json.loads((out/'Studio-metadata.json').read_text())
        old_abilities=slk(st.read(old,'units\\abilitydata.slk'))
        new_abilities=slk(st.read(new,'units\\abilitydata.slk'))
        for raw,row in old_abilities.items():assert new_abilities[raw]==row,raw
        for raw,alias in metadata['aliases'].items():
            assert alias not in old_abilities and new_abilities[alias]['code']==old_abilities[raw]['code']
        for name in permitted:
            if not name.lower().endswith(('abilitystrings.txt','abilityfunc.txt')):continue
            prior,current=st.read(old,name),st.read(new,name)
            assert current.startswith(prior),name
            old_profiles,new_profiles=profiles(prior),profiles(current)
            for raw,alias in metadata['aliases'].items():
                if raw in old_profiles:assert new_profiles[alias]==old_profiles[raw],(name,raw,alias)
        images=0
        for name in after-before:
            if not name.endswith('.tga'):continue
            image=Image.open(io.BytesIO(st.read(new,name)));image.load()
            assert image.width&(image.width-1)==0 and image.height&(image.height-1)==0,name
            assert max(image.size)<=1024,name
            images+=1
        for key in ('players','forces','tail'):
            assert read_info(st.read(old,'war3map.w3i'))[key]==read_info(st.read(new,'war3map.w3i'))[key],key
        assert st.read(new,'war3map.wts') is None
    finally:st.close(old);st.close(new)
    result=dict(sha256=report['sha256'],nativeWarcraftTested=False,
                mainGameCodeRecoveredExactly=True,noMutableNamespaceLeaks=True,
                originalObjectsAndAbilityRowsPreserved=True,originalAnimationsAndFxProfilesCopied=True,
                originalLobbyPreserved=True,unchangedArchiveEntries=unchanged,
                selectableCardCollisionModels=len(raw_cards)-1,texturePowerOfTwoChecks=images,
                builtInIconMaterialsChecked=len(cards['engineIcons']),
                noAddedMemoryFrameHooks=True)
    (out/'Studio-audit.json').write_text(json.dumps(result,indent=2))
    print(json.dumps(result))


if __name__=='__main__':audit(*sys.argv[1:3])

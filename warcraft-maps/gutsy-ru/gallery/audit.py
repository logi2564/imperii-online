"""Independently audit the shipped MPQ, original records and classic UI assets."""
import hashlib
import io
import json
import math
import re
import struct
import sys
from pathlib import Path
from PIL import Image

HERE=Path(__file__).resolve().parent
sys.path.insert(0,str(HERE.parent/'tools'))
from storm import Storm
from classic_data import read_objects,write_objects,read_info
from data import profiles


def value(mod):
    return mod[4].decode() if mod[1]==3 else struct.unpack('<i' if mod[1]==0 else '<f',mod[4])[0]


def audit(base,out):
    base,out=Path(base),Path(out)
    data=json.loads((out/'Gallery-data.json').read_text())
    report=json.loads((out/'Gallery-report.json').read_text())
    target=out/'GGG-RU-GALLERY-FIX.w3x'
    assert report['sha256']==hashlib.sha256(target.read_bytes()).hexdigest()
    assert report['sourceBaseSha256']==hashlib.sha256(base.read_bytes()).hexdigest()
    st=Storm();old=st.open(base);new=st.open(target)
    try:
        before=set(st.read(old,'(listfile)').decode().splitlines())
        after=set(st.read(new,'(listfile)').decode().splitlines())
        assert before<=after
        permitted={'war3map.j','war3map.w3i','war3map.w3u','war3map.w3a','war3map.imp',
                   'units\\campaignunitstrings.txt','units\\campaignabilitystrings.txt'}
        unchanged=0
        for name in before:
            if name.startswith('(') or name in permitted:continue
            assert st.read(old,name)==st.read(new,name),name
            unchanged+=1
        # Exact original script can be recovered by undoing only declared patches.
        delivered=st.read(new,'war3map.j').decode()
        assert delivered==(out/'Gallery.j').read_text()
        restored=re.sub(r'(?ms)^// GALLERY_GLOBALS_BEGIN\n.*?^// GALLERY_GLOBALS_END\n','',delivered)
        restored=re.sub(r'(?ms)^// GALLERY_FUNCTIONS_BEGIN\n.*?^// GALLERY_FUNCTIONS_END\n','',restored)
        for patch in reversed(json.loads((out/'Gallery-patches.json').read_text())):
            assert patch['after'] in restored
            restored=restored.replace(patch['after'],patch['before'],1)
        assert restored==st.read(old,'war3map.j').decode().replace('\r\n','\n')
        oldinfo,newinfo=read_info(st.read(old,'war3map.w3i')),read_info(st.read(new,'war3map.w3i'))
        for key in ('players','forces','tail'):assert oldinfo[key]==newinfo[key],key
        assert st.read(new,'war3map.wts') is None
        schema=json.loads((HERE/'classic-control-schema.json').read_text())
        added={}
        for name,leveled,kind in [('war3map.w3u',False,'unit'),('war3map.w3a',True,'ability')]:
            original=read_objects(st.read(old,name),leveled);actual=read_objects(st.read(new,name),leveled)
            assert original[0]==actual[0] and original[1]==actual[1][:len(original[1])]
            assert write_objects(actual,leveled)==st.read(new,name)
            added[kind]=actual[1][len(original[1]):]
            for obj in added[kind]:
                assert len(obj['new'])==4
                for mod in obj['mods']:
                    field,typ,level,pointer,raw,end=mod
                    assert end==bytes(4)
                    if typ==3:
                        assert '\ufffd' not in raw.decode() and len(raw)<=1023,(obj['new'],field)
                    if field in schema[kind]:
                        entry=schema[kind][field]
                        expected=3 if entry['type'] in ('string','model','icon','char','orderString','modelList','unitList',
                            'abilityList','heroAbilityList','upgradeList','unitRace','techList','intList','moveType',
                            'pathingTexture','shadowTexture','shadowImage') else 1 if entry['type']=='real' else 2 if entry['type']=='unreal' else 0
                        assert typ==expected,(field,typ,expected)
                        assert pointer==entry['data'],(field,pointer,entry['data'])
        assert len(added['unit'])==83 and len(added['ability'])==932
        abilities={obj['new'].decode():{m[0]:m for m in obj['mods']} for obj in added['ability']}
        for raw,fields in abilities.items():
            assert value(fields['aher'])==0 and value(fields['alev'])==1
            assert value(fields['amcs'])==0 and value(fields['acdn'])==0
            assert value(fields['Ncl2'])==0 and value(fields['Ncl3'])==1 and value(fields['Ncl5'])==0
            assert fields['Ncl6'][3]==6
            assert value(fields['aub1']) and 0<=value(fields['abpx'])<4 and 0<=value(fields['abpy'])<3
        changed_fields=0
        for name in ('units\\campaignunitstrings.txt','units\\campaignabilitystrings.txt'):
            a,b=profiles(st.read(old,name)),profiles(st.read(new,name))
            assert a.keys()==b.keys()
            allowed={'name','propernames','tip','ubertip'} if name.endswith('unitstrings.txt') else {'tip','researchtip','ubertip','researchubertip'}
            for section in a:
                assert a[section].keys()==b[section].keys()
                for field in a[section]:
                    prior,current=a[section][field],b[section][field]
                    assert len(prior)==len(current),(section,field,'rank count')
                    if prior!=current:
                        assert field in allowed,(section,field)
                        changed_fields+=1
                        if name.endswith('abilitystrings.txt') and field in ('ubertip','researchubertip'):
                            for x,y in zip(prior,current):
                                assert re.findall(r'<[^>]+>',x)==re.findall(r'<[^>]+>',y),(section,'dynamic values')
                                assert re.findall(r'\d+(?:\.\d+)?',x)==re.findall(r'\d+(?:\.\d+)?',y),(section,'numbers')
                    assert all(len(v.encode())<=1023 for v in current) if field in allowed else True
            assert max(map(len,st.read(new,name).splitlines()))<=4095
        textures=0
        for name in after-before:
            if name.endswith('.tga'):
                im=Image.open(io.BytesIO(st.read(new,name)));im.load()
                assert im.size==(512,256)
                if '\\Panels\\' in name:
                    assert im.mode=='RGBA' and im.getpixel((250,250))[3]==0
                textures+=1
            elif name.endswith('.blp'):
                blob=st.read(new,name)
                assert struct.unpack_from('<4s6I',blob)==(b'BLP1',1,0,64,64,5,1)
                im=Image.open(io.BytesIO(blob));im.load();assert im.size==(64,64)
        model=st.read(new,'GGV\\Scene\\floor.mdx');assert model[:4]==b'MDLX'
        cursor=4;chunks={}
        while cursor<len(model):
            tag,size=struct.unpack_from('<4sI',model,cursor);cursor+=8
            assert cursor+size<=len(model);chunks[tag]=model[cursor:cursor+size];cursor+=size
        assert cursor==len(model) and struct.unpack('<I',chunks[b'VERS'])[0]==800
        assert chunks[b'TEXS'][4:].split(b'\0')[0]==b'GGV\\Scene\\floor.tga'
        for hero in data['heroes']:
            assert hero['controller'][0].islower()
            control=next(u for u in added['unit'] if u['new'].decode()==hero['controller'])
            assert math.isclose(value(next(m for m in control['mods'] if m[0]=='usca')),hero['previewScale'],rel_tol=1e-6)
            for path in [hero['icon'],hero['model']]+[s['icon'] for s in hero['skills']]:
                assert st.read(new,path) is not None or path.lower().startswith(('replaceabletextures\\','units\\','buildings\\','abilities\\')),(hero['name'],path)
    finally:st.close(old);st.close(new)
    result=dict(sha256=report['sha256'],unchangedOriginalFiles=unchanged,
        originalScriptRecoveredExactly=True,originalObjectRecordsPreserved=True,
        originalLobbySlotsAndForcesPreserved=True,classicChannelMetadataVerified=True,
        tooltipsKeepAllRanksNumbersAndDynamicReferences=True,changedDisplayFields=changed_fields,
        newTgaTexturesDecoded=textures,customMdxVersion=800,noWtsDependency=True,
        nativeWarcraftTested=False)
    (out/'Gallery-audit.json').write_text(json.dumps(result,indent=2))
    print(json.dumps(result))


if __name__=='__main__':audit(*sys.argv[1:3])

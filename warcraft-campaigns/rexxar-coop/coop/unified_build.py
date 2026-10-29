#!/usr/bin/env python3
"""Build the experimental single-map campaign atlas for native-client testing."""
import argparse,copy,json,os,re,struct,subprocess
from pathlib import Path
from build import ROOT,MAPS,EXTRA,state_schema,player_remap
from formats import read_info,coop_info,Reader,i,s
from storm import Storm
from unified_catalog import UnifiedCatalog,ALL_KINDS
from unified_script import source_parts
from trigger_strings import parse_campaign_wts,resolve_string,write_wts
import unified_terrain as terrain

def atlas_info(original,title,dx,dy):
    blob,_=coop_info(original,{},[0,1,2,3],title)
    info=read_info(blob);prefix=bytearray(info['prefix']);r=Reader(prefix);r.read(12)
    for _ in range(4):r.s()
    origin=terrain.ORIGIN
    bounds=(origin+1280,origin+768,-origin-1280,-origin-1280,origin+1280,-origin-1280,-origin-1280,origin+768)
    struct.pack_into('<8f4i2i',prefix,r.p,*bounds,6,6,4,8,468,468)
    host=copy.deepcopy(next(p for p in info['players'] if p['id']==0));players=[]
    raw=read_info(original)
    storm=Storm();handle=storm.open(ROOT/'inputs/OrcX01.w3x')
    try:
        strings=parse_campaign_wts(storm.read(handle,'war3map.wts'),'OrcX01')
        source_script=storm.read(handle,'war3map.j').decode()
    finally:storm.close(handle)
    remap=player_remap(source_script,'OrcX01')
    faction_names={remap.get(p['id'],p['id']):resolve_string(p['name'],strings) for p in raw['players'] if p['id']!=0}
    for number in range(12):
        p=copy.deepcopy(next((p for p in info['players'] if p['id']==number),host));p['id']=number
        p['x']=host['x']+dx;p['y']=host['y']+dy;p['low']=0;p['high']=15^(1<<number) if number<4 else 0
        if number<4:p['name']=('Игрок '+str(number+1)+' / выбор героя').encode()
        if number>=4:p.update(controller=2,race=1,flags=1,name=faction_names.get(number,'Нейтральная фракция'.encode()))
        players.append(p)
    forces=[dict(flags=11,members=15,name='Отряд Рексара'.encode())]+[dict(flags=0,members=1<<n,name=faction_names.get(n,'Нейтральная фракция'.encode())) for n in range(4,12)]
    out=bytes(prefix)+i(12)
    for p in players:out+=b''.join(i(p[k]) for k in ['id','controller','race','flags'])+s(p['name'])+struct.pack('<ffii',p['x'],p['y'],p['low'],p['high'])
    out+=i(len(forces))
    for f in forces:out+=i(f['flags'])+i(f['members'])+s(f['name'])
    return out+info['tail']

def prepare(out,missions=None):
    out=Path(out);out.mkdir(parents=True,exist_ok=True);storm=Storm();maps={};terrains=[];paths={};shadows={}
    fields=set(EXTRA)|{v[0] for v in ALL_KINDS.values()}|{'war3map.w3e','war3map.wpm','war3map.shd','war3mapMap.blp'}
    for index,name in enumerate(MAPS):
        path=ROOT/'inputs'/(name+'.w3x');h=storm.open(path)
        try:data={file:storm.read(h,file) for file in fields}
        finally:storm.close(h)
        strings=parse_campaign_wts(data['war3map.wts'],name)
        script=data['war3map.j'].decode().replace('\r\n','\n')
        maps[name]=dict(name=name,index=index,path=path,data=data,script=script,strings=strings)
        terrains.append(terrain.read(name,data['war3map.w3e'],data['war3map.w3i']));paths[name]=data['war3map.wpm'];shadows[name]=data['war3map.shd']
    terrain.arrange(terrains);catalog=UnifiedCatalog(maps);schema=state_schema(maps)
    import unified_world
    layouts=unified_world.layouts(maps)
    (out/'World-layout.json').write_text(json.dumps(layouts,ensure_ascii=False,indent=2))
    for m in maps.values():m['worldLayout']=layouts.get(m['index'])
    merged,cliffs=terrain.merge(terrains,paths,shadows);stage=out/'merged';stage.mkdir(exist_ok=True)
    stages=terrain.preview_stages(terrains,merged)
    (out/'Preview-stages.json').write_text(json.dumps(stages))
    for m in maps.values():m['previewStages']=stages
    for name,blob in merged.items():(stage/name).write_bytes(blob)
    plan={};parts={}
    for t in terrains:
        m=maps[t.name];m['storyCount']=len(schema);m['schema']=schema;m['itemCount']=len(catalog.compact)
        l,b,w,h=t.crop;dx,dy=t.offset
        plan[t.name]=dict(dx=dx,dy=dy,cropLeft=l,cropBottom=b,cropWidth=w,cropHeight=h,sourceX=t.x,sourceY=t.y,atlasX=t.atlas_x,atlasY=t.atlas_y,playable=t.playable,rawMap={k.decode():v.decode() for k,v in catalog.raw_maps[t.name].items()},owners=player_remap(m['script'],t.name))
        plan[t.name]['kindMaps']={kind:{k.decode():v.decode() for k,v in pairs.items()} for kind,pairs in catalog.kind_maps[t.name].items()}
        generated=(Path(missions)/'scripts'/(t.name+'.j')).read_text() if missions else m['script']
        parts[t.name]=source_parts(m['script'],generated,m['strings'],catalog.raw_maps[t.name],t,m['index'])
        target=out/'zone-scripts'/t.name;target.mkdir(parents=True,exist_ok=True)
        (target/'globals.j').write_text(parts[t.name]['globals'])
        (target/'functions.j').write_text('\n\n'.join(parts[t.name]['functions'].values()))
    (out/'Atlas-plan.json').write_text(json.dumps(plan,ensure_ascii=False,indent=2))
    (out/'Atlas-info-template.w3i').write_bytes(atlas_info(maps[MAPS[0]]['data']['war3map.w3i'],'REXXAR VII - ALL LOCATIONS',*terrains[0].offset))
    subprocess.run([os.environ.get('DOTNET','dotnet'),str(ROOT/'Tools/bin/Release/net10.0/Tools.dll'),'atlas-placements',str(ROOT/'inputs'),str(out/'Atlas-plan.json'),str(out/'Atlas-info-template.w3i'),str(stage)],check=True)
    report=dict(status='atlas-geometry-prepared',maps=17,width=480,height=480,palette=[v.decode() for v in terrain.GROUND],cliffs=[v.decode() for v in cliffs],objects={k:len(v) for k,v in catalog.output.items()},nativeGameTested=False)
    (out/'Atlas-preparation.json').write_text(json.dumps(report,ensure_ascii=False,indent=2));print(report)
    return maps,terrains,catalog,schema,parts


def build(out,missions=None):
    import kits,talents,unified_menu,unified_runtime,ctypes as c,hashlib,tempfile
    from formats import field,write_objects
    out=Path(out);maps,terrains,catalog,schema,parts=prepare(out,missions)
    script,zones=unified_runtime.assemble(maps,terrains,catalog,schema)
    (out/'Rexxar-VII.j').write_text(script)
    entries={f.name:f.read_bytes() for f in (out/'merged').iterdir()}
    entries['war3map.j']=script.encode()
    entries.update(unified_menu.assets())
    for kind,(filename,leveled) in ALL_KINDS.items():
        tables=[[],copy.deepcopy(catalog.output[kind])]
        if kind=='unit':
            # Source hero edits (HP/mana/etc) are canonical, not aliases.
            for raw in kits.HEROES:
                obj=next((m['lookup']['unit'][raw.encode()] for m in maps.values() if raw.encode() in m['lookup']['unit']),None)
                if obj:tables[0].append(dict(old=raw.encode(),new=b'\0'*4,mods=copy.deepcopy(obj['mods'])))
            kits.apply_heroes(tables);tables[1]+=kits.unit_helpers()+unified_menu.objects()[1]
        if kind=='ability':
            tables[1]+=kits.abilities()+unified_menu.objects()[0]
            mods=[field('arpx',0,0),field('arpy',0,1),field('abpx',0,0),field('abpy',0,1),field('alev',0,10),field('arlv',0,1),field('alsk',0,2)]
            for rank in range(1,11):mods += [field('Istr',0,3*rank,rank),field('Iagi',0,3*rank,rank),field('Iint',0,3*rank,rank),field('Ihid',0,1,rank),field('atp1',3,'Характеристики — ранг '+str(rank),rank),field('aub1',3,'+3 к силе, ловкости и интеллекту за ранг.',rank)]
            tables[0].append(dict(old=b'Aamk',new=b'\0'*4,mods=mods))
        if kind=='upgrade':tables[1]+=talents.upgrades()
        entries[filename]=write_objects(tables,leveled)
    # Script/object strings from all zones are inline. The W3I loading-screen
    # and author metadata still reference the first source mission's WTS.
    entries['war3map.wts']=write_wts(maps[MAPS[0]]['strings'])
    entries['war3mapMisc.txt']=b'[Misc]\r\nMaxHeroLevel=20\r\nHeroMaxLevel=20\r\n'
    from unified_minimap import render
    entries['war3mapMap.tga']=render(terrains,maps)
    target=out/'Maps/Rexxar-VII-Coop-1.26.w3x';target.parent.mkdir(exist_ok=True)
    storm=Storm();storm.lib.SFileCreateArchive.argtypes=[c.c_char_p,c.c_uint32,c.c_uint32,c.POINTER(c.c_void_p)]
    with tempfile.TemporaryDirectory(prefix='rx-atlas-') as folder:
        mpq=Path(folder)/'map.mpq';handle=c.c_void_p()
        if not storm.lib.SFileCreateArchive(os.fsencode(mpq),0,128,c.byref(handle)):raise OSError('Cannot create atlas MPQ')
        storm.close(handle);storm.replace(mpq,entries,folder)
        parsed=read_info(entries['war3map.w3i']);flags=struct.unpack_from('<i',parsed['prefix'],parsed['flags_offset'])[0]
        header=b'HM3W'+i(0)+s('REXXAR VII TEST - 1 TO 4')+i(flags)+i(4)
        target.write_bytes(header+bytes(512-len(header))+mpq.read_bytes())
    verify=storm.open(target)
    try:
        for name,data in entries.items():assert storm.read(verify,name)==data,name
    finally:storm.close(verify)
    report=dict(status='experimental-native-client-test-required',nativeWarcraftTested=False,liveIrinaBotTested=False,sourceMaps=17,terrainSize=480,sourceZones=zones,objects={k:len(v) for k,v in catalog.output.items()},skillKits=16,talentChoices=40,talentBooks=4,talentUI='Classic spellbook; level requirements and permanent per-tier choice',minPlayers=1,maxPlayers=4,heroLevelCap=20,nextMapRequiresNewLobby=False,localSessionSaves='Z6/C4',AI='Adapted synchronized active-zone attack and factory replenishment; original native campaign AI not started',bytes=target.stat().st_size,sha256=hashlib.sha256(target.read_bytes()).hexdigest())
    (out/'Build-report.json').write_text(json.dumps(report,ensure_ascii=False,indent=2));print('BUILT',target,report['bytes'])
    return report

if __name__=='__main__':
    parser=argparse.ArgumentParser();parser.add_argument('--out',required=True);parser.add_argument('--missions');a=parser.parse_args();build(a.out,a.missions)

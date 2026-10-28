#!/usr/bin/env python3
"""Build a single-map campaign atlas. Work in progress, not a released map."""
import argparse,copy,json,os,re,struct,subprocess
from pathlib import Path
from build import ROOT,MAPS,EXTRA,state_schema,player_remap
from formats import read_info,coop_info,Reader,i,s
from storm import Storm
from unified_catalog import UnifiedCatalog,ALL_KINDS
from unified_script import source_parts
import unified_terrain as terrain

def atlas_info(original,title,dx,dy):
    blob,_=coop_info(original,player_remap('', 'atlas') if False else {},[0,1,2,3],title)
    info=read_info(blob);prefix=bytearray(info['prefix']);r=Reader(prefix);r.read(12)
    for _ in range(4):r.s()
    origin=terrain.ORIGIN
    bounds=(origin+1280,origin+768,-origin-1280,-origin-1280,origin+1280,-origin-1280,-origin-1280,origin+768)
    struct.pack_into('<8f4i2i',prefix,r.p,*bounds,6,6,4,8,468,468)
    host=copy.deepcopy(next(p for p in info['players'] if p['id']==0));players=[]
    for number in range(12):
        p=copy.deepcopy(next((p for p in info['players'] if p['id']==number),host));p['id']=number
        p['x']=host['x']+dx;p['y']=host['y']+dy;p['low']=0;p['high']=15^(1<<number) if number<4 else 0
        if number>=4:p.update(controller=2,race=1,flags=1,name=('NPC '+str(number)).encode())
        players.append(p)
    forces=[dict(flags=11,members=15,name='Отряд Рексара'.encode())]+[dict(flags=0,members=1<<n,name=('NPC '+str(n)).encode()) for n in range(4,12)]
    out=bytes(prefix)+i(12)
    for p in players:out+=b''.join(i(p[k]) for k in ['id','controller','race','flags'])+s(p['name'])+struct.pack('<ffii',p['x'],p['y'],p['low'],p['high'])
    out+=i(len(forces))
    for f in forces:out+=i(f['flags'])+i(f['members'])+s(f['name'])
    return out+info['tail']

def prepare(out,missions):
    out=Path(out);out.mkdir(parents=True,exist_ok=True);storm=Storm();maps={};terrains=[];paths={};shadows={}
    fields=set(EXTRA)|{v[0] for v in ALL_KINDS.values()}|{'war3map.w3e','war3map.wpm','war3map.shd'}
    for index,name in enumerate(MAPS):
        path=ROOT/'inputs'/(name+'.w3x');h=storm.open(path)
        try:data={file:storm.read(h,file) for file in fields}
        finally:storm.close(h)
        strings={int(n):v.encode() for n,v in re.findall(r'STRING\s+(\d+)\s*\r?\n\{\r?\n(.*?)\r?\n\}',data['war3map.wts'].decode(),re.S)}
        script=data['war3map.j'].decode().replace('\r\n','\n')
        maps[name]=dict(name=name,index=index,path=path,data=data,script=script,strings=strings)
        terrains.append(terrain.read(name,data['war3map.w3e'],data['war3map.w3i']));paths[name]=data['war3map.wpm'];shadows[name]=data['war3map.shd']
    terrain.arrange(terrains);catalog=UnifiedCatalog(maps);schema=state_schema(maps)
    merged,cliffs=terrain.merge(terrains,paths,shadows);stage=out/'merged';stage.mkdir(exist_ok=True)
    for name,blob in merged.items():(stage/name).write_bytes(blob)
    plan={};parts={}
    for t in terrains:
        m=maps[t.name];m['storyCount']=len(schema);m['schema']=schema;m['itemCount']=len(catalog.compact)
        l,b,w,h=t.crop;dx,dy=t.offset
        plan[t.name]=dict(dx=dx,dy=dy,cropLeft=l,cropBottom=b,cropWidth=w,cropHeight=h,sourceX=t.x,sourceY=t.y,atlasX=t.atlas_x,atlasY=t.atlas_y,playable=t.playable,rawMap={k.decode():v.decode() for k,v in catalog.raw_maps[t.name].items()},owners=player_remap(m['script'],t.name))
        generated=(Path(missions)/'scripts'/(t.name+'.j')).read_text()
        parts[t.name]=source_parts(m['script'],generated,m['strings'],catalog.raw_maps[t.name],t,m['index'])
        target=out/'zone-scripts'/t.name;target.mkdir(parents=True,exist_ok=True)
        (target/'globals.j').write_text(parts[t.name]['globals'])
        (target/'functions.j').write_text('\n\n'.join(parts[t.name]['functions'].values()))
    (out/'Atlas-plan.json').write_text(json.dumps(plan,ensure_ascii=False,indent=2))
    (out/'Atlas-info-template.w3i').write_bytes(atlas_info(maps[MAPS[0]]['data']['war3map.w3i'],'REXXAR VII - ALL LOCATIONS',*terrains[0].offset))
    subprocess.run([os.environ.get('DOTNET','dotnet'),str(ROOT/'Tools/bin/Release/net10.0/Tools.dll'),'atlas-placements',str(ROOT/'inputs'),str(out/'Atlas-plan.json'),str(out/'Atlas-info-template.w3i'),str(stage)],check=True)
    report=dict(status='work-in-progress-not-playable',maps=17,width=480,height=480,palette=[v.decode() for v in terrain.GROUND],cliffs=[v.decode() for v in cliffs],objects={k:len(v) for k,v in catalog.output.items()},nativeGameTested=False)
    (out/'Atlas-preparation.json').write_text(json.dumps(report,ensure_ascii=False,indent=2));print(report)
    return maps,terrains,catalog,schema,parts

if __name__=='__main__':
    parser=argparse.ArgumentParser();parser.add_argument('--out',required=True);parser.add_argument('--missions',required=True);a=parser.parse_args();prepare(a.out,a.missions)

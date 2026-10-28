"""Reproducible classic-map example; original playable content stays in place."""
import argparse,copy,hashlib,json,os,re,shutil,struct,subprocess
from pathlib import Path
from catalog import Catalog
from classic_data import field,write_objects,read_objects,read_info,s
from stages import choose
from storm import Storm
from ui_assets import build as build_assets
from controls import abilities as control_abilities,units as control_units

ROOT=Path(__file__).resolve().parent
BASE=ROOT.parent/'release/23-Races-3.2D-Triggers-NewGen-1.26.w3x'

def global_vars():
    rows=[]
    def add(typ,scalars='',arrays=''):
        rows.extend(dict(name='AS_'+n,type=typ,array=a) for a,names in [(False,scalars),(True,arrays)] for n in names.split())
    add('integer','Remaining TreeCount SetupIndex','Choice PreviewType ControlType RaceAbility Pending')
    add('real','','NextInput PreviewX PreviewY SpawnX SpawnY StageOffset StageX StageY StageZ OriginalDelay')
    add('boolean','Running WasFog WasFogMask','Entered Ready PendingConfirm OriginalEnabled OriginalRepeat')
    add('group','World','Actors Workers')
    add('unit','','Selector Control')
    add('destructable','','Tree')
    add('hashtable','State')
    add('timer','Clock SetupTimer TickTimer CameraTimer InputTimer Deadline','OriginalTimer')
    add('timerdialog','Countdown')
    add('trigger','Spells','OriginalTrigger')
    return rows

def initial_timers(source):
    rows=[]
    for name,body in re.findall(r'^function (InitTrig_\w+) takes[^\n]*\n([\s\S]*?)^endfunction',source,re.M):
        for kind,trigger,delay in re.findall(r'TriggerRegisterTimerEvent(Single|Periodic)\((gg_trg_\w+),([\d.]+)\)',body):
            rows.append(dict(trigger=trigger,delay=float(delay),repeat=kind=='Periodic'))
    assert len(rows)==45
    return rows

def runtime(catalog,aliases,stages,timers,entries):
    init=['function AS_InitCatalog takes nothing returns nothing']
    for p,stage in enumerate(stages):
        for axis in ('x','y','z'):init.append(f"set udg_AS_Stage{axis.upper()}[{p}] = {stage[axis]:.3f}")
    # Back-row buildings, army in front; camp is framed on the right of panel.
    offsets=[(500,480),(-120,450),(1100,350),(1050,900),(0,-200),(380,-230),(780,-180),(1050,-450),(460,-650),(1100,-850),(0,-800),(250,-900)]
    for n,(x,y) in enumerate(offsets):
        init.extend([f'set udg_AS_PreviewX[{n}] = {x}.',f'set udg_AS_PreviewY[{n}] = {y}.'])
    for race in catalog.races:
        r=race['index'];init.extend([f"set udg_AS_ControlType[{r}] = 'qC{r:02}'",f"set udg_AS_RaceAbility[{r}] = 'qA{r:02}'"])
        items=race['previewBuildings']+['']*(4-len(race['previewBuildings']))+race['previewUnits']+[race['worker']]
        assert len(items)<=12
        for n,raw in enumerate(items):
            if raw:init.append(f"set udg_AS_PreviewType[{r*12+n}] = '{aliases[raw]}'")
    init.append('endfunction')
    gates=['function AS_InitOriginalTimers takes nothing returns nothing']
    for n,t in enumerate(timers):
        gates.extend([f'set udg_AS_OriginalTimer[{n}] = CreateTimer()',f'call TriggerRegisterTimerExpireEvent({t["trigger"]}, udg_AS_OriginalTimer[{n}])',f'set udg_AS_OriginalDelay[{n}] = {t["delay"]}',f'set udg_AS_OriginalRepeat[{n}] = {str(t["repeat"]).lower()}'])
    gates.extend(['endfunction','function AS_FreezeOriginals takes nothing returns nothing','local integer n = 0'])
    for n,e in enumerate(entries):gates.append(f'set udg_AS_OriginalTrigger[{n}] = gg_trg_{e["name"]}')
    gates.extend(['loop',f'exitwhen n == {len(entries)}','set udg_AS_OriginalEnabled[n] = IsTriggerEnabled(udg_AS_OriginalTrigger[n])','call DisableTrigger(udg_AS_OriginalTrigger[n])','set n = n + 1','endloop','endfunction','function AS_RestoreOriginals takes nothing returns nothing','local integer n = 0','loop',f'exitwhen n == {len(entries)}','if udg_AS_OriginalEnabled[n] then','call EnableTrigger(udg_AS_OriginalTrigger[n])','endif','set n = n + 1','endloop','set n = 0','loop',f'exitwhen n == {len(timers)}','call TimerStart(udg_AS_OriginalTimer[n],udg_AS_OriginalDelay[n],udg_AS_OriginalRepeat[n],null)','set n = n + 1','endloop','endfunction'])
    apply=['function AS_ApplyRace takes integer p, integer choice returns nothing','local location spawn = Location(udg_AS_SpawnX[p], udg_AS_SpawnY[p])']
    for r in catalog.races:
        apply.append(('if' if r['index']==0 else 'elseif')+f" choice == {r['index']} then")
        apply.append(f"call SetPlayerTechResearched(Player(p), '{r['research']}', 1)")
        body=r['action'].strip().replace('GetOwningPlayer(GetTriggerUnit())','Player(p)').replace('GetUnitLoc(GetTriggerUnit())','spawn').replace('GetTriggerUnit()','udg_AS_Selector[p]').replace('GetTriggerPlayer()','Player(p)')
        apply.append(body)
    apply.extend(['endif','call RemoveLocation(spawn)','set spawn = null','endfunction'])
    text=(ROOT/'runtime.j').read_text()
    for marker,value in [('CATALOG',init),('ORIGINAL_GATES',gates),('APPLY_RACES',apply)]:text=text.replace('// @@'+marker+'@@','\n'.join(value))
    text=text.replace('call AS_FreezeOriginals()','call AS_InitOriginalTimers()\n    call AS_FreezeOriginals()')
    names=set(re.findall(r'udg_(AS_\w+)',text));declared={v['name'] for v in global_vars()}
    assert names==declared,(names-declared,declared-names)
    return text.replace('// @@GLOBALS@@','')

def ui_object(raw,model):
    mods=[field('unam',3,'Экран выбора расы'),field('umdl',3,model),field('usca',2,1.),field('uabi',3,'Aloc,Avul'),field('uhab',3,''),field('ures',3,''),field('utra',3,''),field('ubui',3,''),field('ufoo',0,0),field('uaen',0,0),field('uacq',2,0.),field('umvs',0,0),field('umvt',3,'fly'),field('umvh',2,0.),field('umvf',2,0.),field('ucol',2,0.),field('upat',3,''),field('ubdg',0,0),field('ushb',3,''),field('ushu',3,''),field('umxp',2,0.),field('umxr',2,0.),field('uclr',0,255),field('uclg',0,255),field('uclb',0,255)]
    return dict(old=b'hfoo',new=raw.encode(),mods=mods)

def main():
    ap=argparse.ArgumentParser();ap.add_argument('--out',required=True,type=Path);ap.add_argument('--dotnet',default=os.environ.get('DOTNET','dotnet'));args=ap.parse_args();out=args.out.resolve();out.mkdir(parents=True,exist_ok=True)
    storm=Storm();h=storm.open(BASE)
    source=(ROOT.parent/'source/original-gameplay.j').read_text()
    try:
        cat=Catalog(storm,h,source);preview,aliases=cat.preview_objects()
        stages=choose(storm.read(h,'war3map.w3e'),storm.read(h,'war3map.wpm'),source)
        oldimp=storm.read(h,'war3map.imp');oldlist=storm.read(h,'(listfile)');oldinfo=storm.read(h,'war3map.w3i');ability_tables=read_objects(storm.read(h,'war3map.w3a'),True)
    finally:storm.close(h)
    timers=initial_timers(source);entries=json.loads((ROOT.parent/'source/trigger-index.json').read_text())['entries']
    for name,obj in [('catalog.json',cat.races),('stages.json',stages),('timers.json',timers),('globals.json',global_vars())]:
        (out/name).write_text(json.dumps(obj,ensure_ascii=False,indent=2)+'\n')
    functions=runtime(cat,aliases,stages,timers,entries);(out/'selector-functions.j').write_text(functions)
    assets=build_assets(cat,out)
    cmd=[args.dotnet,str(ROOT/'Check/bin/Debug/net10.0/Check.dll')]
    subprocess.run(cmd+['patch',str(BASE),str(out)],check=True)
    # Source declaration version stays classic; only add isolated preview types.
    tables=copy.deepcopy(cat.tables);tables[1]+=preview
    tables[1]+=control_units(cat)
    tables[1].append(ui_object('qPln','AS\\Scene\\Floor.mdx'))
    ids=[o['new'] for o in tables[1]];assert len(ids)==len(set(ids))
    ability_tables[1]+=control_abilities(cat)
    ids=[o['new'] for o in ability_tables[1]];assert len(ids)==len(set(ids))
    script=(out/'editor-generated.j').read_bytes()
    a,b=read_info(oldinfo)['title'];title='23 Расы — Выбор расы FIX2';info=oldinfo[:a]+s(title)+oldinfo[b:]
    newimp=struct.pack('<II',1,struct.unpack_from('<I',oldimp,4)[0]+len(assets))+oldimp[8:]+b''.join(b'\r'+s(n) for n in assets)
    replacements={'war3map.wtg':(out/'war3map.wtg').read_bytes(),'war3map.wct':(out/'war3map.wct').read_bytes(),'war3map.w3u':write_objects(tables),'war3map.w3a':write_objects(ability_tables,True),'war3map.j':script,'Scripts\\war3map.j':script,'war3map.imp':newimp,'war3map.w3i':info}
    replacements.update({name:path.read_bytes() for name,path in assets.items()})
    # StormLib owns (listfile); it adds every inserted name on archive close.
    target=out/'23-Races-Race-Selection-1.26.w3x';shutil.copy2(BASE,target)
    temp=out/'mpq-write';temp.mkdir(exist_ok=True);storm.replace(target,replacements,temp);storm.compact(target)
    blob=target.read_bytes()
    if blob[:4]!=b'HM3W':
        assert blob[:4]==b'MPQ\x1a';target.write_bytes(BASE.read_bytes()[:512]+blob)
    blob=target.read_bytes();assert blob[512:516]==b'MPQ\x1a' and struct.unpack_from('<H',blob,524)[0]==0
    end=blob.index(0,8);prefix=blob[:8]+s(title)+blob[end+1:end+9]
    assert len(prefix)<=512
    target.write_bytes(prefix+bytes(512-len(prefix))+blob[512:]);blob=target.read_bytes()
    report=dict(inputSHA256=hashlib.sha256(BASE.read_bytes()).hexdigest(),outputSHA256=hashlib.sha256(blob).hexdigest(),bytes=len(blob),races=34,players=12,newPreviewTypes=len(preview)+1,nativeControlTypes=34,nativeButtonAbilities=38,newAssets=len(assets),deferredInitialTimers=len(timers),originalTriggers=262,nativeWarcraftRun=False)
    (out/'build-report.json').write_text(json.dumps(report,indent=2)+'\n')
    subprocess.run(cmd+['verify',str(target),str(out/'verify')],check=True)
    subprocess.run(cmd+['models',str(out/'assets')],check=True)
    print(json.dumps(report));print(target)

if __name__=='__main__':main()

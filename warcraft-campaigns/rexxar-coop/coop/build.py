#!/usr/bin/env python3
"""Build actual four-player mission maps from the user's seventeen originals."""
import argparse,copy,hashlib,json,os,re,shutil,struct,subprocess,tempfile,zipfile
from pathlib import Path
from formats import Reader,coop_info,field,i,read_info,read_objects,s,write_objects
from storm import Storm
import kits

ROOT=Path(__file__).resolve().parent
MAPS=['OrcX01']+[f'OrcX01_{n:02}' for n in range(2,6)]+['OrcX02']+[f'OrcX02_{n:02}' for n in range(2,11)]+['OrcX03a','OrcX03b']
ROLES=[0,3,4,5]
FILE_PREFIX='RX4-'
DISPLAY_PREFIX='REXXAR IV - '
KINDS={'item':('war3map.w3t',False),'ability':('war3map.w3a',True),'unit':('war3map.w3u',False),'buff':('war3map.w3h',False)}
EXTRA=['war3map.j','war3map.w3i','war3map.wts','war3mapMisc.txt','war3mapUnits.doo']

def mask(text):
    # Retain offsets/newlines while ignoring strings, rawcodes and comments.
    return re.sub(r'//[^\r\n]*|"(?:[^"\\]|\\.)*"|\'(?:[^\'\\]|\\.)*\'',lambda m:re.sub(r'[^\r\n]',' ',m[0]),text)

def function(text,name,body):
    pattern=r'(?m)^function '+re.escape(name)+r' takes[^\r\n]*\r?\n[\s\S]*?^endfunction\b'
    text,n=re.subn(pattern,lambda _:f'function {name} takes nothing returns nothing\n{body}\nendfunction',text)
    if n!=1:raise ValueError('Expected function '+name)
    return text

def calls(text,mapping):
    tokens=mask(text);changes=[]
    for match in re.finditer(r'\b([A-Za-z_]\w*)\s*\(',tokens):
        if match[1] in mapping:changes.append((match.start(1),match.end(1),mapping[match[1]]))
    for a,b,v in reversed(changes):text=text[:a]+v+text[b:]
    return text

def classic_strings(script):
    """The classic JASS loader has a 1023-byte literal limit (UTF-8 bytes).

    pjass accepts longer strings, so syntax checks alone missed the 1415-byte
    Russian help literal in RC1. Split at character/escape boundaries and audit
    the serialized bytes independently in test_maps.py.
    """
    pattern=r'//[^\r\n]*|"(?:[^"\\]|\\.)*"'
    def shorten(match):
        token=match[0]
        if token.startswith('//') or len(token[1:-1].encode())<=900:return token
        parts=[];part=''
        for char in re.findall(r'\\.|[^\\]',token[1:-1],re.S):
            if len((part+char).encode())>480:parts.append('"'+part+'"');part=''
            part+=char
        parts.append('"'+part+'"')
        return '('+' + '.join(parts)+')'
    return re.sub(pattern,shorten,script)

def player_remap(script,name):
    if name=='OrcX03b':return {} # Three existing Horde armies become the three friends' armies.
    used=set(map(int,re.findall(r'\bPlayer\(\s*(\d+)\s*\)',mask(script))))
    targets=[n for n in range(1,12) if n not in ROLES and n not in used]
    moved={}
    collisions=[n for n in ROLES[1:] if n in used]
    if len(collisions)>len(targets):
        # Revival stones have no campaign AI/economy: the neutral-victim slot is
        # a real engine player, not an additional playable lobby position.
        if 6 not in used:raise ValueError('No safe NPC placement')
        moved[6]=13;targets.append(6)
    for old,new in zip(collisions,targets):moved[old]=new
    if len(collisions)>len(targets):raise ValueError('Cannot reserve three co-op positions')
    return moved

def apply_player_remap(script,remap):
    masked=mask(script);matches=list(re.finditer(r'\bPlayer\(\s*(\d+)\s*\)',masked))
    for m in reversed(matches):
        id=int(m[1])
        if id in remap:script=script[:m.start(1)]+str(remap[id])+script[m.end(1):]
    return script

class Catalog:
    """Portable item definitions, including their modified ability/unit dependencies.

    The same original I00x ID means different things in different actual inputs.
    Save codes therefore use stable RIxx aliases, translated back to local quest
    IDs whenever an equivalent local definition exists.
    """
    def __init__(self,maps):
        self.maps=maps;self.output={k:[] for k in KINDS};self.identities={};self.local={};self.cache={};self.busy=set()
        for name,m in maps.items():
            lookup={}
            for kind,(filename,leveled) in KINDS.items():
                tables=read_objects(m['data'].get(filename),leveled);m[kind]=tables
                lookup[kind]={obj['old'] if table==0 else obj['new']:obj for table,items in enumerate(tables) for obj in items if obj['mods']}
            m['lookup']=lookup
    def resolve(self,m,value):
        if not isinstance(value,bytes):return value
        match=re.fullmatch(rb'TRIGSTR_(\d+)',value)
        return m['strings'].get(int(match[1]),value) if match else value
    def dependencies(self,m,mod):
        if mod[1]!=3 or mod[0] in {'unam','upro','utip','utub','ides','anam','atp1','aub1','arut','aret','ureq','urqa'}:return []
        text=mod[4].decode('utf8',errors='replace')
        if not re.fullmatch(r'[A-Za-z0-9_, ]+',text):return []
        found=[]
        for token in re.findall(r'\b[A-Za-z0-9_]{4}\b',text):
            for kind in ['ability','buff','unit','item']:
                if token.encode() in m['lookup'][kind]:found.append((token,kind));break
        return found
    def signature(self,name,kind,raw,seen=()):
        m=self.maps[name];obj=m['lookup'][kind].get(raw)
        if obj is None:return (kind,raw.hex())
        if (kind,raw) in seen:return ('cycle',kind,raw.hex())
        mods=[]
        for mod in obj['mods']:
            value=self.resolve(m,mod[4]);deps=[(token,self.signature(name,k,token.encode(),seen+((kind,raw),))) for token,k in self.dependencies(m,mod)]
            mods.append([mod[0],mod[1],mod[2],mod[3],value.hex(),deps])
        # Include original identity: identical-looking quest items may have distinct roles.
        return (kind,raw.hex(),obj['old'].hex(),sorted(mods,key=lambda x:(x[0],x[2],x[3])))
    def clone(self,name,kind,raw):
        key=(name,kind,raw)
        if key in self.cache:return self.cache[key]
        m=self.maps[name];obj=m['lookup'][kind].get(raw)
        if obj is None:return raw
        identity=hashlib.sha256(json.dumps(self.signature(name,kind,raw),sort_keys=True).encode()).hexdigest()
        dedup=(kind,identity)
        if dedup in self.identities:self.cache[key]=self.identities[dedup];return self.cache[key]
        index=len(self.output[kind]);alphabet='0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz'
        if index>=62*62:raise ValueError('Portable catalog exhausted')
        prefix={'item':'RI','ability':'RA','unit':('RU' if obj['old'][0]<97 else 'rU'),'buff':'RB'}[kind]
        alias=(prefix+alphabet[index//62]+alphabet[index%62]).encode();self.cache[key]=alias;self.identities[dedup]=alias
        target={'old':obj['old'],'new':alias,'mods':[]};self.output[kind].append(target)
        # Inherit modified standard base fields too, before custom overrides.
        base=m['lookup'][kind].get(obj['old']) if obj['new']!=b'\0'*4 else None
        mods=(base['mods'] if base is not None and base is not obj else [])+obj['mods']
        for mod in mods:
            new=copy.deepcopy(mod);new[4]=self.resolve(m,new[4]);new[5]=b'\0'*4
            if new[1]==3:
                for token,dependency in self.dependencies(m,mod):
                    replacement=self.clone(name,dependency,token.encode())
                    new[4]=re.sub(rb'(?<![A-Za-z0-9_])'+re.escape(token.encode())+rb'(?![A-Za-z0-9_])',replacement,new[4])
            target['mods'].append(new)
        return alias
    def build(self):
        for name,m in self.maps.items():
            self.local[name]={raw:self.clone(name,'item',raw) for raw in sorted(m['lookup']['item'])}
        standards=json.loads((ROOT/'classic-items.json').read_text())['items']
        self.compact=[b'\0'*4]+sorted(set(x.encode() for x in standards)|{x['new'] for x in self.output['item']})
        if len(self.compact)>4096:raise ValueError('Compact item catalog exhausted')
        return self
    def hooks(self,name):
        forward=self.local[name];reverse={v:k for k,v in forward.items()}
        writes=[]
        for column,table in enumerate([forward,reverse]):
            for source,target in sorted(table.items()):writes.append(f"    call SaveInteger(RC_items, '{source.decode()}', {column}, '{target.decode()}')")
        for index,raw in enumerate(self.compact[1:],1):
            writes += [f"    call SaveInteger(RC_items, '{raw.decode()}', 2, {index})",f"    call SaveInteger(RC_items, {index}, 3, '{raw.decode()}')"]
        lines=[];chunks=[]
        for n,start in enumerate(range(0,len(writes),128)):
            name=f'RC_ItemsInit{n}';chunks.append(name)
            lines += [f'function {name} takes nothing returns nothing']+writes[start:start+128]+['endfunction']
        lines += ['function RC_InitItems takes nothing returns nothing']+[f'    call {name}()' for name in chunks]+['endfunction']
        for column,fn in enumerate(['RC_ItemToPortable','RC_ItemToLocal']):lines += [f'function {fn} takes integer id returns integer',f'    local integer translated = LoadInteger(RC_items, id, {column})','    if translated != 0 then','        return translated','    endif','    return id','endfunction']
        return '\n'.join(lines)

def state_schema(maps):
    schema={}
    for m in maps.values():
        for typ,name,default in re.findall(r'^\s*(boolean|integer)\s+(udg_\w*(?:Progress\w*|Given))\s*=\s*(\w+)',m['script'].split('endglobals')[0],re.M):schema[name]=typ
    return sorted(schema.items())

def hooks(m,schema):
    globals=m['script'].split('endglobals')[0];declared=set(re.findall(r'\budg_\w+',globals));out=[]
    # Keep source campaign diplomacy in gameplay, without changing lobby teams.
    # In particular, splitting the humans into their own force must not turn
    # original friendly vendors/revival stones into hostile factions.
    source=read_info(m['data']['war3map.w3i']);remap=player_remap(m['script'],m['name']);relations=set()
    for force in source['forces']:
        members=[remap.get(p['id'],p['id']) for p in source['players'] if force['members']&(1<<p['id'])]
        for a in members:
            for b in members:
                if a==b or a in ROLES and b in ROLES:continue
                if a in ROLES[1:] or b in ROLES[1:]:continue
                for left in (ROLES if a==0 else [a]):
                    for right in (ROLES if b==0 else [b]):
                        for flag,native in [(1,'ALLIANCE_PASSIVE'),(8,'ALLIANCE_SHARED_VISION'),(16,'ALLIANCE_SHARED_CONTROL'),(32,'ALLIANCE_SHARED_ADVANCED_CONTROL')]:
                            if force['flags']&flag:relations.add((left,right,native))
    writes=[f'    call SetPlayerAlliance(Player({a}), Player({b}), {native}, true)' for a,b,native in sorted(relations)]
    chunks=[]
    for n,start in enumerate(range(0,len(writes),128)):
        fn=f'RC_InitialAlliance{n}';chunks.append(fn);out.append('\n'.join([f'function {fn} takes nothing returns nothing']+writes[start:start+128]+['endfunction']))
    out.append('\n'.join(['function RC_InitialAlliances takes nothing returns nothing']+[f'    call {fn}()' for fn in chunks]+['endfunction']))
    collect=['function RC_CollectStory takes nothing returns nothing'];apply=['function RC_ApplyStory takes nothing returns nothing'];seed=['function RC_SeedStory takes nothing returns nothing']
    for index,(name,typ) in enumerate(schema):
        if name in declared:
            if typ=='boolean':collect += [f'    if {name} then',f'        set RC_story[{index}] = 1','    else',f'        set RC_story[{index}] = 0','    endif'];apply.append(f'    set {name} = RC_story[{index}] != 0')
            else:collect.append(f'    set RC_story[{index}] = {name}');apply.append(f'    set {name} = RC_story[{index}]')
    for role,name in enumerate(['Rexxar','Rokhan','Chen','Cairne']):
        if f'udg_{name}InParty' in declared:collect += [f'    if udg_{name}InParty then',f'        set RC_flags[{role}] = 1','    else',f'        set RC_flags[{role}] = 0','    endif'];apply.append(f'    set udg_{name}InParty = RC_flags[{role}] != 0')
    # Keys are not always equal to variable names (Serpents/Survivors in act II).
    for var,typ,key in re.findall(r'set\s+(udg_\w+)\s*=\s*GetStored(Integer|Boolean)BJ\("([^"]+)"',m['script']):
        indices={name:index for index,(name,_) in enumerate(schema)}
        if var in indices:value=f'RC_story[{indices[var]}]'
        elif var.endswith('InParty') and var[4:-7] in ['Rexxar','Rokhan','Chen','Cairne']:value=f"RC_flags[{['Rexxar','Rokhan','Chen','Cairne'].index(var[4:-7])}]"
        else:continue
        native='StoreBoolean' if typ=='Boolean' else 'StoreInteger';v=f'{value} != 0' if typ=='Boolean' else value
        for mission in ['OrcX01Transitions','OrcX02Transitions']:seed.append(f'    call {native}(RC_cache, "{mission}", "{key}", {v})')
    for mission in ['OrcX01Transitions','OrcX02Transitions']:
        seed += [f'    call StoreInteger(RC_cache, "{mission}", "TransitionSource", RC_zone[RC_sourceMap])',f'    call StoreInteger(RC_cache, "{mission}", "TransitionTargetArea", RC_nextArea)']
    out.extend('\n'.join(lines+['endfunction']) for lines in [collect,apply,seed])
    observed=['function RC_ObserveStoryHeroes takes nothing returns nothing']
    for index,name in enumerate(['Rexxar','Rokhan','Chen','Cairne']):
        if f'udg_{name}' in declared:observed += [f'    if udg_{name} != null and GetUnitTypeId(udg_{name}) != 0 and RC_IsPartyPlayer(GetOwningPlayer(udg_{name})) then',f'        call RC_Adopt({index}, udg_{name})','    endif']
    out.append('\n'.join(observed+['endfunction']))
    if 'udg_Stash' in declared:
        out[-1]=out[-1].replace('endfunction','    if udg_Stash != null then\n        set RC_stash = udg_Stash\n    endif\nendfunction')
    original_triggers=list(dict.fromkeys(re.findall(r'^\s*trigger\s+(gg_trg_\w+)\s*=',globals,re.M)))
    for enabled in [False,True]:
        basename=f'RC_{"Enable" if enabled else "Disable"}Originals';batches=[]
        for n,t in enumerate(original_triggers):
            if enabled:batches.append([f'    if RC_originalEnabled[{n}] then',f'        call EnableTrigger({t})','    endif'])
            else:batches.append([f'    set RC_originalEnabled[{n}] = IsTriggerEnabled({t})',f'    call DisableTrigger({t})'])
        chunks=[]
        for n,start in enumerate(range(0,len(batches),128)):
            name=basename+str(n);chunks.append(name)
            out.append('\n'.join([f'function {name} takes nothing returns nothing']+[line for batch in batches[start:start+128] for line in batch]+['endfunction']))
        lines=[f'function {basename} takes nothing returns nothing']+[f'    call {name}()' for name in chunks]
        if enabled:
            for t,seconds in re.findall(r'TriggerRegisterTimerEventSingle\(\s*(gg_trg_\w+),\s*([\d.]+)\s*\)',m['script']):
                if t in original_triggers:lines += [f'    if RC_originalEnabled[{original_triggers.index(t)}] and TimerGetElapsed(RC_menuClock) >= {seconds} then',f'        call TriggerRegisterTimerEventSingle({t}, {seconds})','    endif']
        out.append('\n'.join(lines+['endfunction']))
    out.append('function RC_StoryCinematic takes nothing returns boolean\n    return '+('udg_InCinematic' if 'udg_InCinematic' in declared else 'false')+'\nendfunction')
    extra=['function RC_CollectExtraLoot takes nothing returns nothing']
    if m['index']==6:
        extra += ['    local integer n = 0','    local item it','    if udg_Jaina == null or not RC_IsPartyPlayer(GetOwningPlayer(udg_Jaina)) then','        return','    endif','    loop','        exitwhen n == 6','        set it = UnitItemInSlot(udg_Jaina, n)','        if it != null then','            set RC_extraItem[n] = RC_ItemToPortable(GetItemTypeId(it))','            set RC_extraCharges[n] = GetItemCharges(it)','            call RemoveItem(it)','        endif','        set n = n + 1','    endloop','    set it = null']
    out.append('\n'.join(extra+['endfunction']))
    return '\n\n'.join(out)

def build(destination):
    destination=Path(destination);destination.mkdir(parents=True,exist_ok=True);storm=Storm();maps={}
    for index,name in enumerate(MAPS):
        path=ROOT/'inputs'/(name+'.w3x');archive=storm.open(path)
        try:data={file:storm.read(archive,file) for file in EXTRA+[v[0] for v in KINDS.values()]}
        finally:storm.close(archive)
        if not data['war3map.j'] or not data['war3map.w3i']:raise ValueError('Incomplete original '+name)
        strings={int(n):v.encode() for n,v in re.findall(r'STRING\s+(\d+)\s*\r?\n\{\r?\n(.*?)\r?\n\}',(data['war3map.wts'] or b'').decode('utf8'),re.S)}
        maps[name]=dict(name=name,index=index,path=path,data=data,script=data['war3map.j'].decode('utf8').replace('\r\n','\n'),strings=strings)
    schema=state_schema(maps);catalog=Catalog(maps).build();runtime=(ROOT/'runtime'/'core.j').read_text();reports=[]
    plan={name:player_remap(m['script'],name) for name,m in maps.items()}
    (destination/'Npc-remap.json').write_text(json.dumps(plan,indent=2))
    subprocess.run([os.environ.get('DOTNET','dotnet'),'run','--project',str(ROOT/'Tools'),'-c','Release','--','owners',str(ROOT/'inputs'),str(destination/'Npc-remap.json'),str(destination/'placements')],check=True)
    (destination/'scripts').mkdir(exist_ok=True);(destination/'Maps').mkdir(exist_ok=True)
    for name,m in maps.items():
        m['storyCount']=len(schema)
        m['schema']=schema;m['itemCount']=len(catalog.compact)
        original=m['script'];remap=player_remap(original,name);script=apply_player_remap(original,remap)
        title=DISPLAY_PREFIX+name
        info,players=coop_info(m['data']['war3map.w3i'],remap,ROLES,title)
        script=transform(script,m,schema,catalog,players,remap,runtime,read_info(info)['forces'])
        edits={'war3map.j':script.encode(),'war3map.w3i':info,'war3mapUnits.doo':(destination/'placements'/(name+'.doo')).read_bytes()}
        for kind,(filename,leveled) in KINDS.items():
            tables=copy.deepcopy(m[kind]);tables[1].extend(catalog.output[kind])
            if kind=='ability':
                tables[1].extend(kits.abilities())
                attribute=next((o for o in tables[0] if o['old']==b'Aamk'),None)
                if attribute is None:attribute=dict(old=b'Aamk',new=b'\0'*4,mods=[]);tables[0].append(attribute)
                attribute['mods']=[mod for mod in attribute['mods'] if mod[0] not in {'arpx','arpy','abpx','abpy'}]+[field('arpx',0,0),field('arpy',0,1),field('abpx',0,0),field('abpy',0,1)]
            if kind=='unit':
                kits.apply_heroes(tables);tables[1].extend(kits.unit_helpers())
            metadata=json.loads((ROOT/'metadata-types.json').read_text())['types']
            for table in tables:
                for obj in table:
                    for mod in obj['mods']:
                        if mod[0] in metadata and mod[1]!=metadata[mod[0]]:raise ValueError(f'Classic metadata type mismatch: {name} {filename} {mod[0]}')
            edits[filename]=write_objects(tables,leveled)
        misc=(m['data']['war3mapMisc.txt'] or b'[Misc]\r\n').decode('utf8')
        if re.search(r'(?mi)^MaxHeroLevel=',misc):misc=re.sub(r'(?mi)^MaxHeroLevel=[^\r\n]*','MaxHeroLevel=20',misc)
        elif re.search(r'(?mi)^\[Misc\][^\S\r\n]*\r?$',misc):misc=re.sub(r'(?mi)^(\[Misc\][^\S\r\n]*\r?\n)',r'\1MaxHeroLevel=20\r\n',misc,count=1)
        else:misc += '\r\n[Misc]\r\nMaxHeroLevel=20\r\n'
        edits['war3mapMisc.txt']=misc.encode()
        target=destination/'Maps'/(FILE_PREFIX+name+'.w3x');shutil.copyfile(m['path'],target)
        with tempfile.TemporaryDirectory(prefix='rc-build-') as temp:storm.replace(target,edits,temp)
        blob=bytearray(target.read_bytes())
        if blob[:4]!=b'HM3W' or blob[512:516]!=b'MPQ\x1a':raise ValueError('Expected classic map header')
        parsed_info=read_info(info)
        header=bytes(blob[:8])+s(title)+struct.pack('<ii',struct.unpack_from('<i',parsed_info['prefix'],parsed_info['flags_offset'])[0],4)
        if len(header)>512:raise ValueError('Map title too long')
        blob[:512]=header+bytes(512-len(header));target.write_bytes(blob)
        verify=storm.open(target)
        try:
            if storm.read(verify,'war3map.j')!=edits['war3map.j']:raise ValueError('JASS verification failed')
            parsed=read_info(storm.read(verify,'war3map.w3i'))
            if sorted(p['id'] for p in parsed['players'] if p['controller']==1)!=ROLES:raise ValueError('Not four co-op roles')
            for kind,(filename,leveled) in KINDS.items():read_objects(storm.read(verify,filename),leveled)
        finally:storm.close(verify)
        (destination/'scripts'/(name+'.j')).write_text(script)
        reports.append(dict(map=name,bytes=target.stat().st_size,sha256=hashlib.sha256(target.read_bytes()).hexdigest(),sourceSha256=hashlib.sha256(m['path'].read_bytes()).hexdigest(),roles=ROLES,npcRemap=remap))
        print(name,'four roles',ROLES,'NPC remap',remap)
    report=dict(status='experimental-needs-real-game-test',nativeWarcraftTested=False,liveIrinaBotTested=False,filePrefix=FILE_PREFIX,maps=reports,questFields=schema,portableObjects={k:len(v) for k,v in catalog.output.items()},compactItems=len(catalog.compact),nextMapRequiresNewLobby=True,saveFormat='Z3',uncompressedSaveFormat='C2',legacySaveFormat='RC1')
    (destination/'Build-report.json').write_text(json.dumps(report,ensure_ascii=False,indent=2))
    return report

def transform(script,m,schema,catalog,players,remap,runtime,forces):
    # The original stash is a building. A temporary blade master only shuttles
    # its items through the single-player cache, then is removed. Keep the real
    # container intact and load our stash payload directly into it instead.
    for match in reversed(list(re.finditer(r'^function (\w+) takes[^\n]*\n[\s\S]*?^endfunction',script,re.M))):
        name=match[1];body=match[0]
        if name=='Trig_Load_Stash_Actions':
            body='function Trig_Load_Stash_Actions takes nothing returns nothing\n    call RC_ObserveStoryHeroes()\n    call RC_ApplyStash()\nendfunction'
        elif name in {'Trig_Next_Level_Prep_Actions','Trig_Export_Mission_Data_Actions','Trig_Import_Mission_Data_Actions'} and 'udg_StashHero' in body:
            body=re.sub(r'(?m)^    // Save Stash Contents In A Hero\n[\s\S]*?(?=^    // Save Cache)', '    // Stash persists through the RC payload, without moving its live items.\n',body)
            body=re.sub(r'(?m)^    // Stash\n[\s\S]*?(?=^    // Misc)', '    // Shared stash is restored directly by the RC runtime.\n',body)
        script=script[:match.start()]+body+script[match.end():]
    # Broaden owner-based quest tests without changing the actual owner handles.
    owner=r'(GetOwningPlayer\s*\((?:[^()]|\([^()]*\))*\))'
    replacements=[]
    for pattern,group in [(owner+r'\s*==\s*(?:udg_AP1_Player|Player\(\s*0\s*\))',1),(r'(?:udg_AP1_Player|Player\(\s*0\s*\))\s*==\s*'+owner,1)]:
        for match in re.finditer(pattern,mask(script)):replacements.append((match.start(),match.end(),'RC_IsPartyPlayer('+script[match.start(group):match.end(group)]+')'))
    for a,b,value in sorted(replacements,reverse=True):script=script[:a]+value+script[b:]
    mapped={'GetGameDifficulty':'RC_GetDifficulty','GetForceOfPlayer':'RC_GetForce','IsUnitOwnedByPlayer':'RC_UnitOwned','TriggerRegisterPlayerUnitEvent':'RC_RegisterUnitEvent','TriggerRegisterPlayerEventEndCinematic':'RC_RegisterSkip','CinematicModeBJ':'RC_Cinematic','CameraSetupApplyForPlayer':'RC_CameraSetup','GetUnitsOfPlayerAll':'RC_UnitsOfPlayer','InitGameCacheBJ':'RC_InitCache','ReloadGameCachesFromDisk':'RC_ReloadCache','SaveGameCacheBJ':'RC_SaveCache','RestoreUnitLocFacingAngleBJ':'RC_RestoreHero','StartCampaignAI':'RC_StartAI','ChangeLevel':'RC_ChangeLevel','SetNextLevelBJ':'RC_SetNextLevel','CustomVictoryBJ':'RC_Victory','CustomDefeatBJ':'RC_Defeat','SetPlayerStateBJ':'RC_Resource','AdjustPlayerStateBJ':'RC_AdjustResource'}
    mapped.update({'SelectHeroSkill':'RC_Learn','UnitHasItemOfTypeBJ':'RC_HasQuestItem','GetItemOfTypeFromUnitBJ':'RC_QuestItem'})
    script=calls(script,mapped)
    if 'function Trig_Transition_Actions ' in script:
        base=0 if m['index']<5 else 5
        script=function(script,'Trig_Transition_Actions',f'    call RC_Transition({base} + udg_TransitionTarget - 1, udg_TransitionTargetArea)')
        script=function(script,'Trig_Perform_Map_Transition_Actions',f'    call RC_Transition({base} + udg_TransitionTarget - 1, udg_TransitionTargetArea)')
    # A returning hub must rebuild quest state instead of replaying its first intro.
    if m['index'] in (0,5):
        pattern=r'(function Trig_Initialization_Actions\b[\s\S]*?)(    call QueuedTriggerAddBJ\( gg_trg_Intro_Cinematic_Q, true \))'
        script,count=re.subn(pattern,lambda match:match[1]+'    if RC_partyLoaded and RC_act[RC_sourceMap] == RC_act[RC_map] then\n        call ConditionalTriggerExecute(gg_trg_Import_All)\n        call ConditionalTriggerExecute(gg_trg_Resume_Game)\n    else\n'+match[2]+'\n    endif',script,count=1)
        if count!=1:raise ValueError('Hub initialization shape changed')
    # Replace config completely; NPC player 13 (revival stones) is never placed in
    # the twelve-slot lobby. Its gameplay player handle remains unchanged.
    config=['    call SetMapName("'+DISPLAY_PREFIX+m['name']+'")','    call SetMapDescription("Четыре героя, отдельные войска, три сложности и коды после миссии Z3. Продолжение: каждому -load КОД до -start.")',f'    call SetPlayers({len(players)})',f'    call SetTeams({len(players)})','    call SetGamePlacement(MAP_PLACEMENT_USE_MAP_SETTINGS)']
    controllers={0:'MAP_CONTROL_NONE',1:'MAP_CONTROL_USER',2:'MAP_CONTROL_COMPUTER',3:'MAP_CONTROL_NEUTRAL',4:'MAP_CONTROL_RESCUABLE'}
    races={1:'RACE_PREF_HUMAN',2:'RACE_PREF_ORC',3:'RACE_PREF_UNDEAD',4:'RACE_PREF_NIGHTELF'}
    teams={p['id']:n for n,force in enumerate(forces) for p in players if force['members']&(1<<p['id'])}
    for pos,p in enumerate(players):
        id=p['id'];team=teams[id]
        config += [f'    call DefineStartLocation({pos}, {float(p["x"])}, {float(p["y"])})',f'    call SetPlayerStartLocation(Player({id}), {pos})',f'    call ForcePlayerStartLocation(Player({id}), {pos})',f'    call SetPlayerColor(Player({id}), ConvertPlayerColor({id}))',f'    call SetPlayerController(Player({id}), {controllers[p["controller"]]})',f'    call SetPlayerTeam(Player({id}), {team})']
        config += [f'    call SetPlayerRacePreference(Player({id}), {races.get(p["race"],"RACE_PREF_RANDOM")})',f'    call SetPlayerRaceSelectable(Player({id}), false)']
        if id in ROLES:config += [f'    call SetPlayerSlotAvailable(Player({id}), MAP_CONTROL_USER)']
    for n,force in enumerate(forces):
        members=[p['id'] for p in players if force['members']&(1<<p['id'])]
        for a in members:
            if force['flags']&2:config.append(f'    call SetPlayerState(Player({a}), PLAYER_STATE_ALLIED_VICTORY, 1)')
            for b in members:
                if a==b:continue
                for flag,native in [(1,'ALLIANCE_PASSIVE'),(8,'ALLIANCE_SHARED_VISION'),(16,'ALLIANCE_SHARED_CONTROL'),(32,'ALLIANCE_SHARED_ADVANCED_CONTROL')]:
                    if force['flags']&flag:config.append(f'    call SetPlayerAlliance(Player({a}), Player({b}), {native}, true)')
    script=function(script,'config','\n'.join(config))
    script=script.replace('    call RunInitializationTriggers(  )','    call RC_Bootstrap()')
    if script.count('call RC_Bootstrap()')!=1:raise ValueError('Main initialization not gated')
    global_text=globals_text(m,len(schema))
    code=runtime.replace('// @@GLOBALS@@','').replace('// @@ITEMS@@',catalog.hooks(m['name'])).replace('// @@HOOKS@@',hooks(m,schema)).replace('// @@INIT@@',initialization(m))
    code=code.replace('// @@SKILLS@@',(ROOT/'runtime/skills.j').read_text()).replace('// @@BALANCE@@',(ROOT/'runtime/balance.j').read_text())
    code=code.replace('// @@CHECKPOINT@@',(ROOT/'runtime/checkpoint.j').read_text())
    script=script.replace('endglobals',global_text+'\nendglobals\n'+code,1)
    return classic_strings(script)

def globals_text(m,story_count):
    text='''
    string RC_alphabet = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz-_"
    string RC_filePrefix = "RX4-"
    boolean RC_codeOK = true
    boolean RC_started = false
    boolean RC_partyLoaded = false
    boolean RC_transitionPending = false
    boolean RC_stashRequired = false
    boolean RC_originalsGated = false
    boolean RC_saveOK = false
    boolean RC_checkpointLoaded = false
    integer RC_checkpoint = 0
    integer RC_storyChars = 0
    integer RC_checkpointLength = 0
    integer RC_itemCount = 0
    integer array RC_storyBits
    integer array RC_tempStory
    integer RC_bitValue = 0
    integer RC_bitPower = 1
    integer RC_bitPosition = 0
    string RC_bitText = ""
    string RC_loadedGroup = ""
    string array RC_checkpointCode
    string array RC_checkpointPart
    quest array RC_codeQuest
    boolean array RC_originalEnabled
    integer RC_host = 0
    integer RC_session = 1
    integer RC_map = 0
    integer RC_sourceMap = 0
    integer RC_nextMap = 0
    integer RC_nextArea = 0
    integer RC_difficulty = 1
    integer RC_storyCount = 0
    integer RC_defaultLevel = 2
    integer RC_seconds = 0
    integer RC_armyCounter = 0
    integer array RC_story
    integer array RC_flags
    integer array RC_zone
    integer array RC_act
    integer array RC_heroType
    integer array RC_skill
    integer array RC_deadSeconds
    string array RC_heroName
    string array RC_mapName
    string array RC_difficultyName
    string array RC_loadedHero
    string array RC_lastCode
    unit array RC_hero
    unit RC_stash = null
    unit RC_stashApplied = null
    string RC_loadedStash = ""
    integer array RC_extraItem
    integer array RC_extraCharges
    item array RC_extraDrop
    gamecache RC_cache = null
    hashtable RC_table = null
    hashtable RC_digits = null
    hashtable RC_items = null
    group RC_scratch = null
    group RC_army = null
    force RC_force = null
    timer RC_tickTimer = null
    timer RC_menuClock = null
    quest RC_saveQuest = null
    quest RC_helpQuest = null
    dialog RC_menu = null
    button array RC_difficultyButton
    real RC_xpRate = 0.30
    real RC_revivalX = 0.0
    real RC_revivalY = 0.0
'''
    return text + (ROOT/'runtime/kit-globals.j').read_text()

def initialization(m):
    index=m['index'];lines=[f'    set RC_map = {index}',f'    set RC_sourceMap = {index}',f'    set RC_nextMap = {index}',f'    set RC_storyCount = {m["storyCount"]}',f'    set RC_defaultLevel = {2 if index<5 else 8 if index<15 else 12}',f'    set RC_xpRate = {0.30 if index<5 else 0.25 if index<15 else 0.45}','    set RC_session = GetRandomInt(1, 4095)','    set RC_flags[0] = 1']
    for n,name in enumerate(MAPS):lines += [f'    set RC_mapName[{n}] = "{name}"',f'    set RC_act[{n}] = {1 if n<5 else 2 if n<15 else 3}',f'    set RC_zone[{n}] = {n+1 if n<5 else n-4 if n<15 else 0}']
    heroes=[('Orex','Рексар — повелитель стаи',['Arsg','Arsq','ANsb','Arsp','Aamk']),('Orkn','Рокхан — духолов',['ANhw','ANhx','Arsw','AOls','Aamk']),('Nsjs','Чэнь — мастер огня',['ANcf','Acdh','Acdb','Acef','Aamk']),('Ocb2','Кэрн — оплот предков',['AOs2','AOw2','AOr2','AOr3','Aamk'])]
    for role,(type,name,skills) in enumerate(heroes):
        lines += [f"    set RC_heroType[{role}] = '{type}'",f'    set RC_heroName[{role}] = "{name}"',f'    set RC_loadedHero[{role}] = ""']
        for skill,id in enumerate(skills):
            lines.append(f"    set RC_skill[{role*5+skill}] = '{kits.skill_id(role,skill) if skill<4 else id}'")
            if skill<4:lines.append(f"    set RC_oldSkill[{role*4+skill}] = '{id}'")
    for bit in range(16):lines.append(f"    set RC_hpBit[{bit}] = 'RH{bit:02}'")
    for rank in range(1,6):lines.append(f"    set RC_armorId[{rank}] = 'RD0{rank}'")
    for n,text in enumerate(['Лёгкая','Обычная','Тяжёлая']):lines.append(f'    set RC_difficultyName[{n}] = "{text}"')
    # All source quest stages are 0..9; booleans need one bit. The cumulative
    # bonus-skill counter retains RC1's full 0..4095 range.
    bits=[]
    for n,(name,typ) in enumerate(m['schema']):
        width=1 if typ=='boolean' else 12 if name=='udg_BonusSkillPointsGiven' else 4
        bits.append(width);lines.append(f'    set RC_storyBits[{n}] = {width}')
    chars=(sum(bits)+5)//6
    lines += [f'    set RC_storyChars = {chars}',f'    set RC_checkpointLength = {14+chars+48+12+3}',f'    set RC_itemCount = {m["itemCount"]}']
    for n in range(4):lines += [f'    set RC_checkpointCode[{n}] = ""',f'    set RC_checkpointPart[{n}] = ""']
    return '\n'.join(lines)

if __name__=='__main__':
    parser=argparse.ArgumentParser();parser.add_argument('--out',required=True);args=parser.parse_args();build(args.out)

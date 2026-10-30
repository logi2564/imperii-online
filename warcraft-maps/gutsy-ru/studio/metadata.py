"""Native order/target metadata and confined copies of actual ability data."""
import re
from data import slk

ORDERS={
 'AHtc':('thunderclap',0),'ANst':('stampede',2),'ANbf':('breathoffire',2),
 'AUcs':('carrionswarm',2),'Absk':('berserk',0),'AEfk':('fanofknives',0),
 'ANsi':('silence',2),'Aroa':('roar',0),'AOcl':('chainlightning',1),
 'AEtq':('tranquility',0),'AOsh':('shockwave',2),'ANfd':('fingerofdeath',1),
 'ANrf':('rainoffire',2),'AHbz':('blizzard',2),'ANcr':('chemicalrage',0),
 'Amls':('magicleash',1),'AEsf':('starfall',0),'AIta':('itemtelescope',2),
 'Ahwd':('healingward',2),'AOsf':('spiritwolf',0),'AOws':('stomp',0),
 'AOww':('whirlwind',0),'Aslo':('slow',1),'Aeye':('evileye',2),
 'Aens':('ensnare',1),'AOhw':('healingwave',1),'AHwe':('waterelemental',0),
 'AEsh':('shadowstrike',1),'ANcs':('clusterrockets',2),'ANfl':('forkedlightning',1),
 'Atau':('taunt',0),'AUls':('locustswarm',0),'ANto':('tornado',2),
 'AHmt':('massteleport',2),'ACtb':('creepthunderbolt',1),'AOwk':('windwalk',0),
 'AHhb':('holybolt',1),'AHpx':('phoenix',0),'AUfn':('frostnova',1),
}


def quoted(value):
    if re.fullmatch(r'-?(?:\d+(?:\.\d*)?|\.\d+)',str(value)):return str(value)
    return '"'+str(value).replace('"','""')+'"'


def append_rows(blob,rows):
    lines=blob.decode().splitlines();p=next(i for i,l in enumerate(lines) if l.startswith('B;'))
    headers={};x=y=0
    for line in lines:
        if not line.startswith('C;'):continue
        match=re.search(r';X(\d+)',line)
        if match:x=int(match[1])
        match=re.search(r';Y(\d+)',line)
        if match:y=int(match[1])
        if y==1:
            match=re.search(r';K"(.*)"',line)
            if match:headers[match[1].lower()]=x
    old_rows=max(int(v) for v in re.findall(r';Y(\d+)',blob.decode()))
    lines[p]=re.sub(r';Y\d+',';Y'+str(old_rows+len(rows)),lines[p])
    while lines and lines[-1] in ('E',''):lines.pop()
    for i,row in enumerate(rows,old_rows+1):
        for key,value in row.items():
            assert key in headers,key
            lines.append('C;X'+str(headers[key])+';Y'+str(i)+';K'+quoted(value))
    return ('\r\n'.join(lines)+'\r\nE\r\n').encode()


def build(st,archive,data,codes):
    blob=st.read(archive,'units\\abilitydata.slk');abilities=slk(blob)
    excluded={'Aloc','Avul','Amov','Aatk','AInv','Aneu','Asid','Aall','Apit','Awan'}
    aliases={};rows=[]
    for raw,row in abilities.items():
        if raw in excluded or row.get('code') in excluded:continue
        alias=codes.take('k');aliases[raw]=alias
        clone=dict(row);clone['alias']=alias;clone['checkdep']='0'
        # Native geometry cannot reach the actual arena from the unused north
        # rehearsal area. Original scripted distances remain original in SDX_.
        for field,value in list(clone.items()):
            if field.startswith(('rng','area','data')) and re.fullmatch(r'-?\d+(?:\.\d*)?',value):
                if row.get('code')=='ANcl' and field.startswith('data'):continue
                number=float(value)
                if 2500<abs(number)<10000000:clone[field]=str(2500 if number>0 else -2500)
        rows.append(clone)
    helper={}
    for key,base,amount in [('mana','AImz',20000),('life','AIlf',200000)]:
        raw=codes.take('k');helper[key]=raw
        rows.append(dict(abilities[base],alias=raw,dataa1=str(amount),checkdep='0'))
    skills=[]
    unit_abilities=slk(st.read(archive,'units\\unitabilities.slk'))
    aliases_heroes=data.get('aliases',[])
    for h,hero in enumerate(data['heroes']):
        for skill in hero['skills']:
            raw=skill['raw'];row=abilities.get(raw,{});code=row.get('code','')
            order,target=ORDERS.get(code,('',0))
            if code=='ANcl':order=row.get('dataf1','channel');target=int(float(row.get('datab1','0')))
            actor=hero['raw']
            if skill.get('additionalForm'):
                for alias in aliases_heroes:
                    if alias.get('hero')==h and raw in unit_abilities.get(alias['raw'],{}).get('abillist','').split(','):
                        actor=alias['raw'];break
            skills.append(dict(index=skill['index'],hero=h,raw=raw,actor=actor,code=code,order=order,
                               target=target,ally='friend' in row.get('targs1','') or 'allies' in row.get('targs1',''),
                               level=max(1,int(float(row.get('levels','1')))),passive=not bool(order)))
    result=append_rows(blob,rows)
    parsed=slk(result)
    for raw,row in abilities.items():assert parsed[raw]==row,raw
    for row in rows:assert parsed[row['alias']]==row,row['alias']
    edits={'units\\abilitydata.slk':result}
    for name in st.read(archive,'(listfile)').decode().splitlines():
        if not name.lower().endswith(('abilitystrings.txt','abilityfunc.txt')):continue
        profile=st.read(archive,name)
        sections=re.split(rb'(?m)(?=^\[[^\]\r\n]+\])',profile)
        copies=[]
        for section in sections:
            match=re.match(rb'\[([^\]]+)\]',section)
            if match and match[1].decode() in aliases:
                alias=aliases[match[1].decode()]
                copies.append(b'['+alias.encode()+b']'+section[match.end():])
        if copies:edits[name]=profile+b'\r\n'+b'\r\n'.join(copies)
    return edits,dict(aliases=aliases,helper=helper,skills=skills,
        originalAbilityRowsPreserved=True,confinedNativeGeometry=2500)

"""One object namespace, retaining the released portable item identities."""
import copy,hashlib,json,re
from build import Catalog,KINDS
from formats import read_objects
from kits import HEROES

EXTRA_KINDS={'upgrade':('war3map.w3q',True),'destructable':('war3map.w3b',False),'doodad':('war3map.w3d',True)}
ALL_KINDS={**KINDS,**EXTRA_KINDS}

class UnifiedCatalog(Catalog):
    def __init__(self,maps):
        # This first pass is deliberately unchanged: RIxx and the compact item
        # indices used by VI saves must keep their existing meaning.
        old=Catalog(maps).build();self.__dict__.update(old.__dict__)
        for kind in EXTRA_KINDS:self.output[kind]=[]
        for m in maps.values():
            for kind,(filename,leveled) in EXTRA_KINDS.items():
                tables=read_objects(m['data'].get(filename),leveled);m[kind]=tables
                m['lookup'][kind]={o['old'] if table==0 else o['new']:o for table,objects in enumerate(tables) for o in objects if o['mods']}
        self.raw_maps={}
        for name,m in maps.items():
            mapping={}
            for kind in ALL_KINDS:
                for raw in sorted(m['lookup'][kind]):
                    new=self.clone(name,kind,raw)
                    if raw in mapping and mapping[raw]!=new:raise ValueError('Ambiguous rawcode '+name+' '+raw.decode())
                    mapping[raw]=new
            self.raw_maps[name]=mapping

    def dependencies(self,m,mod):
        if mod[1]!=3 or mod[0] in {'unam','upro','utip','utub','ides','anam','atp1','aub1','arut','aret','urqa'}:return []
        text=mod[4].decode('utf8',errors='replace')
        if not re.fullmatch(r'[A-Za-z0-9_, ]+',text):return []
        result=[]
        for token in re.findall(r'\b[A-Za-z0-9_]{4}\b',text):
            for kind in ['ability','buff','unit','item','upgrade','destructable','doodad']:
                if token.encode() in m['lookup'].get(kind,{}):result.append((token,kind));break
        return result

    def clone(self,name,kind,raw):
        if kind=='unit' and raw.decode() in HEROES:return raw
        key=(name,kind,raw)
        if key in self.cache:return self.cache[key]
        m=self.maps[name];obj=m['lookup'][kind].get(raw)
        if obj is None:return raw
        identity=hashlib.sha256(json.dumps(self.signature(name,kind,raw),sort_keys=True).encode()).hexdigest();dedup=(kind,identity)
        if dedup in self.identities:self.cache[key]=self.identities[dedup];return self.cache[key]
        number=len(self.output[kind]);alphabet='0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz'
        if number>=62*62:raise ValueError('Unified object namespace exhausted: '+kind)
        prefix={'item':'RI','ability':'RA','unit':'RU' if obj['old'][0]<97 else 'rU','buff':'RB','upgrade':'rQ','destructable':'rB','doodad':'rD'}[kind]
        alias=(prefix+alphabet[number//62]+alphabet[number%62]).encode();self.cache[key]=alias;self.identities[dedup]=alias
        target=dict(old=obj['old'],new=alias,mods=[]);self.output[kind].append(target)
        base=m['lookup'][kind].get(obj['old']) if obj['new']!=b'\0'*4 else None
        mods=(base['mods'] if base is not None and base is not obj else [])+obj['mods']
        for mod in mods:
            new=copy.deepcopy(mod);new[4]=self.resolve(m,new[4]);new[5]=b'\0'*4
            if new[1]==3:
                for token,dependency in self.dependencies(m,mod):
                    alias_value=self.clone(name,dependency,token.encode())
                    new[4]=re.sub(rb'(?<![A-Za-z0-9_])'+re.escape(token.encode())+rb'(?![A-Za-z0-9_])',alias_value,new[4])
            target['mods'].append(new)
        return alias

    def unified_hooks(self):
        writes=[]
        for index,raw in enumerate(self.compact[1:],1):writes.extend([f"    call SaveInteger(RC_items, '{raw.decode()}', 2, {index})",f"    call SaveInteger(RC_items, {index}, 3, '{raw.decode()}')"])
        lines=[];names=[]
        for start in range(0,len(writes),128):
            name='UZ_Items'+str(start//128);names.append(name)
            lines.append('\n'.join([f'function {name} takes nothing returns nothing']+writes[start:start+128]+['endfunction']))
        lines.append('\n'.join(['function RC_InitItems takes nothing returns nothing']+[f'    call {name}()' for name in names]+['endfunction']))
        for fn in ['RC_ItemToPortable','RC_ItemToLocal']:lines.append(f'function {fn} takes integer id returns integer\n    return id\nendfunction')
        return '\n\n'.join(lines)

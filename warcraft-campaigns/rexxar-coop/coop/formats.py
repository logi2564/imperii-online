"""Lossless classic W3I/object editing; no changes to terrain or imports."""
import copy
import struct
import json
from pathlib import Path

ABILITY_POINTERS=json.loads(Path(__file__).with_name('ability-pointers.json').read_text())

class Reader:
    def __init__(self,data):self.data=data;self.p=0
    def read(self,n):
        if n<0 or self.p+n>len(self.data):raise ValueError('Unexpected end of Warcraft data')
        b=self.data[self.p:self.p+n];self.p+=n;return b
    def i(self):return struct.unpack('<i',self.read(4))[0]
    def f(self):return struct.unpack('<f',self.read(4))[0]
    def s(self):
        end=self.data.index(0,self.p);b=self.read(end-self.p);self.read(1);return b

def i(v):return struct.pack('<i',v)
def s(v):return v.encode('utf8')+b'\0' if isinstance(v,str) else v+b'\0'

def read_info(data):
    r=Reader(data);version=r.i()
    if version!=25:raise ValueError('Expected original TFT W3I 25')
    r.read(8);title=(r.p,None);r.s();title=(title[0],r.p);r.s();r.s();recommendation=r.p;r.s();after_recommendation=r.p
    r.read(56);flags=r.p;r.read(5);r.i();r.s()
    for _ in range(3):r.s()
    r.i();r.s()
    for _ in range(3):r.s()
    r.read(24);r.s();r.read(5);start=r.p
    players=[]
    for _ in range(r.i()):
        players.append(dict(id=r.i(),controller=r.i(),race=r.i(),flags=r.i(),name=r.s(),x=r.f(),y=r.f(),low=r.i(),high=r.i()))
    forces=[]
    for _ in range(r.i()):forces.append(dict(flags=r.i(),members=r.i(),name=r.s()))
    return dict(prefix=data[:start],tail=data[r.p:],flags_offset=flags,title=title,recommendation=(recommendation,after_recommendation),players=players,forces=forces)

def coop_info(data,remap,roles,title=None):
    info=read_info(data);host=copy.deepcopy(next(p for p in info['players'] if p['id']==0));players=[]
    source_ids={p['id'] for p in info['players']}
    for p in info['players']:
        p=copy.deepcopy(p);p['id']=remap.get(p['id'],p['id'])
        if p['id']<12:players.append(p)
    for role,id in enumerate(roles):
        p=next((p for p in players if p['id']==id),None)
        if p is None:p=copy.deepcopy(host);p['id']=id;players.append(p)
        p.update(controller=1,race=2,flags=1,name=['Рексар — охотник','Рокхан — духолов','Чэнь — мастер огня','Кэрн — оплот'][role].encode(),x=host['x'],y=host['y'],low=0,high=sum(1<<x for x in roles if x!=id))
    if len(players)>12 or len({p['id'] for p in players})!=len(players):raise ValueError('Invalid player remapping')
    # World Editor normally emits records in colour order. Host bots construct
    # network slot order from these records, so never append the humans after
    # unsorted remapped NPC records (the RC1/RC2 output did this).
    players.sort(key=lambda p:p['id'])
    present=sum(1<<p['id'] for p in players)
    for p in players:
        p['low']=0;p['high']=sum(1<<x for x in roles if x!=p['id']) if p['id'] in roles else 0
    info['players']=players;party=sum(1<<x for x in roles);forces=[]
    for force in info['forces']:
        members=0
        for id in source_ids:
            if force['members']&(1<<id):
                mapped=remap.get(id,id)
                if mapped<12 and mapped not in roles:members|=1<<mapped
        members&=present
        if members:forces.append(dict(flags=force['flags'],members=members,name=force['name']))
    # GHost assigns a repeated colour to the LAST force containing it. Preserve
    # that effective assignment while removing overlap/absent-colour masks.
    claimed=party
    for force in reversed(forces):
        force['members']&=~claimed;claimed|=force['members']
    forces=[force for force in forces if force['members']]
    for p in players:
        if not claimed&(1<<p['id']):
            forces.append(dict(flags=0,members=1<<p['id'],name=b'NPC'));claimed|=1<<p['id']
    forces.insert(0,dict(flags=1|2|8,members=party,name='Четверо героев Орды'.encode()))
    prefix=bytearray(info['prefix']);struct.pack_into('<i',prefix,info['flags_offset'],(struct.unpack_from('<i',prefix,info['flags_offset'])[0]|0x60)&~4)
    a,b=info['recommendation'];prefix=bytes(prefix[:a])+s('4 игрока / кооператив')+bytes(prefix[b:])
    if title is not None:
        a,b=info['title'];prefix=prefix[:a]+s(title)+prefix[b:]
    out=prefix+i(len(players))
    for p in players:out+=b''.join(i(p[k]) for k in ['id','controller','race','flags'])+s(p['name'])+struct.pack('<ffii',p['x'],p['y'],p['low'],p['high'])
    out+=i(len(forces))
    for f in forces:out+=i(f['flags'])+i(f['members'])+s(f['name'])
    return out+info['tail'],players

def read_objects(data,leveled=False):
    if data is None:return [[],[]]
    if leveled=='doodad':
        # Act I contains legacy simple W3D records; later acts have the two
        # variation/data-pointer integers. Normalize both to classic v2 output.
        try:return read_objects(data,True)
        except (ValueError,UnicodeError,IndexError,struct.error):return read_objects(data,False)
    r=Reader(data)
    if r.i() not in (1,2):raise ValueError('Expected classic object format 1/2')
    tables=[]
    for _ in range(2):
        objects=[]
        for _ in range(r.i()):
            obj={'old':r.read(4),'new':r.read(4),'mods':[]}
            for _ in range(r.i()):
                field=r.read(4).decode('ascii');typ=r.i()
                level,ptr=(r.i(),r.i()) if leveled else (0,0)
                value=r.s() if typ==3 else r.read(4)
                end=r.read(4);obj['mods'].append([field,typ,level,ptr,value,end])
            objects.append(obj)
        tables.append(objects)
    if r.p!=len(data):raise ValueError('Object file trailing bytes')
    return tables

def write_objects(tables,leveled=False):
    out=i(2)
    for table in tables:
        out+=i(len(table))
        for obj in table:
            out+=obj['old']+obj['new']+i(len(obj['mods']))
            for field,typ,level,ptr,value,end in obj['mods']:
                extra=i(level)+i(ptr) if leveled else b''
                out+=field.encode()+i(typ)+extra+(s(value) if typ==3 else value)+end
    return out

def field(name,typ,value,level=0):
    value=str(value).encode() if typ==3 else (i(value) if typ==0 else struct.pack('<f',value))
    return [name,typ,level,ABILITY_POINTERS.get(name,0) if level else 0,value,b'\0'*4]

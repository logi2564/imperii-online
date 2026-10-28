"""Lossless classic W3I/object editing; no changes to terrain or imports."""
import struct

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

def read_objects(data,leveled=False):
    if data is None:return [[],[]]
    r=Reader(data)
    if r.i() not in (1,2):raise ValueError('Expected classic object format 1/2')
    tables=[]
    for _ in range(2):
        objects=[]
        for _ in range(r.i()):
            obj={'old':r.read(4),'new':r.read(4),'mods':[]}
            for _ in range(r.i()):
                field=r.read(4).decode('ascii');typ=r.i();level,ptr=(r.i(),r.i()) if leveled else (0,0)
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
                out+=field.encode()+i(typ)+(i(level)+i(ptr) if leveled else b'')+(s(value) if typ==3 else value)+end
    return out

def field(name,typ,value,level=0):
    value=str(value).encode() if typ==3 else (i(value) if typ==0 else struct.pack('<f',value))
    return [name,typ,level,0,value,b'\0'*4]

"""Store long tooltips in standard WTS-backed ability overrides for classic WC3.

The SLK-optimized original keeps every TXT value below 1024 bytes. Do not
expand those fixed parser buffers with UTF-8 translations; object overrides
contain short TRIGSTR references, while WTS retains the complete description.
"""
import re,struct
from catalog import Reader

CELL_LIMIT=1023
LINE_LIMIT=4095
TOOLTIP_FIELDS={'tip':b'atp1','ubertip':b'aub1','researchtip':b'aret','researchubertip':b'arut'}

def read_objects(blob):
    r=Reader(blob);version=r.i();assert version==2
    tables=[]
    for _ in range(2):
        objects=[]
        for _ in range(r.i()):
            obj=dict(old=r.read(4),new=r.read(4),mods=[])
            for _ in range(r.i()):
                field=r.read(4);kind=r.i();level=r.i();pointer=r.i()
                if kind==3:
                    start=r.p;r.string();value=r.data[start:r.p]
                else:value=r.read(4)
                obj['mods'].append(dict(field=field,kind=kind,level=level,pointer=pointer,value=value,end=r.read(4)))
            objects.append(obj)
        tables.append(objects)
    assert r.p==len(blob)
    return tables

def write_objects(tables):
    out=bytearray(struct.pack('<i',2))
    for table in tables:
        out+=struct.pack('<i',len(table))
        for obj in table:
            out+=obj['old']+obj['new']+struct.pack('<i',len(obj['mods']))
            for m in obj['mods']:
                out+=m['field']+struct.pack('<iii',m['kind'],m['level'],m['pointer'])+m['value']+m['end']
    return bytes(out)

def ability_levels(blob,tables):
    rows={};x=y=0
    for line in blob.splitlines():
        if not line.startswith(b'C;'):continue
        mx=re.search(rb'(?:^|;)X(\d+)',line);my=re.search(rb'(?:^|;)Y(\d+)',line)
        if mx:x=int(mx[1])
        if my:y=int(my[1])
        value=re.search(rb'(?:^|;)K("(?:[^"]|"")*"|[^;]+)',line)
        if value and x in (1,11):rows.setdefault(y,{})[x]=value[1].strip(b'"')
    assert rows[1][1]==b'alias' and rows[1][11]==b'levels'
    result={v[1]:int(v[11]) for row,v in rows.items() if row>1 and 1 in v and 11 in v}
    for table in tables:
        for obj in table:
            raw=obj['new'] if obj['new']!=bytes(4) else obj['old']
            if raw not in result and obj['old'] in result:result[raw]=result[obj['old']]
            for m in obj['mods']:
                if m['field']==b'alev' and m['kind']==0:result[raw]=struct.unpack('<i',m['value'])[0]
    return result

def migrate(blob,levels_blob,requests):
    tables=read_objects(blob);levels=ability_levels(levels_blob,tables)
    by_id={(o['new'] if o['new']!=bytes(4) else o['old']):o for table in tables for o in table}
    entries={};records=[]
    def store(raw,mod,text,origin):
        assert mod['field'] in TOOLTIP_FIELDS.values() and mod['kind']==3
        assert raw in levels,raw
        if mod['field'] in (b'aub1',b'atp1'):assert 1<=mod['level']<=levels[raw],(raw,mod['level'],levels[raw])
        index=len(entries)+1;entries[index]=text
        reference=f'TRIGSTR_{index:06d}'
        mod['value']=reference.encode()+b'\0'
        records.append(dict(id=raw.decode(),field=mod['field'].decode(),level=mod['level'],reference=reference,text=text,origin=origin))
    for request in requests:
        raw=request['id'].encode();field=request['field'].encode();level=request['level']
        obj=by_id.get(raw)
        if obj is not None and any(m['field']==field and m['level']==level for m in obj['mods']):
            # An original binary override takes priority over the base TXT.
            # Keep its separately localized text, rather than changing it.
            continue
        if obj is None:
            obj=dict(old=raw,new=bytes(4),mods=[]);tables[0].append(obj);by_id[raw]=obj
        mod=dict(field=field,kind=3,level=level,pointer=0,value=b'',end=bytes(4))
        store(raw,mod,request['text'],'txt');obj['mods'].append(mod)
    for raw,obj in by_id.items():
        for m in obj['mods']:
            if m['kind']!=3 or m['field'] not in TOOLTIP_FIELDS.values():continue
            text=m['value'][:-1].decode()
            if len(text.encode())>CELL_LIMIT:store(raw,m,text,'original-object')
    wts=''.join(f'STRING {index}\n{{\n{text}\n}}\n\n' for index,text in entries.items())
    assert all(len(line.encode())<=LINE_LIMIT for line in wts.splitlines())
    return write_objects(tables),wts.encode('utf8'),records

def parse_wts(blob):
    return {int(m[1]):m[2] for m in re.finditer(r'(?ms)^STRING (\d+)\r?\n\{\r?\n(.*?)\r?\n\}',blob.decode())}

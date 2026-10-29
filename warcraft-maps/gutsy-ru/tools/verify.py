"""Check the final MPQ independently of the translation writer."""
import csv,hashlib,json,re,sys
from pathlib import Path
from catalog import Reader,decode_jass,prose
from storm import Storm
from inline_tooltips import CELL_LIMIT,LINE_LIMIT,TOOLTIP_FIELDS,tooltip_fingerprint

ROOT=Path(__file__).resolve().parents[1]
LEX=re.compile(r'//[^\r\n]*|"(?:[^"\\]|\\.)*"|\'(?:[^\'\\]|\\.)*\'|[A-Za-z_]\w*|\d+(?:\.\d*)?(?:[eE][+-]?\d+)?|[^\s]')

def script_tokens(text,editable=()):
    editable=set(editable);stack=[];longest=0
    for m in LEX.finditer(text):
        token=m[0]
        if token.startswith('//'):continue
        if token.startswith('"'):
            longest=max(longest,len(token.encode())-2)
            stack.append(('string',decode_jass(token),m.start() in editable))
        else:stack.append(('code',token,False))
        # Splitting a long translated literal only adds a parenthesized
        # constant concatenation. Fold those on both sides before comparison.
        if token==')':
            end=len(stack)-2;start=end
            while start>=0 and stack[start][0]=='string':
                if start>0 and stack[start-1][1]=='(':
                    group=stack[start:end+1]
                    if all(t[0]=='string' if i%2==0 else t[1]=='+' for i,t in enumerate(group)):
                        stack[start-1:]=[('string',''.join(t[1] for t in group if t[0]=='string'),any(t[2] for t in group))]
                    break
                if start<2 or stack[start-1][1]!='+':break
                start-=2
    return stack,longest

def text_records(blob):
    section='';out=[]
    for line in blob.decode().splitlines():
        if line.startswith('['):section=line[1:line.find(']')]
        if '=' in line and not line.startswith('//'):
            key,value=line.split('=',1);out.append((section+':'+key,value))
    return out

def check_txt_limits(st,archive,names):
    max_cell=max_line=0
    for name in names:
        if not name.lower().endswith('.txt'):continue
        for number,line in enumerate(st.read(archive,name).decode().splitlines(),1):
            if '=' not in line or line.startswith('//'):continue
            cells=next(csv.reader([line.split('=',1)[1]]))
            max_line=max(max_line,len(line.encode()))
            max_cell=max(max_cell,max((len(v.encode()) for v in cells),default=0))
            assert len(line.encode())<=LINE_LIMIT,(name,number,'TXT line exceeds 4095 bytes')
            assert all(len(v.encode())<=CELL_LIMIT for v in cells),(name,number,'TXT value exceeds 1023 bytes')
            assert all('"' not in v for v in cells),(name,number,'Nested ASCII quote')
    return max_cell,max_line

def check_text_storage(st,original,actual,catalog,cache,records):
    # Check actual inline strings, not an assumed TXT -> WTS resolution.
    # This catches FIX1's added object/WTS layer even if a custom resolver
    # would consider its descriptions complete.
    assert st.read(original,'war3map.wts') is None
    assert st.read(actual,'war3map.wts') is None,'Unexpected WTS dependency'
    indexed={}
    for record in records:
        key=(record['file'],record['context'],record.get('rank'))
        assert key not in indexed,key
        indexed[key]=record
        assert record['storage'] in ('original-inline-txt','original-inline-object')
        assert tooltip_fingerprint(record['fullText'])==tooltip_fingerprint(record['inlineText'])
    seen=set();checked=0;nonempty=0;max_object=0
    def expected_text(value):
        text=cache[value] if prose(value) else value
        if '\n' not in value and '\r' not in value:text=text.replace('\r\n','|n').replace('\n','|n').replace('\r','|n')
        return text
    def check(value,text,key):
        nonlocal checked,nonempty
        expected=expected_text(value)
        record=indexed.get(key)
        if record:
            assert expected==record['fullText'],key
            expected=record['inlineText'];seen.add(key)
        assert text==expected,(key,'Inline Russian tooltip differs')
        assert not value.strip() or text.strip(),(key,'Description disappeared')
        assert not re.search(r'TRIGSTR_\d+',text),(key,'Unresolved WTS reference')
        assert len(text.encode())<=CELL_LIMIT,(key,'Inline tooltip too long')
        checked+=1
        if value.strip():nonempty+=1
    for name in catalog['files']:
        if not name.lower().endswith('abilitystrings.txt'):continue
        old_rows=text_records(st.read(original,name));new_rows=text_records(st.read(actual,name))
        assert len(old_rows)==len(new_rows),name
        for (context,before),(other,after) in zip(old_rows,new_rows):
            assert context==other
            if context.split(':',1)[1].lower() not in TOOLTIP_FIELDS:continue
            source=next(csv.reader([before]));target=next(csv.reader([after]))
            assert len(source)==len(target),(name,context)
            for rank,(value,text) in enumerate(zip(source,target),1):check(value,text,(name,context,rank))
    # Existing binary fields can take precedence over TXT. All original
    # records and numeric data are compared separately by object_records.
    source=st.read(original,'war3map.w3a');target=st.read(actual,'war3map.w3a')
    def tooltip_mods(blob):
        r=Reader(blob);assert r.i()==2;mods=[];shape=[]
        for table in range(2):
            count=r.i();shape.append(count)
            for _ in range(count):
                old,new=r.read(4),r.read(4);raw=old if table==0 else new
                count=r.i();shape.append((old,new,count))
                for _ in range(count):
                    field,kind=r.read(4),r.i();level,pointer=r.i(),r.i()
                    if kind==3:
                        _,_,text=r.string()
                        if field in TOOLTIP_FIELDS.values():mods.append((raw.decode()+':'+field.decode(),level,pointer,text))
                    else:r.read(4)
                    r.read(4)
        assert r.p==len(blob)
        return shape,mods
    old_shape,old_mods=tooltip_mods(source);new_shape,new_mods=tooltip_mods(target)
    assert old_shape==new_shape,'Ability objects/modifications were added or removed'
    assert len(old_mods)==len(new_mods)
    for (context,rank,pointer,value),(other,other_rank,other_pointer,text) in zip(old_mods,new_mods):
        assert (context,rank,pointer)==(other,other_rank,other_pointer)
        check(value,text,('war3map.w3a',context,None));max_object=max(max_object,len(text.encode()))
    assert seen==set(indexed),('Unverified compact tooltips',set(indexed)-seen)
    return checked,nonempty,max_object

def object_records(blob,leveled,editable):
    r=Reader(blob);version=r.i();out=[version]
    for table in range(2):
        count=r.i();out.append(count)
        for _ in range(count):
            old,new=r.read(4),r.read(4);out.extend([old,new]);raw=old if table==0 else new
            if version==3:
                n=r.i();out.extend([n,r.read(4*n)])
            n=r.i();out.append(n)
            for _ in range(n):
                field=r.read(4);kind=r.i();out.extend([field,kind])
                if leveled:out.append(r.read(8))
                if kind==3:
                    _,_,text=r.string();context=raw.decode()+':'+field.decode()
                    out.append('<TRANSLATED>' if context in editable else text)
                else:out.append(r.read(4))
                out.append(r.read(4))
    assert r.p==len(blob)
    return out

def info_records(blob,editable):
    r=Reader(blob);out=[]
    def fixed(n):out.append(r.read(n))
    def integer():n=r.i();out.append(n);return n
    def string(context):
        _,_,text=r.string();out.append('<TRANSLATED>' if context in editable else text)
    assert integer()==25;fixed(8)
    for i in range(4):string('map-info:'+str(i))
    fixed(61);integer();string('loading-model')
    for i in range(3):string('loading:'+str(i))
    integer();string('prologue-model')
    for i in range(3):string('prologue:'+str(i))
    fixed(24);string('sound-environment');fixed(5)
    for i in range(integer()):fixed(16);string('lobby-player:'+str(i));fixed(16)
    for i in range(integer()):fixed(8);string('lobby-force:'+str(i))
    fixed(len(blob)-r.p)
    return out

def verify(source_path,output_dir):
    source_path=Path(source_path);out=Path(output_dir)
    meta=json.loads((out/'Localization-report.json').read_text())
    catalog=json.loads((out/'catalog.json').read_text())
    translated=json.loads((out/'Translations.json').read_text())
    storage=json.loads((out/'Text-storage.json').read_text())
    target=out/'Gutsy-Geoid-Game-RU-v1.0.5.w3x'
    assert hashlib.sha256(source_path.read_bytes()).hexdigest()==meta['source']['sha256']
    assert hashlib.sha256(target.read_bytes()).hexdigest()==meta['sha256']
    assert all(s in translated for s in catalog['phrases'])
    assert not any(re.search(r'ZXQ\d+QXZ|\ue000|\ue001|[\uac00-\ud7ff\u3040-\u30ff\u3400-\u9fff]',translated[s]) for s in catalog['phrases'])
    st=Storm();a=st.open(source_path);b=st.open(target);kept=0;audio=0
    try:
        names=(st.read(a,'(listfile)') or b'').decode().splitlines()
        for name in names:
            if name.startswith('('):continue
            original=st.read(a,name);actual=st.read(b,name);assert actual is not None,name
            if name not in catalog['files']:assert original==actual,name
            if name.lower().endswith(('.wav','.mp3','.ogg')):assert original==actual;audio+=1
            kept+=1
        old=st.read(a,'war3map.j').decode();new=st.read(b,'war3map.j').decode()
        max_cell,max_line=check_txt_limits(st,b,catalog['files'])
        effective_texts,nonempty_tooltips,max_object=check_text_storage(st,a,b,catalog,translated,storage)
        x,_=script_tokens(old,[s['start'] for s in catalog['files']['war3map.j']['spans']]);y,longest=script_tokens(new)
        assert len(x)==len(y),(len(x),len(y))
        mutable=0
        for i,(before,after) in enumerate(zip(x,y)):
            assert before[0]==after[0],(i,before,after)
            if before[0]=='code' or not before[2]:assert before[1]==after[1],(i,before,after)
            else:mutable+=1
        assert longest<=1023,longest
        for name,file in catalog['files'].items():
            original=st.read(a,name);actual=st.read(b,name);editable={s['context'] for s in file['spans']}
            lower=name.lower()
            if lower.endswith('.txt'):
                old_rows=text_records(original);new_rows=text_records(actual)
                assert len(old_rows)==len(new_rows),name
                for (key,value),(other,new_value) in zip(old_rows,new_rows):
                    assert key==other,(name,key,other)
                    if key not in editable:assert value==new_value,(name,key)
                    else:assert len(next(csv.reader([value])))==len(next(csv.reader([new_value]))),(name,key)
            elif lower.endswith(('.w3u','.w3a','.w3t','.w3h','.w3q')):
                leveled=lower.endswith(('.w3a','.w3q'))
                assert object_records(original,leveled,editable)==object_records(actual,leveled,editable),name
            elif lower.endswith('.w3i'):
                assert info_records(original,editable)==info_records(actual,editable),name
            elif lower.endswith('.slk'):
                old_lines=original.splitlines(keepends=True);new_lines=actual.splitlines(keepends=True)
                assert len(old_lines)==len(new_lines),name
                pos=0
                for before,after in zip(old_lines,new_lines):
                    spans=[s for s in file['spans'] if pos<=s['start']<pos+len(before)]
                    if spans:
                        pattern=rb'K"(?:[^"]|"")*"'
                        assert re.sub(pattern,b'K"<TEXT>"',before)==re.sub(pattern,b'K"<TEXT>"',after),name
                    else:assert before==after,name
                    pos+=len(before)
    finally:st.close(a);st.close(b)
    result=dict(retainedFiles=kept,unchangedAudioFiles=audio,playerTextEntries=len(catalog['phrases']),jassCodeTokens=len(x),translatedJassConstants=mutable,maxJassLiteralBytes=longest,gameplayConstantsAndIdentifiersUnchanged=True,commandsAndAssetPathsUnchanged=True,nativeWarcraftTested=False,maxTxtValueBytes=max_cell,maxTxtLineBytes=max_line,addedWtsReferences=0,addedAbilityModifications=0,compactTooltips=len(storage),inlineTooltipsVerified=effective_texts,nonemptyTooltipsVerified=nonempty_tooltips,maxInlineObjectTooltipBytes=max_object)
    (out/'Verification-report.json').write_text(json.dumps(result,ensure_ascii=False,indent=2))
    print('PASS archive/assets/audio, JASS code and non-text literals, classic string limits, object statistics/IDs, TXT ranks/keys, SLK numeric cells and lobby settings.')
    print(json.dumps(result,ensure_ascii=False))

if __name__=='__main__':verify(*sys.argv[1:3])

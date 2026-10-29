"""Check the final MPQ independently of the translation writer."""
import csv,hashlib,json,re,sys
from pathlib import Path
from catalog import Reader,decode_jass
from storm import Storm

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
    result=dict(retainedFiles=kept,unchangedAudioFiles=audio,playerTextEntries=len(catalog['phrases']),jassCodeTokens=len(x),translatedJassConstants=mutable,maxJassLiteralBytes=longest,gameplayConstantsAndIdentifiersUnchanged=True,commandsAndAssetPathsUnchanged=True,nativeWarcraftTested=False)
    (out/'Verification-report.json').write_text(json.dumps(result,ensure_ascii=False,indent=2))
    print('PASS archive/assets/audio, JASS code and non-text literals, classic string limits, object statistics/IDs, TXT ranks/keys, SLK numeric cells and lobby settings.')
    print(json.dumps(result,ensure_ascii=False))

if __name__=='__main__':verify(*sys.argv[1:3])

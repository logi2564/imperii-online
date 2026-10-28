"""Lossless player-text spans in the original SLK-optimized Warcraft map."""
import csv,io,json,re,struct,hashlib
from collections import defaultdict,deque
STR=re.compile(r'"(?:[^"\\]|\\.)*"')
LEX=re.compile(r'//[^\r\n]*|"(?:[^"\\]|\\.)*"|\'(?:[^\'\\]|\\.)*\'')
FUNC=re.compile(r'(?m)^function (\w+) takes ([^\r\n]+) returns (\w+)')
DISPLAY={'name','propernames','tip','ubertip','awakentip','revivetip','description','researchtip','researchubertip','untip','unubertip','editorsuffix','bufftip','buffubertip'}
OBJDISPLAY={'unam','upro','utip','utub','uawt','urev','ides','anam','ansf','atp1','aub1','aut1','auu1','aret','arut','fnam','ftip','fube','gnam','gtp1','gub1','bnam','bsuf','dnam'}
UI={'DisplayTextToPlayer':[3],'DisplayTimedTextToPlayer':[4],'DisplayTextToForce':[1],'DisplayTimedTextToForce':[2],'BJDebugMsg':[0],'SetTextTagText':[1],'SetTextTagTextBJ':[0],'CreateTextTagLocBJ':[0],'CreateTextTagUnitBJ':[0],'DialogSetMessage':[1],'DialogAddButton':[1],'DialogAddButtonBJ':[1],'MultiboardSetItemValue':[1],'MultiboardSetItemValueBJ':[3],'MultiboardSetTitleText':[1],'LeaderboardSetLabel':[1],'LeaderboardAddItem':[1],'CreateMultiboardBJ':[2],'CreateQuestBJ':[1,2],'CreateQuestItemBJ':[1],'QuestSetTitle':[1],'QuestSetDescription':[1],'QuestItemSetDescription':[1],'QuestMessageBJ':[2],'TimerDialogSetTitle':[1],'CreateTimerDialogBJ':[1],'SetMapName':[0],'SetMapDescription':[0],'SetPlayerName':[1],'BlzFrameSetText':[1],'DzFrameSetText':[1],'BlzSetUnitName':[1],'BlzSetHeroProperName':[1],'BlzSetItemName':[1],'BlzSetItemDescription':[1],'BlzSetItemTooltip':[1],'BlzSetItemExtendedTooltip':[1],'BlzSetAbilityTooltip':[1],'BlzSetAbilityExtendedTooltip':[1],'BlzSetAbilityResearchTooltip':[1],'BlzSetAbilityResearchExtendedTooltip':[1]}
TECH=re.compile(r'^(?:TRIGSTR_\d+|(?:WESTRING|UISTR|WESTRING)_[A-Z0-9_]+|[A-Za-z_]+\.[A-Za-z]{2,4})$')
LETTERS=re.compile(r'[A-Za-z]{2}|[\uac00-\ud7ff\u3040-\u30ff\u3400-\u9fff]')

def mask(s):return LEX.sub(lambda m:re.sub(r'[^\r\n]',' ',m[0]),s)
def arguments(s,start):
 depth=1;first=start+1;args=[]
 for n in range(start+1,len(s)):
  c=s[n]
  if c=='(':depth+=1
  elif c==')':
   depth-=1
   if depth==0:return args+[(first,n)]
  elif c==',' and depth==1:args.append((first,n));first=n+1
 raise ValueError('Unbalanced original script call')

def prose(s):
 plain=re.sub(r'(?i)\|c[0-9a-f]{8}|\|[rnt]', '', s)
 if not LETTERS.search(plain) or TECH.fullmatch(s.strip()) or '\\' in s:return False
 if re.search(r'(?i)\.(?:mdx|mdl|blp|tga|wav|mp3|ogg|txt|j|w3x|slk|lua|fdf|toc)(?:$|[|,])',s):return False
 if re.match(r'^(?:https?://|www\.)\S+$',s):return False
 return True

def jass_spans(s):
 masked=mask(s);defs=list(FUNC.finditer(masked));functions={};globals_string=set(re.findall(r'(?m)^(?:constant )?string\s+(?:array\s+)?(\w+)',masked[:masked.index('endglobals')]))
 # Own lexical scopes avoid translating animation/order literals held in an
 # unrelated function's identically named local string variable.
 for k,m in enumerate(defs):
  end=masked.index('endfunction',m.end());params=[]
  for part in m[2].split(','):
   v=part.strip().split();params.append(v[-1] if len(v)==2 and v[0]=='string' else None)
  locals_=set(re.findall(r'\blocal\s+string\s+(\w+)',masked[m.end():end]))|{v for v in params if v}
  functions[m[1]]=dict(start=m.start(),end=end,params=params,locals=locals_,returns=m[3])
 ordered=list(functions.items());fi=0
 def owner(pos):
  nonlocal fi
  while fi+1<len(ordered) and pos>ordered[fi][1]['end']:fi+=1
  return ordered[fi][0] if ordered and ordered[fi][1]['start']<=pos<ordered[fi][1]['end'] else ''
 def key(name,fn):return fn+'::'+name if fn and name in functions[fn]['locals'] else name
 assignments=defaultdict(list);calls=defaultdict(list);seeds=[];commands=set();protected_names=set()
 fi=0
 for m in re.finditer(r'(?m)^\s*(?:set\s+|(?:local\s+)?(?:constant\s+)?string\s+)(\w+)(?:\[[^\r\n]*?\])?\s*=([^\r\n]*)',masked):
  fn=owner(m.start());assignments[key(m[1],fn)].append((m.start(2),m.end(2),fn))
 fi=0
 for m in re.finditer(r'\b([A-Za-z_]\w*)\s*\(',masked):
  fn=owner(m.start());args=arguments(masked,m.end()-1);calls[m[1]].append((args,fn))
  for n in UI.get(m[1],[]):
   if n<len(args):seeds.append((*args[n],fn))
  if m[1]=='TriggerRegisterPlayerChatEvent' and len(args)>2:
   for v in STR.finditer(s,*args[2]):commands.add(decode_jass(v[0]))
  if m[1].startswith('Issue'):
   for a,b in args:
    for raw in re.findall(r"GetObjectName\s*\(\s*'(.{4})'\s*\)",s[a:b]):protected_names.add(raw)
 selected={};queue=deque(seeds);seen_expr=set();seen_vars=set()
 while queue:
  a,b,fn=queue.popleft()
  if (a,b,fn) in seen_expr:continue
  seen_expr.add((a,b,fn))
  for lit in STR.finditer(s,a,b):
   value=decode_jass(lit[0])
   if prose(value):selected[lit.start()]={'start':lit.start(),'end':lit.end(),'text':value,'kind':'jass','context':fn}
  for token in re.findall(r'\b[A-Za-z_]\w*\b',masked[a:b]):
   if token in functions and functions[token]['returns']=='string':
    f=functions[token]
    for ret in re.finditer(r'(?m)^\s*return ([^\r\n]+)',masked[f['start']:f['end']]):queue.append((f['start']+ret.start(1),f['start']+ret.end(1),token))
   if token not in globals_string and not (fn and token in functions[fn]['locals']):continue
   q=key(token,fn)
   if q in seen_vars:continue
   seen_vars.add(q);queue.extend(assignments.get(q,[]))
   if fn and token in functions[fn]['params']:
    for index,p in enumerate(functions[fn]['params']):
     if p==token:
      for caller_args,caller in calls.get(fn,[]):
       if index<len(caller_args):queue.append((*caller_args[index],caller))
 # All commands are literals consumed by the existing chat parser. Their
 # spellings remain usable, and are separately protected inside translated help.
 return sorted(selected.values(),key=lambda x:x['start']),sorted(commands),sorted(protected_names)

def decode_jass(s):
 s=s[1:-1]
 return re.sub(r'\\([\\"nrt])',lambda m:{'n':'\n','r':'\r','t':'\t','\\':'\\','"':'"'}[m[1]],s)
def encode_jass(s):return '"'+s.replace('\\','\\\\').replace('"','\\"').replace('\r','\\r').replace('\n','\\n').replace('\t','\\t')+'"'

class Reader:
 def __init__(self,data):self.data=data;self.p=0
 def read(self,n):
  if self.p+n>len(self.data):raise ValueError('Truncated object data')
  v=self.data[self.p:self.p+n];self.p+=n;return v
 def i(self):return struct.unpack('<i',self.read(4))[0]
 def string(self):
  start=self.p;end=self.data.index(0,start);self.p=end+1;return start,end,self.data[start:end].decode('utf8')

def object_spans(data,leveled):
 r=Reader(data);version=r.i();assert version in (1,2,3),version;result=[]
 for table in range(2):
  for _ in range(r.i()):
   old,new=r.read(4),r.read(4);raw=old if table==0 else new
   if version==3:r.read(4*r.i())
   for _ in range(r.i()):
    field=r.read(4).decode('ascii');typ=r.i()
    if leveled:r.read(8)
    if typ==3:
     a,b,text=r.string()
     if field in OBJDISPLAY and prose(text):result.append(dict(start=a,end=b,text=text,kind='binary',context=raw.decode()+':'+field))
    else:r.read(4)
    r.read(4)
 assert r.p==len(data),(r.p,len(data))
 return result

def txt_spans(s,skin=False,protected_names=()):
 result=[];section=''
 for m in re.finditer(r'(?m)^([^\r\n]*)',s):
  line=m[1]
  if line.startswith('['):section=line[1:line.find(']')];continue
  if '=' not in line or line.startswith('//'):continue
  k,v=line.split('=',1)
  if section in protected_names and k.lower()=='name':continue
  if skin:
   if section=='CustomSkin' or re.search(r'font|art|model|texture|cursor|sound|path|icon|^file$',k,re.I):continue
  elif k.lower() not in DISPLAY:continue
  # Preserve list cardinality: these TXT values are per-rank CSV strings.
  if any(prose(t) for t in next(csv.reader([v]),[])):
   a=m.start()+len(k)+1;result.append(dict(start=a,end=m.end(),text=v,kind='csv',context=section+':'+k))
 return result

def info_spans(data):
 r=Reader(data);assert r.i()==25;r.read(8);result=[]
 for index in range(4):
  a,b,t=r.string()
  if index!=1 and prose(t):result.append(dict(start=a,end=b,text=t,kind='binary',context='map-info:'+str(index)))
 return result

def catalog(st,path):
 h=st.open(path)
 try:
  names=(st.read(h,'(listfile)') or b'').decode('utf8').splitlines();files={};contexts=[]
  script=st.read(h,'war3map.j');script_text=script.decode('utf8');spans,commands,protected=jass_spans(script_text)
  files['war3map.j']=dict(encoding='utf8',spans=spans,sha256=hashlib.sha256(script).hexdigest())
  for name in names:
   lower=name.lower()
   if lower=='war3map.j':continue
   data=st.read(h,name)
   if lower.endswith('.txt') and (lower.startswith('units\\') or lower=='war3mapskin.txt'):
    text=data.decode('utf8');spans=txt_spans(text,skin=lower=='war3mapskin.txt',protected_names=protected)
    if spans:files[name]=dict(encoding='utf8',spans=spans,sha256=hashlib.sha256(data).hexdigest())
   elif lower in ['war3map.w3a','war3map.w3u','war3map.w3t','war3map.w3h','war3map.w3q']:
    spans=[span for span in object_spans(data,lower.endswith(('.w3a','.w3q'))) if not (span['context'].split(':')[0] in protected and span['context'].endswith(':anam'))]
    if spans:files[name]=dict(encoding='binary',spans=spans,sha256=hashlib.sha256(data).hexdigest())
   elif lower=='war3map.w3i':files[name]=dict(encoding='binary',spans=info_spans(data),sha256=hashlib.sha256(data).hexdigest())
  phrases={}
  for name,file in files.items():
   for span in file['spans']:
    texts=next(csv.reader([span['text']])) if span['kind']=='csv' else [span['text']]
    for text in texts:
     if prose(text):phrases.setdefault(text,[]).append([name,span['context']])
  return dict(files=files,phrases=phrases,commands=commands,protectedObjectNames=protected,sourceSha256=hashlib.sha256(path.read_bytes()).hexdigest())
 finally:st.close(h)

if __name__=='__main__':
 import sys
 from pathlib import Path
 from storm import Storm
 data=catalog(Storm(),Path(sys.argv[1]));Path(sys.argv[2]).write_text(json.dumps(data,ensure_ascii=False,indent=2))
 print('files',len(data['files']),'spans',sum(len(f['spans']) for f in data['files'].values()),'phrases',len(data['phrases']),'characters',sum(len(s) for s in data['phrases']))
 print('commands',len(data['commands']),'technical object names',data['protectedObjectNames'])

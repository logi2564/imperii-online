"""Translate extracted player-facing text; cache is checked and reviewable.

The input is public map text. Paths, order IDs, numbers, printf specifiers,
Warcraft color/data tags, hotkeys and existing chat commands are protected.
No source script is executed, and technical fields are not submitted.
"""
import concurrent.futures,hashlib,json,re,sys,time,threading,urllib.parse,urllib.request
from pathlib import Path
ROOT=Path(__file__).resolve().parents[1]
GLOSSARY=json.loads((ROOT/'source/glossary.json').read_text())
MANUAL=json.loads((ROOT/'source/manual.json').read_text()) if (ROOT/'source/manual.json').exists() else {}
TERMS=re.compile(r'(?<![A-Za-z])('+'|'.join(re.escape(s) for s in sorted(GLOSSARY,key=len,reverse=True))+r')(?![A-Za-z])',re.I)
LOWER={k.lower():v for k,v in GLOSSARY.items()}
TOKEN=re.compile(r'(?i)\|c[0-9a-f]{8}[A-Za-z]\|r(?=\W|$)|\|T[^|]*\|t|\|H[^|]*\|h|\|c[0-9a-f]{8}|\|[rRnN]|<[^<>\r\n]+>|%(?:\d+\$)?[+\-0 #]*(?:\d+|\*)?(?:\.(?:\d+|\*))?[diouxXeEfFgGcs%]|https?://[^\s|]+|\b(?:F\d{1,2}|ESC|TAB|ALT|SHIFT|CTRL|HK416|2B)\b|(?<!\w)-[A-Za-z][A-Za-z0-9_-]*|\([A-Za-z]\)|\[[A-Za-z]\]|[+\-]?(?:\d+(?:\.\d+)?|\.\d+)%?|[\r\n]+')
FOREIGN=re.compile(r'[A-Za-z]{2}|[\uac00-\ud7ff\u3040-\u30ff\u3400-\u9fff]')
TOKEN_ID=re.compile(r'ZXQ\s*(\d+)\s*QXZ')
_lock=threading.Lock()

def prepare(text,commands):
 # Keep commands intact in help, but translate the prose around them.
 protected=[]
 def save(v):
  n=len(protected);protected.append(v);return 'ZXQ'+str(n)+'QXZ'
 # A shortcut highlighted inside an English word moves to an explicit suffix;
 # the actual key stays Latin and the whole word becomes translatable.
 suffix=[]
 text=re.sub(r'(?i)(?<![A-Za-z])([A-Za-z]*)\|c([0-9a-f]{8})([A-Za-z])\|r([A-Za-z]+)',lambda m:(suffix.append('|c'+m[2]+m[3]+'|r') or m[1]+m[3]+m[4]),text)
 if suffix:text+=' ('+', '.join(suffix)+')'
 # Existing text input protocols may contain ordinary English sentences.
 for cmd in sorted(commands,key=len,reverse=True):
  if len(cmd)>=3:text=re.sub(r'(?<![A-Za-z0-9_])'+re.escape(cmd)+r'(?![A-Za-z0-9_])',lambda m:save(m[0]),text)
 # All remaining engine tokens are protected before terminology substitutions.
 text=re.sub(r'ZXQ\d+QXZ|'+TOKEN.pattern,lambda m:m[0] if m[0].startswith('ZXQ') else save(m[0]),text,flags=re.I)
 # Translate terminology only in segments outside the placeholders.
 pieces=TOKEN_ID.split(text)
 for i in range(0,len(pieces),2):pieces[i]=TERMS.sub(lambda m:LOWER[m[0].lower()],pieces[i])
 # split() includes ID digits; reconstruct the placeholder delimiters.
 text=''.join(v if i%2==0 else 'ZXQ'+v+'QXZ' for i,v in enumerate(pieces))
 return text,protected

def restore(text,protected):
 ids=[int(m[1]) for m in TOKEN_ID.finditer(text)]
 if ids!=list(range(len(protected))):raise ValueError('Translation changed engine token order: '+str(ids))
 result=TOKEN_ID.sub(lambda m:protected[int(m[1])],text)
 if re.search(r'ZXQ|QXZ',result):raise ValueError('Unrestored token')
 return result

def language(text):
 if re.search(r'[\uac00-\ud7ff]',text):return 'ko'
 if re.search(r'[\u3040-\u30ff]',text):return 'ja'
 if re.search(r'[\u3400-\u9fff]',text):return 'zh-CN'
 return 'en'

def request(text,lang='en'):
 if len(urllib.parse.quote(text))>11000 or len(text)>4700:
  chunks=[];remaining=text
  while remaining:
   end=min(len(remaining),2000)
   while len(urllib.parse.quote(remaining[:end]))>9000:end-=100
   space=remaining.rfind(' ',0,end)
   if space>end//2:end=space+1
   # Never split an opaque engine token.
   for marker in TOKEN_ID.finditer(remaining):
    if marker.start()<end<marker.end():end=marker.start();break
   if end<=0:raise ValueError('Oversized indivisible engine token')
   chunks.append(request(remaining[:end],lang));remaining=remaining[end:]
  return ''.join(chunks)
 url='https://translate.googleapis.com/translate_a/single?'+urllib.parse.urlencode(dict(client='gtx',sl=lang,tl='ru',dt='t',q=text))
 last=None
 for retry in range(7):
  try:
   req=urllib.request.Request(url,headers={'User-Agent':'Mozilla/5.0'})
   with urllib.request.urlopen(req,timeout=40) as r:data=json.load(r)
   return ''.join(segment[0] or '' for segment in data[0] if segment)
  except Exception as e:last=e;time.sleep(min(2**retry,20))
 raise RuntimeError('Translation endpoint failed: '+str(last))

def translate_batch(batch,commands,lang):
 prepared=[prepare(text,commands) for text in batch]
 joined='\n'.join('⟦'+str(i)+'⟧ '+text for i,(text,_) in enumerate(prepared))
 raw=request(joined,lang);markers=list(re.finditer(r'⟦\s*(\d+)\s*⟧\s*',raw));result={};retry=[]
 if [int(m[1]) for m in markers]==list(range(len(batch))):
  for i,m in enumerate(markers):
   translated=raw[m.end():markers[i+1].start() if i+1<len(markers) else len(raw)].strip()
   try:result[batch[i]]=restore(translated,prepared[i][1])
   except ValueError:retry.append(i)
 else:retry=list(range(len(batch)))
 for i in retry:
  text,tokens=prepared[i]
  try:result[batch[i]]=restore(request(text,lang),tokens)
  except ValueError:
   # Preserve exact token ordering by translating only intervening prose.
   chunks=[];pos=0
   for m in TOKEN_ID.finditer(text):
    phrase=text[pos:m.start()];chunks.append(request(phrase,lang) if FOREIGN.search(phrase) else phrase);chunks.append(tokens[int(m[1])]);pos=m.end()
   tail=text[pos:];chunks.append(request(tail,lang) if FOREIGN.search(tail) else tail);result[batch[i]]=''.join(chunks)
 time.sleep(.4)
 return {source:re.match(r'\s*',source)[0]+translated.strip()+re.search(r'\s*$',source)[0] for source,translated in result.items()}

def run(catalog_path,cache_path):
 catalog=json.loads(Path(catalog_path).read_text());cache_path=Path(cache_path);cache=json.loads(cache_path.read_text()) if cache_path.exists() else {}
 pending=[];commands=catalog['commands'];counter=0
 for text in catalog['phrases']:
  if text in MANUAL:cache[text]=MANUAL[text];continue
  if text in cache:continue
  prepared,tokens=prepare(text,commands)
  stripped=TOKEN_ID.sub('',prepared)
  if not FOREIGN.search(stripped):cache[text]=restore(prepared,tokens);continue
  pending.append(text)
 batches=[]
 for lang in ['en','ko','ja','zh-CN']:
  batch=[];size=0;chars=0
  for text in [text for text in pending if language(text)==lang]:
   prepared=prepare(text,commands)[0];n=len(urllib.parse.quote(prepared))+40
   if batch and (size+n>10000 or chars+len(prepared)>4200):batches.append((batch,lang));batch=[];size=0;chars=0
   batch.append(text);size+=n;chars+=len(prepared)+12
   if len(batch)>=30:batches.append((batch,lang));batch=[];size=0;chars=0
  if batch:batches.append((batch,lang))
 print('phrases',len(catalog['phrases']),'pending',len(pending),'batches',len(batches),flush=True)
 def save():
  cache_path.write_text(json.dumps(cache,ensure_ascii=False,indent=2))
  cache_path.with_name('Progress.json').write_text(json.dumps(dict(translated=len(cache),total=len(catalog['phrases']),remaining=len(catalog['phrases'])-len(cache)),indent=2))
 save()
 errors=[]
 with concurrent.futures.ThreadPoolExecutor(max_workers=3) as pool:
  tasks=[pool.submit(translate_batch,batch,commands,lang) for batch,lang in batches]
  for task in concurrent.futures.as_completed(tasks):
   try:cache.update(task.result())
   except Exception as e:errors.append(str(e));print('BATCH ERROR',str(e),flush=True)
   counter+=1
   if counter%5==0 or counter==len(tasks):save();print('completed batches',counter,'/',len(tasks),'phrases',len(cache),flush=True)
 save()
 if errors or any(s not in cache for s in catalog['phrases']):raise RuntimeError('Incomplete translation cache: '+repr(errors[:5]))
 print('COMPLETE',len(cache),flush=True)
if __name__=='__main__':run(*sys.argv[1:3])

"""Apply validated player-text replacements without rebuilding game objects."""
import csv,hashlib,io,json,os,re,shutil,struct,sys,tempfile,ctypes
from collections import Counter
from pathlib import Path
from catalog import catalog,encode_jass,decode_jass,STR,prose
from storm import Storm
ROOT=Path(__file__).resolve().parents[1]
TAG=re.compile(r'(?i)\|c[0-9a-f]{8}|\|[rn]|<[^<>\r\n]+>|%(?:\d+\$)?[+\-0 #]*(?:\d+|\*)?(?:\.(?:\d+|\*))?[diouxXeEfFgGcs%]')
NUMBER=re.compile(r'(?<![A-Za-z])[+\-]?(?:\d+(?:\.\d+)?|\.\d+)%?')

def structural(text):
 tags=TAG.findall(text)
 # Normalize a literal newline to the engine line-break marker equivalently.
 digits=NUMBER.findall(TAG.sub('',text))
 return (Counter(v.lower() for v in tags if v.lower()!='|n'),digits)

def split_literal(text):
 if len(encode_jass(text).encode())<=1025:return encode_jass(text)
 chunks=[];chunk=''
 for char in text:
  if len(encode_jass(chunk+char).encode())>1000:chunks.append(encode_jass(chunk));chunk=char
  else:chunk+=char
 if chunk:chunks.append(encode_jass(chunk))
 return '('+'+'.join(chunks)+')'

def csv_render(values):
 stream=io.StringIO(newline='');writer=csv.writer(stream,lineterminator='\n');writer.writerow(values)
 return stream.getvalue()[:-1]

def build(source_path,cache_path,output_dir):
 source_path=Path(source_path);output_dir=Path(output_dir);output_dir.mkdir(parents=True,exist_ok=True)
 source=source_path.read_bytes();reference=json.loads((ROOT/'source/Original.json').read_text());assert hashlib.sha256(source).hexdigest()==reference['sha256']
 st=Storm();data=catalog(st,source_path);cache=json.loads(Path(cache_path).read_text());manual=json.loads((ROOT/'source/manual.json').read_text()) if (ROOT/'source/manual.json').exists() else {};cache.update(manual)
 missing=[s for s in data['phrases'] if s not in cache];assert not missing,('Missing reviewed translation entries',missing[:10],len(missing))
 edits={};reports=[];replacements=0;translated_phrases=set();h=st.open(source_path);manifest={}
 try:
  names=(st.read(h,'(listfile)') or b'').decode('utf8').splitlines()
  for name in names:
   if not name.startswith('('):manifest[name]=hashlib.sha256(st.read(h,name)).hexdigest()
  for name,meta in data['files'].items():
   original=st.read(h,name);assert hashlib.sha256(original).hexdigest()==meta['sha256']
   raw=original if meta['encoding']=='binary' else original.decode(meta['encoding']);changes=[]
   for span in meta['spans']:
    before=span['text']
    def translate(text):
     if not prose(text):return text
     result=cache[text]
     assert '\0' not in result
     if structural(text)!=structural(result):raise ValueError('Engine markup or tooltip numbers changed: '+repr(text)+' => '+repr(result))
     translated_phrases.add(text)
     return result
    if span['kind']=='csv':
     values=next(csv.reader([before]));after=csv_render([translate(v) for v in values]);assert len(next(csv.reader([after])))==len(values)
    elif span['kind']=='jass':after=split_literal(translate(before))
    elif span['kind']=='slk':after=translate(before).replace('"','""').encode('utf8')
    else:after=translate(before).encode('utf8')
    if raw[span['start']:span['end']]!=after:changes.append((span['start'],span['end'],after,span['context']))
   for a,b,v,_ in sorted(changes,reverse=True):raw=raw[:a]+v+raw[b:]
   blob=raw if isinstance(raw,bytes) else raw.encode(meta['encoding'])
   edits[name]=blob;replacements+=len(changes);reports.append(dict(file=name,changedSpans=len(changes),sourceSha256=meta['sha256'],outputSha256=hashlib.sha256(blob).hexdigest()))
 finally:st.close(h)
 target=output_dir/'Gutsy-Geoid-Game-RU-v1.0.5.w3x';shutil.copyfile(source_path,target)
 with tempfile.TemporaryDirectory(prefix='gutsy-ru-') as folder:st.replace(target,edits,folder)
 # Compact dead original text blocks while preserving every retained file.
 lib=st.lib;lib.SFileCompactArchive.argtypes=[ctypes.c_void_p,ctypes.c_char_p,ctypes.c_bool];arc=st.open(target,False)
 try:
  if not lib.SFileCompactArchive(arc,None,False):raise OSError('Cannot compact localized archive')
 finally:st.close(arc)
 # Keep the lobby's external map header consistent with the localized W3I.
 old_header=source[:512];end=old_header.index(0,8);old_name=old_header[8:end].decode('utf8');localized_name=cache.get(old_name,old_name)
 info=next(f for f in reports if f['file'].lower()=='war3map.w3i')
 map_name=next(sp['text'] for sp in data['files'][info['file']]['spans'] if sp['context']=='map-info:0');localized_name=cache.get(map_name,map_name)
 header=old_header[:8]+localized_name.encode()+b'\0'+old_header[end+1:end+9];assert len(header)<512
 blob=bytearray(target.read_bytes());blob[:512]=header+bytes(512-len(header));target.write_bytes(blob)
 # Verify all 3581 retained files from the exact final archive, not a staging directory.
 verify=st.open(target)
 try:
  for name,checksum in manifest.items():
   actual=st.read(verify,name)
   assert actual is not None,name
   assert actual==edits[name] if name in edits else hashlib.sha256(actual).hexdigest()==checksum,name
  for name,expected in edits.items():assert st.read(verify,name)==expected,name
 finally:st.close(verify)
 report=dict(source=reference,translationMethod='Machine translation with reviewed Russian names/terminology and manually corrected interface text',sourceVersion='1.0.5',targetLanguage='ru',uniquePlayerTexts=len(data['phrases']),translatedTextOccurrences=replacements,translatedFiles=reports,retainedFilesVerified=len(manifest),chatCommandsPreserved=len(data['commands']),orderNamesPreserved=data['protectedObjectNames'],gameplayCodeChanged=False,voiceTracks='original',nativeWarcraftTested=False,bytes=target.stat().st_size,sha256=hashlib.sha256(target.read_bytes()).hexdigest())
 (output_dir/'Localization-report.json').write_text(json.dumps(report,ensure_ascii=False,indent=2))
 (output_dir/'Source-file-hashes.json').write_text(json.dumps(manifest,ensure_ascii=False,indent=2));(output_dir/'Translations.json').write_text(json.dumps(cache,ensure_ascii=False,indent=2));(output_dir/'catalog.json').write_text(json.dumps(data,ensure_ascii=False))
 print('BUILT',target,report['bytes'],'bytes;',replacements,'text replacements')
 return report
if __name__=='__main__':build(*sys.argv[1:4])

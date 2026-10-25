"""Translate public game text, retaining formatting tokens and a resumable cache."""
from pathlib import Path
import argparse,json,re,urllib.request,urllib.parse,time,hashlib

def protect(text):
    tokens=[]
    def save(m):tokens.append(m[0]);return '__PH'+str(len(tokens)-1)+'__'
    return re.sub(r'\\[nrt]|%[0-9.$+-]*[sdfiu]|\{[0-9]+[^}]*\}|<[^>]+>|#[0-9a-fA-F]{6,8}\b',save,text),tokens

def restore(text,tokens):
    for i,original in enumerate(tokens):
        marker='__PH'+str(i)+'__'
        if marker not in text:raise ValueError('translation formatting token missing')
        text=text.replace(marker,original)
    return text.replace('\n','\\n').strip()

def main(a):
    entries=json.loads(a.input.read_text());translated=json.loads(a.output.read_text()) if a.output.exists() else {}
    values=list(dict.fromkeys(entries.values()))
    pending=[v for v in values if v not in translated]
    for language in ['en','zh-CN']:
        group=[v for v in pending if bool(re.search('[\u3400-\u9fff]',v))==(language=='zh-CN')]
        batches=[];batch=[];size=0
        for value in group:
            if batch and size+len(value)>2800:batches.append(batch);batch=[];size=0
            batch.append(value);size+=len(value)+25
        if batch:batches.append(batch)
        for number,batch in enumerate(batches):
            protected=[protect(v) for v in batch]
            text='\n'.join('§§'+str(i)+'§§\n'+v[0] for i,v in enumerate(protected))
            query=urllib.parse.urlencode({'client':'gtx','sl':language,'tl':'ru','dt':'t','q':text})
            for attempt in range(5):
                try:
                    req=urllib.request.Request('https://translate.googleapis.com/translate_a/single?'+query,headers={'User-Agent':'EW4 localization build/0.3'})
                    data=json.load(urllib.request.urlopen(req,timeout=60));result=''.join(piece[0] for piece in data[0] if piece[0])
                    chunks=re.split(r'§\s*§\s*([0-9]+)\s*§\s*§',result)
                    parts={int(chunks[i]):chunks[i+1].strip() for i in range(1,len(chunks),2)}
                    if len(parts)!=len(batch):raise ValueError('translation markers missing')
                    for i,value in enumerate(batch):translated[value]=restore(parts[i],protected[i][1])
                    a.output.write_text(json.dumps(translated,ensure_ascii=False,indent=2)+'\n');break
                except Exception as error:
                    print('Translation retry',language,number,type(error).__name__,flush=True)
                    if attempt==4:raise
                    time.sleep(min(30,2**attempt))
            print('Translated',len(translated),'of',len(values),'public text entries',flush=True);time.sleep(1)
    missing=[k for k,v in entries.items() if v not in translated]
    report={'entries':len(entries),'unique_values':len(values),'translated':len(translated),'missing':len(missing),'method':'machine_translation_with_reviewed_interface_overrides'}
    a.output.with_name('translation-coverage.json').write_text(json.dumps(report,indent=2)+'\n')
    if missing:raise SystemExit('Missing translations')
if __name__=='__main__':
    p=argparse.ArgumentParser();p.add_argument('--input',type=Path,required=True);p.add_argument('--output',type=Path,required=True);main(p.parse_args())

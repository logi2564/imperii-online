"""Apply reviewed Russian terminology, without altering commands or markup."""
import json,re,sys
from pathlib import Path
from build import structural
from translate_cache import prepare,restore

ROOT=Path(__file__).resolve().parents[1]

def finalize(catalog_path,cache_path,output_path):
    catalog=json.loads(Path(catalog_path).read_text())
    cache=json.loads(Path(cache_path).read_text())
    manual=json.loads((ROOT/'source/manual.json').read_text())
    terms=json.loads((ROOT/'source/terminology-ru.json').read_text())
    lower={k.lower():v for k,v in terms.items()}
    pattern=re.compile(r'(?<![A-Za-z])(?=[A-Za-z])(?:'+'|'.join(re.escape(k) for k in sorted(terms,key=len,reverse=True))+r')(?![A-Za-z])',re.I)
    technical=re.compile(r'(?i)\|c[0-9a-f]{8}|\|[rn]|<[^<>\r\n]+>|(?:https?://|www\.|discord\.gg/|cafe\.naver\.com/)[^\s|]+')
    result={}
    for text in catalog['phrases']:
        translated=manual.get(text,cache.get(text))
        if translated is None:raise ValueError('Missing text: '+repr(text))
        if text in manual:
            if structural(text)!=structural(translated):
                raise ValueError('Invalid reviewed translation: '+repr(text))
            result[text]=translated
            continue
        # Old cache entries could retain an English word whose final letter
        # was a colored shortcut: Monsoo<n>, He<x>, Sou<l>. Rebuild short
        # labels from the whole word only when every word is now understood.
        has_embedded_key=any(m[1] or m[4] for m in re.finditer(r'(?i)(?<![A-Za-z])([A-Za-z]*)\|c([0-9a-f]{8})([A-Za-z])\|r([A-Za-z]*)',text))
        if len(text)<160 and has_embedded_key:
            prepared,tokens=prepare(text,catalog['commands'])
            candidate=restore(prepared,tokens)
            protected_candidate=[]
            def save_candidate(m):
                protected_candidate.append(m[0]);return '\ue000'+str(len(protected_candidate)-1)+'\ue001'
            candidate=technical.sub(save_candidate,candidate)
            candidate=pattern.sub(lambda m:lower[m[0].lower()],candidate)
            remaining=re.findall(r'[A-Za-z]{2,}',candidate)
            if not remaining:
                translated=re.sub(r'\ue000(\d+)\ue001',lambda m:protected_candidate[int(m[1])],candidate)
        # Preserve literal input commands in instructions. Ordinary displayed
        # labels such as "hero" or "Normal" are not protocols by themselves.
        protected=[]
        def keep(m):
            protected.append(m[0]);return '\ue000'+str(len(protected)-1)+'\ue001'
        translated=technical.sub(keep,translated)
        for command in sorted(catalog['commands'],key=len,reverse=True):
            if len(command)<2:continue
            quoted=re.search(r"['\"]"+re.escape(command)+r"['\"]",text)
            typed=re.search(r'(?i)(?<![-A-Za-z])(?:type|enter|write|input)\s*'+re.escape(command)+r'(?!\w)',text)
            if command.startswith('-') or quoted or typed:
                translated=re.sub(r'(?<![A-Za-z0-9_])'+re.escape(command)+r'(?![A-Za-z0-9_])',keep,translated)
        translated=pattern.sub(lambda m:lower[m[0].lower()],translated)
        translated=re.sub(r'\ue000(\d+)\ue001',lambda m:protected[int(m[1])],translated)
        translated=re.sub(r'\bF\s+(\d{1,2})\b',r'F\1',translated)
        if re.search(r'(?<!\|)c(?:000080ff|00ffff00)',text,re.I):
            translated=re.sub(r'(?i)(?<!\|)\bc\s*000080\s*ff|(?<!\|)\bc\s*00\s*ffff\s*00',' ',translated)
        translated=translated.replace('Сторонник','Поддержка').replace('Танкер','Танк')
        translated=translated.replace('Физический урон навыков','Физический урон навыка').replace('Диапазон:','Дальность:')
        translated=re.match(r'\s*',text)[0]+translated.strip()+re.search(r'\s*$',text)[0]
        if structural(text)!=structural(translated):
            raise ValueError('Markup/numbers changed: '+repr(text)+' => '+repr(translated))
        result[text]=translated
    Path(output_path).write_text(json.dumps(result,ensure_ascii=False,indent=2)+'\n')
    print('Finalized',len(result),'Russian player texts')

if __name__=='__main__':finalize(*sys.argv[1:4])

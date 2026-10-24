"""Read public developer/store pages to verify legitimate cross-platform RTS downloads."""
import concurrent.futures
import html
from html.parser import HTMLParser
import json
from pathlib import Path
import urllib.error
import urllib.request

SOURCES = {
 'siegeup': 'https://siegeup.com/',
 'siegeup-play': 'https://play.google.com/store/apps/details?id=com.abuksigun.rpg_prototype&hl=en&gl=US',
 'siegeup-itch-author': 'https://abuksigun.itch.io/siege-up',
 'siegeup-itch': 'https://siegeup.itch.io/siege-up',
 'siegeup-steam-search': 'https://store.steampowered.com/search/?term=Siege%20Up',
 'rusted-warfare': 'https://corrodinggames.com/rusted_warfare',
 'rusted-warfare-steam': 'https://store.steampowered.com/app/647960/Rusted_Warfare__RTS/',
 'mindustry': 'https://anuke.itch.io/mindustry',
}
class Page(HTMLParser):
    def __init__(self):
        super().__init__();self.skip=0;self.parts=[];self.links=[]
    def handle_starttag(self,tag,attrs):
        if tag in ('script','style'):self.skip+=1
        if tag=='a':
            for key,value in attrs:
                if key=='href' and value and not value.startswith(('#','javascript:','mailto:')):self.links.append(value)
    def handle_endtag(self,tag):
        if tag in ('script','style') and self.skip:self.skip-=1
    def handle_data(self,data):
        if not self.skip and data.strip():self.parts.append(data.strip())

out=Path('dist/rts-source-check');out.mkdir(parents=True,exist_ok=True)
def read(entry):
    key,url=entry
    try:
        request=urllib.request.Request(url,headers={'User-Agent':'Mozilla/5.0 (compatible; CrossplayResearch/1.0)'})
        with urllib.request.urlopen(request,timeout=40) as r:
            raw=r.read(3_000_000).decode('utf-8',errors='replace');resolved=r.url;status=r.status
        parser=Page();parser.feed(raw)
        result={'source_url':url,'resolved_url':resolved,'http_status':status,
                'text':'\n'.join(parser.parts)[:65000],'links':list(dict.fromkeys(parser.links))[:180]}
        (out/(key+'.json')).write_text(json.dumps(result,ensure_ascii=False,indent=2),encoding='utf-8')
        return {'source':key,'status':status,'url':resolved}
    except Exception as error:
        result={'source':key,'source_url':url,'error':str(error)}
        (out/(key+'.json')).write_text(json.dumps(result,indent=2));return result
with concurrent.futures.ThreadPoolExecutor(max_workers=4) as executor:
    results=list(executor.map(read,SOURCES.items()))
(out/'status.json').write_text(json.dumps(results,indent=2),encoding='utf-8')
print(json.dumps(results,indent=2))

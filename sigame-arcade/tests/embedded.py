import os,zipfile,json,tempfile,threading,http.server,functools
from pathlib import Path
from playwright.sync_api import sync_playwright
ROOT=Path(__file__).resolve().parents[2];OUT=ROOT/'sigame-arcade';checked=[]
with tempfile.TemporaryDirectory() as folder,zipfile.ZipFile(ROOT/'dist/arcade/Bro-Arcade-61.siq') as z,sync_playwright() as p:
 class QuietHandler(http.server.SimpleHTTPRequestHandler):
  def log_message(self,*args):pass
 server=http.server.ThreadingHTTPServer(('127.0.0.1',0),functools.partial(QuietHandler,directory=folder));threading.Thread(target=server.serve_forever,daemon=True).start();used_http=not bool(os.environ.get('ARCADE_TEST_FILE_URLS'))
 browser=p.chromium.launch(executable_path=os.environ.get('BROWSER_EXECUTABLE'),args=['--no-sandbox'])
 for viewport in [{'width':800,'height':500},{'width':360,'height':800}]:
  ctx=browser.new_context(viewport=viewport,has_touch=viewport['width']==360,is_mobile=viewport['width']==360);page=ctx.new_page();errors=[];external=[];page.on('pageerror',lambda e:errors.append(str(e)));page.on('request',lambda r:external.append(r.url) if r.url.startswith(('http:','https:')) and not r.is_navigation_request() else None)
  for i in range(1,62):
   file=Path(folder)/f'g{i:02d}.html';file.write_bytes(z.read(f'Html/g{i:02d}.html'))
   if used_http:page.goto(f'http://127.0.0.1:{server.server_port}/g{i:02d}.html')
   else:
    try:page.goto(file.as_uri())
    except Exception as error:
     if 'ERR_BLOCKED_BY_ADMINISTRATOR' not in str(error):raise
     used_http=True;page.close();page=ctx.new_page();page.on('pageerror',lambda e:errors.append(str(e)));page.on('request',lambda r:external.append(r.url) if r.url.startswith(('http:','https:')) and not r.is_navigation_request() else None);page.goto(f'http://127.0.0.1:{server.server_port}/g{i:02d}.html')
   assert page.locator('.answer-box').count()==0
   assert page.locator('#begin-game').is_visible();page.locator('#begin-game').click();assert page.evaluate('Arcade.mode')=='playing'
   assert page.evaluate('document.documentElement.scrollWidth<=innerWidth')
   if viewport['width']==800:
    box=page.locator('#game-canvas').bounding_box();assert box['y']+box['height']<=500,(i,box)
    if page.locator('.control').count():
     b=page.locator('.control').last.bounding_box();assert b['y']+b['height']<=505,(i,b)
   checked.append({'game':i,'viewport':viewport})
  assert not errors,errors;assert not external,external;ctx.close()
 browser.close();server.shutdown()
(OUT/'embedded-report.json').write_text(json.dumps({'embeddedFilesChecked':len(checked),'externalRequests':0,'javascriptErrors':0,'desktopCanvasAndControlsFit':True,'mobileWidthFits':True,'fileProtocolTested':not used_http,'localHttpFallbackForManagedBrowser':used_http},indent=2)+'\n')
print('PASS: all 61 SIQ HTML files run without external resources on desktop and phone; 0 external requests, controls fit 800x500 client area')

"""Run SIQ games through the unmodified SI Online HTML renderer, with a test server store."""
import functools, hashlib, http.server, json, os, subprocess, tempfile, threading, zipfile
from pathlib import Path
from urllib.parse import urlencode
from playwright.sync_api import sync_playwright
ROOT=Path(__file__).resolve().parents[2];OUT=ROOT/'sigame-arcade'
games=json.loads((OUT/'catalog.json').read_text());checks=[];errors=[];requests=[]
upstream=json.loads((OUT/'tests/sionline/UPSTREAM.json').read_text())
assert hashlib.sha256((OUT/'tests/sionline/HtmlContent.tsx').read_bytes()).hexdigest()==upstream['sha256']
class Quiet(http.server.SimpleHTTPRequestHandler):
 def log_message(self,*args):pass

def serve(folder):
 server=http.server.ThreadingHTTPServer(('127.0.0.1',0),functools.partial(Quiet,directory=str(folder)))
 threading.Thread(target=server.serve_forever,daemon=True).start();return server

with tempfile.TemporaryDirectory() as folder,zipfile.ZipFile(ROOT/'dist/blitz/Bro-Arcade-Blitz-61.siq')as pack,sync_playwright()as p:
 folder=Path(folder);media=folder/'media';host=folder/'host';media.mkdir();host.mkdir()
 for g in games:(media/(g['id']+'.html')).write_bytes(pack.read('Html/'+g['id']+'.html'))
 subprocess.run(['node',str(OUT/'tests/sionline/build.cjs'),str(host)],check=True)
 media_server=serve(media);host_server=serve(host)
 allowed={f'http://127.0.0.1:{media_server.server_port}',f'http://127.0.0.1:{host_server.server_port}'}
 def url(g):return f'http://127.0.0.1:{host_server.server_port}/?'+urlencode({'src':f'http://127.0.0.1:{media_server.server_port}/{g}.html'})
 browser=p.chromium.launch(executable_path=os.environ.get('BROWSER_EXECUTABLE'),args=['--no-sandbox'])
 for viewport in [{'width':1024,'height':768},{'width':360,'height':640},{'width':360,'height':390},{'width':640,'height':360}]:
  mobile=viewport['width']==360
  context=browser.new_context(viewport=viewport,is_mobile=mobile,has_touch=mobile)
  context.add_init_script('window.__ARCADE_TEST_DRIVER__=true')
  page=context.new_page();page.on('pageerror',lambda e:errors.append(str(e)))
  page.on('request',lambda r:requests.append(r.url)if not any(r.url.startswith(o+'/')for o in allowed)else None)
  for g in games:
   page.goto(url(g['id']));page.wait_for_selector('iframe')
   frame=page.frames[1];frame.wait_for_function('typeof Arcade!=="undefined"&&Arcade.mode==="preparing"')
   assert frame.locator('#begin-game').count()==0,'No personal start button inside SI Online'
   assert frame.locator('a[href],img').count()==0,'No outgoing sites or QR codes'
   assert frame.evaluate('Arcade.definitions.size')==1,'A phone should load just this game'
   assert frame.evaluate('Arcade.remaining')==g['seconds']
   frame.evaluate('Arcade.testStep(5)');assert frame.evaluate('Arcade.mode')=='playing'
   assert frame.evaluate('document.documentElement.scrollWidth<=innerWidth&&document.documentElement.scrollHeight<=innerHeight'),g['id']+' scroll'
   assert frame.locator('.answer-box').count()==0
   box=frame.locator('canvas').bounding_box();area=page.locator('iframe').bounding_box()
   assert abs(box['width']-box['height'])<1,(g['id'],'stretched',box)
   assert box['y']>=area['y'] and box['y']+box['height']<=area['y']+area['height'],(g['id'],box,area)
   for control in frame.locator('.control').all():
    r=control.bounding_box();assert r['width']>=43 and r['height']>=39
    assert r['y']+r['height']<=area['y']+area['height'],(g['id'],'clipped controls',r,area)
   # Actual finger/mouse events at the center of the game. No in-frame popups are allowed.
   if mobile:page.touchscreen.tap(box['x']+box['width']*.5,box['y']+box['height']*.5)
   else:page.mouse.click(box['x']+box['width']*.5,box['y']+box['height']*.5)
   frame.evaluate('Arcade.testStep(.1)')
   if g['id'] in ['g12','g36','g42','g61'] and viewport['height']==640:
    page.screenshot(path=str(OUT/('client-'+g['id']+'-phone.png')))
   checks.append({'id':g['id'],'viewport':viewport,'frameWidth':round(area['width']),'frameHeight':round(area['height']),'autoStart':True,'squareCanvas':True,'noScroll':True})
   assert not errors,(g['id'],errors)
  # The client, not a personal clock button, controls pause and answer phases.
  page.goto(url('g12'));frame=page.frames[1];frame.wait_for_function('typeof Arcade!=="undefined"&&Arcade.mode==="preparing"')
  frame.evaluate('Arcade.testStep(2)');before=frame.evaluate('[Arcade.prepLeft,Arcade.remaining]')
  page.locator('#pause').click();frame.wait_for_function('Arcade.paused');frame.evaluate('Arcade.testStep(10)')
  assert frame.evaluate('[Arcade.prepLeft,Arcade.remaining]')==before
  page.locator('#resume').click();frame.wait_for_function('!Arcade.paused');frame.evaluate('Arcade.testStep(4)')
  assert frame.evaluate('Arcade.mode')=='playing'
  assert abs(frame.evaluate('Arcade.remaining')-19)<.01
  # A long frame must consume real elapsed time, rather than gifting slow phones extra seconds.
  frame.evaluate('Arcade.testStep(2)');assert abs(frame.evaluate('Arcade.remaining')-17)<.01
  page.locator('#answer').click();frame.wait_for_function('Arcade.paused');frame.evaluate('Arcade.testStep(5)')
  assert abs(frame.evaluate('Arcade.remaining')-17)<.01
  page.locator('#answer-end').click();frame.wait_for_function('!Arcade.paused')
  frame.evaluate('Arcade.testStep(18)');assert frame.evaluate('Arcade.mode')=='timeout';assert frame.locator('.answer-box').count()==0
  # Loss and retry do not buy extra seconds or reveal a reward.
  page.goto(url('g36'));frame=page.frames[1];frame.wait_for_function('typeof Arcade!=="undefined"&&Arcade.mode==="preparing"');frame.evaluate('Arcade.testStep(5)')
  box=frame.locator('canvas').bounding_box();x=80+(7%4+.5)*80;y=82+(7//4+.5)*80
  page.mouse.click(box['x']+x*box['width']/480,box['y']+y*box['height']/480)
  assert frame.evaluate('Arcade.mode')=='lost';assert frame.locator('.answer-box').count()==0
  frame.evaluate('Arcade.testStep(1.5)');left=frame.evaluate('Arcade.remaining')
  frame.locator('#retry').click();assert frame.evaluate('Arcade.mode')=='playing'
  assert frame.evaluate('Arcade.remaining')==left
  assert left<35
  frame.evaluate('Arcade.testStep(36)');assert frame.evaluate('Arcade.mode')=='timeout'
  context.close()
 # Two players are separate iframe instances; one player's victory must not end the question for the other.
 context=browser.new_context(viewport={'width':360,'height':640},is_mobile=True,has_touch=True)
 context.add_init_script('window.__ARCADE_TEST_DRIVER__=true')
 players=[context.new_page(),context.new_page()]
 for page in players:
  page.goto(url('g12'));frame=page.frames[1];frame.wait_for_function('typeof Arcade!=="undefined"&&Arcade.mode==="preparing"');frame.evaluate('Arcade.testStep(5)')
 for i in [0,2,4,7]:
  page=players[0];frame=page.frames[1];box=frame.locator('canvas').bounding_box();x=75+(i%3+.5)*110;y=95+(i//3+.5)*110
  page.touchscreen.tap(box['x']+x*box['width']/480,box['y']+y*box['height']/480)
  frame.evaluate('Arcade.testStep(.2)')
 assert players[0].frames[1].evaluate('Arcade.mode')=='won'
 assert players[0].frames[1].locator('.answer-box').inner_text()==next(g['answer']for g in games if g['id']=='g12')
 assert players[1].frames[1].evaluate('Arcade.mode')=='playing'
 assert players[1].frames[1].locator('.answer-box').count()==0
 for page in players:assert not any(e['type']in ['completed','answer-right','answer-wrong']for e in page.evaluate('fixtureEvents'))
 players[0].screenshot(path=str(OUT/'client-victory-phone.png'))
 context.close();browser.close();host_server.shutdown();media_server.shutdown()
assert not errors,errors;assert not requests,requests
report={'renderer':'Unmodified SI Online HtmlContent.tsx','upstreamCommit':upstream['commit'],'scope':'Real React HTML renderer and sandbox, mocked server/Redux state; no full remote SI session or physical phone','cases':len(checks),'games':61,'clientPauseAndResume':True,'answerPhasePausesGameplay':True,'automaticFiveSecondPreparation':True,'slowFrameConsumesRealTime':True,'privateVictoryAcrossTwoPlayers':True,'winnerDoesNotEndOtherPlayersMedia':True,'externalRequests':requests,'javascriptErrors':errors,'details':checks}
(OUT/'embedded-report.json').write_text(json.dumps(report,ensure_ascii=False,indent=2)+'\n')
print('PASS: 61 embedded games × 4 client viewports, actual SI Online renderer, pause/resume, fair clock, separate player answers, 0 external requests')

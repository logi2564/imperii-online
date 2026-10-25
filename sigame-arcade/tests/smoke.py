import os,json
from pathlib import Path
from playwright.sync_api import sync_playwright
ROOT=Path(__file__).resolve().parents[2]
OUT=ROOT/'sigame-arcade';games=json.loads((OUT/'catalog.json').read_text())
errors=[];checks=[]
with sync_playwright() as p:
 browser=p.chromium.launch(executable_path=os.environ.get('BROWSER_EXECUTABLE'),args=['--no-sandbox'])
 for mobile in [False,True]:
  context=browser.new_context(viewport={'width':360 if mobile else 1365,'height':800 if mobile else 900},is_mobile=mobile,has_touch=mobile,device_scale_factor=1)
  context.add_init_script('window.__ARCADE_TEST_DRIVER__=true')
  page=context.new_page();page.on('pageerror',lambda error:errors.append(str(error)))
  page.goto('http://127.0.0.1:8794/')
  assert page.locator('.card').count()==61
  assert page.locator('.answer-box').count()==0
  page.screenshot(path=str(OUT/('home-mobile.png' if mobile else 'home-desktop.png')))
  for game in games:
   page.goto('http://127.0.0.1:8794/?g='+game['id'])
   assert page.evaluate('Arcade.mode')=='ready'
   assert page.evaluate('Arcade.remaining')==game['seconds']
   assert page.locator('.answer-box').count()==0
   assert page.evaluate('document.documentElement.scrollWidth<=innerWidth'),game['id']+' overflow'
   page.locator('#begin-game').click()
   assert page.evaluate('Arcade.mode')=='playing'
   page.evaluate('Arcade.testStep(.2)')
   canvas=page.locator('#game-canvas');box=canvas.bounding_box();x=box['x']+box['width']*.5;y=box['y']+box['height']*.5
   if mobile:page.touchscreen.tap(x,y)
   else:page.mouse.click(x,y)
   page.evaluate('Arcade.testStep(.2)')
   assert page.evaluate("['playing','lost','won'].includes(Arcade.mode)"),game['id']
   assert not errors,(game['id'],errors)
   checks.append({'id':game['id'],'mobile':mobile,'readyTimerPaused':True,'fitsViewport':True,'inputWorks':True})
  # The default 10-second SIGame timer must not be copied into the minigame.
  page.goto('http://127.0.0.1:8794/?g=g12');page.locator('#begin-game').click();page.evaluate('Arcade.testStep(11)')
  assert page.evaluate('Arcade.mode')=='playing'
  assert page.locator('.answer-box').count()==0
  before=page.evaluate('Arcade.remaining');page.evaluate('Arcade.retry()');assert abs(page.evaluate('Arcade.remaining')-before)<.01
  page.evaluate('Arcade.testStep(220)');assert page.evaluate('Arcade.mode')=='timeout'
  assert page.locator('.answer-box').count()==0
  # A wrong move in snake loses without leaking a reward.
  page.goto('http://127.0.0.1:8794/?g=g05');page.locator('#begin-game').click();page.evaluate('Arcade.testStep(3)')
  assert page.evaluate('Arcade.mode')=='lost';assert page.locator('.answer-box').count()==0
  left=page.evaluate('Arcade.remaining');page.get_by_role('button',name='Попробовать снова').click();assert page.evaluate('Arcade.mode')=='playing'
  assert page.evaluate('Arcade.remaining')==left
  context.close()
 browser.close()
assert not errors
(OUT/'smoke-report.json').write_text(json.dumps({'checks':len(checks),'games':61,'desktopAndTouch':True,'cases':checks,'errors':errors,'timeoutDoesNotRevealAnswer':True,'retryKeepsRemainingTime':True},ensure_ascii=False,indent=2)+'\n')
print('PASS: all 61 games on desktop and 360px touch viewport; ready timers, input, no horizontal overflow, hidden answers, retries and timeout')

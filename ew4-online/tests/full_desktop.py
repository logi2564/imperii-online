"""Test the packaged full game, safe rendering, actual offline play and menu after restart."""
from pathlib import Path
import argparse,json,os,sys,socket,subprocess,time,urllib.request
from playwright.sync_api import sync_playwright
from integration import wait_for

def port():
 with socket.socket() as s:s.bind(('127.0.0.1',0));return s.getsockname()[1]
def visible_chinese(page):
 page.wait_for_timeout(150)
 return page.evaluate("()=>Array.from(document.querySelectorAll('[aria-label],[title]')).filter(e=>e.getClientRects().length&&!e.closest('[hidden]')).map(e=>e.getAttribute('aria-label')||e.getAttribute('title')).filter(t=>/[\\u3400-\\u9fff]/.test(t))")
def settle(page):
 page.wait_for_function('()=>!busy&&!sessionTransition',timeout=60000)
 if page.locator('#detail-modal').is_visible():page.locator('#close-detail').click()
 page.wait_for_timeout(250)
 for _ in range(15):
  if not page.locator('#dialogue').is_visible():break
  page.locator('#dialogue-ok').click();page.wait_for_timeout(150)
 page.wait_for_function('()=>!busy&&!aiRunning&&!sessionTransition&&!stageIntroOpen',timeout=60000)

def main(a):
 out=a.output.resolve();out.mkdir(parents=True,exist_ok=True);profile=out/'profile';report={'result':'FAIL'};stage='startup';process=None;log=(out/'private.log').open('w')
 with sync_playwright() as pw:
  def launch():
   nonlocal process
   debug=port();started=time.monotonic();flags=['--no-sandbox']if sys.platform=='linux'else[]
   process=subprocess.Popen([str(a.electron.resolve()),*flags,str(a.app.resolve()),'--app-root',str(a.root.resolve()),'--profile',str(profile),'--test-mode','--remote-debugging-port='+str(debug)],stdout=log,stderr=subprocess.STDOUT)
   wait_for(lambda:urllib.request.urlopen(f'http://127.0.0.1:{debug}/json/version',timeout=1).status==200)
   browser=pw.chromium.connect_over_cdp(f'http://127.0.0.1:{debug}');ctx=browser.contexts[0];page=ctx.pages[0]if ctx.pages else ctx.wait_for_event('page')
   page.wait_for_url('**/single?**',timeout=60000)
   page.wait_for_function("()=>document.querySelector('[data-mode=\"1\"]')&&!document.querySelector('[data-mode=\"1\"]').disabled",timeout=45000)
   return page,round(time.monotonic()-started,3)
  def quit(page):
   page.evaluate('Ew4Desktop.quit()')
   try:process.wait(15)
   except subprocess.TimeoutExpired:process.terminate();process.wait(15)
  try:
   page,startup=launch();assert startup<30
   assert page.locator('#main-menu').is_visible()and not page.locator('#play').is_visible()
   assert page.evaluate('document.documentElement.lang')=='ru'
   nav=page.locator('#main-menu nav button').evaluate_all('(es)=>es.map(e=>({bottom:e.getBoundingClientRect().bottom,right:e.getBoundingClientRect().right}))')
   assert all(b['bottom']<=page.viewport_size['height']if page.viewport_size else True for b in nav)
   page.screenshot(path=str(out/'full-main.png'))
   stage='settings_and_headquarters';page.locator('#main-settings').click();assert not visible_chinese(page);page.locator('#close-settings').click()
   page.locator('#headquarters').click();page.locator('#hq-screen').wait_for(state='visible',timeout=30000);assert not visible_chinese(page);page.screenshot(path=str(out/'full-headquarters.png'));page.locator('#hq-recruit').click();page.locator('.commander-info').first.click();page.locator('#detail-modal').wait_for(state='visible');assert not visible_chinese(page)
   if page.locator('.skill-info').count():page.locator('.skill-info').first.click();assert not visible_chinese(page)
   page.locator('#close-detail').click();page.locator('#hq-back').click()
   page.evaluate('()=>showMain()');page.locator('[data-mode="2"]').click();assert not visible_chinese(page)
   assert page.locator('.conquest-caption img').count()==0
   page.locator('#menu-back').click();page.locator('[data-mode="4"]').click();assert not visible_chinese(page)
   page.evaluate('()=>showMain()')
   stage='campaign';page.locator('[data-mode="1"]').click();chapters=page.locator('.chapter-entry').count();assert chapters>=6
   page.locator('.chapter-entry').first.click();page.locator('.chapter-preview-confirm').click();page.locator('#campaign-battles .country-entry').first.wait_for(state='visible',timeout=30000)
   missions=page.locator('#campaign-battles .country-entry').count();assert missions>=18;assert not visible_chinese(page)
   page.screenshot(path=str(out/'full-campaigns.png'));page.locator('#campaign-confirm').click();page.locator('#play').wait_for(state='visible',timeout=60000)
   settle(page);assert page.evaluate('ctx.gpu')is False
   stage='move_and_save'
   move=page.evaluate("async()=>{for(const u of state.units){if(u.owner!==state.playerFaction||!u.canMove)continue;const selection=await rpc('action',{op:'select',cell:u.cell,revision:state.revision});if(selection.range.length)return {id:u.id,from:u.cell,to:selection.range[0]};}return null;}")
   assert move
   page.evaluate('cell=>selectCell(cell)',move['from']);page.evaluate('cell=>selectCell(cell)',move['to'])
   assert page.evaluate('id=>state.units.find(u=>u.id===id).cell',move['id'])==move['to']
   page.locator('#menu-button').click();page.locator('#save').click();page.locator('.save-slot-confirm').nth(1).click()
   page.locator('#detail-modal').wait_for(state='hidden');page.locator('#resume').click()
   assert not visible_chinese(page);page.screenshot(path=str(out/'full-campaign-battle.png'))
   assert page.evaluate('()=>Ew4Ru.missing')==[], 'An exercised game text is missing its Russian translation'
   stage='performance'
   durations=page.evaluate("async()=>{const original=render,samples=[];render=function(t){const before=performance.now();original(t);samples.push(performance.now()-before);};for(let i=0;i<35;i++){view.x+=i%2?3:-3;requestRender();await new Promise(r=>setTimeout(r,45));}render=original;return samples;}")
   durations.sort();p95=durations[min(len(durations)-1,int(len(durations)*.95))]if durations else None
   assert durations and p95<250
   quit(page);stage='restart_saved_game';page,restart=launch()
   assert page.locator('#main-menu').is_visible()and not page.locator('#play').is_visible()
   page.locator('[data-mode="1"]').click();page.locator('#continue').click();page.locator('.save-slot-confirm').nth(1).click();page.locator('#play').wait_for(state='visible',timeout=60000);settle(page)
   assert page.evaluate('id=>state.units.find(u=>u.id===id).cell',move['id'])==move['to']
   report.update(result='PASS',cold_menu_seconds=startup,restart_menu_seconds=restart,starts_in_main_menu=True,saved_game_requires_explicit_load=True,offline_campaign=True,campaign_chapters=chapters,first_chapter_missions=missions,own_unit_moved=True,manual_save_and_restart_restore=True,headquarters=True,russian_text=True,visible_chinese_labels=[],renderer='canvas2d',hardware_acceleration=False,render_p95_ms=round(p95,2),physical_user_pc_tested=False)
   quit(page)
  except Exception as e:
   import traceback
   traceback.print_exc(file=log)
   try:page.screenshot(path=str(out/'private-failure-game.png'))
   except Exception:pass
   report.update(stage=stage,exception_type=type(e).__name__);print('Full game verification:',stage,type(e).__name__,flush=True)
  finally:
   if process and process.poll()is None:
    process.terminate()
    try:process.wait(15)
    except subprocess.TimeoutExpired:process.kill();process.wait()
   log.close();(out/'full-desktop.json').write_text(json.dumps(report,indent=2)+'\n')
 print(json.dumps(report,indent=2),flush=True)
 if report['result']!='PASS':raise SystemExit(1)
if __name__=='__main__':
 p=argparse.ArgumentParser()
 for name in ['electron','app','root','output']:p.add_argument('--'+name,type=Path,required=True)
 main(p.parse_args())

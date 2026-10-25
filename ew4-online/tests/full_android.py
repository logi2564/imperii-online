"""Verify the actual Android game offline, including campaigns, movement, save and menu restart."""
from pathlib import Path
import argparse,json,socket,subprocess,time,urllib.request,re
from integration import wait_for
from webview_cdp import WebView,ScriptError

def adb(*args):return subprocess.check_output(['adb',*map(str,args)],stderr=subprocess.STDOUT,text=True)
def freeport():
 with socket.socket()as s:s.bind(('127.0.0.1',0));return s.getsockname()[1]
def chinese(p):return p.evaluate("Array.from(document.querySelectorAll('[aria-label],[title]')).filter(e=>e.getClientRects().length&&!e.closest('[hidden]')).map(e=>e.getAttribute('aria-label')||e.getAttribute('title')).filter(t=>/[\\u3400-\\u9fff]/.test(t))")
def main(a):
 out=a.output.resolve();out.mkdir(parents=True,exist_ok=True);report={'result':'FAIL'};stage='install';phone=None;log=(out/'private.log').open('w');package='org.logi2564.ew4fullgame';activity=package+'/.GameActivity'
 def launch():
  started=time.monotonic();adb('shell','am','start','-W','-S','-n',activity)
  def pid():
   p=subprocess.run(['adb','shell','pidof',package],capture_output=True,text=True);return p.stdout.strip()if p.returncode==0 else None
  current=wait_for(pid);port=freeport();adb('forward',f'tcp:{port}',f'localabstract:webview_devtools_remote_{current}')
  targets=wait_for(lambda:json.load(urllib.request.urlopen(f'http://127.0.0.1:{port}/json',timeout=3)),60)
  from urllib.parse import urlsplit
  ws=urlsplit(targets[0]['webSocketDebuggerUrl']);p=WebView(f'ws://127.0.0.1:{port}'+ws.path,log)
  p.wait("document.querySelector('[data-mode=\"1\"]')&&!document.querySelector('[data-mode=\"1\"]').disabled",90)
  return p,round(time.monotonic()-started,3)
 def shot(name):
  foreground=adb('shell','dumpsys','activity','activities');assert any(package+'/.GameActivity'in l and'mResumedActivity'in l for l in foreground.splitlines())
  (out/name).write_bytes(subprocess.check_output(['adb','exec-out','screencap','-p']))
 try:
  adb('install','-r',a.apk.resolve());adb('logcat','-c');adb('shell','svc','wifi','disable');adb('shell','svc','data','disable')
  stage='offline_startup';phone,cold=launch();assert phone.evaluate("location.hostname==='ew4.local'&&document.documentElement.lang==='ru'")
  assert phone.evaluate("!document.querySelector('#main-menu').hidden&&document.querySelector('#play').hidden")
  assert cold<45;assert not chinese(phone);shot('android-full-main.png')
  stage='offline_campaign'
  phone.click('[data-mode="1"]');phone.wait("!!document.querySelector('.chapter-entry')");chapters=phone.evaluate("document.querySelectorAll('.chapter-entry').length");assert chapters>=6
  phone.click('.chapter-entry');phone.click('.chapter-preview-confirm');phone.wait("!!document.querySelector('#campaign-battles .country-entry')")
  missions=phone.evaluate("document.querySelectorAll('#campaign-battles .country-entry').length");assert missions>=18;assert not chinese(phone);shot('android-full-campaigns.png')
  phone.click('#campaign-confirm');phone.wait("!document.querySelector('#play').hidden",90)
  phone.wait('!busy&&!sessionTransition',60)
  if phone.evaluate("!document.querySelector('#detail-modal').hidden"):phone.click('#close-detail')
  time.sleep(.25)
  for _ in range(15):
   if phone.evaluate("document.querySelector('#dialogue').hidden"):break
   phone.click('#dialogue-ok');time.sleep(.15)
  phone.wait('!busy&&!aiRunning&&!sessionTransition&&!stageIntroOpen',60)
  assert phone.evaluate('ctx.gpu===false')
  stage='offline_movement'
  move=phone.evaluate("(async()=>{for(const u of state.units){if(u.owner!==state.playerFaction||!u.canMove)continue;const s=await rpc('action',{op:'select',cell:u.cell,revision:state.revision});if(s.range.length)return{id:u.id,from:u.cell,to:s.range[0]};}return null;})()")
  assert move;phone.evaluate('selectCell('+str(move['from'])+')');phone.evaluate('selectCell('+str(move['to'])+')')
  assert phone.evaluate('state.units.find(u=>u.id==='+json.dumps(move['id'])+').cell')==move['to']
  stage='offline_save';phone.click('#menu-button');phone.click('#save');phone.wait("document.querySelectorAll('.save-slot-confirm').length>1");phone.evaluate("document.querySelectorAll('.save-slot-confirm')[1].click()")
  phone.wait("document.querySelector('#detail-modal').hidden");phone.click('#resume');assert not chinese(phone);shot('android-offline-battle.png')
  phone.close();phone=None;stage='offline_restart';phone,restart=launch()
  assert phone.evaluate("!document.querySelector('#main-menu').hidden&&document.querySelector('#play').hidden")
  phone.click('[data-mode="1"]');phone.click('#continue');phone.wait("document.querySelectorAll('.save-slot-confirm').length>1");phone.evaluate("document.querySelectorAll('.save-slot-confirm')[1].click()")
  phone.wait("!document.querySelector('#play').hidden",90)
  if phone.evaluate("!document.querySelector('#detail-modal').hidden"):phone.click('#close-detail')
  phone.wait('!busy&&!sessionTransition',60)
  assert phone.evaluate('state.units.find(u=>u.id==='+json.dumps(move['id'])+').cell')==move['to']
  report.update(result='PASS',installed_game_engine=True,assets_bundled=True,wifi_and_mobile_data_disabled=True,offline_campaign=True,offline_own_unit_moved=True,offline_save_and_restart=True,starts_in_main_menu=True,explicit_saved_game_load=True,campaign_chapters=chapters,first_chapter_missions=missions,cold_menu_seconds=cold,restart_menu_seconds=restart,renderer='canvas2d',russian_text=True,visible_chinese_labels=[],physical_android_device_tested=False)
 except Exception as e:
  report.update(stage=stage,exception_type=type(e).__name__)
  if isinstance(e,ScriptError):report.update(javascript_exception_class=e.kind,javascript_error_hint=e.hint)
  try:
   crash=adb('logcat','-d','-b','crash','-s','AndroidRuntime:E');report['android_exception_classes']=sorted(set(re.findall(r'\b(?:java|android|org)\.[A-Za-z0-9_.$]+(?:Exception|Error)\b',crash)))[:12]
  except Exception:pass
 finally:
  if phone:phone.close()
  adb('shell','svc','wifi','enable');adb('shell','svc','data','enable');log.close();(out/'full-android.json').write_text(json.dumps(report,indent=2)+'\n')
 print(json.dumps(report,indent=2),flush=True)
 if report['result']!='PASS':raise SystemExit(1)
if __name__=='__main__':
 p=argparse.ArgumentParser();p.add_argument('--apk',type=Path,required=True);p.add_argument('--output',type=Path,required=True);main(p.parse_args())

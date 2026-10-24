"""Launch the real desktop application and verify its own game window."""
from pathlib import Path
import argparse,json,os,time,urllib.request,sys,socket,subprocess
from playwright.sync_api import sync_playwright

def main(a):
    out=a.output.resolve();out.mkdir(parents=True,exist_ok=True)
    profile=out/'profile'
    errors=[]
    with sync_playwright() as p:
        env=dict(os.environ);env['XDG_CACHE_HOME']=str(out/'cache')
        with socket.socket() as sock:sock.bind(('127.0.0.1',0));port=sock.getsockname()[1]
        log=(out/'electron.log').open('w')
        flags=['--no-sandbox'] if sys.platform=='linux' else []
        process=subprocess.Popen([str(a.electron.resolve())]+flags+[str(a.app.resolve()),'--app-root',str(a.root.resolve()),'--profile',str(profile),'--test-mode','--remote-debugging-port='+str(port)],env=env,stdout=log,stderr=subprocess.STDOUT)
        until=time.monotonic()+60
        while True:
            if process.poll() is not None:raise RuntimeError('Desktop exited before debugger became ready; inspect local electron.log')
            try:
                urllib.request.urlopen(f'http://127.0.0.1:{port}/json/version',timeout=1).close();break
            except OSError:
                if time.monotonic()>until:raise
                time.sleep(.2)
        browser=p.chromium.connect_over_cdp(f'http://127.0.0.1:{port}')
        try:
            context=browser.contexts[0]
            page=context.pages[0] if context.pages else context.wait_for_event('page',timeout=60000)
            page.on('pageerror',lambda e:errors.append(str(e)))
            page.locator('#solo').wait_for(state='visible',timeout=60000)
            page.wait_for_function('!!window.Ew4Desktop',timeout=20000)
            assert page.url.split('#')[0].endswith('/native'),page.url
            assert len(context.pages)==1
            page.wait_for_function("!document.querySelector('#solo').disabled")
            page.screenshot(path=str(out/'native-main.png'))
            page.locator('#solo').click();page.locator('#country option[value="fra"]').wait_for(state='attached',timeout=20000)
            page.locator('#country').select_option('fra');page.locator('#create').click()
            frame=page.frame_locator('#game');frame.locator('#play').wait_for(state='visible',timeout=60000)
            page.wait_for_timeout(1500)
            child=next(f for f in page.frames if '/game?' in f.url)
            assert child.evaluate('document.fonts.check(\'24px "EW4 Russian"\')')
            untranslated=child.evaluate('''()=>Array.from(document.querySelectorAll('[aria-label],[title]')).filter(e=>e.getClientRects().length&&!e.closest('[hidden]')).map(e=>e.getAttribute('aria-label')||e.getAttribute('title')).filter(t=>/[\u3400-\u9fff]/.test(t))''')
            assert not untranslated,untranslated[:25]
            unit=child.evaluate("async()=>{const j=await(await fetch('/api/action',{method:'POST',headers:{'Content-Type':'application/json'},body:JSON.stringify({op:'state'})})).json();return j.data.units.find(u=>u.owner===j.data.playerFaction);}")
            child.evaluate('cell=>selectCell(cell)',unit['cell']);page.wait_for_timeout(500)
            untranslated=child.evaluate('''()=>Array.from(document.querySelectorAll('[aria-label],[title]')).filter(e=>e.getClientRects().length&&!e.closest('[hidden]')).map(e=>e.getAttribute('aria-label')||e.getAttribute('title')).filter(t=>/[\u3400-\u9fff]/.test(t))''')
            assert not untranslated,untranslated[:25]
            assert not errors,errors
            page.screenshot(path=str(out/'native-battle.png'))
            assert child.evaluate('Ew4OnlineGame.revision()')>=0
            page.locator('#end').click();page.wait_for_timeout(600)
            report={'result':'PASS','real_desktop_window':True,'external_browser':False,'window_count':1,'single_player_map_started':True,'cyrillic_font_loaded':True,'visible_chinese_labels':untranslated,'javascript_errors':errors}
            (out/'native-window.json').write_text(json.dumps(report,indent=2)+'\n')
            print(json.dumps(report,indent=2),flush=True)
        finally:
            try:page.evaluate('window.Ew4Desktop.quit()')
            except Exception:pass
            try:process.wait(10)
            except subprocess.TimeoutExpired:process.terminate();process.wait(10)
            log.close()

if __name__=='__main__':
    p=argparse.ArgumentParser();p.add_argument('--electron',type=Path,required=True);p.add_argument('--app',type=Path,required=True);p.add_argument('--root',type=Path,required=True);p.add_argument('--output',type=Path,required=True);main(p.parse_args())

"""Real Electron host plus an installed Android Activity/WebView over public HTTPS.
Only controlled reports and battlefield screenshots are publishable; profiles/logs are private.
"""
from pathlib import Path
import argparse,base64,json,os,socket,subprocess,time,urllib.request,sys,re
from playwright.sync_api import sync_playwright
from integration import Client,wait_for,move
from webview_cdp import WebView,ScriptError

def free_port():
    with socket.socket() as s:s.bind(('127.0.0.1',0));return s.getsockname()[1]
def adb(*args):
    return subprocess.check_output(['adb',*map(str,args)],stderr=subprocess.STDOUT,text=True)
def run(a):
    out=a.output.resolve();out.mkdir(parents=True,exist_ok=True);stage='desktop_start';process=None;phone=None;blocked_network=False;report={'result':'FAIL','physical_android_device_tested':False}
    log=(out/'private-electron.log').open('w')
    try:
        with sync_playwright() as pw:
            port=free_port();profile=out/'profile'
            flags=['--no-sandbox'] if sys.platform=='linux' else []
            process=subprocess.Popen([str(a.electron.resolve()),*flags,str(a.app.resolve()),'--app-root',str(a.root.resolve()),'--profile',str(profile),'--test-mode','--remote-debugging-port='+str(port)],stdout=log,stderr=subprocess.STDOUT)
            wait_for(lambda:urllib.request.urlopen(f'http://127.0.0.1:{port}/json/version',timeout=2).status==200)
            desktop=pw.chromium.connect_over_cdp(f'http://127.0.0.1:{port}')
            context=desktop.contexts[0];host=context.pages[0] if context.pages else context.wait_for_event('page')
            if a.full:
                host.wait_for_function("()=>document.querySelector('#full-multiplayer-button')&&!document.querySelector('#full-multiplayer-button').disabled",timeout=60000)
                host.locator('#full-multiplayer-button').click();host.locator('#full-create').click()
            host.wait_for_function("()=>!!document.querySelector('#multiplayer')&&!document.querySelector('#multiplayer').disabled",timeout=60000)
            stage='create_room'
            if not a.full:host.locator('#multiplayer').click()
            host.locator('#country option[value="fra"]').wait_for(state='attached')
            host.locator('#country').select_option('fra');host.locator('#create').click()
            host.wait_for_function("()=>document.querySelector('#code').value.startsWith('EW4-')",timeout=90000)
            code=host.locator('#code').input_value();invite=json.loads(base64.urlsafe_b64decode(code[4:]+'='*((-len(code[4:]))%4)))
            ready=json.loads((profile/'native-ready.json').read_text());cfg=json.loads((profile/'state/saves/online-room.json').read_text())
            api=Client(ready['origin'],cfg['hostToken'])
            guest_seat=next(c['id'] for c in api.call('/online/status')['choices'] if c['country']=='gbr')
            def public_ready():
                try:return json.load(urllib.request.urlopen(invite['u'].rstrip('/')+'/health',timeout=5))['ok']
                except (OSError,ValueError):return False
            wait_for(public_ready,90)
            stage='android_install'
            package='org.logi2564.ew4fullgame.r31' if a.full else 'org.logi2564.ew4online';activity=package+'/.GameActivity'
            adb('logcat','-c')
            if a.full:adb('root');adb('wait-for-device')
            stage='android_install_apk';adb('install','-r',a.apk.resolve())
            stage='android_start_activity';adb('shell','am','start','-W','-S','-n',activity,'--es','invite',code)
            stage='android_process'
            def android_pid():
                found=subprocess.run(['adb','shell','pidof',package],capture_output=True,text=True)
                return found.stdout.strip() if found.returncode==0 else None
            pid=wait_for(android_pid)
            stage='android_debugger';cdp=free_port();adb('forward',f'tcp:{cdp}',f'localabstract:webview_devtools_remote_{pid}')
            targets=wait_for(lambda:json.load(urllib.request.urlopen(f'http://127.0.0.1:{cdp}/json',timeout=3)),60)
            from urllib.parse import urlsplit
            debugger=urlsplit(targets[0]['webSocketDebuggerUrl'])
            phone=WebView(f'ws://127.0.0.1:{cdp}'+debugger.path,log)
            if a.full:
                phone.wait("document.querySelector('#full-multiplayer-button')&&!document.querySelector('#full-multiplayer-button').disabled",90)
                phone.click('#full-multiplayer-button');phone.select('#friend-code',code);phone.click('#full-connect')
            stage='android_choose_country'
            phone.wait('!!document.querySelector('+json.dumps('#faction option[value="'+guest_seat+'"]')+')')
            phone.select('#faction',guest_seat);phone.click('#choose')
            host.wait_for_function("()=>!document.querySelector('#start').disabled",timeout=30000)
            host.locator('#start').click()
            stage='battlefields'
            host.frame_locator('#game').locator('#play').wait_for(state='visible',timeout=90000)
            game="document.querySelector('#game').contentWindow"
            phone.wait(game+".document.querySelector('#play')&&!"+game+".document.querySelector('#play').hidden")
            # API assertions inspect authoritative state; turn input comes from the in-app UI.
            guest_api=Client(invite['u'].rstrip('/'),cfg['guestToken'])
            state=api.state();hfaction=state['playerFaction'];gfaction=guest_api.state()['playerFaction']
            assert hfaction!=gfaction and state['online']['canAct'] and not guest_api.state()['online']['canAct']
            hf=next(f for f in host.frames if '/game' in f.url)
            hf.wait_for_function('()=>!Ew4OnlineGame.busy()&&Ew4OnlineCanEnd')
            assert phone.evaluate(game+'.document.querySelector("#end-turn").disabled')
            assert phone.evaluate('document.querySelector("#end").disabled')
            guest_api.call('/api/action',{'op':'end','revision':state['revision']},expected=400)
            uid,target,moved=move(api)
            wait_for(lambda:phone.evaluate(game+'.Ew4OnlineGame.revision()')>=moved['revision'])
            assert next(u['cell'] for u in guest_api.state()['units'] if u['id']==uid)==target
            stage='turn_to_android'
            host.locator('#end').click();wait_for(lambda:guest_api.call('/online/status')['canAct'],60)
            phone.wait("!document.querySelector('#end').disabled",60)
            # Select/move use the same controller as actual map taps, not a separate test game.
            phone.wait(game+'.Ew4OnlineCanAct&&!'+game+'.Ew4OnlineGame.busy()',60)
            stage='reject_host_skipping_guest'
            host.wait_for_function('()=>document.querySelector("#end").disabled')
            hf.wait_for_function('()=>document.querySelector("#end-turn").disabled')
            guest_revision=guest_api.state()['revision']
            for _ in range(3):api.call('/api/action',{'op':'end','revision':guest_revision},expected=400)
            assert guest_api.state()['revision']==guest_revision
            stage='android_controller_move'
            state=guest_api.state();revision=state['revision']
            phone.wait(game+'.Ew4OnlineGame.revision()>='+str(revision)+'&&!'+game+'.Ew4OnlineGame.busy()',60)
            for unit in state['units']:
                if unit['owner']!=gfaction or not unit['canMove']:continue
                selection=guest_api.call('/api/action',{'op':'select','revision':revision,'cell':unit['cell']})['data']
                if selection['range']:
                    target2=selection['range'][0];uid2=unit['id'];break
            else:raise AssertionError('No guest move')
            phone.evaluate(game+'.selectCell('+str(unit['cell'])+')')
            phone.evaluate(game+'.selectCell('+str(target2)+')')
            wait_for(lambda:next(u['cell'] for u in api.state()['units'] if u['id']==uid2)==target2)
            stage='phone_network_offline'
            # Disconnect real HTTPS sockets in this disposable, rootable emulator.
            # WebView's CDP emulation is not a reliable Android network switch.
            adb('shell','iptables','-I','OUTPUT','-p','tcp','--dport','443','-j','REJECT')
            blocked_network=True
            adb('shell','ip6tables','-I','OUTPUT','-p','tcp','--dport','443','-j','REJECT')
            stage='phone_wait_disconnected'
            phone.wait('!document.querySelector("#connection").hidden',45)
            assert phone.evaluate('document.querySelector("#end").disabled')
            stage='phone_network_online'
            adb('shell','iptables','-D','OUTPUT','-p','tcp','--dport','443','-j','REJECT')
            adb('shell','ip6tables','-D','OUTPUT','-p','tcp','--dport','443','-j','REJECT')
            blocked_network=False
            stage='phone_wait_reconnected'
            phone.wait('document.querySelector("#connection").hidden&&!document.querySelector("#end").disabled',45)
            assert guest_api.state()['playerFaction']==gfaction
            assert next(u['cell'] for u in guest_api.state()['units'] if u['id']==uid2)==target2
            stage='phone_local_media'
            stats=json.loads(phone.evaluate('Ew4App.stats()'))if a.full else {}
            if a.full:assert stats['bundledMedia']>30 and stats['remoteMediaFallback']==0,stats
            stage='android_end_turn'
            phone.click('#end');wait_for(lambda:api.call('/online/status')['canAct'],180)
            assert api.state()['round']>=2
            stage='foreground_activity'
            resumed=adb('shell','dumpsys','activity','activities');assert any(package+'/.GameActivity' in line and 'mResumedActivity' in line for line in resumed.splitlines())
            stage='translated_labels'
            labels=phone.evaluate("Array.from("+game+".document.querySelectorAll('[aria-label],[title]')).filter(e=>e.getClientRects().length&&!e.closest('[hidden]')).map(e=>e.getAttribute('aria-label')||e.getAttribute('title')).filter(t=>/[\\u3400-\\u9fff]/.test(t))")
            assert not labels
            report.update(real_electron_host=True,installed_android_activity=True,android_emulator=True,external_browser=False,public_https=True,two_independent_countries=True,host_move_synced=True,android_controller_move_synced=True,android_end_turn=True,server_ai_round_two=True,visible_chinese_labels=labels,wrong_turn_buttons_disabled=True,repeated_host_end_cannot_skip_guest=True,phone_reconnect_without_reload=True,bundled_media=stats)
            stage='capture_battle'
            host.screenshot(path=str(out/'desktop-multiplayer.png'))
            # The dedicated emulator has only this foreground full-screen game Activity.
            # Android WebView does not implement desktop CDP Page.captureScreenshot.
            (out/'android-battle.png').write_bytes(subprocess.check_output(['adb','exec-out','screencap','-p']))
            stage='PASS';report['result']='PASS'
    except Exception as error:
        report.update(stage=stage,exception_type=type(error).__name__)
        if phone:
            try:report['phone_connection_state']=phone.evaluate('({connectionBanner:!document.querySelector("#connection")?.hidden,endDisabled:!!document.querySelector("#end")?.disabled,role:typeof status!=="undefined"?status?.role:null,canEnd:typeof status!=="undefined"?!!status?.canEnd:false})')
            except Exception:pass
        if isinstance(error,ScriptError):report.update(javascript_exception_class=error.kind,javascript_error_hint=error.hint)
        for command in ['Browser.setDownloadBehavior','Browser.getVersion','Target.setAutoAttach','Target.getTargetInfo','Page.enable','Page.getFrameTree','Page.addScriptToEvaluateOnNewDocument','Emulation.setFocusEmulationEnabled']:
            if command in str(error):report['debugger_command']=command
        if isinstance(error,subprocess.CalledProcessError):
            match=re.search(r'\bINSTALL_[A-Z_]+\b',str(error.output))
            if match:report['android_install_error']=match[0]
        # Publish only exception CLASS names from the disposable test app's crash buffer.
        try:
            crash=adb('logcat','-d','-b','crash','-s','AndroidRuntime:E')
            report['android_exception_classes']=sorted(set(re.findall(r'\b(?:java|android|org)\.[A-Za-z0-9_.$]+(?:Exception|Error)\b',crash)))[:12]
        except Exception:pass
        print('Crossplay failed at',stage,type(error).__name__,flush=True)
    finally:
        if blocked_network:
            for firewall in ['iptables','ip6tables']:
                subprocess.run(['adb','shell',firewall,'-D','OUTPUT','-p','tcp','--dport','443','-j','REJECT'],stdout=subprocess.DEVNULL,stderr=subprocess.DEVNULL)
        if phone:phone.close()
        if process:
            process.terminate()
            try:process.wait(15)
            except subprocess.TimeoutExpired:process.kill();process.wait()
        log.close();(out/'android-crossplay.json').write_text(json.dumps(report,indent=2)+'\n')
    print(json.dumps(report,indent=2),flush=True)
    if report['result']!='PASS':raise SystemExit(1)

if __name__=='__main__':
    p=argparse.ArgumentParser()
    for name in ['electron','app','root','apk','output']:p.add_argument('--'+name,type=Path,required=True)
    p.add_argument('--full',action='store_true')
    run(p.parse_args())

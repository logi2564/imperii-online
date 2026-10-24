"""Black-box crossplay tests against the real EW4 engine, never a mock server."""
from pathlib import Path
import argparse, http.cookiejar, json, os, shutil, socket, subprocess, time
import urllib.request, urllib.error

class Client:
    def __init__(self, base, token=None):
        self.base=base
        self.opener=urllib.request.build_opener(urllib.request.HTTPCookieProcessor(http.cookiejar.CookieJar()))
        if token:self.call('/online/login',{'token':token})
    def call(self,path,data=None,expected=200,origin=None):
        headers={'Content-Type':'application/json'}
        if origin:headers['Origin']=origin
        req=urllib.request.Request(self.base+path,data=None if data is None else json.dumps(data).encode(),headers=headers)
        try:
            with self.opener.open(req,timeout=90) as r:status=r.status;result=json.load(r)
        except urllib.error.HTTPError as e:status=e.code;result=json.load(e)
        assert status==expected,(path,status,result)
        return result
    def state(self):return self.call('/api/action',{'op':'state'})['data']

def wait_for(fn,seconds=60):
    until=time.monotonic()+seconds
    while time.monotonic()<until:
        try:
            value=fn()
            if value:return value
        except (OSError,urllib.error.URLError):pass
        time.sleep(.3)
    raise AssertionError('Timed out waiting for server/turn')

def move(client):
    state=client.state()
    for unit in state['units']:
        if unit['owner']!=state['playerFaction'] or not unit['canMove']:continue
        selection=client.call('/api/action',{'op':'select','revision':state['revision'],'cell':unit['cell']})['data']
        if selection['range']:
            target=selection['range'][0]
            moved=client.call('/api/action',{'op':'move','revision':state['revision'],'unit':unit['id'],'cell':target})['data']
            assert next(u['cell'] for u in moved['units'] if u['id']==unit['id'])==target
            return unit['id'],target,moved
    raise AssertionError('No legal move in real scenario')

def main(args):
    out=args.output.resolve();out.mkdir(parents=True,exist_ok=True)
    saves=out/'saves'
    assert not saves.exists(),'Tests require a fresh save folder'
    with socket.socket() as sock:sock.bind(('127.0.0.1',0));port=sock.getsockname()[1]
    base=f'http://127.0.0.1:{port}'
    root=args.upstream.resolve();web=root/'rewrite/Ew4.Web'
    logs=(out/'server.log').open('w')
    command=[args.dotnet,str(web/'bin/Release/net10.0/Ew4.Web.dll'),'--root',str(root),'--contentRoot',str(web),'--urls',base,'--save-root',str(saves)]
    process=None
    checks=[]
    def passed(message):checks.append(message);print('PASS:',message,flush=True)
    def start():
        nonlocal process
        process=subprocess.Popen(command,cwd=web,stdout=logs,stderr=subprocess.STDOUT)
        wait_for(lambda:Client(base).call('/health')['ok'],30)
    def stop():
        nonlocal process
        if process:
            process.terminate()
            try:process.wait(15)
            except subprocess.TimeoutExpired:process.kill();process.wait()
            process=None
    try:
        start()
        cfg=json.loads((saves/'online-room.json').read_text())
        anon=Client(base);host=Client(base,cfg['hostToken']);guest=Client(base,cfg['guestToken'])
        anon.call('/api/action',{'op':'state'},expected=401)
        anon.call('/online/login',{'token':'wrong'},expected=401)
        host.call('/online/prepare',{},expected=403,origin='https://attacker.invalid')
        host.call('/api/mod-import',{},expected=400)
        passed('Private invitations, same-origin enforcement and blocked original admin routes')
        scenarios=host.call('/online/catalog',{})['scenarios']
        scenario=next(s for s in scenarios if s['id']=='conquest1')
        assert scenario['mode']==2
        countries=host.call('/online/countries',{'scenario':scenario['id']})
        room=host.call('/online/prepare',{'scenario':scenario['id'],'country':countries[0]['id']})
        hf=room['hostFaction'];gf=next(c['id'] for c in room['choices'] if c['id']!=hf)
        guest.call('/online/choose',{'faction':hf},expected=400)
        guest.call('/online/choose',{'faction':gf})
        guest.call('/online/start',{},expected=400)
        host.call('/online/start',{})
        hs=host.state();gs=guest.state()
        assert hs['playerFaction']==hf and gs['playerFaction']==gf
        assert sum(f['human'] for f in hs['factions'])==2 and len(hs['units'])>100
        assert hs['online']['canAct'] and not gs['online']['canAct']
        passed('Real European 1798 scenario with two independently owned human countries')
        revision=hs['revision']
        guest.call('/api/action',{'op':'end','revision':revision},expected=400)
        host.call('/api/action',{'op':'end','revision':revision-1},expected=400)
        enemy=next(u for u in hs['units'] if u['owner']==gf)
        host.call('/api/action',{'op':'move','unit':enemy['id'],'cell':enemy['cell']+1,'revision':revision},expected=400)
        assert host.state()['revision']==revision
        passed('Wrong-turn, stale-revision and foreign-unit commands cannot change the game')
        uid,target,moved=move(host)
        for _ in range(3):
            view=guest.state();assert next(u['cell'] for u in view['units'] if u['id']==uid)==target
            assert view['playerFaction']==gf and host.state()['playerFaction']==hf
            assert view.get('baseRevision') is None and len(view['cells'])>1000
        passed('Actual movement synchronizes while each connection retains its own perspective')
        host.call('/api/action',{'op':'end','revision':moved['revision']})
        wait_for(lambda:guest.call('/online/status')['canAct'],30)
        host.call('/api/action',{'op':'end','revision':guest.state()['revision']},expected=400)
        uid2,target2,guest_move=move(guest)
        assert next(u['cell'] for u in host.state()['units'] if u['id']==uid2)==target2
        passed('Turn transfers to the second player, who can move their own units')
        before=guest.state();stop();start()
        after=guest.state()
        assert after['revision']==before['revision'] and after['activeFaction']==gf
        assert [(u['id'],u['cell'],u['health']) for u in after['units']]==[(u['id'],u['cell'],u['health']) for u in before['units']]
        assert host.call('/online/status')['hostFaction']==hf and guest.call('/online/status')['guestFaction']==gf
        passed('Server restart restores world, turn, units, invitations and country seats from disk')
        (saves/'public-url.txt').write_text('https://integration-test.trycloudflare.com')
        from playwright.sync_api import sync_playwright
        with sync_playwright() as pw:
            browser=pw.chromium.launch(headless=True,executable_path=shutil.which('chromium'),args=['--no-sandbox'])
            pages=[];contexts=[];errors=[]
            for role,token,viewport,mobile in [('host',cfg['hostToken'],{'width':1280,'height':800},False),('guest',cfg['guestToken'],{'width':844,'height':390},True)]:
                context=browser.new_context(viewport=viewport,is_mobile=mobile,has_touch=mobile)
                context.request.post(base+'/online/login',data={'token':token})
                page=context.new_page();page.on('pageerror',lambda e:errors.append(str(e)))
                page.goto(base);page.frame_locator('#game').locator('#play').wait_for(state='visible',timeout=60000)
                page.wait_for_timeout(1800)
                frame=page.frame_locator('#game');canvas=frame.locator('#map')
                size=canvas.evaluate('(e)=>({width:e.width,height:e.height})');assert size['width']>=viewport['width'] and size['height']>250
                assert not page.locator('#end').is_enabled() if role=='host' else page.locator('#end').is_enabled()
                page.screenshot(path=str(out/(role+'.png')))
                if role=='host':
                    page.locator('#back').click()
                    assert page.locator('#invite').is_visible()
                    assert page.locator('#invite').input_value().startswith('https://integration-test.trycloudflare.com/#join=')
                    page.locator('#open-game').click()
                pages.append(page);contexts.append(context)
            assert not errors,errors
            passed('Desktop and Android-sized touch browsers both render the actual battlefield without JavaScript errors')
            # Send the second player's end-turn through the real mobile UI.
            pages[1].locator('#end').click()
            wait_for(lambda:host.call('/online/status')['canAct'],150)
            current=host.state();assert current['round']>=2
            assert not host.call('/online/status')['problem']
            passed('Mobile UI ends a turn and the server independently runs the intervening AI countries into round two')
            contexts[1].close()
            reconnect=browser.new_context(viewport={'width':390,'height':844},is_mobile=True,has_touch=True)
            reconnect.request.post(base+'/online/login',data={'token':cfg['guestToken']})
            phone=reconnect.new_page();phone.goto(base);phone.frame_locator('#game').locator('#play').wait_for(state='visible',timeout=60000)
            assert guest.state()['playerFaction']==gf
            assert phone.locator('#bar').evaluate('(e)=>e.scrollWidth<=innerWidth')
            phone.screenshot(path=str(out/'android-portrait.png'))
            passed('Reconnection preserves the guest seat and the portrait phone layout fits the screen')
            host.call('/online/reset',{'confirm':True})
            phone.locator('#lobby').wait_for(state='visible',timeout=15000)
            host.call('/online/prepare',{'scenario':'conquest1','country':countries[0]['id']})
            guest.call('/online/choose',{'faction':gf})
            host.call('/online/start',{})
            phone.frame_locator('#game').locator('#play').wait_for(state='visible',timeout=60000)
            phone.wait_for_timeout(1200)
            frame=next(f for f in phone.frames if f.url.endswith('/game'))
            assert frame.evaluate('Ew4OnlineGame.revision()')==0
            assert guest.state()['playerFaction']==gf
            passed('A room reset sends both clients into a fresh rematch without retaining the previous world')
            reconnect.close();contexts[0].close();browser.close()
        report={'result':'PASS','upstream_commit':'3abe88c062b170837c4b290b674b0415bcb6dca8','checks':checks,'physical_android_device_tested':False,'full_match_played':False}
        (out/'integration.json').write_text(json.dumps(report,indent=2)+'\n')
    finally:stop();logs.close()

if __name__=='__main__':
    p=argparse.ArgumentParser();p.add_argument('--upstream',type=Path,required=True);p.add_argument('--dotnet',default='dotnet');p.add_argument('--output',type=Path,required=True)
    main(p.parse_args())

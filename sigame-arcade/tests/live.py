"""Exercise the real public links, including first-visit consent, in a browser."""
import hashlib
import json
import os
from pathlib import Path
from playwright.sync_api import sync_playwright

ROOT = Path(__file__).resolve().parents[2]
PUBLIC = 'https://rawcdn.githack.com/logi2564/imperii-online/arcade-61-v1/mini-games/index.html'
BASE = PUBLIC.rsplit('/', 1)[0] + '/'
errors, checks, verified = [], [], []
notices = 0
with sync_playwright() as playwright:
    browser = playwright.chromium.launch(executable_path=os.environ.get('BROWSER_EXECUTABLE'), args=['--no-sandbox'])
    for mobile in [False, True]:
        context = browser.new_context(viewport={'width': 360 if mobile else 1365, 'height': 800 if mobile else 900}, is_mobile=mobile, has_touch=mobile)
        page = context.new_page()
        # Start on a QR destination in a fresh browser, rather than after visiting the catalog.
        response = page.goto(PUBLIC + '?g=g42', wait_until='networkidle', timeout=60000)
        assert response.status == 200, response.status
        consent = page.get_by_role('button', name='Open the page', exact=True)
        if consent.count():
            consent.click()
            page.wait_for_load_state('networkidle', timeout=60000)
            notices += 1
        page.wait_for_selector('#begin-game', timeout=45000)
        assert page.evaluate('Arcade.meta.id') == 'g42', 'First-visit consent lost the QR game number'
        page.on('pageerror', lambda error: errors.append(str(error)))
        if not mobile:
            # Browser fetch uses the same normal browser session as players; no bot/WAF bypass.
            for name in ['index.html', 'style.css', 'catalog.js', 'engine.js', 'games.js', 'app.js', 'assets/qr-g01.png', 'assets/qr-g61.png']:
                actual = page.evaluate('''async url => {
                    const r = await fetch(url);
                    const bytes = await r.arrayBuffer();
                    const hash = await crypto.subtle.digest('SHA-256', bytes);
                    return {status:r.status, bytes:bytes.byteLength, type:r.headers.get('Content-Type'),
                        sha256:[...new Uint8Array(hash)].map(n=>n.toString(16).padStart(2,'0')).join('')};
                }''', BASE + name)
                expected = (ROOT / 'mini-games' / name).read_bytes()
                assert actual['status'] == 200, (name, actual)
                assert actual['sha256'] == hashlib.sha256(expected).hexdigest(), (name, actual)
                if name.endswith('.html'):
                    assert 'text/html' in actual['type']
                verified.append({'file': name, **actual})
        page.goto(PUBLIC, wait_until='networkidle', timeout=60000)
        assert page.locator('.card').count() == 61
        assert page.locator('.answer-box').count() == 0
        assert page.evaluate('document.documentElement.scrollWidth <= innerWidth')
        for game_id in ['g01', 'g42', 'g61']:
            page.goto(PUBLIC + '?g=' + game_id, wait_until='networkidle', timeout=60000)
            assert page.evaluate('Arcade.mode') == 'ready'
            assert page.evaluate('Arcade.meta.id') == game_id
            assert page.locator('.answer-box').count() == 0
            page.locator('#begin-game').click()
            assert page.evaluate('Arcade.mode') == 'playing'
            box = page.locator('#game-canvas').bounding_box()
            x, y = box['x'] + box['width'] / 2, box['y'] + box['height'] / 2
            if mobile:
                page.touchscreen.tap(x, y)
            else:
                page.mouse.click(x, y)
            assert page.evaluate('document.documentElement.scrollWidth <= innerWidth')
            assert not errors, errors
            checks.append({'game': game_id, 'mobile': mobile, 'publicStartAndInput': True})
        context.close()
    browser.close()

(ROOT / 'sigame-arcade/live-report.json').write_text(json.dumps({'url': PUBLIC, 'firstVisitNoticeAcknowledged': notices, 'publishedFilesMatchSource': verified, 'checks': checks, 'javascriptErrors': errors}, indent=2) + '\n')
print('PASS: live QR destinations preserve game after first-visit consent, exact published assets, 61-game catalog, PC/touch starts')

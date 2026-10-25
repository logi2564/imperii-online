"""Check the published site, not a localhost substitute, before releasing QR cards."""
import hashlib
import json
import os
import time
import urllib.request
from pathlib import Path
from playwright.sync_api import sync_playwright

ROOT = Path(__file__).resolve().parents[2]
PUBLIC = 'https://rawcdn.githack.com/logi2564/imperii-online/arcade-61-v1/mini-games/index.html'
BASE = PUBLIC.rsplit('/', 1)[0] + '/'

verified = []
for name in ['index.html', 'style.css', 'catalog.js', 'engine.js', 'games.js', 'app.js', 'assets/qr-g01.png', 'assets/qr-g61.png']:
    for attempt in range(4):
        try:
            with urllib.request.urlopen(BASE + name, timeout=45) as response:
                assert response.status == 200
                content = response.read()
                if name.endswith('.html'):
                    assert 'text/html' in response.headers.get('Content-Type', '')
            assert content == (ROOT / 'mini-games' / name).read_bytes(), name + ' differs from the tested source'
            verified.append({'file': name, 'sha256': hashlib.sha256(content).hexdigest()})
            break
        except Exception as error:
            if attempt == 3:
                print(f'::error::Public asset {name}: {type(error).__name__}: {error}', flush=True)
                raise
            time.sleep(5)

errors = []
checks = []
with sync_playwright() as playwright:
    browser = playwright.chromium.launch(executable_path=os.environ.get('BROWSER_EXECUTABLE'), args=['--no-sandbox'])
    for mobile in [False, True]:
        context = browser.new_context(viewport={'width': 360 if mobile else 1365, 'height': 800 if mobile else 900}, is_mobile=mobile, has_touch=mobile)
        page = context.new_page()
        page.on('pageerror', lambda error: errors.append(str(error)))
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

(ROOT / 'sigame-arcade/live-report.json').write_text(json.dumps({'url': PUBLIC, 'publishedFilesMatchSource': verified, 'checks': checks, 'javascriptErrors': errors}, indent=2) + '\n')
print('PASS: live public site, exact published assets, 61-game catalog, PC/touch starts, QR direct links, no JS errors')

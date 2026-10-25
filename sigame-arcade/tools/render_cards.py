from pathlib import Path
import os
from playwright.sync_api import sync_playwright
ROOT=Path(__file__).resolve().parents[2]
OUT=ROOT/'sigame-arcade/cards';OUT.mkdir(parents=True,exist_ok=True)
with sync_playwright() as p:
 browser=p.chromium.launch(executable_path=os.environ.get('BROWSER_EXECUTABLE'),args=['--no-sandbox'])
 page=browser.new_page(viewport={'width':1400,'height':860},device_scale_factor=1)
 for n in range(1,62):
  page.goto(f'http://127.0.0.1:8794/card.html?g=g{n:02d}')
  page.locator('#qr').evaluate('(el)=>el.decode()')
  page.screenshot(path=str(OUT/f'g{n:02d}.png'))
 browser.close()
print('Rendered 61 question cards with game previews and QR codes.')

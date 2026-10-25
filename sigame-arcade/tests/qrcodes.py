from pathlib import Path
import json
from PIL import Image
import zxingcpp
ROOT=Path(__file__).resolve().parents[2];root=ROOT/'sigame-arcade'
games=json.loads((root/'catalog.json').read_text())
for game in games:
 decoded=zxingcpp.read_barcodes(Image.open(root/'cards'/(game['id']+'.png')))
 expected='https://rawcdn.githack.com/logi2564/imperii-online/arcade-61-v1/mini-games/index.html?g='+game['id']
 assert any(code.text==expected for code in decoded),game['id']
(root/'qr-report.json').write_text(json.dumps({'renderedQuestionCards':61,'decodedCorrectLinks':61,'scanner':'zxing-cpp 2.3.0'},indent=2)+'\n')
print('PASS: 61 actual rendered QR question cards decode to their own game links')

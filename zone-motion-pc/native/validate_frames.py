from collections import Counter
import json
from pathlib import Path
import sys

from PIL import Image

root = Path(sys.argv[1])
for stage, scene in [('menu', 'Menu'), ('new-game', 'Kordon'), ('reload', 'Kordon')]:
    report = json.loads((root / (stage + '.json')).read_text(encoding='utf-8-sig'))
    assert report['scene'] == scene, report
    assert report['frames'] > 2, report
    assert report['errors'] == [], report
    assert report['renderer'] == 'Vulkan', report
    if stage == 'menu':
        assert report['buttons'] >= 5, report
    else:
        assert report['characters'] > 0, report
    with Image.open(root / (stage + '.png')) as source:
        assert source.width >= 960 and source.height >= 540, source.size
        image = source.convert('RGB').resize((320, 180))
        pixels = list(image.getdata())
        colors = Counter(pixels)
        assert len(colors) > 150, (stage, 'blank or uniform frame', len(colors))
        magenta = sum(1 for r, g, b in pixels if r > 220 and g < 45 and b > 220)
        assert magenta / len(pixels) < 0.01, (stage, 'unsupported magenta shaders')
    print(stage, 'scene:', report['scene'], 'renderer:', report['device'],
          'characters:', report['characters'], 'distinct colors:', len(colors))
print('Actual native menu, new-game and save/reload checks passed. Campaign checks remain.')

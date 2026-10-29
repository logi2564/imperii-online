"""Package only the audited enhanced map as the playable download."""
import hashlib
import json
import sys
import zipfile
from pathlib import Path

base, menu, release = map(Path, sys.argv[1:4])
release.mkdir(parents=True, exist_ok=True)
report = json.loads((menu/'Menu-report.json').read_text())
assert hashlib.sha256((menu/'GGG-RU-MENU.w3x').read_bytes()).hexdigest() == report['sha256']
tests = json.loads((menu/'Menu-tests.json').read_text())
assert tests['heroesTraversed'] == report['heroes']
assert tests['skillsTraversed'] == report['skills']
assert tests['pagesTraversed'] == report['skillPages']
assert report['strictJassCompilerClean']
readme = Path(__file__).parent/'README-RU.txt'
map_file = release/'GGG-RU-MENU.w3x'
map_file.write_bytes((menu/'GGG-RU-MENU.w3x').read_bytes())
archive = release/'GGG-RU-MENU.zip'
with zipfile.ZipFile(archive, 'w', zipfile.ZIP_DEFLATED, compresslevel=6) as z:
    z.write(map_file, map_file.name)
    z.write(readme, 'НАЧНИ-ЗДЕСЬ.txt')
    for name in ['Menu-report.json', 'Menu-tests.json', 'Menu-compiler.txt', 'Source-patches.json', 'Hero-handbook.json']:
        z.write(menu/name, 'Проверки/'+name)
    for name in ['Localization-report.json', 'Verification-report.json', 'Compiler-report.json', 'Text-storage.json']:
        z.write(base/name, 'Проверки/Перевод/'+name)
for name in ['Menu-report.json', 'Menu-tests.json']:
    (release/name).write_bytes((menu/name).read_bytes())
(release/'README-RU.txt').write_bytes(readme.read_bytes())
(release/'SHA256SUMS.txt').write_text(''.join(hashlib.sha256(p.read_bytes()).hexdigest()+'  '+p.name+'\n' for p in [map_file, archive]))
print('Packaged audited enhanced map:', map_file)

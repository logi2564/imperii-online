"""Package the checked repair candidate without changing its map bytes."""
import hashlib
import json
import sys
import zipfile
from pathlib import Path

ROOT=Path(__file__).resolve().parent
out=Path(sys.argv[1]);release=Path(sys.argv[2])
map_data=(out/'Maps/Rexxar-VII-Coop-1.26.w3x').read_bytes()
report=(out/'Build-report.json').read_bytes()
if hashlib.sha256(map_data).hexdigest()!=json.loads(report)['sha256']:
    raise ValueError('Map does not match the checked build report')
readme=(ROOT/'README-Repair-RU.txt').read_bytes()
logs={p.name:p.read_bytes() for p in sorted(out.glob('*-check.txt'))}
required={'JASS','Independent','Archive','Behavior','Campaign-integration',
          'Campaign-routes','Story-restore','Talent-book','Skill-regression',
          'Skill-demo','World-restore'}
missing={name+'-check.txt' for name in required}-logs.keys()
if missing:
    raise ValueError('Missing check logs: '+', '.join(sorted(missing)))
release.mkdir(parents=True,exist_ok=True)
stem='Rexxar-Repair-Preview-1.26'
map_file=release/(stem+'.w3x');map_file.write_bytes(map_data)
archive=release/(stem+'.zip')
with zipfile.ZipFile(archive,'w',compression=zipfile.ZIP_DEFLATED,compresslevel=9) as z:
    z.writestr(map_file.name,map_data)
    z.writestr('НАЧНИ-ЗДЕСЬ.txt',readme)
    z.writestr('Проверки/Build-report.json',report)
    for name,data in logs.items():z.writestr('Проверки/'+name,data)
(release/'README-Repair-RU.txt').write_bytes(readme)
(release/'Build-report.json').write_bytes(report)
(release/'SHA256SUMS.txt').write_text(''.join(
    hashlib.sha256(p.read_bytes()).hexdigest()+'  '+p.name+'\n'
    for p in [map_file,archive]))
print('Packaged checked preview:',archive)

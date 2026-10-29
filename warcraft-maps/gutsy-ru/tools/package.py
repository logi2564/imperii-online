"""Deliver the exact audited localized W3X and its Russian instructions."""
import hashlib,json,sys,zipfile
from pathlib import Path

ROOT=Path(__file__).resolve().parents[1]
out=Path(sys.argv[1]);release=Path(sys.argv[2]);release.mkdir(parents=True,exist_ok=True)
map_file=out/'Gutsy-Geoid-Game-RU-v1.0.5.w3x'
assert hashlib.sha256(map_file.read_bytes()).hexdigest()==json.loads((out/'Localization-report.json').read_text())['sha256']
published=release/'GGG-RU-FIX2.w3x'
archive=release/'GGG-RU-FIX2.zip'
with zipfile.ZipFile(archive,'w',compression=zipfile.ZIP_DEFLATED,compresslevel=6) as z:
    z.write(map_file,published.name);z.write(ROOT/'README-RU.txt','НАЧНИ-ЗДЕСЬ.txt')
    for name in ['Localization-report.json','Verification-report.json','Compiler-report.json','Text-storage.json','Original-compiler.txt','Russian-compiler.txt']:
        z.write(out/name,'Проверки/'+name)
    for path in sorted(out.glob('*-check.txt')):z.write(path,'Проверки/'+path.name)
published.write_bytes(map_file.read_bytes())
for name in ['Localization-report.json','Verification-report.json','Compiler-report.json']:(release/name).write_bytes((out/name).read_bytes())
(release/'README-RU.txt').write_bytes((ROOT/'README-RU.txt').read_bytes())
(release/'SHA256SUMS.txt').write_text(''.join(hashlib.sha256(p.read_bytes()).hexdigest()+'  '+p.name+'\n' for p in [published,archive]))
print('Packaged',archive)

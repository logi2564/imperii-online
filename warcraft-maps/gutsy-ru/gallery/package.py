"""Publish only a map that passed the shipped-code and MPQ audits."""
import hashlib
import json
import shutil
import sys
import zipfile
from pathlib import Path


def package(base,out,release):
    base,out,release=map(Path,(base,out,release))
    release.mkdir(parents=True,exist_ok=True)
    report=json.loads((out/'Gallery-report.json').read_text())
    tests=json.loads((out/'Gallery-tests.json').read_text())
    audit=json.loads((out/'Gallery-audit.json').read_text())
    source=out/'GGG-RU-GALLERY-FIX.w3x'
    assert report['sha256']==audit['sha256']==tests['sha256']==hashlib.sha256(source.read_bytes()).hexdigest()
    assert report['strictJassCompilerClean'] and tests['actualOriginalSaleAndPortalHandlers']
    assert (tests['heroesTraversed'],tests['skillsTraversed'],tests['pagesTraversed'])==(81,808,2365)
    assert len(tests['actualHeroInitializations'])==81
    assert tests['arenaPlayersTested']==[1,2,3,10] and tests['epiccenterPlayersTested']==2
    target=release/source.name;shutil.copyfile(source,target)
    readme=Path(__file__).parent/'README-RU.txt'
    names=['Gallery-report.json','Gallery-tests.json','Gallery-audit.json','Gallery-compiler.txt',
           'Gallery-patches.json','Gallery-data.json','Gallery-bindings.json']
    with zipfile.ZipFile(release/'GGG-RU-GALLERY-FIX.zip','w',zipfile.ZIP_DEFLATED,compresslevel=6) as z:
        z.write(target,target.name);z.write(readme,'НАЧНИ-ЗДЕСЬ.txt')
        for name in names:z.write(out/name,'Проверки/'+name)
        for name in ['Localization-report.json','Verification-report.json','Compiler-report.json','Text-storage.json']:
            z.write(base/name,'Проверки/Перевод/'+name)
        for name in ['Menu-preview.png','Saber-preview.png']:
            z.write(out/name,'Эскизы-панели/'+name)
    for name in ['Gallery-report.json','Gallery-tests.json','Gallery-audit.json']:
        shutil.copyfile(out/name,release/name)
    shutil.copyfile(readme,release/'README-RU.txt')
    with (release/'SHA256SUMS.txt').open('w') as f:
        for p in sorted(release.iterdir()):
            if p.name!='SHA256SUMS.txt':f.write(hashlib.sha256(p.read_bytes()).hexdigest()+'  '+p.name+'\n')
    print('Packaged audited gallery:',target)


if __name__=='__main__':package(*sys.argv[1:4])

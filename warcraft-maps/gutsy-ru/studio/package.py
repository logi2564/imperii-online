"""Publish the exact Studio map that passed compilation and both audits."""
import hashlib
import json
import shutil
import sys
import zipfile
from pathlib import Path


def package(base,out,release):
    base,out,release=map(Path,(base,out,release))
    release.mkdir(parents=True,exist_ok=True)
    source=out/'GGG-RU-STUDIO-TEST.w3x'
    reports={name:json.loads((out/name).read_text()) for name in
             ('Studio-report.json','Studio-audit.json','Studio-tests.json')}
    digest=hashlib.sha256(source.read_bytes()).hexdigest()
    assert all(r['sha256']==digest and r['nativeWarcraftTested'] is False for r in reports.values())
    assert reports['Studio-report.json']['strictJassCompilerClean']
    assert reports['Studio-audit.json']['mainGameCodeRecoveredExactly']
    assert reports['Studio-audit.json']['noMutableNamespaceLeaks']
    tests=reports['Studio-tests.json']
    assert (tests['heroesTraversed'],tests['skillsTraversed'],tests['pagesTraversed'])==(81,808,2365)
    assert tests['originalModeHandlers']==[1,2,3] and tests['arenaPlayersTested']==[1,2,3,10]
    assert tests['sceneResourcesAndSparseArraysCleaned'] and tests['battleAfterSceneCleanup']
    assert tests['castEventRequiredForDemoSuccess'] and tests['actualOriginalSaleAndPortalHandlers']
    gallery=json.loads((out/'Gallery-tests.json').read_text())
    gallery_digest=hashlib.sha256((out/'GGG-RU-GALLERY-FIX.w3x').read_bytes()).hexdigest()
    assert gallery['sha256']==gallery_digest and len(gallery['actualHeroInitializations'])==81
    shutil.copyfile(source,release/source.name)
    readme=Path(__file__).parent/'README-RU.txt'
    names=list(reports)+['Studio-compiler.txt','Studio-cards.json','Studio-metadata.json',
                         'Studio-ui-patches.json','Gallery-tests.json','Gallery-audit.json']
    with zipfile.ZipFile(release/'GGG-RU-STUDIO-TEST.zip','w',zipfile.ZIP_DEFLATED,compresslevel=6) as z:
        z.write(source,source.name);z.write(readme,'НАЧНИ-ЗДЕСЬ.txt')
        for name in names:z.write(out/name,'Проверки/'+name)
        for name in ('Localization-report.json','Verification-report.json','Compiler-report.json','Text-storage.json'):
            z.write(base/name,'Проверки/Перевод/'+name)
        z.write(out/'Studio-card-preview.png','Эскиз-карточки.png')
    for name in reports:shutil.copyfile(out/name,release/name)
    shutil.copyfile(readme,release/'README-RU.txt')
    with (release/'SHA256SUMS.txt').open('w') as f:
        for p in sorted(release.iterdir()):
            if p.name!='SHA256SUMS.txt':f.write(hashlib.sha256(p.read_bytes()).hexdigest()+'  '+p.name+'\n')
    print('Packaged audited Studio map:',source.name,digest)


if __name__=='__main__':package(*sys.argv[1:4])

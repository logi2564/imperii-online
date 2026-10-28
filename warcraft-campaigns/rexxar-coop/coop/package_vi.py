"""Package newly generated gameplay bytes; never replace them with baseline C."""
import argparse,hashlib,json,shutil,zipfile
from pathlib import Path
ROOT=Path(__file__).resolve().parent
from talents import TREES,LEVELS

def package(missions,helper,out):
    out.mkdir(parents=True,exist_ok=True);stage=out/'vi-package';maps=stage/'Maps/Rexxar-Coop-VI';maps.mkdir(parents=True,exist_ok=True)
    files=sorted((missions/'Maps').glob('RX6-*.w3x'));assert len(files)==17
    generated=json.loads((missions/'Build-report.json').read_text())
    for path in files:
        row=next(row for row in generated['maps'] if path.name=='RX6-'+row['map']+'.w3x')
        assert hashlib.sha256(path.read_bytes()).hexdigest()==row['sha256']
        shutil.copyfile(path,maps/path.name)
    exe=helper/'RexxarCoop-Saves.exe';assert exe.read_bytes()[:2]==b'MZ';shutil.copyfile(exe,stage/exe.name)
    shutil.copyfile(ROOT/'README-VI-FIX-RU.txt',stage/'ЧИТАЙ.txt')
    shutil.copyfile(ROOT/'README-VI-RU.txt',stage/'Справка-VI.txt')
    descriptions=[]
    for role,tree in enumerate(TREES):
        descriptions.append(['РЕКСАР','РОКХАН','ЧЭНЬ','КЭРН'][role])
        for tier,options in enumerate(tree):
            descriptions.append('Уровень '+str(LEVELS[tier])+': выбери один из двух')
            for name,text in options:descriptions.append('  '+name+' — '+text)
        descriptions.append('')
    (stage/'Таланты.txt').write_text('\n'.join(descriptions))
    reports=stage/'Reports';reports.mkdir(exist_ok=True)
    for folder in (missions,helper):
        for pattern in ('*-check.txt','*-report.json'):
            for path in folder.glob(pattern):shutil.copyfile(path,reports/path.name)
    manifest=dict(version='VI-FIX',status='xp-skill-code-fix-awaiting-native-party-test',nativeWarcraftExecutedInCloud=False,seamlessLocationTransitions=False,baselineCEntryConfirmedByUser=True,baselineLobbyPreserved=False,standardColours=True,requiresRed=True,minPlayers=1,maxPlayers=4,heroLevelCap=20,allMissionLobbiesTested=False,wholeCampaignPlaythroughTested=False,liveIrinaBotTested=False,skills=16,talentChoices=40,saveFormat='Z6/Z5 (C4, legacy compatible); high-entropy solo S2 stash',maps=[dict(file=path.name,bytes=path.stat().st_size,sha256=hashlib.sha256(path.read_bytes()).hexdigest()) for path in sorted(maps.glob('*.w3x'))])
    for target in (reports/'VI-package.json',out/'VI-package.json'):target.write_text(json.dumps(manifest,ensure_ascii=False,indent=2))
    archive=out/'Rexxar-Coop-VI-Fix.zip'
    with zipfile.ZipFile(archive,'w',zipfile.ZIP_DEFLATED) as z:
        for path in sorted(stage.rglob('*')):
            if path.is_file():z.write(path,path.relative_to(stage).as_posix())
    with zipfile.ZipFile(archive) as z:
        assert z.testzip() is None
        for path in files:assert z.read('Maps/Rexxar-Coop-VI/'+path.name)==path.read_bytes()
    (out/(archive.name+'.sha256')).write_text(hashlib.sha256(archive.read_bytes()).hexdigest()+'  '+archive.name+'\n')
    shutil.copyfile(maps/'RX6-OrcX01.w3x',out/'RX6-OrcX01.w3x')
    (out/'Package-check.txt').write_text('PASS: exact 17 newly generated RX6 mission bytes packaged, no stale C substitution; ZIP CRC, inventory, generated build hashes, first mission, and Windows helper MZ verified. Native game testing is pending.\n')
    return dict(maps=17,bytes=archive.stat().st_size)
if __name__=='__main__':
    p=argparse.ArgumentParser();p.add_argument('missions',type=Path);p.add_argument('helper',type=Path);p.add_argument('out',type=Path);a=p.parse_args();print(package(a.missions,a.helper,a.out))

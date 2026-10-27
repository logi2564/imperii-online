"""Package newly generated gameplay bytes; never replace them with baseline C."""
import argparse,hashlib,json,shutil,zipfile
from pathlib import Path
ROOT=Path(__file__).resolve().parent

def package(missions,helper,out):
    out.mkdir(parents=True,exist_ok=True);stage=out/'iv-package';maps=stage/'Maps/Rexxar-Coop-IV';maps.mkdir(parents=True,exist_ok=True)
    files=sorted((missions/'Maps').glob('RX4-*.w3x'));assert len(files)==17
    generated=json.loads((missions/'Build-report.json').read_text())
    for path in files:
        row=next(row for row in generated['maps'] if path.name=='RX4-'+row['map']+'.w3x')
        assert hashlib.sha256(path.read_bytes()).hexdigest()==row['sha256']
        shutil.copyfile(path,maps/path.name)
    exe=helper/'RexxarCoop-Saves.exe';assert exe.read_bytes()[:2]==b'MZ';shutil.copyfile(exe,stage/exe.name)
    shutil.copyfile(ROOT/'README-IV-RU.txt',stage/'ЧИТАЙ.txt')
    reports=stage/'Reports';reports.mkdir(exist_ok=True)
    for folder in (missions,helper):
        for pattern in ('*-check.txt','*-report.json'):
            for path in folder.glob(pattern):shutil.copyfile(path,reports/path.name)
    manifest=dict(version='IV',status='new-gameplay-awaiting-native-party-test',nativeWarcraftExecutedInCloud=False,baselineCEntryConfirmedByUser=True,baselineLobbyPreserved=True,allMissionLobbiesTested=False,wholeCampaignPlaythroughTested=False,liveIrinaBotTested=False,skills=16,saveFormat='Z3 (C2 compatible)',maps=[dict(file=path.name,bytes=path.stat().st_size,sha256=hashlib.sha256(path.read_bytes()).hexdigest()) for path in sorted(maps.glob('*.w3x'))])
    for target in (reports/'IV-package.json',out/'IV-package.json'):target.write_text(json.dumps(manifest,ensure_ascii=False,indent=2))
    archive=out/'Rexxar-Coop-IV.zip'
    with zipfile.ZipFile(archive,'w',zipfile.ZIP_DEFLATED) as z:
        for path in sorted(stage.rglob('*')):
            if path.is_file():z.write(path,path.relative_to(stage).as_posix())
    with zipfile.ZipFile(archive) as z:
        assert z.testzip() is None
        for path in files:assert z.read('Maps/Rexxar-Coop-IV/'+path.name)==path.read_bytes()
    (out/(archive.name+'.sha256')).write_text(hashlib.sha256(archive.read_bytes()).hexdigest()+'  '+archive.name+'\n')
    shutil.copyfile(maps/'RX4-OrcX01.w3x',out/'RX4-OrcX01.w3x')
    (out/'Package-check.txt').write_text('PASS: exact 17 newly generated RX4 mission bytes packaged, no stale C substitution; ZIP CRC, inventory, generated build hashes, first mission, and Windows helper MZ verified. Native game testing is pending.\n')
    return dict(maps=17,bytes=archive.stat().st_size)
if __name__=='__main__':
    p=argparse.ArgumentParser();p.add_argument('missions',type=Path);p.add_argument('helper',type=Path);p.add_argument('out',type=Path);a=p.parse_args();print(package(a.missions,a.helper,a.out))

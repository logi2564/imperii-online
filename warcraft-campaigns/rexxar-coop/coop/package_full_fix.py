"""Package all corrected missions; use the EXACT C file accepted by the user."""
import argparse,hashlib,json,shutil,urllib.request,zipfile
from pathlib import Path

ROOT=Path(__file__).resolve().parent

def package(missions,helper,out,accepted=None):
    out.mkdir(parents=True,exist_ok=True);stage=out/'full-package';maps=stage/'Maps/Rexxar-Coop-Fixed';maps.mkdir(parents=True,exist_ok=True)
    pins=json.loads((ROOT/'accepted-first.json').read_text())
    if accepted is None:
        with urllib.request.urlopen(pins['url'],timeout=60) as response:blob=response.read()
    else:blob=accepted.read_bytes()
    if len(blob)!=pins['bytes'] or hashlib.sha256(blob).hexdigest()!=pins['sha256']:raise ValueError('Accepted first-map pin mismatch')
    files=sorted((missions/'Maps').glob('RX3-*.w3x'));assert len(files)==17
    for path in files:shutil.copyfile(path,maps/path.name)
    # Keep canonical filenames for return-to-hub codes, without changing a byte
    # of the very map on which the user confirmed local lobby acceptance.
    (maps/'RX3-OrcX01.w3x').write_bytes(blob)
    exe=helper/'RexxarCoop-Saves.exe';assert exe.read_bytes()[:2]==b'MZ';shutil.copyfile(exe,stage/exe.name)
    shutil.copyfile(ROOT/'README-FIXED-RU.txt',stage/'ЧИТАЙ.txt')
    reports=stage/'Reports';reports.mkdir(exist_ok=True)
    for name in ['Lobby-report.json']:
        if (missions/name).exists():shutil.copyfile(missions/name,reports/name)
    generated=json.loads((missions/'Build-report.json').read_text())
    first=next(row for row in generated['maps'] if row['map']=='OrcX01')
    first['generatedFirstMapSha256']=first['sha256'];first['sha256']=pins['sha256'];first['bytes']=pins['bytes'];first['localLobbyOpenedByUser']=True
    generated['acceptedFirstMapSubstitution']=pins
    (reports/'Build-report.json').write_text(json.dumps(generated,ensure_ascii=False,indent=2))
    for folder in [missions,helper]:
        for path in folder.glob('*-check.txt'):shutil.copyfile(path,reports/path.name)
    if (missions/'type-fix/Type-fix-check.txt').exists():shutil.copyfile(missions/'type-fix/Type-fix-check.txt',reports/'Type-fix-check.txt')
    manifest=dict(status='first-native-lobby-confirmed-by-user',nativeWarcraftExecutedInCloud=False,firstMap=pins,allMissionLobbiesTested=False,wholeCampaignPlaythroughTested=False,liveIrinaBotTested=False,maps=[dict(file=path.name,bytes=path.stat().st_size,sha256=hashlib.sha256(path.read_bytes()).hexdigest()) for path in sorted(maps.glob('*.w3x'))])
    (reports/'Fixed-package.json').write_text(json.dumps(manifest,ensure_ascii=False,indent=2));(out/'Fixed-package.json').write_text(json.dumps(manifest,ensure_ascii=False,indent=2))
    archive=out/'Rexxar-Coop-Fixed.zip'
    with zipfile.ZipFile(archive,'w',zipfile.ZIP_DEFLATED) as z:
        for path in sorted(stage.rglob('*')):
            if path.is_file():z.write(path,path.relative_to(stage).as_posix())
    with zipfile.ZipFile(archive) as z:
        assert z.testzip() is None
        assert z.read('Maps/Rexxar-Coop-Fixed/RX3-OrcX01.w3x')==blob
    (out/(archive.name+'.sha256')).write_text(hashlib.sha256(archive.read_bytes()).hexdigest()+'  '+archive.name+'\n')
    (out/'Accepted-First-Mission.w3x').write_bytes(blob)
    proof='PASS: 17 corrected mission files packaged; the first-map bytes exactly match the pinned C file whose lobby the user confirmed on Warcraft1.26.0.6401; final ZIP CRC and inventory hashes verified. Native gameplay/whole campaign/IrinaBot were NOT tested.'
    (out/'Package-check.txt').write_text(proof+'\n')
    return dict(maps=17,zipBytes=archive.stat().st_size,firstMapSha256=pins['sha256'],localLobbyOpenedByUser=True,wholeCampaignPlaythroughTested=False)

if __name__=='__main__':
    p=argparse.ArgumentParser();p.add_argument('missions',type=Path);p.add_argument('helper',type=Path);p.add_argument('out',type=Path);p.add_argument('--accepted-first',type=Path);a=p.parse_args()
    print(json.dumps(package(a.missions,a.helper,a.out,a.accepted_first),indent=2))

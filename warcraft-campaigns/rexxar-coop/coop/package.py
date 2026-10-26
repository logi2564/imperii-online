import hashlib,json,shutil,sys,zipfile
from pathlib import Path
root=Path(__file__).resolve().parent
maps=Path(sys.argv[1]);helper=Path(sys.argv[2]);out=Path(sys.argv[3]);package=out/'package';target=package/'Maps'/'Rexxar-Coop';target.mkdir(parents=True,exist_ok=True)
files=list((maps/'Maps').glob('*.w3x'));assert len(files)==17
for file in files:shutil.copyfile(file,target/file.name)
exe=helper/'RexxarCoop-Saves.exe';assert exe.read_bytes()[:2]==b'MZ'
shutil.copyfile(exe,package/exe.name);shutil.copyfile(root/'README-RU.txt',package/'RexxarCoop-ЧИТАЙ.txt')
reports=package/'RexxarCoop-Reports';reports.mkdir(exist_ok=True)
for folder in [maps,helper]:
    for file in folder.glob('*.txt'):shutil.copyfile(file,reports/file.name)
shutil.copyfile(maps/'Build-report.json',reports/'Build-report.json')
archive=out/'Rexxar-Coop-RC1.zip'
with zipfile.ZipFile(archive,'w',zipfile.ZIP_DEFLATED) as z:
    for file in sorted(package.rglob('*')):
        if file.is_file():z.write(file,file.relative_to(package).as_posix())
with zipfile.ZipFile(archive) as z:assert z.testzip() is None
checksum=hashlib.sha256(archive.read_bytes()).hexdigest();(out/'Rexxar-Coop-RC1.zip.sha256').write_text(checksum+'  '+archive.name+'\n')
print(json.dumps({'maps':17,'zipBytes':archive.stat().st_size,'sha256':checksum,'nativeWarcraftTested':False}))

import hashlib,json,sys,zipfile
from pathlib import Path
from build import ROOT
out=Path(sys.argv[1]);release=Path(sys.argv[2]);release.mkdir(parents=True,exist_ok=True)
path=out/'Maps/Rexxar-VII-Coop-1.26.w3x';report=json.loads((out/'Build-report.json').read_text());assert report['sha256']==hashlib.sha256(path.read_bytes()).hexdigest()
archive=release/'Rexxar-VII-Coop-1.26.zip'
with zipfile.ZipFile(archive,'w',compression=zipfile.ZIP_DEFLATED,compresslevel=9) as z:
 z.write(path,path.name);z.write(ROOT/'README-VII-RU.txt','НАЧНИ-ЗДЕСЬ.txt')
 for name in ['Build-report.json','JASS-check.txt','Behavior-check.txt','Archive-check.txt','Independent-check.txt']:z.write(out/name,'Проверки/'+name)
for file in [archive]:file.with_suffix(file.suffix+'.sha256').write_text(hashlib.sha256(file.read_bytes()).hexdigest()+'  '+file.name+'\n')
(release/path.name).write_bytes(path.read_bytes());print(archive)

"""Package tested outputs without bundling build caches or intermediate assets."""
import argparse,hashlib,shutil,zipfile
from pathlib import Path
ROOT=Path(__file__).resolve().parent
DOWNLOAD='23-Races-Race-Selection-FIX1-1.26'
def package(work,out):
    out.mkdir(parents=True,exist_ok=True)
    game=work/'23-Races-Race-Selection-1.26.w3x';name=DOWNLOAD+'.w3x';shutil.copy2(game,out/name)
    digest=hashlib.sha256(game.read_bytes()).hexdigest()
    (out/(name+'.sha256')).write_text(digest+'  '+name+'\n')
    shutil.copy2(ROOT/'README-RU.txt',out/'README-RU.txt')
    with zipfile.ZipFile(out/(DOWNLOAD+'.zip'),'w',zipfile.ZIP_DEFLATED,compresslevel=6)as z:
        z.write(game,name);z.write(ROOT/'README-RU.txt','README-RU.txt')
        for name in ('build-report.json','preservation-tests.json','runtime-tests.json','pjass-runtime.txt','pjass-editor.txt'):
            z.write(work/name,'verification/'+name)
    print('Packaged '+str(game.stat().st_size)+' byte map; SHA256 '+digest)
if __name__=='__main__':
    p=argparse.ArgumentParser();p.add_argument('work',type=Path);p.add_argument('out',type=Path);a=p.parse_args();package(a.work,a.out)

from pathlib import Path
import argparse,json,shutil,hashlib,zipfile

here=Path(__file__).resolve().parent
p=argparse.ArgumentParser();p.add_argument('--electron',type=Path,required=True);p.add_argument('--root',type=Path,required=True);p.add_argument('--output',type=Path,required=True);a=p.parse_args()
root=a.root.resolve();root.mkdir(parents=True,exist_ok=True)
assert (root/'server/Ew4.Web.exe').exists(),'Publish the Windows engine before packaging'
shutil.copytree(a.electron.resolve(),root,dirs_exist_ok=True)
(root/'electron.exe').rename(root/'EuropeanWar4-Napoleon.exe')
default=root/'resources/default_app.asar'
if default.exists():default.unlink()
app=root/'resources/app';app.mkdir(parents=True,exist_ok=True)
for name in ['main.cjs','preload.cjs','game-icon.png']:shutil.copyfile(here/name,app/name)
meta=json.loads((here/'package.json').read_text());meta.pop('devDependencies',None);(app/'package.json').write_text(json.dumps(meta,indent=2)+'\n')
shutil.copyfile(here.parent/'NATIVE-READ-ME.txt',root/'READ-ME.txt')
shutil.copyfile(here.parent/'UPSTREAM.json',root/'UPSTREAM.json')
shutil.copyfile(here.parent/'localization/DejaVu-LICENSE.txt',root/'DejaVu-LICENSE.txt')
entries=sorted(f for f in root.rglob('*') if f.is_file() and f.name!='SHA256SUMS.txt')
(root/'SHA256SUMS.txt').write_text(''.join(hashlib.sha256(f.read_bytes()).hexdigest()+'  '+f.relative_to(root).as_posix()+'\n' for f in entries),encoding='utf-8')
a.output.parent.mkdir(parents=True,exist_ok=True)
with zipfile.ZipFile(a.output,'w',zipfile.ZIP_DEFLATED,compresslevel=6) as z:
    for f in sorted(root.rglob('*')):
        if f.is_file():z.write(f,f.relative_to(root.parent))
digest=hashlib.sha256(a.output.read_bytes()).hexdigest();Path(str(a.output)+'.sha256').write_text(digest+'  '+a.output.name+'\n')
(a.output.parent/'native-build-info.json').write_text(json.dumps({'file':a.output.name,'bytes':a.output.stat().st_size,'sha256':digest,'version':'0.2.0','own_desktop_window':True,'external_browser':False,'menus':'Russian','original_narrative':'English','source':'EW4 Rewrite 0.2.19 plus user-provided EW4 1.4.50 language resources'},indent=2)+'\n')
print('Packaged own-window game:',a.output.name,a.output.stat().st_size,digest)

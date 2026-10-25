"""Build the actual .NET Android game, including every offline game asset."""
from pathlib import Path
import argparse,subprocess,os,json,hashlib,shutil,zipfile,re
p=argparse.ArgumentParser();p.add_argument('--upstream',type=Path,required=True);p.add_argument('--output',type=Path,required=True);a=p.parse_args()
root=a.upstream.resolve();out=a.output.resolve();out.mkdir(parents=True,exist_ok=True);project=root/'rewrite/Ew4.Android';report={'result':'FAIL','stage':'android_compile'}
try:
 for diagnostic in [False,True]:
  private=out/('private-test-build.log'if diagnostic else'private-release-build.log')
  command=['dotnet','publish',str(project),'-c','Release','-p:AndroidSdkDirectory='+os.environ['ANDROID_HOME'],'-p:AndroidPackageFormats=apk','-p:AndroidKeyStore=false']
  if diagnostic:command+=['-p:DefineConstants=EW4_DIAGNOSTICS','-p:AndroidDebuggable=true']
  with private.open('w')as log:process=subprocess.run(command,stdout=log,stderr=subprocess.STDOUT)
  if process.returncode:
   text=private.read_text(errors='replace');report.update(exit_code=process.returncode,compiler_error_codes=sorted(set(re.findall(r'\b(?:CS|XA|MSB|NETSDK)\d{3,6}\b',text))))
   raise RuntimeError('Android compiler failed')
  candidates=sorted((project/'bin/Release').rglob('*-Signed.apk'),key=lambda p:p.stat().st_mtime)
  assert candidates
  target=out/('EuropeanWar4-Full-Android-test.apk'if diagnostic else'EuropeanWar4-Full-Android.apk');shutil.copyfile(candidates[-1],target)
  with zipfile.ZipFile(target)as z:
   names=z.namelist();assert 'assets/www/native-ru.json'in names;assert 'assets/www/content/ui/main.png'in names
   battles=[n for n in names if n.startswith('assets/original/')and n.endswith('.btl')];assert len(battles)>=100
   assert any(n.startswith('lib/arm64-v8a/')for n in names)
   assert target.stat().st_size>30*1024*1024
  digest=hashlib.sha256(target.read_bytes()).hexdigest();Path(str(target)+'.sha256').write_text(digest+'  '+target.name+'\n')
  if not diagnostic:
   (out/'android-build-info.json').write_text(json.dumps({'file':target.name,'bytes':target.stat().st_size,'sha256':digest,'version':'0.3.0','package':'org.logi2564.ew4fullgame','standalone_game_engine':True,'bundled_resources':True,'campaign_battle_files':len(battles),'offline_single_player':True,'renderer':'canvas2d','menus':'Russian','narrative':'Russian','development_signed':True,'min_sdk':26},indent=2)+'\n')
 report.update(result='PASS',stage='complete')
except Exception as e:
 report['exception_type']=type(e).__name__
finally:(out/'android-compile-status.json').write_text(json.dumps(report,indent=2)+'\n')
print(json.dumps(report,indent=2),flush=True)
if report['result']!='PASS':raise SystemExit(1)

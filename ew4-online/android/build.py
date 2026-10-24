from pathlib import Path
import argparse,os,subprocess,tempfile,zipfile,hashlib,json,shutil

p=argparse.ArgumentParser();p.add_argument('--sdk',type=Path,default=Path(os.environ.get('ANDROID_HOME','/opt/android-sdk')));p.add_argument('--output',type=Path,required=True);p.add_argument('--debug',action='store_true');a=p.parse_args()
here=Path(__file__).resolve().parent;out=a.output.resolve();out.mkdir(parents=True,exist_ok=True)
sdk=a.sdk.resolve();tools=sdk/'build-tools/35.0.0';platform=sdk/'platforms/android-35/android.jar'
def run(args):subprocess.run([str(x) for x in args],check=True)
with tempfile.TemporaryDirectory(prefix='ew4-apk-') as temp:
    work=Path(temp);classes=work/'classes';classes.mkdir();dex=work/'dex';dex.mkdir()
    compiler=['javac'] if shutil.which('javac') else ['java','-m','jdk.compiler/com.sun.tools.javac.Main']
    config=work/'BuildConfig.java';config.write_text('package org.logi2564.ew4online; public final class BuildConfig { public static final boolean DEBUG='+str(a.debug).lower()+'; }\n')
    run(compiler+['-source','8','-target','8','-Xlint:-options','-encoding','UTF-8','-bootclasspath',platform,'-classpath',platform,'-d',classes,config,here/'GameActivity.java'])
    jar=work/'classes.jar'
    with zipfile.ZipFile(jar,'w',zipfile.ZIP_DEFLATED) as z:
        for file in classes.rglob('*.class'):z.write(file,file.relative_to(classes))
    run([tools/'d8','--min-api','23','--lib',platform,'--output',dex,jar])
    resources=work/'res/drawable';resources.mkdir(parents=True);shutil.copyfile(here.parent/'desktop/game-icon.png',resources/'game_icon.png')
    compiled=work/'resources.zip';run([tools/'aapt2','compile','--dir',work/'res','-o',compiled])
    manifest=work/'AndroidManifest.xml';text=(here/'AndroidManifest.xml').read_text()
    if a.debug:text=text.replace('<application ','<application android:debuggable="true" ')
    manifest.write_text(text)
    unsigned=work/'unsigned.apk';run([tools/'aapt2','link','-I',platform,'--manifest',manifest,'-R',compiled,'--min-sdk-version','23','--target-sdk-version','35','-o',unsigned])
    with zipfile.ZipFile(unsigned,'a',zipfile.ZIP_DEFLATED) as z:z.write(dex/'classes.dex','classes.dex')
    aligned=work/'aligned.apk';run([tools/'zipalign','-p','4',unsigned,aligned])
    key=work/'test-signing.p12'
    run(['keytool','-genkeypair','-keystore',key,'-storetype','PKCS12','-storepass','android','-keypass','android','-alias','androiddebugkey','-keyalg','RSA','-keysize','2048','-validity','10000','-dname','CN=EW4 Online Development,O=Unofficial game client,C=UA'])
    apk=out/('EuropeanWar4-Online-Android-test.apk' if a.debug else 'EuropeanWar4-Online-Android.apk')
    run([tools/'apksigner','sign','--ks',key,'--ks-pass','pass:android','--key-pass','pass:android','--out',apk,aligned])
    run([tools/'apksigner','verify','--verbose',apk])
    digest=hashlib.sha256(apk.read_bytes()).hexdigest();Path(str(apk)+'.sha256').write_text(digest+'  '+apk.name+'\n')
    (out/('android-test-build-info.json' if a.debug else 'android-build-info.json')).write_text(json.dumps({'file':apk.name,'bytes':apk.stat().st_size,'sha256':digest,'package':'org.logi2564.ew4online','version':'0.2.0','native_android_activity':True,'external_browser':False,'min_sdk':23,'development_signed':True,'debuggable':a.debug},indent=2)+'\n')

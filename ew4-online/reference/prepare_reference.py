"""Inspect public EW4 1.4.50 resources as data; never execute APK contents."""
from pathlib import Path
import hashlib,io,json,re,urllib.request,urllib.error,zipfile

out=Path('build/ew4-reference');out.mkdir(parents=True,exist_ok=True)
url='https://d.apkpure.com/b/XAPK/com.easytech.ew4?versionCode=27'
report={'package':'com.easytech.ew4','version':'1.4.50','versionCode':27,'source':'APKPure public download','executed':False}
try:
    req=urllib.request.Request(url,headers={'User-Agent':'Mozilla/5.0'})
    data=bytearray()
    with urllib.request.urlopen(req,timeout=90) as response:
        while part:=response.read(1024*1024):
            data.extend(part)
            if len(data)>160*1024*1024:raise ValueError('Package exceeds inspection budget')
    report.update(bytes=len(data),sha256=hashlib.sha256(data).hexdigest())
    entries={};apk_meta=[]
    def inspect(archive,label):
        table=[]
        for entry in archive.infolist():
            name=entry.filename
            if re.fullmatch(r'assets/(?:[^/]+/)?stringtable[^/]*\.ini',name,re.I):
                if entry.file_size>3*1024*1024:raise ValueError('Language table exceeds inspection budget')
                content=archive.read(entry)
                safe=label+'-'+Path(name).name
                entries[safe]=content
                table.append({'file':safe,'bytes':len(content),'sha256':hashlib.sha256(content).hexdigest()})
        return table
    with zipfile.ZipFile(io.BytesIO(data)) as package:
        if 'manifest.json' in package.namelist():
            m=json.loads(package.read('manifest.json'))
            report['manifest']={k:m.get(k) for k in ['package_name','version_code','version_name','name','min_sdk_version','target_sdk_version']}
            if m.get('version_code') is not None and int(m['version_code'])!=27:raise ValueError('Unexpected game version')
        direct=inspect(package,'base')
        for name in package.namelist():
            if name.endswith('.apk'):
                raw=package.read(name)
                with zipfile.ZipFile(io.BytesIO(raw)) as apk:
                    tables=inspect(apk,Path(name).stem)
                    libs=[n for n in apk.namelist() if n.startswith('lib/') and n.endswith('.so')]
                    apk_meta.append({'name':Path(name).name,'bytes':len(raw),'sha256':hashlib.sha256(raw).hexdigest(),'libraries':libs,'language_tables':tables})
    if not entries:raise ValueError('No plain language tables found')
    if sum(len(x) for x in entries.values())>16*1024*1024:raise ValueError('Reference exceeds output budget')
    with zipfile.ZipFile(out/'EW4-1.4.50-language-tables.zip','w',zipfile.ZIP_DEFLATED) as z:
        for name,content in sorted(entries.items()):z.writestr(name,content)
    report.update(result='READY',apks=apk_meta,language_tables=sorted(entries))
except urllib.error.HTTPError as e:report.update(result='SOURCE_UNAVAILABLE',http_status=e.code)
except (OSError,ValueError,zipfile.BadZipFile):report.update(result='REFERENCE_UNAVAILABLE')
(out/'reference-info.json').write_text(json.dumps(report,ensure_ascii=False,indent=2)+'\n')
print(json.dumps(report,ensure_ascii=False,indent=2))

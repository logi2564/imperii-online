"""Extract the reviewed dependency manifest from the original map, without executing it."""
from pathlib import Path
import ctypes,hashlib,json,shutil,sys
from verify_map import Storm
repo,original,work=map(Path,sys.argv[1:4]);library=sys.argv[4];expected=json.loads((repo/'source/ORIGINAL.json').read_text());assert hashlib.sha256(original.read_bytes()).hexdigest()==expected['sha256'],'Different original map'
work.mkdir(exist_ok=True,parents=True);cache=work/'asset-cache';cache.mkdir(exist_ok=True);records=json.loads((repo/'source/original-assets.json').read_text());storm=Storm(library);h=ctypes.c_void_p();assert storm.lib.SFileOpenArchive(str(original.resolve()).encode(),0,0x100,ctypes.byref(h))
try:
 for record in records:
  data=storm.read(h,record['name'].encode());assert hashlib.sha256(data).hexdigest()==record['sha256'],record['name'];(cache/record['cache']).write_bytes(data)
finally:storm.lib.SFileCloseArchive(h)
if original.resolve()!=(work/'original.w3x').resolve():shutil.copy2(original,work/'original.w3x')
(work/'assets-report.json').write_text(json.dumps(dict(originalListedFiles=1371,retainedFiles=len(records),records=records),ensure_ascii=False,indent=2)+'\n');print('Extracted',len(records),'reviewed original map files')

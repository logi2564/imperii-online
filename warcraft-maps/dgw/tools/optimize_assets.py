from pathlib import Path
import sys,json,io,struct,zlib,subprocess,hashlib
from PIL import Image
root=Path(sys.argv[1]);report=json.loads((root/'assets-report.json').read_text());changes=[];out=root/'optimized-assets';out.mkdir(exist_ok=True)
for r in report['records']:
 data=(root/'asset-cache'/r['cache']).read_bytes();new=data
 if r['name'].lower().endswith('.blp')and r['originalCompressedBytes']>400000:
  im=Image.open(io.BytesIO(data));im.load()
  # Preserve alpha textures byte-for-byte. Oversized opaque skins become classic BLP1 palettes with a complete mip chain.
  if im.mode=='RGB':
   size=256 if 'clouds'in r['name'].lower()or 'star'in r['name'].lower()else 512
   base=im.resize((size,size),Image.Resampling.LANCZOS);q=base.quantize(colors=256,method=Image.Quantize.MEDIANCUT);pal=q.getpalette();palette=b''.join(bytes((pal[i+2],pal[i+1],pal[i],255))for i in range(0,768,3));offsets=[];lengths=[];parts=[];pos=156+1024;level=base
   while True:
    p=level.quantize(palette=q,dither=Image.Dither.NONE).tobytes();offsets.append(pos);lengths.append(len(p));parts.append(p);pos+=len(p)
    if level.size==(1,1):break
    level=level.resize((max(1,level.width//2),max(1,level.height//2)),Image.Resampling.BOX)
   new=b'BLP1'+struct.pack('<6I',1,0,size,size,5,1)+struct.pack('<16I',*(offsets+[0]*(16-len(offsets))))+struct.pack('<16I',*(lengths+[0]*(16-len(lengths))))+palette+b''.join(parts)
   check=Image.open(io.BytesIO(new));check.load();assert check.size==(size,size)and check.mode=='RGB'
 if r['name'].lower().endswith('sound01.mp3'):
  src=root/'music-original.mp3';dst=root/'music-optimized.mp3';src.write_bytes(data)
  subprocess.run(['ffmpeg','-hide_banner','-loglevel','error','-y','-i',str(src),'-map_metadata','-1','-ac','2','-ar','22050','-b:a','64k',str(dst)],check=True);new=dst.read_bytes()
 if new!=data:
  (out/r['cache']).write_bytes(new);changes.append(dict(name=r['name'],cache=r['cache'],originalSha256=r['sha256'],sha256=hashlib.sha256(new).hexdigest(),originalBytes=len(data),bytes=len(new),compressedBytes=len(zlib.compress(new,9))))
print('Optimized',len(changes),'files; compressed estimate savings',sum(next(r['originalCompressedBytes']for r in report['records']if r['name']==x['name'])-x['compressedBytes']for x in changes))
print([(x['name'],x['compressedBytes'])for x in changes]);(root/'asset-optimizations.json').write_text(json.dumps(changes,indent=2)+'\n')

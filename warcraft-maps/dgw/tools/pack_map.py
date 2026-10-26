"""Create a classic sector-compressed MPQ from validated retained resources and editor files."""
from pathlib import Path
import sys,json,struct,zlib,hashlib,io
import mpyq
root=Path(sys.argv[1]);repo=Path(sys.argv[2]);mode=sys.argv[3]if len(sys.argv)>3 else'lite';assert mode in ['lite','full'];assets=json.loads((root/'assets-report.json').read_text())['records'];optimizations={r['name']:r for r in json.loads((root/'asset-optimizations.json').read_text())}if mode=='lite'else{};files={};sources={}
for record in assets:
 folder='optimized-assets'if record['name']in optimizations else'asset-cache';data=(root/folder/record['cache']).read_bytes();expected=optimizations.get(record['name'],record)['sha256'];assert hashlib.sha256(data).hexdigest()==expected;files[record['name']]=data;sources[record['name']]='optimized'if record['name']in optimizations else'original'
for p in(root/'editor-files').iterdir():
 if p.name.startswith('war3map'):files[p.name]=p.read_bytes();sources[p.name]='metadata'
imports=[n for n in files if not n.lower().startswith('war3map')or'\\'in n or'/'in n]
files['war3map.imp']=struct.pack('<II',1,len(imports))+b''.join(b'\x0d'+n.encode()+b'\0'for n in imports);sources['war3map.imp']='metadata'
files['(listfile)']=('\r\n'.join(sorted([*files,'(listfile)'],key=str.lower))+'\r\n').encode();sources['(listfile)']='metadata'
a=object.__new__(mpyq.MPQArchive);a.encryption_table=mpyq.MPQArchive.encryption_table

def encrypt(data,key):
 seed=0xEEEEEEEE;out=bytearray()
 for(plain,)in struct.iter_unpack('<I',data):
  seed=(seed+a.encryption_table[0x400+(key&255)])&0xffffffff;out+=struct.pack('<I',plain^((key+seed)&0xffffffff));key=((((~key&0xffffffff)<<21)+0x11111111)|(key>>11))&0xffffffff;seed=(plain+seed+(seed<<5)+3)&0xffffffff
 return out
payload=bytearray();blocks=[];hashes=[[0xffffffff,0xffffffff,0xffff,0xffff,0xffffffff]for _ in range(512)];records=[];dedup={}
for name,data in sorted(files.items(),key=lambda pair:pair[0].lower()):
 digest=hashlib.sha256(data).hexdigest()
 if digest not in dedup:
  offsets=[4*((len(data)+32767)//32768+1)];parts=[]
  for start in range(0,len(data),32768):
   part=data[start:start+32768];c=b'\x02'+zlib.compress(part,9);part=c if len(c)<len(part)else part;parts.append(part);offsets.append(offsets[-1]+len(part))
  encoded=struct.pack('<'+'I'*len(offsets),*offsets)+b''.join(parts);flags=0x80000200
  if len(encoded)>=len(data):encoded=data;flags=0x80000000
  dedup[digest]=len(blocks);blocks.append([32+len(payload),len(encoded),len(data),flags]);payload+=encoded
 idx=dedup[digest];n=name.encode();ha=a._hash(n,'HASH_A');hb=a._hash(n,'HASH_B');slot=a._hash(n,'TABLE_OFFSET')%len(hashes)
 while hashes[slot][4]!=0xffffffff:slot=(slot+1)%len(hashes)
 hashes[slot]=[ha,hb,0,0,idx];records.append(dict(name=name,bytes=len(data),sha256=digest,source=sources[name]))
ho=32+len(payload);bo=ho+len(hashes)*16;size=bo+len(blocks)*16;header=struct.pack('<4sIIHHIIII',b'MPQ\x1a',32,size,0,6,ho,bo,len(hashes),len(blocks));raw=(root/'editor-files/archive-header.bin').read_bytes()+header+payload+encrypt(b''.join(struct.pack('<IIHHI',*h)for h in hashes),a._hash('(hash table)','TABLE'))+encrypt(b''.join(struct.pack('<IIII',*b)for b in blocks),a._hash('(block table)','TABLE'))
assert len(raw)==512+size;assert mode=='full'or len(raw)<8*1024*1024,('Classic multiplayer size limit',len(raw));filename='DGW-Gods-FFA-16Races-'+('Full-'if mode=='full'else'')+'WC3-1.26.w3x';out=repo/'release'/filename;out.write_bytes(raw)
report=dict(file=out.name,bytes=len(raw),sha256=hashlib.sha256(raw).hexdigest(),variant=mode,requiresLargeMapPatch=mode=='full',classic8MiBLimit=len(raw)<8*1024*1024,bytesBelowLimit=max(0,8*1024*1024-len(raw)),originalBytes=(root/'original.w3x').stat().st_size,originalSha256=hashlib.sha256((root/'original.w3x').read_bytes()).hexdigest(),factions=16,newUnitDefinitions=321,newArmyTypes=128,champions=16,gods=16,headquarterTiers=3,shrines=5,playerSlots=12,optimizedFiles=list(optimizations),removedUnusedImports=1371-len(assets),retainedTerrainAndDoodads=True,actualWarcraftGameRun=False,files=records)
(repo/'release'/('verification-full.json'if mode=='full'else'verification.json')).write_text(json.dumps(report,ensure_ascii=False,indent=2)+'\n');
if mode=='lite':(repo/'source/asset-optimizations.json').write_text(json.dumps(list(optimizations.values()),indent=2)+'\n');
(repo/'source/original-assets.json').write_text(json.dumps(assets,ensure_ascii=False,indent=2)+'\n');print('Packed',mode,len(raw),'bytes; needs large-map patch:',report['requiresLargeMapPatch'],'; files',len(files))

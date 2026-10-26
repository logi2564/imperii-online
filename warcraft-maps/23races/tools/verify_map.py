"""Check the actual W3X through StormLib and a strict independent classic W3I reader."""
import ctypes,hashlib,io,json,math,struct,sys
from pathlib import Path
import mpyq

class Storm:
 def __init__(self,path):
  self.lib=ctypes.CDLL(str(Path(path).resolve()));api=self.lib
  api.SFileOpenArchive.argtypes=[ctypes.c_char_p,ctypes.c_uint32,ctypes.c_uint32,ctypes.POINTER(ctypes.c_void_p)];api.SFileOpenArchive.restype=ctypes.c_bool
  api.SFileOpenFileEx.argtypes=[ctypes.c_void_p,ctypes.c_char_p,ctypes.c_uint32,ctypes.POINTER(ctypes.c_void_p)];api.SFileOpenFileEx.restype=ctypes.c_bool
  api.SFileGetFileSize.argtypes=[ctypes.c_void_p,ctypes.c_void_p];api.SFileGetFileSize.restype=ctypes.c_uint32
  api.SFileReadFile.argtypes=[ctypes.c_void_p,ctypes.c_void_p,ctypes.c_uint32,ctypes.POINTER(ctypes.c_uint32),ctypes.c_void_p];api.SFileReadFile.restype=ctypes.c_bool
  api.SFileCloseFile.argtypes=[ctypes.c_void_p];api.SFileCloseArchive.argtypes=[ctypes.c_void_p]
 def read(self,archive,name):
  f=ctypes.c_void_p();assert self.lib.SFileOpenFileEx(archive,name,0,ctypes.byref(f)),name
  try:
   n=self.lib.SFileGetFileSize(f,None);buf=ctypes.create_string_buffer(n);read=ctypes.c_uint32();assert self.lib.SFileReadFile(f,buf,n,ctypes.byref(read),None);assert read.value==n;return buf.raw
  finally:self.lib.SFileCloseFile(f)

class Reader:
 def __init__(self,b):self.b=b;self.p=0
 def unpack(self,fmt):
  n=struct.calcsize('<'+fmt);assert self.p+n<=len(self.b),'Truncated level info';v=struct.unpack_from('<'+fmt,self.b,self.p);self.p+=n;return v[0]if len(v)==1 else v
 def z(self):
  end=self.b.index(0,self.p);v=self.b[self.p:end];self.p=end+1;v.decode('utf-8');return v

def strict_info(b):
 r=Reader(b);assert r.unpack('i')==25;r.unpack('i');assert r.unpack('i')==6052
 for _ in range(4):r.z()
 assert all(math.isfinite(x)for x in r.unpack('8f'))
 left,right,bottom,top=r.unpack('4i');w,h=r.unpack('2i');assert w+left+right==480 and h+bottom+top==480
 r.unpack('I');r.unpack('B');r.unpack('i')
 for _ in range(4):r.z()
 r.unpack('i')
 for _ in range(4):r.z()
 r.unpack('i');assert all(math.isfinite(x)for x in r.unpack('3f'));r.unpack('4B');r.unpack('I');r.z();r.unpack('B');r.unpack('4B')
 players=r.unpack('i');assert players==12;ids=[]
 for _ in range(players):
  pid,controller,race,flags=r.unpack('4i');ids.append(pid);assert 0<=controller<=4 and 0<=race<=4 and flags&~3==0,(pid,controller,race,flags,r.p)
  r.z();assert all(math.isfinite(x)for x in r.unpack('2f'));r.unpack('2I')
 assert sorted(ids)==list(range(12))
 forces=r.unpack('i');assert 1<=forces<=12
 for _ in range(forces):r.unpack('2I');r.z()
 # The original optimizer left a single FF byte here. Classic editor data requires all four tables.
 upgrades=r.unpack('i');assert upgrades==0
 tech=r.unpack('i');assert tech==0
 units=r.unpack('i');assert units==0
 items=r.unpack('i');assert items==0
 assert r.p==len(b),('Unparsed/trailing W3I data',r.p,len(b))
 return dict(version=25,players=players,forces=forces,terrain=(480,480),completeTableCounts=True)

def main(library,folder):
 root=Path(folder);report=json.loads((root/'release/verification.json').read_text());path=root/'release'/report['file'];raw=path.read_bytes()
 assert raw[:4]==b'HM3W'and raw[512:516]==b'MPQ\x1a'
 assert len(raw)<8*1024*1024 and hashlib.sha256(raw).hexdigest()==report['sha256']
 arc=mpyq.MPQArchive(io.BytesIO(raw[512:]),listfile=False);assert arc.header['header_size']==32 and arc.header['format_version']==0 and arc.header['archive_size']==len(raw)-512
 assert all(not b.flags&0x1030000 for b in arc.block_table),'Encryption/SINGLE_UNIT remained'
 entries={f'{e.hash_a|(e.hash_b<<32):016x}':e for e in arc.hash_table if e.block_table_index<0xfffffffe}
 storm=Storm(library);handle=ctypes.c_void_p();assert storm.lib.SFileOpenArchive(str(path.resolve()).encode(),0,0x100,ctypes.byref(handle))
 try:
  expected=json.loads((root/'original-assets.json').read_text());preserved=0
  changed={f'{arc._hash(n,"HASH_A")|(arc._hash(n,"HASH_B")<<32):016x}'for n in ['war3map.w3i','(listfile)']}
  for original in expected:
   if original['hash']in changed:continue
   entry=entries[original['hash']];content=storm.read(handle,f'File{entry.block_table_index:08d}.xxx'.encode());assert len(content)==original['size']and hashlib.sha256(content).hexdigest()==original['sha256'];preserved+=1
  assert preserved==589
  byhash={x['hash']:x for x in expected}
  aliases=json.loads((root/'resource-aliases.json').read_text())
  for h,name in aliases.items():assert hashlib.sha256(storm.read(handle,name.encode())).hexdigest()==byhash[h]['sha256']
  assert storm.read(handle,b'war3map.j')==storm.read(handle,b'Scripts\\war3map.j')
  info=strict_info(storm.read(handle,b'war3map.w3i'))
  for name,sig,version in [(b'war3map.wtg',b'WTG!',7),(b'war3mapUnits.doo',b'W3do',8)]:
   b=storm.read(handle,name);assert b[:4]==sig and struct.unpack_from('<I',b,4)[0]==version
  for name,version in [(b'war3map.wct',1),(b'war3map.w3r',5),(b'war3map.w3s',1),(b'war3map.imp',1)]:assert struct.unpack_from('<I',storm.read(handle,name))[0]==version
 finally:storm.lib.SFileCloseArchive(handle)
 print('PASS: native StormLib reads 589 unchanged original entries and all 30 aliases; original gameplay script unchanged; classic MPQ <8 MiB; strict W3I validates 12 players and complete level information')
if __name__=='__main__':main(*sys.argv[1:])

"""Read the complete HM3W map through game-aware native StormLib.
Generic MPQ parsers accept SINGLE_UNIT; Warcraft III explicitly masks it out.
The negative fixture makes sure this exact incompatibility remains detectable.
"""
import ctypes,hashlib,io,json,struct,sys,tempfile,zlib
from pathlib import Path
import mpyq
from classic_mpq_pack import encrypt_table

class Storm:
 def __init__(self,library):
  self.lib=ctypes.CDLL(str(Path(library).resolve()))
  api=self.lib
  api.SFileOpenArchive.argtypes=[ctypes.c_char_p,ctypes.c_uint32,ctypes.c_uint32,ctypes.POINTER(ctypes.c_void_p)];api.SFileOpenArchive.restype=ctypes.c_bool
  api.SFileOpenFileEx.argtypes=[ctypes.c_void_p,ctypes.c_char_p,ctypes.c_uint32,ctypes.POINTER(ctypes.c_void_p)];api.SFileOpenFileEx.restype=ctypes.c_bool
  api.SFileGetFileSize.argtypes=[ctypes.c_void_p,ctypes.c_void_p];api.SFileGetFileSize.restype=ctypes.c_uint32
  api.SFileReadFile.argtypes=[ctypes.c_void_p,ctypes.c_void_p,ctypes.c_uint32,ctypes.POINTER(ctypes.c_uint32),ctypes.c_void_p];api.SFileReadFile.restype=ctypes.c_bool
  api.SFileCloseFile.argtypes=[ctypes.c_void_p];api.SFileCloseArchive.argtypes=[ctypes.c_void_p]
  api.GetLastError.restype=ctypes.c_uint32
 def open(self,path):
  handle=ctypes.c_void_p()
  if not self.lib.SFileOpenArchive(str(Path(path).resolve()).encode(),0,0x100,ctypes.byref(handle)):raise ValueError('Cannot open map: '+str(self.lib.GetLastError()))
  return handle
 def read(self,archive,name):
  handle=ctypes.c_void_p()
  if not self.lib.SFileOpenFileEx(archive,name,0,ctypes.byref(handle)):raise ValueError('Cannot open file '+repr(name)+': '+str(self.lib.GetLastError()))
  try:
   size=self.lib.SFileGetFileSize(handle,None);buffer=ctypes.create_string_buffer(size);read=ctypes.c_uint32()
   if not self.lib.SFileReadFile(handle,buffer,size,ctypes.byref(read),None):raise ValueError('Cannot read file '+repr(name)+': '+str(self.lib.GetLastError()))
   assert read.value==size
   return buffer.raw
  finally:self.lib.SFileCloseFile(handle)

def regression_fixture(storm,prefix):
 name='war3map.w3i';data=struct.pack('<I',25)+b'fixture data'*200
 compressed=b'\x02'+zlib.compress(data,9)
 # Use mpyq's public algorithm tables for the standard MPQ hashes and cipher.
 seed_archive=object.__new__(mpyq.MPQArchive);seed_archive.encryption_table=mpyq.MPQArchive.encryption_table
 slots=[struct.pack('<IIII',0xffffffff,0xffffffff,0xffffffff,0xffffffff) for _ in range(16)]
 slot=seed_archive._hash(name,'TABLE_OFFSET')%16
 slots[slot]=struct.pack('<IIHHI',seed_archive._hash(name,'HASH_A'),seed_archive._hash(name,'HASH_B'),0,0,0)
 hash_offset=32+len(compressed);block_offset=hash_offset+256;size=block_offset+16
 header=struct.pack('<4sIIHHIIII',b'MPQ\x1a',32,size,0,3,hash_offset,block_offset,16,1)
 hashes=encrypt_table(b''.join(slots),seed_archive._hash('(hash table)','TABLE'),seed_archive.encryption_table)
 blocks=encrypt_table(struct.pack('<IIII',32,len(compressed),len(data),0x81000200),seed_archive._hash('(block table)','TABLE'),seed_archive.encryption_table)
 raw=prefix+header+compressed+hashes+blocks
 # This used to pass our generic reader, while a Warcraft-aware reader rejects it.
 generic=mpyq.MPQArchive(io.BytesIO(raw[512:]),listfile=False);assert generic.read_file(name)==data
 with tempfile.TemporaryDirectory() as folder:
  path=Path(folder)/'unsupported-single-unit.w3x';path.write_bytes(raw);archive=storm.open(path)
  try:
   try:storm.read(archive,name.encode())
   except ValueError as error:
    assert '1004' in str(error),str(error)
   else:raise AssertionError('Regression fixture should fail Warcraft III file decoding')
  finally:storm.lib.SFileCloseArchive(archive)
 print('PASS: regression fixture reproduces Warcraft III error 1004 for SINGLE_UNIT')

def verify(library,root):
 root=Path(root);report=json.loads((root/'release/verification.json').read_text());path=root/'release'/report['file'];raw=path.read_bytes()
 storm=Storm(library);regression_fixture(storm,raw[:512])
 expected={(int(e['hash'],16),e['locale']):e for e in json.loads((root/'decoded-assets.json').read_text())}
 generic=mpyq.MPQArchive(io.BytesIO(raw[512:]),listfile=False);archive=storm.open(path)
 try:
  for name in [b'war3map.w3i',b'war3map.w3e',b'war3map.wtg',b'war3map.wct',b'war3mapUnits.doo',b'war3map.w3r',b'war3map.w3s',b'war3map.imp',b'war3map.j']:
   content=storm.read(archive,name);assert content==generic.read_file(name.decode())
  count=0
  for entry in generic.hash_table:
   if entry.block_table_index>=0xfffffffe:continue
   content=storm.read(archive,f'File{entry.block_table_index:08d}.xxx'.encode())
   item=expected.pop((entry.hash_a|(entry.hash_b<<32),entry.locale|(entry.platform<<16)))
   assert len(content)==item['size'] and hashlib.sha256(content).hexdigest()==item['sha256']
   count+=1
  assert not expected and count==report['entries']
 finally:storm.lib.SFileCloseArchive(archive)
 print(f'PASS: native StormLib read {count} file hashes from the complete Warcraft III map')
if __name__=='__main__':verify(*sys.argv[1:])

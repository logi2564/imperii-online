"""Verify the actual classic map and dependency closure through native StormLib."""
import ctypes,hashlib,io,json,struct,sys
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


def main(library,folder,reportfile="verification.json"):
 root=Path(folder);report=json.loads((root/'release'/reportfile).read_text());path=root/'release'/report['file'];data=path.read_bytes();assert hashlib.sha256(data).hexdigest()==report['sha256'];assert (report.get('requiresLargeMapPatch')or len(data)<8*1024*1024)and data[:4]==b'HM3W'and data[512:516]==b'MPQ\x1a'
 a=mpyq.MPQArchive(io.BytesIO(data[512:]),listfile=False);assert a.header['header_size']==32 and a.header['format_version']==0 and a.header['archive_size']==len(data)-512;assert all(not b.flags&0x1030000 for b in a.block_table)
 canon=lambda s:s.replace('/','\\').lower();original={canon(n)for n in(root/'source/original-all-filenames.txt').read_text().splitlines()};native=Storm(library);h=ctypes.c_void_p();assert native.lib.SFileOpenArchive(str(path.resolve()).encode(),0,0x100,ctypes.byref(h));files={}
 try:
  for r in report['files']:
   b=native.read(h,r['name'].encode());assert len(b)==r['bytes']and hashlib.sha256(b).hexdigest()==r['sha256'];files[canon(r['name'])]=b
  baseline={canon(x['name']):x for x in json.loads((root/'source/original-assets.json').read_text())}
  for r in report['files']:
   if r['source']=='original':assert r['sha256']==baseline[canon(r['name'])]['sha256']
  for n,b in files.items():
   if n.endswith(('.txt','.wts')):
    for line in b.decode('utf-8',errors='replace').splitlines():
     if '='in line:
      for value in line.split('=',1)[1].strip().strip('"').split(','):
       key=canon(value)
       if key in original:assert key in files,('Missing UI/text resource',n,key)
   if b[:4]!=b'MDLX':continue
   pos=4
   while pos+8<=len(b):
    tag=b[pos:pos+4];size=struct.unpack_from('<I',b,pos+4)[0];chunk=b[pos+8:pos+8+size];pos+=8+size
    if tag==b'TEXS':
     assert len(chunk)%268==0
     for i in range(0,len(chunk),268):
      texture=canon(chunk[i+4:i+264].split(b'\0')[0].decode('utf-8',errors='replace'))
      if texture in original:assert texture in files,('Missing model texture',n,texture)
  for name,version in [('war3map.w3i',25),('war3map.wct',1),('war3map.w3u',2),('war3map.w3a',2),('war3map.w3q',2),('war3map.imp',1)]:assert struct.unpack_from('<I',files[name])[0]==version
  assert files['war3map.wtg'][:8]==b'WTG!\x07\x00\x00\x00'
  assert files['war3map.w3e']==(native.read(h,b'war3map.w3e'))and hashlib.sha256(files['war3map.w3e']).hexdigest()==baseline['war3map.w3e']['sha256']
  for n in ['war3map.doo','war3map.wpm']:assert hashlib.sha256(files[n]).hexdigest()==baseline[n]['sha256']
  catalog=json.loads((root/'source/catalog.json').read_text());objects={o['id']:{m['id']:m['value']for m in o['fields']}for o in catalog['objects']};assert len(objects)==321 and len(catalog['factions'])==16
  for f in catalog['factions']:
   worker=objects[f['worker']];reachable=set(worker['ubui'].split(','));assert f['hq'][0]in reachable
   for i,hq in enumerate(f['hq']):
    obj=objects[hq];assert obj['utra']==f['worker'];assert obj['ufma']>=30;assert obj['uupt']==(f['hq'][i+1]if i<2 else'')
    if i<2:assert all(id in obj['udep'].split(',')for id in f['hq'][i+1:])
    reachable.add(hq)
   trained=set()
   for id in f['buildings']:
    assert id in reachable;trained.update(filter(None,objects[id]['utra'].split(',')))
   assert all(id in trained for id in f['army'])and f['champion']in trained
   assert len(f['army'])==8 and objects[f['avatar']]['uabi'].endswith(f['spell'])
   for u in f['units']:
    obj=objects[u['id']];assert obj['ugol']==u['gold']and obj['ulum']==u['wood']and obj['ufoo']==u['food'];assert obj['ureq']==(f['hq'][u['tier']-1]if u['tier']>1 else'')
  layout=json.loads((root/'source/layout.json').read_text());assert len(layout['starts'])==12 and layout['minimumStartDistance']>=3600 and all(s['buildableFraction']>=.92 for s in layout['starts']);assert len(layout['shrines'])==5
 finally:native.lib.SFileCloseArchive(h)
 print(f'PASS: native StormLib reads all {len(files)} verified files; classic MPQ is {len(data):,} bytes (variant: {report.get('variant','lite')}), model texture dependencies present, original terrain/doodads/pathing preserved, 16 complete reachable tech trees and 12 separated start clearings.')
if __name__=='__main__':main(*sys.argv[1:])

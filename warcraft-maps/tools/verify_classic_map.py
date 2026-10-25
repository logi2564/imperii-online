"""Validate the exact downloadable MPQ against a decoded asset manifest."""
import hashlib,io,json,struct,sys,zlib
from pathlib import Path
import mpyq
root=Path(sys.argv[1])
report=json.loads((root/'release/verification.json').read_text())
path=root/'release'/report['file']
raw=path.read_bytes()
assert raw[:4]==b'HM3W' and raw[512:516]==b'MPQ\x1a'
assert 0<len(raw)<8*1024*1024
header=struct.unpack_from('<4sIIHHIIII',raw,512)
assert header[1]==32 and header[2]==len(raw)-512 and header[3]==0
assert hashlib.sha256(raw).hexdigest()==report['sha256']
archive=mpyq.MPQArchive(io.BytesIO(raw[512:]))
expected={(int(e['hash'],16),e['locale']):e for e in json.loads((root/'decoded-assets.json').read_text())}
count=0
for entry in archive.hash_table:
 if entry.block_table_index>=0xfffffffe:continue
 key=(entry.hash_a|(entry.hash_b<<32),entry.locale|(entry.platform<<16))
 expected_file=expected.pop(key)
 block=archive.block_table[entry.block_table_index]
 assert block.flags in [0x80000000,0x80000200], "SINGLE_UNIT is not supported in Warcraft III maps"
 encoded=raw[512+block.offset:512+block.offset+block.archived_size]
 if block.flags&0x200:
  sector_size=512<<header[4];n=(block.size+sector_size-1)//sector_size
  offsets=struct.unpack_from('<'+'I'*(n+1),encoded)
  assert offsets[0]==4*(n+1) and offsets[-1]==len(encoded)
  chunks=[]
  for i in range(n):
   chunk=encoded[offsets[i]:offsets[i+1]];wanted=min(sector_size,block.size-i*sector_size)
   assert offsets[i]<=offsets[i+1] and len(chunk)<=wanted
   if len(chunk)<wanted:
    assert chunk[0]==2;chunk=zlib.decompress(chunk[1:])
   assert len(chunk)==wanted;chunks.append(chunk)
  content=b''.join(chunks)
 else:content=encoded
 assert len(content)==block.size==expected_file['size']
 assert hashlib.sha256(content).hexdigest()==expected_file['sha256']
 count+=1
assert not expected and count==report['entries']
assert hashlib.sha256(archive.read_file('war3map.j')).hexdigest()==report['originalScriptSha256']
for name,signature,version in [('war3map.wtg',b'WTG!',7),('war3mapUnits.doo',b'W3do',8)]:
 data=archive.read_file(name);assert data[:4]==signature and struct.unpack_from('<I',data,4)[0]==version
assert struct.unpack_from('<I',archive.read_file('war3map.w3i'))[0]==25
assert struct.unpack_from('<I',archive.read_file('war3map.wct'))[0]==1
assert archive.read_file('war3map.w3r') and archive.read_file('war3map.w3s') and archive.read_file('war3map.imp')
print(f'PASS: {count} decoded file hashes, valid classic MPQ v0, intact gameplay script, old editor formats, {len(raw)} bytes < 8 MiB')

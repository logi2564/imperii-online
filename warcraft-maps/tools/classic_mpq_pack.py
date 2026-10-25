"""Repack a decoded MPQ snapshot with classic v0 headers, DEFLATE and shared blocks.
Hash slots, filename hashes and locales are retained, including unnamed assets.
No terrain, script, object or media content is changed.
"""
from pathlib import Path
import sys,io,json,struct,zlib,hashlib
sys.path.insert(0,'/workspace/.tools/war3-python')
import mpyq

def encrypt_table(data,key,crypt_table):
 seed=0xEEEEEEEE;result=bytearray()
 for (plain,) in struct.iter_unpack('<I',data):
  seed=(seed+crypt_table[0x400+(key&255)])&0xffffffff
  result+=struct.pack('<I',plain^((key+seed)&0xffffffff))
  key=((((~key&0xffffffff)<<21)+0x11111111)|(key>>11))&0xffffffff
  seed=(plain+seed+(seed<<5)+3)&0xffffffff
 return result

def pack(source,dump,dest):
 original=Path(source).read_bytes();arc=mpyq.MPQArchive(io.BytesIO(original[512:]),listfile=False)
 entries=json.loads((Path(dump)/'entries.json').read_text());by_key={(int(e['hash'],16),e['locale']):e for e in entries}
 blocks=[];payload=bytearray();by_content={};hashes=[];stored=0
 for h in arc.hash_table:
  if h.block_table_index>=0xfffffffe:
   hashes.append(struct.pack('<IIHHI',*h));continue
  key=(h.hash_a|(h.hash_b<<32),h.locale|(h.platform<<16));e=by_key[key]
  content=(Path(dump)/e['file']).read_bytes();digest=hashlib.sha256(content).hexdigest()
  assert digest==e['sha256']
  if digest not in by_content:
   # Single-unit DEFLATE has existed since MPQ format v0; no newer compression codec is used.
   compressed=b'\x02'+zlib.compress(content,9)
   if len(compressed)<len(content):encoded=compressed;flags=0x81000200
   else:encoded=content;flags=0x81000000
   index=len(blocks);by_content[digest]=index;blocks.append((32+len(payload),len(encoded),len(content),flags));payload+=encoded
  index=by_content[digest]
  hashes.append(struct.pack('<IIHHI',h.hash_a,h.hash_b,h.locale,h.platform,index));stored+=1
 hash_offset=32+len(payload);block_offset=hash_offset+len(hashes)*16
 size=block_offset+len(blocks)*16
 header=struct.pack('<4sIIHHIIII',b'MPQ\x1a',32,size,0,3,hash_offset,block_offset,len(hashes),len(blocks))
 hash_data=encrypt_table(b''.join(hashes),arc._hash('(hash table)','TABLE'),arc.encryption_table)
 block_data=encrypt_table(b''.join(struct.pack('<IIII',*b) for b in blocks),arc._hash('(block table)','TABLE'),arc.encryption_table)
 result=original[:512]+header+payload+hash_data+block_data
 assert len(result)==size+512
 Path(dest).write_bytes(result)
 # Independent mpyq reader: every filename hash must still return exactly the input bytes.
 check=mpyq.MPQArchive(io.BytesIO(result[512:]),listfile=False)
 for h in check.hash_table:
  if h.block_table_index>=0xfffffffe:continue
  e=by_key[(h.hash_a|(h.hash_b<<32),h.locale|(h.platform<<16))];b=check.block_table[h.block_table_index]
  raw=result[512+b.offset:512+b.offset+b.archived_size]
  decoded=zlib.decompress(raw[1:]) if b.flags&0x200 else raw
  assert len(decoded)==b.size and hashlib.sha256(decoded).hexdigest()==e['sha256']
 report=dict(file=Path(dest).name,bytes=len(result),sha256=hashlib.sha256(result).hexdigest(),entries=stored,uniqueBlocks=len(blocks),deduplicatedEntries=stored-len(blocks),mpqVersion=0,headerBytes=32,allDecodedHashesMatch=True,underClassic8MiB=len(result)<8*1024*1024)
 Path(str(dest)+'.json').write_text(json.dumps(report,indent=2)+'\n');print(json.dumps(report,indent=2))
if __name__=='__main__':pack(*sys.argv[1:])

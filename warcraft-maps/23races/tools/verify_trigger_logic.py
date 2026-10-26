"""Verify all original trigger functions and initialization order in the reopened editor script.

Equality allows only comments/whitespace, equivalent numeric encodings, and the
consistent R23_/udg_R23_ symbol prefixes. It does not ignore expressions or actions.
"""
from pathlib import Path
from decimal import Decimal
import re,json,sys
FUNCTION=re.compile(r'^function (\w+) takes.*?^endfunction',re.M|re.S)
TOKEN=re.compile(r'"(?:\\.|[^"\\])*"|\x27[^\x27\r\n]*\x27|//[^\n]*|\$[0-9A-Fa-f]+|0x[0-9A-Fa-f]+|(?:\d+\.\d*|\.\d+|\d+)|[A-Za-z_][A-Za-z_0-9]*|\S')
def functions(s):return {m[1]:m[0]for m in FUNCTION.finditer(s)}
def canonical(s,original):
 result=[]
 for m in TOKEN.finditer(s):
  t=m[0]
  if t.startswith('//'):continue
  if t.startswith('udg_R23_'):t=t[8:]
  elif t.startswith('R23_')and t[4:]in original:t=t[4:]
  if t.startswith('$'):t=str(int(t[1:],16))
  elif t.startswith('0x'):t=str(int(t,16))
  elif t.startswith("'"):t=str(int.from_bytes(t[1:-1].encode('latin1'),'big',signed=True))
  if re.fullmatch(r'-?(?:\d+\.\d*|\.\d+|\d+)',t):t=format(Decimal(t).normalize(),'f')
  result.append(t)
 return result

def main(folder,generated):
 root=Path(folder);index=json.loads((root/'source/trigger-index.json').read_text());a=functions((root/'source/original-gameplay.j').read_text());b=functions(Path(generated).read_text())
 order=re.findall(r'^call InitTrig_(\w+)\(\)',a['InitCustomTriggers'],re.M)
 assert len(order)==len(set(order))==262
 assert order==[e['name']for e in index['entries']]
 all_names=list(a);start=next(i for i,n in enumerate(all_names)if n.startswith('Trig_'));checked=0
 for entry in index['entries']:
  name=entry['name'];end=all_names.index('InitTrig_'+name);group=all_names[start:end+1];start=end+1
  assert len(group)==entry['functions'],name
  for fn in group:
   recovered=fn if entry['kind']=='GUI' else 'R23_'+fn
   assert recovered in b,('Missing function',name,recovered)
   aa,bb=canonical(a[fn],a),canonical(b[recovered],a)
   assert aa==bb,('Changed original function',name,fn)
   checked+=1
  if entry['kind']=='JASS':
   expected=f'function InitTrig_{name} takes nothing returns nothing\ncall R23_InitTrig_{name}()\nset gg_trg_{name}=udg_R23_gg_trg_{name}\nendfunction'
   assert canonical(b['InitTrig_'+name],a)==canonical(expected,a),('Changed wrapper',name)
 calls=re.findall(r'\bcall\s+(InitTrig_\w+)\s*\(',b['InitCustomTriggers'])
 assert calls==['InitTrig_R23_Begin',*['InitTrig_'+n for n in order],'InitTrig_R23_End','InitTrig_EditorReferences'],('Initialization order changed',calls)
 # The optimized original main inlined all initializer bodies once, contiguously.
 body='\n'.join(a['main'].splitlines()[1:-1])
 for name in order:
  inline='\n'.join(a['InitTrig_'+name].splitlines()[1:-1]);assert body.count(inline)==1,name
  body=body.replace(inline,'call InitTrig_'+name+'()')
 lines=body.splitlines();first=lines.index('call InitTrig_'+order[0]+'()');last=lines.index('call InitTrig_'+order[-1]+'()')
 assert [s for s in lines[first:last+1]if s.strip()]==['call InitTrig_'+n+'()'for n in order]
 assert 'R23_main'not in b and 'R23_InitCustomTriggers'not in b
 assert 'RunInitializationTriggers'not in b, 'Unexpected extra map-init executions'
 finish='function R23_FinishGame takes nothing returns nothing\n'+'\n'.join(lines[last+1:])+'\nendfunction'
 assert canonical(finish,a)==canonical(b['R23_FinishGame'],a),'Changed initialization event'
 assert Path(generated).read_text().count('call R23_FinishGame()')==1
 print(f'PASS: all {checked} functions across 262 original triggers match; 69 GUI + 193 full JASS entries; original initialization order and final event retained exactly once')
if __name__=='__main__':main(*sys.argv[1:])

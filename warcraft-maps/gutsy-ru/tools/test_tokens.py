"""Localization must not turn a number, hotkey or raw order name into prose."""
import json,sys
from pathlib import Path
from translate_cache import prepare,restore
from build import structural,split_literal
from catalog import encode_jass,decode_jass,STR,prose
cases=['Hello |cffffcc00world|r, 100% damage (Q).','[Targeted Skill]|n300+Agility*3.5',"Please write'Yes I will turn it off'.",'Normal','|cffffcc00C|renarius','|r, level ','50% chance to deal 200 damage.','Blows 75 damage, then 7 per second.','Research <A001,DataA1> and level %d.']
assert not prose('WESTRING_DOOD_LCc0')
cases.append("Spongebob-'olofmoleman'\nSaber-SCV Modeling Cafe\nSasuke-UUU9 public model")
for source in cases:
 prepared,tokens=prepare(source,['Yes I will turn it off','level ']);restored=restore(prepared,tokens)
 assert structural(source)==structural(restored),(source,restored,structural(source),structural(restored))
 if len(tokens)>1:
  try:restore('ZXQ1QXZZXQ0QXZ',tokens)
  except ValueError:pass
  else:raise AssertionError('Reordered engine tokens accepted')
long='Жизнь: 200. |cffffcc00'+('Длинное описание. '*200)+'|r'
encoded=split_literal(long);parts=list(STR.finditer(encoded))
assert len(parts)>1 and ''.join(decode_jass(x[0]) for x in parts)==long
assert all(len(x[0].encode())<=1000 for x in parts)
assert structural('Power 2.5|n100 damage')[1]==['2.5','100']
assert structural('Level 1|r - 200 hit points, 11 - 12 damage')==structural('Уровень 1|r — 200 здоровья, 11–12 урона')
assert structural('Armor -30, multiplier *-1.5')[1]==['-30','-1.5']
assert structural('Damage 200')!=structural('Урон 201')
if len(sys.argv)>1:
 data=json.loads(Path(sys.argv[1]).read_text())
 for text in data['phrases']:
  prepared,tokens=prepare(text,data['commands']);restored=restore(prepared,tokens)
  assert structural(text)==structural(restored),(repr(text),repr(restored))
print('PASS protected markup, numbers, percent signs, hotkeys, command fragments and long UTF-8 JASS literal splitting; token corruption rejected.')

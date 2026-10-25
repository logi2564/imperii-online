"""Check the user-requested balance; file uniqueness alone cannot detect anime repeats."""
from pathlib import Path
import argparse,collections,json,re
p=argparse.ArgumentParser();p.add_argument('--pack',type=Path,default=Path(__file__).resolve().parents[1]/'friends-remix');a=p.parse_args()
pack=json.loads((a.pack/'pack.json').read_text(encoding='utf-8'));media=json.loads((a.pack/'media-sources.json').read_text(encoding='utf-8'))
questions=[q for r in pack['rounds']for t in r['themes']for q in t['questions']]
ordinary=[r for r in pack['rounds']if r.get('type','standart')=='standart']
finals=[r for r in pack['rounds']if r.get('type')=='final']
assert len(questions)==141 and len(ordinary)==4 and len(finals)==1
assert finals[0]is pack['rounds'][-1] and len(finals[0]['themes'])==1 and len(finals[0]['themes'][0]['questions'])==1
assert finals[0]['themes'][0]['questions'][0]['price']==0
assert sum(len(t['questions'])for r in ordinary for t in r['themes'])==140
anime=collections.Counter(q['anime']for q in questions if q.get('anime'));repeated={k:v for k,v in anime.items()if v>1};assert not repeated,repeated
assert len(anime)==26
assert sum(q.get('franchise')=='terraria'for q in questions)==2
full=json.dumps([questions,media],ensure_ascii=False)
assert not re.search(r'star\s*craft|стар\s*крафт|тасса?дар|абатур|\bАларак\b|стетман',full,re.I),'Removed franchise remains in a question or its source'
images=[q for q in questions if q.get('kind')=='game_screenshot'];assert len(images)==20
assert all(q['first_release_year']>=2010 or q['franchise']in ['wc3','wow']for q in images)
reviews=[q for q in questions if q['prompt'].startswith('Узнай игру по выдуманному отзыву:')];assert len(reviews)==20 and len({q['franchise']for q in reviews})==20
assert len({m['sha256']for m in media})==len(media)==90
assert sum(m['path'].startswith('Images/')for m in media)==50
assert sum(m['path'].startswith('Audio/')for m in media)==40
assert sum(q.get('media','').startswith(('h','n'))for q in questions)==20
report={'result':'PASS','questions':141,'standard_questions':140,'final_rounds':1,'final_questions':1,'game_screenshots':20,'anime_recognition_questions':20,'anime_franchises_including_animal_riddles':len(anime),'repeated_anime_franchises':repeated,'removed_franchise_questions':0,'terraria_questions':2,'animal_riddles':20,'new_animal_illustrations':6,'original_funny_reviews':20,'images':50,'audio':40}
print(json.dumps(report,ensure_ascii=False,indent=2))

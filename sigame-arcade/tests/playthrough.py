"""Win each game through its input handlers; no state or victory flags are mutated."""
import os,json,math,heapq,itertools,collections,time
from pathlib import Path
from playwright.sync_api import sync_playwright
ROOT=Path(__file__).resolve().parents[2];OUT=ROOT/'sigame-arcade'
DRIVER=r'''window.__ARCADE_TEST_DRIVER__=true;window.D={
step(t){Arcade.testStep(t)},get st(){return Arcade.state},get t(){return Arcade.elapsed},
point(type,x,y){const c=document.querySelector('#game-canvas'),r=c.getBoundingClientRect();c.dispatchEvent(new PointerEvent(type,{clientX:r.left+x*r.width/480,clientY:r.top+y*r.height/480,pointerId:31,pointerType:'mouse',bubbles:true}))},
tap(x,y){this.point('pointerdown',x,y);this.point('pointerup',x,y);Arcade.draw()},
move(x,y){this.point('pointermove',x,y)},hold(x,y){this.point('pointerdown',x,y)},up(x,y){this.point('pointerup',x,y)},
key(k,v=true){window.dispatchEvent(new KeyboardEvent(v?'keydown':'keyup',{code:k,bubbles:true}));Arcade.draw()},
press(k){this.key(k,true);this.key(k,false)},
keys(list){for(const k of ['ArrowUp','ArrowDown','ArrowLeft','ArrowRight','Space'])this.key(k,list.includes(k))}
};'''

def state():return page.evaluate('Arcade.state')
def mode():return page.evaluate('Arcade.mode')
def step(t):page.evaluate('(t)=>D.step(t)',t)
def tap(x,y):page.evaluate('([x,y])=>D.tap(x,y)',[x,y])
def press(k):page.evaluate('(k)=>D.press(k)',k)
def drag(a,b):
 page.evaluate('([a,b])=>{D.hold(...a);D.move(...b);D.up(...b);Arcade.draw()}',[a,b])
def bot(code,seconds=150):
 return page.evaluate('([code,seconds])=>{const fn=new Function("s","t",code);for(let i=0;i<seconds*25&&Arcade.mode==="playing";i++){fn(D.st,D.t);D.step(.04)}return{mode:Arcade.mode,state:Arcade.state,elapsed:Arcade.elapsed}}',[code,seconds])
def gridtap(i,cols,cell,ox,oy):tap(ox+(i%cols+.5)*cell,oy+(i//cols+.5)*cell)
def keypath(path):
 for k in path:press(k);step(.01)
def astar8(a):
 a=tuple(a);goal=(1,2,3,4,5,6,7,8,0)
 def h(a):return sum(abs(i%3-(v-1)%3)+abs(i//3-(v-1)//3) for i,v in enumerate(a) if v)
 q=[(h(a),0,a,[])];seen={a:0}
 while q:
  _,cost,b,path=heapq.heappop(q)
  if b==goal:return path
  z=b.index(0)
  for j in [z-3,z+3,z-1 if z%3 else -1,z+1 if z%3<2 else -1]:
   if not 0<=j<9:continue
   c=list(b);c[z],c[j]=c[j],c[z];c=tuple(c)
   if seen.get(c,999)>cost+1:seen[c]=cost+1;heapq.heappush(q,(cost+1+h(c),cost+1,c,path+[j]))
 raise AssertionError('Unsolvable sliding puzzle')

def solve(g):
 id=g['id'];m=g['mechanic']
 if m=='orbit':
  return bot('''let p=s.items.find(p=>!p.got)||{x:240,y:400},dx=p.x-s.x,dy=p.y-s.y,n=Math.hypot(dx,dy)||1;dx/=n;dy/=n;for(const r of s.rocks){let a=s.x-r.x,b=s.y-r.y,d=Math.hypot(a,b);if(d<65){dx+=a/d*(65-d)/15;dy+=b/d*(65-d)/15}}D.hold(s.x+dx*45,s.y+dy*45);''',110)
 if m=='traffic':return bot('D.keys(t%5<3? ["Space"]:[])',100)
 if m=='breakout':return bot('''let blocks=s.blocks.filter(b=>b.alive),target=blocks[0]||{x:200,y:80};let land=s.x+s.vx*Math.max(0,(418-s.y)/(Math.abs(s.vy)||175));let span=460;land=((land-10)%(span*2)+span*2)%(span*2);land=10+(land>span?span*2-land:land);let vx=(target.x+33-land)/Math.max(.5,(418-target.y)/175);D.move(land-vx/4,430);''',175)
 if m=='platform':
  return bot('''const p=[{x:0,y:420,w:110},{x:140,y:365,w:100},{x:260,y:308,w:110},{x:120,y:248,w:100},{x:250,y:187,w:100},{x:365,y:129,w:115}];let current=p.findIndex(q=>Math.abs(s.y-(q.y-16))<2&&s.ground);if(!window.stage)window.stage=1;if(current>=window.stage)window.stage=current+1;let next=p[Math.min(window.stage,5)],prev=p[Math.max(0,window.stage-1)],target=next.x+next.w/2;let launch=target>s.x?prev.x+prev.w-20:prev.x+20;if(s.ground){if(Math.abs(s.x-launch)>9){D.keys([s.x<launch?'ArrowRight':'ArrowLeft'])}else{D.keys([]);D.press('Space')}}else D.keys(Math.abs(s.x-target)>7?[s.x<target?'ArrowRight':'ArrowLeft']:[]);''',100)
 if m=='snake':
  for _ in range(600):
   if mode()!='playing':return
   s=state();start=(s['body'][0]['x'],s['body'][0]['y']);goal=(s['food']['x'],s['food']['y']);blocked={(p['x'],p['y']) for p in s['body'][1:-1]};q=collections.deque([(start,[])]);seen={start};found=None
   while q:
    p,path=q.popleft()
    if p==goal:found=path;break
    for dx,dy,k in [(1,0,'ArrowRight'),(-1,0,'ArrowLeft'),(0,1,'ArrowDown'),(0,-1,'ArrowUp')]:
     n=(p[0]+dx,p[1]+dy)
     if 0<=n[0]<10 and 0<=n[1]<9 and n not in blocked and n not in seen:seen.add(n);q.append((n,path+[k]))
   assert found
   press(found[0]);step(.24)
  return
 if m=='slalom':return bot('''let danger=s.objects.filter(o=>!o.done&&o.kind==='cone'&&o.y>325&&o.y<440).map(o=>o.lane);let battery=s.objects.filter(o=>!o.done&&o.kind==='battery'&&o.y>240&&o.y<420).sort((a,b)=>b.y-a.y)[0];let lane=battery&&!danger.includes(battery.lane)?battery.lane:!danger.includes(s.lane)?s.lane:[0,1,2].find(x=>!danger.includes(x));if(lane!==undefined)D.tap(130+lane*110,200);''',90)
 if m=='lasers':return bot('let p=s.keys.find(k=>!k.got)||{x:55,y:430};D.hold(p.x,p.y)',90)
 if m=='billiards':
  drag([100,370],[100,439]);step(4)
  s=state();dx=385-s['x'];dy=120-s['y'];drag([s['x'],s['y']],[s['x']-(dx*.867+12)/3,s['y']-(dy*.867-3)/3]);step(9);return
 if m=='frogger':keypath(['ArrowUp']*7);return
 if m=='flappy':return bot('let p=s.pipes.find(p=>!p.done&&p.x>70),target=p?p.gap:220;if(s.y>target+10||s.vy>120&&s.y>target-15)D.press("Space")',100)
 if m=='sliding':
  for i in astar8(state()['a']):gridtap(i,3,112,72,94)
  return
 if m=='lights':
  for i in [0,2,4,7]:gridtap(i,3,110,75,95)
  return
 if m=='pipes':
  for i,target in [(0,2),(4,0),(5,0),(9,0),(13,0),(14,0),(15,0)]:
   for _ in range((target-state()['rot'][i])%4):gridtap(i,4,85,70,78)
  return
 if m=='sokoban':
  rows=['########','#......#','#..#...#','#......#','#......#','#......#','########'];s=state();start=((s['x'],s['y']),tuple(sorted((b['x'],b['y']) for b in s['boxes'])));goals={(3,4),(4,4)};q=collections.deque([(start,[])]);seen={start}
  while q:
   (p,boxes),path=q.popleft()
   if set(boxes)==goals:keypath(path);return
   for dx,dy,k in [(1,0,'ArrowRight'),(-1,0,'ArrowLeft'),(0,1,'ArrowDown'),(0,-1,'ArrowUp')]:
    n=(p[0]+dx,p[1]+dy)
    if rows[n[1]][n[0]]=='#':continue
    new=set(boxes)
    if n in new:
     b=(n[0]+dx,n[1]+dy)
     if rows[b[1]][b[0]]=='#'or b in new:continue
     new.remove(n);new.add(b)
    key=(n,tuple(sorted(new)))
    if key not in seen:seen.add(key);q.append((key,path+[k]))
  raise AssertionError('Sokoban unsolvable')
 if m=='nonogram':
  target=[0,1,0,1,0,1,1,1,1,1,1,1,1,1,1,0,1,1,1,0,0,0,1,0,0]
  for i,v in enumerate(target):
   if v:gridtap(i,5,57,130,150)
  return
 if m=='mirrors':
  for i,v in enumerate([0,0,1,1]):
   q=state()['mirrors'][i]
   if q['v']!=v:tap(92+q['x']*74,122+q['y']*74)
  return
 if m=='keys':
  rows=['########','#..#..B#','#..R...#','#.##.#.#','#......#','#......#','########'];q=collections.deque([((1,5,0),[])]);seen={(1,5,0)}
  while q:
   (x,y,mask),path=q.popleft()
   if (x,y)==(6,1)and mask==3:keypath(path);return
   for dx,dy,k in [(1,0,'ArrowRight'),(-1,0,'ArrowLeft'),(0,1,'ArrowDown'),(0,-1,'ArrowUp')]:
    a,b=x+dx,y+dy;c=rows[b][a]
    if c=='#'or c=='R'and not mask&1 or c=='B'and not mask&2:continue
    nmask=mask|(1 if (a,b)==(1,1)else 2 if (a,b)==(5,2)else 0);n=(a,b,nmask)
    if n not in seen:seen.add(n);q.append((n,path+[k]))
  raise AssertionError('Key maze unsolvable')
 if m=='bridges':
  for x,y in [(165,145),(315,145),(165,355),(315,355),(90,250),(390,250)]:tap(x,y)
  return
 if m=='balance':
  for target in [9,14,17]:
   weights=[2,3,5,9,12];combo=next(c for n in range(1,6)for c in itertools.combinations(range(5),n)if sum(weights[i]for i in c)==target)
   for i in combo:tap(75+i*82,350)
   step(.55)
  return
 if m=='sudoku':
  target=[1,2,3,4,3,4,1,2,2,1,4,3,4,3,2,1]
  for i,v in enumerate(state()['a']):
   if not v:gridtap(i,4,75,90,70);tap(127.5+(target[i]-1)*75,419)
  return
 if m=='pairs':
  cards=state()['cards']
  for v in range(6):
   for i,c in enumerate(cards):
    if c==v:gridtap(i,4,100,40,95)
  return
 if m=='simon':
  for r in range(5):
   step((r+3)*.8+1.1);s=state()
   assert s['phase']=='input',s
   for n in s['seq'][:r+3]:tap(155+n%2*170,180+n//2*160)
  return
 if m=='cups':
  for _ in range(4):
   step(6.5);s=state();assert s['phase']=='guess',s;tap(110+s['order'].index(0)*130,255)
  return
 if m=='odd':
  for _ in range(8):gridtap(state()['target'],4,88,64,80)
  return
 if m=='stars':
  for _ in range(3):
   step(3.6)
   for i in state()['targets']:gridtap(i,4,88,64,80)
  return
 if m=='descending':
  a=state()['a']
  for n in range(16,0,-1):gridtap(a.index(n),4,88,64,80)
  return
 if m=='stroop':
  for _ in range(10):
   i=state()['ink'];tap(140+i%2*205,333+i//2*72)
  return
 if m=='missing':
  for _ in range(5):step(3.1);tap(53.5+state()['missing']*53,362)
  return
 if m=='tracking':
  step(10.1)
  for i in range(3):
   dots=state()['dots'];p=dots[i];point=None
   for dx,dy in [(0,0),(20,0),(-20,0),(0,20),(0,-20)]:
    x,y=p['x']+dx,p['y']+dy
    if next((j for j,d in enumerate(dots)if math.hypot(d['x']-x,d['y']-y)<30),None)==i:point=(x,y);break
   assert point;tap(*point)
  return
 if m=='silhouette':
  for _ in range(6):
   s=state();i=s['options'].index(s['target']);tap(75+i*115,343)
  return
 if m=='lockpick':return bot('D.hold(240+Math.cos(s.target)*110,255+Math.sin(s.target)*110)',40)
 if m=='timing':
  return bot('''if(Arcade.meta.mechanic==='timing'){if(s.cool<=0&&Math.abs(s.marker-s.target)<.08)D.press('Space')}else if(Math.abs(Math.atan2(Math.sin(s.angle+Math.PI/2),Math.cos(s.angle+Math.PI/2)))<.16)D.press('Space');''',80)
 if m=='archery':
  for _ in range(4):
   target=state()['targetY'];vx=250;t=330/vx;vy=(target-380-70*t*t)/t;drag([65,380],[65-vx/3.6,380-vy/3.6]);step(2.2)
  return
 if m=='rhythm':
  notes=state()['notes'];t=0
  for n in notes:
   if mode()!='playing':return
   step(n['time']-t);t=n['time'];press(['KeyA','KeyS','KeyD','KeyF'][n['lane']])
  return
 if m=='trace':
  points=[[65,400],[65,145],[195,145],[195,300],[340,300],[340,110],[420,110]]
  page.evaluate('(p)=>D.hold(...p)',points[0])
  for a,b in zip(points,points[1:]):
   n=math.ceil(math.dist(a,b)/12)
   for j in range(1,n+1):page.evaluate('(p)=>D.move(...p)',[a[0]+(b[0]-a[0])*j/n,a[1]+(b[1]-a[1])*j/n])
  page.evaluate('(p)=>D.up(...p)',points[-1]);return
 if m=='parking':return bot('''if(!window.parkStage)window.parkStage=0;const points=[{x:100,y:165},{x:365,y:165}];let p=points[Math.min(window.parkStage,1)],dx=p.x-s.x,dy=p.y-s.y,d=Math.hypot(dx,dy);if(d<13&&Math.abs(s.v)<18&&window.parkStage<2)window.parkStage++;let desired=window.parkStage>=2?-Math.PI/2:Math.atan2(dy,dx),err=Math.atan2(Math.sin(desired-s.a),Math.cos(desired-s.a));let keys=[];if(Math.abs(err)>.05)keys.push(err>0?'ArrowRight':'ArrowLeft');let speed=window.parkStage>=2?0:Math.min(90,d*1.25);if(s.v<speed-4&&Math.abs(err)<.15)keys.push('ArrowUp');if(s.v>speed+5)keys.push('ArrowDown');D.keys(keys);''',160)
 if m=='mines':
  gridtap(12,5,60,90,84);mines=state()['mines'];assert 12 not in mines
  for i in range(25):
   if i not in mines:gridtap(i,5,60,90,84)
  return
 if m=='curling':
  for _ in range(4):
   if mode()!='playing':break
   s=state();drag([s['x'],s['y']],[s['x'],s['y']+55]);step(5)
  return
 if m=='reactor':return bot('D.keys(s.temp>53?["ArrowLeft"]:s.temp<47?["ArrowRight"]:[])',70)
 if m=='hockey':return bot('''let q=s.puck,target=s.bot.x<240?310:170,dx=target-q.x,dy=70-q.y,d=Math.hypot(dx,dy)||1;D.move(q.x-dx/d*32,q.y-dy/d*32);''',220)
 if m=='defense':return bot('''if(s.gold>=25){let target=[1,4,0,2,3,5].map(i=>s.towers[i]).find(q=>q.level===0)||s.towers.find(q=>q.level<3);if(target)D.tap(target.x,target.y)}''',220)
 if m=='rts':return bot('''if(s.workers<4&&s.gold>=20)D.tap(125,410);else if(s.gold>=15&&s.cool<=0)D.tap(350,410)''',220)
 if m=='reversi':
  dirs=[(dx,dy)for dx in [-1,0,1]for dy in [-1,0,1]if dx or dy]
  def move(b,i,side):
   if b[i]:return None
   f=[]
   for dx,dy in dirs:
    x,y=i%4+dx,i//4+dy;chain=[]
    while 0<=x<4 and 0<=y<4 and b[y*4+x]==-side:chain.append(y*4+x);x+=dx;y+=dy
    if chain and 0<=x<4 and 0<=y<4 and b[y*4+x]==side:f+=chain
   if not f:return None
   c=list(b);c[i]=side
   for j in f:c[j]=side
   return tuple(c),len(f)
  from functools import lru_cache
  @lru_cache(None)
  def best(b,side):
   moves=[(i,move(b,i,side))for i in range(16)];moves=[(i,v)for i,v in moves if v]
   other=any(move(b,i,-side)for i in range(16))
   if not moves:
    if not other:return (sum(b),None)
    return best(b,-side)[0],None
   if side==-1:
    i,v=max(moves,key=lambda x:x[1][1]);return best(v[0],1)[0],i
   values=[(best(v[0],-1)[0],i)for i,v in moves];return max(values)
  for _ in range(18):
   if mode()!='playing':break
   s=state()
   if s['turn']!=1:step(.6);continue
   _,i=best(tuple(s['board']),1)
   if i is None:step(.6);continue
   gridtap(i,4,85,70,80);step(.6)
  return
 if m=='logistics':
  for i in [1,0,1,4,1,2,1,4,6]:
   points=[(80,130),(240,130),(400,130),(80,295),(240,295),(400,295),(240,420)];tap(*points[i]);step(1.2)
  return
 if m=='siege':
  tap(405,147);tap(405,147)
  for _ in range(3):tap(240,214);step(3)
  return
 if m=='lanes':return bot('''if(s.gold>=12){let enemy=s.units.filter(u=>u.side===-1).sort((a,b)=>a.x-b.x)[0];let lane=enemy?enemy.lane:0,type=enemy?([2,0,1][enemy.type]):0;D.tap(100+type*140,424);D.tap(200,150+lane*85)}''',170)
 if m=='farm':return bot('''let order=[{type:0,n:2},{type:1,n:2},{type:2,n:1}][Math.min(s.order,2)],active=s.plots.filter(p=>p.type===order.type).length;for(let i=0;i<6;i++){let p=s.plots[i],x=125+(i%3)*115,y=172+Math.floor(i/3)*115;if(p.type===order.type&&p.progress>=[6,8,10][p.type]){D.tap(x,y);break}if(p.type===order.type&&p.wet<=0&&s.water>=1){D.tap(x,y);break}if(p.type<0&&active+s.inventory[order.type]<order.n){D.tap(95+order.type*150,414);D.tap(x,y);break}}''',180)
 if m=='alchemy':
  for a,b in [(1,2),(1,3),(0,2),(5,6),(3,7),(2,3),(8,9)]:
   known=state()['known']
   for v in [a,b]:
    i=known.index(v);tap(82+i%4*105,112+i//4*85)
  return
 if m=='conquest':return bot('''if(!window.nextAttack||t>window.nextAttack){let own=s.nodes.map((n,i)=>({...n,i})).filter(n=>n.owner===1).sort((a,b)=>b.n-a.n),enemy=s.nodes.map((n,i)=>({...n,i})).filter(n=>n.owner===-1).sort((a,b)=>a.n-b.n);if(own.length&&enemy.length&&own[0].n>enemy[0].n*2+2){D.tap(own[0].x,own[0].y);D.tap(enemy[0].x,enemy[0].y);window.nextAttack=t+4}}''',210)
 if m=='stealth':
  rows=['########','#......#','#..#...#','#......#','#.#....#','#......#','########'];routes=[[(4,1),(5,1),(6,1),(6,2),(5,2),(4,2)],[(4,4),(5,4),(6,4),(6,3),(5,3),(4,3)]];docs=[(2,1),(5,3),(6,5)];start=(1,5,0,0);q=collections.deque([(start,[])]);seen={start}
  while q:
   (x,y,mask,t),path=q.popleft()
   if (x,y)==(6,1)and mask==7:keypath(path);return
   for dx,dy,k in [(1,0,'ArrowRight'),(-1,0,'ArrowLeft'),(0,1,'ArrowDown'),(0,-1,'ArrowUp'),(0,0,'Space')]:
    a,b=x+dx,y+dy
    if rows[b][a]!='.':continue
    nt=(t+1)%6;danger=set()
    for route in routes:
     gx,gy=route[nt];nx,ny=route[(nt+1)%6];danger.add((gx,gy));vx,vy=nx-gx,ny-gy
     for dist in [1,2]:
      ux,uy=gx+vx*dist,gy+vy*dist
      if not 0<=uy<7 or not 0<=ux<8 or rows[uy][ux]!='.':break
      danger.add((ux,uy))
    if (a,b)in danger:continue
    nm=mask
    for i,d in enumerate(docs):
     if (a,b)==d:nm|=1<<i
    n=(a,b,nm,nt)
    if n not in seen:seen.add(n);q.append((n,path+[k]))
  raise AssertionError('Stealth level unsolvable')
 if m=='anagram':
  for word in ['ПОРТАЛ','КОРОНА','МОЛНИЯ']:
   a=state()['letters'];used=set()
   for char in word:
    i=next(i for i,v in enumerate(a)if v==char and i not in used);used.add(i);tap(80+i*64,317)
  return
 if m=='detective':
  for target in [1,0,2]:
   for i in range(3):tap(240,112+i*64)
   tap(95+target*150,370)
  return
 if m=='gravity':return bot('''let c=s.coins.find(c=>!c.got);if(c){let desired=c.y<200?-1:1;if(s.gravity!==desired)D.press('Space')}''',85)
 if m=='hexpath':
  cells=[(0,0),(1,0),(0,1),(-1,1),(-1,0),(0,-1),(1,-1)]
  for i in [1,2,3,4,5,6,0]:
   q,r=cells[i];tap(240+78*q,260+90*(r+q/2))
  return
 if m=='magnet':return bot('''if(!window.magnetStage)window.magnetStage=0;if(window.magnetStage===0&&t>18)window.magnetStage=1;D.hold(window.magnetStage?405:160,window.magnetStage?400:390);''',100)
 if m=='docking':return bot('''let dx=385-s.x,dy=135-s.y,d=Math.hypot(dx,dy),speed=Math.hypot(s.vx,s.vy),desired=d<31?-Math.PI/2:Math.atan2(dy*1.2-s.vy*2,dx*1.2-s.vx*2),err=Math.atan2(Math.sin(desired-s.a),Math.cos(desired-s.a)),keys=[];if(Math.abs(err)>.045)keys.push(err>0?'ArrowRight':'ArrowLeft');if(d<35||speed>Math.min(85,d*1.5)||Math.abs(err)>.7&&speed>35)keys.push('ArrowDown');else if(Math.abs(err)<.2&&d>23)keys.push('ArrowUp');D.keys(keys);''',200)
 if m=='mastermind':
  candidates=list(itertools.permutations(range(6),4))
  def feedback(a,b):
   exact=sum(x==y for x,y in zip(a,b));return exact,sum(min(a.count(v),b.count(v))for v in range(6))-exact
  guess=(0,1,2,3)
  for turn in range(10):
   for i,c in enumerate(guess):tap(98+i*65,379);tap(67.5+c*65,441)
   tap(402,379)
   if mode()=='won':return
   h=state()['history'][-1];f=(h['exact'],h['partial']);candidates=[c for c in candidates if feedback(c,guess)==f];assert candidates
   guess=min(candidates,key=lambda c:max(collections.Counter(feedback(x,c)for x in candidates).values()))
  return
 if m=='domino':
  tiles=state()['tiles']
  def chain(end,left):
   if not left:return[]
   for i in left:
    a,b=tiles[i]
    if end in [a,b]:
     result=chain(b if a==end else a,[j for j in left if j!=i])
     if result is not None:return[i]+result
   return None
  sequence=chain(1,list(range(7)));assert sequence
  for i in sequence:tap(76+i%4*105,254+i//4*78)
  return
 if m=='tangram':
  targets=[(240,125),(240,220),(160,214),(320,214),(240,328)]
  for i,target in enumerate(targets):
   q=state()['pieces'][i];drag([q['x'],q['y']],list(target))
   for _ in range(4):
    if state()['pieces'][i]['locked']:break
    tap(240,442)
  return
 if m=='cut':
  for a,b in [([240,95],[240,395]),([70,245],[410,245]),([240,95],[240,395])]:drag(a,b)
  return
 if m=='boss':return bot('''const points=[{x:95,y:360},{x:385,y:360},{x:385,y:235},{x:95,y:235}];if(window.bossPoint===undefined)window.bossPoint=0;let p=points[window.bossPoint],dx=p.x-s.x,dy=p.y-s.y;if(Math.hypot(dx,dy)<14){window.bossPoint=(window.bossPoint+1)%4;p=points[window.bossPoint];dx=p.x-s.x;dy=p.y-s.y}let keys=['Space'];if(Math.abs(dx)>8)keys.push(dx>0?'ArrowRight':'ArrowLeft');if(Math.abs(dy)>8)keys.push(dy>0?'ArrowDown':'ArrowUp');D.keys(keys);''',120)
 raise AssertionError('No solver: '+m)

if __name__=='__main__':
 games=json.loads((OUT/'catalog.json').read_text());only=set(os.environ.get('ONLY_GAMES','').split(','));report=[];failed=[]
 with sync_playwright() as p:
  browser=p.chromium.launch(executable_path=os.environ.get('BROWSER_EXECUTABLE'),args=['--no-sandbox'])
  context=browser.new_context(viewport={'width':1100,'height':900});context.add_init_script(DRIVER);page=context.new_page()
  errors=[];page.on('pageerror',lambda e:errors.append(str(e)))
  for g in games:
   if only!={''}and g['id']not in only:continue
   errors.clear()
   try:
    page.goto('http://127.0.0.1:8794/?g='+g['id']);assert page.locator('.answer-box').count()==0;page.locator('#begin-game').click();result=solve(g)
    assert mode()=='won',f"{mode()}: {str(result or state())[:1200]}"
    assert page.locator('.answer-box').inner_text()==g['answer'];assert not errors,errors
    report.append({'id':g['id'],'mechanic':g['mechanic'],'winViaInput':True,'elapsed':page.evaluate('Arcade.elapsed')});print(g['id'],g['mechanic'],'WIN',flush=True)
   except Exception as e:
    failed.append({'id':g['id'],'mechanic':g['mechanic'],'error':str(e)[:1800]});page.screenshot(path=str(OUT/('failure-'+g['id']+'.png')));print(g['id'],g['mechanic'],'FAIL',str(e)[:350],flush=True)
  browser.close()
 (OUT/'playthrough-report.json').write_text(json.dumps({'wins':len(report),'failures':failed,'cases':report},ensure_ascii=False,indent=2)+'\n')
 assert not failed,failed
 print('PASS:',len(report),'different games won via input handlers; exact SIGame answers displayed only on victory')

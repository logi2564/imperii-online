'use strict';
const Arcade=(()=>{
const W=480,H=480,pal={bg:'#132b27',grid:'#2c4840',white:'#edf4e8',lime:'#bdf362',gold:'#ffd481',red:'#ee8d7e',blue:'#9cc8f2',muted:'#89a99b'};
const defs=new Map();let canvas,ctx,meta,game,mode='idle',elapsed=0,deadline=0,played=0,last=performance.now(),prepLeft=0,hostPaused=false,answerPaused=false,repeatLeft=0,down=false,pointer={x:240,y:240},keys={},buttons=[],random,locked=false,onState=()=>{},onFrame=()=>{};
function rng(seed){return()=>{seed|=0;seed=seed+0x6D2B79F5|0;let t=Math.imul(seed^seed>>>15,1|seed);t=t+Math.imul(t^t>>>7,61|t)^t;return((t^t>>>14)>>>0)/4294967296}}
function shuffle(a,r=random){a=a.slice();for(let i=a.length-1;i>0;i--){let j=Math.floor(r()*(i+1));[a[i],a[j]]=[a[j],a[i]]}return a}
function rect(x,y,w,h,color=pal.grid,r=10){ctx.fillStyle=color;ctx.beginPath();if(ctx.roundRect)ctx.roundRect(x,y,w,h,r);else{ctx.moveTo(x+r,y);ctx.arcTo(x+w,y,x+w,y+h,r);ctx.arcTo(x+w,y+h,x,y+h,r);ctx.arcTo(x,y+h,x,y,r);ctx.arcTo(x,y,x+w,y,r)};ctx.fill()}
function circle(x,y,r,color=pal.lime){ctx.fillStyle=color;ctx.beginPath();ctx.arc(x,y,r,0,Math.PI*2);ctx.fill()}
function line(x,y,a,b,color=pal.muted,width=3){ctx.strokeStyle=color;ctx.lineWidth=width;ctx.beginPath();ctx.moveTo(x,y);ctx.lineTo(a,b);ctx.stroke()}
function text(t,x,y,size=20,color=pal.white,align='center',weight=700){ctx.fillStyle=color;ctx.font=`${weight} ${size}px Arial,sans-serif`;ctx.textAlign=align;ctx.textBaseline='middle';ctx.fillText(String(t),x,y)}
function label(t,y=32){text(t,240,y,17,pal.white)}
function button(x,y,w,h,t,fn,color=pal.grid){rect(x,y,w,h,color,12);text(t,x+w/2,y+h/2,16,pal.white);buttons.push({x,y,w,h,fn})}
function hit(x,y,b){return x>=b.x&&x<=b.x+b.w&&y>=b.y&&y<=b.y+b.h}
function dist(a,b){return Math.hypot(a.x-b.x,a.y-b.y)}
function arrow(x,y,angle,color=pal.lime,size=15){ctx.save();ctx.translate(x,y);ctx.rotate(angle);ctx.fillStyle=color;ctx.beginPath();ctx.moveTo(size,0);ctx.lineTo(-size,size*.65);ctx.lineTo(-size*.6,0);ctx.lineTo(-size,-size*.65);ctx.closePath();ctx.fill();ctx.restore()}
function cat(x,y,size=18,color=pal.lime){circle(x,y,size,color);ctx.fillStyle=color;ctx.beginPath();ctx.moveTo(x-size,y);ctx.lineTo(x-size,y-size*1.4);ctx.lineTo(x,y-size*.5);ctx.moveTo(x+size,y);ctx.lineTo(x+size,y-size*1.4);ctx.lineTo(x,y-size*.5);ctx.fill();circle(x-size*.35,y-2,2,pal.bg);circle(x+size*.35,y-2,2,pal.bg);line(x-3,y+5,x+3,y+5,pal.bg,2)}
function warrior(x,y,color=pal.blue,type=0){ctx.save();ctx.translate(x,y);circle(0,-11,6,'#e6c6a1');rect(-7,-5,14,19,color,4);line(-4,13,-7,21,'#26392f',4);line(4,13,7,21,'#26392f',4);if(type===2){ctx.fillStyle=color;ctx.beginPath();ctx.moveTo(-10,-16);ctx.lineTo(0,-31);ctx.lineTo(10,-16);ctx.fill();circle(15,-9,4,pal.gold);line(13,15,15,-9,pal.gold,3)}else if(type===1){ctx.strokeStyle=pal.gold;ctx.lineWidth=3;ctx.beginPath();ctx.arc(12,0,13,-1.2,1.2);ctx.stroke();line(16,-11,16,11,pal.white,1)}else{line(9,5,19,-13,pal.white,3);rect(-14,-3,8,14,'#c1ad78',3)}ctx.restore()}
function star(x,y,r=12,color=pal.gold){ctx.fillStyle=color;ctx.beginPath();for(let i=0;i<10;i++){let a=-Math.PI/2+i*Math.PI/5,rr=i%2?r*.45:r;ctx.lineTo(x+Math.cos(a)*rr,y+Math.sin(a)*rr)}ctx.closePath();ctx.fill()}
function wrap(n,min,max){return n<min?max:n>max?min:n}
function clamp(n,a,b){return Math.max(a,Math.min(b,n))}
function grid(cols,rows,cell=58,ox=(480-cols*cell)/2,oy=80,paint){for(let y=0;y<rows;y++)for(let x=0;x<cols;x++)paint(x,y,ox+x*cell,oy+y*cell,cell)}
function tileAt(x,y,cols,rows,cell=58,ox=(480-cols*cell)/2,oy=80){let c=Math.floor((x-ox)/cell),r=Math.floor((y-oy)/cell);return c>=0&&c<cols&&r>=0&&r<rows?{x:c,y:r,i:r*cols+c}:null}
function win(){if(mode!=='playing')return;mode='won';down=false;keys={};onState('won');try{let v=JSON.parse(localStorage.getItem('bro-arcade-completed')||'[]');if(!v.includes(meta.id))v.push(meta.id);localStorage.setItem('bro-arcade-completed',JSON.stringify(v))}catch{}}
function lose(reason='Попробуй ещё раз — время пока есть.'){if(mode!=='playing')return;mode='lost';down=false;keys={};onState('lost',reason)}
function setCanvas(c){canvas=c;ctx=c.getContext('2d');const dpr=Math.min(2,window.devicePixelRatio||1);c.width=W*dpr;c.height=H*dpr;ctx.setTransform(dpr,0,0,dpr,0,0);c.addEventListener('pointerdown',e=>{if(mode!=='playing'||hostPaused||answerPaused)return;e.preventDefault();try{c.setPointerCapture(e.pointerId)}catch{};const p=coord(e);down=true;pointer=p;for(let b of buttons.slice().reverse())if(hit(p.x,p.y,b)){b.fn();return}game.tap?.(p.x,p.y);game.down?.(p.x,p.y)});c.addEventListener('pointermove',e=>{const p=coord(e);pointer=p;if(mode==='playing'&&!hostPaused&&!answerPaused)game.move?.(p.x,p.y,down)});c.addEventListener('pointerup',e=>{const p=coord(e);if(mode==='playing'&&!hostPaused&&!answerPaused)game.up?.(p.x,p.y);down=false});c.addEventListener('pointercancel',()=>{down=false;game.cancel?.()});c.addEventListener('contextmenu',e=>e.preventDefault())}
function coord(e){let b=canvas.getBoundingClientRect();return{x:(e.clientX-b.left)*W/b.width,y:(e.clientY-b.top)*H/b.height}}
function register(id,def){if(defs.has(id))throw Error('Duplicate game '+id);defs.set(id,def)}
function prepare(m){meta=m;random=rng(m.seed);elapsed=0;played=0;deadline=m.seconds;prepLeft=m.prepSeconds||5;hostPaused=false;answerPaused=false;mode='ready';game=defs.get(m.mechanic).create(api);keys={};down=false;draw()}
function start(){if(mode==='ready'||mode==='preparing'){mode='playing';onState('playing')}}
function prime(){if(mode==='ready'){mode='preparing';onState('preparing')}}
function paused(){return hostPaused||answerPaused}
function control(action){if(!['play','pause','answer','answer-end'].includes(action))return;if(action==='pause')hostPaused=true;else if(action==='play')hostPaused=false;else if(action==='answer')answerPaused=true;else if(action==='answer-end')answerPaused=false;keys={};down=false;onState(paused()?'paused':mode)}
window.addEventListener('message',e=>{if(window.parent!==window&&e.source===window.parent&&e.data?.type==='si:media-control')control(e.data.action)});
function retry(){if(deadline<=0){onState('timeout');return}const remaining=deadline;random=rng(meta.seed);game=defs.get(meta.mechanic).create(api);elapsed=0;deadline=remaining;keys={};down=false;mode='playing';onState('playing')}
function key(k,v){const map={KeyW:'ArrowUp',KeyA:'ArrowLeft',KeyS:'ArrowDown',KeyD:'ArrowRight'};const original=k;k=map[k]||k;if(v&&!keys[k])repeatLeft=.28;if(v&&!keys[k]&&mode==='playing'&&!hostPaused&&!answerPaused)game.key?.(k,original);keys[k]=v}
function step(dt){
 if(paused()||!Number.isFinite(dt)||dt<=0)return;
 if(mode==='preparing'){const used=Math.min(prepLeft,dt);prepLeft-=used;dt-=used;onFrame();if(prepLeft<=.00001)start();else return}
 if(mode!=='playing'&&mode!=='lost')return;
 dt=Math.min(dt,deadline);
 if(mode==='lost'){deadline-=dt;if(deadline<=.00001){mode='timeout';onState('timeout')}onFrame();return}
 while(dt>.000001&&mode==='playing'){
  const slice=Math.min(dt,.025);elapsed+=slice;played+=slice;deadline=Math.max(0,deadline-slice);game.update?.(slice);if(['sokoban','keys','stealth','frogger'].includes(meta.mechanic)){repeatLeft-=slice;if(repeatLeft<=0){const held=['ArrowUp','ArrowDown','ArrowLeft','ArrowRight'].find(k=>keys[k]);if(held){game.key?.(held,held);repeatLeft=.16}}}dt-=slice;
 }
 if(mode==='lost'&&dt>0)deadline=Math.max(0,deadline-dt);
 if(deadline<=.00001&&(mode==='playing'||mode==='lost')){deadline=0;mode='timeout';keys={};down=false;onState('timeout')}
 onFrame()
}
function draw(){if(!ctx||!game)return;ctx.clearRect(0,0,W,H);rect(0,0,W,H,pal.bg,0);ctx.save();buttons=[];game.draw();ctx.restore()}
function loop(t){const dt=Math.max(0,(t-last)/1000);last=t;if(!window.__ARCADE_TEST_DRIVER__)step(dt);draw();requestAnimationFrame(loop)}
const api={W,H,pal,rect,circle,line,text,label,button,hit,dist,arrow,cat,warrior,star,wrap,clamp,grid,tileAt,shuffle,rng,win,lose,get ctx(){return ctx},get rand(){return random},get t(){return elapsed},get remaining(){return deadline},get keys(){return keys},get pointer(){return pointer},get down(){return down},get meta(){return meta}};
window.addEventListener('keydown',e=>{if(!canvas||mode!=='playing'||/INPUT|TEXTAREA/.test(e.target.tagName))return;if(['ArrowUp','ArrowDown','ArrowLeft','ArrowRight','Space','KeyW','KeyA','KeyS','KeyD','KeyF'].includes(e.code))e.preventDefault();key(e.code,true)});window.addEventListener('keyup',e=>key(e.code,false));window.addEventListener('blur',()=>{keys={};down=false});document.addEventListener('visibilitychange',()=>{keys={};down=false});
requestAnimationFrame(loop);
function preview(c,m){const saved={canvas,ctx,meta,game,random,buttons,elapsed,mode};canvas=c;ctx=c.getContext('2d');c.width=480;c.height=300;ctx.setTransform(1,0,0,1,0,-55);meta=m;random=rng(m.seed);elapsed=0;game=defs.get(m.mechanic).create(api);draw();({canvas,ctx,meta,game,random,buttons,elapsed,mode}=saved)}
function stop(){mode='idle';canvas=null;ctx=null;game=null;keys={};down=false}
const exposed={preview,stop,register,prepare,start,prime,retry,setCanvas,key,draw,rng,shuffle,get definitions(){return defs},get meta(){return meta},get mode(){return mode},get remaining(){return deadline},get elapsed(){return elapsed},get prepLeft(){return prepLeft},get paused(){return paused()},get state(){return game?.state},get game(){return game},get palette(){return pal},set onState(fn){onState=fn},set onFrame(fn){onFrame=fn}};
if(window.__ARCADE_TEST_DRIVER__)exposed.testStep=seconds=>{step(seconds);draw()};
return exposed;
})();

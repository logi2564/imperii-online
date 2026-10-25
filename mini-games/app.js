'use strict';
(() => {
 const games=window.ARCADE_GAMES, app=document.getElementById('app');
 const arrows=new Set(['platform','snake','frogger','sokoban','keys','stealth']);
 const action=new Map([['platform','Прыжок'],['stealth','Ждать']]);
 const colors={'Ловкость':'#8eeaff','Головоломки':'#bdadff','Память':'#ffbc91','Точность':'#f5dc82','Стратегии':'#92edbe','Эксперименты':'#f6aadd','Финал':'#ff969d'};
 const meta=games.find(g=>g.id===(window.ENTRY_GAME||new URL(location.href).searchParams.get('g')))||games[0];
 document.documentElement.style.setProperty('--accent',colors[meta.genre]);
 document.body.classList.toggle('embedded',!!window.ENTRY_GAME);
 app.innerHTML=`<main class="arena"><header class="hud"><div class="game-title"><span class="badge">БЛИЦ <b>№${meta.index}</b></span><h1></h1></div><div class="timer" role="timer" aria-label="Осталось времени"><span id="seconds"></span><small>сек</small></div></header><div class="rule"><span id="goal"></span></div><section class="stage"><div class="play-area"><canvas id="game-canvas" aria-label="Игровое поле"></canvas><div class="progressbar"></div><div class="overlay" id="overlay" aria-live="polite"></div></div></section><div class="controls" id="controls"></div><footer><span id="help"></span><span class="private-note">Ответ после победы</span></footer></main>`;
 app.querySelector('h1').textContent=meta.title;
 app.querySelector('#goal').textContent=meta.goal;
 app.querySelector('#help').textContent=meta.controls;
 const stage=app.querySelector('.stage'),area=app.querySelector('.play-area');const resize=()=>{let r=stage.getBoundingClientRect(),n=Math.max(1,Math.min(r.width,r.height,600));area.style.width=n+'px';area.style.height=n+'px'};new ResizeObserver(resize).observe(stage);resize();
 const overlay=app.querySelector('#overlay'),timer=app.querySelector('#seconds'),bar=app.querySelector('.progressbar'),controls=app.querySelector('#controls');
 let lastMode='',lastCount=-1;
 function button(label,key){const b=document.createElement('button');b.className='control';b.textContent=label;b.type='button';b.setAttribute('aria-label',label);b.onpointerdown=e=>{e.preventDefault();try{b.setPointerCapture(e.pointerId)}catch{};b.classList.add('pressed');Arcade.key(key,true)};const end=()=>{b.classList.remove('pressed');Arcade.key(key,false)};b.onpointerup=end;b.onpointercancel=end;b.onlostpointercapture=end;controls.append(b)}
 if(arrows.has(meta.mechanic)){document.body.classList.add('has-controls');for(const [label,key] of [['←','ArrowLeft'],['↑','ArrowUp'],['↓','ArrowDown'],['→','ArrowRight']])button(label,key)}
 if(action.has(meta.mechanic))button(action.get(meta.mechanic),'Space');
 function show(){
  const mode=Arcade.mode,paused=Arcade.paused&&['preparing','playing','lost'].includes(mode),count=Math.ceil(Arcade.prepLeft);
  if(mode==='preparing'&&!paused){if(lastMode==='preparing'&&lastCount===count)return;lastCount=count;lastMode='preparing';overlay.className='overlay preparation';overlay.innerHTML='<div class="eyebrow">СЕЙЧАС НАЧНЁТСЯ</div><div class="countdown">'+count+'</div><h2></h2><p></p><small>Старт автоматически · без переходов</small>';overlay.querySelector('h2').textContent=meta.goal;overlay.querySelector('p').textContent=meta.controls;return}
  lastMode=paused?'paused':mode;
  overlay.className='overlay'+(mode==='playing'&&!paused?' hidden':'');
  if(paused){overlay.innerHTML='<div class="pause-icon">Ⅱ</div><h2>Пауза СИГейма</h2><p>Игра продолжится здесь после возобновления.</p>';return}
  if(mode==='ready'){overlay.innerHTML='<div class="eyebrow">ПРОВЕРКА МИНИ-ИГРЫ</div><h2></h2><p></p><button class="primary" id="begin-game">Начать</button>';overlay.querySelector('h2').textContent=meta.goal;overlay.querySelector('p').textContent=meta.controls;overlay.querySelector('button').onclick=()=>Arcade.start()}
  if(mode==='lost'){overlay.innerHTML='<div class="result-icon">↻</div><h2>Ещё попытка?</h2><p>Оставшееся время сохранится.</p><button class="primary" id="retry">Попробовать снова</button>';overlay.querySelector('button').onclick=()=>Arcade.retry()}
  if(mode==='timeout'){overlay.innerHTML='<div class="result-icon">◷</div><h2>Время вышло</h2><p>Ответ остался закрыт.<br>Следующий вопрос — новая возможность.</p>'}
  if(mode==='won'){overlay.classList.add('victory');overlay.innerHTML='<div class="victory-spark">✦</div><div class="eyebrow">ТЫ ПРОШЁЛ!</div><h2>Твой ответ</h2><div class="answer-box"></div><p>Жми кнопку СИГейма<br>и называй это слово.</p>';overlay.querySelector('.answer-box').textContent=meta.answer;if(meta.genre==='Финал')overlay.querySelector('p').textContent='Дождись приёма ответов СИГейма и введи это слово.'}
 }
 Arcade.onState=show;
 Arcade.onFrame=()=>{timer.textContent=Math.ceil(Arcade.remaining);bar.style.width=(Arcade.remaining/meta.seconds*100)+'%';app.querySelector('.timer').classList.toggle('danger',Arcade.remaining<=5);if(Arcade.mode==='preparing')show()};
 Arcade.setCanvas(app.querySelector('canvas'));Arcade.prepare(meta);timer.textContent=meta.seconds;
 if(window.ENTRY_GAME)Arcade.prime();else show();
})();

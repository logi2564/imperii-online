'use strict';
const $=id=>document.getElementById(id);
const maps={conquest1:'Европа · 1798',conquest2:'Америка · 1775',conquest3:'Европа · 1806',conquest4:'Европа · 1809',conquest5:'Америка · 1812',conquest6:'Европа · 1815'};
const countryNames={alg:'Алжир',aus:'Австрия',bad:'Баден',bav:'Бавария',bru:'Брауншвейг',che:'Швейцария',de:'Пруссия',den:'Дания',egy:'Египет',fra:'Франция',gbr:'Великобритания',hes:'Гессен',hre:'Священная Римская империя',ind:'Индейские народы',koi:'Италия',mar:'Марокко',mek:'Мекленбург',mol:'Молдавия',nap:'Неаполь',nas:'Нассау',nds:'Королевство Обеих Сицилий',ned:'Нидерланды',old:'Ольденбург',pap:'Папская область',per:'Персия',pie:'Пьемонт',pol:'Польша',por:'Португалия',pru:'Пруссия',rhc:'Рейнский союз',rus:'Россия',sax:'Саксония',spa:'Испания',srb:'Сербия',swe:'Швеция',tri:'Триполитания',tun:'Тунис',tur:'Османская империя',usa:'США',wal:'Валахия',wur:'Вюртемберг'};
let status,view='main',launchMode='online',busy=false,polling=false,entered=false,choiceSignature='',autoEnter=true,networkRequested=false,networkPromise=null,pollTimer,connectionLost=false;
async function network(){
 if(networkRequested||!window.Ew4Desktop)return;
 if(networkPromise)return networkPromise;
 message('Подключаем интернет…');
 networkPromise=Ew4Desktop.startNetwork().then(()=>{networkRequested=true;}).finally(()=>networkPromise=null);
 return networkPromise;
}
function name(f){return countryNames[f?.country]||f?.name||f?.country||'Страна';}
function faction(id){return name(status?.choices?.find(f=>f.id===id));}
function message(text){$('message').textContent=text;}
function error(text){$('error').textContent=text;$('error').hidden=false;setTimeout(()=>$('error').hidden=true,6000);}
async function api(route,body){
 const control=new AbortController(),timer=setTimeout(()=>control.abort(),route==='start'?45000:20000);
 try{const r=await fetch('/online/'+route,{method:body===undefined?'GET':'POST',headers:body===undefined?{}:{'Content-Type':'application/json'},body:body===undefined?undefined:JSON.stringify(body),cache:'no-store',signal:control.signal});
 const j=await r.json();if(!r.ok)throw Error(j.message||j.error||'Нет связи с создателем');return j;
 }catch(e){throw Error(e.name==='AbortError'?'Соединение не отвечает. Проверь интернет; партия сохранена.':e.message);}
 finally{clearTimeout(timer);}
}
function options(el,items,value,label){const old=el.value;el.textContent='';for(const item of items)el.appendChild(new Option(label(item),value(item)));if(items.some(i=>value(i)===old))el.value=old;}
function showDialog(kind,title){view=kind;$('dialog-title').textContent=title;$('dialog').hidden=false;for(const id of ['setup','waiting','join','active'])$(id).hidden=id!==kind;message('');}
function showGame(){
 if(!$('game').getAttribute('src'))$('game').src='/game?native=1';
 $('main').hidden=true;$('battle').hidden=false;$('dialog').hidden=true;entered=true;autoEnter=false;
}
function mainMenu(){$('main').hidden=false;$('battle').hidden=true;$('dialog').hidden=true;view='main';}
function invite(){
 const origin=status?.publicUrl||(!['127.0.0.1','localhost'].includes(location.hostname)?location.origin:null);
 if(!origin||!status.guestToken)return '';
 return 'EW4-'+btoa(JSON.stringify({v:1,u:origin+'/',t:status.guestToken})).replace(/\+/g,'-').replace(/\//g,'_').replace(/=+$/,'');
}
function draw(){
 if(!status?.authenticated)return;
 const host=status.role==='host';
 if(host&&status.started&&!status.solo)network().catch(e=>message(e.message));
 $('solo').disabled=false;$('multiplayer').disabled=false;
 $('solo').hidden=!host;$('continue-game').hidden=!status.started;$('multiplayer').textContent=host?'Мультиплеер':'Сетевая партия';
 if(status.started){
  $('turn').textContent='Ход '+status.round+' · '+(status.phase==='Finished'?'Партия завершена':status.canAct?'Ваш ход: '+faction(status.seat):'Ходит '+faction(status.activeFaction));
  $('end').disabled=busy||connectionLost||!status.canEnd||status.phase==='Finished';
  $('end').textContent=status.canEnd?'Завершить мой ход':'Ожидание хода';
  $('turn').textContent='Ты: '+faction(status.seat)+' · Ходит: '+faction(status.activeFaction)+' · Ход '+status.round;
  $('game').contentWindow?.postMessage({type:'ew4-status',status},location.origin);
  if(autoEnter)showGame();
  if(view==='active'){
   $('active-info').textContent='Твоя страна: '+faction(status.seat)+'. '+(status.canAct?'Сейчас твой ход.':'Дождись своего хода.');
   $('new-game').hidden=!host;$('active-invite').hidden=!host||status.solo;
   $('active-code').value=invite();$('active-copy').disabled=!invite();
  }
 }else{
  if(entered){entered=false;$('game').removeAttribute('src');mainMenu();}
  if(status.scenario&&(view==='waiting'||!host)){
   if(view!=='waiting')showDialog('waiting','Мультиплеер · '+(maps[status.scenario]||status.scenario));
   $('players').textContent='Создатель: '+faction(status.hostFaction)+' · Друг: '+(status.guestFaction?faction(status.guestFaction):'выбирает страну');
   $('host-invite').hidden=!host;$('guest-country').hidden=host;$('start').hidden=!host;$('start').disabled=!status.guestFaction;
   if(host){$('code').value=invite();$('copy').disabled=!invite();$('network-retry').hidden=!!invite();message(invite()?'Отправь код другу. Он вставляет его внутри приложения.':'Подключаем сеть…');}
   else {
    const choices=status.choices.filter(c=>c.id!==status.hostFaction),signature=choices.map(c=>c.id).join('|');
    if(signature!==choiceSignature){options($('faction'),choices,c=>c.id,name);choiceSignature=signature;}
    message(status.guestFaction?'Ты: '+faction(status.guestFaction)+'. Ждём начала партии.':'Выбери свою страну и нажми «Выбрать».');
   }
  }else if(!host&&view!=='join'){showDialog('waiting','Ожидание создателя');$('players').textContent='Создатель выбирает карту.';$('host-invite').hidden=true;$('guest-country').hidden=true;$('start').hidden=true;}
 }
 if(status.problem)message(status.problem);
}
async function poll(){
 clearTimeout(pollTimer);if(polling){pollTimer=setTimeout(poll,1000);return;}polling=true;
 try{const next=await api('status');if(!next.authenticated)throw Error('Подключись заново по коду приглашения');status=next;connectionLost=false;$('connection').hidden=true;draw();}
 catch(e){connectionLost=true;$('end').disabled=true;$('connection').hidden=false;$('game').contentWindow?.postMessage({type:'ew4-disconnected'},location.origin);}
 finally{polling=false;pollTimer=setTimeout(poll,connectionLost?3000:1500);}
}
async function setup(mode){
 if(!status?.authenticated)throw Error('Игра ещё запускается');
 if(status.started){showDialog('active','Текущая партия');draw();return;}
 if(status.role!=='host'){showDialog('waiting','Сетевая игра');draw();return;}
 if(mode==='online')network().catch(e=>message(e.message));
 launchMode=mode;showDialog('setup',mode==='solo'?'Одиночная игра':'Создать сетевую партию');
 const c=await api('catalog',{});options($('map'),c.scenarios.filter(s=>s.mode===2),s=>s.id,s=>maps[s.id]||s.name||s.id);await countries();
}
async function countries(){options($('country'),await api('countries',{scenario:$('map').value}),c=>c.id,name);if(Array.from($('country').options).some(o=>o.value==='fra'))$('country').value='fra';}
function action(id,fn){$(id).onclick=async()=>{if(busy)return;busy=true;$(id).disabled=true;try{await fn();await poll();}catch(e){error(e.message);message(e.message);}finally{busy=false;$(id).disabled=false;if(status)draw();}};}
action('solo',()=>setup('solo'));action('multiplayer',()=>setup('online'));action('continue-game',async()=>showGame());
action('create',async()=>{
 status=await api('prepare',{scenario:$('map').value,country:$('country').value});
 if(launchMode==='solo'){status=await api('start-solo',{});showGame();}
 else{autoEnter=true;showDialog('waiting','Мультиплеер · '+maps[status.scenario]);draw();}
});
action('choose',async()=>{autoEnter=true;return api('choose',{faction:$('faction').value});});action('start',async()=>{status=await api('start',{});showGame();});
async function copy(){const code=invite();if(!code)throw Error('Сеть ещё подключается');if(window.Ew4Desktop)await Ew4Desktop.copy(code);else await navigator.clipboard.writeText(code);message('Код скопирован');}
action('copy',copy);action('active-copy',copy);
action('new-game',async()=>{if(confirm('Текущая партия будет заменена. Начать новую?')){status=await api('reset',{confirm:true});$('game').removeAttribute('src');entered=false;choiceSignature='';autoEnter=false;mainMenu();await setup('online');}});
action('return',async()=>showGame());action('end',async()=>{if(connectionLost||!status?.canEnd)throw Error('Дождись своего хода');const game=$('game').contentWindow.Ew4OnlineGame;if(!game)throw Error('Карта ещё загружается');await game.end();});
$('map').onchange=()=>countries().catch(e=>error(e.message));
$('network-menu').onclick=()=>{showDialog('active',status.solo?'Меню игры':'Сетевая партия');draw();};
$('close').onclick=()=>{$('dialog').hidden=true;view=$('battle').hidden?'main':'battle';};
$('join-menu').onclick=()=>showDialog('join','Присоединиться к игре');
action('connect',async()=>{if(!window.Ew4Desktop)throw Error('Вставь код на стартовом экране Android-приложения');await Ew4Desktop.join($('join-code').value.trim());});
$('fullscreen').onclick=()=>window.Ew4Desktop?.fullscreen();$('exit').onclick=()=>window.Ew4Desktop?.quit();
addEventListener('message',event=>{if(event.origin!==location.origin||event.source!==$('game').contentWindow)return;if(event.data?.type==='ew4-lobby'){showDialog('active','Меню игры');draw();}if(event.data?.type==='ew4-error')error(event.data.message);if(event.data?.type==='ew4-disconnected'){$('connection').hidden=false;$('end').disabled=true;}});
action('network-retry',async()=>{networkRequested=false;await network();});
$('connection-retry').onclick=poll;
$('home').onclick=()=>{if(window.Ew4Desktop)Ew4Desktop.home();else window.Ew4App?.home();};
addEventListener('online',poll);addEventListener('visibilitychange',()=>{if(!document.hidden)poll();});
(async()=>{try{const hash=new URLSearchParams(location.hash.slice(1)),token=hash.get('host')||hash.get('join');if(token){await api('login',{token});history.replaceState(null,'',location.pathname);}await poll();if(hash.has('create')&&status?.role==='host')await setup('online');}catch(e){error(e.message);$('connection').hidden=false;}pollTimer=setTimeout(poll,1500);})();

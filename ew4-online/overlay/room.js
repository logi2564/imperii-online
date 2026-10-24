'use strict';
const $=id=>document.getElementById(id);
const countryNames={alg:'Алжир',aus:'Австрия',bad:'Баден',bav:'Бавария',bru:'Брауншвейг',che:'Швейцария',de:'Пруссия',den:'Дания',egy:'Египет',eng:'Великобритания',fra:'Франция',han:'Ганновер',hes:'Гессен',hol:'Нидерланды',ita:'Италия',mar:'Марокко',mex:'Мексика',nap:'Неаполь',ott:'Османская империя',pol:'Польша',por:'Португалия',pru:'Пруссия',rus:'Россия',sax:'Саксония',sco:'Шотландия',sic:'Сицилия',spa:'Испания',swe:'Швеция',tur:'Османская империя',usa:'США',ven:'Венеция',wur:'Вюртемберг'};
Object.assign(countryNames,{gbr:'Великобритания',koi:'Италия',ned:'Нидерланды',hre:'Священная Римская империя',ind:'Индейские народы',mek:'Мекленбург',mol:'Молдавия',nas:'Нассау',nds:'Королевство Обеих Сицилий',old:'Ольденбург',pap:'Папская область',per:'Персия',pie:'Пьемонт',rhc:'Рейнский союз',srb:'Сербия',tri:'Триполитания',tun:'Тунис',wal:'Валахия',fr:'Франция',gb:'Великобритания'});
const maps={'conquest1':'Европа · 1798','conquest2':'Америка · 1775','conquest3':'Европа · 1806','conquest4':'Европа · 1809','conquest5':'Америка · 1812','conquest6':'Европа · 1815'};
let status,entered=false,pollBusy=false,lastFactionSignature='',setupReady=false;
function name(choice){return countryNames[choice?.country]||choice?.name||choice?.country||'страна';}
function factionName(id){return name(status?.choices?.find(c=>c.id===id));}
async function api(route,args){const r=await fetch('/online/'+route,{method:args===undefined?'GET':'POST',headers:args===undefined?{}:{'Content-Type':'application/json'},body:args===undefined?undefined:JSON.stringify(args),cache:'no-store'});const j=await r.json();if(!r.ok)throw Error(j.error||j.message||'Нет связи');return j;}
function message(text){$('message').textContent=text;}
function options(select,items,value,label){const old=select.value;select.replaceChildren(...items.map(item=>new Option(label(item),value(item))));if(items.some(i=>value(i)===old))select.value=old;}
async function setup(){
 if(setupReady)return;setupReady=true;
 try{const c=await api('catalog',{});options($('scenario'),c.scenarios.filter(s=>s.mode===2),s=>s.id,s=>maps[s.id]||s.name||s.id);await countries();}catch(e){setupReady=false;throw e;}
}
async function countries(){const c=await api('countries',{scenario:$('scenario').value});options($('country'),c,x=>x.id,name);}
function draw(){
 for(const id of ['locked','host-setup','waiting','resume','invite-area','guest-choice','start'])$(id).hidden=true;
 if(!status.authenticated){$('locked').hidden=false;message('Нужно приглашение от создателя');return;}
 const host=status.role==='host';
 if(host){
  $('invite-area').hidden=false;
  const origin=status.publicUrl||(!['127.0.0.1','localhost'].includes(location.hostname)?location.origin:null);
  $('invite').value=origin?origin+'/#join='+status.guestToken:'';
  $('copy').disabled=!origin;
  $('tunnel-status').textContent=origin?'Друг открывает приглашение в Chrome на Android.':'Готовим ссылку через интернет. Если она не появляется, проверь окно запуска.';
 }
 if(status.started){
  $('resume').hidden=false;$('reset').hidden=!host;
  const text='Раунд '+status.round+' · '+(status.phase==='Finished'?'Партия завершена':status.canAct?'Твой ход: '+factionName(status.seat):'Сейчас ходит '+factionName(status.activeFaction));
  $('resume-info').textContent=text;$('turn').textContent=text;$('end').disabled=!status.canAct||status.phase==='Finished';
  message(status.problem||'Партия сохраняется автоматически. Твоя страна: '+factionName(status.seat));
  if(!entered){entered=true;openGame();}
  return;
 }
 if(entered){back();$('game').removeAttribute('src');}
 entered=false;
 if(!status.scenario){
  if(host){$('host-setup').hidden=false;setup().catch(e=>message(e.message));message('Выбери карту и свою страну');}
  else {$('waiting').hidden=false;$('waiting-title').textContent='Ждём создателя';$('players').textContent='';message('Создатель выбирает карту. Эта страница обновится сама.');}
  return;
 }
 $('waiting').hidden=false;$('waiting-title').textContent=maps[status.scenario]||status.scenario;
 $('players').textContent='Создатель: '+factionName(status.hostFaction)+' · Друг: '+(status.guestFaction?factionName(status.guestFaction):'выбирает страну')+' · '+(status.guestOnline?'друг на связи':'ждём подключения друга');
 $('invite-area').hidden=!host;$('guest-choice').hidden=host;$('start').hidden=!host;$('start').disabled=!status.guestFaction;
 if(host){
  message(status.guestFaction?'Страны выбраны — можно начинать':'Отправь приглашение другу');
 }else{
  const available=status.choices.filter(c=>c.id!==status.hostFaction),signature=available.map(c=>c.id).join('|');
  if(signature!==lastFactionSignature){options($('faction'),available,c=>c.id,name);lastFactionSignature=signature;}
  message(status.guestFaction?'Твоя страна: '+factionName(status.guestFaction)+'. Ждём начала партии.':'Выбери свою страну');
 }
}
function openGame(){if(!$('game').src)$('game').src='/game';$('lobby').hidden=true;$('battle').hidden=false;}
function back(){$('battle').hidden=true;$('lobby').hidden=false;}
async function poll(){if(pollBusy)return;pollBusy=true;try{status=await api('status');draw();$('connection').hidden=true;}catch(e){message(e.message);$('connection').hidden=false;}finally{pollBusy=false;}}
function action(id,fn){$(id).onclick=async()=>{$(id).disabled=true;try{await fn();await poll();}catch(e){message(e.message);}finally{$(id).disabled=false;}};}
$('scenario').onchange=()=>countries().catch(e=>message(e.message));
action('prepare',()=>api('prepare',{scenario:$('scenario').value,country:$('country').value}));
action('choose',()=>api('choose',{faction:$('faction').value}));
action('start',()=>api('start',{}));
action('reset',async()=>{if(confirm('Начать новую партию? Текущая партия будет заменена.')){await api('reset',{confirm:true});$('game').removeAttribute('src');setupReady=false;back();}});
action('copy',async()=>{if(!navigator.clipboard){$('invite').select();document.execCommand('copy');}else await navigator.clipboard.writeText($('invite').value);message('Приглашение скопировано');});
action('end',()=>{const game=$('game').contentWindow.Ew4OnlineGame;if(!game)throw Error('Карта ещё загружается');return game.end();});
$('open-game').onclick=openGame;$('back').onclick=back;
addEventListener('message',e=>{if(e.origin!==location.origin||e.source!==$('game').contentWindow)return;if(e.data?.type==='ew4-lobby')back();if(e.data?.type==='ew4-error')message(e.data.message);});
(async()=>{try{const hash=new URLSearchParams(location.hash.slice(1)),token=hash.get('host')||hash.get('join');if(token){await api('login',{token});history.replaceState(null,'',location.pathname);}await poll();}catch(e){message(e.message);$('locked').hidden=false;}setInterval(poll,1200);})();

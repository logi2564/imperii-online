'use strict';
(function(){
 const native=!!window.Ew4Ru;if(!native)return;
 const nav=document.querySelector('#main-menu nav');if(!nav)return;
 function command(id,text,fn){const b=document.createElement('button');b.id=id;b.className='main-entry';b.textContent=text;b.setAttribute('aria-label',text);b.onclick=fn;nav.appendChild(b);return b;}
 const dialog=document.createElement('section');dialog.id='full-multiplayer';dialog.hidden=true;dialog.className='modal';
 dialog.innerHTML='<div class="dialog full-network"><h2>Мультиплеер</h2><button id="full-create">Создать партию</button><label>Код приглашения<textarea id="friend-code" rows="3" placeholder="EW4-…" spellcheck="false"></textarea></label><button id="full-connect">Подключиться</button><button id="full-network-close">Назад</button><p id="full-network-error" role="alert"></p></div>';
 document.body.appendChild(dialog);
 command('full-multiplayer-button','Мультиплеер',()=>{dialog.hidden=false;document.querySelector('#full-create').hidden=!window.Ew4Desktop;});
 command('full-exit','Выход',()=>{if(window.Ew4Desktop)Ew4Desktop.quit();else window.Ew4App?.quit();});
 document.querySelector('#full-network-close').onclick=()=>dialog.hidden=true;
 document.querySelector('#full-create').onclick=()=>Ew4Desktop.multiplayer();
 document.querySelector('#full-connect').onclick=async()=>{
  const code=document.querySelector('#friend-code').value.trim(),error=document.querySelector('#full-network-error');
  if(!code.startsWith('EW4-')){error.textContent='Вставь полный код EW4-… от создателя партии';return;}
  try{if(window.Ew4Desktop)await Ew4Desktop.join(code);else if(window.Ew4App)Ew4App.join(code);else throw Error('Игровой клиент не готов');}
  catch(e){error.textContent=e.message;}
 };
})();

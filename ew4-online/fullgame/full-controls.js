'use strict';
(function(){
 if(!window.Ew4Ru)return;
 const nav=document.querySelector('#main-menu nav');if(!nav)return;
 function command(id,text,fn){const b=document.createElement('button');b.id=id;b.className='main-entry';b.textContent=text;b.setAttribute('aria-label',text);b.onclick=fn;nav.appendChild(b);return b;}
 const dialog=document.createElement('section');dialog.id='full-multiplayer';dialog.hidden=true;dialog.className='modal';
 dialog.innerHTML='<div class="dialog full-network"><h2>Играть с другом</h2><button id="full-create">Создать партию на ПК</button><label>Код от друга<textarea id="friend-code" rows="2" placeholder="EW4-…" spellcheck="false"></textarea></label><button id="full-paste">Вставить код</button><button id="full-connect">Подключиться</button><button id="full-network-close">Назад</button><p id="full-network-error" role="status"></p></div>';
 document.body.appendChild(dialog);
 const code=document.querySelector('#friend-code'),error=document.querySelector('#full-network-error'),connect=document.querySelector('#full-connect');
 try{code.value=localStorage.getItem('ew4.last-invitation')||'';}catch{}
 function failed(message){error.textContent=message;connect.disabled=false;connect.textContent='Подключиться';}
 window.ew4JoinFailed=failed;
 command('full-multiplayer-button','Мультиплеер',()=>{dialog.hidden=false;document.querySelector('#full-create').hidden=!window.Ew4Desktop;failed('ПК создателя должен быть включён во время партии.');});
 command('full-exit','Выход',()=>{if(window.Ew4Desktop)Ew4Desktop.quit();else window.Ew4App?.quit();});
 document.querySelector('#full-network-close').onclick=()=>dialog.hidden=true;
 document.querySelector('#full-create').onclick=()=>Ew4Desktop.multiplayer();
 function invitation(text){return String(text).match(/EW4-[A-Za-z0-9_-]+/)?.[0]||String(text).trim();}
 document.querySelector('#full-paste').onclick=async()=>{try{code.value=invitation(window.Ew4Desktop?await Ew4Desktop.paste():window.Ew4App?Ew4App.paste():await navigator.clipboard.readText());error.textContent='Нажми «Подключиться»';}catch{failed('Нажми и удерживай поле кода → «Вставить».');}};
 connect.onclick=async()=>{
  const value=invitation(code.value);code.value=value;
  if(!/^EW4-[A-Za-z0-9_-]{30,1796}$/.test(value)){failed('Вставь полный код EW4-… от создателя партии');return;}
  connect.disabled=true;connect.textContent='Подключаемся…';error.textContent='Проверяем соединение с ПК…';
  try{
   if(window.Ew4Desktop)await Ew4Desktop.join(value);else if(window.Ew4App)Ew4App.join(value);else throw Error('Игровой клиент не готов');
   try{localStorage.setItem('ew4.last-invitation',value);}catch{}
  }catch(e){failed(e.message);}
 };
})();

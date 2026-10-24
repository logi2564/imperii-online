'use strict';
window.Ew4OnlineMode=true;window.Ew4OnlineCanAct=false;
let onlineSequence=-1,onlineFetching=false;
async function onlinePoll(){
 if(onlineFetching||!window.Ew4OnlineGame?.ready()||window.Ew4OnlineGame.busy())return;
 onlineFetching=true;
 try{
  const response=await fetch('/online/status',{cache:'no-store'}),status=await response.json();
  window.Ew4OnlineCanAct=!!status.canAct;
  if(!status.started){onlineSequence=-1;return;}
  if(status.sequence===onlineSequence&&window.Ew4OnlineGame.revision()===status.revision)return;
  const r=await fetch('/api/action',{method:'POST',headers:{'Content-Type':'application/json'},body:JSON.stringify({op:'state'}),cache:'no-store'}),j=await r.json();
  if(!r.ok||!j.ok)throw Error(j.message||j.error||'Не удалось получить карту');
  if(window.Ew4OnlineGame.busy())return;
  // A slow poll must not overwrite a more recent completed local command.
  if(j.data.revision<(window.Ew4OnlineGame.revision()??-1))return;
  window.Ew4OnlineCanAct=!!j.data.online.canAct;
  if(await window.Ew4OnlineGame.enter(j.data))onlineSequence=j.data.online.sequence;
 }catch(error){parent.postMessage({type:'ew4-error',message:error.message},location.origin);}
 finally{onlineFetching=false;}
}
setInterval(onlinePoll,800);
addEventListener('load',()=>{
 const labels={'end-turn':'Завершить ход','undo-move':'Отменить перемещение','next-unit':'Следующий отряд','menu-button':'Меню','player-flag':'Твоя страна','close-settings':'Закрыть настройки'};
 for(const [id,text]of Object.entries(labels)){const e=document.getElementById(id);if(e){e.title=text;e.setAttribute('aria-label',text);}}
});

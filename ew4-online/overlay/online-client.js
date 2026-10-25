'use strict';
window.Ew4OnlineMode=true;window.Ew4OnlineCanAct=false;window.Ew4OnlineCanEnd=false;
window.ew4RequestSignal=function(ms){const c=new AbortController();setTimeout(()=>c.abort(),ms);return c.signal;}
let onlineSequence=-1,onlineFetching=false,onlineStatus=null,onlineParentSeen=0,onlineTimer;
function onlinePermissions(info){
 window.Ew4OnlineCanAct=!!info?.canAct;window.Ew4OnlineCanEnd=!!info?.canEnd;
 const end=document.getElementById('end-turn');if(end)end.disabled=!window.Ew4OnlineCanEnd||window.Ew4OnlineGame?.busy();
}
window.ew4OnlinePermissions=onlinePermissions;
async function onlinePoll(){
 clearTimeout(onlineTimer);
 if(onlineFetching||!window.Ew4OnlineGame?.ready()||window.Ew4OnlineGame.busy()){onlineTimer=setTimeout(onlinePoll,400);return;}
 onlineFetching=true;
 try{
  let status=onlineStatus;
  if(!status||Date.now()-onlineParentSeen>5000){
   const r=await fetch('/online/status',{cache:'no-store',signal:ew4RequestSignal(12000)});if(!r.ok)throw Error('Нет связи с создателем');status=await r.json();
  }
  onlinePermissions(status);
  if(!status.authenticated)throw Error('Подключись заново по приглашению');
  if(!status.started){onlineSequence=-1;return;}
  if(status.sequence===onlineSequence&&window.Ew4OnlineGame.revision()===status.revision)return;
  const r=await fetch('/api/action',{method:'POST',headers:{'Content-Type':'application/json'},body:JSON.stringify({op:'state'}),cache:'no-store',signal:ew4RequestSignal(20000)}),j=await r.json();
  if(!r.ok||!j.ok)throw Error(j.message||j.error||'Не удалось получить карту');
  if(window.Ew4OnlineGame.busy()||j.data.revision<(window.Ew4OnlineGame.revision()??-1))return;
  onlinePermissions(j.data.online);
  if(await window.Ew4OnlineGame.enter(j.data))onlineSequence=j.data.online.sequence;
 }catch(error){onlinePermissions(null);parent.postMessage({type:'ew4-disconnected'},location.origin);}
 finally{onlineFetching=false;onlineTimer=setTimeout(onlinePoll,1500);}
}
addEventListener('message',e=>{
 if(e.origin!==location.origin||e.source!==parent)return;
 if(e.data?.type==='ew4-status'){onlineStatus=e.data.status;onlineParentSeen=Date.now();if(!onlineStatus.canAct)onlinePermissions(onlineStatus);onlinePoll();}
 if(e.data?.type==='ew4-disconnected')onlinePermissions(null);
});
addEventListener('online',onlinePoll);addEventListener('visibilitychange',()=>{if(!document.hidden)onlinePoll();});
onlineTimer=setTimeout(onlinePoll,150);
addEventListener('load',()=>{
 const labels={'end-turn':'Завершить свой ход','undo-move':'Отменить перемещение','next-unit':'Следующий отряд','menu-button':'Меню','player-flag':'Твоя страна','close-settings':'Закрыть настройки'};
 for(const [id,text]of Object.entries(labels)){const e=document.getElementById(id);if(e){e.title=text;e.setAttribute('aria-label',text);}}
});

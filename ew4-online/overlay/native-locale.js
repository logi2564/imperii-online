'use strict';
(function(){
 if(new URLSearchParams(location.search).get('native')!=='1')return;
 let data={dictionary:{},russian:{},labels:{}},parts=[],cache=new Map(),missing=new Set();
 const cjk=/[\u3400-\u9fff]/;
 const normal=s=>s.replace(/\s+/g,' ').trim().toLowerCase();
 function text(value){
  const s=String(value??'');if(cache.has(s))return cache.get(s);
  let result=data.dictionary[s]??s;
  if(cjk.test(result))for(const [from,to]of parts)result=result.split(from).join(to);
  result=data.russian[normal(result)]??result;
  if(cjk.test(result)&&missing.size<500)missing.add(s);
  if(cache.size>20000)cache.clear();cache.set(s,result);return result;
 }
 window.Ew4Ru={text,get missing(){return [...missing];},get labels(){return data.labels;},ready:fetch('/native-ru.json').then(r=>{if(!r.ok)throw Error('Не удалось загрузить перевод');return r.json();}).then(j=>{
  data=j;cache.clear();parts=Object.entries(j.dictionary).filter(([k])=>k.length<100&&cjk.test(k)).sort((a,b)=>b[0].length-a[0].length);
  const style=document.createElement('link');style.rel='stylesheet';style.href='/native-game.css';document.head.append(style);
  document.documentElement.lang='ru';
  for(const image of document.querySelectorAll('.game-title,#loading-screen .loading-stage>img')){
   const title=document.createElement('div');title.className='game-title native-title';title.append('European War 4',document.createElement('br'));
   const sub=document.createElement('span');sub.textContent='Napoleon';title.append(sub);image.replaceWith(title);
  }
  const translateDom=()=>{
   for(const el of document.querySelectorAll('[title],[aria-label],[placeholder],[alt]'))for(const key of ['title','aria-label','placeholder','alt']){
    const old=el.getAttribute(key);if(old&&cjk.test(old)){const next=text(old);if(next!==old)el.setAttribute(key,next);}
   }
   const walker=document.createTreeWalker(document.body,NodeFilter.SHOW_TEXT),nodes=[];
   while(walker.nextNode()){const n=walker.currentNode;if(cjk.test(n.textContent)&&!n.parentElement.closest('script,style,canvas,.original-text'))nodes.push(n);}
   for(const n of nodes){const next=text(n.textContent);if(next!==n.textContent)n.textContent=next;}
  };
  let queued=false;new MutationObserver(()=>{if(!queued){queued=true;requestAnimationFrame(()=>{queued=false;translateDom();});}}).observe(document.body,{subtree:true,childList:true,characterData:true,attributes:true,attributeFilter:['title','aria-label','hidden','placeholder','alt']});
  translateDom();
 })};
})();

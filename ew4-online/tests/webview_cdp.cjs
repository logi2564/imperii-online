// Minimal page-level CDP transport for Android WebView; no desktop browser settings.
'use strict';
const readline=require('node:readline');
const socket=new WebSocket(process.argv[2]);
const pending=new Map();
const startup=setTimeout(()=>{process.stdout.write('{"error":{"code":-1}}\n');process.exit(1);},30000);
socket.addEventListener('open',()=>{clearTimeout(startup);process.stdout.write('{"ready":true}\n');});
socket.addEventListener('message',event=>{
 const value=JSON.parse(event.data);if(!value.id)return;
 clearTimeout(pending.get(value.id));pending.delete(value.id);process.stdout.write(JSON.stringify(value)+'\n');
});
socket.addEventListener('error',()=>{process.stdout.write('{"error":{"code":-2}}\n');process.exit(1);});
const lines=readline.createInterface({input:process.stdin});
lines.on('line',line=>{
 const request=JSON.parse(line);
 pending.set(request.id,setTimeout(()=>{pending.delete(request.id);process.stdout.write(JSON.stringify({id:request.id,error:{code:-3}})+'\n');},45000));
 socket.send(JSON.stringify(request));
});
lines.on('close',()=>{socket.close();process.exit(0);});

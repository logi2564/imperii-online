'use strict';
const {app,BrowserWindow,ipcMain,clipboard,dialog,Menu}=require('electron');
const {spawn}=require('node:child_process');
const fs=require('node:fs');
const path=require('node:path');
const os=require('node:os');
const net=require('node:net');
const testMode=process.argv.includes('--test-mode');
const launched=Date.now();
app.disableHardwareAcceleration();
app.commandLine.appendSwitch('disable-webgl');
app.commandLine.appendSwitch('disable-gpu');
if(process.platform==='win32')app.setAppUserModelId('logi2564.ew4fullgame');
function arg(name){const i=process.argv.indexOf(name);return i<0?null:process.argv[i+1];}
const root=arg('--app-root')||path.resolve(__dirname,'../..');
if(arg('--profile'))app.setPath('userData',path.resolve(arg('--profile')));
else app.setPath('userData',path.join(app.getPath('appData'),'BroEW4FullGame'));
if(testMode&&process.platform==='linux')app.commandLine.appendSwitch('no-sandbox');
let window,server,tunnel,stopping=false,localOrigin,allowedOrigin,hostToken;
const folder=testMode?path.join(app.getPath('userData'),'state'):path.join(process.env.LOCALAPPDATA||app.getPath('userData'),'BroEW4FullGame');
const saves=path.join(folder,'saves');
const publicFile=path.join(saves,'public-url.txt');
fs.mkdirSync(saves,{recursive:true});
function log(text){try{fs.appendFileSync(path.join(folder,'desktop.log'),new Date().toISOString()+' '+String(text)+'\n');}catch{}}
function clean(){
  if(stopping)return;stopping=true;
  for(const p of [tunnel,server])if(p&&!p.killed){try{p.kill();}catch{}}
  try{fs.unlinkSync(publicFile);}catch{}
}
function start(file,args){
  const p=spawn(file,args,{cwd:path.dirname(file),windowsHide:true,stdio:['ignore','pipe','pipe'],env:process.env});
  p.stdout.on('data',data=>log(data.toString()));p.stderr.on('data',data=>log(data.toString()));
  p.on('error',error=>log(error.message));return p;
}
function freePort(){return new Promise((resolve,reject)=>{const s=net.createServer();s.once('error',reject);s.listen(0,'127.0.0.1',()=>{const port=s.address().port;s.close(()=>resolve(port));});});}
async function untilReady(url){
  for(let i=0;i<120;i++){
    if(server.exitCode!==null)throw Error('Не удалось запустить игровой движок. Журнал: '+path.join(folder,'desktop.log'));
    try{const r=await fetch(url+'/health',{signal:AbortSignal.timeout(1500)});if(r.ok)return;}catch{}
    await new Promise(resolve=>setTimeout(resolve,350));
  }
  throw Error('Игра не ответила при запуске');
}
function decode(code){
  if(!code.startsWith('EW4-')||code.length>1800)throw Error('Вставь полный код приглашения EW4-…');
  let data;try{data=JSON.parse(Buffer.from(code.slice(4),'base64url').toString('utf8'));}catch{throw Error('Код приглашения повреждён');}
  const url=new URL(data.u);
  if(url.protocol!=='https:'||!url.hostname.endsWith('.trycloudflare.com')||url.username||url.password||url.port||!/^\/[\s]*$/.test(url.pathname)||!/^\w{64}$/.test(data.t))throw Error('Этот код не является приглашением игры');
  return {origin:url.origin,token:data.t};
}
if(!app.requestSingleInstanceLock())app.quit();
else {
  app.on('second-instance',()=>{if(window){if(window.isMinimized())window.restore();window.focus();}});
  app.on('before-quit',clean);
  app.on('window-all-closed',()=>app.quit());
  app.whenReady().then(async()=>{
    Menu.setApplicationMenu(null);
    window=new BrowserWindow({width:1152,height:720,minWidth:720,minHeight:480,show:false,title:'Европейская война 4 — Наполеон',icon:path.join(__dirname,'game-icon.png'),
      backgroundColor:'#1e211d',autoHideMenuBar:true,
      webPreferences:{preload:path.join(__dirname,'preload.cjs'),nodeIntegration:false,contextIsolation:true,sandbox:true,webgl:false,backgroundThrottling:true,autoplayPolicy:'no-user-gesture-required',devTools:testMode}});
    await window.loadFile(path.join(__dirname,'loading.html'));window.show();
    window.webContents.setWindowOpenHandler(()=>({action:'deny'}));
    window.webContents.on('will-navigate',(event,url)=>{try{if(new URL(url).origin!==allowedOrigin)event.preventDefault();}catch{event.preventDefault();}});
    window.webContents.on('will-attach-webview',event=>event.preventDefault());
    window.on('closed',()=>{window=null;app.quit();});
    window.webContents.on('before-input-event',(event,input)=>{if(input.type==='keyDown'&&input.key==='F11'){window.setFullScreen(!window.isFullScreen());event.preventDefault();}});
    ipcMain.on('ew4:quit',event=>{if(event.sender===window?.webContents)app.quit();});
    ipcMain.handle('ew4:network',event=>{
      if(event.sender!==window?.webContents)throw Error('Invalid sender');
      if(tunnel&&!tunnel.killed&&tunnel.exitCode===null)return true;
      const file=path.join(root,process.platform==='win32'?'cloudflared.exe':'cloudflared');
      if(!fs.existsSync(file))throw Error('Файл сетевого соединения отсутствует. Распакуй архив целиком.');
      tunnel=start(file,['tunnel','--no-autoupdate','--protocol','http2','--url',localOrigin]);
      const inspect=data=>{const match=data.toString().match(/https:\/\/[a-z0-9-]+\.trycloudflare\.com/);if(match)fs.writeFileSync(publicFile,match[0]);};
      tunnel.stdout.on('data',inspect);tunnel.stderr.on('data',inspect);return true;
    });
    ipcMain.on('ew4:fullscreen',event=>{if(event.sender===window?.webContents)window.setFullScreen(!window.isFullScreen());});
    ipcMain.handle('ew4:copy',(event,text)=>{if(event.sender!==window?.webContents||text.length>2000)return false;clipboard.writeText(text);return true;});
    ipcMain.handle('ew4:home',async event=>{if(event.sender!==window?.webContents)throw Error('Invalid sender');allowedOrigin=localOrigin;await window.loadURL(localOrigin+'/single?native=1&renderer=canvas');return true;});
    ipcMain.handle('ew4:multiplayer',async event=>{if(event.sender!==window?.webContents)throw Error('Invalid sender');allowedOrigin=localOrigin;await window.loadURL(localOrigin+'/native#host='+hostToken);return true;});
    ipcMain.handle('ew4:join',async(event,code)=>{
      if(event.sender!==window?.webContents)throw Error('Invalid sender');
      const invite=decode(code);allowedOrigin=invite.origin;
      await window.loadURL(invite.origin+'/native#join='+invite.token);return true;
    });
    try{
      const executable=path.join(root,'server',process.platform==='win32'?'Ew4.Web.exe':'Ew4.Web');
      if(!fs.existsSync(executable))throw Error('Распакуй весь архив игры: рядом с EXE должна быть папка server.');
      const port=await freePort();localOrigin='http://127.0.0.1:'+port;allowedOrigin=localOrigin;
      try{fs.unlinkSync(publicFile);}catch{}
      server=start(executable,['--urls',localOrigin,'--contentRoot',path.join(root,'server'),'--data-root',path.join(root,'server','data'),'--save-root',saves]);
      await untilReady(localOrigin);
      const cfg=JSON.parse(fs.readFileSync(path.join(saves,'online-room.json'),'utf8'));
      hostToken=cfg.hostToken;
      await window.loadURL(localOrigin+'/single?native=1&renderer=canvas');
      window.show();
      if(testMode)fs.writeFileSync(path.join(app.getPath('userData'),'native-ready.json'),JSON.stringify({ready:true,origin:localOrigin,window:true,externalBrowser:false,startupMs:Date.now()-launched,renderer:"canvas",hardwareAcceleration:false}));
    }catch(error){log(error.stack);dialog.showErrorBox('European War 4',error.message);app.quit();}
  }).catch(error=>{log(error.stack);clean();app.exit(1);});
}

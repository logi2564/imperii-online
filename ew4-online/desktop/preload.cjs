'use strict';
const {contextBridge,ipcRenderer}=require('electron');
contextBridge.exposeInMainWorld('Ew4Desktop',Object.freeze({
  quit:()=>ipcRenderer.send('ew4:quit'),
  fullscreen:()=>ipcRenderer.send('ew4:fullscreen'),
  copy:text=>ipcRenderer.invoke('ew4:copy',String(text)),
  startNetwork:()=>ipcRenderer.invoke('ew4:network'),
  join:code=>ipcRenderer.invoke('ew4:join',String(code))
}));

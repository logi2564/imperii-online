const { contextBridge, ipcRenderer } = require("electron");
contextBridge.exposeInMainWorld("svoi", {
  current: () => ipcRenderer.invoke("server:current"),
  connect: (url) => ipcRenderer.invoke("server:connect", url),
});

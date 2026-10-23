const { contextBridge, ipcRenderer } = require("electron");
contextBridge.exposeInMainWorld("svoi", {
  status: () => ipcRenderer.invoke("app:status"),
  retry: () => ipcRenderer.invoke("app:retry"),
  onStatus: (callback) => {
    const handler = (_event, status) => callback(status);
    ipcRenderer.on("app:status", handler);
    return () => ipcRenderer.removeListener("app:status", handler);
  },
});

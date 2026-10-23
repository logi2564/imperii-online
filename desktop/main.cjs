const {
  app,
  BrowserWindow,
  ipcMain,
  Menu,
  session,
  shell,
  net,
} = require("electron");
const fs = require("node:fs");
const path = require("node:path");
const { discover } = require("./service.cjs");
let window,
  launcherContents = null,
  allowedOrigin = null,
  connecting = false;
let status = { phase: "connecting" };
const cachePath = () =>
  path.join(app.getPath("userData"), "service-cache.json");
function cachedService() {
  try {
    return JSON.parse(fs.readFileSync(cachePath(), "utf8")).origin;
  } catch {
    return null;
  }
}
function isLauncher(contents) {
  // Track the window we created: Chromium normalizes Windows file URLs
  // differently from Node's pathToFileURL, including drive-letter casing.
  return (
    contents === launcherContents &&
    contents === window?.webContents &&
    contents.getURL().startsWith("file:")
  );
}
function updateStatus(next) {
  status = next;
  if (window && !window.isDestroyed() && isLauncher(window.webContents))
    window.webContents.send("app:status", status);
}
function makeWindow(preload) {
  const old = window;
  window = new BrowserWindow({
    width: 1360,
    height: 900,
    minWidth: 760,
    minHeight: 600,
    backgroundColor: "#202127",
    title: "Свои",
    autoHideMenuBar: true,
    show: false,
    webPreferences: {
      ...(preload ? { preload: path.join(__dirname, "preload.cjs") } : {}),
      contextIsolation: true,
      nodeIntegration: false,
      sandbox: true,
      webSecurity: true,
      allowRunningInsecureContent: false,
      spellcheck: true,
    },
  });
  launcherContents = preload ? window.webContents : null;
  window.once("ready-to-show", () => {
    window.show();
    if (old && !old.isDestroyed()) old.destroy();
  });
  window.webContents.setWindowOpenHandler(({ url }) => {
    try {
      const link = new URL(url);
      if (["https:", "http:"].includes(link.protocol))
        shell.openExternal(link.href);
    } catch {}
    return { action: "deny" };
  });
  for (const eventName of ["will-navigate", "will-redirect"])
    window.webContents.on(eventName, (event, url) => {
      try {
        if (!allowedOrigin || new URL(url).origin !== allowedOrigin)
          event.preventDefault();
      } catch {
        event.preventDefault();
      }
    });
  return window;
}
async function showLauncher() {
  allowedOrigin = null;
  const win = makeWindow(true);
  await win.loadFile(path.join(__dirname, "connect.html"));
}
async function connect() {
  if (connecting) return;
  connecting = true;
  updateStatus({ phase: "connecting" });
  try {
    const result = await discover({
      fetcher: (url, options) => net.fetch(url, options),
      cached: cachedService(),
      developmentUrl: !app.isPackaged ? process.env.SVOI_DEV_URL : undefined,
    });
    if (result.phase !== "ready") {
      updateStatus(result);
      return;
    }
    fs.mkdirSync(app.getPath("userData"), { recursive: true });
    fs.writeFileSync(cachePath(), JSON.stringify({ origin: result.origin }));
    allowedOrigin = result.origin;
    const win = makeWindow(false);
    await win.loadURL(result.origin + "/");
    status = { phase: "ready" };
  } catch {
    status = { phase: "offline" };
    if (!window || window.isDestroyed() || !isLauncher(window.webContents))
      await showLauncher();
    updateStatus(status);
  } finally {
    connecting = false;
  }
}
ipcMain.handle("app:status", (event) =>
  isLauncher(event.sender) ? status : null,
);
ipcMain.handle("app:retry", (event) => {
  if (!isLauncher(event.sender)) return false;
  setImmediate(connect);
  return true;
});
if (!app.requestSingleInstanceLock()) app.quit();
else {
  app.on("second-instance", () => {
    if (window) {
      if (window.isMinimized()) window.restore();
      window.show();
      window.focus();
    }
  });
  app.whenReady().then(async () => {
    Menu.setApplicationMenu(
      Menu.buildFromTemplate([
        {
          label: "Свои",
          submenu: [
            {
              label: "Повторить подключение",
              accelerator: "CmdOrCtrl+Shift+R",
              click: async () => {
                if (connecting) return;
                await showLauncher();
                connect();
              },
            },
            { type: "separator" },
            { label: "Выйти", role: "quit" },
          ],
        },
        {
          label: "Правка",
          submenu: [
            { role: "undo" },
            { role: "redo" },
            { type: "separator" },
            { role: "cut" },
            { role: "copy" },
            { role: "paste" },
            { role: "selectAll" },
          ],
        },
        {
          label: "Вид",
          submenu: [
            { role: "reload" },
            { role: "togglefullscreen" },
            { type: "separator" },
            { role: "resetZoom" },
            { role: "zoomIn" },
            { role: "zoomOut" },
          ],
        },
      ]),
    );
    const allowed = (contents, details) => {
      try {
        return (
          !!allowedOrigin &&
          contents === window?.webContents &&
          new URL(contents.getURL()).origin === allowedOrigin &&
          new URL(
            details.requestingUrl ||
              details.securityOrigin ||
              contents.getURL(),
          ).origin === allowedOrigin
        );
      } catch {
        return false;
      }
    };
    session.defaultSession.setPermissionRequestHandler(
      (contents, permission, callback, details) =>
        callback(
          permission === "media" &&
            !details.mediaTypes?.includes("video") &&
            allowed(contents, details),
        ),
    );
    session.defaultSession.setPermissionCheckHandler(
      (contents, permission, origin, details) =>
        permission === "media" &&
        details.mediaType !== "video" &&
        allowed(contents, { ...details, securityOrigin: origin }),
    );
    await showLauncher();
    connect();
    app.on("activate", async () => {
      if (!BrowserWindow.getAllWindows().length) {
        await showLauncher();
        connect();
      }
    });
  });
  app.on("window-all-closed", () => {
    if (process.platform !== "darwin") app.quit();
  });
}

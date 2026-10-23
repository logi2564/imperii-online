const {
  app,
  BrowserWindow,
  ipcMain,
  Menu,
  session,
  shell,
} = require("electron");
const fs = require("node:fs");
const path = require("node:path");
let window,
  allowedOrigin = null;
const settingsPath = () => path.join(app.getPath("userData"), "server.json");
function readServer() {
  try {
    return JSON.parse(fs.readFileSync(settingsPath(), "utf8")).url || "";
  } catch {
    return "";
  }
}
function validate(value) {
  if (typeof value !== "string" || value.length > 2048)
    throw Error("Укажи адрес сервера.");
  let url;
  try {
    url = new URL(value.trim());
  } catch {
    throw Error("Введи полный адрес, например https://chat.example.com");
  }
  const local = ["localhost", "127.0.0.1", "[::1]"].includes(url.hostname);
  if (url.protocol !== "https:" && !(url.protocol === "http:" && local))
    throw Error(
      "Для сервера в интернете нужен адрес https://. HTTP разрешён только для localhost.",
    );
  if (url.username || url.password || url.port === "0")
    throw Error("Этот адрес не подходит.");
  if (url.pathname !== "/" && url.pathname !== "")
    throw Error(
      "Нужен адрес корня сервера, без пути. Например https://chat.example.com",
    );
  for (const key of url.searchParams.keys())
    if (!["invite", "setup"].includes(key)) url.searchParams.delete(key);
  url.hash = "";
  return url;
}
function menu() {
  Menu.setApplicationMenu(
    Menu.buildFromTemplate([
      {
        label: "Свои",
        submenu: [
          {
            label: "Сменить сервер…",
            accelerator: "CmdOrCtrl+Shift+S",
            click: () => showConnect(),
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
  window.once("ready-to-show", () => {
    window.show();
    if (old && !old.isDestroyed()) old.destroy();
  });
  window.webContents.setWindowOpenHandler(({ url }) => {
    try {
      const link = new URL(url);
      if (link.protocol === "https:" || link.protocol === "http:")
        shell.openExternal(link.href);
    } catch {}
    return { action: "deny" };
  });
  window.webContents.on("will-navigate", (event, url) => {
    try {
      if (!allowedOrigin || new URL(url).origin !== allowedOrigin)
        event.preventDefault();
    } catch {
      event.preventDefault();
    }
  });
  window.webContents.on("will-redirect", (event, url) => {
    try {
      if (allowedOrigin && new URL(url).origin !== allowedOrigin)
        event.preventDefault();
    } catch {
      event.preventDefault();
    }
  });
  return window;
}
function showConnect(error = "") {
  allowedOrigin = null;
  const win = makeWindow(true);
  win.loadFile(path.join(__dirname, "connect.html"), {
    query: error ? { error } : {},
  });
}
async function openServer(value) {
  const url = validate(value);
  allowedOrigin = url.origin;
  const win = makeWindow(false);
  const stored = url.origin + "/";
  fs.mkdirSync(app.getPath("userData"), { recursive: true });
  fs.writeFileSync(settingsPath(), JSON.stringify({ url: stored }));
  try {
    await win.loadURL(url.href);
  } catch {
    if (!win.isDestroyed())
      showConnect(
        "Не удалось открыть сервер. Проверь адрес и подключение к интернету.",
      );
  }
}
ipcMain.handle("server:current", (event) => {
  if (
    event.sender !== window?.webContents ||
    !event.sender.getURL().startsWith("file://")
  )
    return "";
  return readServer();
});
ipcMain.handle("server:connect", async (event, value) => {
  if (
    event.sender !== window?.webContents ||
    !event.sender.getURL().startsWith("file://")
  )
    return { error: "Запрос не разрешён." };
  try {
    validate(value);
    setImmediate(() =>
      openServer(value).catch((error) => showConnect(error.message)),
    );
    return { ok: true };
  } catch (error) {
    return { error: error.message };
  }
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
  app.whenReady().then(() => {
    menu();
    const allowed = (webContents, details) => {
      try {
        return (
          !!allowedOrigin &&
          webContents === window?.webContents &&
          new URL(webContents.getURL()).origin === allowedOrigin &&
          new URL(
            details.requestingUrl ||
              details.securityOrigin ||
              webContents.getURL(),
          ).origin === allowedOrigin
        );
      } catch {
        return false;
      }
    };
    session.defaultSession.setPermissionRequestHandler(
      (webContents, permission, callback, details) =>
        callback(
          permission === "media" &&
            !details.mediaTypes?.includes("video") &&
            allowed(webContents, details),
        ),
    );
    session.defaultSession.setPermissionCheckHandler(
      (webContents, permission, origin, details) =>
        permission === "media" &&
        details.mediaType !== "video" &&
        allowed(webContents, { ...details, securityOrigin: origin }),
    );
    const saved = readServer();
    if (saved) openServer(saved).catch(() => showConnect());
    else showConnect();
    app.on("activate", () => {
      if (BrowserWindow.getAllWindows().length === 0) showConnect();
    });
  });
  app.on("window-all-closed", () => {
    if (process.platform !== "darwin") app.quit();
  });
}

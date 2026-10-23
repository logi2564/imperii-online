import http from "node:http";
import { DatabaseSync } from "node:sqlite";
import {
  randomBytes,
  randomUUID,
  createHash,
  timingSafeEqual,
} from "node:crypto";
import { mkdirSync, readFileSync, writeFileSync } from "node:fs";
import { dirname, join, resolve } from "node:path";
import { fileURLToPath } from "node:url";
import { WebSocketServer, WebSocket } from "ws";

const root = dirname(fileURLToPath(import.meta.url));
const dataDir = resolve(process.env.DATA_DIR || join(root, ".data"));
mkdirSync(dataDir, { recursive: true, mode: 0o700 });
const keyPath = join(dataDir, "setup-key");
let setupKey;
try {
  setupKey = readFileSync(keyPath, "utf8").trim();
} catch (error) {
  if (error.code !== "ENOENT") throw error;
  setupKey = randomBytes(32).toString("hex");
  writeFileSync(keyPath, setupKey, { mode: 0o600, flag: "wx" });
}
const db = new DatabaseSync(join(dataDir, "chat.sqlite"));
db.exec(`PRAGMA journal_mode=WAL; PRAGMA foreign_keys=ON;
  CREATE TABLE IF NOT EXISTS meta (key TEXT PRIMARY KEY, value TEXT NOT NULL);
  CREATE TABLE IF NOT EXISTS users (id TEXT PRIMARY KEY, name TEXT NOT NULL, color TEXT NOT NULL, owner INTEGER NOT NULL DEFAULT 0, created_at INTEGER NOT NULL);
  CREATE TABLE IF NOT EXISTS sessions (hash TEXT PRIMARY KEY, user_id TEXT NOT NULL REFERENCES users(id), expires_at INTEGER NOT NULL);
  CREATE TABLE IF NOT EXISTS channels (id TEXT PRIMARY KEY, name TEXT NOT NULL COLLATE NOCASE UNIQUE, topic TEXT NOT NULL DEFAULT '', kind TEXT NOT NULL CHECK(kind IN ('text','voice')), created_at INTEGER NOT NULL);
  CREATE TABLE IF NOT EXISTS messages (id INTEGER PRIMARY KEY AUTOINCREMENT, channel_id TEXT NOT NULL REFERENCES channels(id), user_id TEXT NOT NULL REFERENCES users(id), content TEXT NOT NULL, created_at INTEGER NOT NULL);
  CREATE INDEX IF NOT EXISTS messages_channel ON messages(channel_id, id);
  CREATE TABLE IF NOT EXISTS reactions (message_id INTEGER NOT NULL REFERENCES messages(id) ON DELETE CASCADE, user_id TEXT NOT NULL REFERENCES users(id), emoji TEXT NOT NULL, PRIMARY KEY(message_id,user_id,emoji));
`);
const getMeta = (key) =>
  db.prepare("SELECT value FROM meta WHERE key=?").get(key)?.value;
const setMeta = (key, value) =>
  db.prepare("INSERT OR REPLACE INTO meta VALUES (?,?)").run(key, value);
const owner = () => db.prepare("SELECT * FROM users WHERE owner=1").get();
if (!getMeta("invite"))
  setMeta("invite", randomBytes(24).toString("base64url"));
if (!getMeta("name")) setMeta("name", "Свои люди");
if (!db.prepare("SELECT id FROM channels LIMIT 1").get()) {
  for (const [name, kind, topic] of [
    ["общий", "text", "Место, где все свои. Заходи, рассказывай, оставайся."],
    ["мемы", "text", "Здесь смеются громче всего."],
    ["игровая", "text", "Собираемся в пати и обсуждаем игры."],
    ["Гостиная", "voice", "Просто поболтать"],
    ["В игре", "voice", "На связи с командой"],
  ]) {
    db.prepare("INSERT INTO channels VALUES (?,?,?,?,?)").run(
      randomUUID(),
      name,
      topic,
      kind,
      Date.now(),
    );
  }
}
const hash = (text) => createHash("sha256").update(text).digest("hex");
const same = (a, b) =>
  typeof a === "string" &&
  typeof b === "string" &&
  Buffer.byteLength(a) === Buffer.byteLength(b) &&
  timingSafeEqual(Buffer.from(a), Buffer.from(b));
function authenticate(req) {
  const token = /(?:^|;\s*)svoi_session=([a-f0-9]{64})(?:;|$)/.exec(
    req.headers.cookie || "",
  )?.[1];
  return token
    ? db
        .prepare(
          "SELECT u.* FROM users u JOIN sessions s ON s.user_id=u.id WHERE s.hash=? AND s.expires_at>?",
        )
        .get(hash(token), Date.now())
    : null;
}
function newSession(userId, req, res) {
  const token = randomBytes(32).toString("hex");
  db.prepare("DELETE FROM sessions WHERE expires_at<?").run(Date.now());
  db.prepare("INSERT INTO sessions VALUES (?,?,?)").run(
    hash(token),
    userId,
    Date.now() + 30 * 86400000,
  );
  res.setHeader(
    "Set-Cookie",
    `svoi_session=${token}; HttpOnly; SameSite=Lax; Path=/; Max-Age=2592000${process.env.COOKIE_SECURE === "1" ? "; Secure" : ""}`,
  );
}
const sockets = new Map();
const voice = new Map();
const publicUser = (user) => ({
  id: user.id,
  name: user.name,
  color: user.color,
  owner: !!user.owner,
  online: [...sockets.values()].some((s) => s.user.id === user.id),
  voice: voice.get(user.id)?.channel || null,
  muted: voice.get(user.id)?.muted || false,
});
const users = () =>
  db
    .prepare("SELECT * FROM users ORDER BY owner DESC, created_at")
    .all()
    .map(publicUser);
const channels = () =>
  db.prepare("SELECT * FROM channels ORDER BY created_at, rowid").all();
const send = (ws, data) => {
  if (ws.readyState === WebSocket.OPEN) ws.send(JSON.stringify(data));
};
const broadcast = (data) => {
  for (const ws of sockets.keys()) send(ws, data);
};
const presence = () => broadcast({ type: "presence", users: users() });
const reactionList = (id) =>
  db.prepare("SELECT emoji, user_id FROM reactions WHERE message_id=?").all(id);
const message = (id) => {
  const m = db
    .prepare(
      "SELECT m.*,u.name,u.color FROM messages m JOIN users u ON u.id=m.user_id WHERE m.id=?",
    )
    .get(id);
  return m ? { ...m, reactions: reactionList(id) } : null;
};
const buckets = new Map();
function rate(key, limit, window = 60000) {
  const now = Date.now();
  let bucket = buckets.get(key);
  if (!bucket || bucket.until < now) {
    bucket = { count: 0, until: now + window };
    buckets.set(key, bucket);
  }
  return ++bucket.count <= limit;
}
const maintenance = setInterval(() => {
  for (const [key, b] of buckets) if (b.until < Date.now()) buckets.delete(key);
}, 60000);
maintenance.unref();
const local = (req) =>
  ["127.0.0.1", "::1", "::ffff:127.0.0.1"].includes(req.socket.remoteAddress) &&
  /^(localhost|127\.0\.0\.1|\[::1\])(?::\d+)?$/.test(req.headers.host || "");
const validSetup = (req, key) =>
  same(key, setupKey) || (!owner() && local(req));
function json(res, code, data) {
  res.writeHead(code, {
    "Content-Type": "application/json; charset=utf-8",
    "Cache-Control": "no-store",
  });
  res.end(JSON.stringify(data));
}
function fail(status, text) {
  const error = new Error(text);
  error.status = status;
  throw error;
}
async function body(req) {
  if (!req.headers["content-type"]?.startsWith("application/json"))
    fail(415, "Ожидается JSON.");
  let raw = "";
  for await (const chunk of req) {
    raw += chunk;
    if (Buffer.byteLength(raw) > 16384) fail(413, "Слишком большой запрос.");
  }
  try {
    return JSON.parse(raw);
  } catch {
    fail(400, "Не удалось прочитать запрос.");
  }
}
const clean = (value, max) =>
  typeof value === "string"
    ? value
        .trim()
        .replace(/[\u0000-\u0008\u000b\u000c\u000e-\u001f\u007f]/g, "")
        .slice(0, max)
    : "";
function leaveVoice(userId) {
  const old = voice.get(userId);
  if (!old) return;
  voice.delete(userId);
  broadcast({ type: "voice:left", userId, channelId: old.channel });
  presence();
}
const server = http.createServer(async (req, res) => {
  res.setHeader("X-Content-Type-Options", "nosniff");
  res.setHeader("Referrer-Policy", "same-origin");
  res.setHeader("X-Frame-Options", "DENY");
  res.setHeader(
    "Content-Security-Policy",
    "default-src 'self'; script-src 'self'; style-src 'self'; img-src 'self' data:; connect-src 'self'; media-src 'self' blob:; base-uri 'none'; frame-ancestors 'none'; form-action 'self'",
  );
  try {
    const url = new URL(req.url, "http://localhost");
    if (req.method === "GET" && url.pathname === "/health")
      return json(res, 200, { ok: true });
    if (url.pathname.startsWith("/api/")) {
      const user = authenticate(req);
      if (req.method !== "GET") {
        const origin = req.headers.origin;
        if (origin && new URL(origin).host !== req.headers.host)
          fail(403, "Запрос с другого сайта запрещён.");
        if (req.headers["sec-fetch-site"] === "cross-site")
          fail(403, "Запрос с другого сайта запрещён.");
        if (!rate(`http:${user?.id || req.socket.remoteAddress}`, 120))
          fail(429, "Слишком много запросов. Подожди минуту.");
      }
      if (req.method === "GET" && url.pathname === "/api/bootstrap")
        return json(res, 200, {
          name: getMeta("name"),
          needsSetup: !owner(),
          canSetup: !owner() && local(req),
          user: user ? publicUser(user) : null,
          channels: user ? channels() : [],
          users: user ? users() : [],
          invite: user?.owner ? getMeta("invite") : undefined,
        });
      if (req.method === "POST" && url.pathname === "/api/join") {
        const data = await body(req);
        if (!rate(`join:${req.socket.remoteAddress}`, 20))
          fail(429, "Слишком много попыток. Подожди минуту.");
        if (owner() && same(data.setup, setupKey)) {
          newSession(owner().id, req, res);
          return json(res, 200, { ok: true });
        }
        const name = clean(data.name, 24);
        if (name.length < 2)
          fail(400, "Имя должно содержать от 2 до 24 символов.");
        const first = !owner();
        if (
          first
            ? !validSetup(req, data.setup)
            : !same(data.invite, getMeta("invite"))
        )
          fail(
            403,
            first
              ? "Нужна ссылка первоначальной настройки с сервера."
              : "Приглашение не подходит. Попроси новую ссылку у владельца.",
          );
        if (
          db
            .prepare("SELECT id FROM users WHERE lower(name)=lower(?)")
            .get(name)
        )
          fail(409, "Это имя уже занято. Выбери другое.");
        const id = randomUUID(),
          palette = [
            "#8c82ff",
            "#ea9a68",
            "#e786ad",
            "#69bfaa",
            "#76b1ed",
            "#d2b664",
          ];
        const color =
          palette[
            db.prepare("SELECT count(*) AS n FROM users").get().n %
              palette.length
          ];
        db.prepare("INSERT INTO users VALUES (?,?,?,?,?)").run(
          id,
          name,
          color,
          first ? 1 : 0,
          Date.now(),
        );
        if (first) setMeta("name", clean(data.community, 40) || "Свои люди");
        newSession(id, req, res);
        presence();
        return json(res, 201, { ok: true });
      }
      if (!user) fail(401, "Войди по приглашению, чтобы продолжить.");
      if (req.method === "GET" && url.pathname === "/api/rtc") {
        let iceServers = [{ urls: "stun:stun.l.google.com:19302" }];
        if (process.env.RTC_ICE_SERVERS) {
          try {
            const config = JSON.parse(process.env.RTC_ICE_SERVERS);
            if (!Array.isArray(config)) throw new Error();
            iceServers = config;
          } catch {
            fail(500, "Администратору нужно проверить RTC_ICE_SERVERS.");
          }
        }
        return json(res, 200, { iceServers });
      }
      if (req.method === "POST" && url.pathname === "/api/logout") {
        const token = /(?:^|;\s*)svoi_session=([a-f0-9]{64})/.exec(
          req.headers.cookie || "",
        )?.[1];
        if (token)
          db.prepare("DELETE FROM sessions WHERE hash=?").run(hash(token));
        for (const [ws, info] of sockets)
          if (info.session === hash(token || "")) ws.close(4001, "Logged out");
        res.setHeader(
          "Set-Cookie",
          "svoi_session=; HttpOnly; SameSite=Lax; Path=/; Max-Age=0",
        );
        return json(res, 200, { ok: true });
      }
      if (req.method === "GET" && url.pathname === "/api/messages") {
        const channelId = url.searchParams.get("channel");
        if (
          !db
            .prepare("SELECT id FROM channels WHERE id=? AND kind='text'")
            .get(channelId)
        )
          fail(404, "Канал не найден.");
        const before =
          Number(url.searchParams.get("before")) || Number.MAX_SAFE_INTEGER;
        const list = db
          .prepare(
            "SELECT id FROM messages WHERE channel_id=? AND id<? ORDER BY id DESC LIMIT 50",
          )
          .all(channelId, before)
          .reverse()
          .map((m) => message(m.id));
        return json(res, 200, { messages: list, hasMore: list.length === 50 });
      }
      if (req.method === "POST" && url.pathname === "/api/channels") {
        if (!user.owner) fail(403, "Каналы создаёт владелец пространства.");
        const data = await body(req);
        const name = clean(data.name, 32).replace(/\s+/g, "-");
        if (!name || !["text", "voice"].includes(data.kind))
          fail(400, "Укажи имя и тип канала.");
        if (channels().length >= 30)
          fail(400, "В пространстве уже 30 каналов.");
        if (
          db
            .prepare("SELECT id FROM channels WHERE name=? COLLATE NOCASE")
            .get(name)
        )
          fail(409, "Канал с таким именем уже есть.");
        const id = randomUUID();
        db.prepare("INSERT INTO channels VALUES (?,?,?,?,?)").run(
          id,
          name,
          clean(data.topic, 140),
          data.kind,
          Date.now(),
        );
        broadcast({ type: "channels", channels: channels() });
        return json(res, 201, { id });
      }
      if (req.method === "POST" && url.pathname === "/api/invite/rotate") {
        if (!user.owner) fail(403, "Приглашениями управляет владелец.");
        const invite = randomBytes(24).toString("base64url");
        setMeta("invite", invite);
        return json(res, 200, { invite });
      }
      fail(404, "Не найдено.");
    }
    if (!["GET", "HEAD"].includes(req.method))
      fail(405, "Метод не поддерживается.");
    const files = {
      "/": "index.html",
      "/chat/": "index.html",
      "/app.js": "app.js",
      "/styles.css": "styles.css",
      "/icon.svg": "icon.svg",
    };
    const file = files[url.pathname];
    if (!file) fail(404, "Страница не найдена.");
    const type = file.endsWith(".js")
      ? "text/javascript"
      : file.endsWith(".css")
        ? "text/css"
        : file.endsWith(".svg")
          ? "image/svg+xml"
          : "text/html";
    const content = readFileSync(join(root, "chat", file));
    res.writeHead(200, {
      "Content-Type": type + "; charset=utf-8",
      "Cache-Control": "no-cache",
    });
    res.end(req.method === "HEAD" ? undefined : content);
  } catch (error) {
    if (!error.status) console.error(error);
    if (!res.headersSent)
      json(res, error.status || 500, {
        error: error.status
          ? error.message
          : "Ошибка сервера. Попробуй ещё раз.",
      });
    else res.end();
  }
});
const wss = new WebSocketServer({ noServer: true, maxPayload: 16384 });
server.on("upgrade", (req, socket, head) => {
  let user;
  try {
    if (
      new URL(req.url, "http://localhost").pathname !== "/ws" ||
      !req.headers.origin ||
      new URL(req.headers.origin).host !== req.headers.host ||
      !(user = authenticate(req))
    ) {
      socket.end("HTTP/1.1 401 Unauthorized\r\nConnection: close\r\n\r\n");
      return;
    }
    if (
      [...sockets.values()].filter((s) => s.user.id === user.id).length >= 5
    ) {
      socket.end("HTTP/1.1 429 Too Many Requests\r\n\r\n");
      return;
    }
    wss.handleUpgrade(req, socket, head, (ws) =>
      wss.emit("connection", ws, user, req),
    );
  } catch {
    socket.destroy();
  }
});
const EMOJI = ["❤️", "😂", "🔥", "👍", "🎉", "👀"];
wss.on("connection", (ws, user, req) => {
  const token = /(?:^|;\s*)svoi_session=([a-f0-9]{64})/.exec(
    req.headers.cookie || "",
  )?.[1];
  sockets.set(ws, { user, session: hash(token || "") });
  ws.isAlive = true;
  ws.on("pong", () => {
    ws.isAlive = true;
  });
  presence();
  send(ws, { type: "ready" });
  ws.on("message", (raw) => {
    try {
      if (!rate(`ws:${user.id}`, 180, 10000))
        return send(ws, {
          type: "error",
          message: "Слишком много действий. Немного подожди.",
        });
      const data = JSON.parse(raw.toString());
      if (data.type === "message") {
        const content = clean(data.content, 2000);
        if (
          !content ||
          typeof data.channelId !== "string" ||
          !db
            .prepare("SELECT id FROM channels WHERE id=? AND kind='text'")
            .get(data.channelId)
        )
          return;
        if (!rate(`message:${user.id}`, 30, 10000))
          return send(ws, {
            type: "error",
            message: "Помедленнее: не больше 30 сообщений за 10 секунд.",
          });
        const id = db
          .prepare(
            "INSERT INTO messages (channel_id,user_id,content,created_at) VALUES (?,?,?,?)",
          )
          .run(data.channelId, user.id, content, Date.now()).lastInsertRowid;
        broadcast({
          type: "message",
          message: message(Number(id)),
          nonce: clean(data.nonce, 64),
        });
      } else if (data.type === "delete") {
        const m = message(Number(data.id));
        if (!m || (m.user_id !== user.id && !user.owner)) return;
        db.prepare("DELETE FROM messages WHERE id=?").run(m.id);
        broadcast({ type: "deleted", id: m.id, channelId: m.channel_id });
      } else if (data.type === "reaction") {
        if (!EMOJI.includes(data.emoji) || !message(Number(data.id))) return;
        const id = Number(data.id);
        const existing = db
          .prepare(
            "SELECT 1 FROM reactions WHERE message_id=? AND user_id=? AND emoji=?",
          )
          .get(id, user.id, data.emoji);
        if (existing)
          db.prepare(
            "DELETE FROM reactions WHERE message_id=? AND user_id=? AND emoji=?",
          ).run(id, user.id, data.emoji);
        else
          db.prepare("INSERT INTO reactions VALUES (?,?,?)").run(
            id,
            user.id,
            data.emoji,
          );
        broadcast({ type: "reactions", id, reactions: reactionList(id) });
      } else if (data.type === "typing") {
        if (
          typeof data.channelId === "string" &&
          rate(`typing:${user.id}`, 1, 1500)
        )
          broadcast({
            type: "typing",
            userId: user.id,
            channelId: data.channelId,
          });
      } else if (data.type === "voice:join") {
        if (
          !db
            .prepare("SELECT id FROM channels WHERE id=? AND kind='voice'")
            .get(clean(data.channelId, 64))
        )
          return;
        const old = voice.get(user.id);
        if (old?.ws !== ws && old) send(old.ws, { type: "voice:replaced" });
        leaveVoice(user.id);
        const peers = [...voice.entries()]
          .filter(([, v]) => v.channel === data.channelId)
          .map(([id]) => id);
        voice.set(user.id, {
          channel: data.channelId,
          ws,
          muted: !!data.muted,
        });
        send(ws, { type: "voice:peers", peers, channelId: data.channelId });
        presence();
      } else if (data.type === "voice:leave") {
        if (voice.get(user.id)?.ws === ws) leaveVoice(user.id);
      } else if (data.type === "voice:mute") {
        const v = voice.get(user.id);
        if (v?.ws === ws) {
          v.muted = !!data.muted;
          presence();
        }
      } else if (data.type === "signal") {
        const from = voice.get(user.id),
          to = voice.get(data.to);
        if (from?.ws !== ws || !to || to.channel !== from.channel) return;
        if (
          data.description &&
          ["offer", "answer"].includes(data.description.type) &&
          typeof data.description.sdp === "string"
        )
          send(to.ws, {
            type: "signal",
            from: user.id,
            description: data.description,
          });
        else if (data.candidate && typeof data.candidate === "object")
          send(to.ws, {
            type: "signal",
            from: user.id,
            candidate: data.candidate,
          });
      }
    } catch {
      send(ws, { type: "error", message: "Не удалось выполнить действие." });
    }
  });
  ws.on("error", () => {});
  ws.on("close", () => {
    sockets.delete(ws);
    if (voice.get(user.id)?.ws === ws) leaveVoice(user.id);
    presence();
  });
});
const heartbeat = setInterval(() => {
  for (const ws of sockets.keys()) {
    if (!ws.isAlive) ws.terminate();
    else {
      ws.isAlive = false;
      ws.ping();
    }
  }
}, 30000);
heartbeat.unref();
const port = Number(process.env.PORT || 3000);
server.listen(port, process.env.BIND || "127.0.0.1", () =>
  console.log(
    `Свои — http://${process.env.BIND || "127.0.0.1"}:${server.address().port}`,
  ),
);
function shutdown() {
  clearInterval(heartbeat);
  clearInterval(maintenance);
  for (const ws of sockets.keys()) ws.terminate();
  wss.close();
  server.close(() => {
    db.close();
    process.exit(0);
  });
}
process.on("SIGINT", shutdown);
process.on("SIGTERM", shutdown);

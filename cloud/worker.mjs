import { DurableObject } from "cloudflare:workers";

const SECURITY = {
  "X-Content-Type-Options": "nosniff",
  "Referrer-Policy": "same-origin",
  "X-Frame-Options": "DENY",
  "Content-Security-Policy":
    "default-src 'self'; script-src 'self'; style-src 'self'; img-src 'self' data:; connect-src 'self'; media-src 'self' blob:; base-uri 'none'; frame-ancestors 'none'; form-action 'self'",
};
const EMOJI = ["❤️", "😂", "🔥", "👍", "🎉", "👀"];
const clean = (v, n) =>
  typeof v === "string"
    ? v
        .trim()
        .replace(/[\u0000-\u0008\u000b\u000c\u000e-\u001f\u007f]/g, "")
        .slice(0, n)
    : "";
const randomHex = (n) =>
  [...crypto.getRandomValues(new Uint8Array(n))]
    .map((v) => v.toString(16).padStart(2, "0"))
    .join("");
async function hash(value) {
  return [
    ...new Uint8Array(
      await crypto.subtle.digest("SHA-256", new TextEncoder().encode(value)),
    ),
  ]
    .map((v) => v.toString(16).padStart(2, "0"))
    .join("");
}
function same(a, b) {
  if (typeof a !== "string" || typeof b !== "string") return false;
  const x = new TextEncoder().encode(a),
    y = new TextEncoder().encode(b);
  if (x.length !== y.length) return false;
  let diff = 0;
  for (let i = 0; i < x.length; i++) diff |= x[i] ^ y[i];
  return diff === 0;
}
const json = (data, status = 200, extra = {}) =>
  new Response(JSON.stringify(data), {
    status,
    headers: {
      ...SECURITY,
      "Content-Type": "application/json; charset=utf-8",
      "Cache-Control": "no-store",
      ...extra,
    },
  });
function fail(status, message) {
  throw Object.assign(new Error(message), { status });
}
async function readBody(request) {
  if (!request.headers.get("content-type")?.startsWith("application/json"))
    fail(415, "Ожидается JSON.");
  const reader = request.body?.getReader();
  if (!reader) fail(400, "Пустой запрос.");
  let size = 0,
    chunks = [];
  while (true) {
    const { done, value } = await reader.read();
    if (done) break;
    size += value.byteLength;
    if (size > 16384) {
      await reader.cancel();
      fail(413, "Слишком большой запрос.");
    }
    chunks.push(value);
  }
  const bytes = new Uint8Array(size);
  let offset = 0;
  for (const chunk of chunks) {
    bytes.set(chunk, offset);
    offset += chunk.length;
  }
  try {
    const result = JSON.parse(new TextDecoder().decode(bytes));
    if (!result || typeof result !== "object") throw Error();
    return result;
  } catch {
    fail(400, "Не удалось прочитать запрос.");
  }
}
const cookieToken = (request) =>
  /(?:^|;\s*)svoi_session=([a-f0-9]{64})(?:;|$)/.exec(
    request.headers.get("cookie") || "",
  )?.[1];

export default {
  async fetch(request, env) {
    const url = new URL(request.url);
    if (url.pathname === "/health")
      return json({ ok: true, app: "svoi", protocol: 1 });
    if (url.pathname.startsWith("/api/") || url.pathname === "/ws")
      return env.COMMUNITY.get(
        env.COMMUNITY.idFromName("svoi-community-v1"),
      ).fetch(request);
    const assetRequest =
      url.pathname === "/chat/"
        ? new Request(new URL("/", url), request)
        : request;
    const response = await env.ASSETS.fetch(assetRequest);
    const headers = new Headers(response.headers);
    for (const [key, value] of Object.entries(SECURITY))
      headers.set(key, value);
    return new Response(response.body, { status: response.status, headers });
  },
};

export class Community extends DurableObject {
  constructor(ctx, env) {
    super(ctx, env);
    this.sql = ctx.storage.sql;
    this.sockets = new Map();
    this.voice = new Map();
    this.buckets = new Map();
    this.sql.exec(`
      CREATE TABLE IF NOT EXISTS meta (key TEXT PRIMARY KEY, value TEXT NOT NULL);
      CREATE TABLE IF NOT EXISTS users (id TEXT PRIMARY KEY, name TEXT NOT NULL, color TEXT NOT NULL, owner INTEGER NOT NULL DEFAULT 0, created_at INTEGER NOT NULL);
      CREATE TABLE IF NOT EXISTS sessions (hash TEXT PRIMARY KEY, user_id TEXT NOT NULL REFERENCES users(id), expires_at INTEGER NOT NULL);
      CREATE TABLE IF NOT EXISTS channels (id TEXT PRIMARY KEY, name TEXT NOT NULL COLLATE NOCASE UNIQUE, topic TEXT NOT NULL DEFAULT '', kind TEXT NOT NULL CHECK(kind IN ('text','voice')), created_at INTEGER NOT NULL);
      CREATE TABLE IF NOT EXISTS messages (id INTEGER PRIMARY KEY AUTOINCREMENT, channel_id TEXT NOT NULL REFERENCES channels(id), user_id TEXT NOT NULL REFERENCES users(id), content TEXT NOT NULL, created_at INTEGER NOT NULL);
      CREATE INDEX IF NOT EXISTS messages_channel ON messages(channel_id,id);
      CREATE TABLE IF NOT EXISTS reactions (message_id INTEGER NOT NULL REFERENCES messages(id) ON DELETE CASCADE, user_id TEXT NOT NULL REFERENCES users(id), emoji TEXT NOT NULL, PRIMARY KEY(message_id,user_id,emoji));
    `);
    if (!this.meta("invite")) this.setMeta("invite", randomHex(24));
    if (!this.meta("name")) this.setMeta("name", "Свои люди");
    if (!this.one("SELECT id FROM channels LIMIT 1")) {
      for (const [i, [name, kind, topic]] of [
        [
          "общий",
          "text",
          "Место, где все свои. Заходи, рассказывай, оставайся.",
        ],
        ["мемы", "text", "Здесь смеются громче всего."],
        ["игровая", "text", "Собираемся в пати и обсуждаем игры."],
        ["Гостиная", "voice", "Просто поболтать"],
        ["В игре", "voice", "На связи с командой"],
      ].entries())
        this.sql.exec(
          "INSERT INTO channels VALUES (?,?,?,?,?)",
          crypto.randomUUID(),
          name,
          topic,
          kind,
          Date.now() + i,
        );
    }
    // Attachments preserve presence and voice membership when the object hibernates.
    for (const ws of ctx.getWebSockets()) {
      const info = ws.deserializeAttachment();
      if (!info?.user) continue;
      this.sockets.set(ws, info);
      if (info.voice) this.voice.set(info.user.id, { ...info.voice, ws });
    }
  }
  all(query, ...args) {
    return [...this.sql.exec(query, ...args)];
  }
  one(query, ...args) {
    return this.all(query, ...args)[0];
  }
  meta(key) {
    return this.one("SELECT value FROM meta WHERE key=?", key)?.value;
  }
  setMeta(key, value) {
    this.sql.exec("INSERT OR REPLACE INTO meta VALUES (?,?)", key, value);
  }
  owner() {
    return this.one("SELECT * FROM users WHERE owner=1");
  }
  channels() {
    return this.all("SELECT * FROM channels ORDER BY created_at,rowid");
  }
  publicUser(user) {
    return {
      id: user.id,
      name: user.name,
      color: user.color,
      owner: !!user.owner,
      online: [...this.sockets.values()].some((s) => s.user.id === user.id),
      voice: this.voice.get(user.id)?.channel || null,
      muted: this.voice.get(user.id)?.muted || false,
    };
  }
  users() {
    return this.all("SELECT * FROM users ORDER BY owner DESC,created_at").map(
      (u) => this.publicUser(u),
    );
  }
  reactions(id) {
    return this.all(
      "SELECT emoji,user_id FROM reactions WHERE message_id=?",
      id,
    );
  }
  message(id) {
    const value = this.one(
      "SELECT m.*,u.name,u.color FROM messages m JOIN users u ON u.id=m.user_id WHERE m.id=?",
      id,
    );
    return value ? { ...value, reactions: this.reactions(id) } : null;
  }
  send(ws, data) {
    try {
      if (ws.readyState === 1) ws.send(JSON.stringify(data));
    } catch {}
  }
  broadcast(data) {
    for (const ws of this.sockets.keys()) this.send(ws, data);
  }
  presence() {
    this.broadcast({ type: "presence", users: this.users() });
  }
  rate(key, limit, window = 60000) {
    const now = Date.now();
    let bucket = this.buckets.get(key);
    if (!bucket || bucket.until < now) {
      bucket = { count: 0, until: now + window };
      this.buckets.set(key, bucket);
    }
    if (this.buckets.size > 5000)
      for (const [k, b] of this.buckets)
        if (b.until < now) this.buckets.delete(k);
    return ++bucket.count <= limit;
  }
  async authenticate(request) {
    const token = cookieToken(request);
    if (!token) return null;
    return this.one(
      "SELECT u.* FROM users u JOIN sessions s ON s.user_id=u.id WHERE s.hash=? AND s.expires_at>?",
      await hash(token),
      Date.now(),
    );
  }
  async session(userId, request) {
    const token = randomHex(32);
    this.sql.exec("DELETE FROM sessions WHERE expires_at<?", Date.now());
    this.sql.exec(
      "INSERT INTO sessions VALUES (?,?,?)",
      await hash(token),
      userId,
      Date.now() + 30 * 86400000,
    );
    return `svoi_session=${token}; HttpOnly; SameSite=Lax; Path=/; Max-Age=2592000${new URL(request.url).protocol === "https:" ? "; Secure" : ""}`;
  }
  rememberVoice(ws, value) {
    const info = this.sockets.get(ws);
    if (!info) return;
    info.voice = value;
    ws.serializeAttachment(info);
  }
  leaveVoice(userId) {
    const old = this.voice.get(userId);
    if (!old) return;
    this.voice.delete(userId);
    this.rememberVoice(old.ws, null);
    this.broadcast({ type: "voice:left", userId, channelId: old.channel });
    this.presence();
  }
  async fetch(request) {
    try {
      const url = new URL(request.url),
        user = await this.authenticate(request);
      if (url.pathname === "/ws") return await this.upgrade(request, user);
      if (request.method !== "GET") {
        const origin = request.headers.get("origin");
        if (origin && origin !== url.origin)
          fail(403, "Запрос с другого сайта запрещён.");
        if (request.headers.get("sec-fetch-site") === "cross-site")
          fail(403, "Запрос с другого сайта запрещён.");
        if (
          !this.rate(
            "http:" +
              (user?.id || request.headers.get("cf-connecting-ip") || "local"),
            120,
          )
        )
          fail(429, "Слишком много запросов. Подожди минуту.");
      }
      if (request.method === "GET" && url.pathname === "/api/bootstrap")
        return json({
          name: this.meta("name"),
          needsSetup: !this.owner(),
          canSetup: false,
          setupMethod: "key",
          user: user ? this.publicUser(user) : null,
          channels: user ? this.channels() : [],
          users: user ? this.users() : [],
          invite: user?.owner ? this.meta("invite") : undefined,
        });
      if (request.method === "POST" && url.pathname === "/api/join") {
        const data = await readBody(request);
        const setupValid =
          typeof this.env.SVOI_SETUP_KEY === "string" &&
          this.env.SVOI_SETUP_KEY.length >= 32 &&
          same(data.setup, this.env.SVOI_SETUP_KEY);
        if (
          !this.rate(
            "join:" + (request.headers.get("cf-connecting-ip") || "local"),
            20,
          )
        )
          fail(429, "Слишком много попыток. Подожди минуту.");
        if (this.owner() && setupValid)
          return json({ ok: true }, 200, {
            "Set-Cookie": await this.session(this.owner().id, request),
          });
        const first = !this.owner(),
          name = clean(data.name, 24);
        if (name.length < 2)
          fail(400, "Имя должно содержать от 2 до 24 символов.");
        if (
          first &&
          (!this.env.SVOI_SETUP_KEY || this.env.SVOI_SETUP_KEY.length < 32)
        )
          fail(503, "Владелец ещё не завершил настройку онлайн-сервиса.");
        if (first ? !setupValid : !same(data.invite, this.meta("invite")))
          fail(
            403,
            first
              ? "Код создателя не подходит."
              : "Приглашение не подходит. Попроси новую ссылку у владельца.",
          );
        if (this.one("SELECT id FROM users WHERE lower(name)=lower(?)", name))
          fail(409, "Это имя уже занято. Выбери другое.");
        const id = crypto.randomUUID(),
          palette = [
            "#8c82ff",
            "#ea9a68",
            "#e786ad",
            "#69bfaa",
            "#76b1ed",
            "#d2b664",
          ];
        this.sql.exec(
          "INSERT INTO users VALUES (?,?,?,?,?)",
          id,
          name,
          palette[
            this.one("SELECT count(*) AS n FROM users").n % palette.length
          ],
          first ? 1 : 0,
          Date.now(),
        );
        if (first)
          this.setMeta("name", clean(data.community, 40) || "Свои люди");
        const cookie = await this.session(id, request);
        this.presence();
        return json({ ok: true }, 201, { "Set-Cookie": cookie });
      }
      if (!user) fail(401, "Войди по приглашению, чтобы продолжить.");
      if (request.method === "GET" && url.pathname === "/api/rtc") {
        let iceServers = [{ urls: "stun:stun.l.google.com:19302" }];
        if (this.env.RTC_ICE_SERVERS) {
          try {
            iceServers = JSON.parse(this.env.RTC_ICE_SERVERS);
            if (!Array.isArray(iceServers)) throw Error();
          } catch {
            fail(500, "Администратору нужно проверить RTC_ICE_SERVERS.");
          }
        }
        return json({ iceServers });
      }
      if (request.method === "POST" && url.pathname === "/api/logout") {
        const sessionHash = await hash(cookieToken(request) || "");
        this.sql.exec("DELETE FROM sessions WHERE hash=?", sessionHash);
        for (const [ws, info] of this.sockets)
          if (info.session === sessionHash) {
            this.cleanup(ws);
            ws.close(4001, "Logged out");
          }
        return json({ ok: true }, 200, {
          "Set-Cookie":
            "svoi_session=; HttpOnly; SameSite=Lax; Path=/; Max-Age=0",
        });
      }
      if (request.method === "GET" && url.pathname === "/api/messages") {
        const channelId = url.searchParams.get("channel");
        if (
          !this.one(
            "SELECT id FROM channels WHERE id=? AND kind='text'",
            channelId,
          )
        )
          fail(404, "Канал не найден.");
        const before =
          Number(url.searchParams.get("before")) || Number.MAX_SAFE_INTEGER;
        const messages = this.all(
          "SELECT id FROM messages WHERE channel_id=? AND id<? ORDER BY id DESC LIMIT 50",
          channelId,
          before,
        )
          .reverse()
          .map((m) => this.message(m.id));
        return json({ messages, hasMore: messages.length === 50 });
      }
      if (request.method === "POST" && url.pathname === "/api/channels") {
        if (!user.owner) fail(403, "Каналы создаёт владелец пространства.");
        const data = await readBody(request),
          name = clean(data.name, 32).replace(/\s+/g, "-");
        if (!name || !["text", "voice"].includes(data.kind))
          fail(400, "Укажи имя и тип канала.");
        if (this.channels().length >= 30)
          fail(400, "В пространстве уже 30 каналов.");
        if (
          this.one("SELECT id FROM channels WHERE name=? COLLATE NOCASE", name)
        )
          fail(409, "Канал с таким именем уже есть.");
        const id = crypto.randomUUID();
        this.sql.exec(
          "INSERT INTO channels VALUES (?,?,?,?,?)",
          id,
          name,
          clean(data.topic, 140),
          data.kind,
          Date.now(),
        );
        this.broadcast({ type: "channels", channels: this.channels() });
        return json({ id }, 201);
      }
      if (request.method === "POST" && url.pathname === "/api/invite/rotate") {
        if (!user.owner) fail(403, "Приглашениями управляет владелец.");
        const invite = randomHex(24);
        this.setMeta("invite", invite);
        return json({ invite });
      }
      fail(404, "Не найдено.");
    } catch (error) {
      if (!error.status)
        console.error("Community request failed:", error.message);
      return json(
        {
          error: error.status
            ? error.message
            : "Ошибка сервера. Попробуй ещё раз.",
        },
        error.status || 500,
      );
    }
  }
  async upgrade(request, user) {
    if (request.headers.get("upgrade")?.toLowerCase() !== "websocket")
      fail(426, "Нужен WebSocket.");
    if (!user || request.headers.get("origin") !== new URL(request.url).origin)
      fail(401, "Войди по приглашению.");
    if (
      [...this.sockets.values()].filter((s) => s.user.id === user.id).length >=
      5
    )
      fail(429, "Слишком много подключений.");
    const [client, server] = Object.values(new WebSocketPair());
    this.ctx.acceptWebSocket(server);
    const sessionHash = await hash(cookieToken(request));
    const info = {
      user,
      session: sessionHash,
      expiresAt: this.one(
        "SELECT expires_at FROM sessions WHERE hash=?",
        sessionHash,
      ).expires_at,
      voice: null,
    };
    server.serializeAttachment(info);
    this.sockets.set(server, info);
    this.presence();
    this.send(server, { type: "ready" });
    return new Response(null, { status: 101, webSocket: client });
  }
  webSocketMessage(ws, raw) {
    const info = this.sockets.get(ws);
    if (!info) return;
    if (info.expiresAt < Date.now()) {
      this.cleanup(ws);
      ws.close(4001, "Session expired");
      return;
    }
    if (
      typeof raw !== "string" ||
      new TextEncoder().encode(raw).length > 16384
    ) {
      this.cleanup(ws);
      ws.close(1009, "Unsupported message");
      return;
    }
    try {
      const user = info.user;
      if (!this.rate("ws:" + user.id, 180, 10000))
        return this.send(ws, {
          type: "error",
          message: "Слишком много действий. Немного подожди.",
        });
      const data = JSON.parse(raw);
      if (data.type === "message") {
        const content = clean(data.content, 2000);
        if (
          !content ||
          typeof data.channelId !== "string" ||
          !this.one(
            "SELECT id FROM channels WHERE id=? AND kind='text'",
            data.channelId,
          )
        )
          return;
        if (!this.rate("message:" + user.id, 30, 10000))
          return this.send(ws, {
            type: "error",
            message: "Помедленнее: не больше 30 сообщений за 10 секунд.",
          });
        const { id } = this.one(
          "INSERT INTO messages (channel_id,user_id,content,created_at) VALUES (?,?,?,?) RETURNING id",
          data.channelId,
          user.id,
          content,
          Date.now(),
        );
        this.broadcast({
          type: "message",
          message: this.message(id),
          nonce: clean(data.nonce, 64),
        });
      } else if (data.type === "delete") {
        const m = this.message(Number(data.id));
        if (!m || (m.user_id !== user.id && !user.owner)) return;
        this.sql.exec("DELETE FROM messages WHERE id=?", m.id);
        this.broadcast({ type: "deleted", id: m.id, channelId: m.channel_id });
      } else if (data.type === "reaction") {
        const id = Number(data.id);
        if (!EMOJI.includes(data.emoji) || !this.message(id)) return;
        if (
          this.one(
            "SELECT 1 FROM reactions WHERE message_id=? AND user_id=? AND emoji=?",
            id,
            user.id,
            data.emoji,
          )
        )
          this.sql.exec(
            "DELETE FROM reactions WHERE message_id=? AND user_id=? AND emoji=?",
            id,
            user.id,
            data.emoji,
          );
        else
          this.sql.exec(
            "INSERT INTO reactions VALUES (?,?,?)",
            id,
            user.id,
            data.emoji,
          );
        this.broadcast({
          type: "reactions",
          id,
          reactions: this.reactions(id),
        });
      } else if (data.type === "typing") {
        if (
          typeof data.channelId === "string" &&
          this.rate("typing:" + user.id, 1, 1500)
        )
          this.broadcast({
            type: "typing",
            userId: user.id,
            channelId: data.channelId,
          });
      } else if (data.type === "voice:join") {
        if (
          !this.one(
            "SELECT id FROM channels WHERE id=? AND kind='voice'",
            clean(data.channelId, 64),
          )
        )
          return;
        const old = this.voice.get(user.id);
        if (old && old.ws !== ws) this.send(old.ws, { type: "voice:replaced" });
        this.leaveVoice(user.id);
        const peers = [...this.voice.entries()]
          .filter(([, v]) => v.channel === data.channelId)
          .map(([id]) => id);
        const value = { channel: data.channelId, muted: !!data.muted };
        this.voice.set(user.id, { ...value, ws });
        this.rememberVoice(ws, value);
        this.send(ws, {
          type: "voice:peers",
          peers,
          channelId: data.channelId,
        });
        this.presence();
      } else if (data.type === "voice:leave") {
        if (this.voice.get(user.id)?.ws === ws) this.leaveVoice(user.id);
      } else if (data.type === "voice:mute") {
        const v = this.voice.get(user.id);
        if (v?.ws === ws) {
          v.muted = !!data.muted;
          this.rememberVoice(ws, { channel: v.channel, muted: v.muted });
          this.presence();
        }
      } else if (data.type === "signal") {
        const from = this.voice.get(user.id),
          to = this.voice.get(data.to);
        if (from?.ws !== ws || !to || to.channel !== from.channel) return;
        if (
          data.description &&
          ["offer", "answer"].includes(data.description.type) &&
          typeof data.description.sdp === "string"
        )
          this.send(to.ws, {
            type: "signal",
            from: user.id,
            description: data.description,
          });
        else if (data.candidate && typeof data.candidate === "object")
          this.send(to.ws, {
            type: "signal",
            from: user.id,
            candidate: data.candidate,
          });
      }
    } catch {
      this.send(ws, {
        type: "error",
        message: "Не удалось выполнить действие.",
      });
    }
  }
  cleanup(ws) {
    const info = this.sockets.get(ws);
    if (!info) return;
    this.sockets.delete(ws);
    if (this.voice.get(info.user.id)?.ws === ws) this.leaveVoice(info.user.id);
    else this.presence();
  }
  webSocketClose(ws, code, reason) {
    this.cleanup(ws);
    if (ws.readyState !== 3) ws.close(code, reason);
  }
  webSocketError(ws) {
    this.cleanup(ws);
  }
}

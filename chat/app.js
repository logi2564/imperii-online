"use strict";
const $ = (id) => document.getElementById(id);
const paths = {
  hash: "M5 9h14M4 15h14M11 3 7 21M17 3l-4 18",
  plus: "M12 5v14M5 12h14",
  x: "m6 6 12 12M18 6 6 18",
  chevronDown: "m6 9 6 6 6-6",
  arrowRight: "M4 12h16m-6-6 6 6-6 6",
  userPlus:
    "M16 21v-2a4 4 0 0 0-4-4H6a4 4 0 0 0-4 4v2M9 11a4 4 0 1 0 0-8 4 4 0 0 0 0 8M20 8v6m-3-3h6",
  users:
    "M16 21v-2a4 4 0 0 0-4-4H6a4 4 0 0 0-4 4v2M9 11a4 4 0 1 0 0-8 4 4 0 0 0 0 8M22 21v-2a4 4 0 0 0-3-3.87M16 3.13a4 4 0 0 1 0 7.75",
  search: "m21 21-4.4-4.4M19 10.5a8.5 8.5 0 1 1-17 0 8.5 8.5 0 0 1 17 0",
  mic: "M12 3a3 3 0 0 0-3 3v6a3 3 0 0 0 6 0V6a3 3 0 0 0-3-3M5 10v2a7 7 0 0 0 14 0v-2M12 19v3m-4 0h8",
  micOff:
    "m3 3 18 18M9 9v3a3 3 0 0 0 5.12 2.12M15 9V6a3 3 0 0 0-5.1-2.1M5 10v2a7 7 0 0 0 12 4.9M19 10v2M12 19v3m-4 0h8",
  headphones:
    "M3 14v-3a9 9 0 0 1 18 0v3M3 13h3v8H4a1 1 0 0 1-1-1v-7M21 13h-3v8h2a1 1 0 0 0 1-1v-7",
  volume: "m11 5-6 4H2v6h3l6 4V5M15.5 8.5a5 5 0 0 1 0 7M19 5a10 10 0 0 1 0 14",
  volumeOff: "m11 5-6 4H2v6h3l6 4V5m5 4 6 6m0-6-6 6",
  phoneOff:
    "m3 3 18 18M7 7l3 3-2 2a14 14 0 0 0 4 4l2-2 6 3-1 4c-1 2-8-1-12-5S0 5 2 4M13 3h5l3 6-4 2",
  smile:
    "M21 12a9 9 0 1 1-18 0 9 9 0 0 1 18 0M8 14s1 3 4 3 4-3 4-3M8 9h.01M16 9h.01",
  send: "m22 2-7 20-4-9-9-4 20-7ZM22 2 11 13",
  help: "M21 12a9 9 0 1 1-18 0 9 9 0 0 1 18 0M9.1 9a3 3 0 0 1 5.8 1c0 2-3 3-3 3m.1 4h.01",
  lock: "M5 11h14v10H5V11Zm3 0V7a4 4 0 0 1 8 0v4",
  sparkles:
    "m12 3 2.4 6.6L21 12l-6.6 2.4L12 21l-2.4-6.6L3 12l6.6-2.4L12 3ZM20 2v4m-2-2h4",
  menu: "M4 6h16M4 12h16M4 18h16",
  trash: "M3 6h18M9 6V3h6v3M5 6l1 15h12l1-15M10 10v7m4-7v7",
  copy: "M9 9h12v12H9V9ZM15 9V3H3v12h6",
};
function icon(name) {
  return `<svg viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" aria-hidden="true"><path d="${paths[name] || paths.hash}"/></svg>`;
}
document.querySelectorAll("[data-icon]").forEach((e) => {
  e.innerHTML = icon(e.dataset.icon);
});
const S = {
  user: null,
  name: "Свои люди",
  channels: [],
  users: [],
  current: null,
  invite: null,
  ws: null,
  connected: false,
  messages: new Map(),
  more: new Map(),
  unread: new Map(),
  typing: new Map(),
  voiceChannel: null,
  stream: null,
  peers: new Map(),
  muted: false,
  deafened: false,
  joining: false,
  reconnectTimer: null,
  loggedOut: false,
  loadToken: 0,
  iceServers: [],
  sendTimer: null,
};
const params = new URLSearchParams(location.search),
  initialInvite = params.get("invite") || "",
  setupKey = params.get("setup") || "";
let pendingReaction = null,
  authSetup = false;
const initials = (name) =>
  name
    .trim()
    .split(/\s+/)
    .slice(0, 2)
    .map((s) => [...s][0])
    .join("")
    .toUpperCase();
const channel = (id) => S.channels.find((c) => c.id === id);
function element(tag, cls, text) {
  const e = document.createElement(tag);
  if (cls) e.className = cls;
  if (text !== undefined) e.textContent = text;
  return e;
}
function avatar(user, online = false) {
  const e = element(
    "span",
    "avatar" + (online ? " online" : ""),
    initials(user.name),
  );
  const color = /^#[\da-f]{6}$/i.test(user.color) ? user.color : "#a18be8";
  e.style.setProperty("--avatar-bg", color + "2a");
  e.style.setProperty("--avatar-color", color);
  return e;
}
function applyAvatar(id, user, online = false) {
  const fresh = avatar(user, online);
  $(id).className = fresh.className;
  $(id).style.cssText = fresh.style.cssText;
  $(id).textContent = fresh.textContent;
}
function toast(text, error = false) {
  const e = element("div", "toast" + (error ? " error" : ""), text);
  $("toastArea").append(e);
  setTimeout(() => e.remove(), 5000);
}
async function api(path, method = "GET", data) {
  const res = await fetch("/api/" + path, {
    method,
    credentials: "same-origin",
    headers: data ? { "Content-Type": "application/json" } : {},
    body: data ? JSON.stringify(data) : undefined,
  });
  let result;
  try {
    result = await res.json();
  } catch {
    throw Error(
      "Сервер чата недоступен. Запусти npm start или проверь адрес сервера в клиенте.",
    );
  }
  if (!res.ok) {
    if (res.status === 401 && S.user && !S.loggedOut) {
      S.loggedOut = true;
      location.reload();
    }
    throw Error(result.error || "Не удалось выполнить запрос.");
  }
  return result;
}
function send(data) {
  if (S.ws?.readyState !== WebSocket.OPEN) {
    toast("Нет связи с сервером. Сообщение осталось в поле ввода.", true);
    return false;
  }
  S.ws.send(JSON.stringify(data));
  return true;
}
async function bootstrap() {
  const data = await api("bootstrap");
  S.user = data.user;
  S.name = data.name;
  S.invite = data.invite;
  S.channels = data.channels;
  S.users = data.users;
  $("loading").hidden = true;
  if (!data.user) {
    showAuth(data);
    return;
  }
  if (location.search) history.replaceState(null, "", location.pathname);
  $("authScreen").hidden = true;
  $("shell").hidden = false;
  renderSelf();
  renderChannels();
  renderMembers();
  const saved = localStorage.getItem("svoi-channel");
  const target = channel(saved) || S.channels.find((c) => c.kind === "text");
  if (target) await selectChannel(target.id);
  connect();
}
function showAuth(data) {
  $("authScreen").hidden = false;
  authSetup = data.needsSetup;
  if (authSetup) {
    $("authTitle").textContent = "Начнём с вашей компании";
    $("authDescription").textContent = "Создай пространство и позови друзей.";
    $("communityLabel").hidden = false;
    $("authSubmit").firstChild.textContent = "Создать пространство";
    if (!data.canSetup && !setupKey) {
      if (data.setupMethod === "key") {
        $("ownerKeyLabel").hidden = false;
        $("ownerKeyInput").required = true;
        $("authFinePrint").textContent =
          "Код создателя нужен один раз для настройки компании. Друзья войдут по обычному приглашению.";
      } else {
        $("authError").textContent =
          "Онлайн-сервис ещё настраивается владельцем.";
        $("authSubmit").disabled = true;
      }
    }
  } else {
    $("authDescription").textContent = "Тебя ждут в «" + data.name + "».";
    $("inviteLabel").hidden = !!initialInvite;
    if (initialInvite) $("inviteInput").value = initialInvite;
  }
  $("nameInput").value = localStorage.getItem("svoi-name") || "";
  if (setupKey && !authSetup) {
    $("authTitle").textContent = "С возвращением, владелец";
    $("authDescription").textContent =
      "Приватная ссылка восстановит твой профиль.";
    $("nameInput").required = false;
    $("nameInput").parentElement.hidden = true;
    $("inviteLabel").hidden = true;
  }
}
$("authForm").addEventListener("submit", async (e) => {
  e.preventDefault();
  $("authError").textContent = "";
  $("authSubmit").disabled = true;
  try {
    let invite = $("inviteInput").value.trim() || initialInvite;
    try {
      invite = new URL(invite).searchParams.get("invite") || invite;
    } catch {}
    await api("join", "POST", {
      name: $("nameInput").value,
      community: $("communityInput").value,
      invite,
      setup: setupKey || $("ownerKeyInput").value,
    });
    localStorage.setItem("svoi-name", $("nameInput").value);
    $("ownerKeyInput").value = "";
    await bootstrap();
  } catch (err) {
    $("authError").textContent = err.message;
  } finally {
    $("authSubmit").disabled = false;
  }
});
function renderSelf() {
  applyAvatar("myAvatar", S.user, true);
  $("myName").textContent = S.user.name;
  $("myStatus").textContent = S.user.owner ? "Владелец · в сети" : "В сети";
  $("spaceName").textContent = S.name;
  $("spaceInitials").textContent = initials(S.name);
  $("spaceButton").title = S.name;
  document
    .querySelectorAll(".add-channel")
    .forEach((e) => (e.hidden = !S.user.owner));
  for (const id of ["inviteButton", "railInvite", "welcomeInvite"])
    $(id).hidden = !S.user.owner;
}
function renderChannels() {
  for (const kind of ["text", "voice"]) {
    const container = $(kind === "text" ? "textChannels" : "voiceChannels");
    container.replaceChildren();
    for (const c of S.channels.filter((c) => c.kind === kind)) {
      const btn = element(
        "button",
        "channel" + (S.current === c.id ? " active" : ""),
      );
      btn.dataset.channelId = c.id;
      btn.title = c.topic || c.name;
      btn.innerHTML = icon(kind === "text" ? "hash" : "volume");
      btn.append(element("span", "channel-name", c.name));
      if (S.unread.get(c.id)) {
        const badge = element(
          "span",
          "unread-badge",
          Math.min(S.unread.get(c.id), 99),
        );
        btn.append(badge);
      }
      btn.addEventListener("click", () => {
        selectChannel(c.id);
        $("shell").classList.remove("show-sidebar");
      });
      container.append(btn);
      if (kind === "voice") {
        const list = element("div", "voice-member-list");
        for (const u of S.users.filter((u) => u.voice === c.id)) {
          const row = element("div", "voice-member-mini");
          row.append(avatar(u), element("span", "", u.name));
          if (u.muted) {
            const m = element("span");
            m.innerHTML = icon("micOff");
            row.append(m);
          }
          list.append(row);
        }
        container.append(list);
      }
    }
  }
}
function renderMembers() {
  $("memberTotal").textContent = S.users.length;
  const list = $("memberList");
  list.replaceChildren();
  for (const online of [true, false]) {
    const items = S.users.filter((u) => u.online === online);
    if (!items.length) continue;
    list.append(
      element(
        "div",
        "member-section-title",
        (online ? "В СЕТИ" : "НЕ В СЕТИ") + " — " + items.length,
      ),
    );
    for (const u of items) {
      const row = element("div", "member-row" + (online ? "" : " offline"));
      row.append(avatar(u, online));
      const copy = element("span", "member-copy");
      copy.append(
        element("strong", "", u.name + (u.id === S.user.id ? " · ты" : "")),
        element(
          "small",
          "",
          u.voice
            ? "В голосовом · " + (channel(u.voice)?.name || "")
            : u.owner
              ? "Хранитель этой компании"
              : online
                ? "Здесь, со своими"
                : "Вернётся позже",
        ),
      );
      row.append(copy);
      if (u.owner) {
        const crown = element("span", "member-crown", "♛");
        crown.title = "Владелец пространства";
        row.append(crown);
      }
      list.append(row);
    }
  }
}
async function selectChannel(id) {
  const c = channel(id);
  if (!c) return;
  const changed = S.current !== id;
  S.current = id;
  localStorage.setItem("svoi-channel", id);
  S.unread.delete(id);
  renderChannels();
  $("channelName").textContent = c.name;
  $("channelTopic").textContent = c.topic;
  document.title =
    c.kind === "voice" ? c.name + " · Свои" : "#" + c.name + " · Свои";
  $("headerIcon").innerHTML = icon(c.kind === "text" ? "hash" : "volume");
  $("textView").hidden = c.kind !== "text";
  $("voiceView").hidden = c.kind !== "voice";
  $("searchBar").hidden = true;
  $("searchInput").value = "";
  if (c.kind === "voice") {
    renderVoice();
    return;
  }
  $("welcomeChannel").textContent = "#" + c.name;
  $("welcomeTopic").textContent =
    c.topic || "Это начало канала #" + c.name + ". Разговоры начинаются с вас.";
  $("messageInput").placeholder = "Написать в #" + c.name;
  $("typingIndicator").textContent = "";
  if (changed)
    $("messageInput").value = localStorage.getItem("svoi-draft-" + id) || "";
  resizeComposer();
  renderMessages(true);
  await loadHistory(id);
}
async function loadHistory(id, older = false) {
  const token = ++S.loadToken;
  try {
    const existing = S.messages.get(id) || [];
    const before = older && existing.length ? "&before=" + existing[0].id : "";
    const result = await api(
      "messages?channel=" + encodeURIComponent(id) + before,
    );
    if (older) {
      const map = new Map(
        [...result.messages, ...existing].map((m) => [m.id, m]),
      );
      S.messages.set(
        id,
        [...map.values()].sort((a, b) => a.id - b.id),
      );
    } else {
      const pending = (S.messages.get(id) || []).filter(
        (m) => m.id > (result.messages.at(-1)?.id || 0),
      );
      S.messages.set(id, [...result.messages, ...pending]);
    }
    S.more.set(id, result.hasMore);
    if (S.current === id && token === S.loadToken) {
      const h = $("messageScroll").scrollHeight,
        top = $("messageScroll").scrollTop;
      renderMessages(!older);
      if (older)
        $("messageScroll").scrollTop =
          top + $("messageScroll").scrollHeight - h;
    }
  } catch (err) {
    toast(err.message, true);
  }
}
const timeFormat = new Intl.DateTimeFormat("ru-RU", {
  hour: "2-digit",
  minute: "2-digit",
});
const dateFormat = new Intl.DateTimeFormat("ru-RU", {
  day: "numeric",
  month: "long",
  year: "numeric",
});
function addText(parent, text, query = "") {
  if (!query) {
    parent.append(document.createTextNode(text));
    return;
  }
  let at = 0,
    pos;
  const lower = text.toLocaleLowerCase(),
    q = query.toLocaleLowerCase();
  while ((pos = lower.indexOf(q, at)) !== -1) {
    parent.append(
      document.createTextNode(text.slice(at, pos)),
      element("mark", "search-match", text.slice(pos, pos + query.length)),
    );
    at = pos + query.length;
  }
  parent.append(document.createTextNode(text.slice(at)));
}
function contentNode(text, query) {
  const parent = element("div", "message-text");
  let at = 0;
  for (const match of text.matchAll(/https?:\/\/[^\s<>]+|`[^`\n]+`/g)) {
    addText(parent, text.slice(at, match.index), query);
    if (match[0][0] === "`") {
      const code = element("code");
      addText(code, match[0].slice(1, -1), query);
      parent.append(code);
    } else {
      const link = element("a");
      link.href = match[0];
      link.target = "_blank";
      link.rel = "noopener noreferrer";
      addText(link, match[0], query);
      parent.append(link);
    }
    at = match.index + match[0].length;
  }
  addText(parent, text.slice(at), query);
  return parent;
}
function tool(name, title, handler) {
  const b = element("button", "icon-button");
  b.type = "button";
  b.innerHTML = icon(name);
  b.title = title;
  b.setAttribute("aria-label", title);
  b.addEventListener("click", handler);
  return b;
}
function renderMessages(scroll = false) {
  if (channel(S.current)?.kind !== "text") return;
  const scroller = $("messageScroll"),
    oldTop = scroller.scrollTop;
  const query = $("searchBar").hidden ? "" : $("searchInput").value.trim();
  const all = S.messages.get(S.current) || [],
    list = query
      ? all.filter((m) =>
          m.content.toLocaleLowerCase().includes(query.toLocaleLowerCase()),
        )
      : all;
  const container = $("messages");
  container.replaceChildren();
  let day = "";
  for (const m of list) {
    const d = dateFormat.format(m.created_at);
    if (d !== day) {
      container.append(element("div", "date-divider", d));
      day = d;
    }
    const row = element("article", "message");
    row.dataset.messageId = m.id;
    const author = S.users.find((u) => u.id === m.user_id) || {
      name: m.name,
      color: m.color,
    };
    row.append(avatar(author));
    const body = element("div", "message-body");
    const meta = element("div", "message-meta");
    const name = element("span", "message-author", author.name);
    name.style.color = /^#[\da-f]{6}$/i.test(author.color)
      ? author.color
      : "#c8b5ec";
    meta.append(name);
    if (author.owner) meta.append(element("span", "owner-badge", "♛"));
    const time = element(
      "time",
      "message-time",
      timeFormat.format(m.created_at),
    );
    time.dateTime = new Date(m.created_at).toISOString();
    time.title = new Date(m.created_at).toLocaleString("ru-RU");
    meta.append(time);
    body.append(meta, contentNode(m.content, query));
    const reactions = element("div", "reactions");
    const emojis = [...new Set((m.reactions || []).map((r) => r.emoji))];
    for (const emoji of emojis) {
      const mine = m.reactions.some(
        (r) => r.emoji === emoji && r.user_id === S.user.id,
      );
      const btn = element("button", "reaction" + (mine ? " mine" : ""), emoji);
      btn.append(
        element(
          "span",
          "",
          m.reactions.filter((r) => r.emoji === emoji).length,
        ),
      );
      btn.title = (mine ? "Убрать" : "Добавить") + " реакцию " + emoji;
      btn.addEventListener("click", () =>
        send({ type: "reaction", id: m.id, emoji }),
      );
      reactions.append(btn);
    }
    if (emojis.length) body.append(reactions);
    row.append(body);
    const tools = element("div", "message-tools");
    tools.append(
      tool("smile", "Добавить реакцию", (e) =>
        openEmojis(e.currentTarget, m.id),
      ),
      tool("copy", "Копировать сообщение", () =>
        copyText(m.content, "Сообщение скопировано"),
      ),
    );
    if (m.user_id === S.user.id || S.user.owner)
      tools.append(
        tool("trash", "Удалить сообщение", () => {
          if (confirm("Удалить это сообщение для всех?"))
            send({ type: "delete", id: m.id });
        }),
      );
    row.append(tools);
    container.append(row);
  }
  $("channelWelcome").hidden = !!query;
  $("loadMore").hidden = !S.more.get(S.current) || !!query;
  $("noResults").hidden = !query || list.length > 0;
  $("searchCount").textContent = query ? list.length + " найдено" : "";
  if (scroll) {
    scroller.scrollTop = scroller.scrollHeight;
    $("newMessages").hidden = true;
  } else scroller.scrollTop = oldTop;
}
$("loadMore").addEventListener("click", () => loadHistory(S.current, true));
$("newMessages").addEventListener("click", () => {
  $("messageScroll").scrollTop = $("messageScroll").scrollHeight;
  $("newMessages").hidden = true;
});
$("messageScroll").addEventListener("scroll", () => {
  const e = $("messageScroll");
  if (e.scrollHeight - e.scrollTop - e.clientHeight < 70)
    $("newMessages").hidden = true;
});
function resizeComposer() {
  const e = $("messageInput");
  e.style.height = "auto";
  e.style.height = Math.min(e.scrollHeight, 140) + "px";
  $("sendButton").disabled = !e.value.trim() || !S.connected;
  $("charCount").hidden = e.value.length < 1800;
  $("charCount").textContent = e.value.length + "/2000";
}
$("messageInput").addEventListener("input", () => {
  resizeComposer();
  localStorage.setItem("svoi-draft-" + S.current, $("messageInput").value);
  if (S.connected && Date.now() - (S.lastTyped || 0) > 2000) {
    S.lastTyped = Date.now();
    send({ type: "typing", channelId: S.current });
  }
});
$("messageInput").addEventListener("keydown", (e) => {
  if (e.key === "Enter" && !e.shiftKey && !e.isComposing) {
    e.preventDefault();
    $("messageForm").requestSubmit();
  }
});
$("messageForm").addEventListener("submit", (e) => {
  e.preventDefault();
  const content = $("messageInput").value.trim();
  if (
    content &&
    send({
      type: "message",
      content,
      channelId: S.current,
      nonce: crypto.randomUUID(),
    })
  ) {
    $("messageInput").value = "";
    localStorage.removeItem("svoi-draft-" + S.current);
    resizeComposer();
    $("messageInput").focus();
  }
});
function connect() {
  if (S.loggedOut) return;
  S.ws = new WebSocket(
    (location.protocol === "https:" ? "wss:" : "ws:") +
      "//" +
      location.host +
      "/ws",
  );
  S.ws.addEventListener("open", () => {
    S.connected = true;
    updateConnection();
  });
  S.ws.addEventListener("message", async (event) => {
    try {
      const data = JSON.parse(event.data);
      if (data.type === "ready") {
        if (channel(S.current)?.kind === "text") await loadHistory(S.current);
      } else if (data.type === "presence") {
        S.users = data.users;
        renderMembers();
        renderChannels();
        renderVoice();
      } else if (data.type === "channels") {
        S.channels = data.channels;
        renderChannels();
      } else if (data.type === "message") {
        const m = data.message;
        const list = S.messages.get(m.channel_id) || [];
        if (!list.some((x) => x.id === m.id)) list.push(m);
        S.messages.set(m.channel_id, list);
        if (m.channel_id === S.current) {
          const sc = $("messageScroll"),
            bottom = sc.scrollHeight - sc.scrollTop - sc.clientHeight < 100;
          renderMessages(bottom || m.user_id === S.user.id);
          if (!bottom && m.user_id !== S.user.id)
            $("newMessages").hidden = false;
        } else if (m.user_id !== S.user.id) {
          S.unread.set(m.channel_id, (S.unread.get(m.channel_id) || 0) + 1);
          renderChannels();
        }
        S.typing.delete(m.user_id);
        renderTyping();
      } else if (data.type === "deleted") {
        const list = S.messages.get(data.channelId);
        if (list)
          S.messages.set(
            data.channelId,
            list.filter((m) => m.id !== data.id),
          );
        if (S.current === data.channelId) renderMessages();
      } else if (data.type === "reactions") {
        for (const list of S.messages.values()) {
          const m = list.find((m) => m.id === data.id);
          if (m) m.reactions = data.reactions;
        }
        renderMessages();
      } else if (data.type === "typing") {
        if (data.userId !== S.user.id) {
          S.typing.set(data.userId, {
            channel: data.channelId,
            until: Date.now() + 4500,
          });
          renderTyping();
        }
      } else if (data.type === "voice:peers") {
        if (S.voiceChannel === data.channelId) {
          for (const id of data.peers) await makeOffer(id);
        }
      } else if (data.type === "signal") await signal(data);
      else if (data.type === "voice:left") {
        dropPeer(data.userId);
        renderVoice();
      } else if (data.type === "voice:replaced") {
        leaveVoice(false);
        toast("Голос подключён на другом окне этого профиля.");
      } else if (data.type === "error") toast(data.message, true);
    } catch (err) {
      console.error("Event error", err);
      toast(
        "Не удалось обработать событие. Переподключись, если ошибка повторится.",
        true,
      );
    }
  });
  S.ws.addEventListener("close", (event) => {
    S.connected = false;
    updateConnection();
    if (S.voiceChannel) {
      leaveVoice(false);
      toast(
        "Звонок завершён из-за потери связи. Подключись снова после восстановления.",
        true,
      );
    }
    if (event.code === 4001) {
      S.loggedOut = true;
      location.reload();
      return;
    }
    clearTimeout(S.reconnectTimer);
    if (!S.loggedOut) S.reconnectTimer = setTimeout(connect, 2500);
  });
  S.ws.addEventListener("error", () => {});
}
function updateConnection() {
  $("connectionBadge").classList.toggle("offline", !S.connected);
  $("connectionBadge").lastElementChild.textContent = S.connected
    ? "На связи"
    : "Подключение…";
  $("reconnectBanner").hidden = S.connected;
  resizeComposer();
}
function renderTyping() {
  const names = [...S.typing.entries()]
    .filter(([, v]) => v.until > Date.now() && v.channel === S.current)
    .map(([id]) => S.users.find((u) => u.id === id)?.name)
    .filter(Boolean);
  $("typingIndicator").textContent = names.length
    ? names.length > 2
      ? "Несколько человек печатают…"
      : names.join(" и ") + (names.length === 1 ? " печатает…" : " печатают…")
    : "";
}
setInterval(() => {
  for (const [id, value] of S.typing)
    if (value.until < Date.now()) S.typing.delete(id);
  renderTyping();
}, 1000);
function openEmojis(anchor, messageId = null) {
  pendingReaction = messageId;
  const picker = $("emojiPicker");
  picker.replaceChildren();
  for (const emoji of [
    "❤️",
    "😂",
    "🔥",
    "👍",
    "🎉",
    "👀",
    "👋",
    "✨",
    "💜",
    "🎮",
    "😎",
    "✌️",
  ]) {
    if (messageId && !["❤️", "😂", "🔥", "👍", "🎉", "👀"].includes(emoji))
      continue;
    const btn = element("button", "", emoji);
    btn.title = emoji;
    btn.addEventListener("click", () => {
      if (pendingReaction)
        send({ type: "reaction", id: pendingReaction, emoji });
      else {
        const input = $("messageInput");
        input.setRangeText(
          emoji,
          input.selectionStart,
          input.selectionEnd,
          "end",
        );
        input.dispatchEvent(new Event("input"));
        input.focus();
      }
      picker.hidden = true;
    });
    picker.append(btn);
  }
  picker.hidden = false;
  const box = anchor.getBoundingClientRect();
  picker.style.left =
    Math.min(Math.max(10, box.left), innerWidth - picker.offsetWidth - 10) +
    "px";
  picker.style.top = Math.max(10, box.top - picker.offsetHeight - 10) + "px";
}
$("emojiButton").addEventListener("click", (e) => {
  e.stopPropagation();
  if (!$("emojiPicker").hidden) {
    $("emojiPicker").hidden = true;
    return;
  }
  openEmojis(e.currentTarget);
});
document.addEventListener("click", (e) => {
  if (!e.target.closest("#emojiPicker,.message-tools,#emojiButton"))
    $("emojiPicker").hidden = true;
  if (
    innerWidth <= 680 &&
    $("shell").classList.contains("show-sidebar") &&
    !e.target.closest("#sidebar,#mobileMenu")
  )
    $("shell").classList.remove("show-sidebar");
});
document.addEventListener("keydown", (e) => {
  if (e.key === "Escape") {
    $("emojiPicker").hidden = true;
    $("shell").classList.remove("show-sidebar");
  }
});
async function copyText(text, success) {
  try {
    await navigator.clipboard.writeText(text);
    toast(success);
  } catch {
    toast(
      "Не удалось скопировать автоматически. Выдели ссылку и нажми Ctrl+C.",
      true,
    );
  }
}
function showInvite() {
  if (!S.user.owner) {
    toast("Попроси владельца пространства отправить приглашение.");
    return;
  }
  $("inviteLink").value = location.origin + "/?invite=" + S.invite;
  $("inviteDialog").showModal();
}
for (const id of ["inviteButton", "railInvite", "welcomeInvite", "spaceMenu"])
  $(id).addEventListener("click", showInvite);
$("copyInvite").addEventListener("click", () =>
  copyText(
    $("inviteLink").value,
    "Приглашение скопировано. Отправь его друзьям!",
  ),
);
$("rotateInvite").addEventListener("click", async () => {
  if (
    !confirm(
      "Заменить приглашение? Старая ссылка перестанет работать. Участники сохранят доступ.",
    )
  )
    return;
  try {
    const data = await api("invite/rotate", "POST", {});
    S.invite = data.invite;
    $("inviteLink").value = location.origin + "/?invite=" + S.invite;
    toast("Готово. Старая ссылка больше не действует.");
  } catch (err) {
    toast(err.message, true);
  }
});
document.querySelectorAll(".add-channel").forEach((e) =>
  e.addEventListener("click", () => {
    $("channelKind").value = e.dataset.kind;
    $("channelForm").reset();
    $("channelKind").value = e.dataset.kind;
    $("channelError").textContent = "";
    $("channelDialog").showModal();
    $("newChannelName").focus();
  }),
);
document
  .querySelectorAll("[data-close]")
  .forEach((e) =>
    e.addEventListener("click", () => $(e.dataset.close).close()),
  );
document.querySelectorAll("dialog").forEach((d) =>
  d.addEventListener("click", (e) => {
    if (e.target === d) {
      const r = d.getBoundingClientRect();
      if (
        e.clientX < r.left ||
        e.clientX > r.right ||
        e.clientY < r.top ||
        e.clientY > r.bottom
      )
        d.close();
    }
  }),
);
$("channelForm").addEventListener("submit", async (e) => {
  e.preventDefault();
  const button = e.currentTarget.querySelector('[type="submit"]');
  button.disabled = true;
  try {
    const data = await api("channels", "POST", {
      name: $("newChannelName").value,
      topic: $("newChannelTopic").value,
      kind: $("channelKind").value,
    });
    const fresh = await api("bootstrap");
    S.channels = fresh.channels;
    $("channelDialog").close();
    await selectChannel(data.id);
    toast("Канал создан.");
  } catch (err) {
    $("channelError").textContent = err.message;
  } finally {
    button.disabled = false;
  }
});
$("profileButton").addEventListener("click", () => {
  applyAvatar("profileAvatar", S.user);
  $("profileAvatar").classList.add("large-avatar");
  $("profileName").textContent = S.user.name;
  $("profileRole").textContent = S.user.owner
    ? "Владелец · " + S.name
    : "Участник · " + S.name;
  $("profileDialog").showModal();
});
$("logoutButton").addEventListener("click", async () => {
  if (!confirm("Выйти из профиля на этом устройстве?")) return;
  try {
    S.loggedOut = true;
    leaveVoice();
    await api("logout", "POST", {});
    location.reload();
  } catch (err) {
    S.loggedOut = false;
    toast(err.message, true);
  }
});
$("helpButton").addEventListener("click", () => $("helpDialog").showModal());
for (const id of ["homeButton", "spaceButton"])
  $(id).addEventListener("click", () => {
    const c = S.channels.find((c) => c.kind === "text");
    if (c) selectChannel(c.id);
  });
$("mobileMenu").addEventListener("click", (e) => {
  e.stopPropagation();
  $("shell").classList.toggle("show-sidebar");
});
$("membersButton").addEventListener("click", () => {
  if (innerWidth <= 960) {
    $("shell").classList.toggle("show-members");
    $("membersButton").setAttribute(
      "aria-pressed",
      $("shell").classList.contains("show-members"),
    );
  } else {
    $("shell").classList.toggle("no-members");
    $("membersButton").setAttribute(
      "aria-pressed",
      !$("shell").classList.contains("no-members"),
    );
  }
  $("membersButton").classList.toggle(
    "selected",
    $("membersButton").getAttribute("aria-pressed") === "true",
  );
});
$("searchButton").addEventListener("click", () => {
  if (channel(S.current)?.kind !== "text") {
    toast("Поиск доступен в текстовых каналах.");
    return;
  }
  $("searchBar").hidden = !$("searchBar").hidden;
  if (!$("searchBar").hidden) $("searchInput").focus();
  else {
    $("searchInput").value = "";
    renderMessages();
  }
});
$("closeSearch").addEventListener("click", () => {
  $("searchBar").hidden = true;
  $("searchInput").value = "";
  renderMessages();
});
$("searchInput").addEventListener("input", () => renderMessages());
async function joinVoice() {
  if (S.joining) return;
  if (!S.connected) {
    toast("Сначала дождись подключения к серверу.", true);
    return;
  }
  const c = channel(S.current);
  if (c?.kind !== "voice") return;
  if (!navigator.mediaDevices?.getUserMedia) {
    toast(
      "Микрофон доступен через HTTPS или на localhost. Открой защищённый адрес сервера.",
      true,
    );
    return;
  }
  S.joining = true;
  renderVoice();
  try {
    const data = await api("rtc");
    S.iceServers = data.iceServers;
    const stream = await navigator.mediaDevices.getUserMedia({
      audio: {
        echoCancellation: true,
        noiseSuppression: true,
        autoGainControl: true,
      },
      video: false,
    });
    if (!S.connected) {
      stream.getTracks().forEach((t) => t.stop());
      throw Error("Связь прервалась. Подключись снова.");
    }
    leaveVoice();
    S.stream = stream;
    S.voiceChannel = c.id;
    stream
      .getAudioTracks()
      .forEach((track) => (track.enabled = !S.muted && !S.deafened));
    send({ type: "voice:join", channelId: c.id, muted: S.muted || S.deafened });
    $("voiceStatus").hidden = false;
    $("voiceChannelLabel").textContent = c.name + " / " + S.name;
    toast("Ты в голосовом канале «" + c.name + "».");
  } catch (err) {
    const message =
      err.name === "NotAllowedError"
        ? "Микрофон запрещён. Разреши его в настройках приложения или браузера."
        : err.name === "NotFoundError"
          ? "Микрофон не найден. Подключи гарнитуру и попробуй ещё раз."
          : err.message;
    toast(message, true);
  } finally {
    S.joining = false;
    renderVoice();
  }
}
function leaveVoice(notify = true) {
  if (notify && S.voiceChannel && S.connected) send({ type: "voice:leave" });
  S.voiceChannel = null;
  for (const id of S.peers.keys()) dropPeer(id);
  S.stream?.getTracks().forEach((t) => t.stop());
  S.stream = null;
  $("voiceStatus").hidden = true;
  renderVoice();
}
function dropPeer(id) {
  const peer = S.peers.get(id);
  if (peer) {
    peer.pc.onicecandidate = null;
    peer.pc.ontrack = null;
    peer.pc.onconnectionstatechange = null;
    peer.pc.close();
    peer.audio?.remove();
    S.peers.delete(id);
  }
}
function makePeer(id) {
  if (S.peers.has(id)) return S.peers.get(id);
  const pc = new RTCPeerConnection({ iceServers: S.iceServers });
  const peer = { pc, candidates: [], audio: null };
  S.peers.set(id, peer);
  S.stream?.getTracks().forEach((t) => pc.addTrack(t, S.stream));
  pc.onicecandidate = (e) => {
    if (e.candidate)
      send({ type: "signal", to: id, candidate: e.candidate.toJSON() });
  };
  pc.ontrack = (e) => {
    if (!peer.audio) {
      peer.audio = document.createElement("audio");
      peer.audio.autoplay = true;
      peer.audio.muted = S.deafened;
      $("audioContainer").append(peer.audio);
    }
    peer.audio.srcObject = e.streams[0] || new MediaStream([e.track]);
    peer.audio
      .play()
      .catch(() => toast("Нажми на страницу, чтобы включить звук разговора."));
  };
  pc.onconnectionstatechange = () => {
    renderVoice();
    if (pc.connectionState === "failed")
      toast(
        "Не удалось связаться с " +
          (S.users.find((u) => u.id === id)?.name || "участником") +
          ". Для этой сети может потребоваться TURN-сервер.",
        true,
      );
  };
  return peer;
}
async function makeOffer(id) {
  if (!S.voiceChannel || id === S.user.id) return;
  const peer = makePeer(id);
  await peer.pc.setLocalDescription(await peer.pc.createOffer());
  send({
    type: "signal",
    to: id,
    description: peer.pc.localDescription.toJSON(),
  });
}
async function signal(data) {
  if (!S.voiceChannel || !S.stream) return;
  const peer = makePeer(data.from);
  try {
    if (data.description) {
      await peer.pc.setRemoteDescription(data.description);
      for (const candidate of peer.candidates)
        await peer.pc.addIceCandidate(candidate);
      peer.candidates = [];
      if (data.description.type === "offer") {
        await peer.pc.setLocalDescription(await peer.pc.createAnswer());
        send({
          type: "signal",
          to: data.from,
          description: peer.pc.localDescription.toJSON(),
        });
      }
    } else if (data.candidate) {
      if (peer.pc.remoteDescription)
        await peer.pc.addIceCandidate(data.candidate);
      else peer.candidates.push(data.candidate);
    }
  } catch (err) {
    console.error("Voice negotiation:", err);
    toast(
      "Не удалось установить голосовую связь. Переподключись к каналу.",
      true,
    );
  }
}
function renderVoice() {
  if (!S.user) return;
  const c = channel(S.current);
  const active = S.voiceChannel === c?.id;
  const members = S.users.filter((u) => u.voice === c?.id);
  if (
    S.voiceChannel &&
    !S.users.find((u) => u.id === S.user.id && u.voice === S.voiceChannel) &&
    active
  )
    members.push({
      ...S.user,
      voice: S.voiceChannel,
      muted: S.muted || S.deafened,
    });
  $("voiceRoomName").textContent = c?.kind === "voice" ? c.name : "";
  $("voiceEmpty").hidden = members.length > 0;
  const grid = $("voiceGrid");
  grid.replaceChildren();
  for (const u of members) {
    const pc = S.peers.get(u.id)?.pc;
    const own = u.id === S.user.id;
    const card = element(
      "div",
      "voice-card" +
        (own || pc?.connectionState === "connected" ? " connected" : ""),
    );
    card.dataset.voiceUser = u.id;
    card.append(
      avatar(u),
      element("strong", "", u.name + (own ? " · ты" : "")),
      element(
        "small",
        "",
        own
          ? "Вы подключены"
          : !active
            ? "В канале"
            : pc?.connectionState === "connected"
              ? "На связи"
              : pc?.connectionState === "failed"
                ? "Нет соединения"
                : "Соединяем…",
      ),
    );
    if (u.muted) {
      const mark = element("span", "voice-mute-mark");
      mark.innerHTML = icon("micOff");
      card.append(mark);
    }
    grid.append(card);
  }
  $("joinVoiceButton").hidden = active;
  $("joinVoiceButton").disabled = S.joining;
  $("joinVoiceButton").innerHTML =
    icon("mic") +
    (S.joining
      ? "Подключаем микрофон…"
      : S.voiceChannel
        ? "Перейти в этот канал"
        : "Присоединиться к разговору");
  $("roomLeaveButton").hidden = !active;
  const connected = [...S.peers.values()].filter(
    (p) => p.pc.connectionState === "connected",
  ).length;
  $("voiceState").textContent = active
    ? S.deafened
      ? "Звук и микрофон выключены"
      : S.muted
        ? "Микрофон выключен"
        : connected
          ? "Собеседников на связи: " + connected
          : members.length > 1
            ? "Соединяем участников…"
            : "Ты в канале. Друзья могут присоединиться."
    : " ";
  $("voiceStatusLabel").textContent =
    S.muted || S.deafened ? "Микрофон выключен" : "Голос подключён";
}
function updateAudio() {
  S.stream
    ?.getAudioTracks()
    .forEach((t) => (t.enabled = !S.muted && !S.deafened));
  for (const p of S.peers.values()) if (p.audio) p.audio.muted = S.deafened;
  $("muteButton").innerHTML = icon(S.muted || S.deafened ? "micOff" : "mic");
  $("muteButton").classList.toggle("muted", S.muted || S.deafened);
  $("muteButton").title =
    S.muted || S.deafened ? "Включить микрофон" : "Выключить микрофон";
  $("muteButton").setAttribute("aria-label", $("muteButton").title);
  $("deafenButton").innerHTML = icon(S.deafened ? "volumeOff" : "headphones");
  $("deafenButton").classList.toggle("muted", S.deafened);
  $("deafenButton").title = S.deafened ? "Включить звук" : "Выключить звук";
  $("deafenButton").setAttribute("aria-label", $("deafenButton").title);
  if (S.voiceChannel)
    send({ type: "voice:mute", muted: S.muted || S.deafened });
  renderVoice();
}
$("muteButton").addEventListener("click", () => {
  if (S.deafened) {
    S.deafened = false;
    S.muted = false;
  } else S.muted = !S.muted;
  updateAudio();
});
$("deafenButton").addEventListener("click", () => {
  S.deafened = !S.deafened;
  updateAudio();
});
$("joinVoiceButton").addEventListener("click", joinVoice);
$("leaveVoice").addEventListener("click", () => leaveVoice());
$("roomLeaveButton").addEventListener("click", () => leaveVoice());
window.addEventListener("beforeunload", () => {
  S.stream?.getTracks().forEach((t) => t.stop());
  S.ws?.close();
});
bootstrap().catch((err) => {
  $("loading").replaceChildren(
    element("strong", "", "Не удалось подключиться к «Своим»"),
    element("span", "", err.message),
  );
  const b = element("button", "primary-button", "Попробовать снова");
  b.onclick = () => location.reload();
  $("loading").append(b);
});

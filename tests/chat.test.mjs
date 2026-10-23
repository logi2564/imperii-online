import { test } from "node:test";
import assert from "node:assert/strict";
import { spawn } from "node:child_process";
import { mkdtemp, rm } from "node:fs/promises";
import { tmpdir } from "node:os";
import { join } from "node:path";
import { once } from "node:events";
import WebSocket from "ws";
import { Miniflare, convertV4MiniflareOptions } from "miniflare";
import { fileURLToPath } from "node:url";

for (const target of ["node", "cloudflare"])
  test(`${target}: private community, chat, voice signaling and persistence`, async (t) => {
    const dir = await mkdtemp(join(tmpdir(), "svoi-test-"));
    let process, origin, emulator;
    const testSetup = "test-only-owner-key-for-local-integration-12345";
    const sockets = [];
    async function start() {
      if (target === "cloudflare") {
        const options = convertV4MiniflareOptions({
          name: "svoi-test",
          modules: true,
          scriptPath: fileURLToPath(
            new URL("../cloud/worker.mjs", import.meta.url),
          ),
          compatibilityDate: "2026-10-19",
          host: "127.0.0.1",
          port: 0,
          cf: false,
          durableObjects: {
            COMMUNITY: { className: "Community", useSQLite: true },
          },
          durableObjectsPersist: dir,
          bindings: { SVOI_SETUP_KEY: testSetup },
          serviceBindings: {
            ASSETS: () => new Response("not found", { status: 404 }),
          },
        });
        options.resourcePersistencePath = dir;
        emulator = new Miniflare(options);
        origin = (await emulator.ready).origin;
        return;
      }
      process = spawn(globalThis.process.execPath, ["server.mjs"], {
        cwd: new URL("../", import.meta.url),
        env: {
          ...globalThis.process.env,
          DATA_DIR: dir,
          PORT: "0",
          BIND: "127.0.0.1",
        },
        stdio: ["ignore", "pipe", "pipe"],
      });
      origin = await new Promise((resolve, reject) => {
        let output = "";
        const timer = setTimeout(
          () => reject(Error("Server startup timeout")),
          10000,
        );
        process.stdout.on("data", (chunk) => {
          output += chunk;
          const match = output.match(/http:\/\/127\.0\.0\.1:\d+/);
          if (match) {
            clearTimeout(timer);
            resolve(match[0]);
          }
        });
        process.on("exit", (code) => {
          clearTimeout(timer);
          reject(Error("Server exited: " + code));
        });
      });
    }
    async function stop() {
      if (emulator) {
        await emulator.dispose();
        emulator = null;
        return;
      }
      if (process?.exitCode === null) {
        const done = once(process, "exit");
        process.kill("SIGTERM");
        await done;
      }
    }
    t.after(async () => {
      sockets.forEach((ws) => ws.close());
      await stop();
      await rm(dir, { recursive: true, force: true });
    });
    async function request(
      path,
      { method = "GET", body, cookie, foreign = false } = {},
    ) {
      const res = await fetch(origin + "/api/" + path, {
        method,
        headers: {
          ...(body ? { "Content-Type": "application/json" } : {}),
          ...(cookie ? { Cookie: cookie } : {}),
          ...(method !== "GET"
            ? { Origin: foreign ? "https://untrusted.example" : origin }
            : {}),
        },
        body: body ? JSON.stringify(body) : undefined,
      });
      return {
        status: res.status,
        body: await res.json(),
        cookie: res.headers.get("set-cookie")?.split(";")[0],
      };
    }
    async function socket(cookie) {
      const ws = new WebSocket(origin.replace("http:", "ws:") + "/ws", {
        headers: { Cookie: cookie, Origin: origin },
      });
      sockets.push(ws);
      ws.queue = [];
      ws.waiters = [];
      ws.on("message", (raw) => {
        const data = JSON.parse(raw);
        const waiter = ws.waiters.find(
          (w) => w.type === data.type && w.predicate(data),
        );
        if (waiter) {
          ws.waiters.splice(ws.waiters.indexOf(waiter), 1);
          clearTimeout(waiter.timer);
          waiter.resolve(data);
        } else ws.queue.push(data);
      });
      ws.next = (type, predicate = () => true) =>
        new Promise((resolve, reject) => {
          const index = ws.queue.findIndex(
            (e) => e.type === type && predicate(e),
          );
          if (index !== -1) return resolve(ws.queue.splice(index, 1)[0]);
          const waiter = {
            type,
            predicate,
            resolve,
            timer: setTimeout(() => {
              ws.waiters.splice(ws.waiters.indexOf(waiter), 1);
              reject(Error("Missing event " + type));
            }, 5000),
          };
          ws.waiters.push(waiter);
        });
      await once(ws, "open");
      await ws.next("ready");
      return ws;
    }
    await start();
    const initial = await request("bootstrap");
    assert.equal(initial.body.needsSetup, true);
    if (target === "cloudflare") {
      assert.equal(
        (await request("join", { method: "POST", body: { name: "Незваный" } }))
          .status,
        403,
      );
    }
    const first = await request("join", {
      method: "POST",
      body: {
        name: "Владелец",
        community: "Тестовая компания",
        setup: testSetup,
      },
    });
    assert.equal(first.status, 201);
    const ownerCookie = first.cookie;
    const bootstrap = await request("bootstrap", { cookie: ownerCookie });
    assert.equal(bootstrap.body.user.owner, true);
    assert.equal(bootstrap.body.name, "Тестовая компания");
    const text = bootstrap.body.channels.find((c) => c.kind === "text"),
      voice = bootstrap.body.channels.find((c) => c.kind === "voice");
    await t.test(
      "invitation and origin checks protect registration and history",
      async () => {
        assert.equal(
          (await request("messages?channel=" + text.id)).status,
          401,
        );
        assert.equal(
          (
            await request("join", {
              method: "POST",
              body: { name: "Незваный", invite: "invalid" },
            })
          ).status,
          403,
        );
        assert.equal(
          (
            await request("join", {
              method: "POST",
              body: { name: "Друг", invite: bootstrap.body.invite },
              foreign: true,
            })
          ).status,
          403,
        );
      },
    );
    const friend = await request("join", {
      method: "POST",
      body: { name: "Друг", invite: bootstrap.body.invite },
    });
    assert.equal(friend.status, 201);
    const friendCookie = friend.cookie;
    const friendBootstrap = await request("bootstrap", {
      cookie: friendCookie,
    });
    assert.equal(friendBootstrap.body.invite, undefined);
    const a = await socket(ownerCookie),
      b = await socket(friendCookie);
    await a.next(
      "presence",
      (e) => e.users.filter((u) => u.online).length === 2,
    );
    let id;
    await t.test(
      "messages reach another client and persist as text without executing HTML",
      async () => {
        a.send(
          JSON.stringify({
            type: "message",
            channelId: text.id,
            content: "Привет, свои! <script>alert(1)</script>",
          }),
        );
        const event = await b.next("message");
        id = event.message.id;
        assert.equal(
          event.message.content,
          "Привет, свои! <script>alert(1)</script>",
        );
        const history = await request("messages?channel=" + text.id, {
          cookie: friendCookie,
        });
        assert.equal(history.body.messages.at(-1).id, id);
        b.send(JSON.stringify({ type: "typing", channelId: text.id }));
        assert.equal(
          (await a.next("typing")).userId,
          friendBootstrap.body.user.id,
        );
      },
    );
    await t.test(
      "reactions toggle; another guest cannot delete someone else’s message",
      async () => {
        b.send(JSON.stringify({ type: "reaction", id, emoji: "🔥" }));
        assert.equal((await a.next("reactions")).reactions.length, 1);
        b.send(JSON.stringify({ type: "reaction", id, emoji: "🔥" }));
        assert.equal((await a.next("reactions")).reactions.length, 0);
        b.send(JSON.stringify({ type: "delete", id }));
        b.send(
          JSON.stringify({
            type: "message",
            channelId: text.id,
            content: "проверка очереди",
          }),
        );
        await a.next(
          "message",
          (e) => e.message.content === "проверка очереди",
        );
        assert.equal(
          (
            await request("messages?channel=" + text.id, {
              cookie: friendCookie,
            })
          ).body.messages[0].id,
          id,
        );
      },
    );
    await t.test(
      "only the owner creates channels and rotates invites",
      async () => {
        assert.equal(
          (
            await request("channels", {
              method: "POST",
              cookie: friendCookie,
              body: { name: "секретный", kind: "text" },
            })
          ).status,
          403,
        );
        assert.equal(
          (
            await request("channels", {
              method: "POST",
              cookie: ownerCookie,
              body: {
                name: "вечерние планы",
                kind: "text",
                topic: "Сегодня играем",
              },
            })
          ).status,
          201,
        );
        assert.ok(
          (await b.next("channels")).channels.some(
            (c) => c.name === "вечерние-планы",
          ),
        );
        const rotated = await request("invite/rotate", {
          method: "POST",
          cookie: ownerCookie,
          body: {},
        });
        assert.equal(rotated.status, 200);
        assert.equal(
          (
            await request("join", {
              method: "POST",
              body: { name: "Ещё друг", invite: bootstrap.body.invite },
            })
          ).status,
          403,
        );
        assert.equal(
          (
            await request("join", {
              method: "POST",
              body: { name: "Ещё друг", invite: rotated.body.invite },
            })
          ).status,
          201,
        );
      },
    );
    await t.test(
      "voice peers discover each other and signaling is scoped to their channel",
      async () => {
        a.send(JSON.stringify({ type: "voice:join", channelId: voice.id }));
        assert.deepEqual((await a.next("voice:peers")).peers, []);
        b.send(JSON.stringify({ type: "voice:join", channelId: voice.id }));
        assert.deepEqual((await b.next("voice:peers")).peers, [
          bootstrap.body.user.id,
        ]);
        b.send(
          JSON.stringify({
            type: "signal",
            to: bootstrap.body.user.id,
            description: { type: "offer", sdp: "test-offer" },
          }),
        );
        assert.equal((await a.next("signal")).description.sdp, "test-offer");
        b.send(JSON.stringify({ type: "voice:mute", muted: true }));
        await a.next("presence", (e) =>
          e.users.some((u) => u.id === friendBootstrap.body.user.id && u.muted),
        );
        b.send(JSON.stringify({ type: "voice:leave" }));
        assert.equal(
          (await a.next("voice:left")).userId,
          friendBootstrap.body.user.id,
        );
        b.send(
          JSON.stringify({
            type: "signal",
            to: bootstrap.body.user.id,
            description: { type: "offer", sdp: "forbidden" },
          }),
        );
        b.send(
          JSON.stringify({
            type: "message",
            channelId: text.id,
            content: "signal boundary",
          }),
        );
        await a.next("message", (e) => e.message.content === "signal boundary");
        assert.ok(
          !a.queue.some(
            (e) => e.type === "signal" && e.description.sdp === "forbidden",
          ),
        );
      },
    );
    await t.test("owner moderation removes messages for everyone", async () => {
      a.send(JSON.stringify({ type: "delete", id }));
      assert.equal((await b.next("deleted")).id, id);
    });
    a.close();
    b.close();
    await Promise.all([once(a, "close"), once(b, "close")]);
    await stop();
    await start();
    await t.test(
      "history, sessions and channels survive a server restart",
      async () => {
        const fresh = await request("bootstrap", { cookie: ownerCookie });
        assert.equal(fresh.status, 200);
        assert.equal(fresh.body.user.name, "Владелец");
        assert.ok(fresh.body.channels.some((c) => c.name === "вечерние-планы"));
        const history = await request("messages?channel=" + text.id, {
          cookie: friendCookie,
        });
        assert.ok(
          history.body.messages.some((m) => m.content === "проверка очереди"),
        );
        assert.ok(!history.body.messages.some((m) => m.id === id));
        assert.ok(fresh.body.users.every((u) => !u.online && !u.voice));
      },
    );
  });

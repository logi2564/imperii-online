import assert from "node:assert/strict";
import { spawn, spawnSync } from "node:child_process";
import { mkdtemp, readFile, rm } from "node:fs/promises";
import { tmpdir } from "node:os";
import { resolve, join } from "node:path";
import { setTimeout as pause } from "node:timers/promises";

assert.equal(process.platform, "win32", "Run the EXE smoke check on Windows.");
const { version } = JSON.parse(await readFile("package.json", "utf8"));
const profile = await mkdtemp(join(tmpdir(), "svoi-exe-smoke-"));
const child = spawn(resolve(`dist/Svoi-${version}.exe`), [
  `--user-data-dir=${profile}`,
  "--remote-debugging-address=127.0.0.1",
  "--remote-debugging-port=0",
], { stdio: "ignore" });
let launchError;
child.on("error", (error) => { launchError = error; });
let socket;
try {
  const deadline = Date.now() + 90_000;
  let target;
  while (Date.now() < deadline) {
    if (launchError) throw launchError;
    if (child.exitCode !== null)
      throw Error(`Portable EXE exited before showing its window: ${child.exitCode}`);
    try {
      const port = (await readFile(join(profile, "DevToolsActivePort"), "utf8")).split("\n")[0];
      const targets = await (await fetch(`http://127.0.0.1:${port}/json/list`)).json();
      target = targets.find((item) => item.type === "page" && item.url.includes("connect.html"));
      if (target) break;
    } catch {}
    await pause(300);
  }
  assert.ok(target, "The single EXE must open the connection window.");
  socket = new WebSocket(target.webSocketDebuggerUrl);
  await new Promise((resolve, reject) => {
    socket.addEventListener("open", resolve, { once: true });
    socket.addEventListener("error", reject, { once: true });
  });
  let nextId = 0;
  async function evaluate(expression) {
    const id = ++nextId;
    return await new Promise((resolve, reject) => {
      const timeout = setTimeout(() => { cleanup(); reject(Error("CDP timed out.")); }, 10_000);
      function cleanup() { clearTimeout(timeout); socket.removeEventListener("message", onMessage); }
      function onMessage(event) {
        const reply = JSON.parse(event.data);
        if (reply.id !== id) return;
        cleanup();
        if (reply.error || reply.result?.exceptionDetails) reject(Error(JSON.stringify(reply)));
        else resolve(reply.result.result.value);
      }
      socket.addEventListener("message", onMessage);
      socket.send(JSON.stringify({ id, method: "Runtime.evaluate", params: { expression, returnByValue: true, awaitPromise: true } }));
    });
  }
  let view;
  while (Date.now() < deadline) {
    view = await evaluate(`(async () => ({
      title: document.title,
      heading: document.querySelector('#statusTitle')?.textContent,
      retryEnabled: document.querySelector('#retryButton')?.disabled === false,
      addressFields: document.querySelectorAll('input, textarea').length,
      node: typeof require,
      status: await window.svoi.status()
    }))()`);
    if (view.retryEnabled) break;
    await pause(300);
  }
  assert.match(view.title, /Свои/);
  assert.equal(view.addressFields, 0, "The launcher must not ask for a server address.");
  assert.equal(view.node, "undefined", "The window must not expose Node.js.");
  assert.equal(view.retryEnabled, true, "Automatic discovery must finish.");
  const service = JSON.parse(await readFile("service.json", "utf8"));
  if (service.origin === null) {
    assert.equal(view.status.phase, "not_deployed", "The preview must explain that hosting is pending.");
    assert.match(view.heading, /ещё не запущен/);
  }
  console.log("PASS: the single portable EXE opens on Windows, discovers its service, and has no address field.");
} finally {
  socket?.close();
  if (child.pid && child.exitCode === null)
    spawnSync("taskkill.exe", ["/PID", String(child.pid), "/T", "/F"], { stdio: "ignore" });
  await rm(profile, { recursive: true, force: true, maxRetries: 10, retryDelay: 300 });
}

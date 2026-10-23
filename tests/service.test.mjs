import { test } from "node:test";
import assert from "node:assert/strict";
import { createRequire } from "node:module";
const { discover, serviceOrigin } = createRequire(import.meta.url)(
  "../desktop/service.cjs",
);
const reply = (body) => ({ ok: true, json: async () => body });
test("desktop discovers the shared service without asking for an address", async () => {
  const urls = [];
  const result = await discover({
    fetcher: async (url) => {
      urls.push(url);
      return reply(
        url.endsWith("/health")
          ? { ok: true, app: "svoi", protocol: 1 }
          : { schema: 1, origin: "https://chat.example.com" },
      );
    },
  });
  assert.deepEqual(result, {
    phase: "ready",
    origin: "https://chat.example.com",
  });
  assert.equal(urls.at(-1), "https://chat.example.com/health");
});
test("an undeployed service is reported honestly without connecting to localhost", async () => {
  assert.deepEqual(
    await discover({
      fetcher: async () => reply({ schema: 1, origin: null }),
      cached: "https://old.example.com",
    }),
    { phase: "not_deployed" },
  );
});
test("an existing service remains usable when GitHub is temporarily unavailable", async () => {
  const result = await discover({
    cached: "https://chat.example.com",
    fetcher: async (url) => {
      if (!url.endsWith("/health")) throw Error("network down");
      return reply({ ok: true, app: "svoi", protocol: 1 });
    },
  });
  assert.equal(result.origin, "https://chat.example.com");
});
test("invalid routing and unrelated web servers cannot be opened as the chat", async () => {
  for (const url of [
    "http://chat.example.com",
    "https://u:p@chat.example.com",
    "https://chat.example.com/path",
    "file:///tmp/test",
    "https://chat.example.com/?setup=secret",
  ])
    assert.throws(() => serviceOrigin(url));
  await assert.rejects(
    discover({
      fetcher: async (url) =>
        reply(
          url.endsWith("/health")
            ? { ok: true }
            : { schema: 1, origin: "https://unrelated.example.com" },
        ),
    }),
  );
});

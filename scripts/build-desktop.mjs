import { packager } from "@electron/packager";
import { readFileSync, mkdirSync, writeFileSync, rmSync } from "node:fs";
import { createHash } from "node:crypto";
import { resolve, basename } from "node:path";
import { execFileSync } from "node:child_process";
const platform = process.argv[2] || "win32";
if (!["win32", "linux"].includes(platform))
  throw Error("Поддерживаются win32 и linux.");
const pkg = JSON.parse(
  readFileSync(new URL("../package.json", import.meta.url), "utf8"),
);
const out = resolve("dist");
mkdirSync(out, { recursive: true });
const results = await packager({
  dir: resolve("desktop"),
  name: "Svoi",
  appVersion: "1.0.0",
  platform,
  arch: "x64",
  out,
  overwrite: true,
  asar: true,
  electronVersion: pkg.devDependencies.electron,
  download: {
    cacheRoot: process.env.ELECTRON_CACHE || resolve(".electron-cache"),
  },
  prune: true,
});
for (const folder of results) {
  writeFileSync(
    resolve(folder, "START-HERE.txt"),
    "СВОИ — клиент для Windows\r\n\r\n1. Распакуйте всю папку из архива.\r\n2. Запустите Svoi.exe.\r\n3. Вставьте HTTPS-ссылку приглашения от владельца сервера.\r\n4. Выберите никнейм. Для разговора разрешите доступ к микрофону.\r\n\r\nСменить сервер: Ctrl + Shift + S.\r\nПрограмма не включает общий сервер: его запускает владелец компании.\r\nДля локальной проверки можно подключиться к http://localhost:3000 после запуска сервера.\r\n",
  );
  const archive = resolve(out, `Svoi-1.0.0-${platform}-x64.zip`);
  rmSync(archive, { force: true });
  execFileSync(
    process.platform === "win32" ? "tar.exe" : "zip",
    process.platform === "win32"
      ? ["-a", "-c", "-f", archive, basename(folder)]
      : ["-qr", archive, basename(folder)],
    { cwd: out, stdio: "inherit" },
  );
  const digest = createHash("sha256")
    .update(readFileSync(archive))
    .digest("hex");
  writeFileSync(archive + ".sha256", `${digest}  ${basename(archive)}\n`);
  console.log(`Создано: ${archive}`);
}

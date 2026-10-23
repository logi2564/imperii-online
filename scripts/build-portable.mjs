import { build, Platform, Arch } from "electron-builder";
import { createHash } from "node:crypto";
import { readFileSync, writeFileSync } from "node:fs";
import { resolve, basename } from "node:path";

if (process.platform !== "win32")
  throw Error("The portable EXE is built and tested on Windows.");
const pkg = JSON.parse(readFileSync("package.json", "utf8"));
await build({
  targets: Platform.WINDOWS.createTarget("portable", Arch.x64),
  prepackaged: resolve("dist/Svoi-win32-x64"),
  publish: "never",
  config: {
    appId: "com.svoi.chat",
    productName: "Svoi",
    electronVersion: pkg.devDependencies.electron,
    directories: { app: "desktop", output: "dist" },
    artifactName: "Svoi-${version}.${ext}",
    win: { signExecutable: false },
    portable: { requestExecutionLevel: "user" },
  },
});
const executable = resolve(`dist/Svoi-${pkg.version}.exe`);
const bytes = readFileSync(executable);
if (bytes.length < 1_000_000 || bytes.toString("ascii", 0, 2) !== "MZ")
  throw Error("Missing or invalid portable Windows executable.");
const digest = createHash("sha256").update(bytes).digest("hex");
writeFileSync(executable + ".sha256", `${digest}  ${basename(executable)}\n`);
console.log(`Создан один переносимый файл: ${executable}`);

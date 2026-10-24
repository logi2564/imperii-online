import { build, Platform, Arch } from "electron-builder";
import { createHash } from "node:crypto";
import { readFileSync, writeFileSync, copyFileSync, renameSync, mkdirSync } from "node:fs";
import { resolve, join, basename } from "node:path";

if (process.platform !== "win32") throw Error("Build the native portable game on Windows.");
const root = resolve("dist/ZoneMotionPC");
const game = join(root, "Game");
const report = resolve("dist/native-validation/result.txt");
if (readFileSync(report, "utf8").trim() !== "PASS") throw Error("The actual native game must pass first.");
const info = JSON.parse(readFileSync(join(game, "CANDIDATE.json"), "utf8"));
delete info.windows_gameplay_tested;
info.windows_menu_and_new_game_tested = true;
info.windows_save_and_reload_tested = true;
info.windows_mouse_buttons_tested = true;
info.full_campaign_tested = false;
info.commit = process.env.GITHUB_SHA;
writeFileSync(join(game, "CANDIDATE.json"), JSON.stringify(info, null, 2));
renameSync(join(game, "CANDIDATE.json"), join(root, "BUILD-INFO.json"));
copyFileSync("zone-motion-pc/native/README-WINDOWS.txt", join(root, "README.txt"));
// The generic portable target expects its helper directory in a prepacked app.
mkdirSync(join(root, "resources"), { recursive: true });

// Only the generic NSIS portable packager is used. The prepackaged payload is
// the native Unity game and Vulkan driver; no Electron application is included.
await build({
  targets: Platform.WINDOWS.createTarget("portable", Arch.x64),
  prepackaged: root,
  publish: "never",
  config: {
    appId: "com.Sokol.ZoneMotionPC",
    productName: "ZoneMotion",
    executableName: "ZoneMotion",
    electronVersion: "45.0.0",
    directories: { app: "zone-motion-pc/native", output: "dist/native-package" },
    artifactName: "ZoneMotion-PC-Windows.${ext}",
    win: { signExecutable: false },
    portable: { requestExecutionLevel: "user" },
  },
});
const executable = resolve("dist/native-package/ZoneMotion-PC-Windows.exe");
const bytes = readFileSync(executable);
if (bytes.length < 10_000_000 || bytes.toString("ascii", 0, 2) !== "MZ")
  throw Error("A native portable game executable was not produced.");
writeFileSync(executable + ".sha256", createHash("sha256").update(bytes).digest("hex") + "  " + basename(executable) + "\n");
console.log(`Native game packed into one executable: ${bytes.length} bytes.`);

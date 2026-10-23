import { readFileSync } from "node:fs";
import { resolve } from "node:path";
import { fileURLToPath } from "node:url";
const dataDir = resolve(
  process.env.DATA_DIR || fileURLToPath(new URL("../.data/", import.meta.url)),
);
try {
  const key = readFileSync(resolve(dataDir, "setup-key"), "utf8").trim();
  console.log(
    `${process.env.PUBLIC_URL || process.env.RENDER_EXTERNAL_URL || "http://localhost:3000"}/?setup=${encodeURIComponent(key)}`,
  );
  console.log(
    "Это приватная ссылка владельца. Не отправляйте её друзьям: для них есть приглашение внутри приложения.",
  );
} catch {
  console.error("Сначала запустите npm start.");
  process.exitCode = 1;
}

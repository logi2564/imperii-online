import { readFile, writeFile } from "node:fs/promises";
import { createRequire } from "node:module";
const { serviceOrigin } = createRequire(import.meta.url)(
  "../desktop/service.cjs",
);
try {
  const origin = serviceOrigin(process.argv[2] || process.env.SVOI_PUBLIC_URL);
  const response = await fetch(origin + "/health", {
    signal: AbortSignal.timeout(15000),
  });
  if (!response.ok) throw Error("Сервис не отвечает.");
  const data = await response.json();
  if (!data.ok || data.app !== "svoi" || data.protocol !== 1)
    throw Error("По этому адресу нет готового сервиса «Свои».");
  const file = new URL("../service.json", import.meta.url);
  const current = JSON.parse(await readFile(file, "utf8"));
  await writeFile(
    file,
    JSON.stringify({ ...current, schema: 1, origin }, null, 2) + "\n",
  );
  console.log(
    "Сервис проверен. service.json обновлён; отправьте изменение в ветку svoi-release для автоматического подключения клиентов.",
  );
} catch (error) {
  console.error(error.message || "Укажите HTTPS-адрес размещённого сервиса.");
  process.exitCode = 1;
}

"use strict";
const title = document.getElementById("statusTitle");
const description = document.getElementById("statusDescription");
const retry = document.getElementById("retryButton");
function render(status) {
  if (!status) return;
  const connecting = status.phase === "connecting";
  document
    .getElementById("connectionMark")
    .classList.toggle("connecting", connecting);
  retry.disabled = connecting;
  retry.textContent = connecting ? "Подключаемся…" : "Попробовать снова";
  if (connecting) {
    title.textContent = "Заходим к своим";
    description.textContent = "Ещё мгновение — и вы снова вместе.";
  } else if (status.phase === "not_deployed") {
    title.textContent = "Онлайн-сервис ещё не запущен";
    description.textContent =
      "Общее пространство ещё готовится. Когда сервис будет подключён, приложение откроет его автоматически.";
  } else {
    title.textContent = "Не удалось подключиться";
    description.textContent =
      "Проверь интернет и попробуй снова. Если связь не вернулась, сервис может быть временно недоступен.";
  }
}
window.svoi.onStatus(render);
window.svoi.status().then(render);
retry.addEventListener("click", () => window.svoi.retry());

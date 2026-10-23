"use strict";
const input = document.getElementById("server"),
  error = document.getElementById("error"),
  submit = document.getElementById("submit");
error.textContent = new URLSearchParams(location.search).get("error") || "";
window.svoi.current().then((url) => {
  input.value = url || "http://localhost:3000";
});
document.getElementById("connectForm").addEventListener("submit", async (e) => {
  e.preventDefault();
  submit.disabled = true;
  error.textContent = "";
  try {
    const result = await window.svoi.connect(input.value);
    if (result.error) error.textContent = result.error;
  } catch {
    error.textContent = "Не удалось подключиться. Попробуй ещё раз.";
  } finally {
    submit.disabled = false;
  }
});

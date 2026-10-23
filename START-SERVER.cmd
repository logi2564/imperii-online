@echo off
chcp 65001 >nul
cd /d "%~dp0"
where node >nul 2>nul
if errorlevel 1 (
  echo Установите Node.js 24 или новее с https://nodejs.org/ и запустите этот файл снова.
  pause
  exit /b 1
)
node -e "if(Number(process.versions.node.split('.')[0])<24)process.exit(1)"
if errorlevel 1 (
  echo Нужен Node.js 24 или новее.
  pause
  exit /b 1
)
if not exist node_modules\ws\package.json (
  call npm ci --omit=dev --no-fund
  if errorlevel 1 (
    echo Не удалось установить зависимости. Проверьте соединение с интернетом.
    pause
    exit /b 1
  )
)
echo.
echo СВОИ — ваш сервер
echo Откройте http://localhost:3000 в браузере или в клиенте Svoi.exe.
echo Пока вы общаетесь, оставляйте это окно открытым.
echo Для остановки нажмите Ctrl+C.
echo.
call npm start
pause

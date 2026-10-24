@echo off
setlocal EnableExtensions DisableDelayedExpansion
chcp 65001 >nul
pushd "%~dp0"
if errorlevel 1 exit /b 1
if exist "dist\ZoneMotionPC\ZoneMotionPC.exe" if exist "dist\ZoneMotionPC\ZoneMotionPC_Data\globalgamemanagers" goto play

echo Первый запуск: готовой Windows-сборки пока нет.
echo Сейчас Unity попробует собрать игру. Первый импорт может занять несколько минут.
echo Для этого нужен установленный и активированный Unity 2017.2.0f3.
echo.
call BUILD-WINDOWS.cmd
set "ZONEMOTION_LAUNCH_RESULT=%ERRORLEVEL%"
if not "%ZONEMOTION_LAUNCH_RESULT%"=="0" goto build_failed
if not exist "dist\ZoneMotionPC\ZoneMotionPC.exe" goto incomplete
if not exist "dist\ZoneMotionPC\ZoneMotionPC_Data\globalgamemanagers" goto incomplete

:play
echo Запускаю Zone Motion...
start "" /D "%CD%\dist\ZoneMotionPC" "%CD%\dist\ZoneMotionPC\ZoneMotionPC.exe"
set "ZONEMOTION_LAUNCH_RESULT=%ERRORLEVEL%"
if not "%ZONEMOTION_LAUNCH_RESULT%"=="0" goto launch_failed
popd
exit /b 0

:incomplete
set "ZONEMOTION_LAUNCH_RESULT=1"
goto build_failed

:build_failed
echo.
echo Игра не запущена: сначала нужна успешная сборка в Unity.
echo Если Unity ещё не установлен: https://unity.com/releases/editor/archive
echo Установи версию 2017.2.0f3 с Windows Build Support и активируй редактор.
echo Подробности: README-PC.md. Ошибки сборки: build-windows.log, если он создан.
goto finish_error

:launch_failed
echo.
echo Не удалось запустить игру. Не перемещай EXE отдельно от папки ZoneMotionPC_Data.

:finish_error
popd
if not defined ZONEMOTION_NO_PAUSE pause
exit /b %ZONEMOTION_LAUNCH_RESULT%

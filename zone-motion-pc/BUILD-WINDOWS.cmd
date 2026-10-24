@echo off
setlocal EnableExtensions DisableDelayedExpansion
if defined UNITY_EDITOR_PATH (
  set "ZONEMOTION_UNITY=%UNITY_EDITOR_PATH%"
  goto editor_selected
)
set "ZONEMOTION_UNITY=%ProgramFiles%\Unity\Hub\Editor\2017.2.0f3\Editor\Unity.exe"
if not exist "%ZONEMOTION_UNITY%" set "ZONEMOTION_UNITY=%ProgramFiles%\Unity\Editor\Unity.exe"
:editor_selected
if not exist "%ZONEMOTION_UNITY%" (
  echo Unity 2017.2.0f3 with Windows x64 Build Support was not found.
  echo Install and activate the editor before the first build.
  echo Official archive: https://unity.com/releases/editor/archive
  echo For a custom location, set UNITY_EDITOR_PATH to Editor\Unity.exe.
  exit /b 2
)
powershell.exe -NoLogo -NoProfile -NonInteractive -Command "$v = (Get-Item -LiteralPath $env:ZONEMOTION_UNITY).VersionInfo.ProductVersion; if ($v -match '^2017\.2\.0([.f]|$)') { exit 0 }; Write-Host ('Unsupported Unity version: ' + $v); exit 1"
if errorlevel 1 (
  echo Use Unity 2017.2.0f3. A newer editor can modify this legacy project.
  exit /b 2
)
pushd "%~dp0"
if errorlevel 1 exit /b 1
if exist "%~dp0build-windows.log" del "%~dp0build-windows.log"
if exist "%~dp0build-windows.log" (
  popd
  echo Cannot replace build-windows.log. Close Unity and try again.
  exit /b 1
)
"%ZONEMOTION_UNITY%" -batchmode -nographics -buildTarget Win64 -projectPath "%~dp0project" -executeMethod ZoneMotionPC.EditorBuild.BuildWindows -quit -logFile "%~dp0build-windows.log"
set "ZONEMOTION_BUILD_RESULT=%ERRORLEVEL%"
popd
if not "%ZONEMOTION_BUILD_RESULT%"=="0" (
  echo Build failed. See build-windows.log.
  exit /b %ZONEMOTION_BUILD_RESULT%
)
findstr /L /C:"WINDOWS_BUILD_COMPLETE:" "%~dp0build-windows.log" >nul 2>nul
if errorlevel 1 (
  echo Unity did not confirm a completed build. See build-windows.log.
  exit /b 1
)
if not exist "%~dp0dist\ZoneMotionPC\ZoneMotionPC.exe" (
  echo Build did not produce ZoneMotionPC.exe. See build-windows.log.
  exit /b 1
)
if not exist "%~dp0dist\ZoneMotionPC\ZoneMotionPC_Data\globalgamemanagers" (
  echo The game's data folder is missing. See build-windows.log.
  exit /b 1
)
echo Ready: dist\ZoneMotionPC\ZoneMotionPC.exe
exit /b 0

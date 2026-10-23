@echo off
setlocal
set "ZONEMOTION_UNITY=%ProgramFiles%\Unity\Hub\Editor\2017.2.0f3\Editor\Unity.exe"
if defined UNITY_EDITOR_PATH set "ZONEMOTION_UNITY=%UNITY_EDITOR_PATH%"
if not exist "%ZONEMOTION_UNITY%" set "ZONEMOTION_UNITY=%ProgramFiles%\Unity\Editor\Unity.exe"
if not exist "%ZONEMOTION_UNITY%" (
  echo Unity 2017.2.0f3 with Windows x64 Build Support was not found.
  echo Open the project in an activated Unity editor, or set UNITY_EDITOR_PATH.
  exit /b 1
)
pushd "%~dp0"
"%ZONEMOTION_UNITY%" -batchmode -nographics -buildTarget Win64 -projectPath "%~dp0project" -executeMethod ZoneMotionPC.EditorBuild.BuildWindows -quit -logFile "%~dp0build-windows.log"
set "ZONEMOTION_BUILD_RESULT=%ERRORLEVEL%"
popd
if not "%ZONEMOTION_BUILD_RESULT%"=="0" (
  echo Build failed. See build-windows.log.
  exit /b %ZONEMOTION_BUILD_RESULT%
)
if not exist "%~dp0dist\ZoneMotionPC\ZoneMotionPC.exe" (
  echo Build did not produce ZoneMotionPC.exe. See build-windows.log.
  exit /b 1
)
echo Ready: dist\ZoneMotionPC\ZoneMotionPC.exe

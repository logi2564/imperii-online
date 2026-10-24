$ErrorActionPreference = 'Stop'
$root = Join-Path $env:GITHUB_WORKSPACE 'dist\ZoneMotionPC'
$vswhere = Join-Path ${env:ProgramFiles(x86)} 'Microsoft Visual Studio\Installer\vswhere.exe'
$vs = & $vswhere -latest -products '*' -requires Microsoft.VisualStudio.Component.VC.Tools.x86.x64 -property installationPath
if (-not $vs) { throw 'The runner needs the installed Visual C++ x64 compiler.' }
$vcvars = Join-Path $vs 'VC\Auxiliary\Build\vcvars64.bat'
$source = Join-Path $PSScriptRoot 'launcher.c'
$exe = Join-Path $root 'ZoneMotion.exe'
$object = Join-Path $env:RUNNER_TEMP 'zone-launcher.obj'
$batch = Join-Path $env:RUNNER_TEMP 'compile-zone-launcher.cmd'
$commands = @(
    '@echo off',
    ('call "' + $vcvars + '" >nul'),
    'if errorlevel 1 exit /b %errorlevel%',
    ('cl.exe /nologo /O2 /MT /W4 /std:c11 /utf-8 /DUNICODE /D_UNICODE "' + $source + '" /Fe:"' + $exe + '" /Fo:"' + $object + '" /link /SUBSYSTEM:WINDOWS user32.lib'),
    'exit /b %errorlevel%'
)
[IO.File]::WriteAllLines($batch, $commands, [Text.Encoding]::ASCII)
& $env:ComSpec /d /c ('"' + $batch + '"')
if ($LASTEXITCODE -ne 0 -or -not (Test-Path -LiteralPath $exe)) { throw 'The game launcher did not compile.' }
exit 0

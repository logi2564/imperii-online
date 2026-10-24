# Run in Windows PowerShell 5.1. Fixtures are isolated and never enter the release.
# This tests the CMD launcher, not Unity, the restored project, or gameplay.
$ErrorActionPreference = 'Stop'
Set-StrictMode -Version Latest

function Assert($Condition, [string]$Message) {
    if (-not $Condition) { throw $Message }
}

$sourceRoot = Split-Path -Parent $PSScriptRoot
$launchers = @(Get-ChildItem -LiteralPath $sourceRoot -Filter '*.cmd' |
    Where-Object { $_.Name -ne 'BUILD-WINDOWS.cmd' })
Assert ($launchers.Count -eq 1) 'Expected one play launcher.'
$launcherName = $launchers[0].Name
$unicode = [string][char]0x418 + [char]0x433 + [char]0x440 + [char]0x430
$tempRoot = Join-Path ([IO.Path]::GetTempPath()) ("Zone Motion $unicode & test! " + [guid]::NewGuid())
New-Item -ItemType Directory -Path $tempRoot | Out-Null
$gameFixture = Join-Path $tempRoot 'FixtureGame.exe'
$unityFixture = Join-Path $tempRoot 'Unity.exe'
$passed = 0

try {
    Add-Type -OutputAssembly $gameFixture -OutputType ConsoleApplication -TypeDefinition @'
using System;
using System.IO;
public static class LauncherFixtureGame {
    public static int Main() {
        File.WriteAllText(Environment.GetEnvironmentVariable("ZONEMOTION_TEST_GAME_MARKER"),
            Environment.CurrentDirectory);
        return 0;
    }
}
'@
    Add-Type -OutputAssembly $unityFixture -OutputType ConsoleApplication -TypeDefinition @'
using System;
using System.IO;
using System.Reflection;
[assembly: AssemblyInformationalVersion("2017.2.0f3")]
public static class LauncherFixtureEditor {
    static string Value(string[] args, string key) {
        int index = Array.IndexOf(args, key);
        if (index < 0 || index + 1 == args.Length) throw new Exception("Missing argument: " + key);
        return args[index + 1];
    }
    public static int Main(string[] args) {
        File.WriteAllText(Environment.GetEnvironmentVariable("ZONEMOTION_TEST_EDITOR_MARKER"),
            string.Join("\n", args));
        if (Array.IndexOf(args, "-batchmode") < 0 || Array.IndexOf(args, "-quit") < 0 ||
            Value(args, "-buildTarget") != "Win64" ||
            Value(args, "-executeMethod") != "ZoneMotionPC.EditorBuild.BuildWindows") return 41;
        string project = Value(args, "-projectPath");
        if (!File.Exists(Path.Combine(project, "fixture-project.txt"))) return 42;
        string mode = Environment.GetEnvironmentVariable("ZONEMOTION_TEST_EDITOR_MODE");
        string log = Value(args, "-logFile");
        File.WriteAllText(log, "Fixture editor (not Unity).\n");
        if (mode == "fail") return 17;
        if (mode == "silent") return 0;
        string output = Path.Combine(Path.GetDirectoryName(project), "dist", "ZoneMotionPC");
        Directory.CreateDirectory(output);
        File.Copy(Environment.GetEnvironmentVariable("ZONEMOTION_TEST_GAME_FIXTURE"),
            Path.Combine(output, "ZoneMotionPC.exe"), true);
        if (mode != "incomplete") {
            string data = Path.Combine(output, "ZoneMotionPC_Data");
            Directory.CreateDirectory(data);
            File.WriteAllText(Path.Combine(data, "globalgamemanagers"), "fixture");
        }
        File.AppendAllText(log, "WINDOWS_BUILD_COMPLETE: fixture\n");
        return 0;
    }
}
'@

    function New-Fixture([string]$Name) {
        $folder = Join-Path $tempRoot $Name
        New-Item -ItemType Directory -Path (Join-Path $folder 'project') -Force | Out-Null
        Set-Content -LiteralPath (Join-Path $folder 'project\fixture-project.txt') -Value 'fixture'
        Copy-Item -LiteralPath $launchers[0].FullName -Destination $folder
        Copy-Item -LiteralPath (Join-Path $sourceRoot 'BUILD-WINDOWS.cmd') -Destination $folder
        $env:ZONEMOTION_TEST_GAME_MARKER = Join-Path $folder 'game-started.txt'
        $env:ZONEMOTION_TEST_EDITOR_MARKER = Join-Path $folder 'editor-called.txt'
        $env:ZONEMOTION_TEST_GAME_FIXTURE = $gameFixture
        $env:ZONEMOTION_TEST_EDITOR_MODE = 'success'
        $env:ZONEMOTION_NO_PAUSE = '1'
        $env:UNITY_EDITOR_PATH = $unityFixture
        return $folder
    }

    function Invoke-Cmd([string]$Folder, [string]$Script = $launcherName) {
        Push-Location -LiteralPath $Folder
        try {
            $output = & $env:ComSpec /d /c ('call "' + $Script + '"') 2>&1
            $code = $LASTEXITCODE
            $output | Out-File -LiteralPath (Join-Path $Folder 'launcher-output.txt')
            return $code
        } finally { Pop-Location }
    }

    function Assert-GameStarted([string]$Folder) {
        $deadline = [DateTime]::UtcNow.AddSeconds(10)
        while (-not (Test-Path -LiteralPath $env:ZONEMOTION_TEST_GAME_MARKER) -and
            [DateTime]::UtcNow -lt $deadline) { Start-Sleep -Milliseconds 100 }
        Assert (Test-Path -LiteralPath $env:ZONEMOTION_TEST_GAME_MARKER) 'Game process was not launched.'
        $expected = Join-Path $Folder 'dist\ZoneMotionPC'
        $actual = [IO.File]::ReadAllText($env:ZONEMOTION_TEST_GAME_MARKER)
        Assert ($actual -eq $expected) ("Wrong game working directory. Expected [$expected], actual [$actual].")
    }

    $folder = New-Fixture 'No Unity'
    $env:UNITY_EDITOR_PATH = Join-Path $tempRoot 'missing\Unity.exe'
    Assert ((Invoke-Cmd $folder) -eq 2) 'Missing editor must return a clear failure.'
    Assert (-not (Test-Path -LiteralPath $env:ZONEMOTION_TEST_GAME_MARKER)) 'Launched without a build.'
    $passed++

    $folder = New-Fixture 'Build and launch'
    Assert ((Invoke-Cmd $folder) -eq 0) 'First-build launcher failed.'
    Assert (Test-Path -LiteralPath $env:ZONEMOTION_TEST_EDITOR_MARKER) 'Editor was not invoked.'
    Assert-GameStarted $folder
    $passed++

    Remove-Item -LiteralPath $env:ZONEMOTION_TEST_GAME_MARKER, $env:ZONEMOTION_TEST_EDITOR_MARKER
    $env:UNITY_EDITOR_PATH = Join-Path $tempRoot 'missing\Unity.exe'
    Assert ((Invoke-Cmd $folder) -eq 0) 'A completed build should launch without Unity.'
    Assert-GameStarted $folder
    Assert (-not (Test-Path -LiteralPath $env:ZONEMOTION_TEST_EDITOR_MARKER)) 'Rebuilt an existing game.'
    $passed++

    $folder = New-Fixture 'Build failed'
    $env:ZONEMOTION_TEST_EDITOR_MODE = 'fail'
    Assert ((Invoke-Cmd $folder) -eq 17) 'Lost the failed build exit code.'
    Assert (-not (Test-Path -LiteralPath $env:ZONEMOTION_TEST_GAME_MARKER)) 'Launched a failed build.'
    $passed++

    $folder = New-Fixture 'Missing data'
    $env:ZONEMOTION_TEST_EDITOR_MODE = 'incomplete'
    Assert ((Invoke-Cmd $folder) -eq 1) 'Accepted an incomplete build.'
    Assert (-not (Test-Path -LiteralPath $env:ZONEMOTION_TEST_GAME_MARKER)) 'Launched without game data.'
    $passed++

    # Stale files and a zero editor exit code must not conceal a failed build.
    $folder = New-Fixture 'Stale output'
    $env:ZONEMOTION_TEST_EDITOR_MODE = 'success'
    Assert ((Invoke-Cmd $folder 'BUILD-WINDOWS.cmd') -eq 0) 'Fixture setup failed.'
    $env:ZONEMOTION_TEST_EDITOR_MODE = 'silent'
    Assert ((Invoke-Cmd $folder 'BUILD-WINDOWS.cmd') -eq 1) 'Accepted stale files as a new build.'
    $passed++

    $report = [ordered]@{
        launcher_cases_passed = $passed
        unicode_spaces_ampersand_exclamation_paths = $true
        fixtures_only = $true
        unity_player_built = $false
        windows_gameplay_tested = $false
    }
    $report | ConvertTo-Json | Write-Output
    Assert ($passed -eq 6) 'Unexpected case count.'
} catch {
    $diagnosis = "Passed cases: $passed. " + $_.Exception.Message + " " + $_.ScriptStackTrace
    foreach ($log in @(Get-ChildItem -LiteralPath $tempRoot -Filter 'launcher-output.txt' -Recurse)) {
        $diagnosis += "`n" + $log.Directory.Name + ': ' + [IO.File]::ReadAllText($log.FullName)
    }
    foreach ($log in @(Get-ChildItem -LiteralPath $tempRoot -Filter 'build-windows.log' -Recurse)) {
        $diagnosis += "`nBuild log: " + [IO.File]::ReadAllText($log.FullName)
    }
    $escaped = $diagnosis.Replace('%', '%25').Replace("`r", '%0D').Replace("`n", '%0A')
    Write-Host "::error title=Windows launcher check::$escaped"
    throw
} finally {
    Remove-Item -LiteralPath $tempRoot -Recurse -Force
}

# Run the actual native game, never an executable fixture.
$ErrorActionPreference = 'Stop'
Set-StrictMode -Version Latest
$game = Join-Path $env:GITHUB_WORKSPACE 'dist\ZoneMotionPC'
$reports = Join-Path $env:GITHUB_WORKSPACE 'dist\native-validation'
New-Item -ItemType Directory -Path $reports -Force | Out-Null
$env:VK_ICD_FILENAMES = Join-Path $game 'SoftwareRenderer\vk_swiftshader_icd.json'
$env:ZONEMOTION_SMOKE_OUTPUT = $reports
$log = Join-Path $reports 'Player.log'
$process = $null
try {
    $process = Start-Process -FilePath (Join-Path $game 'ZoneMotionPC.exe') -WorkingDirectory $game -PassThru `
        -ArgumentList @('-force-vulkan', '-screen-fullscreen', '0', '-screen-width', '1280',
            '-screen-height', '720', '--zone-motion-smoke', '-logFile', ('"' + $log + '"'))
    $deadline = [DateTime]::UtcNow.AddSeconds(120)
    while (-not $process.HasExited -and [DateTime]::UtcNow -lt $deadline) { Start-Sleep -Milliseconds 500 }
    if (-not $process.HasExited) {
        Stop-Process -Id $process.Id -Force
        throw 'The native game did not finish menu/new-game validation within 120 seconds.'
    }
    $result = Join-Path $reports 'result.txt'
    if (-not (Test-Path -LiteralPath $result)) { throw 'The native game never completed its in-game checks.' }
    if ([IO.File]::ReadAllText($result).Trim() -ne 'PASS') { throw 'Native game validation reported failure.' }
    if ($process.ExitCode -ne 0) { throw "The game exited with code $($process.ExitCode)." }
    python "$PSScriptRoot\validate_frames.py" $reports
    if ($LASTEXITCODE -ne 0) { throw 'Native game screenshots or scene state are invalid.' }
} catch {
    $message = $_.Exception.Message
    if (Test-Path -LiteralPath $log) {
        $lines = [IO.File]::ReadAllLines($log)
        $message += "`n" + (($lines | Select-Object -First 70) -join "`n")
        $message += "`n...`n" + (($lines | Select-Object -Last 70) -join "`n")
    }
    $message = $message.Replace('%', '%25').Replace("`r", '%0D').Replace("`n", '%0A')
    Write-Host "::error title=Native game startup::$message"
    exit 1
}
exit 0

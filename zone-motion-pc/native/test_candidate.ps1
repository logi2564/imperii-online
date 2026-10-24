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
function Capture-GameWindow {
    try {
        if ($null -eq $process -or $process.HasExited) { return }
        $process.Refresh()
        $handle = $process.MainWindowHandle
        if ($handle -eq [IntPtr]::Zero) { return }
        Add-Type -AssemblyName System.Drawing
        Add-Type -TypeDefinition @'
using System;
using System.Runtime.InteropServices;
public static class NativeGameWindowCapture {
    [StructLayout(LayoutKind.Sequential)]
    public struct Rect { public int Left, Top, Right, Bottom; }
    [DllImport("user32.dll")]
    public static extern bool GetWindowRect(IntPtr hwnd, out Rect rect);
    [DllImport("user32.dll")]
    public static extern bool PrintWindow(IntPtr hwnd, IntPtr hdc, uint flags);
}
'@
        $bounds = New-Object NativeGameWindowCapture+Rect
        if (-not [NativeGameWindowCapture]::GetWindowRect($handle, [ref]$bounds)) { return }
        $width = $bounds.Right - $bounds.Left
        $height = $bounds.Bottom - $bounds.Top
        if ($width -le 0 -or $height -le 0 -or $width -gt 8192 -or $height -gt 8192) { return }
        $image = New-Object Drawing.Bitmap($width, $height)
        $graphics = [Drawing.Graphics]::FromImage($image)
        $dc = $graphics.GetHdc()
        try { $printed = [NativeGameWindowCapture]::PrintWindow($handle, $dc, 2) }
        finally { $graphics.ReleaseHdc($dc) }
        if ($printed) {
            $image.Save((Join-Path $reports 'startup-game-window.png'), [Drawing.Imaging.ImageFormat]::Png)
        }
        $graphics.Dispose()
        $image.Dispose()
        # The handle and title belong only to the child process started above.
        $process.MainWindowTitle | Out-File -LiteralPath (Join-Path $reports 'game-window.txt') -Encoding utf8
    } catch {
        $_ | Out-String | Out-File -LiteralPath (Join-Path $reports 'capture-error.txt') -Encoding utf8
    }
}
try {
    $process = Start-Process -FilePath (Join-Path $game 'ZoneMotionPC.exe') -WorkingDirectory $game -PassThru `
        -ArgumentList @('-force-vulkan', '-screen-fullscreen', '0', '-screen-width', '1280',
            '-screen-height', '720', '--zone-motion-smoke', '-logFile', ('"' + $log + '"'))
    $deadline = [DateTime]::UtcNow.AddSeconds(120)
    $captureAt = [DateTime]::UtcNow.AddSeconds(12)
    $captured = $false
    while (-not $process.HasExited -and [DateTime]::UtcNow -lt $deadline) {
        if (-not $captured -and [DateTime]::UtcNow -gt $captureAt) { Capture-GameWindow; $captured = $true }
        Start-Sleep -Milliseconds 500
    }
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
    if (-not (Test-Path -LiteralPath (Join-Path $reports 'startup-game-window.png'))) { Capture-GameWindow }
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

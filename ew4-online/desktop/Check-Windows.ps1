$ErrorActionPreference = 'SilentlyContinue'
# Read-only diagnostics. No dumps, usernames, serial numbers, network or uploads.
$lines = @('Европейская война 4: сведения о Windows', '')
$os = Get-CimInstance Win32_OperatingSystem
$lines += 'Windows build: ' + $os.BuildNumber
Get-CimInstance Win32_VideoController | ForEach-Object {
  $lines += 'GPU: ' + $_.Name
  $lines += 'GPU driver: ' + $_.DriverVersion
}
$events = Get-WinEvent -FilterHashtable @{LogName='System';Id=41;ProviderName='Microsoft-Windows-Kernel-Power'} -MaxEvents 5
foreach ($event in $events) {
  [xml]$xml = $event.ToXml()
  $field = $xml.Event.EventData.Data | Where-Object { $_.Name -eq 'BugcheckCode' }
  $code = [uint32]$field.'#text'
  if ($code -gt 0) { $lines += ('Записанный STOP CODE: 0x{0:X8}' -f $code); break }
}
if (-not ($lines | Where-Object { $_ -like 'Записанный STOP CODE:*' })) { $lines += 'В последних событиях не найден STOP CODE.' }
$lines += ''; $lines += 'Игра использует программное рисование; аппаратное ускорение отключено.'
$lines | Set-Content -LiteralPath (Join-Path $PSScriptRoot 'Windows-diagnostic.txt') -Encoding UTF8
$lines | ForEach-Object { Write-Host $_ }
Write-Host ''; Write-Host 'Файл остаётся только на вашем ПК: Windows-diagnostic.txt'
Read-Host 'Нажмите Enter для закрытия'

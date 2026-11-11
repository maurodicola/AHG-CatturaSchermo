# Autore: AHG
$ErrorActionPreference = 'Stop'
try {
    $installRoot = Join-Path $env:LOCALAPPDATA 'AHG\CatturaSchermo'
    [Microsoft.Win32.Registry]::CurrentUser.DeleteSubKeyTree('Software\Microsoft\Edge\NativeMessagingHosts\it.ahg.catturaschermo', $false)
    if (Test-Path -LiteralPath $installRoot) {
        Remove-Item -LiteralPath $installRoot -Recurse -Force
    }
    Write-Host 'Componente Windows rimosso.' -ForegroundColor Green
    Write-Host 'In edge://extensions rimuovi anche Cattura schermo - AHG.'
    exit 0
} catch {
    Write-Host ('Rimozione non completata: ' + $_.Exception.Message) -ForegroundColor Red
    exit 1
}

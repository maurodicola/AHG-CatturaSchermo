# Autore: AHG
# Richiede Windows PowerShell 5.1 e .NET Framework (inclusi in Windows 10/11).
$ErrorActionPreference = 'Stop'
try {
    $installRoot = Join-Path $env:LOCALAPPDATA 'AHG\CatturaSchermo'
    $sourceRoot = $PSScriptRoot
    if ($sourceRoot -eq $installRoot) { throw 'Esegui Installa.cmd dalla cartella estratta dallo ZIP.' }
    $sourceCode = Join-Path $sourceRoot 'native\AHGHost.cs'
    $tempExe = Join-Path ([IO.Path]::GetTempPath()) ('CatturaSchermo-' + [Guid]::NewGuid().ToString('N') + '.exe')
    try {
        Add-Type -Path $sourceCode -OutputAssembly $tempExe -OutputType ConsoleApplication -ReferencedAssemblies @('System.dll', 'System.Core.dll', 'System.Web.Extensions.dll') -ErrorAction Stop
        New-Item -ItemType Directory -Path $installRoot -Force | Out-Null
        $extensionPath = Join-Path $installRoot 'extension'
        New-Item -ItemType Directory -Path $extensionPath -Force | Out-Null
        Copy-Item -Path (Join-Path $sourceRoot 'extension\*') -Destination $extensionPath -Recurse -Force
        Copy-Item -LiteralPath $tempExe -Destination (Join-Path $installRoot 'AHGHost.exe') -Force
    } finally {
        if (Test-Path -LiteralPath $tempExe) { Remove-Item -LiteralPath $tempExe -Force }
    }
    Copy-Item -LiteralPath (Join-Path $sourceRoot 'Disinstalla.ps1') -Destination $installRoot -Force
    Copy-Item -LiteralPath (Join-Path $sourceRoot 'Disinstalla.cmd') -Destination $installRoot -Force
    $hostManifestPath = Join-Path $installRoot 'it.ahg.catturaschermo.json'
    $hostManifest = [ordered]@{
        name = 'it.ahg.catturaschermo'
        description = 'AHG - Cattura schermo'
        path = (Join-Path $installRoot 'AHGHost.exe')
        type = 'stdio'
        allowed_origins = @('chrome-extension://pjkfgghgaepmjbhplfpjaagpmglkcpbl/')
    }
    [IO.File]::WriteAllText($hostManifestPath, ($hostManifest | ConvertTo-Json -Depth 4), (New-Object Text.UTF8Encoding($false)))
    $registryKey = [Microsoft.Win32.Registry]::CurrentUser.CreateSubKey('Software\Microsoft\Edge\NativeMessagingHosts\it.ahg.catturaschermo')
    try { $registryKey.SetValue('', $hostManifestPath, [Microsoft.Win32.RegistryValueKind]::String) } finally { $registryKey.Close() }
    Write-Host ''
    Write-Host 'Componente Windows installato.' -ForegroundColor Green
    Write-Host 'Ora apri edge://extensions e attiva Modalita sviluppatore.'
    Write-Host 'Scegli Carica estensione decompressa e seleziona questa cartella:'
    Write-Host $extensionPath -ForegroundColor Cyan
    Write-Host 'Poi fissa Cattura schermo - AHG nella barra di Edge dal menu Estensioni.'
    Start-Process explorer.exe -ArgumentList ('"' + $installRoot + '"')
    exit 0
} catch {
    Write-Host ''
    Write-Host ('Installazione non completata: ' + $_.Exception.Message) -ForegroundColor Red
    Write-Host 'Copia questo messaggio e invialo a Gaia.'
    exit 1
}

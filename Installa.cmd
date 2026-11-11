@echo off
setlocal
"%SystemRoot%\System32\WindowsPowerShell\v1.0\powershell.exe" -NoLogo -NoProfile -ExecutionPolicy Bypass -File "%~dp0Installa.ps1"
set "clicExit=%errorlevel%"
echo.
pause
exit /b %clicExit%

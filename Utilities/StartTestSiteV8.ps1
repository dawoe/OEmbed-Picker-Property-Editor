$CurrentDir = Split-Path $MyInvocation.MyCommand.Path
$RootDir = Split-Path -Path $CurrentDir -Parent
$SiteDir= "$RootDir\testsites\v8"
$solutionDir = "$RootDir\src"

write-host $CurrentDir

Write-Host "Starting IIS Express website"

Start-process "C:\Program Files\IIS Express\iisexpress.exe" -ArgumentList "/port:8100 /path:$siteDir" -WindowStyle Hidden
Start-Sleep -m 1000

Write-Host "IIS Express website started"

Write-Host "Open website in browser"

Start "http://localhost:8100"

Write-Host "Press Q to stop"
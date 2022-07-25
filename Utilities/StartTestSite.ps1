$CurrentDir = Split-Path $MyInvocation.MyCommand.Path
. $CurrentDir\Variables.ps1


dotnet watch run --no-restore --project "$TestSitesFolder\$TestProjectName"
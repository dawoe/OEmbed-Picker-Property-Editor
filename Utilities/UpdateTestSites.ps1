$CurrentDir = Split-Path $MyInvocation.MyCommand.Path
. $CurrentDir\Variables.ps1

Invoke-Expression "$CurrentDir\CreateNugetPackages.ps1"

dotnet build

cd $CurrentDir
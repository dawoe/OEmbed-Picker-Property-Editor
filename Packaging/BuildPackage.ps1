param($versionSuffix)


$CurrentDir = Split-Path $MyInvocation.MyCommand.Path
$RootDir = Split-Path -Path $CurrentDir -Parent
$UtilitiesDir = "$RootDir\Utilities"
$DistDir = "$RootDir\dist"

#Remove dist folder
if(Test-Path -Path $DistDir -PathType Leaf)
{
    Remove-Item -LiteralPath $DistDir -Force -Recurse
}

#Prepare build
. $UtilitiesDir\Prepare.ps1 

Prepare-Solution -CurrentDir $UtilitiesDir -Configuration 'Release'

$buildFolder = Join-Path -Path $RootDir -ChildPath 'build';

if(-Not([string]::IsNullOrEmpty($versionSuffix)))
{
    dotnet pack $RootDir\src\Dawoe.OEmbedPickerPropertyEditor.sln -c Release -o $DistDir --version-suffix $VersionSuffix --no-build
}
else
{
    dotnet pack $RootDir\src\Dawoe.OEmbedPickerPropertyEditor.sln -c Release -o $DistDir  --no-build
}
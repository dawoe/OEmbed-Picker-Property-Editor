param($versionSuffix)


$CurrentDir = Split-Path $MyInvocation.MyCommand.Path
$RootDir = Split-Path -Path $CurrentDir -Parent
$DistDir = "$RootDir\dist"
$SrcDir = "$RootDir\src"
$ClientDir = "$SrcDir\Dawoe.OEmbedPickerPropertyEditor.UI\client"
$SolutionFile = "$SrcDir\Dawoe.OEmbedPickerPropertyEditor.sln"

#Remove dist folder
if(Test-Path -Path $DistDir)
{
    Remove-Item -Recurse -Force $DistDir;
}

Write-Host "Preparing solution"

cd $ClientDir
npm install
npm run build

Write-Host "Create nuget packages"

if(-Not([string]::IsNullOrEmpty($versionSuffix)))
{
    if(-Not([string]::IsNullOrEmpty($env:APPVEYOR_BUILD_NUMBER)))
    {
        $VersionSuffix = "$VersionSuffix-$env:APPVEYOR_BUILD_NUMBER"
    }
    dotnet pack $SolutionFile -c Release -o $DistDir --version-suffix $VersionSuffix 
}
else
{
    dotnet pack $SolutionFile -c Release -o $DistDir 
}
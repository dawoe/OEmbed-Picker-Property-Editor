$Url = 'https://our.umbraco.com/ReleaseDownload?id=276831' 

$CurrentDir = Split-Path $MyInvocation.MyCommand.Path
$RootDir = Split-Path -Path $CurrentDir -Parent
$DownloadDir = "$RootDir\downloads"
$ZipFile =  "$DownloadDir\8.1.0.zip"
$Destination= "$RootDir\testsites"
$solution= "$RootDir\src\Dawoe.OEmbedPickerPropertyEditor.sln"
$ToolsDir = "$RootDir\tools"

Write-Host "Cleaning up existing test site"

if (Test-Path -Path $DownloadDir) {
    Remove-Item -LiteralPath $DownloadDir -Force -Recurse
}

if (Test-Path -Path $Destination) {
    Remove-Item -LiteralPath $Destination -Force -Recurse
}

Write-Host "Creating download directory"

New-Item -Path $RootDir -Name "downloads" -ItemType "directory"

New-Item -Path $RootDir -Name "tools" -ItemType "directory"

Write-Host "Downloading Umbraco 8.1.0 to $ZipFile"

Invoke-WebRequest -Uri $Url -OutFile $ZipFile 
 
Write-Host "Extracting downloaded zip file to $Destination"

Expand-Archive -LiteralPath $ZipFile -DestinationPath $Destination -Force

Write-Host "Cleaning up downloaded files"

Remove-Item -LiteralPath $DownloadDir -Force -Recurse

#Build solution

# Ensure NuGet.exe
$nuget_exe = "$ToolsDir\nuget.exe";

If (-NOT(Test-Path -Path $nuget_exe)) {
    Write-Host "Retrieving nuget.exe...";
    Invoke-WebRequest "https://dist.nuget.org/win-x86-commandline/latest/nuget.exe" -OutFile $nuget_exe;
}


# Ensure vswhere.exe
$vswhere_exe = "$ToolsDir\vswhere.exe";

If (-NOT(Test-Path -Path $vswhere_exe)) {
    Write-Host "Retrieving vswhere.exe...";
    Invoke-WebRequest "https://github.com/microsoft/vswhere/releases/download/2.8.4/vswhere.exe" -OutFile $vswhere_exe;
}

$msbuild_exe = & "$vswhere_exe" -Latest -Requires Microsoft.Component.MSBuild -Find MSBuild\**\Bin\MSBuild.exe | Select-Object -First 1
if (-NOT(Test-Path $msbuild_exe)) {
    throw 'MSBuild not found!';
}


Write-host "Building vs solution"

Write-Host 'Compiling Visual Studio solution.';
& $msbuild_exe "$solution" /p:Configuration=Release
if (-NOT $?) {
    throw 'The MSBuild process returned an error code.';
}

#Invoke-Expression "$currentDir\StartTestSite.ps1"
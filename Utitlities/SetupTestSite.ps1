function Create-V8-Site {
    [CmdletBinding()]
	param(
		[Parameter()]
		[string] $RootDir,

        [Parameter()]
		[string] $Destination,

        [Parameter()]
		[string] $DownloadUrl = 'https://our.umbraco.com/ReleaseDownload?id=276831' 
	)

    $DownloadDir = "$RootDir\downloads"
    $ZipFile =  "$DownloadDir\umbraco8.zip"

    if (Test-Path -Path $DownloadDir) {
        Remove-Item -LiteralPath $DownloadDir -Force -Recurse
    }

    Write-Host "Creating download directory"

    New-Item -Path $RootDir -Name "downloads" -ItemType "directory"

    Write-Host "Downloading Umbraco 8.1.0 to $ZipFile"

    Invoke-WebRequest -Uri $DownloadUrl -OutFile $ZipFile 
 
    Write-Host "Extracting downloaded zip file to $Destination"

    Expand-Archive -LiteralPath $ZipFile -DestinationPath "$Destination\v8" -Force

    Write-Host "Cleaning up downloaded files"

    Remove-Item -LiteralPath $DownloadDir -Force -Recurse
}

function Create-V9-Site {
    [CmdletBinding()]
	param(
		[Parameter()]
		[string] $Destination        
	)

    $CurrentDir = Get-Location

    Write-Host $CurrentDir

    Write-Host "Installing Umbraco 9 templates"
    dotnet new --install Umbraco.Templates::9.0.0

    Write-Host "Creating Umbraco 9 site"
    cd $Destination
    dotnet new umbraco --SqlCe -n v9

    cd "$Destination\v9"

    dotnet add package Umbraco.TheStarterKit --version 9.0.0 --source https://api.nuget.org/v3/index.json

    dotnet build

    cd $CurrentDir
}


$CurrentDir = Split-Path $MyInvocation.MyCommand.Path
$RootDir = Split-Path -Path $CurrentDir -Parent
$Destination= "$RootDir\testsites"

Write-Host "Cleaning up existing test site"

if (Test-Path -Path $Destination) {
    Remove-Item -LiteralPath $Destination -Force -Recurse
}

 New-Item -Path $RootDir -Name "testsites" -ItemType "directory"

Create-V8-Site -RootDir $RootDir -Destination $Destination

Create-V9-Site $Destination

. $CurrentDir\Compile.ps1

Compile-Solution -RootDir $RootDir -Configuration Debug

 cd "$Destination\v9"

 dotnet add reference ../../src/Dawoe.OEmbedPickerPropertyEditor/Dawoe.OEmbedPickerPropertyEditor.csproj
 dotnet add reference ../../src/Dawoe.OEmbedPickerPropertyEditor.Web/Dawoe.OEmbedPickerPropertyEditor.Web.csproj
 dotnet build
    cd $CurrentDir
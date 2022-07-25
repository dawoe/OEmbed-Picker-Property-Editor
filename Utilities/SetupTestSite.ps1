function Create-Test-Site {
    [CmdletBinding()]
	param(
		[Parameter()]
		[string] $Destination,  
        
        [Parameter()]
		[string] $ProjectName
	)

    $CurrentDir = Get-Location

    Write-Host $CurrentDir

    Write-Host "Installing Umbraco templates"
    dotnet new --install Umbraco.Templates

    Write-Host "Creating Umbraco site"
    cd $Destination
    dotnet new umbraco -n $ProjectName --development-database-type SQLite --version 10.0.0

    cd "$Destination\$ProjectName"

    dotnet add package Umbraco.TheStarterKit --version 10.0.0 --source https://api.nuget.org/v3/index.json

    dotnet build

    # load project file xml
    $xml = New-Object System.Xml.XmlDocument
    $xml.Load("$Destination\$ProjectName\$ProjectName.csproj")

    $propertyGroup = Select-XML -Xml $xml -XPath '//PropertyGroup[1]'
    $newNode = $xml.CreateElement('RestoreAdditionalProjectSources')
    $newNode.InnerText = '../Nuget'
    $propertyGroup.Node.AppendChild($newNode)  
    $xml.Save("$Destination\$ProjectName\$ProjectName.csproj")

    cd $CurrentDir
}


$CurrentDir = Split-Path $MyInvocation.MyCommand.Path
$RootDir = Split-Path -Path $CurrentDir -Parent
$Destination= "$RootDir\testsites"
$TestProjectName = "OEmbedPickerSite"
$PackageName = "Dawoe.OEmbedPickerPropertyEditor"

Write-Host "Cleaning up existing test site"

if (Test-Path -Path $Destination) {
    Remove-Item -LiteralPath $Destination -Force -Recurse
}

New-Item -Path $RootDir -Name "testsites" -ItemType "directory"

Create-Test-Site $Destination $TestProjectName

Write-Host "Create nuget packages"

$dateTime = get-date -Format "ddMMyyyyHHmmss"

Write-Host "Version suffix $dateTime"

dotnet pack $RootDir\src\$PackageName.sln -c Debug -o $Destination\nuget --version-suffix "$dateTime" --no-build

cd "$Destination\$TestProjectName"

dotnet add package $PackageName -v 10.0.0-$dateTime --no-restore

dotnet build

cd $CurrentDir
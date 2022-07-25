function Create-Test-Site {
    [CmdletBinding()]
	param(
		[Parameter()]
		[string] $Destination,  
        
        [Parameter()]
		[string] $ProjectName,

        [Parameter()]
		[string] $CmsVersion
	)

    $CurrentDir = Get-Location

    Write-Host $CurrentDir

    Write-Host "Installing Umbraco templates"
    dotnet new --install Umbraco.Templates

    Write-Host "Creating Umbraco site"
    cd $Destination
    dotnet new umbraco -n $ProjectName --development-database-type SQLite --version $CmsVersion

    cd "$Destination\$ProjectName"

    dotnet add package Umbraco.TheStarterKit --version $CmsVersion --source https://api.nuget.org/v3/index.json

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
. $CurrentDir\Variables.ps1

Write-Host "Cleaning up existing test site"

if (Test-Path -Path $TestSitesFolder) {
    Remove-Item -LiteralPath $TestSitesFolder -Force -Recurse
}

New-Item -Path $RootDir -Name $TestSitesFolderName -ItemType "directory"

Create-Test-Site $TestSitesFolder $TestProjectName $UmbracoVersion

Invoke-Expression "$CurrentDir\CreateNugetPackages.ps1"

dotnet build

cd $CurrentDir
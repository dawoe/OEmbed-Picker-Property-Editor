param($versionSuffix)


$CurrentDir = Split-Path $MyInvocation.MyCommand.Path
$RootDir = Split-Path -Path $CurrentDir -Parent
$UtilitiesDir = "$RootDir\Utilities"
$DistDir = "$RootDir\dist"
$SrcDir = "$RootDir\src"
$SolutionFile = "$SrcDir\Dawoe.OEmbedPickerPropertyEditor.sln"

#Remove dist folder
if(Test-Path -Path $DistDir)
{
    Remove-Item -Recurse -Force $DistDir;
}

Write-Host "Preparing solution"

#Prepare build
. $UtilitiesDir\Prepare.ps1 

Prepare-Solution -CurrentDir $UtilitiesDir -Configuration 'Release'

$buildFolder = Join-Path -Path $RootDir -ChildPath 'build';

Write-Host "Create nuget packages"

if(-Not([string]::IsNullOrEmpty($versionSuffix)))
{
    if(-Not([string]::IsNullOrEmpty($env:APPVEYOR_BUILD_VERSION)))
    {
        $VersionSuffix = "$VersionSuffix-$env:APPVEYOR_BUILD_VERSION"
    }
    dotnet pack $SolutionFile -c Release -o $DistDir --version-suffix $VersionSuffix --no-build
}
else
{
    dotnet pack $SolutionFile -c Release -o $DistDir  --no-build
}

Write-Host "Getting version for package"

#Get version number
$buildPropsXml = New-Object System.Xml.XmlDocument
$buildPropsXml.Load("$SrcDir\Directory.Build.props")

$version = Select-XML -xml $buildPropsXml -XPath '(//VersionPrefix)[1]'

if(-Not([string]::IsNullOrEmpty($versionSuffix)))
{
    $version = "$version-$VersionSuffix"
}

Write-Host "Assembling Umbraco Package"

$umbFolder = Join-Path -Path $buildFolder -ChildPath "__umb";
if (!(Test-Path -Path $umbFolder)) {New-Item -Path $umbFolder -Type Directory;}

$umbracoManifest = Join-Path -Path $CurrentDir -ChildPath "manifest-umbraco.xml";
$umbracoPackageXml = [xml](Get-Content $umbracoManifest);
$umbracoPackageXml.umbPackage.info.package.version = "$($version)";

$filesXml = $umbracoPackageXml.CreateElement("files");

$assetFiles = Get-ChildItem -Path $buildFolder -File -Recurse;
foreach($assetFile in $assetFiles){

    $hash = Get-FileHash -Path $assetFile.FullName -Algorithm MD5;
    $guid = $hash.Hash.ToLower() + $assetFile.Extension;
    $orgPath = "~" + $assetFile.Directory.FullName.Replace($buildFolder, "").Replace("\", "/");

    $fileXml = $umbracoPackageXml.CreateElement("file");
    $fileXml.set_InnerXML("<guid>${guid}</guid><orgPath>${orgPath}</orgPath><orgName>$($assetFile.Name)</orgName>");
    $filesXml.AppendChild($fileXml);

    Copy-Item -Path $assetFile.FullName -Destination "${umbFolder}\${guid}";
}

$umbracoPackageXml.umbPackage.ReplaceChild($filesXml, $umbracoPackageXml.SelectSingleNode("/umbPackage/files")) | Out-Null;
$umbracoPackageXml.Save("${umbFolder}\package.xml");

Write-Host "Creating Umbraco Package zip file"

Compress-Archive -Path "${umbFolder}\*" -DestinationPath "${DistDir}\Dawoe.OEmbedPickerPropertyEditor_$version.zip" -Force;


# Tidy up folders
Write-Host "Cleaning up"
Remove-Item -Recurse -Force $buildFolder;
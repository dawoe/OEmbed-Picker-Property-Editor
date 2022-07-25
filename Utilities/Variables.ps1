$TestSitesFolder$CurrentDir = Split-Path $MyInvocation.MyCommand.Path
$RootDir = Split-Path -Path $CurrentDir -Parent
$TestSitesFolderName = "testsites"
$TestSitesFolder = "$RootDir\$TestSitesFolderName"
$TestProjectName = "OEmbedPickerSite"
$PackageName = "Dawoe.OEmbedPickerPropertyEditor"
$SourceDir = "$RootDir\src"
$UmbracoVersion = "10.0.0"
Write-Host "Create nuget packages"

$directoryBuildProps = [xml](Get-Content -Path "$SourceDir\Directory.Build.props");
$version = $directoryBuildProps.Project.PropertyGroup.VersionPrefix;
Write-Host "Package version: $version";

$dateTime = get-date -Format "yyyyMMddHHmmss"

Write-Host "Version suffix $dateTime"

if (Test-Path -Path  $TestSitesFolder\nuget) {
    Remove-Item -LiteralPath $TestSitesFolder\nuget -Force -Recurse
}

dotnet pack $SourceDir\$SolutionName.sln -c Debug -o $TestSitesFolder\nuget --version-suffix "$dateTime"

cd "$TestSitesFolder\$TestProjectName"

dotnet add package $PackageName -v "$($version)-$dateTime".trim()
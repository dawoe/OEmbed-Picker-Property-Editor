Write-Host "Create nuget packages"

$directoryBuildProps = [xml](Get-Content -Path "$SourceDir\Directory.Build.props");
$version = $directoryBuildProps.Project.PropertyGroup.VersionPrefix;
Write-Host "Package version: $version";

$dateTime = get-date -Format "ddMMyyyyHHmmss"

Write-Host "Version suffix $dateTime"

dotnet pack $SourceDir\$PackageName.sln -c Debug -o $TestSitesFolder\nuget --version-suffix "$dateTime"

cd "$TestSitesFolder\$TestProjectName"

dotnet add package $PackageName -v $version-$dateTime
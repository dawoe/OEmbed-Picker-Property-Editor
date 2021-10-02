function Compile-Solution {
    [CmdletBinding()]
	param(
		[Parameter()]
		[string] $RootDir,
        
        [Parameter()]
		[string] $Configuration = 'Debug'
	)

    $projectDir = "$RootDir\src\Dawoe.OEmbedPickerPropertyEditor"
    $solution= "$RootDir\src\Dawoe.OEmbedPickerPropertyEditor.sln"
    $ToolsDir = "$RootDir\tools"

    # Build the VS project
    Write-Host 'Cleaning Visual Studio solution.';
    Remove-Item -Recurse -Force "$projectDir\obj";
    & dotnet clean $solution;

    Write-Host 'Compiling Visual Studio solution.';
    & dotnet build $solution --configuration $Configuration
    if (-NOT $?) {
        throw 'The dotnet CLI returned an error code.';
    }
}
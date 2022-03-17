function Prepare-Solution {
    [CmdletBinding()]
    param( 
        [Parameter()]
		[string] $CurrentDir,

        [Parameter()]
        [string] $Configuration = 'Debug'
    )
    
    $RootDir = Split-Path -Path $CurrentDir -Parent
    $buildFolder = Join-Path -Path $RootDir -ChildPath 'build';

    #Compile solution
    . $CurrentDir\Compile.ps1

    Compile-Solution -RootDir $RootDir -Configuration $Configuration

    #Clean build folder
    if (Test-Path -Path $buildFolder) {Remove-Item -Recurse -Force $buildFolder}

    New-Item -Path $buildFolder -Type Directory

    # Copy DLL to build folder
    $binFolder = Join-Path -Path $buildFolder -ChildPath "bin";
    if (!(Test-Path -Path $binFolder)) {New-Item -Path $binFolder -Type Directory;}

    Copy-Item -Path "${RootDir}\src\Dawoe.OEmbedPickerPropertyEditor\bin\${Configuration}\net472\Dawoe*" -Destination $binFolder;

    #Copy UI to build folder
    Copy-Item -Path  "${RootDir}\src\Dawoe.OEmbedPickerPropertyEditor.UI\App_Plugins\" -Destination $buildFolder -Recurse -Force
}
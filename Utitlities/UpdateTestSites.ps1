$CurrentDir = Split-Path $MyInvocation.MyCommand.Path

#Prepare update
. $CurrentDir\Prepare.ps1 

Prepare-Solution -CurrentDir $CurrentDir

$RootDir = Split-Path -Path $CurrentDir -Parent
$buildFolder = Join-Path -Path $RootDir -ChildPath 'build';

#Copy App_Plugins folder
Copy-Item -Path "$buildFolder\App_Plugins" -Destination "$RootDir\testsites\v8" -Recurse -Force
Copy-Item -Path "$buildFolder\App_Plugins" -Destination "$RootDir\testsites\v9" -Recurse -Force

#Copy bin folder
Copy-Item -Path "$buildFolder\bin\net472\*.*" -Destination "$RootDir\testsites\v8\bin" -Force
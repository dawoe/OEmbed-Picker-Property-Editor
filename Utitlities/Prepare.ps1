param(   
    [string]$ConfigurationName = 'Release'
);

$CurrentDir = Split-Path $MyInvocation.MyCommand.Path
$RootDir = Split-Path -Path $CurrentDir -Parent

. $CurrentDir\Compile.ps1

Compile-Solution -RootDir $RootDir -Configuration $ConfigurationName
$CurrentDir = Split-Path $MyInvocation.MyCommand.Path
$RootDir = Split-Path -Path $CurrentDir -Parent
$SiteDir= "$RootDir\testsites\v9"



dotnet watch run --no-restore --project $SiteDir
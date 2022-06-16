$OperatingSystemBase = if ($IsWindows) {$env:SYSTEMDRIVE} Else {"~"}
$ModulePath = Join-Path $PSScriptRoot "modules"
$BaseDirectory = Join-Path $OperatingSystemBase "code" "PomeloMariaDbTest"

# Import all modules within the powershell/modules directory
# 
# Implementations for all custom commands can be found within the powershell/modules directory
Get-ChildItem -Path $ModulePath | ForEach-Object -Process { Import-Module $_ }

Add-NewMigration -BaseDirectory $BaseDirectory
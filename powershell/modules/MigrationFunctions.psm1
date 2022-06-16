function ErrorExit 
{
    Read-Host -Prompt "Press any key to exit"
    exit
}

function Add-NewMigration 
{
    [CmdletBinding()]
    param (
        [Parameter(Position = 0, Mandatory,  HelpMessage = "The migration directory.")]
        [ValidateScript({
            if( -Not ($_ | Test-Path) ) 
            {
                throw "Directory `"$($_)`" does not exist"
            }
            return $true
        })]
        [System.IO.FileInfo]$BaseDirectory,

        [Parameter(Position = 1, HelpMessage = "The name of the migration being created.")]
        [ValidateNotNullOrEmpty()]
        [string]$MigrationName = $(Read-Host "`nEnter the name of the migration being created"),

        [Parameter(Position = 2, HelpMessage = "The prefix of the context that a migration should be created for (e.g. TestContext -> Test)")]
        [ValidateNotNullOrEmpty()]
        [string]$ContextPrefix = $(Read-Host "`nEnter the prefix of the context that a migration should be created for (e.g. TestContext -> Test)"),

        [Parameter(Position = 3, HelpMessage="The desired folder name for the context being created. Leave empty to use the context prefix.")]
        [string]$DesiredFolderName = $(Read-Host "`nEnter the desired folder name for the context being created (leave empty to use the context prefix)")
    )

    if ([string]::IsNullOrWhitespace($DesiredFolderName)) 
    {
        $DesiredFolderName = $ContextPrefix 
    }
    $MigrationBase = Join-Path $BaseDirectory "PomeloMariaDbTest.Api"
    $MigrationAssembly = Join-Path $BaseDirectory "PomeloMariaDbTest.Data.Migrations"
    $OutputLocation = Join-Path $MigrationAssembly $DesiredFolderName

    Write-Host -ForegroundColor Magenta "`r`n Creating $($MigrationName) for $($ContextPrefix)Context in directory $($OutputLocation)"
    Set-Location $MigrationBase

    dotnet ef migrations add $MigrationName --context "$($ContextPrefix)Context" --project $MigrationAssembly --output-dir $OutputLocation --verbose
      
    if ($LASTEXITCODE -ne 0)
    {
        ErrorExit
    }
}
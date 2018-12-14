$DOCS_PATH = "$PSScriptRoot/../docs"
$SOURCE_PATH = "$PSScriptRoot/../source/SPClientCore"

Import-Module -Name 'platyPS'
New-ExternalHelp -Path $DOCS_PATH -OutputPath $SOURCE_PATH -Force

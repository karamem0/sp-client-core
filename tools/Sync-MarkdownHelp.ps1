#
# Copyright (c) 2020 karamem0
#
# This software is released under the MIT License.
#
# https://github.com/karamem0/SPClientCore/blob/master/LICENSE
#

$SOURCE_PATH = "$PSScriptRoot/../source/SPClientCore"
$SOURCE_HELP_FILE_PATH = "$PSScriptRoot/../source/SPClientCore/bin/Debug/netstandard2.0/publish/SPClientCore.dll-Help.xml"
$SOURCE_MODULE_PATH = "$PSScriptRoot/../source/SPClientCore/bin/Debug/netstandard2.0/publish/SPClientCore.psd1"
$DOCS_PATH = "$PSScriptRoot/../docs"

dotnet publish $SOURCE_PATH
Remove-Item $SOURCE_HELP_FILE_PATH
Import-Module -Name $SOURCE_MODULE_PATH
Import-Module -Name 'platyPS'
New-MarkdownHelp -Module 'SPClientCore' -OutputFolder $DOCS_PATH -ErrorAction SilentlyContinue
Update-MarkdownHelp -Path $DOCS_PATH

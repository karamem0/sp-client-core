#
# Copyright (c) 2021 karamem0
#
# This software is released under the MIT License.
#
# https://github.com/karamem0/SPClientCore/blob/master/LICENSE
#

$DOCS_PATH = "$PSScriptRoot/../docs"
$SOURCE_PATH = "$PSScriptRoot/../source/SPClientCore"

Import-Module -Name 'platyPS'
New-ExternalHelp -Path $DOCS_PATH -OutputPath $SOURCE_PATH -Force

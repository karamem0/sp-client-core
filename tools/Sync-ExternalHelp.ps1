#
# Copyright (c) 2021 karamem0
#
# This software is released under the MIT License.
#
# https://github.com/karamem0/spclientcore/blob/master/LICENSE
#

$DOCS_PATH = "$PSScriptRoot/../docs"
$SOURCE_PATH = "$PSScriptRoot/../source/Karamem0.SPClientCore/Karamem0.SPClientCore.dll-help.xml"

Import-Module -Name 'platyPS'
New-ExternalHelp -Path $DOCS_PATH -OutputPath $SOURCE_PATH -Force

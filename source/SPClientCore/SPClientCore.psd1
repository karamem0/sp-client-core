#
# Copyright (c) 2018 karamem0
#
# This software is released under the MIT License.
#
# https://github.com/karamem0/SPClientCore/blob/master/LICENSE
#

@{

# Script module or binary module file associated with this manifest.
RootModule = 'SPClientCore.dll'

# Version number of this module.
ModuleVersion = '1.1.0'

# ID used to uniquely identify this module
GUID = '83E99C54-16E5-4ABA-96EC-76830CCDFFEF'

# Author of this module
Author = 'karamem0'

# Company or vendor of this module
CompanyName = 'karamem0'

# Copyright statement for this module
Copyright = 'Copyright (c) 2018 karamem0'

# Description of the functionality provided by this module
Description = 'SharePoint Service Module for PowerShell Core'

# Minimum version of the Windows PowerShell engine required by this module
PowerShellVersion = '6.0'

# Name of the Windows PowerShell host required by this module
# PowerShellHostName = ''

# Minimum version of the Windows PowerShell host required by this module
# PowerShellHostVersion = ''

# Minimum version of Microsoft .NET Framework required by this module
# DotNetFrameworkVersion = ''

# Minimum version of the common language runtime (CLR) required by this module
# CLRVersion = ''

# Processor architecture (None, X86, Amd64) required by this module
# ProcessorArchitecture = ''

# Modules that must be imported into the global environment prior to importing this module
# RequiredModules = @()

# Assemblies that must be loaded prior to importing this module
RequiredAssemblies = @(
    'Microsoft.Extensions.DependencyInjection.dll'
    'Microsoft.Extensions.DependencyInjection.Abstractions.dll'
    'Newtonsoft.Json.dll'
)

# Script files (.ps1) that are run in the caller's environment prior to importing this module.
# ScriptsToProcess = @()

# Type files (.ps1xml) to be loaded when importing this module
# TypesToProcess = @()

# Format files (.ps1xml) to be loaded when importing this module
# FormatsToProcess = @()

# Modules to import as nested modules of the module specified in RootModule/ModuleToProcess
# NestedModules = @()

# Functions to export from this module
FunctionsToExport = '*'

# Cmdlets to export from this module
CmdletsToExport = '*'

# Variables to export from this module
VariablesToExport = '*'

# Aliases to export from this module
AliasesToExport = '*'

# List of all modules packaged with this module
# ModuleList = @()

# List of all files packaged with this module
# FileList = @()

# Private data to pass to the module specified in RootModule/ModuleToProcess
PrivateData = @{

    PSData = @{

        # Tags applied to this module. These help with module discovery in online galleries. 
        # Tags = @()

        # A URL to the license for this module.
        LicenseUri = 'https://github.com/karamem0/SPClientCore/blob/master/LICENSE'

        # A URL to the main website for this project. 
        ProjectUri = 'https://github.com/karamem0/SPClientCore'

        # A URL to an icon representing this module. 
        # IconUri = ''

        # ReleaseNotes of this module 
        # ReleaseNotes = ''

    }

}

# HelpInfo URI of this module
# HelpInfoURI = ''

# Default prefix for commands exported from this module. Override the default prefix using Import-Module -Prefix.
# DefaultCommandPrefix = ''

}

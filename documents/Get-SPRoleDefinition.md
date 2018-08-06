---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Get-SPRoleDefinition

## SYNOPSIS
Gets a role definition.

## SYNTAX

```
Get-SPRoleDefinition [-RoleDefinition] <RoleDefinitionPipeBind> [-Includes <String[]>] [<CommonParameters>]
```

## DESCRIPTION
{{Fill in the Description}}

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-SPRoleDefinition -RoleDefinition 1073741826
```

Gets the role definition by role definition ID.

### Example 2
```powershell
PS C:\> Get-SPRoleDefinition -RoleDefinition 'Full Control'
```

Gets the role definition by role definition name.

### Example 3
```powershell
PS C:\> Get-SPRoleDefinition -RoleDefinition 'Administrator'
```

Gets the role definition by role definition type.

## PARAMETERS

### -Includes
Indicates the property name collection to include in the result object.

```yaml
Type: String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RoleDefinition
Indicates the role definition ID, name or type.

```yaml
Type: RoleDefinitionPipeBind
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable.
For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Karamem0.SharePoint.PowerShell.PipeBinds.Core.RoleDefinitionPipeBind

## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.Core.RoleDefinition

## NOTES

## RELATED LINKS

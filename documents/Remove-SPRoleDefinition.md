---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Remove-SPRoleDefinition

## SYNOPSIS
Removes a role definition.

## SYNTAX

```
Remove-SPRoleDefinition [-RoleDefinition] <RoleDefinitionPipeBind> [<CommonParameters>]
```

## DESCRIPTION
The Remove-SPRoleDefinition cmdlet removes a role definition from a site.

## EXAMPLES

### Example 1
```
PS C:\> Remove-SPRoleDefinition -RoleDefinition 1073741947
```

Removes the role definition from the site.

## PARAMETERS

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

### System.Void
## NOTES

## RELATED LINKS

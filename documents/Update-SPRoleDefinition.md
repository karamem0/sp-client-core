---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Update-SPRoleDefinition

## SYNOPSIS
Updates a role definition.

## SYNTAX

```
Update-SPRoleDefinition [-RoleDefinition] <RoleDefinitionPipeBind> [-BasePermissions <BasePermissions>]
 [-Description <String>] [-Name <String>] [-PassThru] [-Includes <String[]>] [<CommonParameters>]
```

## DESCRIPTION
The Update-SPRoleDefinition cmdlet updates the role definition property.

## EXAMPLES

### Example 1
```powershell
PS C:\> Update-SPRoleDefinition -RoleDefinition 1073741947 -BasePermissions 'ViewListItems,AddListItems'
```

Updates a role definition.

## PARAMETERS

### -BasePermissions
Indicates the role definition base permissions.

```yaml
Type: BasePermissions
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Description
Indicates the role definition description.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -Name
Indicates the role definition name.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
If specified, returns the updated object.

```yaml
Type: SwitchParameter
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

---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# New-SPRoleDefinition

## SYNOPSIS
Creates a new role definition.

## SYNTAX

```
New-SPRoleDefinition -BasePermissions <BasePermissions> [-Description <String>] -Name <String>
 [-Includes <String[]>] [<CommonParameters>]
```

## DESCRIPTION
The New-SPRoleDefinition cmdlet adds a new role definition to the site.

## EXAMPLES

### Example 1
```
PS C:\> New-SPRoleDefinition -BasePermissions 'ViewListItems,AddListItems' -Name 'RoleDefinition1'
```

Creates a new role definition to the site.

## PARAMETERS

### -BasePermissions
Indicates the role definition base permissions.

```yaml
Type: BasePermissions
Parameter Sets: (All)
Aliases:

Required: True
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

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable.
For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None
## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.Core.RoleDefinition
## NOTES

## RELATED LINKS

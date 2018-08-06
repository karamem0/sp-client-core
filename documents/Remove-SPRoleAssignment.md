---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Remove-SPRoleAssignment

## SYNOPSIS
Removes a role assignment from a principal.

## SYNTAX

### Web (Default)
```
Remove-SPRoleAssignment -PrincipalId <Int32> -RoleDefinitionId <Int32> [<CommonParameters>]
```

### List
```
Remove-SPRoleAssignment [-List] <ListPipeBind> -PrincipalId <Int32> -RoleDefinitionId <Int32>
 [<CommonParameters>]
```

### ListItem
```
Remove-SPRoleAssignment [-List] <ListPipeBind> [-ListItem] <ListItemPipeBind> -PrincipalId <Int32>
 -RoleDefinitionId <Int32> [<CommonParameters>]
```

## DESCRIPTION
The Remove-SPRoleAssignment cmdlet removes a permission from a principal (User or Group).

## EXAMPLES

### Example 1
```powershell
PS C:\> Remove-SPRoleAssignment -PrincipalId 14 -RoleDefinitionId 1073741826
```

Removes site read permission from the principal.

### Example 2
```powershell
PS C:\> Remove-SPRoleAssignment -List 'Shared Documents' -PrincipalId 14 -RoleDefinitionId 1073741827
```

Removes list contribute permission from the principal.

### Example 3
```powershell
PS C:\> Remove-SPRoleAssignment -List 'Shared Documents' -ListItem 1 -PrincipalId 14 -RoleDefinitionId 1073741829
```

Removes list full control permission from the principal.

## PARAMETERS

### -List
Indicates the list ID or title.

```yaml
Type: ListPipeBind
Parameter Sets: List, ListItem
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ListItem
Indicates the list item ID.

```yaml
Type: ListItemPipeBind
Parameter Sets: ListItem
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrincipalId
Indicates the user ID or group ID.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RoleDefinitionId
Indicates the role definition ID.

```yaml
Type: Int32
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

### System.Void

## NOTES

## RELATED LINKS

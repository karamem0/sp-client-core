---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Add-KshRoleAssignment

## SYNOPSIS
Adds a new role assignment to a site, list, or list item.

## SYNTAX

### ParamSet1
```
Add-KshRoleAssignment [-Site] [-Principal] <Principal> [-RoleDefinition] <RoleDefinition>
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet2
```
Add-KshRoleAssignment [-List] <List> [-Principal] <Principal> [-RoleDefinition] <RoleDefinition>
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet3
```
Add-KshRoleAssignment [-ListItem] <ListItem> [-Principal] <Principal> [-RoleDefinition] <RoleDefinition>
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Add-KshRoleAssignment` cmdlet adds a new role assignment to a site, list, or list item for a specified principal and role definition.

## EXAMPLES

### Example 1
```powershell
PS C:\> Add-KshRoleAssignment -Site -Principal $user -RoleDefinition "Contribute"
```

This example adds the "Contribute" role assignment to the current site for the specified user.

### Example 2
```powershell
PS C:\> Add-KshRoleAssignment -List $list -Principal $user -RoleDefinition "Read"
```

This example adds the "Read" role assignment to the specified list for the specified user.

### Example 3
```powershell
PS C:\> Add-KshRoleAssignment -ListItem $listItem -Principal $user -RoleDefinition "Edit"
```

This example adds the "Edit" role assignment to the specified list item for the specified user.

## PARAMETERS

### -List
Specifies the list to which the role assignment is added.

```yaml
Type: List
Parameter Sets: ParamSet2
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ListItem
Specifies the list item to which the role assignment is added.

```yaml
Type: ListItem
Parameter Sets: ParamSet3
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Principal
Specifies the principal (user or group) to which the role assignment is added.

```yaml
Type: Principal
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RoleDefinition
Specifies the role definition (permission level) to assign to the principal.

```yaml
Type: RoleDefinition
Parameter Sets: (All)
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Site
Specifies that the role assignment is added to the site.

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet1
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
Specifies the action preference for progress updates.

```yaml
Type: ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None
## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.RoleAssignment
## NOTES

## RELATED LINKS


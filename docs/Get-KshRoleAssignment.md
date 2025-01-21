---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Get-KshRoleAssignment

## SYNOPSIS
Retrieves one or more role assignments for a site, list, or list item.

## SYNTAX

### ParamSet1
```
Get-KshRoleAssignment [-Identity] <RoleAssignment> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet2
```
Get-KshRoleAssignment [-Site] [-PrincipalId] <Int32> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet3
```
Get-KshRoleAssignment [-Site] [-NoEnumerate] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet4
```
Get-KshRoleAssignment [-List] <List> [-PrincipalId] <Int32> [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### ParamSet5
```
Get-KshRoleAssignment [-List] <List> [-NoEnumerate] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet6
```
Get-KshRoleAssignment [-ListItem] <ListItem> [-PrincipalId] <Int32> [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### ParamSet7
```
Get-KshRoleAssignment [-ListItem] <ListItem> [-NoEnumerate] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

## DESCRIPTION
The `Get-KshRoleAssignment` cmdlet retrieves role assignments for a site, list, or list item based on the specified parameters.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-KshRoleAssignment -Identity $roleAssignment
```

This example retrieves a role assignment by identity.

### Example 2
```powershell
PS C:\> Get-KshRoleAssignment -Site -PrincipalId 5
```

This example retrieves a site role assignment by principal ID.

### Example 3
```powershell
PS C:\> Get-KshRoleAssignment -Site
```

This example retrieves all site role assignments.

### Example 4
```powershell
PS C:\> Get-KshRoleAssignment -List $list -PrincipalId 5
```

This example retrieves a list role assignment by principal ID.

### Example 5
```powershell
PS C:\> Get-KshRoleAssignment -List $list
```

This example retrieves all list role assignments.

### Example 6
```powershell
PS C:\> Get-KshRoleAssignment -ListItem $listItem -PrincipalId 5
```

This example retrieves a list item role assignment by principal ID.

### Example 7
```powershell
PS C:\> Get-KshRoleAssignment -ListItem $listItem
```

This example retrieves all list item role assignments.

## PARAMETERS

### -Identity
Specifies the role assignment to retrieve.

```yaml
Type: RoleAssignment
Parameter Sets: ParamSet1
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -List
Specifies the list object.

```yaml
Type: List
Parameter Sets: ParamSet4, ParamSet5
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ListItem
Specifies the list item object.

```yaml
Type: ListItem
Parameter Sets: ParamSet6, ParamSet7
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoEnumerate
Indicates that the cmdlet does not enumerate the role assignments.

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet3, ParamSet5, ParamSet7
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrincipalId
Specifies the principal ID.

```yaml
Type: Int32
Parameter Sets: ParamSet2, ParamSet4, ParamSet6
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Site
Indicates that the cmdlet retrieves role assignments for a site.

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet2, ParamSet3
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
Specifies the action preference for progress.

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

### Karamem0.SharePoint.PowerShell.Models.V1.RoleAssignment
## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.RoleAssignment
## NOTES

## RELATED LINKS


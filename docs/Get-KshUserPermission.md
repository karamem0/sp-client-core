---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Get-KshUserPermission

## SYNOPSIS
Retrieves user permissions from a site, list, or list item.

## SYNTAX

### ParamSet1
```
Get-KshUserPermission [-User] <User> [-Site] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet2
```
Get-KshUserPermission [-User] <User> [-List] <List> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet3
```
Get-KshUserPermission [-User] <User> [-ListItem] <ListItem> [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

## DESCRIPTION
The `Get-KshUserPermission` cmdlet retrieves user permissions from a site, list, or list item based on the specified parameters.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-KshUserPermission -User $user -Site
```

This example retrieves the site permissions for the specified user.

### Example 2
```powershell
PS C:\> Get-KshUserPermission -User $user -List $list
```

This example retrieves the list permissions for the specified user.

### Example 3
```powershell
PS C:\> Get-KshUserPermission -User $user -ListItem $listItem
```

This example retrieves the list item permissions for the specified user.

## PARAMETERS

### -List
Specifies the list for which to retrieve the user permissions.

```yaml
Type: List
Parameter Sets: ParamSet2
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ListItem
Specifies the list item for which to retrieve the user permissions.

```yaml
Type: ListItem
Parameter Sets: ParamSet3
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Site
Specifies that the cmdlet retrieves the user permissions for the site.

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -User
Specifies the user for whom to retrieve permissions.

```yaml
Type: User
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
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

### Karamem0.SharePoint.PowerShell.Models.V1.User
## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.BasePermission
## NOTES

## RELATED LINKS


---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Get-SPRoleAssignment

## SYNOPSIS
Gets a role assignment.

## SYNTAX

### Web (Default)
```
Get-SPRoleAssignment -PrincipalId <Int32> [-Includes <String[]>] [<CommonParameters>]
```

### List
```
Get-SPRoleAssignment [-List] <ListPipeBind> -PrincipalId <Int32> [-Includes <String[]>] [<CommonParameters>]
```

### ListItem
```
Get-SPRoleAssignment [-List] <ListPipeBind> [-ListItem] <ListItemPipeBind> -PrincipalId <Int32>
 [-Includes <String[]>] [<CommonParameters>]
```

## DESCRIPTION
The Get-SPRoleAssignment cmdlet retrieves the role assignment which matches the parameter.

## EXAMPLES

### Example 1
```
PS C:\> Get-SPRoleAssignment -PrincipalId 14
```

Gets the site role assignment by ID.

### Example 2
```
PS C:\> Get-SPRoleAssignment -List 'Shared Documents' -PrincipalId 14
```

Gets the list role assignment by ID.

### Example 3
```
PS C:\> Get-SPRoleAssignment -List 'Shared Documents' -ListItem 1 -PrincipalId 14
```

Gets the list item role assignment by ID.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable.
For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None
## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.Core.RoleAssignment
## NOTES

## RELATED LINKS

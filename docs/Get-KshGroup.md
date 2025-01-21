---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Get-KshGroup

## SYNOPSIS
Retrieves one or more groups from the current site.

## SYNTAX

### ParamSet1
```
Get-KshGroup [-Identity] <Group> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet2
```
Get-KshGroup [-GroupId] <Int32> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet3
```
Get-KshGroup [-GroupTitle] <String> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet4
```
Get-KshGroup [-NoEnumerate] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Get-KshGroup` cmdlet retrieves one or more groups from the current site based on the specified parameters.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-KshGroup -Identity $group
```

This example retrieves a group by identity.

### Example 2
```powershell
PS C:\> Get-KshGroup -GroupId 1
```

This example retrieves a group by group ID.

### Example 3
```powershell
PS C:\> Get-KshGroup -GroupTitle "Administrators"
```

This example retrieves a group by group title.

### Example 4
```powershell
PS C:\> Get-KshGroup
```

This example retrieves all groups.

## PARAMETERS

### -GroupId
Specifies the ID of the group to retrieve.

```yaml
Type: Int32
Parameter Sets: ParamSet2
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GroupTitle
Specifies the title of the group to retrieve.

```yaml
Type: String
Parameter Sets: ParamSet3
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Identity
Specifies the group to retrieve.

```yaml
Type: Group
Parameter Sets: ParamSet1
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -NoEnumerate
Indicates that the cmdlet does not enumerate the collection.

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet4
Aliases:

Required: False
Position: Named
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

### Karamem0.SharePoint.PowerShell.Models.V1.Group
## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.Group
## NOTES

## RELATED LINKS


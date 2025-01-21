---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Get-KshRecycleBinItem

## SYNOPSIS
Retrieves one or more items from the recycle bin.

## SYNTAX

### ParamSet1
```
Get-KshRecycleBinItem [-Identity] <RecycleBinItem> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet2
```
Get-KshRecycleBinItem [-ItemId] <Guid> [-SecondStage] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet3
```
Get-KshRecycleBinItem [-SecondStage] [-NoEnumerate] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Get-KshRecycleBinItem` cmdlet retrieves one or more items from the recycle bin based on the specified parameters.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-KshRecycleBinItem -Identity $recycleBinItem
```

This example retrieves a recycle bin item by identity.

### Example 2
```powershell
PS C:\> Get-KshRecycleBinItem -ItemId "12345678-1234-1234-1234-1234567890ab"
```

This example retrieves a recycle bin item by item ID.

### Example 3
```powershell
PS C:\> Get-KshRecycleBinItem -SecondStage
```

This example retrieves all items from the second-stage recycle bin.

## PARAMETERS

### -Identity
Specifies the recycle bin item to retrieve.

```yaml
Type: RecycleBinItem
Parameter Sets: ParamSet1
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ItemId
Specifies the ID of the recycle bin item to retrieve.

```yaml
Type: Guid
Parameter Sets: ParamSet2
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoEnumerate
Indicates that the cmdlet does not enumerate the collection.

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet3
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SecondStage
Indicates that the cmdlet retrieves items from the second-stage recycle bin.

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet2, ParamSet3
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

### Karamem0.SharePoint.PowerShell.Models.V1.RecycleBinItem
## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.RecycleBinItem
## NOTES

## RELATED LINKS


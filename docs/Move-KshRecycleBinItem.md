---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Move-KshRecycleBinItem

## SYNOPSIS

Moves one or more recycle bin items.

## SYNTAX

### ParamSet1

```
Move-KshRecycleBinItem [-Identity] <RecycleBinItem> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet2

```
Move-KshRecycleBinItem [-All] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION

The `Move-KshRecycleBinItem` cmdlet moves one or more items from the recycle bin to their original locations.

## EXAMPLES

### Example 1

```powershell
PS C:\> Move-KshRecycleBinItem -Identity $recycleBinItem
```

This example moves a specific item from the recycle bin to its original location.

### Example 2

```powershell
PS C:\> Move-KshRecycleBinItem -All
```

This example moves all items from the recycle bin to their original locations.

## PARAMETERS

### -All

Moves all items from the recycle bin to their original locations.

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet2
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Identity

Specifies the recycle bin item to move.

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

This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about\_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.RecycleBinItem

## OUTPUTS

### System.Void

## NOTES

## RELATED LINKS

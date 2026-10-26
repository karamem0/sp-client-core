---
Module Name: SPClientCore
external help file: SPClientCore.dll-Help.xml
schema: 2.0.0
---

# Restore-KshRecycleBinItem

## SYNOPSIS
Restore recycle bin item.

## SYNTAX

### ParamSet1
```
Restore-KshRecycleBinItem [-Identity] <RecycleBinItem> [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### ParamSet2
```
Restore-KshRecycleBinItem [-All] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## PARAMETERS

### -All

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

### System.Void


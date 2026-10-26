---
Module Name: SPClientCore
external help file: SPClientCore.dll-Help.xml
schema: 2.0.0
---

# Set-KshTermLabel

## SYNOPSIS
Set term label.

## SYNTAX

### ParamSet1
```
Set-KshTermLabel [-Identity] <TermLabel> [-Lcid] <UInt32> [-PassThru] [-SelectAllProperties]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet2
```
Set-KshTermLabel [-Identity] <TermLabel> [-Name] <String> [-PassThru] [-SelectAllProperties]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet3
```
Set-KshTermLabel [-Identity] <TermLabel> [-IsDefault] [-PassThru] [-SelectAllProperties]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## PARAMETERS

### -Identity

```yaml
Type: TermLabel
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -IsDefault

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet3
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Lcid

```yaml
Type: UInt32
Parameter Sets: ParamSet1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name

```yaml
Type: String
Parameter Sets: ParamSet2
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SelectAllProperties

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
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

### Karamem0.SharePoint.PowerShell.Models.V1.TermLabel

## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.TermLabel


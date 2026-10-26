---
Module Name: SPClientCore
external help file: SPClientCore.dll-Help.xml
schema: 2.0.0
---

# Get-KshView

## SYNOPSIS
Get view.

## SYNTAX

### ParamSet1
```
Get-KshView [-Identity] <View> [-SelectAllProperties] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet2
```
Get-KshView [-List] <List> [-ViewId] <Guid> [-SelectAllProperties] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### ParamSet3
```
Get-KshView [-List] <List> [-ViewTitle] <String> [-SelectAllProperties] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### ParamSet4
```
Get-KshView [-List] <List> [-SelectAllProperties] [-NoEnumerate] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

## PARAMETERS

### -Identity

```yaml
Type: View
Parameter Sets: ParamSet1
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -List

```yaml
Type: List
Parameter Sets: ParamSet2, ParamSet3, ParamSet4
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -NoEnumerate

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

### -ViewId

```yaml
Type: Guid
Parameter Sets: ParamSet2
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ViewTitle

```yaml
Type: String
Parameter Sets: ParamSet3
Aliases:

Required: True
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

### Karamem0.SharePoint.PowerShell.Models.V1.View

### Karamem0.SharePoint.PowerShell.Models.V1.List

## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.View


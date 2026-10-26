---
Module Name: SPClientCore
external help file: SPClientCore.dll-Help.xml
schema: 2.0.0
---

# Set-KshLike

## SYNOPSIS
Set like.

## SYNTAX

### ParamSet1
```
Set-KshLike [-Comment] <Comment> [-Like] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet3
```
Set-KshLike [-Comment] <Comment> [-Unlike] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet2
```
Set-KshLike [-ListItem] <ListItem> [-Like] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet4
```
Set-KshLike [-ListItem] <ListItem> [-Unlike] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## PARAMETERS

### -Comment

```yaml
Type: Comment
Parameter Sets: ParamSet1, ParamSet3
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Like

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet1, ParamSet2
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ListItem

```yaml
Type: ListItem
Parameter Sets: ParamSet2, ParamSet4
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Unlike

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet3, ParamSet4
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

### Karamem0.SharePoint.PowerShell.Models.V1.Comment

### Karamem0.SharePoint.PowerShell.Models.V1.ListItem

## OUTPUTS

### System.Void


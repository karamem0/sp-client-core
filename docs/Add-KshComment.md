---
Module Name: SPClientCore
external help file: SPClientCore.dll-Help.xml
schema: 2.0.0
---

# Add-KshComment

## SYNOPSIS
Add a comment.

## SYNTAX

### ParamSet1
```
Add-KshComment [-ListItem] <ListItem> [-Text] <String> [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### ParamSet2
```
Add-KshComment [-Comment] <Comment> [-Text] <String> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## PARAMETERS

### -Comment

```yaml
Type: Comment
Parameter Sets: ParamSet2
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ListItem

```yaml
Type: ListItem
Parameter Sets: ParamSet1
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Text

```yaml
Type: String
Parameter Sets: (All)
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

### Karamem0.SharePoint.PowerShell.Models.V1.ListItem

### Karamem0.SharePoint.PowerShell.Models.V1.Comment

## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.Comment


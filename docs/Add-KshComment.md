---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Add-KshComment

## SYNOPSIS
Adds a new comment to a list item or another comment.

## SYNTAX

### ParamSet1
```
Add-KshComment [-ListItem] <ListItem> -Text <String> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet2
```
Add-KshComment [-Comment] <Comment> -Text <String> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
This cmdlet adds a new comment to a list item or another comment. It can be used to provide additional information or feedback.

## EXAMPLES

### Example 1
```powershell
PS C:\> Add-KshComment -ListItem $listItem -Text "This is a comment."
```

This example adds a comment to the specified list item.

### Example 2
```powershell
PS C:\> Add-KshComment -Comment $comment -Text "This is a reply."
```

This example adds a reply to the specified comment.

## PARAMETERS

### -Comment
Specifies the comment to which the new comment will be added.

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
Specifies the list item to which the comment will be added.

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
Specifies the text of the comment to be added.

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

### Karamem0.SPClientCore.Models.V1.ListItem
### Karamem0.SPClientCore.Models.V1.Comment
## OUTPUTS

### Karamem0.SPClientCore.Models.V1.Comment
## NOTES

## RELATED LINKS


---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Enable-KshLike

## SYNOPSIS
Enables a like on a comment or list item.

## SYNTAX

### ParamSet1
```
Enable-KshLike [-Comment] <Comment> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet2
```
Enable-KshLike [-ListItem] <ListItem> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Enable-KshLike` cmdlet enables a like on a comment or list item.

## EXAMPLES

### Example 1
```powershell
PS C:\> Enable-KshLike -Comment $comment
```

This example enables a like on the specified comment.

### Example 2
```powershell
PS C:\> Enable-KshLike -ListItem $listItem
```

This example enables a like on the specified list item.

## PARAMETERS

### -Comment
Specifies the comment to like.

```yaml
Type: Comment
Parameter Sets: ParamSet1
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ListItem
Specifies the list item to like.

```yaml
Type: ListItem
Parameter Sets: ParamSet2
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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.Comment
### Karamem0.SharePoint.PowerShell.Models.V1.ListItem
## OUTPUTS

### System.Void
## NOTES

## RELATED LINKS


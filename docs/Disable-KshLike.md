---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Disable-KshLike

## SYNOPSIS
Disables a like on a comment or list item.

## SYNTAX

### ParamSet1
```
Disable-KshLike [-Comment] <Comment> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet2
```
Disable-KshLike [-ListItem] <ListItem> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Disable-KshLike` cmdlet disables a like on a comment or list item.

## EXAMPLES

### Example 1
```powershell
PS C:\> Disable-KshLike -Comment $comment
```

This example disables a like on the specified comment.

### Example 2
```powershell
PS C:\> Disable-KshLike -ListItem $listItem
```

This example disables a like on the specified list item.

## PARAMETERS

### -Comment
Specifies the comment on which to disable the like.

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
Specifies the list item on which to disable the like.

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


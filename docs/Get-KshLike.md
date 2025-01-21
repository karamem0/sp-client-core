---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Get-KshLike

## SYNOPSIS
Retrieves the likes for a comment or list item.

## SYNTAX

### ParamSet1
```
Get-KshLike [-Comment] <Comment> [-NoEnumerate] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet2
```
Get-KshLike [-ListItem] <ListItem> [-NoEnumerate] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Get-KshLike` cmdlet retrieves the likes for a comment or list item.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-KshLike -Comment $comment
```

This example retrieves the likes by comment.

### Example 2
```powershell
PS C:\> Get-KshLike -ListItem $listItem
```

This example retrieves the likes by list item.

## PARAMETERS

### -Comment
Specifies the comment for which to retrieve likes.

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
Specifies the list item for which to retrieve likes.

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

### -NoEnumerate
Indicates that the cmdlet does not enumerate the collection.

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

### Karamem0.SharePoint.PowerShell.Models.V1.LikedUser
## NOTES

## RELATED LINKS


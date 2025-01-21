---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Get-KshComment

## SYNOPSIS
Retrieves one or more comments from a list item.

## SYNTAX

### ParamSet1
```
Get-KshComment [-Identity] <Comment> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet2
```
Get-KshComment [-ListItem] <ListItem> [-CommentId] <Int32> [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### ParamSet3
```
Get-KshComment [-ListItem] <ListItem> [-NoEnumerate] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Get-KshComment` cmdlet retrieves one or more comments from a list item based on the specified parameters.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-KshComment -Identity $comment
```

This example retrieves a comment by identity.

### Example 2
```powershell
PS C:\> Get-KshComment -ListItem $listItem -CommentId 1
```

This example retrieves a comment by comment ID.

### Example 3
```powershell
PS C:\> Get-KshComment -ListItem $listItem
```

This example retrieves all comments.

## PARAMETERS

### -CommentId
Specifies the ID of the comment to retrieve.

```yaml
Type: Int32
Parameter Sets: ParamSet2
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Identity
Specifies the comment to retrieve.

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
Specifies the list item that contains the comments to retrieve.

```yaml
Type: ListItem
Parameter Sets: ParamSet2, ParamSet3
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoEnumerate
Indicates that the cmdlet does not enumerate the comments.

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet3
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
## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.Comment
## NOTES

## RELATED LINKS


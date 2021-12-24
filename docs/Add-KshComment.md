---
external help file: SPClientCore.dll-help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Add-KshComment

## SYNOPSIS
Creates a new comment.

## SYNTAX

### ParamSet1
```
Add-KshComment [-ListItem] <ListItem> -Text <String> [<CommonParameters>]
```

### ParamSet2
```
Add-KshComment [-Comment] <Comment> -Text <String> [<CommonParameters>]
```

## DESCRIPTION
The Add-KshComment cmdlet adds a new comment to the specified list item.

## EXAMPLES

### Example 1
```powershell
PS C:\> Add-KshComment -ListItem (Get-KshListItem -List (Get-KshList -ListTitle 'Site Pages') -ItemId 1) -Text 'It is great!'
```

Creates a new comment.

## PARAMETERS

### -Comment
Specifies the comment.

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
Specifies the list item.

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
Specifies the text.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.ListItem
### Karamem0.SharePoint.PowerShell.Models.V1.Comment
## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.Comment

## NOTES

## RELATED LINKS

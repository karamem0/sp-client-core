---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# New-KshSitePageComment

## SYNOPSIS
Creates a new site page comment.

## SYNTAX

### ParamSet1
```
New-KshSitePageComment [-ListItem] <ListItem> -Text <String> [<CommonParameters>]
```

### ParamSet2
```
New-KshSitePageComment [-Comment] <SitePageComment> -Text <String> [<CommonParameters>]
```

## DESCRIPTION
The New-KshSitePageComment cmdlet adds a new comment to the specified site page.

## EXAMPLES

### Example 1
```powershell
PS C:\> New-KshSitePageComment -ListItem (Get-KshListItem -List (Get-KshList -ListTitle 'Site Pages') -ItemId 1) -Text 'It is great!'
```

Creates a new comment.

## PARAMETERS

### -Comment
Specifies the comment.

```yaml
Type: SitePageComment
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

### Karamem0.SharePoint.PowerShell.Models.ListItem

### Karamem0.SharePoint.PowerShell.Models.SitePageComment

## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.SitePageComment

## NOTES

## RELATED LINKS

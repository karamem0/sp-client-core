---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Get-KshSitePageComment

## SYNOPSIS
Retrieves one or more site page comment.

## SYNTAX

### ParamSet1
```
Get-KshSitePageComment [-Identity] <SitePageComment> [<CommonParameters>]
```

### ParamSet2
```
Get-KshSitePageComment [-ListItem] <ListItem> [-CommentId] <Int32> [<CommonParameters>]
```

### ParamSet3
```
Get-KshSitePageComment [-ListItem] <ListItem> [-NoEnumerate] [<CommonParameters>]
```

## DESCRIPTION
The Get-KshSitePageComment cmdlet retrieves comments of the site page.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-KshSitePageComment -ListItem (Get-KshListItem -List (Get-KshList -ListTitle 'Site Pages') -ItemId 1) -CommentId 1
```

Retrieves a comment by comment ID.

### Example 2
```powershell
PS C:\> Get-KshSitePageComment -ListItem (Get-KshListItem -List (Get-KshList -ListTitle 'Site Pages') -ItemId 1)
```

Retrieves all comments.

## PARAMETERS

### -CommentId
Specifies the comment ID.

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
Specifies the comment.

```yaml
Type: SitePageComment
Parameter Sets: ParamSet1
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
Parameter Sets: ParamSet2, ParamSet3
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoEnumerate
If specified, suppresses to enumerate objects.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Karamem0.SharePoint.PowerShell.Models.SitePageComment

## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.SitePageComment

## NOTES

## RELATED LINKS

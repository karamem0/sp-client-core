---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Remove-KshSitePageComment

## SYNOPSIS
Removes a site page comment.

## SYNTAX

```
Remove-KshSitePageComment [-Identity] <SitePageComment> [<CommonParameters>]
```

## DESCRIPTION
The Remove-KshSitePageComment cmdlet removes a comment from the site page.

## EXAMPLES

### Example 1
```powershell
PS C:\> Remove-KshSitePageComment -Identity (Get-KshSitePageComment -ListItem (Get-KshListItem -List (Get-KshList -ListTitle 'Site Pages') -ItemId 1) -CommentId 1)
```

Removes a comment.

## PARAMETERS

### -Identity
Specifies the comment.

```yaml
Type: SitePageComment
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Karamem0.SharePoint.PowerShell.Models.SitePageComment

## OUTPUTS

### None

## NOTES

## RELATED LINKS

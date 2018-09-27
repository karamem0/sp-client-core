---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Remove-SPContentType

## SYNOPSIS
Removes a content type.

## SYNTAX

### Web (Default)
```
Remove-SPContentType [-ContentType] <ContentTypePipeBind> [<CommonParameters>]
```

### List
```
Remove-SPContentType [-List] <ListPipeBind> [-ContentType] <ContentTypePipeBind> [<CommonParameters>]
```

## DESCRIPTION
The Remove-SPContentType cmdlet removes a content type from a site or list.

## EXAMPLES

### Example 1
```
PS C:\> Remove-SPContentType -ContentType '0x0100DFF682E1FF5A8A4EA7A6370B7D0A8104'
```

Removes the site content type.

### Example 2
```
PS C:\> Remove-SPContentType -List 'Shared Documents' -ContentType '0x0100DFF682E1FF5A8A4EA7A6370B7D0A8104'
```

Removes the list content type.

## PARAMETERS

### -ContentType
Indicates the content type ID.

```yaml
Type: ContentTypePipeBind
Parameter Sets: Web
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: ContentTypePipeBind
Parameter Sets: List
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -List
Indicates the list ID or title.

```yaml
Type: ListPipeBind
Parameter Sets: List
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable.
For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Karamem0.SharePoint.PowerShell.PipeBinds.Core.ContentTypePipeBind
## OUTPUTS

### System.Void
## NOTES

## RELATED LINKS

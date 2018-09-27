---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Get-SPContentType

## SYNOPSIS
Gets a content type.

## SYNTAX

### Web (Default)
```
Get-SPContentType [-ContentType] <ContentTypePipeBind> [-Includes <String[]>] [<CommonParameters>]
```

### List
```
Get-SPContentType [-List] <ListPipeBind> [-ContentType] <ContentTypePipeBind> [-Includes <String[]>]
 [<CommonParameters>]
```

## DESCRIPTION
The Get-SPContentType cmdlet retrieves the content type which matches the parameter.

## EXAMPLES

### Example 1
```
PS C:\> Get-SPContentType -ContentType '0x0100DFF682E1FF5A8A4EA7A6370B7D0A8104'
```

Gets the site content type by ID.

### Example 1
```
PS C:\> Get-SPContentType -List 'Shared Documents' -ContentType '0x0100DFF682E1FF5A8A4EA7A6370B7D0A8104'
```

Gets the list content type by ID.

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

### -Includes
Indicates the property name collection to include in the result object.

```yaml
Type: String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
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

### Karamem0.SharePoint.PowerShell.Models.Core.ContentType
## NOTES

## RELATED LINKS

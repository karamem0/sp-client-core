---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Update-SPContentType

## SYNOPSIS
Updates a content type.

## SYNTAX

### Web (Default)
```
Update-SPContentType [-ContentType] <ContentTypePipeBind> [-Description <String>] [-JSLink <String>]
 [-Hidden <Boolean>] [-PassThru] [-Includes <String[]>] [<CommonParameters>]
```

### List
```
Update-SPContentType [-List] <ListPipeBind> [-ContentType] <ContentTypePipeBind> [-Description <String>]
 [-JSLink <String>] [-Hidden <Boolean>] [-PassThru] [-Includes <String[]>] [<CommonParameters>]
```

## DESCRIPTION
The Update-SPContentType cmdlet updates the content type property.

## EXAMPLES

### Example 1
```
PS C:\> Update-SPContentType -ContentType '0x0100DFF682E1FF5A8A4EA7A6370B7D0A8104' -Description 'My Content Type'
```

Updates display name of the site content type.

### Example 2
```
PS C:\> Update-SPContentType -List 'Shared Documents' -ContentType '0x0100DFF682E1FF5A8A4EA7A6370B7D0A8104' -Description 'My Content Type'
```

Updates display name of the list content type.

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

### -Description
Indicates the description.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Hidden
Indicates the value whether to hide from user.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
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

### -JSLink
Indicates the JSLink URL.

```yaml
Type: String
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

### -PassThru
If specified, returns the updated object.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
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

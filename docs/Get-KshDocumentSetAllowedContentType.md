---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Get-KshDocumentSetAllowedContentType

## SYNOPSIS
Retrieves the allowed content types for a document set.

## SYNTAX

```
Get-KshDocumentSetAllowedContentType [-ContentType] <ContentType> [-NoEnumerate]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Get-KshDocumentSetAllowedContentType` cmdlet retrieves the allowed content types for a document set.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-KshDocumentSetAllowedContentType -ContentType $contentType
```

This example retrieves the allowed content types for the document set.

## PARAMETERS

### -ContentType
Specifies the content type of the document set.

```yaml
Type: ContentType
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoEnumerate
Indicates that the cmdlet does not enumerate the content types.

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

### None
## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.ContenTypeId
## NOTES

## RELATED LINKS


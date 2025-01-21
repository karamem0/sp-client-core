---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Add-KshDocumentSetDefaultDocument

## SYNOPSIS
Adds a default document to a document set.

## SYNTAX

```
Add-KshDocumentSetDefaultDocument -ContentType <ContentType> -DocumentContentType <ContentType>
 -Content <Byte[]> -FileName <String> [-PushChanges] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Add-KshDocumentSetDefaultDocument` cmdlet adds a default document to a document set with a content type and document content type.

## EXAMPLES

### Example 1
```powershell
PS C:\> Add-KshDocumentSetDefaultDocument -ContentType $contentType -DocumentContentType $documentContentType -Content $content -FileName "example.docx"
```

This example adds a default document named "example.docx" to the specified document set.

## PARAMETERS

### -Content
Specifies the content of the document as a byte array.

```yaml
Type: Byte[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ContentType
Specifies the content type of the document set.

```yaml
Type: ContentType
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DocumentContentType
Specifies the content type of the document being added.

```yaml
Type: ContentType
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FileName
Specifies the name of the file to be added as the default document.

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

### -PushChanges
Indicates whether to push changes immediately.

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

### Karamem0.SharePoint.PowerShell.Models.V1.DefaultDocument
## NOTES

## RELATED LINKS


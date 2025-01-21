---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Add-KshDocumentSetAllowedContentType

## SYNOPSIS
Adds an allowed content type to a document set.

## SYNTAX

```
Add-KshDocumentSetAllowedContentType [-ContentType] <ContentType> -AllowedContentType <ContentType>
 [-PushChanges] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Add-KshDocumentSetAllowedContentType` cmdlet adds an allowed content type to a document set.

## EXAMPLES

### Example 1
```powershell
PS C:\> Add-KshDocumentSetAllowedContentType -ContentType $contentType -AllowedContentType $allowedContentType
```

This example adds the specified content type as an allowed content type to the specified content type.

## PARAMETERS

### -AllowedContentType
Specifies the content type to be allowed in the document set.

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

### -ContentType
Specifies the document set content type to which the allowed content type will be added.

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

### -PushChanges
Indicates whether to push changes to the content type.

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

### System.Void
## NOTES

## RELATED LINKS


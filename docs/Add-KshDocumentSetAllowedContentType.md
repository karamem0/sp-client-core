---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Add-KshDocumentSetAllowedContentType

## SYNOPSIS
Adds a document set allowed content type.

## SYNTAX

```
Add-KshDocumentSetAllowedContentType [-ContentType] <ContentType> -AllowedContentType <ContentType>
 [-PushChanges] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The Add-KshDocumentSetAllowedContentType cmdlet add an allowed content type to the specified document set template.

## EXAMPLES

### Example 1
```powershell
PS C:\> Add-KshDocumentSetAllowedContentType -ContentType (Get-KshContentType -ContentTypeId '0x0120D5200014BC33BECFD5C340922C6D6CECC7830D') -AllowedContentType (Get-KshContentType -ContentTypeId '0x0101009D1CB255DA76424F860D91F20E6C4118') -PushChanges
```

Adds a document set allowed content type.

## PARAMETERS

### -AllowedContentType
Specifies the allowed content type.

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
Specifies the content type.

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
If Specified, propagates changes to all content types that use the content type.

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
Determines how PowerShell responds to progress updates generated by a script, cmdlet, or provider.

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

### None

## NOTES

## RELATED LINKS


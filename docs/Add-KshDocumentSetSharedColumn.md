---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Add-KshDocumentSetSharedColumn

## SYNOPSIS
Adds a document set shared column.

## SYNTAX

```
Add-KshDocumentSetSharedColumn [-ContentType] <ContentType> -Column <Column> [-PushChanges]
 [<CommonParameters>]
```

## DESCRIPTION
The Add-KshDocumentSetSharedColumn cmdlet add a shared column to the specified document set template.

## EXAMPLES

### Example 1
```powershell
PS C:\> Add-KshDocumentSetSharedColumn -ContentType (Get-KshContentType -ContentTypeId '0x0120D5200014BC33BECFD5C340922C6D6CECC7830D') -Column (Get-KshColumn -ColumnId '35aa78a6-66d7-472c-ab6b-d534193842af') -PushChanges
```

Adds a document set shared column.

## PARAMETERS

### -Column
Specifies the column.

```yaml
Type: Column
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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### None

## NOTES

## RELATED LINKS

---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# New-KshContentTypeColumn

## SYNOPSIS
Creates a content type column.

## SYNTAX

```
New-KshContentTypeColumn -ContentType <ContentType> -Column <Column> [-PushChanges] [<CommonParameters>]
```

## DESCRIPTION
The New-KshContentTypeColumn cmdlet adds a new content type column to the specified content type.

## EXAMPLES

### Example 1
```powershell
PS C:> $list = New-KshContentTypeColumn -ListTitle 'Announcements'
PS C:> $listContentType = $list | Get-KshContentType -ContentType '0x0100EFB1758564C77D448177233D1199B912000A210B1C5CBC634C849328008B1CC306'
PS C:> $listColumn = $list | Get-KshColumn -ColumnTitle 'Remarks'
PS C:> New-KshContentTypeColumn -ContentType $listContentType -Column $listColumn
```

Creates a new content type column to the list content type.

### Example 2
```powershell
PS C:> $siteContentType = Get-KshContentType -ContentTypeId '0x0100EFB1758564C77D448177233D1199B912'
PS C:> $siteColumn = Get-KshColumn -ColumnTitle 'Remarks'
PS C:> New-KshContentTypeColumn -ContentType $siteContentType -Column $siteColumn -PushChanges
```

Creates a new content type column to the site content type.

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
Position: Named
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

### Karamem0.SharePoint.PowerShell.Models.ContentTypeColumn

## NOTES

## RELATED LINKS
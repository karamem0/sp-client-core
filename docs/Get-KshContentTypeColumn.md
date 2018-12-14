---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Get-KshContentTypeColumn

## SYNOPSIS
Retrieves one or more content type columns.

## SYNTAX

### ParamSet1
```
Get-KshContentTypeColumn [-Identity] <ContentTypeColumn> [<CommonParameters>]
```

### ParamSet2
```
Get-KshContentTypeColumn [-ContentType] <ContentType> [-Column] <Column> [<CommonParameters>]
```

### ParamSet3
```
Get-KshContentTypeColumn [-ContentType] <ContentType> [-NoEnumerate] [<CommonParameters>]
```

## DESCRIPTION
The Get-KshContentTypeColumn cmdlet retrives content type columns of the specified content type.

## EXAMPLES

### Example 1
```powershell
PS C:\> $siteContentType = Get-KshContentType -ContentTypeId '0x0100EFB1758564C77D448177233D1199B912'
PS C:\> $siteColumn = Get-KshColumn -ColumnId '35aa78a6-66d7-472c-ab6b-d534193842af'
PS C:\> $siteContentTypeColumn = Get-KshContentTypeColumn -ContentType $siteContentType -Column $siteColumn
```

Retrieves a content type column by column.

### Example 2
```powershell
PS C:\> $list = Get-KshList -ListTitle 'Announcements'
PS C:\> $listContentType = Get-KshContentType -List $list -ContentTypeId '0x0100EFB1758564C77D448177233D1199B912000A210B1C5CBC634C849328008B1CC306'
PS C:\> $listContentTypeColumns = Get-KshContentTypeColumn -ContentType $listContentType
```

Retrieves all content type columns of the list content type.

### Example 3
```powershell
PS C:\> $siteContentType = Get-KshContentType -ContentTypeId '0x0100EFB1758564C77D448177233D1199B912'
PS C:\> $siteContentTypeColumns = Get-KshContentTypeColumn -ContentType $siteContentType
```

Retrieves all content type columns of the site content type.

## PARAMETERS

### -Column
{{ Fill Column Description }}

```yaml
Type: Column
Parameter Sets: ParamSet2
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ContentType
Specifies the content type.

```yaml
Type: ContentType
Parameter Sets: ParamSet2, ParamSet3
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Identity
Specifies the content type column.

```yaml
Type: ContentTypeColumn
Parameter Sets: ParamSet1
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -NoEnumerate
If specified, suppresses to enumerate objects.

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet3
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

### Karamem0.SharePoint.PowerShell.Models.ContentTypeColumn

## OUTPUTS

### System.Void

## NOTES

## RELATED LINKS

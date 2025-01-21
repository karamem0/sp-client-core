---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Get-KshContentTypeColumn

## SYNOPSIS
Retrieves one or more columns from a content type.

## SYNTAX

### ParamSet1
```
Get-KshContentTypeColumn [-Identity] <ContentTypeColumn> [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### ParamSet2
```
Get-KshContentTypeColumn [-ContentType] <ContentType> [-Column] <Column> [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### ParamSet3
```
Get-KshContentTypeColumn [-ContentType] <ContentType> [-NoEnumerate] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

## DESCRIPTION
The `Get-KshContentTypeColumn` cmdlet retrieves one or more columns from a content type based on the specified parameters.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-KshContentTypeColumn -Identity $contentTypeColumn
```

This example retrieves a content type column by identity.

### Example 2
```powershell
PS C:\> Get-KshContentTypeColumn -ContentType $contentType -Column $column
```

This example retrieves a content type column by column.

### Example 3
```powershell
PS C:\> Get-KshContentTypeColumn -ContentType $contentType
```

This example retrieves all content type columns.

## PARAMETERS

### -Column
Specifies the column to retrieve from the content type.

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
Specifies the content type from which to retrieve columns.

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
Specifies the content type column to retrieve.

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
Indicates that the cmdlet does not enumerate the content type columns.

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

### Karamem0.SharePoint.PowerShell.Models.V1.ContentTypeColumn
## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.ContentTypeColumn
## NOTES

## RELATED LINKS


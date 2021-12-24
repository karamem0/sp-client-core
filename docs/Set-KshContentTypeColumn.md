---
external help file: SPClientCore.dll-help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Set-KshContentTypeColumn

## SYNOPSIS
Updates a content type column.

## SYNTAX

```
Set-KshContentTypeColumn [-Identity] <ContentTypeColumn> [-Hidden <Boolean>] [-Required <Boolean>]
 [-PushChanges] [-PassThru] [<CommonParameters>]
```

## DESCRIPTION
The Set-KshContentTypeColumn cmdlet updates properties of the content type column.

## EXAMPLES

### Example 1
```powershell
PS C:\> Set-KshContentTypeColumn -ContentTypeColumn Get-KshContentTypeColumn -ContentType (Get-KshContentType -ContentTypeId '0x0100EFB1758564C77D448177233D1199B912') -Column (Get-KshColumn -ColumnTitle 'Remarks') -Required $true
```

Updates property values of the content type column.

## PARAMETERS

### -Hidden
Specifies whether to hide the content type column from users.

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

### -Identity
Specifies the content type column.

```yaml
Type: ContentTypeColumn
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
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

### -Required
Specifies whether a value is required.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.ContentTypeColumn

## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.ContentTypeColumn

## NOTES

## RELATED LINKS

---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Remove-KshContentType

## SYNOPSIS
Removes a content type.

## SYNTAX

```
Remove-KshContentType [-Identity] <ContentType> [<CommonParameters>]
```

## DESCRIPTION
The Remove-KshContentType cmdlet removes a content type from the current site or the specified list.

## EXAMPLES

### Example 1
```powershell
PS C:\> $list = Get-KshList -ListTitle 'Announcements'
PS C:\> $listContentType = Get-KshContentType -List $list -ContentTypeId '0x0100EFB1758564C77D448177233D1199B912000A210B1C5CBC634C849328008B1CC306'
PS C:\> Remove-KshContentType -Identity $listContentType
```

Removes a content type from the list.

### Example 2
```powershell
PS C:\> $siteContentType = Get-KshContentType -ContentTypeId '0x0100EFB1758564C77D448177233D1199B912'
PS C:\> Remove-KshContentType -Identity $siteContentType
```

Removes a content type from the current site.

## PARAMETERS

### -Identity
Specifies the content type.

```yaml
Type: ContentType
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Karamem0.SharePoint.PowerShell.Models.ContentType

## OUTPUTS

### System.Void

## NOTES

## RELATED LINKS

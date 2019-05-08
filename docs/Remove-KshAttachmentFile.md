---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Remove-KshAttachmentFile

## SYNOPSIS
Removes a attachment file.

## SYNTAX

### ParamSet1
```
Remove-KshAttachmentFile [-Identity] <AttachmentFile> [<CommonParameters>]
```

### ParamSet2
```
Remove-KshAttachmentFile [-Identity] <AttachmentFile> [-Force] [<CommonParameters>]
```

## DESCRIPTION
The Remove-KshAttachmentFile cmdlet removes a attachment file from the list item.

## EXAMPLES

### Example 1
```powershell
PS C:\> $list = Get-KshList -ListTitle 'Announcements'
PS C:\> $listItem = Get-KshListItem -List $list -ItemId 1
PS C:\> $attachmentFile = Get-KshAttachmentFile -ListItem $listItem -FileName 'Readme.txt'
PS C:\> Remove-KshAttachmentFile -Identity $attachmentFile
```

Moves a attachment file to the recycle bin.

### Example 2
```powershell
PS C:\> $list = Get-KshList -ListTitle 'Announcements'
PS C:\> $listItem = Get-KshListItem -List $list -ItemId 1
PS C:\> $attachmentFile = Get-KshAttachmentFile -ListItem $listItem -FileName 'Readme.txt'
PS C:\> Remove-KshAttachmentFile -Identity $attachmentFile -Force
```

Removes a attachment file permanently.

## PARAMETERS

### -Force
If specified, removes object permanently.

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet2
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Identity
Specifies the attachment file.

```yaml
Type: AttachmentFile
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

### Karamem0.SharePoint.PowerShell.Models.AttachmentFile

## OUTPUTS

### System.Void

## NOTES

## RELATED LINKS
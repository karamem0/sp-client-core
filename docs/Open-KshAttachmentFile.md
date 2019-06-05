---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Open-KshAttachmentFile

## SYNOPSIS
Opens a attachment file.

## SYNTAX

```
Open-KshAttachmentFile [-Identity] <AttachmentFile> [<CommonParameters>]
```

## DESCRIPTION
The Open-KshAttachmentFile cmdlet retrives contents of the attachment file.

## EXAMPLES

### Example 1
```powershell
PS C:\> $list = Get-KshList -ListTitle 'Announcements'
PS C:\> $listItem = Get-KshListItem -List $list -ItemId 1
PS C:\> $attachmentFile = Get-KshAttachmentFile -ListItem $listItem -FileName 'README.txt'
PS C:\> $content = Open-KshAttachmentFile -Identity $attachmentFile
```

Retrieves contents of the attachment file.

## PARAMETERS

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

### System.IO.Stream

## NOTES

## RELATED LINKS

---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Open-KshAttachmentFile

## SYNOPSIS

Opens an attachment file and returns its content as a stream.

## SYNTAX

```
Open-KshAttachmentFile [-Identity] <AttachmentFile> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION

The `Open-KshAttachmentFile` cmdlet opens an attachment file and returns its content as a stream.

## EXAMPLES

### Example 1

```powershell
PS C:\> $stream = Open-KshAttachmentFile -Identity $attachmentFile
```

This example opens the specified attachment file and stores its content in a stream.

## PARAMETERS

### -Identity

Specifies the attachment file to open.

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

This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about\_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.AttachmentFile

## OUTPUTS

### System.IO.Stream

## NOTES

## RELATED LINKS

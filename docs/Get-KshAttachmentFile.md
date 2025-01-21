---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Get-KshAttachmentFile

## SYNOPSIS
Retrieves one or more attachment files from a list item.

## SYNTAX

### ParamSet1
```
Get-KshAttachmentFile [-Identity] <AttachmentFile> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet2
```
Get-KshAttachmentFile [-ListItem] <ListItem> [-FileName] <String> [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### ParamSet3
```
Get-KshAttachmentFile [-ListItem] <ListItem> [-NoEnumerate] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

## DESCRIPTION
The `Get-KshAttachmentFile` cmdlet retrieves one or more attachment files from a list item based on the specified parameters.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-KshAttachmentFile -Identity $attachmentFile
```

This example retrieves an attachment file by identity.

### Example 2
```powershell
PS C:\> Get-KshAttachmentFile -ListItem $listItem -FileName "example.txt"
```

This example retrieves an attachment file by file name.

### Example 3
```powershell
PS C:\> Get-KshAttachmentFile -ListItem $listItem
```

This example retrieves all attachment files.

## PARAMETERS

### -FileName
Specifies the name of the attachment file to retrieve.

```yaml
Type: String
Parameter Sets: ParamSet2
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Identity
Specifies the attachment file to retrieve.

```yaml
Type: AttachmentFile
Parameter Sets: ParamSet1
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ListItem
Specifies the list item that contains the attachment file.

```yaml
Type: ListItem
Parameter Sets: ParamSet2, ParamSet3
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoEnumerate
Indicates that the cmdlet does not enumerate the collection.

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

### Karamem0.SharePoint.PowerShell.Models.V1.AttachmentFile
## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.AttachmentFile
## NOTES

## RELATED LINKS


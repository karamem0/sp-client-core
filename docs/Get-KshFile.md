---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Get-KshFile

## SYNOPSIS
Retrieves one or more files.

## SYNTAX

### ParamSet1
```
Get-KshFile [-Identity] <File> [<CommonParameters>]
```

### ParamSet2
```
Get-KshFile [-AttachmentFile] <AttachmentFile> [<CommonParameters>]
```

### ParamSet3
```
Get-KshFile [-FileId] <Guid> [<CommonParameters>]
```

### ParamSet4
```
Get-KshFile [-FileUrl] <Uri> [<CommonParameters>]
```

### ParamSet5
```
Get-KshFile [-Folder] <Folder> [-FileName] <String> [<CommonParameters>]
```

### ParamSet6
```
Get-KshFile [-Folder] <Folder> [-NoEnumerate] [<CommonParameters>]
```

## DESCRIPTION
The Get-KshFile cmdlet retrives files of the specified folder.

## EXAMPLES

### Example 1
```powershell
PS C:\> $file = Get-KshFile -FileId '2c7ceb97-193f-4d05-91a5-a03c6d58ae60'
```

Retrieves a file by file ID.

### Example 2
```powershell
PS C:\> $file = Get-KshFile -FileUrl '/sites/japan/hr/Shared%20Documents/README.txt'
```

Retrieves a file by file URL.

### Example 3
```powershell
PS C:\> $file = Get-KshFile -Folder '/sites/japan/hr/Shared%20Documents' -FileName 'README.txt'
```

Retrieves a file by folder and file name.

### Example 4
```powershell
PS C:\> $files = Get-KshFile -Folder '/sites/japan/hr/Shared%20Documents'
```

Retrieves all files.

## PARAMETERS

### -AttachmentFile
Specifies the attachment file.

```yaml
Type: AttachmentFile
Parameter Sets: ParamSet2
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -FileId
Specifies the file ID.

```yaml
Type: Guid
Parameter Sets: ParamSet3
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FileName
Specifies the file name.

```yaml
Type: String
Parameter Sets: ParamSet5
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FileUrl
Specifies the file URL.

```yaml
Type: Uri
Parameter Sets: ParamSet4
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Folder
Specifies the folder.

```yaml
Type: Folder
Parameter Sets: ParamSet5, ParamSet6
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Identity
Specifies the file.

```yaml
Type: File
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
Parameter Sets: ParamSet6
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

### Karamem0.SharePoint.PowerShell.Models.File

## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.File

## NOTES

## RELATED LINKS

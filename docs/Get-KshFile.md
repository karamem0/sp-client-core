---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Get-KshFile

## SYNOPSIS
Retrieves one or more files from a folder.

## SYNTAX

### ParamSet1
```
Get-KshFile [-Identity] <File> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet2
```
Get-KshFile [-AttachmentFile] <AttachmentFile> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet3
```
Get-KshFile [-FileVersion] <FileVersion> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet4
```
Get-KshFile [-App] <App> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet5
```
Get-KshFile [-ListItem] <ListItem> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet6
```
Get-KshFile [-FileId] <Guid> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet7
```
Get-KshFile [-FileUrl] <Uri> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet8
```
Get-KshFile [-Folder] <Folder> [-FileName] <String> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet9
```
Get-KshFile [-Folder] <Folder> [-NoEnumerate] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Get-KshFile` cmdlet retrieves a file from a folder on the specified parameters.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-KshFile -Identity $file
```

This example retrieves a file by identity.

### Example 2
```powershell
PS C:\> Get-KshFile -AttachmentFile $attachmentFile
```

This example retrieves a file by attachment file.

### Example 3
```powershell
PS C:\> Get-KshFile -FileVersion $fileVersion
```

This example retrieves a file by file version.

### Example 4
```powershell
PS C:\> Get-KshFile -App $app
```

This example retrieves a file by app.

### Example 5
```powershell
PS C:\> Get-KshFile -ListItem $listItem
```

This example retrieves a file by list item.

### Example 6
```powershell
PS C:\> Get-KshFile -FileId $guid
```

This example retrieves a file by file ID.

### Example 7
```powershell
PS C:\> Get-KshFile -FileUrl $uri
```

This example retrieves a file by file URL.

### Example 8
```powershell
PS C:\> Get-KshFile -Folder $folder -FileName "example.txt"
```

This example retrieves a file by file name.

### Example 9
```powershell
PS C:\> Get-KshFile -Folder $folder
```

This example retrieves all files.

## PARAMETERS

### -App
Specifies the app from which to retrieve the file.

```yaml
Type: App
Parameter Sets: ParamSet4
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -AttachmentFile
Specifies the attachment file to retrieve.

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
Specifies the GUID of the file to retrieve.

```yaml
Type: Guid
Parameter Sets: ParamSet6
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FileName
Specifies the name of the file to retrieve from the folder.

```yaml
Type: String
Parameter Sets: ParamSet8
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FileUrl
Specifies the URL of the file to retrieve.

```yaml
Type: Uri
Parameter Sets: ParamSet7
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FileVersion
Specifies the version of the file to retrieve.

```yaml
Type: FileVersion
Parameter Sets: ParamSet3
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Folder
Specifies the folder from which to retrieve the file.

```yaml
Type: Folder
Parameter Sets: ParamSet8, ParamSet9
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Identity
Specifies the file to retrieve.

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

### -ListItem
Specifies the list item from which to retrieve the file.

```yaml
Type: ListItem
Parameter Sets: ParamSet5
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -NoEnumerate
Indicates that the cmdlet does not enumerate the folder contents.

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet9
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

### Karamem0.SharePoint.PowerShell.Models.V1.File
### Karamem0.SharePoint.PowerShell.Models.V1.AttachmentFile
### Karamem0.SharePoint.PowerShell.Models.V1.FileVersion
### Karamem0.SharePoint.PowerShell.Models.V1.App
### Karamem0.SharePoint.PowerShell.Models.V1.ListItem
## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.File
## NOTES

## RELATED LINKS


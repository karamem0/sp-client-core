---
external help file: SPClientCore.dll-help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Get-KshDriveItem

## SYNOPSIS
Retrieves one or more drive items.

## SYNTAX

### ParamSet1
```
Get-KshDriveItem [-Identity] <DriveItem> [<CommonParameters>]
```

### ParamSet2
```
Get-KshDriveItem [-Folder] <Folder> [<CommonParameters>]
```

### ParamSet3
```
Get-KshDriveItem [-File] <File> [<CommonParameters>]
```

### ParamSet4
```
Get-KshDriveItem [-ListItem] <ListItem> [<CommonParameters>]
```

### ParamSet5
```
Get-KshDriveItem [-DriveItemUrl] <Uri> [<CommonParameters>]
```

### ParamSet6
```
Get-KshDriveItem [-Drive] <Drive> [-DriveItemId] <String> [<CommonParameters>]
```

### ParamSet7
```
Get-KshDriveItem [-Drive] <Drive> [-DriveItemPath] <Uri> [<CommonParameters>]
```

### ParamSet8
```
Get-KshDriveItem [-Drive] <Drive> [-NoEnumerate] [<CommonParameters>]
```

### ParamSet9
```
Get-KshDriveItem [-DriveItem] <DriveItem> [-NoEnumerate] [<CommonParameters>]
```

## DESCRIPTION
The Get-KshDriveItem cmdlet retrieves drive items of the specified drive.
The drive represents a logical container of files, like a document library or a user's OneDrive.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-KshDriveItem -Drive (Get-KshDrive -DriveId 'b!vpvKq3kXeEaww1z6NPnGbKhvcv2QlkNIoGE112ESrYtKvAhAPsWLSLhCqJy8wVDu') -DriveItemId '01DTPY6YF6Y2GOVW7725BZO354PWSELRRZ'
```

Retrieves a drive item by drive item ID.

### Example 2
```powershell
PS C:\> Get-KshDriveItem -Drive (Get-KshDrive -DriveId 'b!vpvKq3kXeEaww1z6NPnGbKhvcv2QlkNIoGE112ESrYtKvAhAPsWLSLhCqJy8wVDu') -DriveItemPath '/README.txt'
```

Retrieves a drive item by drive item path.

### Example 3
```powershell
PS C:\> Get-KshDriveItem -Drive (Get-KshDrive -DriveId 'b!vpvKq3kXeEaww1z6NPnGbKhvcv2QlkNIoGE112ESrYtKvAhAPsWLSLhCqJy8wVDu')
```

Retrieves all drive items of drive root.

### Example 4
```powershell
PS C:\> Get-KshDriveItem -DriveItem (Get-KshDriveItem -Drive (Get-KshDrive -DriveId 'b!vpvKq3kXeEaww1z6NPnGbKhvcv2QlkNIoGE112ESrYtKvAhAPsWLSLhCqJy8wVDu'))
```

Retrieves all drive items of drive item.

## PARAMETERS

### -Drive
Specifies the drive.

```yaml
Type: Drive
Parameter Sets: ParamSet6, ParamSet7, ParamSet8
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DriveItem
Specifies the parent drive item.

```yaml
Type: DriveItem
Parameter Sets: ParamSet9
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DriveItemId
Specifies the drive item ID.

```yaml
Type: String
Parameter Sets: ParamSet6
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DriveItemPath
Specifies the drive item path.

```yaml
Type: Uri
Parameter Sets: ParamSet7
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DriveItemUrl
Specifies the drive item URL.

```yaml
Type: Uri
Parameter Sets: ParamSet5
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -File
Specifies the file.

```yaml
Type: File
Parameter Sets: ParamSet3
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
Parameter Sets: ParamSet2
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Identity
Specifies the drive item.

```yaml
Type: DriveItem
Parameter Sets: ParamSet1
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ListItem
Specifies the list item.

```yaml
Type: ListItem
Parameter Sets: ParamSet4
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoEnumerate
If specified, suppresses to enumerate objects.

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet8, ParamSet9
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

### Karamem0.SharePoint.PowerShell.Models.V2.DriveItem

## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V2.DriveItem

## NOTES

## RELATED LINKS

---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Get-KshDriveItem

## SYNOPSIS
Retrieves one or more drive items from a drive or drive item.

## SYNTAX

### ParamSet1
```
Get-KshDriveItem [-Identity] <DriveItem> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet2
```
Get-KshDriveItem [-Folder] <Folder> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet3
```
Get-KshDriveItem [-File] <File> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet4
```
Get-KshDriveItem [-ListItem] <ListItem> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet5
```
Get-KshDriveItem [-DriveItemUrl] <Uri> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet6
```
Get-KshDriveItem [-Drive] <Drive> [-DriveItemId] <String> [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### ParamSet7
```
Get-KshDriveItem [-Drive] <Drive> [-DriveItemPath] <Uri> [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### ParamSet8
```
Get-KshDriveItem [-Drive] <Drive> [-NoEnumerate] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet9
```
Get-KshDriveItem [-DriveItem] <DriveItem> [-NoEnumerate] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

## DESCRIPTION
The `Get-KshDriveItem` cmdlet retrieves one or more drive items from a drive or drive item based on the specified parameters.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-KshDriveItem -Identity $driveItem
```

This example retrieves a drive item by identity.

### Example 2
```powershell
PS C:\> Get-KshDriveItem -Folder $folder
```

This example retrieves a drive item by folder.

### Example 3
```powershell
PS C:\> Get-KshDriveItem -File $file
```

This example retrieves a drive item by file.

### Example 4
```powershell
PS C:\> Get-KshDriveItem -ListItem $listItem
```

This example retrieves a drive item by list item.

### Example 5
```powershell
PS C:\> Get-KshDriveItem -DriveItemUrl "https://contoso.sharepoint.com/Shared Documents/file.txt"
```

This example retrieves a drive item by drive item URL.

### Example 6
```powershell
PS C:\> Get-KshDriveItem -Drive $drive -DriveItemId "01DTPY6YF6Y2GOVW7725BZO354PWSELRRZ"
```

This example retrieves a drive item by drive item ID.

### Example 7
```powershell
PS C:\> Get-KshDriveItem -Drive $drive -DriveItemPath "/file.txt"
```

This example retrieves a drive item by drive item path.

### Example 8
```powershell
PS C:\> Get-KshDriveItem -Drive $drive
```

This example retrieves drive items from the drive root.

### Example 9
```powershell
PS C:\> Get-KshDriveItem -DriveItem $driveItem
```

This example retrieves drive items from the specified drive item.

## PARAMETERS

### -Drive
Specifies the drive object.

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
Specifies the drive item object.

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
Specifies the ID of the drive item to retrieve.

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
Specifies the path of the drive item to retrieve.

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
Specifies the URL of the drive item to retrieve.

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
Specifies the file object to retrieve.

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
Specifies the folder object to retrieve.

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
Specifies the drive item to retrieve.

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
Specifies the list item object to retrieve.

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
Indicates that the cmdlet does not enumerate the drive items.

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

### Karamem0.SharePoint.PowerShell.Models.V2.DriveItem
## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V2.DriveItem
## NOTES

## RELATED LINKS


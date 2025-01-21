---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Get-KshFolder

## SYNOPSIS
Retrieves one or more folders from a folder.

## SYNTAX

### ParamSet1
```
Get-KshFolder [-Identity] <Folder> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet2
```
Get-KshFolder [-List] <List> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet3
```
Get-KshFolder [-ListItem] <ListItem> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet4
```
Get-KshFolder [-FolderId] <Guid> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet5
```
Get-KshFolder [-FolderUrl] <Uri> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet6
```
Get-KshFolder [-Folder] <Folder> [-FolderName] <String> [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### ParamSet7
```
Get-KshFolder [-Folder] <Folder> [-NoEnumerate] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet8
```
Get-KshFolder [-NoEnumerate] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Get-KshFolder` cmdlet retrieves one or more folders based on the specified parameters.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-KshFolder -Identity $folder
```

This example retrieves a folder by identity.

### Example 2
```powershell
PS C:\> Get-KshFolder -List $list
```

This example retrieves a folder by list.

### Example 3
```powershell
PS C:\> Get-KshFolder -ListItem $listItem
```

This example retrieves a folder by list item.

### Example 4
```powershell
PS C:\> Get-KshFolder -FolderId $folderId
```

This example retrieves a folder by folder ID.

### Example 5
```powershell
PS C:\> Get-KshFolder -FolderUrl $folderUrl
```

This example retrieves a folder by folder URL.

### Example 6
```powershell
PS C:\> Get-KshFolder -Folder $folder -FolderName "Documents"
```

This example retrieves a folder by folder name.

### Example 7
```powershell
PS C:\> Get-KshFolder -Folder $folder
```

This example retrieves all folders.

### Example 8
```powershell
PS C:\> Get-KshFolder
```

This example retrieves all folders.

## PARAMETERS

### -Folder
Specifies the folder object.

```yaml
Type: Folder
Parameter Sets: ParamSet6, ParamSet7
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FolderId
Specifies the ID of the folder.

```yaml
Type: Guid
Parameter Sets: ParamSet4
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FolderName
Specifies the name of the folder.

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

### -FolderUrl
Specifies the URL of the folder.

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

### -Identity
Specifies the folder to retrieve.

```yaml
Type: Folder
Parameter Sets: ParamSet1
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -List
Specifies the list object.

```yaml
Type: List
Parameter Sets: ParamSet2
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ListItem
Specifies the list item object.

```yaml
Type: ListItem
Parameter Sets: ParamSet3
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
Parameter Sets: ParamSet7, ParamSet8
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
Specifies the action preference for progress.

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

### Karamem0.SharePoint.PowerShell.Models.V1.Folder
### Karamem0.SharePoint.PowerShell.Models.V1.List
### Karamem0.SharePoint.PowerShell.Models.V1.ListItem
## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.Folder
## NOTES

## RELATED LINKS


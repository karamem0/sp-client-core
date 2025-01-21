---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Get-KshListItem

## SYNOPSIS
Retrieves one or more list items from a list.

## SYNTAX

### ParamSet1
```
Get-KshListItem [-Identity] <ListItem> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet2
```
Get-KshListItem [-Folder] <Folder> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet3
```
Get-KshListItem [-File] <File> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet4
```
Get-KshListItem [-DriveItem] <DriveItem> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet5
```
Get-KshListItem [-ItemUrl] <String> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet6
```
Get-KshListItem [-List] <List> [-ItemId] <Int32> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet7
```
Get-KshListItem [-List] <List> [-All] [-NoEnumerate] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet8
```
Get-KshListItem [-List] <List> [-FolderServerRelativeUrl <String>]
 [-ListItemCollectionPosition <ListItemCollectionPosition>] [-ViewXml <String>] [-NoEnumerate]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Get-KshListItem` cmdlet retrieves one or more list items from a list based on the specified parameters.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-KshListItem -Identity $ListItem
```

This example retrieves a list item by identity.

## PARAMETERS

### -All
Retrieves all list items.

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet7
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DriveItem
Specifies the drive item to retrieve.

```yaml
Type: DriveItem
Parameter Sets: ParamSet4
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -File
Specifies the file to retrieve.

```yaml
Type: File
Parameter Sets: ParamSet3
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Folder
Specifies the folder to retrieve.

```yaml
Type: Folder
Parameter Sets: ParamSet2
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -FolderServerRelativeUrl
Specifies the server-relative URL of the folder.

```yaml
Type: String
Parameter Sets: ParamSet8
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Identity
Specifies the list item to retrieve.

```yaml
Type: ListItem
Parameter Sets: ParamSet1
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ItemId
Specifies the ID of the list item to retrieve.

```yaml
Type: Int32
Parameter Sets: ParamSet6
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ItemUrl
Specifies the URL of the list item to retrieve.

```yaml
Type: String
Parameter Sets: ParamSet5
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -List
Specifies the list that contains the item to retrieve.

```yaml
Type: List
Parameter Sets: ParamSet6, ParamSet7, ParamSet8
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ListItemCollectionPosition
Specifies the position of the list item collection.

```yaml
Type: ListItemCollectionPosition
Parameter Sets: ParamSet8
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoEnumerate
Indicates that the cmdlet does not enumerate the collection.

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

### -ViewXml
Specifies the XML view of the list items.

```yaml
Type: String
Parameter Sets: ParamSet8
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

### Karamem0.SharePoint.PowerShell.Models.V1.ListItem
### Karamem0.SharePoint.PowerShell.Models.V1.Folder
### Karamem0.SharePoint.PowerShell.Models.V1.File
### Karamem0.SharePoint.PowerShell.Models.V2.DriveItem
## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.ListItem
## NOTES

## RELATED LINKS


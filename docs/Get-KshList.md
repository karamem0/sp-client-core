---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Get-KshList

## SYNOPSIS
Retrieves one or more lists from the current site.

## SYNTAX

### ParamSet1
```
Get-KshList [-Identity] <List> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet2
```
Get-KshList [-ListItem] <ListItem> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet3
```
Get-KshList [-View] <View> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet4
```
Get-KshList [-Drive] <Drive> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet5
```
Get-KshList [-ListId] <Guid> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet6
```
Get-KshList [-ListUrl] <Uri> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet7
```
Get-KshList [-ListTitle] <String> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet8
```
Get-KshList [-LibraryType] <LibraryType> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet9
```
Get-KshList [-NoEnumerate] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Get-KshList` cmdlet retrieves a list from the specified site based on the specified parameters.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-KshList -Identity $list
```

This example retrieves a list by identity.

### Example 2
```powershell
PS C:\> Get-KshList -ListItem $listItem
```

This example retrieves a list by list item.

### Example 3
```powershell
PS C:\> Get-KshList -View $view
```

This example retrieves a list by view.

### Example 4
```powershell
PS C:\> Get-KshList -Drive $drive
```

This example retrieves a list by drive.

### Example 5
```powershell
PS C:\> Get-KshList -ListId $listId
```

This example retrieves a list by list ID.

### Example 6
```powershell
PS C:\> Get-KshList -ListUrl $listUrl
```

This example retrieves a list by list URL.

### Example 7
```powershell
PS C:\> Get-KshList -ListTitle "Documents"
```

This example retrieves a list by list title.

### Example 8
```powershell
PS C:\> Get-KshList -LibraryType "SiteAssets"
```

This example retrieves a list by library type.

### Example 9
```powershell
PS C:\> Get-KshList
```

This example retrieves all lists.

## PARAMETERS

### -Drive
Specifies the drive from which to retrieve the list.

```yaml
Type: Drive
Parameter Sets: ParamSet4
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Identity
Specifies the list to retrieve.

```yaml
Type: List
Parameter Sets: ParamSet1
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -LibraryType
Specifies the type of library to retrieve.

```yaml
Type: LibraryType
Parameter Sets: ParamSet8
Aliases:
Accepted values: SitePages, ClientRenderedSitePages, SiteAssets

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ListId
Specifies the ID of the list to retrieve.

```yaml
Type: Guid
Parameter Sets: ParamSet5
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ListItem
Specifies the list item from which to retrieve the list.

```yaml
Type: ListItem
Parameter Sets: ParamSet2
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ListTitle
Specifies the title of the list to retrieve.

```yaml
Type: String
Parameter Sets: ParamSet7
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ListUrl
Specifies the URL of the list to retrieve.

```yaml
Type: Uri
Parameter Sets: ParamSet6
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoEnumerate
Indicates that the cmdlet does not enumerate the list.

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

### -View
Specifies the view from which to retrieve the list.

```yaml
Type: View
Parameter Sets: ParamSet3
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
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

### Karamem0.SharePoint.PowerShell.Models.V1.List
### Karamem0.SharePoint.PowerShell.Models.V1.ListItem
### Karamem0.SharePoint.PowerShell.Models.V1.View
### Karamem0.SharePoint.PowerShell.Models.V2.Drive
## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.List
## NOTES

## RELATED LINKS


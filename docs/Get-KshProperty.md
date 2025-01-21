---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Get-KshProperty

## SYNOPSIS
Retrieves properties of a alert, file, folder, list item or site.

## SYNTAX

### ParamSet1
```
Get-KshProperty [-Alert] <Alert> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet2
```
Get-KshProperty [-File] <File> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet3
```
Get-KshProperty [-Folder] <Folder> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet4
```
Get-KshProperty [-ListItem] <ListItem> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet5
```
Get-KshProperty [-Site] <Site> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Get-KshProperty` cmdlet retrieves properties of a alert, file, folder, list item or site.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-KshProperty -Alert $alert
```

This example retrieves alert properties.

### Example 2
```powershell
PS C:\> Get-KshProperty -File $file
```

This example retrieves file properties.

### Example 3
```powershell
PS C:\> Get-KshProperty -Folder $folder
```

This example retrieves folder properties.

### Example 4
```powershell
PS C:\> Get-KshProperty -ListItem $listItem
```

This example retrieves list item properties.

### Example 5
```powershell
PS C:\> Get-KshProperty -Site $site
```

This example retrieves site properties.

## PARAMETERS

### -Alert
Specifies the alert whose properties are retrieved.

```yaml
Type: Alert
Parameter Sets: ParamSet1
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -File
Specifies the file whose properties are retrieved.

```yaml
Type: File
Parameter Sets: ParamSet2
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Folder
Specifies the folder whose properties are retrieved.

```yaml
Type: Folder
Parameter Sets: ParamSet3
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ListItem
Specifies the list item whose properties are retrieved.

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

### -Site
Specifies the site whose properties are retrieved.

```yaml
Type: Site
Parameter Sets: ParamSet5
Aliases:

Required: True
Position: 0
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

### None
## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.PropertyValues
## NOTES

## RELATED LINKS


---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Get-KshProperty

## SYNOPSIS
Retrieves properties.

## SYNTAX

### ParamSet1
```
Get-KshProperty [-Alert] <Alert> [<CommonParameters>]
```

### ParamSet2
```
Get-KshProperty [-File] <File> [<CommonParameters>]
```

### ParamSet3
```
Get-KshProperty [-Folder] <Folder> [<CommonParameters>]
```

### ParamSet4
```
Get-KshProperty [-ListItem] <ListItem> [<CommonParameters>]
```

### ParamSet5
```
Get-KshProperty [-Site] <Site> [<CommonParameters>]
```

## DESCRIPTION
The Get-KshProperty cmdlet retrieves properties of the specified alert, file, folder, list item or site.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-KshProperty -Alert (Get-KshAlert -AlertId '8e22b48d-680a-493a-b3d1-b4607108a94a')
```

Retrieves properties of the alert.

### Example 2
```powershell
PS C:\> Get-KshProperty -File (Get-KshFile -FileUrl '/sites/japan/hr/Shared%20Documents/README.txt')
```

Retrieves properties of the file.

### Example 3
```powershell
PS C:\> Get-KshProperty -Folder (Get-KshFolder -FolderUrl '/sites/japan/hr/Shared%20Documents/Templates')
```

Retrieves properties of the folder.

### Example 4
```powershell
PS C:\> Get-KshProperty -ListItem (Get-KshListItem -List (Get-KshList -ListTitle 'Announcements') -ItemId 1)
```

Retrieves properties of the list item.

### Example 5
```powershell
PS C:\> Get-KshProperty -Site (Get-KshSite -SiteUrl '/sites/japan/hr')
```

Retrieves properties of the site.

## PARAMETERS

### -Alert
Specifies the alert.

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
Specifies the file.

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
Specifies the folder.

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

### -Site
Specifies the site.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.PropertyValues

## NOTES

## RELATED LINKS

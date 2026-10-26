---
Module Name: SPClientCore
external help file: SPClientCore.dll-Help.xml
schema: 2.0.0
---

# Get-KshDriveItem

## SYNOPSIS
Get drive item.

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

## PARAMETERS

### -Drive

```yaml
Type: Drive
Parameter Sets: ParamSet6, ParamSet7
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -DriveItemId

```yaml
Type: String
Parameter Sets: ParamSet6
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DriveItemPath

```yaml
Type: Uri
Parameter Sets: ParamSet7
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DriveItemUrl

```yaml
Type: Uri
Parameter Sets: ParamSet5
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -File

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

### -Identity

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

```yaml
Type: ListItem
Parameter Sets: ParamSet4
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ProgressAction

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

### Karamem0.SharePoint.PowerShell.Models.V1.Folder

### Karamem0.SharePoint.PowerShell.Models.V1.File

### Karamem0.SharePoint.PowerShell.Models.V1.ListItem

### Karamem0.SharePoint.PowerShell.Models.V2.Drive

## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V2.DriveItem


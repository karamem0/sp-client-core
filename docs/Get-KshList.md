---
Module Name: SPClientCore
external help file: SPClientCore.dll-Help.xml
schema: 2.0.0
---

# Get-KshList

## SYNOPSIS
Get list.

## SYNTAX

### ParamSet1
```
Get-KshList [-Identity] <List> [-SelectAllProperties] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet2
```
Get-KshList [-ListItem] <ListItem> [-SelectAllProperties] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### ParamSet3
```
Get-KshList [-Folder] <Folder> [-SelectAllProperties] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet4
```
Get-KshList [-File] <File> [-SelectAllProperties] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet5
```
Get-KshList [-View] <View> [-SelectAllProperties] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet6
```
Get-KshList [-Drive] <Drive> [-SelectAllProperties] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet7
```
Get-KshList [-ListId] <Guid> [-SelectAllProperties] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet8
```
Get-KshList [-ListUrl] <Uri> [-SelectAllProperties] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet9
```
Get-KshList [-ListTitle] <String> [-SelectAllProperties] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### ParamSet10
```
Get-KshList [-LibraryType] <LibraryType> [-SelectAllProperties] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### ParamSet11
```
Get-KshList [-SelectAllProperties] [-NoEnumerate] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## PARAMETERS

### -Drive

```yaml
Type: Drive
Parameter Sets: ParamSet6
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -File

```yaml
Type: File
Parameter Sets: ParamSet4
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
Parameter Sets: ParamSet3
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Identity

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

```yaml
Type: LibraryType
Parameter Sets: ParamSet10
Aliases:
Accepted values: SitePages, ClientRenderedSitePages, SiteAssets

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ListId

```yaml
Type: Guid
Parameter Sets: ParamSet7
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ListItem

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

```yaml
Type: String
Parameter Sets: ParamSet9
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ListUrl

```yaml
Type: Uri
Parameter Sets: ParamSet8
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoEnumerate

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet11
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SelectAllProperties

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -View

```yaml
Type: View
Parameter Sets: ParamSet5
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

### Karamem0.SharePoint.PowerShell.Models.V1.List

### Karamem0.SharePoint.PowerShell.Models.V1.ListItem

### Karamem0.SharePoint.PowerShell.Models.V1.Folder

### Karamem0.SharePoint.PowerShell.Models.V1.File

### Karamem0.SharePoint.PowerShell.Models.V1.View

### Karamem0.SharePoint.PowerShell.Models.V2.Drive

## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.List


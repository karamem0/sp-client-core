---
Module Name: SPClientCore
external help file: SPClientCore.dll-Help.xml
schema: 2.0.0
---

# Set-KshApprovalStatus

## SYNOPSIS
Set approval status.

## SYNTAX

### ParamSet1
```
Set-KshApprovalStatus [-File] <File> [-Approve] [[-Comment] <String>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### ParamSet2
```
Set-KshApprovalStatus [-File] <File> [-Reject] [[-Comment] <String>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### ParamSet3
```
Set-KshApprovalStatus [-Folder] <Folder> [-Approve] [[-Comment] <String>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### ParamSet4
```
Set-KshApprovalStatus [-Folder] <Folder> [-Reject] [[-Comment] <String>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### ParamSet5
```
Set-KshApprovalStatus [-Folder] <Folder> [-Pending] [[-Comment] <String>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### ParamSet6
```
Set-KshApprovalStatus [-ListItem] <ListItem> [-Approve] [[-Comment] <String>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet7
```
Set-KshApprovalStatus [-ListItem] <ListItem> [-Reject] [[-Comment] <String>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet8
```
Set-KshApprovalStatus [-ListItem] <ListItem> [-Pending] [[-Comment] <String>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## PARAMETERS

### -Approve

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet1, ParamSet3, ParamSet6
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Comment

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -File

```yaml
Type: File
Parameter Sets: ParamSet1, ParamSet2
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
Parameter Sets: ParamSet3, ParamSet4, ParamSet5
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
Parameter Sets: ParamSet6, ParamSet7, ParamSet8
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Pending

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet5, ParamSet8
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Reject

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet2, ParamSet4, ParamSet7
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
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

### Karamem0.SharePoint.PowerShell.Models.V1.File

### Karamem0.SharePoint.PowerShell.Models.V1.Folder

### Karamem0.SharePoint.PowerShell.Models.V1.ListItem

## OUTPUTS

### System.Void


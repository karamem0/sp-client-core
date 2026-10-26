---
Module Name: SPClientCore
external help file: SPClientCore.dll-Help.xml
schema: 2.0.0
---

# New-KshColumnImageValue

## SYNOPSIS
Create an image value column.

## SYNTAX

### ParamSet1
```
New-KshColumnImageValue [-ImageItem] <ImageItem> [[-ColumnName] <String>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### ParamSet2
```
New-KshColumnImageValue [[-ColumnName] <String>] [[-FileName] <String>] [[-ServerUrl] <Uri>]
 [[-ServerRelativeUrl] <Uri>] [[-Id] <Guid>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## PARAMETERS

### -ColumnName

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

### -FileName

```yaml
Type: String
Parameter Sets: ParamSet2
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Id

```yaml
Type: Guid
Parameter Sets: ParamSet2
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ImageItem

```yaml
Type: ImageItem
Parameter Sets: ParamSet1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServerRelativeUrl

```yaml
Type: Uri
Parameter Sets: ParamSet2
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServerUrl

```yaml
Type: Uri
Parameter Sets: ParamSet2
Aliases:

Required: False
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

### None

## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.ColumnImageValue


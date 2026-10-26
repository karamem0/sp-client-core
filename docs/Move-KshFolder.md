---
Module Name: SPClientCore
external help file: SPClientCore.dll-Help.xml
schema: 2.0.0
---

# Move-KshFolder

## SYNOPSIS
Move folder.

## SYNTAX

### ParamSet1
```
Move-KshFolder [-Identity] <Folder> [-NewUrl] <Uri> [-KeepBoth] [-ResetAuthorAndCreatedOnCopy]
 [-RetainEditorAndModifiedOnMove] [-ShouldBypassSharedLocks] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### ParamSet2
```
Move-KshFolder [-Identity] <Folder> [-NewUrl] <Uri> [-Legacy] [-PassThru] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

## PARAMETERS

### -Identity

```yaml
Type: Folder
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -KeepBoth

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Legacy

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet2
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NewUrl

```yaml
Type: Uri
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet2
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResetAuthorAndCreatedOnCopy

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RetainEditorAndModifiedOnMove

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ShouldBypassSharedLocks

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet1
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

### Karamem0.SharePoint.PowerShell.Models.V1.Folder

## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.Folder


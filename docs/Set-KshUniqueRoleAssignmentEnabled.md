---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Set-KshUniqueRoleAssignmentEnabled

## SYNOPSIS
{{ Fill in the Synopsis }}

## SYNTAX

### ParamSet1
```
Set-KshUniqueRoleAssignmentEnabled [-Site] [-Enabled] [-CopyRoleAssignments] [-ClearSubscopes]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet2
```
Set-KshUniqueRoleAssignmentEnabled [-Site] [-Disabled] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### ParamSet3
```
Set-KshUniqueRoleAssignmentEnabled [-List] <List> [-Enabled] [-CopyRoleAssignments] [-ClearSubscopes]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet4
```
Set-KshUniqueRoleAssignmentEnabled [-List] <List> [-Disabled] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### ParamSet5
```
Set-KshUniqueRoleAssignmentEnabled [-ListItem] <ListItem> [-Enabled] [-CopyRoleAssignments] [-ClearSubscopes]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet6
```
Set-KshUniqueRoleAssignmentEnabled [-ListItem] <ListItem> [-Disabled] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

## DESCRIPTION
{{ Fill in the Description }}

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -ClearSubscopes
{{ Fill ClearSubscopes Description }}

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet1, ParamSet3, ParamSet5
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CopyRoleAssignments
{{ Fill CopyRoleAssignments Description }}

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet1, ParamSet3, ParamSet5
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Disabled
{{ Fill Disabled Description }}

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet2, ParamSet4, ParamSet6
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Enabled
{{ Fill Enabled Description }}

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet1, ParamSet3, ParamSet5
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -List
{{ Fill List Description }}

```yaml
Type: List
Parameter Sets: ParamSet3, ParamSet4
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ListItem
{{ Fill ListItem Description }}

```yaml
Type: ListItem
Parameter Sets: ParamSet5, ParamSet6
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Site
{{ Fill Site Description }}

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet1, ParamSet2
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

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

### System.Void
## NOTES

## RELATED LINKS


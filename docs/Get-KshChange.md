---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Get-KshChange

## SYNOPSIS
{{ Fill in the Synopsis }}

## SYNTAX

### ParamSet1
```
Get-KshChange [-SiteCollection] [-BeginToken <ChangeToken>] [-EndToken <ChangeToken>] [-FetchLimit <Int64>]
 [-Objects <ChangeObjects>] [-Operations <ChangeOperations>] [-RecursiveAll <Boolean>] [-NoEnumerate]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet2
```
Get-KshChange [-Site] [-BeginToken <ChangeToken>] [-EndToken <ChangeToken>] [-FetchLimit <Int64>]
 [-Objects <ChangeObjects>] [-Operations <ChangeOperations>] [-RecursiveAll <Boolean>] [-NoEnumerate]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet3
```
Get-KshChange [-List] <List> [-BeginToken <ChangeToken>] [-EndToken <ChangeToken>] [-FetchLimit <Int64>]
 [-Objects <ChangeObjects>] [-Operations <ChangeOperations>] [-RecursiveAll <Boolean>] [-NoEnumerate]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
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

### -BeginToken
{{ Fill BeginToken Description }}

```yaml
Type: ChangeToken
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EndToken
{{ Fill EndToken Description }}

```yaml
Type: ChangeToken
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FetchLimit
{{ Fill FetchLimit Description }}

```yaml
Type: Int64
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -List
{{ Fill List Description }}

```yaml
Type: List
Parameter Sets: ParamSet3
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoEnumerate
{{ Fill NoEnumerate Description }}

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

### -Objects
{{ Fill Objects Description }}

```yaml
Type: ChangeObjects
Parameter Sets: (All)
Aliases:
Accepted values: None, Item, List, Site, SiteCollection, File, Folder, Alert, User, Group, ContentType, Column, SecurityPolicy, View, All

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Operations
{{ Fill Operations Description }}

```yaml
Type: ChangeOperations
Parameter Sets: (All)
Aliases:
Accepted values: None, Add, Update, DeleteObject, Rename, Move, Restore, RoleDefinitionAdd, RoleDefinitionDelete, RoleDefinitionUpdate, RoleAssignmentAdd, RoleAssignmentDelete, GroupMembershipAdd, GroupMembershipDelete, SystemUpdate, Navigation, All

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RecursiveAll
{{ Fill RecursiveAll Description }}

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Site
{{ Fill Site Description }}

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet2
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SiteCollection
{{ Fill SiteCollection Description }}

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet1
Aliases:

Required: True
Position: Named
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

### Karamem0.SharePoint.PowerShell.Models.V1.Change
## NOTES

## RELATED LINKS


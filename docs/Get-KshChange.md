---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Get-KshChange

## SYNOPSIS
Retrieves changes from a site collection, site, or list.

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
The `Get-KshChange` cmdlet retrieves changes from a site collection, site, or list based on the specified parameters.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-KshChange -SiteCollection -BeginToken $beginToken -EndToken $endToken -FetchLimit 100
```

This example retrieves site collection changes between the given change tokens with a fetch limit of 100.

### Example 2
```powershell
PS C:\> Get-KshChange -Site -BeginToken $beginToken -EndToken $endToken -FetchLimit 50
```

This example retrieves site changes between the given change tokens with a fetch limit of 50.

### Example 3
```powershell
PS C:\> Get-KshChange -List $list -BeginToken $beginToken -EndToken $endToken -FetchLimit 200
```

This example retrieves list changes  between the given change tokens with a fetch limit of 200.

## PARAMETERS

### -BeginToken
Specifies the beginning change token.

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
Specifies the ending change token.

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
Specifies the maximum number of changes to retrieve.

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
Specifies the list from which to retrieve changes.

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
Indicates that the cmdlet does not enumerate the changes.

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
Specifies the types of objects to retrieve changes for.

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
Specifies the types of operations to retrieve changes for.

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
Indicates that the cmdlet retrieves changes recursively.

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
Specifies that the cmdlet retrieves changes from a site.

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
Specifies that the cmdlet retrieves changes from a site collection.

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

### None
## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.Change
## NOTES

## RELATED LINKS


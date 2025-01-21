---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Get-KshGroupMember

## SYNOPSIS
Retrieves one or more group members from a group.

## SYNTAX

### ParamSet1
```
Get-KshGroupMember [-Group] <Group> [-MemberId] <Int32> [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### ParamSet2
```
Get-KshGroupMember [-Group] <Group> [-MemberName] <String> [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### ParamSet3
```
Get-KshGroupMember [-Group] <Group> [-NoEnumerate] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Get-KshGroupMember` cmdlet retrieves group members from a group based on the specified parameters.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-KshGroupMember -Group $group -MemberId 123
```

This example retrieves a group member by member ID.

### Example 2
```powershell
PS C:\> Get-KshGroupMember -Group $group -MemberName "JohnDoe"
```

This example retrieves a group member by member name.

### Example 3
```powershell
PS C:\> Get-KshGroupMember -Group $group
```

This example retrieves all group members.

## PARAMETERS

### -Group
Specifies the group from which to retrieve members.

```yaml
Type: Group
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MemberId
Specifies the ID of the member to retrieve.

```yaml
Type: Int32
Parameter Sets: ParamSet1
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MemberName
Specifies the name of the member to retrieve.

```yaml
Type: String
Parameter Sets: ParamSet2
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoEnumerate
Indicates that the cmdlet should not enumerate the members.

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet3
Aliases:

Required: False
Position: Named
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

### Karamem0.SharePoint.PowerShell.Models.V1.User
## NOTES

## RELATED LINKS


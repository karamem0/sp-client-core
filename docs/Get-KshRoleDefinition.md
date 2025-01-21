---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Get-KshRoleDefinition

## SYNOPSIS
Retrieves one or more role definitions from the current site.

## SYNTAX

### ParamSet1
```
Get-KshRoleDefinition [-Identity] <RoleDefinition> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet2
```
Get-KshRoleDefinition [-RoleDefinitionId] <Int32> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet3
```
Get-KshRoleDefinition [-RoleDefinitionName] <String> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet4
```
Get-KshRoleDefinition [-NoEnumerate] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Get-KshRoleDefinition` cmdlet retrieves one or more role definitions from the current site based on the specified parameters.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-KshRoleDefinition -Identity $roleDefinition
```

This example retrieves a role definition by identity.

### Example 2
```powershell
PS C:\> Get-KshRoleDefinition -RoleDefinitionId 1073741829
```

This example retrieves a role definition by role definition ID.

### Example 3
```powershell
PS C:\> Get-KshRoleDefinition -RoleDefinitionName "Full Control"
```

This example retrieves a role definition by role definition name.

### Example 4
```powershell
PS C:\> Get-KshRoleDefinition
```

This example retrieves all role definitions.

## PARAMETERS

### -Identity
Specifies the role definition to retrieve.

```yaml
Type: RoleDefinition
Parameter Sets: ParamSet1
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -NoEnumerate
Indicates that the cmdlet does not enumerate the collection.

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet4
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RoleDefinitionId
Specifies the ID of the role definition.

```yaml
Type: Int32
Parameter Sets: ParamSet2
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RoleDefinitionName
Specifies the name of the role definition.

```yaml
Type: String
Parameter Sets: ParamSet3
Aliases:

Required: True
Position: 0
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

### Karamem0.SharePoint.PowerShell.Models.V1.RoleDefinition
## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.RoleDefinition
## NOTES

## RELATED LINKS


---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Set-KshUniqueRoleAssignmentEnabled

## SYNOPSIS
Changes whether unique role assignment is enabled.

## SYNTAX

### ParamSet1
```
Set-KshUniqueRoleAssignmentEnabled [-Identity] <SecurableObject> [-Enabled] [-CopyRoleAssignments]
 [-ClearSubscopes] [<CommonParameters>]
```

### ParamSet2
```
Set-KshUniqueRoleAssignmentEnabled [-Identity] <SecurableObject> [-Disabled] [<CommonParameters>]
```

## DESCRIPTION
The Set-KshUniqueRoleAssignmentEnabled cmdlet changes whether unique role assignment is enabled for the securable object.

## EXAMPLES

### Example 1
```powershell
PS C:\> Set-KshUniqueRoleAssignmentEnabled -Identity (Get-KshCurrentSite) -Enabled -CopyRoleAssignments -ClearSubscopes
```

Creates unique role assignments for the securable object.

### Example 2
```powershell
PS C:\> Set-KshUniqueRoleAssignmentEnabled -Identity (Get-KshCurrentSite) -Disabled
```

Removes unique role assignments for the securable object.

## PARAMETERS

### -ClearSubscopes
If specified, the role assignments for all child securable objects must be cleared.

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

### -CopyRoleAssignments
If specified, copies the role assignments from the parent securable object.

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

### -Disabled
If specified, removes unique role assignments for the securable object.

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

### -Enabled
If specified, creates unique role assignments for the securable object.

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

### -Identity
Specifies the securable object.

```yaml
Type: SecurableObject
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Karamem0.SharePoint.PowerShell.Models.SecurableObject

## OUTPUTS

### None

## NOTES

## RELATED LINKS

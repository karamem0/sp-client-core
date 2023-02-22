---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Set-KshRoleDefinition

## SYNOPSIS
Updates a role definition.

## SYNTAX

```
Set-KshRoleDefinition [-Identity] <RoleDefinition> [-BasePermission <BasePermission>] [-Description <String>]
 -Name <String> [-Order <Int32>] [-PassThru] [<CommonParameters>]
```

## DESCRIPTION
The Set-KshRoleDefinition cmdlet updates properties of the role definition.

## EXAMPLES

### Example 1
```powershell
PS C:\> Set-KshRoleDefinition -Identity (Get-KshRoleDefinition -Name 'Viewer') -Order 255
```

Updates property values of the role definition.

## PARAMETERS

### -BasePermission
Specifies the base permissions.

```yaml
Type: BasePermission
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Description
Specifies the description.

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

### -Identity
Specifies the role definition.

```yaml
Type: RoleDefinition
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Specifies the name.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Order
Specifies the order.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
If specified, returns the updated object.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.RoleDefinition

## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.RoleDefinition

## NOTES

## RELATED LINKS

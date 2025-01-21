---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Get-KshUserProperty

## SYNOPSIS
Retrieves properties of a user.

## SYNTAX

### ParamSet1
```
Get-KshUserProperty [-Identity] <UserProperty> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet2
```
Get-KshUserProperty [-UserLoginName] <String> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Get-KshUserProperty` cmdlet retrieves properties of a user.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-KshUserProperty -Identity $userProperty
```

This example retrieves the properties of the user by identity.

### Example 2
```powershell
PS C:\> Get-KshUserProperty -UserLoginName "meganb@contoso.com"
```

This example retrieves the properties of the user by login name.

## PARAMETERS

### -Identity
Specifies the properties of the user to retrieve.

```yaml
Type: UserProperty
Parameter Sets: ParamSet1
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -UserLoginName
Specifies the login name of the user whose properties are to be retrieved.

```yaml
Type: String
Parameter Sets: ParamSet2
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

### Karamem0.SharePoint.PowerShell.Models.V1.UserProperty
## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.UserProperty
## NOTES

## RELATED LINKS


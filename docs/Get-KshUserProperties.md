---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Get-KshUserProperties

## SYNOPSIS
Retrieves an user properties.

## SYNTAX

### ParamSet1
```
Get-KshUserProperties [-Identity] <UserProperties> [<CommonParameters>]
```

### ParamSet2
```
Get-KshUserProperties [-UserLoginName] <String> [<CommonParameters>]
```

## DESCRIPTION
The Get-KshUserProperties cmdlet retrieves properties of the specific user.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-KshUserProperties -UserLoginName 'i:0#.f|membership|admin@example.onmicrosoft.com'
```

Retrieves a user properties by user login name.

## PARAMETERS

### -Identity
Specifies the user properties.

```yaml
Type: UserProperties
Parameter Sets: ParamSet1
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -UserLoginName
Specifies the user login name.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Karamem0.SharePoint.PowerShell.Models.UserProperties

## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.UserProfile

## NOTES

## RELATED LINKS

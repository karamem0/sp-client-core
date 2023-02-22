---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Remove-KshTenantExternalUser

## SYNOPSIS
Removes an external user.

## SYNTAX

```
Remove-KshTenantExternalUser [-User] <ExternalUser> [<CommonParameters>]
```

## DESCRIPTION
The Remove-KshTenantExternalUser cmdlet removes an external user from the tenant. This cmdlet can be used only when connected to the SharePoint admin center.

## EXAMPLES

### Example 1
```powershell
PS C:\> Remove-KshTenantExternalUser -User (KshTenantExternalUser -Filter 'someone@contoso.com')
```

Removes an external user.

## PARAMETERS

### -User
Specifies the external user.

```yaml
Type: ExternalUser
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

### Karamem0.SharePoint.PowerShell.Models.V1.ExternalUser

## OUTPUTS

### None

## NOTES

## RELATED LINKS

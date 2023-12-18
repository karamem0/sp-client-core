---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Get-KshTenantPersonalSite

## SYNOPSIS
Retrieves a personal site.

## SYNTAX

### ParamSet1
```
Get-KshTenantPersonalSite [-User] <User> [<CommonParameters>]
```

### ParamSet2
```
Get-KshTenantPersonalSite [-UserId] <String> [<CommonParameters>]
```

## DESCRIPTION
The Get-KshTenantPersonalSite cmdlet retrieves a personal site URL of the user. This cmdlet can be used only when connected to the SharePoint admin center.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-KshTenantPersonalSite -User (Get-KshTenantUser -SiteCollectionUrl 'https://example.sharepoint.com/sites/japan' -UserName 'i:0#.f|membership|admin@example.onmicrosoft.com')
```

Retrieves a personal site by user.

### Example 2
```powershell
PS C:\> Get-KshTenantPersonalSite -UserId 'admin@example.onmicrosoft.com'
```

Retrieves a personal site by user ID.

## PARAMETERS

### -User
Specifies the user.

```yaml
Type: User
Parameter Sets: ParamSet1
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserId
Specifies the user ID.

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

### None

## OUTPUTS

### System.String

## NOTES

## RELATED LINKS

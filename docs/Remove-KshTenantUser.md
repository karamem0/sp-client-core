---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Remove-KshTenantUser

## SYNOPSIS
Removes a user.

## SYNTAX

### ParamSet1
```
Remove-KshTenantUser [-SiteCollection] <TenantSiteCollection> [-User] <User> [<CommonParameters>]
```

### ParamSet2
```
Remove-KshTenantUser [-SiteCollectionUrl] <Uri> [-User] <User> [<CommonParameters>]
```

## DESCRIPTION
The Remove-KshTenantUser cmdlet removes a user from the specified site collection.

## EXAMPLES

### Example 1
```powershell
PS C:\> Remove-KshTenantUser -SiteCollectionUrl 'https://example.sharepoint.com/sites/japan' -User (Get-KshTenantUser -SiteCollectionUrl 'https://example.sharepoint.com/sites/japan' -UserName 'i:0#.f|membership|admin@example.onmicrosoft.com')
```

Removes a user from the current site.

## PARAMETERS

### -SiteCollection
Specifies the site collection.

```yaml
Type: TenantSiteCollection
Parameter Sets: ParamSet1
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SiteCollectionUrl
Specifies the site collection URL.

```yaml
Type: Uri
Parameter Sets: ParamSet2
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -User
Specifies the user.

```yaml
Type: User
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### None

## NOTES

## RELATED LINKS

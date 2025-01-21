---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Add-KshTenantUser

## SYNOPSIS
Adds a user to a site collection.

## SYNTAX

### ParamSet1
```
Add-KshTenantUser [-SiteCollection] <TenantSiteCollection> [-Email <String>] -LoginName <String>
 [-Title <String>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet2
```
Add-KshTenantUser [-SiteCollectionUrl] <Uri> [-Email <String>] -LoginName <String> [-Title <String>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Add-KshTenantUser` cmdlet adds a user to a site collection.

## EXAMPLES

### Example 1
```powershell
PS C:\> Add-KshTenantUser -SiteCollectionUrl "https://tenant.sharepoint.com/sites/site1" -LoginName "user@consoto.com" -Email "user@consoto.com" -Title "User Title"
```

This example adds a user to the site collection at the given URL with a login name, email, and title.

### Example 2
```powershell
PS C:\> Add-KshTenantUser -SiteCollection $siteCollection -LoginName "user@consoto.com" -Email "user@consoto.com" -Title "User Title"
```

This example adds a user to the specified site collection with a login name, email, and title.

## PARAMETERS

### -Email
Specifies the email address of the user.

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

### -LoginName
Specifies the login name of the user. This parameter is required.

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

### -SiteCollection
Specifies the tenant site collection object.

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
Specifies the URL of the tenant site collection.

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

### -Title
Specifies the title of the user.

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


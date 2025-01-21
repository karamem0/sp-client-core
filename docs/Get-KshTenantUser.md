---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Get-KshTenantUser

## SYNOPSIS
Retrieves one or more users from a site collection.

## SYNTAX

### ParamSet1
```
Get-KshTenantUser [-SiteCollection] <TenantSiteCollection> [-UserId] <Int32>
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet2
```
Get-KshTenantUser [-SiteCollection] <TenantSiteCollection> [-UserName] <String>
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet3
```
Get-KshTenantUser [-SiteCollection] <TenantSiteCollection> [-NoEnumerate] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### ParamSet4
```
Get-KshTenantUser [-SiteCollectionUrl] <Uri> [-UserId] <Int32> [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### ParamSet5
```
Get-KshTenantUser [-SiteCollectionUrl] <Uri> [-UserName] <String> [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### ParamSet6
```
Get-KshTenantUser [-SiteCollectionUrl] <Uri> [-NoEnumerate] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

## DESCRIPTION
The `Get-KshTenantUser` cmdlet retrieves a user from a site collection based on the specified parameters.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-KshTenantUser -SiteCollection $siteCollection -UserId 11
```

This example retrieves a user by site collection and user ID.

### Example 2
```powershell
PS C:\> Get-KshTenantUser -SiteCollection $siteCollection -UserName "meganb@consoto.com"
```

This example retrieves a user by site collection and user name.

### Example 3
```powershell
PS C:\> Get-KshTenantUser -SiteCollection $siteCollection
```

This example retrieves all users by site collection.

### Example 4
```powershell
PS C:\> Get-KshTenantUser -SiteCollectionUrl "https://tenant.sharepoint.com/sites/site1" -UserId 11
```

This example retrieves a user by site collection URL and user ID.

### Example 5
```powershell
PS C:\> Get-KshTenantUser -SiteCollectionUrl "https://tenant.sharepoint.com/sites/site1" -UserName "user@example.com"
```

This example retrieves a user by site collection URL and user name.

### Example 6
```powershell
PS C:\> Get-KshTenantUser -SiteCollectionUrl "https://tenant.sharepoint.com/sites/site1"
```

This example retrieves all users by site collection URL.

## PARAMETERS

### -NoEnumerate
Indicates that the cmdlet should not enumerate the users.

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet3, ParamSet6
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SiteCollection
Specifies the tenant site collection from which to retrieve the user.

```yaml
Type: TenantSiteCollection
Parameter Sets: ParamSet1, ParamSet2, ParamSet3
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SiteCollectionUrl
Specifies the URL of the tenant site collection from which to retrieve the user.

```yaml
Type: Uri
Parameter Sets: ParamSet4, ParamSet5, ParamSet6
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserId
Specifies the ID of the user to retrieve.

```yaml
Type: Int32
Parameter Sets: ParamSet1, ParamSet4
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserName
Specifies the username of the user to retrieve.

```yaml
Type: String
Parameter Sets: ParamSet2, ParamSet5
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

### None
## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.User
## NOTES

## RELATED LINKS


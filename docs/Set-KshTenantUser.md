---
external help file: SPClientCore.dll-help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Set-KshTenantUser

## SYNOPSIS
Changes a user.

## SYNTAX

### ParamSet1
```
Set-KshTenantUser [-SiteCollection] <TenantSiteCollection> [-User] <User> -IsSiteCollectionAdmin <Boolean>
 [-PassThru] [<CommonParameters>]
```

### ParamSet2
```
Set-KshTenantUser [-SiteCollection] <TenantSiteCollection> [-UserName] <String>
 -IsSiteCollectionAdmin <Boolean> [-PassThru] [<CommonParameters>]
```

### ParamSet3
```
Set-KshTenantUser [-SiteCollectionUrl] <Uri> [-User] <User> -IsSiteCollectionAdmin <Boolean> [-PassThru]
 [<CommonParameters>]
```

### ParamSet4
```
Set-KshTenantUser [-SiteCollectionUrl] <Uri> [-UserName] <String> -IsSiteCollectionAdmin <Boolean> [-PassThru]
 [<CommonParameters>]
```

## DESCRIPTION
The Set-KshTenantUser cmdlet updates properties of the user of the specified site collection.
This cmdlet can be used only when connected to the SharePoint admin center.

## EXAMPLES

### Example 1
```powershell
PS C:\> Set-KshTenantUser -SiteCollectionUrl https://example.sharepoint.com/sites/japan -UserName 'admin@example.onmicrosoft.com' -IsSiteCollectionAdmin $true
```

Changes a user.

## PARAMETERS

### -IsSiteCollectionAdmin
Specifies whether the user is a site collection administrator.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: True
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

### -SiteCollection
Specifies the site collection.

```yaml
Type: TenantSiteCollection
Parameter Sets: ParamSet1, ParamSet2
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
Parameter Sets: ParamSet3, ParamSet4
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
Parameter Sets: ParamSet1, ParamSet3
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserName
Specifies the user name.

```yaml
Type: String
Parameter Sets: ParamSet2, ParamSet4
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

### Karamem0.SharePoint.PowerShell.Models.V1.User

## NOTES

## RELATED LINKS

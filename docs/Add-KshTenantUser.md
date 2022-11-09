---
external help file: SPClientCore.dll-help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Add-KshTenantUser

## SYNOPSIS
Creates a new user.

## SYNTAX

### ParamSet1
```
Add-KshTenantUser [-SiteCollection] <TenantSiteCollection> [-Email <String>] -LoginName <String>
 [-Title <String>] [<CommonParameters>]
```

### ParamSet2
```
Add-KshTenantUser [-SiteCollectionUrl] <Uri> [-Email <String>] -LoginName <String> [-Title <String>]
 [<CommonParameters>]
```

## DESCRIPTION
The Add-KshTenantUser cmdlet adds a new user to the specified site collection.
This cmdlet can be used only when connected to the SharePoint admin center.

## EXAMPLES

### Example 1
```powershell
PS C:\> Add-KshTenantUser -SiteCollectionUrl 'https://example.sharepoint.com/sites/japan' -LoginName 'i:0#.f|membership|admin@example.onmicrosoft.com'
```

Creates a new user to the the specified site collection.

## PARAMETERS

### -Email
Specifies the e-mail address.

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
Specifies the login name.

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

### -Title
Specifies the title.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.User

## NOTES

## RELATED LINKS

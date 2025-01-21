---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Add-KshTenantSiteCollection

## SYNOPSIS
Adds a new site collection to the tenant.

## SYNTAX

### ParamSet1
```
Add-KshTenantSiteCollection [-CompatibilityLevel <Int32>] [-Lcid <UInt32>] -Owner <String>
 [-StorageMaxLevel <Int64>] [-StorageWarningLevel <Int64>] [-Template <String>] [-TimeZoneId <Int32>]
 [-Title <String>] -Url <String> [-UserCodeMaxLevel <Double>] [-UserCodeWarningLevel <Double>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet2
```
Add-KshTenantSiteCollection [-CompatibilityLevel <Int32>] [-Lcid <UInt32>] -Owner <String>
 [-StorageMaxLevel <Int64>] [-StorageWarningLevel <Int64>] [-Template <String>] [-TimeZoneId <Int32>]
 [-Title <String>] -Url <String> [-UserCodeMaxLevel <Double>] [-UserCodeWarningLevel <Double>] [-NoWait]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Add-KshTenantSiteCollection` cmdlet adds a new site collection to the tenant with the given parameters.

## EXAMPLES

### Example 1
```powershell
PS C:\> Add-KshTenantSiteCollection -Owner "owner@contoso.com" -Url "https://contoso.sharepoint.com/sites/newsite" -Title "New Site" -Template "STS#0"
```

This example adds a new site collection to the tenant with the specified owner, URL, title, and template.

## PARAMETERS

### -CompatibilityLevel
Specifies the compatibility level of the site collection.

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

### -Lcid
Specifies the locale ID of the site collection.

```yaml
Type: UInt32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Indicates that the cmdlet does not wait for the operation to complete.

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet2
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Owner
Specifies the owner of the site collection.

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

### -StorageMaxLevel
Specifies the maximum storage level for the site collection.

```yaml
Type: Int64
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageWarningLevel
Specifies the storage warning level for the site collection.

```yaml
Type: Int64
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Template
Specifies the template to use for the site collection.

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

### -TimeZoneId
Specifies the time zone ID for the site collection.

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

### -Title
Specifies the title of the site collection.

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

### -Url
Specifies the URL of the site collection.

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

### -UserCodeMaxLevel
Specifies the maximum user code level for the site collection.

```yaml
Type: Double
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserCodeWarningLevel
Specifies the user code warning level for the site collection.

```yaml
Type: Double
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

### Karamem0.SharePoint.PowerShell.Models.V1.TenantSiteCollection
## NOTES

## RELATED LINKS


---
Module Name: SPClientCore
external help file: SPClientCore.dll-Help.xml
schema: 2.0.0
---

# Get-KshTenantUser

## SYNOPSIS
Get tenant user.

## SYNTAX

### ParamSet1
```
Get-KshTenantUser [-SiteCollection] <TenantSiteCollection> [-UserId] <Int32> [-SelectAllProperties]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet2
```
Get-KshTenantUser [-SiteCollection] <TenantSiteCollection> [-UserName] <String> [-SelectAllProperties]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet3
```
Get-KshTenantUser [-SiteCollection] <TenantSiteCollection> [-SelectAllProperties] [-NoEnumerate]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet4
```
Get-KshTenantUser [-SiteCollectionUrl] <Uri> [-UserId] <Int32> [-SelectAllProperties]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet5
```
Get-KshTenantUser [-SiteCollectionUrl] <Uri> [-UserName] <String> [-SelectAllProperties]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet6
```
Get-KshTenantUser [-SiteCollectionUrl] <Uri> [-SelectAllProperties] [-NoEnumerate]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## PARAMETERS

### -NoEnumerate

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

### -SelectAllProperties

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

```yaml
Type: TenantSiteCollection
Parameter Sets: ParamSet1, ParamSet2, ParamSet3
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SiteCollectionUrl

```yaml
Type: Uri
Parameter Sets: ParamSet4, ParamSet5, ParamSet6
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserId

```yaml
Type: Int32
Parameter Sets: ParamSet1, ParamSet4
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserName

```yaml
Type: String
Parameter Sets: ParamSet2, ParamSet5
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction

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

### Karamem0.SharePoint.PowerShell.Models.V1.TenantSiteCollection

## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.User


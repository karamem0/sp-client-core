---
Module Name: SPClientCore
external help file: SPClientCore.dll-Help.xml
schema: 2.0.0
---

# Set-KshTenantUser

## SYNOPSIS
Set tenant user.

## SYNTAX

### ParamSet1
```
Set-KshTenantUser [-SiteCollection] <TenantSiteCollection> [-User] <User> [-IsSiteCollectionAdmin] <Boolean>
 [-PassThru] [-SelectAllProperties] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet2
```
Set-KshTenantUser [-SiteCollection] <TenantSiteCollection> [-UserName] <String>
 [-IsSiteCollectionAdmin] <Boolean> [-PassThru] [-SelectAllProperties] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### ParamSet3
```
Set-KshTenantUser [-SiteCollectionUrl] <Uri> [-User] <User> [-IsSiteCollectionAdmin] <Boolean> [-PassThru]
 [-SelectAllProperties] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet4
```
Set-KshTenantUser [-SiteCollectionUrl] <Uri> [-UserName] <String> [-IsSiteCollectionAdmin] <Boolean>
 [-PassThru] [-SelectAllProperties] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## PARAMETERS

### -IsSiteCollectionAdmin

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
Parameter Sets: ParamSet1, ParamSet2
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SiteCollectionUrl

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

### None

## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.User


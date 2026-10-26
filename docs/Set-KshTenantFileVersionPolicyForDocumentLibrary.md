---
Module Name: SPClientCore
external help file: SPClientCore.dll-Help.xml
schema: 2.0.0
---

# Set-KshTenantFileVersionPolicyForDocumentLibrary

## SYNOPSIS
Set tenant file version policy for document library.

## SYNTAX

### ParamSet1
```
Set-KshTenantFileVersionPolicyForDocumentLibrary [-SiteUrl] <Uri> [-ListId] <Guid>
 [-IsAutoTrimEnabled] <Boolean> [-MajorVersionLimit] <Int32> [-ExpireVersionsAfterDays] <Int32> [-PassThru]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet2
```
Set-KshTenantFileVersionPolicyForDocumentLibrary [-SiteUrl] <Uri> [-ListId] <Guid>
 [-IsAutoTrimEnabled] <Boolean> [-MajorVersionLimit] <Int32> [-ExpireVersionsAfterDays] <Int32> [-NoWait]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet3
```
Set-KshTenantFileVersionPolicyForDocumentLibrary [-SiteUrl] <Uri> [-ListTitle] <String>
 [-IsAutoTrimEnabled] <Boolean> [-MajorVersionLimit] <Int32> [-ExpireVersionsAfterDays] <Int32> [-PassThru]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet4
```
Set-KshTenantFileVersionPolicyForDocumentLibrary [-SiteUrl] <Uri> [-ListTitle] <String>
 [-IsAutoTrimEnabled] <Boolean> [-MajorVersionLimit] <Int32> [-ExpireVersionsAfterDays] <Int32> [-NoWait]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## PARAMETERS

### -ExpireVersionsAfterDays

```yaml
Type: Int32
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsAutoTrimEnabled

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

### -ListId

```yaml
Type: Guid
Parameter Sets: ParamSet1, ParamSet2
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ListTitle

```yaml
Type: String
Parameter Sets: ParamSet3, ParamSet4
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MajorVersionLimit

```yaml
Type: Int32
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet2, ParamSet4
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
Parameter Sets: ParamSet1, ParamSet3
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SiteUrl

```yaml
Type: Uri
Parameter Sets: (All)
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

### None

## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.FileVersionPolicyForDocumentLibrary


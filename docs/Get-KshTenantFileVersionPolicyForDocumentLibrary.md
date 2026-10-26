---
Module Name: SPClientCore
external help file: SPClientCore.dll-Help.xml
schema: 2.0.0
---

# Get-KshTenantFileVersionPolicyForDocumentLibrary

## SYNOPSIS
Get tenant file version policy for document library.

## SYNTAX

### ParamSet1
```
Get-KshTenantFileVersionPolicyForDocumentLibrary [-SiteUrl] <Uri> [-ListId] <Guid>
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet2
```
Get-KshTenantFileVersionPolicyForDocumentLibrary [-SiteUrl] <Uri> [-ListTitle] <String>
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## PARAMETERS

### -ListId

```yaml
Type: Guid
Parameter Sets: ParamSet1
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
Parameter Sets: ParamSet2
Aliases:

Required: True
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


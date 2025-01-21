---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Get-KshTenantFileVersionPolicyForDocumentLibrary

## SYNOPSIS
Retrieves the file version policy for a document library.

## SYNTAX

### ParamSet1
```
Get-KshTenantFileVersionPolicyForDocumentLibrary -SiteUrl <Uri> -ListId <Guid>
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet2
```
Get-KshTenantFileVersionPolicyForDocumentLibrary -SiteUrl <Uri> -ListTitle <String>
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Get-KshTenantFileVersionPolicyForDocumentLibrary` cmdlet retrieves the file version policy for a document library based on the specified parameters.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-KshTenantFileVersionPolicyForDocumentLibrary -SiteUrl "https://contoso.sharepoint.com" -ListId "12345678-1234-1234-1234-1234567890ab"
```

This example retrieves the file version policy for the document library with the specified ListId at the specified site URL.

### Example 2
```powershell
PS C:\> Get-KshTenantFileVersionPolicyForDocumentLibrary -SiteUrl "https://contoso.sharepoint.com" -ListTitle "Documents"
```

This example retrieves the file version policy for the document library named "Documents" at the specified site URL.

## PARAMETERS

### -ListId
Specifies the ID of the document library.

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
Specifies the title of the document library.

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
Specifies the URL of the site that contains the document library.

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

### Karamem0.SharePoint.PowerShell.Models.V1.FileVersionPolicyForDocumentLibrary

## NOTES

## RELATED LINKS


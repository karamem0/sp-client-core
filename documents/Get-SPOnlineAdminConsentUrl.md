---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Get-SPOnlineAdminConsentUrl

## SYNOPSIS
Gets the admin consent URL.

## SYNTAX

```
Get-SPOnlineAdminConsentUrl -Url <Uri> [-Authority <Uri>] [-ClientId <Guid>] [<CommonParameters>]
```

## DESCRIPTION
The Add-SPOnlineAdminConsentUrl cmdlet retrieves the admin consent URL.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-SPOnlineAdminConsentUrl -Url 'https://example.sharepoint.com'
```

Gets the admin consent URL.

## PARAMETERS

### -Authority
Indicates the authorization endpoint URL. This parameter is provided for some environment. (Germany, China, and US Government)

```yaml
Type: Uri
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClientId
Indicates the app ID if a user wants to connect through his/her organization app.

```yaml
Type: Guid
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Url
Indicates the site URL.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable.
For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### System.String

## NOTES

## RELATED LINKS

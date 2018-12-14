---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Connect-KshSite

## SYNOPSIS
Connects to a site.

## SYNTAX

### ParamSet1
```
Connect-KshSite [-Url] <Uri> [-Authority <Uri>] [<CommonParameters>]
```

### ParamSet2
```
Connect-KshSite [-Url] <Uri> -Credential <PSCredential> [-Authority <Uri>] [<CommonParameters>]
```

## DESCRIPTION
The Connect-KshSite cmdlet creates new connection to a site.

## EXAMPLES

### Example 1
```powershell
PS C:\> Connect-KshSite -Url 'https://example.sharepoint.com'
```

Connects to a site with device code.

### Example 2
```powershell
PS C:\> Connect-KshSite -Url 'https://example.sharepoint.com' -Credentials (Get-Credential)
```

Connects to a site with user name and password.

## PARAMETERS

### -Authority
Specifies the authorization endpoint URL. This parameter is provided for some environment. (Germany, China, and US Government)

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

### -Credential
Specifies the credentials (user name and password) of Office 365.

```yaml
Type: PSCredential
Parameter Sets: ParamSet2
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Url
Specifies the site URL.

```yaml
Type: Uri
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.Uri

## OUTPUTS

### System.Void

## NOTES

## RELATED LINKS

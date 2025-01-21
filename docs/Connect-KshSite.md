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
Connect-KshSite [-Url] <Uri> [-ClientId <String>] [-Authority <Uri>] [-UserMode]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet2
```
Connect-KshSite [-Url] <Uri> -Credential <PSCredential> [-ClientId <String>] [-Authority <Uri>] [-UserMode]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet3
```
Connect-KshSite [-Url] <Uri> -ClientId <String> [-Authority <Uri>] -CertificatePath <String>
 -CertificatePassword <SecureString> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet4
```
Connect-KshSite [-Url] <Uri> [-ClientId <String>] [-Authority <Uri>] [-Cached]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet5
```
Connect-KshSite [-Url] <Uri> -ClientId <String> -ClientSecret <String> [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

## DESCRIPTION
The `Connect-KshSite` cmdlet connects to a site with device code, client ID and certificate, or from cache.

## EXAMPLES

### Example 1
```powershell
PS C:\> Connect-KshSite -Url "https://consoto.sharepoint.com"
```

This example connects to the site at "https://consoto.sharepoint.com" using device code.

### Example 2
```powershell
PS C:\> Connect-KshSite -Url "https://consoto.sharepoint.com" -Credential $credential
```

This example connects to the site at "https://consoto.sharepoint.com" using user ID and password. This method is not recommended.

### Example 3
```powershell
PS C:\> Connect-KshSite -Url "https://consoto.sharepoint.com" -ClientId "12345678-1234-1234-1234-1234567890ab" -CertificatePath "path/to/certificate.pfx" -CertificatePassword $password
```

This example connects to the site at "https://consoto.sharepoint.com" using a client ID and a certificate.

### Example 4
```powershell
PS C:\> Connect-KshSite -Url "https://consoto.sharepoint.com" -ClientId "12345678-1234-1234-1234-1234567890ab" -ClientSecret "MTIz..."
```

This example connects to the site at "https://consoto.sharepoint.com" using a client ID and client secret. This method is not recommended.

### Example 5
```powershell
PS C:\> Connect-KshSite -Url "https://consoto.sharepoint.com" -Cached
```

This example connects to the site at "https://consoto.sharepoint.com" using cached credentials.

## PARAMETERS

### -Authority
Specifies the authority URI to use for authentication.

```yaml
Type: Uri
Parameter Sets: ParamSet1, ParamSet2, ParamSet3, ParamSet4
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Cached
Indicates that cached credentials should be used.

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet4
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CertificatePassword
Specifies the password for the certificate file.

```yaml
Type: SecureString
Parameter Sets: ParamSet3
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CertificatePath
Specifies the path to the certificate file.

```yaml
Type: String
Parameter Sets: ParamSet3
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClientId
Specifies the client ID to use for authentication.

```yaml
Type: String
Parameter Sets: ParamSet1, ParamSet2, ParamSet4
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: String
Parameter Sets: ParamSet3, ParamSet5
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClientSecret
Specifies the client secret to use for authentication.

```yaml
Type: String
Parameter Sets: ParamSet5
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Credential
Specifies the user credentials to use for authentication.

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
Specifies the URL of the site to connect to.

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

### -UserMode
Indicates that user mode should be used for authentication.

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet1, ParamSet2
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

### System.Uri
## OUTPUTS

### System.Void
## NOTES

## RELATED LINKS


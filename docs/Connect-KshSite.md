---
Module Name: SPClientCore
external help file: SPClientCore.dll-Help.xml
schema: 2.0.0
---

# Connect-KshSite

## SYNOPSIS
Connect to site.

## SYNTAX

### ParamSet1
```
Connect-KshSite [-Url] <Uri> [-ClientId] <String> [[-Authority] <Uri>] [-UserMode]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet2
```
Connect-KshSite [-Url] <Uri> [-ClientId] <String> [[-Authority] <Uri>] [-Certificate] <Byte[]>
 [-CertificatePassword] <SecureString> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet3
```
Connect-KshSite [-Url] <Uri> [-ClientId] <String> [[-Authority] <Uri>] [-Certificate] <Byte[]>
 [-PrivateKey] <Byte[]> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet4
```
Connect-KshSite [-Url] <Uri> [-ClientId] <String> [[-Authority] <Uri>] [-CertificatePath] <String>
 [-CertificatePassword] <SecureString> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet5
```
Connect-KshSite [-Url] <Uri> [-ClientId] <String> [[-Authority] <Uri>] [-CertificatePath] <String>
 [-PrivateKeyPath] <String> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet6
```
Connect-KshSite [-Url] <Uri> [[-Authority] <Uri>] [-Cached] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### ParamSet7
```
Connect-KshSite [-Url] <Uri> [-ClientId] <String> [-ClientSecret] <SecureString>
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## PARAMETERS

### -Authority

```yaml
Type: Uri
Parameter Sets: ParamSet1, ParamSet2, ParamSet3, ParamSet4, ParamSet5, ParamSet6
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Cached

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet6
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Certificate

```yaml
Type: Byte[]
Parameter Sets: ParamSet2, ParamSet3
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CertificatePassword

```yaml
Type: SecureString
Parameter Sets: ParamSet2, ParamSet4
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CertificatePath

```yaml
Type: String
Parameter Sets: ParamSet4, ParamSet5
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClientId

```yaml
Type: String
Parameter Sets: ParamSet1, ParamSet2, ParamSet3, ParamSet4, ParamSet5, ParamSet7
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClientSecret

```yaml
Type: SecureString
Parameter Sets: ParamSet7
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrivateKey

```yaml
Type: Byte[]
Parameter Sets: ParamSet3
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrivateKeyPath

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

### -Url

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

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet1
Aliases:

Required: False
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

### System.Uri

## OUTPUTS

### System.Void


---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Connect-KshSite

## SYNOPSIS
{{ Fill in the Synopsis }}

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
{{ Fill in the Description }}

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -Authority
{{ Fill Authority Description }}

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
{{ Fill Cached Description }}

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
{{ Fill CertificatePassword Description }}

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
{{ Fill CertificatePath Description }}

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
{{ Fill ClientId Description }}

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
{{ Fill ClientSecret Description }}

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
{{ Fill Credential Description }}

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
{{ Fill Url Description }}

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
{{ Fill UserMode Description }}

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
{{ Fill ProgressAction Description }}

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


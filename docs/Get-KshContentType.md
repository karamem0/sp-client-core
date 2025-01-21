---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Get-KshContentType

## SYNOPSIS
Retrieves one or more content types from a list or site.

## SYNTAX

### ParamSet1
```
Get-KshContentType [-Identity] <ContentType> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet2
```
Get-KshContentType [-List] <List> [-ContentTypeId] <String> [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### ParamSet3
```
Get-KshContentType [-List] <List> [-NoEnumerate] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet4
```
Get-KshContentType [-ContentTypeId] <String> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet5
```
Get-KshContentType [-NoEnumerate] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Get-KshContentType` cmdlet retrieves one or more content types from a list or site based on the specified parameters.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-KshContentType -Identity "0x0101009189AB5D3D2647B580F011DA2F356FB2"
```

This example retrieves a content type by identity.

### Example 2
```powershell
PS C:\> Get-KshContentType -List $list -ContentTypeId "0x0101009189AB5D3D2647B580F011DA2F356FB2"
```

This example retrieves a list content type by content type ID.

### Example 3
```powershell
PS C:\> Get-KshContentType -List $list
```

This example retrieves all list content types from.

### Example 4
```powershell
PS C:\> Get-KshContentType -ContentTypeId "0x0101009189AB5D3D2647B580F011DA2F356FB2"
```

This example retrieves a site content type by content type ID.

### Example 5
```powershell
PS C:\> Get-KshContentType
```

This example retrieves all site content types.

## PARAMETERS

### -ContentTypeId
Specifies the ID of the content type to retrieve.

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

### -Identity
Specifies the content type to retrieve.

```yaml
Type: ContentType
Parameter Sets: ParamSet1
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -List
Specifies the list from which to retrieve the content type.

```yaml
Type: List
Parameter Sets: ParamSet2, ParamSet3
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoEnumerate
Indicates that the cmdlet does not enumerate the content types.

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet3, ParamSet5
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

### Karamem0.SharePoint.PowerShell.Models.V1.ContentType
## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.ContentType
## NOTES

## RELATED LINKS


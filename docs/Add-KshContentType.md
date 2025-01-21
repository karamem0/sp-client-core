---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Add-KshContentType

## SYNOPSIS
Adds a new content type to a list or library.

## SYNTAX

### ParamSet1
```
Add-KshContentType -List <List> -ContentType <ContentType> [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### ParamSet2
```
Add-KshContentType -List <List> [-ContentType <ContentType>] [-Description <String>] [-Group <String>]
 -Name <String> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet3
```
Add-KshContentType [-ContentType <ContentType>] [-Description <String>] [-Group <String>] -Name <String>
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
This cmdlet adds a new content type to a list or library. You can specify the content type by name or by using an existing content type object.

## EXAMPLES

### Example 1
```powershell
PS C:\> Add-KshContentType -List $list -ContentType $contentType
```

This example adds the existing site content type to the specified list.

### Example 2
```powershell
PS C:\> Add-KshContentType -List $list -Name "CustomContentType" -Description "A custom content type" -Group "CustomGroup"
```

This example creates a new content type named "CustomContentType" with a description and group, and adds it to the specified list.

### Example 3
```powershell
PS C:\> Add-KshContentType -Name "CustomContentType" -Description "A custom content type" -Group "CustomGroup"
```

This example creates a new content type named "CustomContentType" with a description and group, and adds it as a site content type.

## PARAMETERS

### -ContentType
Specifies the content type to add.

```yaml
Type: ContentType
Parameter Sets: ParamSet1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: ContentType
Parameter Sets: ParamSet2, ParamSet3
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Description
Specifies the description of the content type.

```yaml
Type: String
Parameter Sets: ParamSet2, ParamSet3
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Group
Specifies the group of the content type.

```yaml
Type: String
Parameter Sets: ParamSet2, ParamSet3
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -List
Specifies the list or library to which the content type is added.

```yaml
Type: List
Parameter Sets: ParamSet1, ParamSet2
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Specifies the name of the content type.

```yaml
Type: String
Parameter Sets: ParamSet2, ParamSet3
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

### Karamem0.SharePoint.PowerShell.Models.V1.ContentType
## NOTES

## RELATED LINKS


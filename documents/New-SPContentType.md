---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# New-SPContentType

## SYNOPSIS
Creates a new content type.

## SYNTAX

### Web (Default)
```
New-SPContentType [-Description <String>] [-DisplayFormUrl <String>] [-EditFormUrl <String>] [-Group <String>]
 [-Hidden <Boolean>] [-JSLink <String>] [-MobileDisplayFormUrl <String>] [-MobileEditFormUrl <String>]
 [-MobileNewFormUrl <String>] [-Name <String>] [-NewFormUrl <String>] [-Includes <String[]>]
 [<CommonParameters>]
```

### List
```
New-SPContentType [-List] <ListPipeBind> [-Description <String>] [-DisplayFormUrl <String>]
 [-EditFormUrl <String>] [-Group <String>] [-Hidden <Boolean>] [-JSLink <String>]
 [-MobileDisplayFormUrl <String>] [-MobileEditFormUrl <String>] [-MobileNewFormUrl <String>] [-Name <String>]
 [-NewFormUrl <String>] [-Includes <String[]>] [<CommonParameters>]
```

## DESCRIPTION
The New-SPWeb cmdlet adds a new content type to a site or list.

## EXAMPLES

### Example 1
```
PS C:\> New-SPContentType -Name 'My Content Type'
```

Creates a new content type to a site.

### Example 2
```
PS C:\> New-SPContentType -List 'Shared Documents' -Name 'My Content Type'
```

Creates a new content type to a list.

## PARAMETERS

### -Description
Indicates the description.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DisplayFormUrl
Indicates the URL of a custom display form.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EditFormUrl
Indicates the URL of a custom edit form.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Group
Indicates the group.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Hidden
Indicates the value whether to hide from user.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Includes
Indicates the property name collection to include in the result object.

```yaml
Type: String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JSLink
Indicates the JSLink URL.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -List
Indicates the list ID or title.

```yaml
Type: ListPipeBind
Parameter Sets: List
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MobileDisplayFormUrl
Indicates the URL of a custom display form for mobile.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MobileEditFormUrl
Indicates the URL of a custom edit form for mobile.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MobileNewFormUrl
Indicates the URL of a custom new form for mobile.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Indicates the name.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NewFormUrl
Indicates the URL of a custom new form.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
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

### Karamem0.SharePoint.PowerShell.Models.Core.ContentType
## NOTES

## RELATED LINKS

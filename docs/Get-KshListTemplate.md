---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Get-KshListTemplate

## SYNOPSIS
Retrieves one or more list templates from the current site.

## SYNTAX

### ParamSet1
```
Get-KshListTemplate [-Identity] <ListTemplate> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet2
```
Get-KshListTemplate [-ListTemplateTitle] <String> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet3
```
Get-KshListTemplate [-NoEnumerate] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Get-KshListTemplate` cmdlet retrieves one or more list templates from the current site based on the specified parameters.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-KshListTemplate -Identity $listTemplate
```

This example retrieves a list template by identity.

### Example 2
```powershell
PS C:\> Get-KshListTemplate -ListTemplateTitle "Custom List"
```

This example retrieves a list template by list template title.

### Example 3
```powershell
PS C:\> Get-KshListTemplate
```

This example retrieves all list templates.

## PARAMETERS

### -Identity
Specifies the list template to retrieve.

```yaml
Type: ListTemplate
Parameter Sets: ParamSet1
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ListTemplateTitle
Specifies the title of the list template to retrieve.

```yaml
Type: String
Parameter Sets: ParamSet2
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoEnumerate
Indicates that the cmdlet does not enumerate the list templates.

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet3
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

### Karamem0.SharePoint.PowerShell.Models.V1.ListTemplate
## OUTPUTS

### Karamem0.SharePoint.PowerShell.Models.V1.ListTemplate
## NOTES

## RELATED LINKS


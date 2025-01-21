---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Get-KshTenantSiteScriptFromList

## SYNOPSIS
Retrieves a site script from a list.

## SYNTAX

```
Get-KshTenantSiteScriptFromList [-ListUrl] <String> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The `Get-KshTenantSiteScriptFromList` cmdlet retrieves a site script from a list.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-KshTenantSiteScriptFromList -ListUrl "https://contoso.sharepoint.com/sites/sitecollection/Shared Documents"
```

This example retrieves the site script by list URL.

## PARAMETERS

### -ListUrl
Specifies the URL of the list from which to retrieve the tenant site script.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
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

### System.String
## NOTES

## RELATED LINKS


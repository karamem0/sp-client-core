---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Add-KshSitePage

## SYNOPSIS
Creates a new site page.

## SYNTAX

### ParamSet1
```
Add-KshSitePage [-List] <List> -PageName <String> [-PageLayoutType <SitePageLayoutType>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ParamSet2
```
Add-KshSitePage -PageName <String> [-PageLayoutType <SitePageLayoutType>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

## DESCRIPTION
The `Add-KshSitePage` cmdlet creates a new site page with the name and layout type.

## EXAMPLES

### Example 1
```powershell
PS C:\> Add-KshSitePage -List $list -PageName "HomePage" -PageLayoutType "Home"
```

This example creates a new site page named "HomePage" in the specified list with the layout type set to "Home".

### Example 2
```powershell
PS C:\> Add-KshSitePage -PageName "AboutUs" -PageLayoutType "Article"
```

This example creates a new site page in the default list named "AboutUs" with the layout type set to "Article".

## PARAMETERS

### -List
Specifies the list where the site page will be created.

```yaml
Type: List
Parameter Sets: ParamSet1
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PageLayoutType
Specifies the layout type of the site page.

```yaml
Type: SitePageLayoutType
Parameter Sets: (All)
Aliases:
Accepted values: Article, Home, SingleWebPartAppPage, RepostPage, HeaderlessSearchResults, Spaces

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PageName
Specifies the name of the site page.

```yaml
Type: String
Parameter Sets: (All)
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

### System.Void
## NOTES

## RELATED LINKS


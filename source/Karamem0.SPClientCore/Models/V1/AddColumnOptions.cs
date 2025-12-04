//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

namespace Karamem0.SharePoint.PowerShell.Models.V1;

[Flags()]
public enum AddColumnOptions
{

    DefaultValue = 0,

    AddToDefaultContentType = 1,

    AddToNoContentType = 2,

    AddToAllContentTypes = 4,

    AddColumnInternalNameHint = 8,

    AddColumnToDefaultView = 16,

    AddColumnCheckDisplayName = 32,

}

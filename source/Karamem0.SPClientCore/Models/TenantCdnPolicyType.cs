//
// Copyright (c) 2021 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Models
{

    public enum TenantCdnPolicyType
    {

        IncludeFileExtensions = 0,

        ExcludeRestrictedSiteClassifications = 1,

        ExcludeIfNoScriptDisabled = 2,

    }

}

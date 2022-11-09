//
// Copyright (c) 2022 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Models.V1
{

    [Flags()]
    public enum PrincipalType
    {

        None = 0,

        User = 1,

        DistributionList = 2,

        SecurityGroup = 4,

        SharePointGroup = 8,

        All = 15,

    }

}

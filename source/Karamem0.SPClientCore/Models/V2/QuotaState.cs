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

namespace Karamem0.SharePoint.PowerShell.Models.V2
{

    public enum QuotaState
    {

        None = 0,

        Normal = 1,

        Nearing = 2,

        Critical = 3,

        Exceeded = 4,

    }

}

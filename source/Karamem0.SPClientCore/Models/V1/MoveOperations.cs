//
// Copyright (c) 2023 karamem0
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
    public enum MoveOperations
    {

        None = 0,

        Overwrite = 1,

        AllowBrokenThickets = 8,

        BypassApprovePermission = 64,

    }

}

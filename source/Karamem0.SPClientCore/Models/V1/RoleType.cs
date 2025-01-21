//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Models.V1;

public enum RoleType
{

    None = 0,

    View = 1,

    Edit = 2,

    Owner = 3,

    LimitedView = 4,

    LimitedEdit = 5,

    Review = 6,

    RestrictedView = 7,

    Submit = 8,

    ManageList = 9,

}

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

[Flags()]
public enum PrincipalSource
{

    None = 0,

    UserInfoList = 1,

    Windows = 2,

    MembershipProvider = 4,

    RoleProvider = 8,

    All = 15,

}

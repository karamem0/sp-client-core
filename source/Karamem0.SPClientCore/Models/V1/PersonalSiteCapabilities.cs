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
public enum PersonalSiteCapabilities
{

    None = 0,

    Profile = 1,

    Social = 2,

    Storage = 4,

    MyTasksDashboard = 8,

    Education = 16,

    Guest = 32,

}

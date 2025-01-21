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

public enum AppStatus
{

    InvalidStatus = 0,

    Installing = 1,

    Uninstalling = 4,

    Installed = 5,

    Canceling = 7,

    Upgrading = 8,

    Initialized = 9,

    UpgradeCanceling = 10,

    Disabling = 11,

    Disabled = 12,

    SecretRolling = 13,

    Recycling = 14,

    Recycled = 15,

    Restoring = 16,

    RestoreCanceling = 17

}

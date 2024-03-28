//
// Copyright (c) 2018-2024 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Runtime.Services;

public static class ClientConstants
{

    public const string UserAgent = "NONISV|karamem0|SPClientCore";

    public const int MaxRetryCount = 3;

    public const int TenantServiceWaitSeconds = 10;

    public const int TermLabelServiceWaitSeconds = 1;

    public const int ChunkSize = 10 * 1024 * 1024;

    public const int PageSize = 25;

}

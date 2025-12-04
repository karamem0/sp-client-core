//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

namespace Karamem0.SharePoint.PowerShell.Runtime.Services;

public static class ClientConstants
{

    public const string UserAgent = "NONISV|karamem0|SPClientCore";

    public const int MaxRetryCount = 3;

    public const int WaitIntervalForTenantService = 10;

    public const int WaitIntervalForTermLabelService = 1;

    public const int ChunkSize = 10 * 1024 * 1024;

    public const int PageSize = 25;

}

//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

namespace Karamem0.SharePoint.PowerShell.Runtime.OAuth;

public abstract class OAuthTokenProvider
{

    public abstract string? CurrentAceessToken { get; }

    public abstract string? GetAccessToken();

}

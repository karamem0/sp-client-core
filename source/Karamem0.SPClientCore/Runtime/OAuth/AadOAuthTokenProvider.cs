//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Resources;
using Microsoft.IdentityModel.JsonWebTokens;

namespace Karamem0.SharePoint.PowerShell.Runtime.OAuth;

public class AadOAuthTokenProvider(
    Uri uri,
    AadOAuthContext oAuthContext,
    AadOAuthToken oAuthToken
) : OAuthTokenProvider
{

    private readonly Uri uri = uri;

    private readonly AadOAuthContext oAuthContext = oAuthContext;

    private AadOAuthToken oAuthToken = oAuthToken;

    public override string? CurrentAceessToken => this.oAuthToken.AccessToken;

    public override string? GetAccessToken()
    {
        var jwtToken = new JsonWebToken(this.oAuthToken.AccessToken);
        var jwtExpireIn = jwtToken.GetPayloadValue<double>("exp");
        var jwtExpireOn = DateTime.UnixEpoch.AddSeconds(jwtExpireIn);
        if (jwtExpireOn <= DateTime.UtcNow)
        {
            if (this.oAuthToken.RefreshToken is null)
            {
                throw new InvalidOperationException(StringResources.ErrorAccessTokenExpired);
            }
            var oAuthMessage = this.oAuthContext.AcquireTokenByRefreshToken(this.oAuthToken.RefreshToken);
            if (oAuthMessage is AadOAuthToken oAuthToken)
            {
                this.oAuthToken = oAuthToken;
                AadOAuthTokenStore.Add(this.uri, oAuthToken);
            }
            if (oAuthMessage is OAuthError oAuthError)
            {
                throw new InvalidOperationException(oAuthError.ErrorDescription);
            }
        }
        return this.oAuthToken.AccessToken;
    }

}

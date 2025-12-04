//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Microsoft.IdentityModel.JsonWebTokens;

namespace Karamem0.SharePoint.PowerShell.Runtime.OAuth;

public class AcsOAuthTokenProvider(AcsOAuthContext oAuthContext, AcsOAuthToken oAuthToken) : OAuthTokenProvider
{

    private readonly AcsOAuthContext oAuthContext = oAuthContext;

    private AcsOAuthToken oAuthToken = oAuthToken;

    public override string? CurrentAceessToken => this.oAuthToken.AccessToken;

    public override string? GetAccessToken()
    {
        var jwtToken = new JsonWebToken(this.oAuthToken.AccessToken);
        var jwtExpireIn = jwtToken.GetPayloadValue<double>("exp");
        var jwtExpireOn = DateTime.UnixEpoch.AddSeconds(jwtExpireIn);
        if (jwtExpireOn <= DateTime.UtcNow)
        {
            var oAuthMessage = this.oAuthContext.AcquireToken();
            if (oAuthMessage is AcsOAuthToken oAuthToken)
            {
                this.oAuthToken = oAuthToken;
            }
            if (oAuthMessage is OAuthError oAuthError)
            {
                throw new InvalidOperationException(oAuthError.ErrorDescription);
            }
        }
        return this.oAuthToken.AccessToken;
    }

}

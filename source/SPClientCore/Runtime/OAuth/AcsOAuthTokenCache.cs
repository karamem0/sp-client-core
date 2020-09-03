//
// Copyright (c) 2020 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Resources;
using Microsoft.IdentityModel.JsonWebTokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Runtime.OAuth
{

    public class AcsOAuthTokenCache : OAuthTokenCache
    {

        private AcsOAuthContext oAuthContext;

        private AcsOAuthToken oAuthToken;

        public AcsOAuthTokenCache(AcsOAuthContext oAuthContext, AcsOAuthToken oAuthToken)
        {
            if (oAuthContext == null)
            {
                throw new ArgumentNullException(nameof(oAuthContext));
            }
            if (oAuthToken == null)
            {
                throw new ArgumentNullException(nameof(oAuthToken));
            }
            this.oAuthContext = oAuthContext;
            this.oAuthToken = oAuthToken;
        }

        public override string GetAccessToken() 
        {
            var jwtToken = new JsonWebToken(this.oAuthToken.AccessToken);
            var expireIn = jwtToken.GetPayloadValue<double>("exp");
            var expireOn = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(expireIn);
            if (expireOn <= DateTime.UtcNow)
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

}

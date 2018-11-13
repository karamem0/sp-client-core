//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Services.OAuth;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Services
{

    public class BearerClientContext : ClientContext
    {

        private OAuthContext oAuthContext;

        private OAuthToken oAuthToken;

        private HttpClient httpClient;

        public BearerClientContext(Uri baseAddress, OAuthContext oAuthContext, OAuthToken oAuthToken) : base(baseAddress)
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

        protected override HttpClient HttpClient
        {
            get
            {
                if (this.httpClient == null)
                {
                    this.httpClient = new HttpClient();
                }
                return this.httpClient;
            }
        }

        protected override HttpRequestMessage CreateHttpRequestMessage(HttpMethod httpMethod, Uri requestUrl)
        {
            var requestMessage = new HttpRequestMessage(httpMethod, requestUrl);
            var jwtToken = new JwtSecurityToken(this.oAuthToken.AccessToken);
            var expireIn = (double)jwtToken.Payload.Exp;
            var expireOn = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(expireIn);
            if (expireOn <= DateTime.UtcNow)
            {
                var oAuthMessage = this.oAuthContext.AcquireTokenByRefreshToken(this.oAuthToken.RefreshToken);
                if (oAuthMessage is OAuthToken oAuthToken)
                {
                    this.oAuthToken = oAuthToken;
                }
                if (oAuthMessage is OAuthError oAuthError)
                {
                    throw new InvalidOperationException(oAuthError.ErrorDescription);
                }
            }
            requestMessage.Headers.Add("Authorization", "Bearer " + this.oAuthToken.AccessToken);
            requestMessage.Headers.Add("Accept", "application/json;odata=verbose");
            requestMessage.Headers.Add("User-Agent", "NONISV|karamem0|SPClientCore/" + this.GetType().Assembly.GetName().Version.ToString(3));
            return requestMessage;
        }

    }

}

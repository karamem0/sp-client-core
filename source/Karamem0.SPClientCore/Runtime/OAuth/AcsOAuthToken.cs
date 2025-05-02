//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Runtime.OAuth;

[JsonObject()]
public class AcsOAuthToken : OAuthMessage
{

    [JsonProperty("token_type")]
    public virtual string? TokenType { get; protected set; }

    [JsonProperty("expires_in")]
    public virtual int ExpiresIn { get; protected set; }

    [JsonProperty("not_before")]
    public virtual int NotBefore { get; protected set; }

    [JsonProperty("expires_on")]
    public virtual int ExpiresOn { get; protected set; }

    [JsonProperty("resource")]
    public virtual string? Resource { get; protected set; }

    [JsonProperty("access_token")]
    public virtual string? AccessToken { get; protected set; }

}

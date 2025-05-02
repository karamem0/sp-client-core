//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Models.V1;

[JsonObject()]
public class Subscription : ODataV1Object
{

    [JsonProperty("clientState")]
    public virtual string? ClientState { get; set; }

    [JsonProperty("expirationDateTime")]
    public virtual DateTime ExpirationDateTime { get; set; }

    [JsonProperty("id")]
    public virtual Guid Id { get; set; }

    [JsonProperty("notificationUrl")]
    public virtual string? NotificationUrl { get; set; }

    [JsonProperty("resource")]
    public virtual Guid Resource { get; set; }

    [JsonProperty("resourceData")]
    public virtual string? ResourceData { get; set; }

}

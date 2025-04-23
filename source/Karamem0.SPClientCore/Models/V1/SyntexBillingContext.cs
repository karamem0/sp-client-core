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

[ClientObject(Name = "Microsoft.Online.SharePoint.TenantAdministration.SyntexBillingContext", Id = "{37e70ec1-6ec1-4317-a5a7-19c21b03fca5}")]
[JsonObject()]
public class SyntexBillingContext : ClientObject
{

    [JsonProperty()]
    public virtual SyntexConsumptionBillingActivationStatus ActivationStatus { get; protected set; }

    [JsonProperty()]
    public virtual string AzureResourceId { get; protected set; }

    [JsonProperty()]
    public virtual AzureSubscriptionState AzureSubscriptionState { get; protected set; }

    [JsonProperty()]
    public virtual SyntexConsumptionBillingEnabledFeatures EnabledFeatures { get; protected set; }

    [JsonProperty()]
    public virtual string Location { get; protected set; }

    [JsonProperty()]
    public virtual DateTime Updated { get; protected set; }

}

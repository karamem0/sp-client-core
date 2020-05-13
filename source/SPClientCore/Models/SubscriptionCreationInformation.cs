//
// Copyright (c) 2020 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Models
{

    [JsonObject()]
    [ODataObject(Name = "Microsoft.SharePoint.Webhooks.Subscription")]
    public class SubscriptionCreationInformation : ODataObject
    {

        public SubscriptionCreationInformation()
        {
        }

        [JsonProperty("clientState")]
        public virtual string ClientState { get; protected set; }

        [JsonProperty("expirationDateTime")]
        public virtual DateTime ExpirationDateTime { get; protected set; }

        [JsonProperty("notificationUrl")]
        public virtual string NotificationUrl { get; protected set; }

        [JsonProperty("resource")]
        public virtual string Resource { get; protected set; }

    }

}

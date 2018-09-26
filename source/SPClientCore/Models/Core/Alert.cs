//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Models.Core
{

    [JsonObject(Id = "SP.Alert")]
    public class Alert : ClientObject
    {

        public Alert()
        {
        }

        [JsonProperty()]
        public AlertFrequency? AlertFrequency { get; private set; }

        [JsonProperty()]
        public string AlertTemplateName { get; private set; }

        [JsonProperty()]
        public AlertType? AlertType { get; private set; }

        [JsonProperty()]
        public bool? AlwaysNotify { get; private set; }

        [JsonProperty()]
        public AlertDeliveryChannel? DeliveryChannels { get; private set; }

        [JsonProperty()]
        public AlertEventType? EventType { get; private set; }

        [JsonProperty()]
        public string Filter { get; private set; }

        [JsonProperty()]
        public Guid? Id { get; private set; }

        [JsonProperty()]
        public ListItem Item { get; private set; }

        [JsonProperty()]
        public List List { get; private set; }

        [JsonProperty()]
        public ClientObjectCollection<KeyValue> Properties { get; private set; }

        [JsonProperty()]
        public AlertStatus? Status { get; private set; }

        [JsonProperty()]
        public string Title { get; private set; }

        [JsonProperty()]
        public User User { get; private set; }

        [JsonProperty()]
        public int? UserId { get; private set; }

    }

}

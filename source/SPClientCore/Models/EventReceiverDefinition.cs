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

namespace Karamem0.SharePoint.PowerShell.Models
{

    [JsonObject(Id = "SP.EventReceiverDefinition")]
    public class EventReceiverDefinition : ClientObject
    {

        public EventReceiverDefinition()
        {
        }

        [JsonProperty()]
        public EventReceiverType? EventType { get; private set; }

        [JsonProperty()]
        public string ReceiverAssembly { get; private set; }

        [JsonProperty()]
        public string ReceiverClass { get; private set; }

        [JsonProperty()]
        public string ReceiverId { get; private set; }

        [JsonProperty()]
        public string ReceiverName { get; private set; }

        [JsonProperty()]
        public string ReceiverUrl { get; private set; }

        [JsonProperty()]
        public int? SequenceNumber { get; private set; }

        [JsonProperty()]
        public EventReceiverSynchronization? Synchronization { get; private set; }

    }

}

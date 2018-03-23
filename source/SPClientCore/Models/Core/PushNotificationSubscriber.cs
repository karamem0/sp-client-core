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

    [JsonObject(Id = "SP.PushNotificationSubscriber")]
    public class PushNotificationSubscriber : ClientObject
    {

        public PushNotificationSubscriber()
        {
        }

        [JsonProperty()]
        public string CustomArgs { get; private set; }

        [JsonProperty()]
        public string DeviceAppInstanceId { get; private set; }

        [JsonProperty()]
        public DateTime? LastModifiedTimeStamp { get; private set; }

        [JsonProperty()]
        public DateTime? RegistrationTimeStamp { get; private set; }

        [JsonProperty()]
        public string ServiceToken { get; private set; }

        [JsonProperty()]
        public string SubscriberType { get; private set; }

        [JsonProperty()]
        public User User { get; private set; }

    }

}

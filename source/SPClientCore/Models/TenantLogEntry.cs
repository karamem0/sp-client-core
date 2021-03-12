//
// Copyright (c) 2021 karamem0
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
    [ClientObject(Name = "Microsoft.Online.SharePoint.TenantAdministration.TenantLogEntry", Id = "{c13e16f4-3f73-48c7-9f72-c9c5b49f2694}")]
    public class TenantLogEntry : ClientObject
    {

        public TenantLogEntry()
        {
        }

        [JsonProperty()]
        public virtual int CategoryId { get; protected set; }

        [JsonProperty()]
        public virtual Guid CorrelationId { get; protected set; }

        [JsonProperty()]
        public virtual string Message { get; protected set; }

        [JsonProperty()]
        public virtual int Source { get; protected set; }

        [JsonProperty("TimestampUtc")]
        public virtual DateTime Timestamp { get; protected set; }

        [JsonProperty()]
        public virtual string User { get; protected set; }

    }

}

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

    [JsonObject(Id = "SP.AppInstance")]
    public class AppInstance : ClientObject
    {

        public AppInstance()
        {
        }

        [JsonProperty()]
        public string AppPrincipalId { get; private set; }

        [JsonProperty()]
        public string AppWebFullUrl { get; private set; }

        [JsonProperty()]
        public Guid? Id { get; private set; }

        [JsonProperty()]
        public bool? InError { get; private set; }

        [JsonProperty()]
        public Guid? ProductId { get; private set; }

        [JsonProperty()]
        public string RemoteAppUrl { get; private set; }

        [JsonProperty()]
        public string SettingsPageUrl { get; private set; }

        [JsonProperty()]
        public Guid? SiteId { get; private set; }

        [JsonProperty()]
        public string StartPage { get; private set; }

        [JsonProperty()]
        public AppInstanceStatus? Status { get; private set; }

        [JsonProperty()]
        public string Title { get; private set; }

        [JsonProperty()]
        public Guid? WebId { get; private set; }

    }

}

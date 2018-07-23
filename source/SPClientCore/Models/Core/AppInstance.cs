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
        public string AppPrincipalId { get; set; }

        [JsonProperty()]
        public string AppWebFullUrl { get; set; }

        [JsonProperty()]
        public Guid? Id { get; set; }

        [JsonProperty()]
        public bool? InError { get; set; }

        [JsonProperty()]
        public string RemoteAppUrl { get; set; }

        [JsonProperty()]
        public string SettingsPageUrl { get; set; }

        [JsonProperty()]
        public Guid? SiteId { get; set; }

        [JsonProperty()]
        public string StartPage { get; set; }

        [JsonProperty()]
        public AppInstanceStatus? Status { get; set; }

        [JsonProperty()]
        public string Title { get; set; }

        [JsonProperty()]
        public Guid? WebId { get; set; }

    }

}

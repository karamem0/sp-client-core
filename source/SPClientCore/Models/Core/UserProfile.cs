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

    [JsonObject(Id = "SP.UserProfile")]
    public class UserProfile : ClientObject
    {

        public UserProfile()
        {
        }

        [JsonProperty()]
        public string AccountName { get; private set; }

        [JsonProperty()]
        public string DisplayName { get; private set; }

        [JsonProperty()]
        public FollowedContent FollowedContent { get; private set; }

        [JsonProperty()]
        public int? O15FirstRunExperience { get; private set; }

        [JsonProperty()]
        public Site PersonalSite { get; private set; }

        [JsonProperty()]
        public int? PersonalSiteCapabilities { get; private set; }

        [JsonProperty()]
        public string PersonalSiteFirstCreationError { get; private set; }

        [JsonProperty()]
        public DateTime? PersonalSiteFirstCreationTime { get; private set; }

        [JsonProperty()]
        public int? PersonalSiteInstantiationState { get; private set; }

        [JsonProperty()]
        public DateTime? PersonalSiteLastCreationTime { get; private set; }

        [JsonProperty()]
        public int? PersonalSiteNumberOfRetries { get; private set; }

        [JsonProperty()]
        public bool? PictureImportEnabled { get; private set; }

        [JsonProperty()]
        public string PublicUrl { get; private set; }

        [JsonProperty()]
        public string UrlToCreatePersonalSite { get; private set; }

    }

}

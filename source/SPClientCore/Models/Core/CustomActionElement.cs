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

    [JsonObject(Id = "SP.CustomActionElement")]
    public class CustomActionElement : ClientObject
    {

        public CustomActionElement()
        {
        }

        [JsonProperty()]
        public Guid ClientSideComponentId { get; private set; }

        [JsonProperty()]
        public string ClientSideComponentProperties { get; private set; }

        [JsonProperty()]
        public string CommandUIExtension { get; private set; }

        [JsonProperty()]
        public string Id { get; private set; }

        [JsonProperty()]
        public string EnabledScript { get; private set; }

        [JsonProperty()]
        public string ImageUrl { get; private set; }

        [JsonProperty()]
        public string Location { get; private set; }

        [JsonProperty()]
        public string RegistrationId { get; private set; }

        [JsonProperty()]
        public UserCustomActionRegistrationType? RegistrationType { get; private set; }

        [JsonProperty()]
        public bool? RequireSiteAdministrator { get; private set; }

        [JsonProperty()]
        public BasePermissions Rights { get; private set; }

        [JsonProperty()]
        public string Title { get; private set; }

        [JsonProperty()]
        public string UrlAction { get; private set; }

    }

}

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

    [JsonObject(Id = "SP.UserCustomAction")]
    public class UserCustomAction : ClientObject
    {

        public UserCustomAction()
        {
        }

        [JsonProperty()]
        public string CommandUIExtension { get; private set; }

        [JsonProperty()]
        public string Description { get; private set; }

        [JsonProperty()]
        public string Group { get; private set; }

        [JsonProperty()]
        public Guid? Id { get; private set; }

        [JsonProperty()]
        public string ImageUrl { get; private set; }

        [JsonProperty()]
        public string Location { get; private set; }

        [JsonProperty()]
        public string Name { get; private set; }

        [JsonProperty()]
        public string RegistrationId { get; private set; }

        [JsonProperty()]
        public UserCustomActionRegistrationType? RegistrationType { get; private set; }

        [JsonProperty()]
        public BasePermissions Rights { get; private set; }

        [JsonProperty()]
        public bool? Scope { get; private set; }

        [JsonProperty()]
        public string ScriptBlock { get; private set; }

        [JsonProperty()]
        public string ScriptSrc { get; private set; }

        [JsonProperty()]
        public int? Sequence { get; private set; }

        [JsonProperty()]
        public string Title { get; private set; }

        [JsonProperty()]
        public string Url { get; private set; }

        [JsonProperty()]
        public string VersionOfUserCustomAction { get; private set; }

    }

}

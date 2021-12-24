//
// Copyright (c) 2022 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Models.V1
{

    [ClientObject(Name = "SP.NavigationNode", Id = "{cd5d6053-7ffd-41ac-bf36-7b856320a122}")]
    [JsonObject()]
    public class NavigationNode : ClientObject
    {

        public NavigationNode()
        {
        }

        [JsonProperty()]
        public virtual IReadOnlyCollection<Guid> AudienceIds { get; protected set; }

        [JsonProperty("CurrentLCID")]
        public virtual uint CurrentLcid { get; protected set; }

        [JsonProperty()]
        public virtual int Id { get; protected set; }

        [JsonProperty()]
        public virtual bool IsDocLib { get; protected set; }

        [JsonProperty()]
        public virtual bool IsExternal { get; protected set; }

        [JsonProperty()]
        public virtual bool IsVisible { get; protected set; }

        [JsonProperty()]
        public virtual ListTemplateType ListTemplateType { get; protected set; }

        [JsonProperty()]
        public virtual string Title { get; protected set; }

        [JsonProperty()]
        public virtual string Url { get; protected set; }

    }

}

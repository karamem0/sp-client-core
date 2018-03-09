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

    [JsonObject(Id = "SP.Principal")]
    public class Principal : ClientObject
    {

        public Principal()
        {
        }

        [JsonProperty()]
        public int? Id { get; private set; }

        [JsonProperty()]
        public bool? IsHiddenInUI { get; private set; }

        [JsonProperty()]
        public string LoginName { get; private set; }

        [JsonProperty()]
        public PrincipalType? PrincipalType { get; private set; }

        [JsonProperty()]
        public string Title { get; private set; }

    }

}

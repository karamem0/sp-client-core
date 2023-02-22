//
// Copyright (c) 2023 karamem0
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

    [ClientObject(Name = "SP.Principal", Id = "{8a76e712-17a1-4a40-b2df-cca7c060d78f}")]
    [JsonObject()]
    public class Principal : ClientObject
    {

        public Principal()
        {
        }

        [JsonProperty()]
        public virtual int Id { get; protected set; }

        // [JsonProperty()]
        // public virtual bool IsHiddenInUI { get; protected set; }

        [JsonProperty()]
        public virtual string LoginName { get; protected set; }

        [JsonProperty()]
        public virtual PrincipalType PrincipalType { get; protected set; }

        [JsonProperty()]
        public virtual string Title { get; protected set; }

    }

}

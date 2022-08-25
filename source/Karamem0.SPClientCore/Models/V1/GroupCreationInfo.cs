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

    [ClientObject(Name = "SP.GroupCreationInformation", Id = "{9fd1540e-59e6-47fa-9a00-5173c9c35785}")]
    [JsonObject()]
    public class GroupCreationInfo : ClientValueObject
    {

        public GroupCreationInfo()
        {
        }

        public GroupCreationInfo(IReadOnlyDictionary<string, object> parameters) : base(parameters)
        {
        }

        [JsonProperty()]
        public virtual string Description { get; protected set; }

        [JsonProperty()]
        public virtual string Title { get; protected set; }

    }

}

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

    [ClientObject(Name = "SP.PickerSettings", Id = "{8d31357d-328a-45cc-a5ab-b15c9c83eb71}")]
    [JsonObject()]
    public class PickerSettings : ClientObject
    {

        public PickerSettings()
        {
        }

        [JsonProperty()]
        public virtual bool AllowEmailAddresses { get; protected set; }

        [JsonProperty()]
        public virtual bool AllowOnlyEmailAddresses { get; protected set; }

        [JsonProperty()]
        public virtual string PrincipalAccountType { get; protected set; }

        [JsonProperty()]
        public virtual PrincipalSource PrincipalSource { get; protected set; }

        [JsonProperty()]
        public virtual PeoplePickerQuerySettings QuerySettings { get; protected set; }

        [JsonProperty()]
        public virtual bool UseSubstrateSearch { get; protected set; }

        [JsonProperty()]
        public virtual int VisibleSuggestions { get; protected set; }

    }

}

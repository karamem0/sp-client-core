//
// Copyright (c) 2018-2024 karamem0
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

namespace Karamem0.SharePoint.PowerShell.Models.V1;

[ClientObject(Name = "SP.PeoplePickerQuerySettings", Id = "{836910b9-5dd8-4cdb-9863-4e7154de92d2}")]
[JsonObject()]
public class PeoplePickerQuerySettings : ClientValueObject
{

    public PeoplePickerQuerySettings()
    {
    }

    [JsonProperty()]
    public virtual bool ExcludeAllUsersOnTenantClaim { get; protected set; }

    [JsonProperty()]
    public virtual bool IsSharing { get; protected set; }

}

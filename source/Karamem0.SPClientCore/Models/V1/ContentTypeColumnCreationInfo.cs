//
// Copyright (c) 2018-2025 karamem0
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

[ClientObject(Name = "SP.FieldLinkCreationInformation", Id = "{63fb2c92-8f65-4bbb-a658-b6cd294403f4}")]
[JsonObject()]
public class ContentTypeColumnCreationInfo : ClientValueObject
{

    [JsonProperty("Field")]
    public virtual Column? Column { get; protected set; }

}

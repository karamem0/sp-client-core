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

[ClientObject(Name = "SP.FieldLinkCollection", Id = "{6d87e76a-b8a8-4634-8170-082b1d454bfd}")]
[JsonObject()]
public class ContentTypeColumnEnumerable : ClientObjectEnumerable<ContentTypeColumn>
{

    public ContentTypeColumnEnumerable()
    {
    }

}

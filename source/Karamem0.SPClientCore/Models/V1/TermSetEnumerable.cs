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

[ClientObject(Name = "SP.Taxonomy.TermSetCollection", Id = "{659df998-3955-45fa-b64e-3d6ca277a97a}")]
[JsonObject()]
public class TermSetEnumerable : ClientObjectEnumerable<TermSet>
{

    public TermSetEnumerable()
    {
    }

}

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

[ClientObject(Name = "SP.Taxonomy.TermCollection", Id = "{ac6d0da8-9769-4425-a395-6413a9a0367e}")]
[JsonObject()]
public class TermEnumerable : ClientObjectEnumerable<Term>
{

    public TermEnumerable()
    {
    }

}

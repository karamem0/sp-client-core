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

    [ClientObject(Name = "SP.FileCollection", Id = "{d367b17c-170b-4691-a1e3-8bccf7686ce4}")]
    [JsonObject()]
    public class FileEnumerable : ClientObjectEnumerable<File>
    {

        public FileEnumerable()
        {
        }

    }

}

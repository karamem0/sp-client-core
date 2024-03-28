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

[ClientObject(Name = "SP.FileVersionCollection", Id = "{3826e282-67a6-4861-88fb-474e8aac897b}")]
[JsonObject()]
public class FileVersionEnumerable : ClientObjectEnumerable<FileVersion>
{

    public FileVersionEnumerable()
    {
    }

}

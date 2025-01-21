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

[ClientObject(Name = "SP.AttachmentCollection", Id = "{f4e86471-7dab-4b47-b061-50a40e27140e}")]
[JsonObject()]
public class AttachmentFileEnumerable : ClientObjectEnumerable<AttachmentFile>
{

    public AttachmentFileEnumerable()
    {
    }

}

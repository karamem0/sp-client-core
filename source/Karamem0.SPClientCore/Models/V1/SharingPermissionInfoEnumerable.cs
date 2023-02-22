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

    [ClientObject(Name = "SP.SharingPermissionInformationCollection", Id = "{7ee2a862-17c8-46b8-8f66-0373ee06afbf}")]
    [JsonObject()]
    public class SharingPermissionInfoEnumerable : ClientObjectEnumerable<SharingPermissionInfo>
    {

        public SharingPermissionInfoEnumerable()
        {
        }

    }

}

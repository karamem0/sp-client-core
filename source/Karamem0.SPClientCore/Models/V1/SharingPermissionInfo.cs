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

    [ClientObject(Name = "SP.SharingPermissionInformation", Id = "{1a97a9b7-5f9f-4da3-9402-48324bcb9d9f}")]
    [JsonObject()]
    public class SharingPermissionInfo : ClientObject
    {

        public SharingPermissionInfo()
        {
        }

    }

}

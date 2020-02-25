//
// Copyright (c) 2020 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Models
{

    [JsonObject()]
    [ClientObject(Name = "Microsoft.Online.SharePoint.TenantAdministration.TenantLog", Id = "{ea623a2c-97c8-4899-8f0e-7619f6bbce3d}")]
    public class TenantLog : ODataObject
    {

        public TenantLog()
        {
        }

    }

}

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

    [ClientObject(Name = "SP.UserProfiles.ProfileLoader", Id = "{9c42543a-91b3-4902-b2fe-14ccdefb6e2b}")]
    [JsonObject()]
    public class ProfileLoader : ClientObject
    {

        public ProfileLoader()
        {
        }

    }

}

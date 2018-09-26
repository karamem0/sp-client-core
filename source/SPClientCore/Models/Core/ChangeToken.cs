//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Models.Core
{

    public class ChangeToken : ClientObject
    {

        public ChangeToken()
        {
        }

        [JsonProperty()]
        public string StringValue { get; private set; }

    }

}

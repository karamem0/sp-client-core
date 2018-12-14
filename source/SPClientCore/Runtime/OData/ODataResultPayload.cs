//
// Copyright (c) 2019 karamem0
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

namespace Karamem0.SharePoint.PowerShell.Runtime.OData
{

    [JsonObject()]
    public class ODataResultPayload
    {

        public ODataResultPayload()
        {
        }

        [JsonProperty("error")]
        public ODataError Error { get; private set; }

    }

}

//
// Copyright (c) 2020 karamem0
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

namespace Karamem0.SharePoint.PowerShell.Runtime.Models
{

    [JsonObject()]
    public class ODataResultPayload<T> : ODataResultPayload where T : ODataObject
    {

        public ODataResultPayload()
        {
        }

        [JsonProperty("d")]
        public T Entry { get; private set; }

    }

}

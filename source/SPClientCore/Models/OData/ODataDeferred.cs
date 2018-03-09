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

namespace Karamem0.SharePoint.PowerShell.Models.OData
{

    [JsonObject()]
    public class ODataDeferred : ODataObject
    {

        public ODataDeferred()
        {
        }

        public ODataDeferred(Uri uri)
        {
            this.Uri = uri;
        }

        [JsonProperty("uri")]
        public Uri Uri { get; private set; }

    }

}

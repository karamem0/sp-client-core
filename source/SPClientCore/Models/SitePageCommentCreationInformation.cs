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
    [ODataV1Object(Name = "Microsoft.SharePoint.Comments.comment")]
    public class SitePageCommentCreationInformation : ODataV1Object
    {

        public SitePageCommentCreationInformation()
        {
        }

        [JsonProperty("text")]
        public virtual string Text { get; protected set; }

    }

}

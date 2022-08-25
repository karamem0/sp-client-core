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

    [JsonObject()]
    [ODataV1Object(Name = "Microsoft.SharePoint.Comments.comment")]
    public class CommentCreationInfo : ODataV1Object
    {

        public CommentCreationInfo()
        {
        }

        [JsonProperty("text")]
        public virtual string Text { get; protected set; }

    }

}

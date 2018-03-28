//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Models.Social
{

    [Flags()]
    public enum SocialThreadAttributes
    {

        None = 0,

        IsDigest = 1,

        CanReply = 2,

        CanLock = 4,

        IsLocked = 8,

        ReplyLimitReached = 16,

    }

}

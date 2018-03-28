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
    public enum SocialPostAttributes
    {

        None = 0,

        CanLike = 1,

        CanDelete = 2,

        UseAuthorImage = 4,

        UseSmallImage = 8,

        CanFollowUp = 16,

    }

}

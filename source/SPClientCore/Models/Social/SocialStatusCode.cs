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

    public enum SocialStatusCode
    {
        OK = 0,

        InvalidRequest = 1,

        AccessDenied = 2,

        ItemNotFound = 3,

        InvalidOperation = 4,

        ItemNotModified = 5,

        InternalError = 6,

        CacheReadError = 7,

        CacheUpdateError = 8,

        PersonalSiteNotFound = 9,

        FailedToCreatePersonalSite = 10,

        NotAuthorizedToCreatePersonalSite = 11,

        CannotCreatePersonalSite = 12,

        LimitReached = 13,

        AttachmentError = 14,

        PartialData = 15,

        FeatureDisabled = 16,

    }

}

//
// Copyright (c) 2020 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Runtime.OAuth
{

    public abstract class OAuthTokenCache
    {

        protected OAuthTokenCache()
        {
        }

        public abstract string GetAccessToken();

    }

}

//
// Copyright (c) 2023 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Runtime.OAuth
{

    public abstract class OAuthTokenProvider
    {

        protected OAuthTokenProvider()
        {
        }

        public abstract string CurrentAceessToken { get; }

        public abstract string GetAccessToken();

    }

}

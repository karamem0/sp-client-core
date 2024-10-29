//
// Copyright (c) 2018-2024 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Runtime.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Runtime.Commands;

public abstract class OAuthCmdlet : ClientObjectCmdlet
{

    protected OAuthCmdlet()
    {
        this.Service = new OAuthService();
    }

    protected IOAuthService Service { get; private set; }

}

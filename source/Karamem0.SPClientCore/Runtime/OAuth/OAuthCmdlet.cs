//
// Copyright (c) 2018-2024 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Resources;
using Karamem0.SharePoint.PowerShell.Runtime.ApplicationInsights;
using Karamem0.SharePoint.PowerShell.Runtime.OAuth;
using Microsoft.ApplicationInsights;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management.Automation;
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

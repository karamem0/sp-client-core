//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Resources;
using Karamem0.SharePoint.PowerShell.Runtime.Commands;
using Karamem0.SharePoint.PowerShell.Services.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands;

[Cmdlet(VerbsCommon.Add, "KshOrganizationSharingLink")]
[OutputType(typeof(string))]
public class AddOrganizationSharingLinkCommand : ClientObjectCmdlet<ISharingLinkService>
{

    public AddOrganizationSharingLinkCommand()
    {
    }

    [Parameter(Mandatory = true)]
    public Uri Url { get; private set; }

    [Parameter(Mandatory = true)]
    public bool IsEditLink { get; private set; }

    protected override void ProcessRecordCore()
    {
        if (this.Url.IsAbsoluteUri)
        {
            this.Outputs.Add(this.Service.CreateOrganizationSharingLink(this.Url, this.IsEditLink));
        }
        else
        {
            throw new InvalidOperationException(string.Format(StringResources.ErrorValueIsNotAbsoluteUrl, this.Url));
        }
    }

}

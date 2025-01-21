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

[Cmdlet(VerbsCommon.Remove, "KshAnonymousLink", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
[OutputType(typeof(void))]
public class RemoveAnonymousLinkCommand : ClientObjectCmdlet<ISharingLinkService>
{

    public RemoveAnonymousLinkCommand()
    {
    }

    [Parameter(Mandatory = true, Position = 0)]
    public Uri Url { get; private set; }

    [Parameter(Mandatory = true, Position = 1)]
    public bool IsEditLink { get; private set; }

    [Parameter(Mandatory = true, Position = 2)]
    public bool RemoveAssociatedSharingLinkGroup { get; private set; }

    protected override void ProcessRecordCore()
    {
        if (this.ShouldProcess(this.Url.ToString(), VerbsCommon.Remove))
        {
            if (this.Url.IsAbsoluteUri)
            {
                this.Service.RemoveAnonymousLink(this.Url, this.IsEditLink, this.RemoveAssociatedSharingLinkGroup);
            }
            else
            {
                throw new InvalidOperationException(string.Format(StringResources.ErrorValueIsNotAbsoluteUrl, this.Url));
            }
        }
    }

}

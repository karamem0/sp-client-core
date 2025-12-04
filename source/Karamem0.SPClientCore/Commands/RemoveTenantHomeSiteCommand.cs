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
using System.Management.Automation;

namespace Karamem0.SharePoint.PowerShell.Commands;

[Cmdlet(
    VerbsCommon.Remove,
    "TenantHomeSite",
    SupportsShouldProcess = true,
    ConfirmImpact = ConfirmImpact.High
)]
[OutputType(typeof(void))]
public class RemoveTenantHomeSiteCommand : ClientObjectCmdlet<ITenantHomeSiteService>
{

    protected override void ProcessRecordCore()
    {
        var siteUrl = this.Service.GetObject();
        _ = siteUrl ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
        if (this.ShouldProcess(siteUrl.ToString(), VerbsCommon.Remove))
        {
            this.Service.RemoveObject();
        }
    }

}

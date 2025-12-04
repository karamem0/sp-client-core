//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Resources;
using Karamem0.SharePoint.PowerShell.Runtime.Commands;
using Karamem0.SharePoint.PowerShell.Services.V1;
using System.Management.Automation;

namespace Karamem0.SharePoint.PowerShell.Commands;

[Cmdlet(
    VerbsCommon.Remove,
    "TenantDeletedSiteCollection",
    SupportsShouldProcess = true,
    ConfirmImpact = ConfirmImpact.High
)]
[OutputType(typeof(void))]
public class RemoveTenantDeletedSiteCollectionCommand : ClientObjectCmdlet<ITenantDeletedSiteCollectionService>
{

    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true,
        ParameterSetName = "ParamSet1"
    )]
    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true,
        ParameterSetName = "ParamSet2"
    )]
    public TenantDeletedSiteCollection? Identity { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet2")]
    public SwitchParameter NoWait { get; private set; }

    protected override void ProcessRecordCore()
    {
        _ = this.Identity?.Url ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Identity));
        if (this.ShouldProcess(this.Identity.Url.ToString(), VerbsCommon.Remove))
        {
            if (this.ParameterSetName == "ParamSet1")
            {
                this.Service.RemoveObjectAwait(this.Identity);
            }
            if (this.ParameterSetName == "ParamSet2")
            {
                this.ValidateSwitchParameter(nameof(this.NoWait));
                _ = this.Service.RemoveObject(this.Identity);
            }
        }
    }

}

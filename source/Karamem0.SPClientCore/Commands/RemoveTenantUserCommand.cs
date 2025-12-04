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
    "TenantUser",
    SupportsShouldProcess = true,
    ConfirmImpact = ConfirmImpact.High
)]
[OutputType(typeof(void))]
public class RemoveTenantUserCommand : ClientObjectCmdlet<ITenantUserService>
{

    [Parameter(
        Mandatory = true,
        Position = 0,
        ParameterSetName = "ParamSet1"
    )]
    public TenantSiteCollection? SiteCollection { get; private set; }

    [Parameter(
        Mandatory = true,
        Position = 0,
        ParameterSetName = "ParamSet2"
    )]
    public Uri? SiteCollectionUrl { get; private set; }

    [Parameter(
        Mandatory = true,
        Position = 1,
        ParameterSetName = "ParamSet1"
    )]
    [Parameter(
        Mandatory = true,
        Position = 1,
        ParameterSetName = "ParamSet2"
    )]
    public User? User { get; private set; }

    protected override void ProcessRecordCore()
    {
        _ = this.User ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.User));
        if (this.ShouldProcess(this.User.Title, VerbsCommon.Remove))
        {
            if (this.ParameterSetName == "ParamSet1")
            {
                _ = this.SiteCollection?.Url ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.SiteCollection));
                this.Service.RemoveObject(this.SiteCollection.Url, this.User);
            }
            if (this.ParameterSetName == "ParamSet2")
            {
                _ = this.SiteCollectionUrl ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.SiteCollectionUrl));
                this.Service.RemoveObject(this.SiteCollectionUrl, this.User);
            }
        }
    }

}

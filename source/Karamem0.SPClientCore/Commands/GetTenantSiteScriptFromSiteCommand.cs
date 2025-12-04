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

[Cmdlet(VerbsCommon.Get, "TenantSiteScriptFromSite")]
[OutputType(typeof(string))]
public class GetTenantSiteScriptFromSiteCommand : ClientObjectCmdlet<ITenantSiteScriptService>
{

    [Parameter(Mandatory = true)]
    public Uri? SiteUrl { get; private set; }

    [Parameter(Mandatory = false)]
    public SwitchParameter IncludeBranding { get; private set; }

    [Parameter(Mandatory = false)]
    public string[]? IncludedLists { get; private set; }

    [Parameter(Mandatory = false)]
    public SwitchParameter IncludeLinksToExportedItems { get; private set; }

    [Parameter(Mandatory = false)]
    public SwitchParameter IncludeRegionalSettings { get; private set; }

    [Parameter(Mandatory = false)]
    public SwitchParameter IncludeSiteExternalSharingCapability { get; private set; }

    [Parameter(Mandatory = false)]
    public SwitchParameter IncludeTheme { get; private set; }

    protected override void ProcessRecordCore()
    {
        this.Outputs.Add(
            this.Service.GetScriptFromSite(
                this.SiteUrl ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.SiteUrl)),
                this.MyInvocation.BoundParameters
            )
        );
    }

}

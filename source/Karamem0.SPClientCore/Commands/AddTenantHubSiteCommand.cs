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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands;

[Cmdlet(VerbsCommon.Add, "KshTenantHubSite")]
[OutputType(typeof(HubSite))]
public class AddTenantHubSiteCommand : ClientObjectCmdlet<ITenantHubSiteService>
{

    [Parameter(Mandatory = false)]
    public string? Description { get; private set; }

    [Parameter(Mandatory = false)]
    public bool EnablePermissionsSync { get; private set; }

    [Parameter(Mandatory = false)]
    public bool HideNameInNavigation { get; private set; }

    [Parameter(Mandatory = false)]
    public Uri? LogoUrl { get; private set; }

    [Parameter(Mandatory = true)]
    public Guid SiteCollectionId { get; private set; }

    [Parameter(Mandatory = true)]
    public Uri? SiteCollectionUrl { get; private set; }

    [Parameter(Mandatory = true)]
    public string? Title { get; private set; }

    protected override void ProcessRecordCore()
    {
        _ = this.SiteCollectionUrl ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.SiteCollectionUrl));
        this.Outputs.Add(this.Service.AddObject(this.SiteCollectionUrl, this.MyInvocation.BoundParameters));
    }

}

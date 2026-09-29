//
// Copyright (c) 2018-2026 karamem0
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

[Cmdlet(VerbsCommon.Get, "TenantHubSite")]
[OutputType(typeof(HubSite))]
public class GetTenantHubSiteCommand : ClientObjectCmdlet<ITenantHubSiteService>
{

    [Parameter(
        Mandatory = true,
        Position = 0,
        ParameterSetName = "ParamSet1"
    )]
    public Guid HubSiteId { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet2")]
    public Uri? HubSiteUrl { get; private set; }

    [Parameter(Mandatory = false)]
    public SwitchParameter SelectAllProperties { get; private set; } = true;

    [Parameter(Mandatory = false, ParameterSetName = "ParamSet3")]
    public SwitchParameter NoEnumerate { get; private set; }

    protected override async Task ProcessRecordAsync()
    {
        if (this.ParameterSetName == "ParamSet1")
        {
            this.Outputs.Add(await this.Service.GetObjectAsync(this.HubSiteId, this.SelectAllProperties));
        }
        if (this.ParameterSetName == "ParamSet2")
        {
            this.Outputs.Add(
                await this.Service.GetObjectAsync(
                    this.HubSiteUrl ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.HubSiteUrl)),
                    this.SelectAllProperties
                )
            );
        }
        if (this.ParameterSetName == "ParamSet3")
        {
            if (this.NoEnumerate)
            {
                this.Outputs.Add(await this.Service.GetObjectEnumerableAsync(this.SelectAllProperties));
            }
            else
            {
                this.Outputs.AddRange(await this.Service.GetObjectEnumerableAsync(this.SelectAllProperties));
            }
        }
    }

}

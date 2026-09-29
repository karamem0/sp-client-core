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

[Cmdlet(VerbsCommon.Get, "TenantSiteCollection")]
[OutputType(typeof(TenantSiteCollection))]
public class GetTenantSiteCollectionCommand : ClientObjectCmdlet<ITenantSiteCollectionService>
{

    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true,
        ParameterSetName = "ParamSet1"
    )]
    public TenantSiteCollection? Identity { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet2")]
    public Uri? SiteCollectionUrl { get; private set; }

    [Parameter(Mandatory = false, ParameterSetName = "ParamSet3")]
    public SwitchParameter GroupIdDefined { get; private set; }

    [Parameter(Mandatory = false, ParameterSetName = "ParamSet3")]
    public SwitchParameter IncludePersonalSite { get; private set; }

    [Parameter(Mandatory = false, ParameterSetName = "ParamSet3")]
    public string? Template { get; private set; }

    [Parameter(Mandatory = false)]
    public SwitchParameter SelectAllProperties { get; private set; } = true;

    [Parameter(Mandatory = false, ParameterSetName = "ParamSet3")]
    public SwitchParameter NoEnumerate { get; private set; }

    protected override async Task ProcessRecordAsync()
    {
        if (this.ParameterSetName == "ParamSet1")
        {
            _ = this.Identity ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Identity));
            this.Outputs.Add(await this.Service.GetObjectAsync(this.Identity, this.SelectAllProperties));
        }
        if (this.ParameterSetName == "ParamSet2")
        {
            _ = this.SiteCollectionUrl ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.SiteCollectionUrl));
            if (this.SiteCollectionUrl.IsAbsoluteUri)
            {
                this.Outputs.Add(await this.Service.GetObjectAsync(this.SiteCollectionUrl, this.SelectAllProperties));
            }
            else
            {
                throw new InvalidOperationException(string.Format(StringResources.ErrorValueIsNotAbsoluteUrl, this.SiteCollectionUrl));
            }
        }
        if (this.ParameterSetName == "ParamSet3")
        {
            var filterInfo = new Dictionary<string, object?>(this.MyInvocation.BoundParameters);
            _ = filterInfo.Remove(nameof(this.NoEnumerate));
            if (this.NoEnumerate)
            {
                this.Outputs.Add(await this.Service.GetObjectEnumerableAsync(filterInfo, this.SelectAllProperties));
            }
            else
            {
                this.Outputs.AddRange(await this.Service.GetObjectEnumerableAsync(filterInfo, this.SelectAllProperties));
            }
        }
    }

}

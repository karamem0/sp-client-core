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

[Cmdlet(VerbsCommon.Add, "SiteCollectionAppCatalog")]
[OutputType(typeof(void))]
public class AddSiteCollectionAppCatalogCommand : ClientObjectCmdlet<ISiteCollectionAppCatalogService>
{

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet1")]
    public SiteCollection? SiteCollection { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet2")]
    public TenantSiteCollection? TenantSiteCollection { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet3")]
    public Uri? SiteCollectionUrl { get; private set; }

    protected override void ProcessRecordCore()
    {
        if (this.ParameterSetName == "ParamSet1")
        {
            _ = this.SiteCollection?.Url ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.SiteCollection));
            this.Service.AddObject(this.SiteCollection.Url);
        }
        if (this.ParameterSetName == "ParamSet2")
        {
            _ = this.TenantSiteCollection?.Url ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.TenantSiteCollection));
            this.Service.AddObject(this.TenantSiteCollection.Url);
        }
        if (this.ParameterSetName == "ParamSet3")
        {
            _ = this.SiteCollectionUrl ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.SiteCollectionUrl));
            if (this.SiteCollectionUrl.IsAbsoluteUri)
            {
                this.Service.AddObject(this.SiteCollectionUrl);
            }
            else
            {
                throw new InvalidOperationException(string.Format(StringResources.ErrorValueIsNotAbsoluteUrl, this.SiteCollectionUrl));
            }
        }
    }

}

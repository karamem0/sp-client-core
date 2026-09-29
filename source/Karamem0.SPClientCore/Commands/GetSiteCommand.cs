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

[Cmdlet(VerbsCommon.Get, "Site")]
[OutputType(typeof(Site))]
public class GetSiteCommand : ClientObjectCmdlet<ISiteService>
{

    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true,
        ParameterSetName = "ParamSet1"
    )]
    public Site? Identity { get; private set; }

    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true,
        ParameterSetName = "ParamSet2"
    )]
    public SiteCollection? SiteCollection { get; private set; }

    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true,
        ParameterSetName = "ParamSet3"
    )]
    public List? List { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet4")]
    public Guid SiteId { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet5")]
    public Uri? SiteUrl { get; private set; }

    [Parameter(Mandatory = false)]
    public SwitchParameter SelectAllProperties { get; private set; } = true;

    [Parameter(Mandatory = false, ParameterSetName = "ParamSet6")]
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
            _ = this.SiteCollection ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.SiteCollection));
            this.Outputs.Add(await this.Service.GetObjectAsync(this.SiteCollection, this.SelectAllProperties));
        }
        if (this.ParameterSetName == "ParamSet3")
        {
            _ = this.List ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.List));
            this.Outputs.Add(await this.Service.GetObjectAsync(this.List, this.SelectAllProperties));
        }
        if (this.ParameterSetName == "ParamSet4")
        {
            this.Outputs.Add(await this.Service.GetObjectAsync(this.SiteId, this.SelectAllProperties));
        }
        if (this.ParameterSetName == "ParamSet5")
        {
            _ = this.SiteUrl ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.SiteUrl));
            if (this.SiteUrl.IsAbsoluteUri)
            {
                this.Outputs.Add(await this.Service.GetObjectAsync(new Uri(this.SiteUrl.AbsolutePath, UriKind.Relative), this.SelectAllProperties));
            }
            else
            {
                this.Outputs.Add(await this.Service.GetObjectAsync(this.SiteUrl, this.SelectAllProperties));
            }
        }
        if (this.ParameterSetName == "ParamSet6")
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

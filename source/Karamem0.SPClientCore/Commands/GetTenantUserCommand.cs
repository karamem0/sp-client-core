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

[Cmdlet(VerbsCommon.Get, "TenantUser")]
[OutputType(typeof(User))]
public class GetTenantUserCommand : ClientObjectCmdlet<ITenantUserService>
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
    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true,
        ParameterSetName = "ParamSet3"
    )]
    public TenantSiteCollection? SiteCollection { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet4")]
    [Parameter(Mandatory = true, ParameterSetName = "ParamSet5")]
    [Parameter(Mandatory = true, ParameterSetName = "ParamSet6")]
    public Uri? SiteCollectionUrl { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet1")]
    [Parameter(Mandatory = true, ParameterSetName = "ParamSet4")]
    public int UserId { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet2")]
    [Parameter(Mandatory = true, ParameterSetName = "ParamSet5")]
    public string? UserName { get; private set; }

    [Parameter(Mandatory = false, ParameterSetName = "ParamSet3")]
    [Parameter(Mandatory = false, ParameterSetName = "ParamSet6")]
    public SwitchParameter NoEnumerate { get; private set; }

    protected override void ProcessRecordCore()
    {
        if (this.ParameterSetName == "ParamSet1")
        {
            _ = this.SiteCollection?.Url ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.SiteCollection));
            this.Outputs.Add(this.Service.GetObject(this.SiteCollection.Url, this.UserId));
        }
        if (this.ParameterSetName == "ParamSet2")
        {
            _ = this.SiteCollection?.Url ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.SiteCollection));
            _ = this.UserName ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.UserName));
            this.Outputs.Add(this.Service.GetObject(this.SiteCollection.Url, this.UserName));
        }
        if (this.ParameterSetName == "ParamSet3")
        {
            _ = this.SiteCollection?.Url ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.SiteCollection));
            if (this.NoEnumerate)
            {
                this.Outputs.Add(this.Service.GetObjectEnumerable(this.SiteCollection.Url));
            }
            else
            {
                this.Outputs.AddRange(this.Service.GetObjectEnumerable(this.SiteCollection.Url));
            }
        }
        if (this.ParameterSetName == "ParamSet4")
        {
            _ = this.SiteCollectionUrl ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.SiteCollectionUrl));
            this.Outputs.Add(this.Service.GetObject(this.SiteCollectionUrl, this.UserId));
        }
        if (this.ParameterSetName == "ParamSet5")
        {
            _ = this.SiteCollectionUrl ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.SiteCollectionUrl));
            _ = this.UserName ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.UserName));
            this.Outputs.Add(this.Service.GetObject(this.SiteCollectionUrl, this.UserName));
        }
        if (this.ParameterSetName == "ParamSet6")
        {
            _ = this.SiteCollectionUrl ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.SiteCollectionUrl));
            if (this.NoEnumerate)
            {
                this.Outputs.Add(this.Service.GetObjectEnumerable(this.SiteCollectionUrl));
            }
            else
            {
                this.Outputs.AddRange(this.Service.GetObjectEnumerable(this.SiteCollectionUrl));
            }
        }
    }

}

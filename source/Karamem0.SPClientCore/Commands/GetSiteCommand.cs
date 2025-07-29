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

[Cmdlet(VerbsCommon.Get, "KshSite")]
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

    [Parameter(Mandatory = false, ParameterSetName = "ParamSet6")]
    public SwitchParameter NoEnumerate { get; private set; }

    protected override void ProcessRecordCore()
    {
        if (this.ParameterSetName == "ParamSet1")
        {
            _ = this.Identity ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Identity));
            this.Outputs.Add(this.Service.GetObject(this.Identity));
        }
        if (this.ParameterSetName == "ParamSet2")
        {
            _ = this.SiteCollection ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.SiteCollection));
            this.Outputs.Add(this.Service.GetObject(this.SiteCollection));
        }
        if (this.ParameterSetName == "ParamSet3")
        {
            _ = this.List ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.List));
            this.Outputs.Add(this.Service.GetObject(this.List));
        }
        if (this.ParameterSetName == "ParamSet4")
        {
            this.Outputs.Add(this.Service.GetObject(this.SiteId));
        }
        if (this.ParameterSetName == "ParamSet5")
        {
            _ = this.SiteUrl ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.SiteUrl));
            if (this.SiteUrl.IsAbsoluteUri)
            {
                this.Outputs.Add(this.Service.GetObject(new Uri(this.SiteUrl.AbsolutePath, UriKind.Relative)));
            }
            else
            {
                this.Outputs.Add(this.Service.GetObject(this.SiteUrl));
            }
        }
        if (this.ParameterSetName == "ParamSet6")
        {
            if (this.NoEnumerate)
            {
                this.Outputs.Add(this.Service.GetObjectEnumerable());
            }
            else
            {
                this.Outputs.AddRange(this.Service.GetObjectEnumerable());
            }
        }
    }

}

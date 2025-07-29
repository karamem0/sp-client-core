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

[Cmdlet(VerbsCommon.Get, "KshView")]
[OutputType(typeof(View))]
public class GetViewCommand : ClientObjectCmdlet<IViewService>
{

    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true,
        ParameterSetName = "ParamSet1"
    )]
    public View? Identity { get; private set; }

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
    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true,
        ParameterSetName = "ParamSet4"
    )]
    public List? List { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet2")]
    public Guid ViewId { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet3")]
    public string? ViewTitle { get; private set; }

    [Parameter(Mandatory = false, ParameterSetName = "ParamSet4")]
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
            _ = this.List ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.List));
            this.Outputs.Add(this.Service.GetObject(this.List, this.ViewId));
        }
        if (this.ParameterSetName == "ParamSet3")
        {
            _ = this.List ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.List));
            _ = this.ViewTitle ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.ViewTitle));
            this.Outputs.Add(this.Service.GetObject(this.List, this.ViewTitle));
        }
        if (this.ParameterSetName == "ParamSet4")
        {
            _ = this.List ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.List));
            if (this.NoEnumerate)
            {
                this.Outputs.Add(this.Service.GetObjectEnumerable(this.List));
            }
            else
            {
                this.Outputs.AddRange(this.Service.GetObjectEnumerable(this.List));
            }
        }
    }

}

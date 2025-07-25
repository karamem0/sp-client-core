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

[Cmdlet(VerbsCommon.Get, "KshProperty")]
[OutputType(typeof(PropertyValues))]
public class GetPropertyCommand : ClientObjectCmdlet<IPropertyService>
{

    [Parameter(
        Mandatory = true,
        Position = 0,
        ParameterSetName = "ParamSet1"
    )]
    public Alert? Alert { get; private set; }

    [Parameter(
        Mandatory = true,
        Position = 0,
        ParameterSetName = "ParamSet2"
    )]
    public File? File { get; private set; }

    [Parameter(
        Mandatory = true,
        Position = 0,
        ParameterSetName = "ParamSet3"
    )]
    public Folder? Folder { get; private set; }

    [Parameter(
        Mandatory = true,
        Position = 0,
        ParameterSetName = "ParamSet4"
    )]
    public ListItem? ListItem { get; private set; }

    [Parameter(
        Mandatory = true,
        Position = 0,
        ParameterSetName = "ParamSet5"
    )]
    public Site? Site { get; private set; }

    protected override void ProcessRecordCore()
    {
        if (this.ParameterSetName == "ParamSet1")
        {
            _ = this.Alert ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Alert));
            this.Outputs.Add(this.Service.GetObject(this.Alert));
        }
        if (this.ParameterSetName == "ParamSet2")
        {
            _ = this.File ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.File));
            this.Outputs.Add(this.Service.GetObject(this.File));
        }
        if (this.ParameterSetName == "ParamSet3")
        {
            _ = this.Folder ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Folder));
            this.Outputs.Add(this.Service.GetObject(this.Folder));
        }
        if (this.ParameterSetName == "ParamSet4")
        {
            _ = this.ListItem ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.ListItem));
            this.Outputs.Add(this.Service.GetObject(this.ListItem));
        }
        if (this.ParameterSetName == "ParamSet5")
        {
            _ = this.Site ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Site));
            this.Outputs.Add(this.Service.GetObject(this.Site));
        }
    }

}

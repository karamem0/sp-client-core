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

[Cmdlet(VerbsCommon.Add, "KshContentType")]
[OutputType(typeof(ContentType))]
public class AddContentTypeCommand : ClientObjectCmdlet<IContentTypeService>
{

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet1")]
    [Parameter(Mandatory = true, ParameterSetName = "ParamSet2")]
    public List? List { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet1")]
    [Parameter(Mandatory = false, ParameterSetName = "ParamSet2")]
    [Parameter(Mandatory = false, ParameterSetName = "ParamSet3")]
    public ContentType? ContentType { get; private set; }

    [Parameter(Mandatory = false, ParameterSetName = "ParamSet2")]
    [Parameter(Mandatory = false, ParameterSetName = "ParamSet3")]
    public string? Description { get; private set; }

    [Parameter(Mandatory = false, ParameterSetName = "ParamSet2")]
    [Parameter(Mandatory = false, ParameterSetName = "ParamSet3")]
    public string? Group { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet2")]
    [Parameter(Mandatory = true, ParameterSetName = "ParamSet3")]
    public string? Name { get; private set; }

    protected override void ProcessRecordCore()
    {
        if (this.ParameterSetName == "ParamSet1")
        {
            _ = this.List ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.List));
            _ = this.ContentType ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.ContentType));
            this.Outputs.Add(this.Service.AddObject(this.List, this.ContentType));
        }
        if (this.ParameterSetName == "ParamSet2")
        {
            _ = this.List ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.List));
            this.Outputs.Add(this.Service.AddObject(this.List, this.MyInvocation.BoundParameters));
        }
        if (this.ParameterSetName == "ParamSet3")
        {
            this.Outputs.Add(this.Service.AddObject(this.MyInvocation.BoundParameters));
        }
    }

}

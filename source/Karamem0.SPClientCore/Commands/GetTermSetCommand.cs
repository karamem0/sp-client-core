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

[Cmdlet(VerbsCommon.Get, "KshTermSet")]
[OutputType(typeof(TermSet))]
public class GetTermSetCommand : ClientObjectCmdlet<ITermSetService>
{

    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true,
        ParameterSetName = "ParamSet1"
    )]
    public TermSet? Identity { get; private set; }

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
    [Parameter(Mandatory = true, ParameterSetName = "ParamSet4")]
    public TermGroup? TermGroup { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet2")]
    public Guid TermSetId { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet3")]
    public string? TermSetName { get; private set; }

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
            _ = this.TermGroup ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.TermGroup));
            this.Outputs.Add(this.Service.GetObject(this.TermGroup, this.TermSetId));
        }
        if (this.ParameterSetName == "ParamSet3")
        {
            _ = this.TermGroup ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.TermGroup));
            _ = this.TermSetName ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.TermSetName));
            this.Outputs.Add(this.Service.GetObject(this.TermGroup, this.TermSetName));
        }
        if (this.ParameterSetName == "ParamSet4")
        {
            _ = this.TermGroup ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.TermGroup));
            if (this.NoEnumerate)
            {
                this.Outputs.Add(this.Service.GetObjectEnumerable(this.TermGroup));
            }
            else
            {
                this.Outputs.AddRange(this.Service.GetObjectEnumerable(this.TermGroup));
            }
        }
    }

}

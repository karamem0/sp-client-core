//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Runtime.Commands;
using Karamem0.SharePoint.PowerShell.Services.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands;

[Cmdlet(VerbsCommon.Get, "KshRoleAssignment")]
[OutputType(typeof(RoleAssignment))]
public class GetRoleAssignmentCommand : ClientObjectCmdlet<ISiteService, IRoleAssignmentService>
{

    public GetRoleAssignmentCommand()
    {
    }

    [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ParameterSetName = "ParamSet1")]
    public RoleAssignment Identity { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet2")]
    [Parameter(Mandatory = true, ParameterSetName = "ParamSet3")]
    public SwitchParameter Site { get; private set; }

    [Parameter(Mandatory = true, Position = 0, ParameterSetName = "ParamSet4")]
    [Parameter(Mandatory = true, ParameterSetName = "ParamSet5")]
    public List List { get; private set; }

    [Parameter(Mandatory = true, Position = 0, ParameterSetName = "ParamSet6")]
    [Parameter(Mandatory = true, ParameterSetName = "ParamSet7")]
    public ListItem ListItem { get; private set; }

    [Parameter(Mandatory = true, Position = 0, ParameterSetName = "ParamSet2")]
    [Parameter(Mandatory = true, Position = 1, ParameterSetName = "ParamSet4")]
    [Parameter(Mandatory = true, Position = 1, ParameterSetName = "ParamSet6")]
    public int PrincipalId { get; private set; }

    [Parameter(Mandatory = false, ParameterSetName = "ParamSet3")]
    [Parameter(Mandatory = false, ParameterSetName = "ParamSet5")]
    [Parameter(Mandatory = false, ParameterSetName = "ParamSet7")]
    public SwitchParameter NoEnumerate { get; private set; }

    protected override void ProcessRecordCore()
    {
        if (this.ParameterSetName == "ParamSet1")
        {
            this.Outputs.Add(this.Service2.GetObject(this.Identity));
        }
        if (this.ParameterSetName == "ParamSet2")
        {
            this.ValidateSwitchParameter(nameof(this.Site));
            this.Outputs.Add(this.Service2.GetObject(this.Service1.GetObject(), this.PrincipalId));
        }
        if (this.ParameterSetName == "ParamSet3")
        {
            this.ValidateSwitchParameter(nameof(this.Site));
            if (this.NoEnumerate)
            {
                this.Outputs.Add(this.Service2.GetObjectEnumerable(this.Service1.GetObject()));
            }
            else
            {
                this.Outputs.AddRange(this.Service2.GetObjectEnumerable(this.Service1.GetObject()));
            }
        }
        if (this.ParameterSetName == "ParamSet4")
        {
            this.Outputs.Add(this.Service2.GetObject(this.List, this.PrincipalId));
        }
        if (this.ParameterSetName == "ParamSet5")
        {
            if (this.NoEnumerate)
            {
                this.Outputs.Add(this.Service2.GetObjectEnumerable(this.List));
            }
            else
            {
                this.Outputs.AddRange(this.Service2.GetObjectEnumerable(this.List));
            }
        }
        if (this.ParameterSetName == "ParamSet6")
        {
            this.Outputs.Add(this.Service2.GetObject(this.ListItem, this.PrincipalId));
        }
        if (this.ParameterSetName == "ParamSet7")
        {
            if (this.NoEnumerate)
            {
                this.Outputs.Add(this.Service2.GetObjectEnumerable(this.ListItem));
            }
            else
            {
                this.Outputs.AddRange(this.Service2.GetObjectEnumerable(this.ListItem));
            }
        }
    }

}

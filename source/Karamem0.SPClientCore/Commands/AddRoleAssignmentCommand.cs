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

[Cmdlet(VerbsCommon.Add, "RoleAssignment")]
[OutputType(typeof(RoleAssignment))]
public class AddRoleAssignmentCommand : ClientObjectCmdlet<ISiteService, IRoleAssignmentService>
{

    [Parameter(
        Mandatory = true,
        Position = 0,
        ParameterSetName = "ParamSet1"
    )]
    public SwitchParameter Site { get; private set; }

    [Parameter(
        Mandatory = true,
        Position = 0,
        ParameterSetName = "ParamSet2"
    )]
    public List? List { get; private set; }

    [Parameter(
        Mandatory = true,
        Position = 0,
        ParameterSetName = "ParamSet3"
    )]
    public ListItem? ListItem { get; private set; }

    [Parameter(
        Mandatory = true,
        Position = 1,
        ParameterSetName = "ParamSet1"
    )]
    [Parameter(
        Mandatory = true,
        Position = 1,
        ParameterSetName = "ParamSet2"
    )]
    [Parameter(
        Mandatory = true,
        Position = 1,
        ParameterSetName = "ParamSet3"
    )]
    public Principal? Principal { get; private set; }

    [Parameter(
        Mandatory = true,
        Position = 2,
        ParameterSetName = "ParamSet1"
    )]
    [Parameter(
        Mandatory = true,
        Position = 2,
        ParameterSetName = "ParamSet2"
    )]
    [Parameter(
        Mandatory = true,
        Position = 2,
        ParameterSetName = "ParamSet3"
    )]
    public RoleDefinition? RoleDefinition { get; private set; }

    protected override void ProcessRecordCore()
    {
        if (this.ParameterSetName == "ParamSet1")
        {
            this.ValidateSwitchParameter(nameof(this.Site));
            _ = this.Principal ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Principal));
            _ = this.RoleDefinition ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.RoleDefinition));
            var siteObject = this.Service1.GetObject();
            _ = siteObject ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
            this.Outputs.Add(
                this.Service2.AddObject(
                    siteObject,
                    this.Principal,
                    this.RoleDefinition
                )
            );
        }
        if (this.ParameterSetName == "ParamSet2")
        {
            _ = this.List ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.List));
            _ = this.Principal ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Principal));
            _ = this.RoleDefinition ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.RoleDefinition));
            this.Outputs.Add(
                this.Service2.AddObject(
                    this.List,
                    this.Principal,
                    this.RoleDefinition
                )
            );
        }
        if (this.ParameterSetName == "ParamSet3")
        {
            _ = this.ListItem ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.ListItem));
            _ = this.Principal ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Principal));
            _ = this.RoleDefinition ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.RoleDefinition));
            this.Outputs.Add(
                this.Service2.AddObject(
                    this.ListItem,
                    this.Principal,
                    this.RoleDefinition
                )
            );
        }
    }

}

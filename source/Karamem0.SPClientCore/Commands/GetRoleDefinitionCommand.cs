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

[Cmdlet(VerbsCommon.Get, "RoleDefinition")]
[OutputType(typeof(RoleDefinition))]
public class GetRoleDefinitionCommand : ClientObjectCmdlet<IRoleDefinitionService>
{

    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true,
        ParameterSetName = "ParamSet1"
    )]
    public RoleDefinition? Identity { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet2")]
    public int RoleDefinitionId { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet3")]
    public string? RoleDefinitionName { get; private set; }

    [Parameter(Mandatory = false)]
    public SwitchParameter SelectAllProperties { get; private set; } = true;

    [Parameter(Mandatory = false, ParameterSetName = "ParamSet4")]
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
            this.Outputs.Add(await this.Service.GetObjectAsync(this.RoleDefinitionId, this.SelectAllProperties));
        }
        if (this.ParameterSetName == "ParamSet3")
        {
            _ = this.RoleDefinitionName ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.RoleDefinitionName));
            this.Outputs.Add(await this.Service.GetObjectAsync(this.RoleDefinitionName, this.SelectAllProperties));
        }
        if (this.ParameterSetName == "ParamSet4")
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

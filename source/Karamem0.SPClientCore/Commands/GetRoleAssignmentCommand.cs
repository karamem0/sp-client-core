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

[Cmdlet(VerbsCommon.Get, "RoleAssignment")]
[OutputType(typeof(RoleAssignment))]
public class GetRoleAssignmentCommand : ClientObjectCmdlet<ISiteService, IRoleAssignmentService>
{

    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true,
        ParameterSetName = "ParamSet1"
    )]
    public RoleAssignment? Identity { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet2")]
    [Parameter(Mandatory = true, ParameterSetName = "ParamSet3")]
    public SwitchParameter Site { get; private set; }

    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true,
        ParameterSetName = "ParamSet4"
    )]
    [Parameter(Mandatory = true, ParameterSetName = "ParamSet5")]
    public List? List { get; private set; }

    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true,
        ParameterSetName = "ParamSet6"
    )]
    [Parameter(Mandatory = true, ParameterSetName = "ParamSet7")]
    public ListItem? ListItem { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet2")]
    [Parameter(Mandatory = true, ParameterSetName = "ParamSet4")]
    [Parameter(Mandatory = true, ParameterSetName = "ParamSet6")]
    public int PrincipalId { get; private set; }

    [Parameter(Mandatory = false)]
    public SwitchParameter SelectAllProperties { get; private set; } = true;

    [Parameter(Mandatory = false, ParameterSetName = "ParamSet3")]
    [Parameter(Mandatory = false, ParameterSetName = "ParamSet5")]
    [Parameter(Mandatory = false, ParameterSetName = "ParamSet7")]
    public SwitchParameter NoEnumerate { get; private set; }

    protected override async Task ProcessRecordAsync()
    {
        if (this.ParameterSetName == "ParamSet1")
        {
            _ = this.Identity ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Identity));
            this.Outputs.Add(await this.Service2.GetObjectAsync(this.Identity, this.SelectAllProperties));
        }
        if (this.ParameterSetName == "ParamSet2")
        {
            this.ValidateSwitchParameter(nameof(this.Site));
            var siteObject = await this.Service1.GetObjectAsync(this.SelectAllProperties);
            _ = siteObject ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
            this.Outputs.Add(
                await this.Service2.GetObjectAsync(
                    siteObject,
                    this.PrincipalId,
                    this.SelectAllProperties
                )
            );
        }
        if (this.ParameterSetName == "ParamSet3")
        {
            this.ValidateSwitchParameter(nameof(this.Site));
            var siteObject = await this.Service1.GetObjectAsync(this.SelectAllProperties);
            _ = siteObject ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
            if (this.NoEnumerate)
            {
                this.Outputs.Add(await this.Service2.GetObjectEnumerableAsync(siteObject, this.SelectAllProperties));
            }
            else
            {
                this.Outputs.AddRange(await this.Service2.GetObjectEnumerableAsync(siteObject, this.SelectAllProperties));
            }
        }
        if (this.ParameterSetName == "ParamSet4")
        {
            _ = this.List ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.List));
            this.Outputs.Add(
                await this.Service2.GetObjectAsync(
                    this.List,
                    this.PrincipalId,
                    this.SelectAllProperties
                )
            );
        }
        if (this.ParameterSetName == "ParamSet5")
        {
            _ = this.List ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.List));
            if (this.NoEnumerate)
            {
                this.Outputs.Add(await this.Service2.GetObjectEnumerableAsync(this.List, this.SelectAllProperties));
            }
            else
            {
                this.Outputs.AddRange(await this.Service2.GetObjectEnumerableAsync(this.List, this.SelectAllProperties));
            }
        }
        if (this.ParameterSetName == "ParamSet6")
        {
            _ = this.ListItem ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.ListItem));
            this.Outputs.Add(
                await this.Service2.GetObjectAsync(
                    this.ListItem,
                    this.PrincipalId,
                    this.SelectAllProperties
                )
            );
        }
        if (this.ParameterSetName == "ParamSet7")
        {
            _ = this.ListItem ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.ListItem));
            if (this.NoEnumerate)
            {
                this.Outputs.Add(await this.Service2.GetObjectEnumerableAsync(this.ListItem, this.SelectAllProperties));
            }
            else
            {
                this.Outputs.AddRange(await this.Service2.GetObjectEnumerableAsync(this.ListItem, this.SelectAllProperties));
            }
        }
    }

}

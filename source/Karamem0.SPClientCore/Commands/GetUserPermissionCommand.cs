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

[Cmdlet(VerbsCommon.Get, "UserPermission")]
[OutputType(typeof(BasePermission))]
public class GetUserPermissionCommand : ClientObjectCmdlet<ISiteService, IUserPermissionService>
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
    public User? User { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet1")]
    public SwitchParameter Site { get; private set; }

    [Parameter(
        Mandatory = true,
        Position = 1,
        ValueFromPipeline = true,
        ParameterSetName = "ParamSet2"
    )]
    public List? List { get; private set; }

    [Parameter(
        Mandatory = true,
        Position = 1,
        ValueFromPipeline = true,
        ParameterSetName = "ParamSet3"
    )]
    public ListItem? ListItem { get; private set; }

    protected override void ProcessRecordCore()
    {
        if (this.ParameterSetName == "ParamSet1")
        {
            this.ValidateSwitchParameter(nameof(this.Site));
            _ = this.User ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.User));
            var siteObject = this.Service1.GetObject();
            _ = siteObject ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
            this.Outputs.Add(this.Service2.GetObject(this.User, siteObject));
        }
        if (this.ParameterSetName == "ParamSet2")
        {
            _ = this.User ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.User));
            _ = this.List ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.List));
            this.Outputs.Add(this.Service2.GetObject(this.User, this.List));
        }
        if (this.ParameterSetName == "ParamSet3")
        {
            _ = this.User ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.User));
            _ = this.ListItem ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.ListItem));
            this.Outputs.Add(this.Service2.GetObject(this.User, this.ListItem));
        }
    }

}

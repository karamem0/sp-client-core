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

[Cmdlet(VerbsCommon.Get, "GroupMember")]
[OutputType(typeof(User))]
public class GetGroupMemberCommand : ClientObjectCmdlet<IGroupMemberService>
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
    public Group? Group { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet1")]
    public int MemberId { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet2")]
    public string? MemberName { get; private set; }

    [Parameter(Mandatory = false, ParameterSetName = "ParamSet3")]
    public SwitchParameter NoEnumerate { get; private set; }

    protected override void ProcessRecordCore()
    {
        if (this.ParameterSetName == "ParamSet1")
        {
            _ = this.Group ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Group));
            this.Outputs.Add(this.Service.GetObject(this.Group, this.MemberId));
        }
        if (this.ParameterSetName == "ParamSet2")
        {
            _ = this.Group ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Group));
            _ = this.MemberName ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.MemberName));
            this.Outputs.Add(this.Service.GetObject(this.Group, this.MemberName));
        }
        if (this.ParameterSetName == "ParamSet3")
        {
            _ = this.Group ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Group));
            if (this.NoEnumerate)
            {
                this.Outputs.Add(this.Service.GetObjectEnumerable(this.Group));
            }
            else
            {
                this.Outputs.AddRange(this.Service.GetObjectEnumerable(this.Group));
            }
        }
    }

}

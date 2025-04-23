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

[Cmdlet(VerbsCommon.Set, "KshLike")]
[OutputType(typeof(void))]
public class SetLikeCommand : ClientObjectCmdlet<ILikeService>
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
        ParameterSetName = "ParamSet3"
    )]
    public Comment Comment { get; private set; }

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
        ParameterSetName = "ParamSet4"
    )]
    public ListItem ListItem { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet1")]
    [Parameter(Mandatory = true, ParameterSetName = "ParamSet2")]
    public SwitchParameter Like { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet3")]
    [Parameter(Mandatory = true, ParameterSetName = "ParamSet4")]
    public SwitchParameter Unlike { get; private set; }

    protected override void ProcessRecordCore()
    {
        if (this.ParameterSetName == "ParamSet1")
        {
            this.ValidateSwitchParameter(nameof(this.Like));
            this.Service.LikeObject(this.Comment);
        }
        if (this.ParameterSetName == "ParamSet2")
        {
            this.ValidateSwitchParameter(nameof(this.Like));
            this.Service.LikeObject(this.ListItem);
        }
        if (this.ParameterSetName == "ParamSet3")
        {
            this.ValidateSwitchParameter(nameof(this.Unlike));
            this.Service.UnlikeObject(this.Comment);
        }
        if (this.ParameterSetName == "ParamSet4")
        {
            this.ValidateSwitchParameter(nameof(this.Unlike));
            this.Service.UnlikeObject(this.ListItem);
        }
    }

}

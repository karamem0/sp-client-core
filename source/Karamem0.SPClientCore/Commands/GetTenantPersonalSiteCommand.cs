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

[Cmdlet(VerbsCommon.Get, "KshTenantPersonalSite")]
[OutputType(typeof(string))]
public class GetTenantPersonalSiteCommand : ClientObjectCmdlet<ITenantPersonalSiteService>
{

    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true,
        ParameterSetName = "ParamSet1"
    )]
    public User? User { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet2")]
    public string? UserId { get; private set; }

    protected override void ProcessRecordCore()
    {
        if (this.ParameterSetName == "ParamSet1")
        {
            _ = this.User?.UserPrincipalName ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.User));
            this.Outputs.Add(this.Service.GetObject(this.User.UserPrincipalName));
        }
        if (this.ParameterSetName == "ParamSet2")
        {
            _ = this.UserId ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.UserId));
            this.Outputs.Add(this.Service.GetObject(this.UserId));
        }
    }

}

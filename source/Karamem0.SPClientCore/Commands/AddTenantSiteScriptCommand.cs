//
// Copyright (c) 2018-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Runtime.Commands;
using Karamem0.SharePoint.PowerShell.Services.V1;
using System.Management.Automation;

namespace Karamem0.SharePoint.PowerShell.Commands;

[Cmdlet(VerbsCommon.Add, "TenantSiteScript")]
[OutputType(typeof(TenantSiteScript))]
public class AddTenantSiteScriptCommand : ClientObjectCmdlet<ITenantSiteScriptService>
{

    [Parameter(Mandatory = true)]
    public string? Content { get; private set; }

    [Parameter(Mandatory = false)]
    public string? Description { get; private set; }

    [Parameter(Mandatory = true)]
    public string? Title { get; private set; }

    protected override async Task ProcessRecordAsync()
    {
        this.Outputs.Add(await this.Service.AddObjectAsync(this.MyInvocation.BoundParameters));
    }

}

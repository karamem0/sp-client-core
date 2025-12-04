//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Resources;
using Karamem0.SharePoint.PowerShell.Runtime.Commands;
using Karamem0.SharePoint.PowerShell.Services.V1;
using System.Management.Automation;

namespace Karamem0.SharePoint.PowerShell.Commands;

[Cmdlet(VerbsCommon.Get, "TenantSiteScriptFromList")]
[OutputType(typeof(string))]
public class GetTenantSiteScriptFromListCommand : ClientObjectCmdlet<ITenantSiteScriptService>
{

    [Parameter(Mandatory = true)]
    public Uri? ListUrl { get; private set; }

    protected override void ProcessRecordCore()
    {
        this.Outputs.Add(
            this.Service.GetScriptFromList(this.ListUrl ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.ListUrl)))
        );
    }

}

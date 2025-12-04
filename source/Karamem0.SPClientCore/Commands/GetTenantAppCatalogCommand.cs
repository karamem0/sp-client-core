//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Runtime.Commands;
using Karamem0.SharePoint.PowerShell.Services.V1;
using System.Management.Automation;

namespace Karamem0.SharePoint.PowerShell.Commands;

[Cmdlet(VerbsCommon.Get, "TenantAppCatalog")]
[OutputType(typeof(Uri))]
public class GetTenantAppCatalogCommand : ClientObjectCmdlet<ITenantSettingsService>
{

    protected override void ProcessRecordCore()
    {
        var tenantSettingsObject = this.Service.GetObject();
        if (tenantSettingsObject is not null)
        {
            this.Outputs.Add(tenantSettingsObject.AppCatalogUrl);
        }
    }

}

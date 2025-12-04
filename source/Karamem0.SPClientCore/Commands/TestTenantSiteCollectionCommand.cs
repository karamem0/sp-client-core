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

[Cmdlet(VerbsDiagnostic.Test, "TenantSiteCollection")]
[OutputType(typeof(bool))]
public class TestTenantSiteCollectionCommand : ClientObjectCmdlet<ITenantService>
{

    protected override void ProcessRecordCore()
    {
        try
        {
            var tenantObject = this.Service.GetObject();
            if (tenantObject is null)
            {
                this.Outputs.Add(false);
            }
            else
            {
                this.Outputs.Add(true);
            }
        }
        catch
        {
            this.Outputs.Add(false);
        }
    }

}

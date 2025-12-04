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

[Cmdlet(VerbsCommon.Get, "TenantOrganizationNewsSite")]
[OutputType(typeof(Uri))]
public class GetTenantOrganizationNewsSiteCommand : ClientObjectCmdlet<ITenantOrganizationNewsSiteService>
{

    [Parameter(Mandatory = false)]
    public SwitchParameter NoEnumerate { get; private set; }

    protected override void ProcessRecordCore()
    {
        if (this.NoEnumerate)
        {
            this.Outputs.Add(this.Service.GetObjectEnumerable());
        }
        else
        {
            this.Outputs.AddRange(this.Service.GetObjectEnumerable());
        }
    }

}

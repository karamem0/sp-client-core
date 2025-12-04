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

[Cmdlet(VerbsCommon.Add, "TenantOrganizationNewsSite")]
[OutputType(typeof(void))]
public class AddTenantOrganizationNewsSiteCommand : ClientObjectCmdlet<ITenantOrganizationNewsSiteService>
{

    [Parameter(Mandatory = true)]
    public Uri? Url { get; private set; }

    protected override void ProcessRecordCore()
    {
        _ = this.Url ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Url));
        this.Service.AddObject(this.Url);
    }

}

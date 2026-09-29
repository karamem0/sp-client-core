//
// Copyright (c) 2018-2026 karamem0
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

[Cmdlet(VerbsCommon.Set, "Subscription")]
[OutputType(typeof(Subscription))]
public class SetSubscriptionCommand : ClientObjectCmdlet<ISubscriptionService>
{

    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true
    )]
    public Subscription? Identity { get; private set; }

    [Parameter(Mandatory = false)]
    public DateTime ExpirationDateTime { get; private set; }

    [Parameter(Mandatory = false)]
    public Uri? NotificationUrl { get; private set; }

    [Parameter(Mandatory = false)]
    public SwitchParameter PassThru { get; private set; }

    [Parameter(Mandatory = false)]
    public SwitchParameter SelectAllProperties { get; private set; } = true;

    protected override async Task ProcessRecordAsync()
    {
        _ = this.Identity ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Identity));
        await this.Service.SetObjectAsync(this.Identity, this.MyInvocation.BoundParameters);
        if (this.PassThru)
        {
            this.Outputs.Add(await this.Service.GetObjectAsync(this.Identity, this.SelectAllProperties));
        }
    }

}

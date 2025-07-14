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

[Cmdlet(VerbsCommon.Add, "KshSubscription")]
[OutputType(typeof(Subscription))]
public class AddSubscriptionCommand : ClientObjectCmdlet<ISubscriptionService>
{

    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true
    )]
    public List? List { get; private set; }

    [Parameter(Mandatory = false)]
    public string? ClientState { get; private set; }

    [Parameter(Mandatory = true)]
    public DateTime ExpirationDateTime { get; private set; }

    [Parameter(Mandatory = true)]
    public Uri? NotificationUrl { get; private set; }

    protected override void ProcessRecordCore()
    {
        _ = this.List ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.List));
        this.Outputs.Add(this.Service.AddObject(this.List, this.MyInvocation.BoundParameters));
    }

}

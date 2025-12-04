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
using System.Management.Automation;

namespace Karamem0.SharePoint.PowerShell.Commands;

[Cmdlet(VerbsCommon.Add, "Alert")]
[OutputType(typeof(Alert))]
public class AddAlertCommand : ClientObjectCmdlet<IAlertService>
{

    [Parameter(Mandatory = false)]
    public AlertFrequency AlertFrequency { get; private set; }

    [Parameter(Mandatory = false)]
    public string? AlertTemplateName { get; private set; }

    [Parameter(Mandatory = false)]
    public DateTime AlertTime { get; private set; }

    [Parameter(Mandatory = false)]
    public AlertType AlertType { get; private set; }

    [Parameter(Mandatory = false)]
    public bool AlwaysNotify { get; private set; }

    [Parameter(Mandatory = false)]
    public AlertDeliveryChannel DeliveryChannels { get; private set; }

    [Parameter(Mandatory = false)]
    public AlertEventType EventType { get; private set; }

    [Parameter(Mandatory = false)]
    public int EventTypeBitmask { get; private set; }

    [Parameter(Mandatory = false)]
    public string? Filter { get; private set; }

    [Parameter(Mandatory = true)]
    public List? List { get; private set; }

    [Parameter(Mandatory = false)]
    public ListItem? ListItem { get; private set; }

    [Parameter(Mandatory = false)]
    public IReadOnlyDictionary<string, string>? Properties { get; private set; }

    [Parameter(Mandatory = false)]
    public AlertStatus Status { get; private set; }

    [Parameter(Mandatory = false)]
    public string? Title { get; private set; }

    [Parameter(Mandatory = true)]
    public User? User { get; private set; }

    protected override void ProcessRecordCore()
    {
        this.Outputs.Add(this.Service.GetObject(this.Service.AddObject(this.MyInvocation.BoundParameters)));
    }

}

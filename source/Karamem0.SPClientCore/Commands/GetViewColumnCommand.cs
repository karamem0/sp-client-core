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
using System.Management.Automation;

namespace Karamem0.SharePoint.PowerShell.Commands;

[Cmdlet(VerbsCommon.Get, "ViewColumn")]
[OutputType(typeof(string))]
public class GetViewColumnCommand : ClientObjectCmdlet<IViewColumnService>
{

    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true
    )]
    public View? View { get; private set; }

    [Parameter(Mandatory = false)]
    public SwitchParameter NoEnumerate { get; private set; }

    protected override void ProcessRecordCore()
    {
        _ = this.View ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.View));
        if (this.NoEnumerate)
        {
            this.Outputs.Add(this.Service.GetObjectEnumerable(this.View));
        }
        else
        {
            this.Outputs.AddRange(this.Service.GetObjectEnumerable(this.View));
        }
    }

}

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

[Cmdlet(VerbsCommon.Remove, "Highlight")]
[OutputType(typeof(HighlightResult))]
public class RemoveHighlightCommand : ClientObjectCmdlet<IHighlightService>
{

    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true
    )]
    public View? View { get; private set; }

    [Parameter(Mandatory = true)]
    public int ItemId { get; private set; }

    [Parameter(Mandatory = true)]
    public string? FolderPath { get; private set; }

    protected override void ProcessRecordCore()
    {
        _ = this.View ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.View));
        _ = this.FolderPath ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.FolderPath));
        this.Outputs.Add(
            this.Service.RemoveObject(
                this.View,
                this.ItemId,
                this.FolderPath
            )
        );
    }

}

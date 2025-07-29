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

[Cmdlet(VerbsCommon.Add, "KshHighlight")]
[OutputType(typeof(HighlightResult))]
public class AddHighlightCommand : ClientObjectCmdlet<IHighlightService>
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

    [Parameter(Mandatory = false)]
    public int AfterItemId { get; private set; }

    protected override void ProcessRecordCore()
    {
        _ = this.View ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.View));
        _ = this.FolderPath ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.FolderPath));
        if (this.AfterItemId == default)
        {
            this.AfterItemId = -1;
        }
        this.Outputs.Add(
            this.Service.AddObject(
                this.View,
                this.ItemId,
                this.FolderPath,
                this.AfterItemId
            )
        );
    }

}

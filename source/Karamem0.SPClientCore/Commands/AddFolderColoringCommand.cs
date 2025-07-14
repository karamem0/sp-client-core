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
using Karamem0.SharePoint.PowerShell.Runtime.Common;
using Karamem0.SharePoint.PowerShell.Services.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands;

[Cmdlet(VerbsCommon.Add, "KshFolderColoring")]
[OutputType(typeof(Folder))]
public class AddFolderColoringCommand : ClientObjectCmdlet<IFolderColoringService, IFolderService>
{

    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true
    )]
    public Folder? Folder { get; private set; }

    [Parameter(Mandatory = true)]
    public string? FolderName { get; private set; }

    [Parameter(Mandatory = false)]
    public string? ColorHex { get; private set; }

    [Parameter(Mandatory = false)]
    public string? ColorTag { get; private set; }

    [Parameter(Mandatory = false)]
    public string? Emoji { get; private set; }

    [Parameter(Mandatory = false)]
    public bool Overwrite { get; private set; }

    protected override void ProcessRecordCore()
    {
        _ = this.Folder?.ServerRelativeUrl ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Folder));
        _ = this.FolderName ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.FolderName));
        this.Service1.AddObject(
            this.Folder.ServerRelativeUrl,
            this.FolderName,
            this.Overwrite,
            this.MyInvocation.BoundParameters
        );
        this.Outputs.Add(this.Service2.GetObject(this.Folder.ServerRelativeUrl.ConcatPath(this.FolderName)));
    }

}

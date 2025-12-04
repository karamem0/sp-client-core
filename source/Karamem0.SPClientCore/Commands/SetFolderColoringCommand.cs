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

[Cmdlet(VerbsCommon.Set, "FolderColoring")]
[OutputType(typeof(Folder))]
public class SetFolderColoringCommand : ClientObjectCmdlet<IFolderColoringService, IFolderService>
{

    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true
    )]
    public Folder? Identity { get; private set; }

    [Parameter(Mandatory = false)]
    public string? ColorHex { get; private set; }

    [Parameter(Mandatory = false)]
    public string? ColorTag { get; private set; }

    [Parameter(Mandatory = false)]
    public string? Emoji { get; private set; }

    [Parameter(Mandatory = false)]
    public SwitchParameter PassThru { get; private set; }

    protected override void ProcessRecordCore()
    {
        _ = this.Identity?.ServerRelativeUrl ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Identity));
        this.Service1.SetObject(this.Identity.ServerRelativeUrl, this.MyInvocation.BoundParameters);
        if (this.PassThru)
        {
            this.Outputs.Add(this.Service2.GetObject(this.Identity));
        }
    }

}

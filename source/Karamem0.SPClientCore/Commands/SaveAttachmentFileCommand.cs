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

[Cmdlet(VerbsData.Save, "AttachmentFile")]
[OutputType(typeof(AttachmentFile))]
public class SaveAttachmentFileCommand : ClientObjectCmdlet<IAttachmentFileService>
{

    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true
    )]
    public ListItem? ListItem { get; private set; }

    [Parameter(Mandatory = true)]
    public System.IO.Stream? Content { get; private set; }

    [Parameter(Mandatory = true)]
    public string? FileName { get; private set; }

    [Parameter(Mandatory = true)]
    public SwitchParameter PassThru { get; private set; }

    protected override void ProcessRecordCore()
    {
        _ = this.ListItem ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.ListItem));
        _ = this.FileName ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.FileName));
        _ = this.Content ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Content));
        this.Service.UploadObject(
            this.ListItem,
            this.FileName,
            this.Content
        );
        if (this.PassThru)
        {
            this.Outputs.Add(this.Service.GetObject(this.ListItem, this.FileName));
        }
    }

}

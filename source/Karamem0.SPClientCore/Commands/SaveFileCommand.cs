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

[Cmdlet(VerbsData.Save, "File")]
[OutputType(typeof(File))]
public class SaveFileCommand : ClientObjectCmdlet<IFileService>
{

    [Parameter(Mandatory = true)]
    public Folder? Folder { get; private set; }

    [Parameter(Mandatory = true)]
    public System.IO.Stream? Content { get; private set; }

    [Parameter(Mandatory = true)]
    public string? FileName { get; private set; }

    [Parameter(Mandatory = false)]
    public bool Overwrite { get; private set; }

    [Parameter(Mandatory = false)]
    public SwitchParameter PassThru { get; private set; }

    protected override async Task ProcessRecordAsync()
    {
        _ = this.Folder?.ServerRelativeUrl ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Folder));
        _ = this.FileName ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.FileName));
        _ = this.Content ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Content));
        await this.Service.UploadObjectAsync(
            this.Folder.ServerRelativeUrl,
            this.FileName,
            this.Content,
            this.Overwrite
        );
        if (this.PassThru)
        {
            this.Outputs.Add(await this.Service.GetObjectAsync(this.Folder, this.FileName));
        }
    }

}

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

[Cmdlet(VerbsData.Save, "KshFile")]
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

    protected override void ProcessRecordCore()
    {
        _ = this.Folder?.ServerRelativeUrl ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Folder));
        _ = this.FileName ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.FileName));
        _ = this.Content ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Content));
        this.Service.UploadObject(
            this.Folder.ServerRelativeUrl,
            this.FileName,
            this.Content,
            this.Overwrite
        );
        if (this.PassThru)
        {
            this.Outputs.Add(this.Service.GetObject(this.Folder, this.FileName));
        }
    }

}

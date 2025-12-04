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

[Cmdlet(VerbsCommon.Set, "FilePublished")]
[OutputType(typeof(File))]
public class SetFilePublishedCommand : ClientObjectCmdlet<IFileService>
{

    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true
    )]
    public File? File { get; private set; }

    [Parameter(Mandatory = true)]
    public bool Published { get; private set; }

    [Parameter(Mandatory = false)]
    public string? Comment { get; private set; }

    [Parameter(Mandatory = false)]
    public SwitchParameter PassThru { get; private set; }

    protected override void ProcessRecordCore()
    {
        if (this.Published)
        {
            _ = this.File ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.File));
            this.Service.PublishObject(this.File, this.Comment);
        }
        else
        {
            _ = this.File ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.File));
            this.Service.UnpublishObject(this.File, this.Comment);
        }
        if (this.PassThru)
        {
            this.Outputs.Add(this.Service.GetObject(this.File));
        }
    }

}

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

[Cmdlet(VerbsCommon.Add, "File")]
[OutputType(typeof(File))]
public class AddFileCommand : ClientObjectCmdlet<IFileService>
{

    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true
    )]
    public Folder? Folder { get; private set; }

    [Parameter(Mandatory = true)]
    public byte[]? Content { get; private set; }

    [Parameter(Mandatory = true)]
    public string? FileName { get; private set; }

    [Parameter(Mandatory = false)]
    public bool Overwrite { get; private set; }

    protected override void ProcessRecordCore()
    {
        _ = this.Folder ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Folder));
        this.Outputs.Add(this.Service.AddObject(this.Folder, this.MyInvocation.BoundParameters));
    }

}

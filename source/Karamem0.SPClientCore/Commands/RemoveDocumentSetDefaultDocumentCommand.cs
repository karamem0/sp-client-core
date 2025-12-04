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

[Cmdlet(
    VerbsCommon.Remove,
    "DocumentSetDefaultDocument",
    SupportsShouldProcess = true,
    ConfirmImpact = ConfirmImpact.High
)]
[OutputType(typeof(void))]
public class RemoveDocumentSetDefaultDocumentCommand : ClientObjectCmdlet<IDocumentSetDefaultDocumentService>
{

    [Parameter(Mandatory = true, Position = 0)]
    public ContentType? ContentType { get; private set; }

    [Parameter(Mandatory = true, Position = 1)]
    public string? FileName { get; private set; }

    [Parameter(Mandatory = false)]
    public SwitchParameter PushChanges { get; private set; }

    protected override void ProcessRecordCore()
    {
        if (this.ShouldProcess(this.FileName, VerbsCommon.Remove))
        {
            _ = this.ContentType ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.ContentType));
            _ = this.FileName ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.FileName));
            this.Service.RemoveObject(
                this.ContentType,
                this.FileName,
                this.PushChanges
            );
        }
    }

}

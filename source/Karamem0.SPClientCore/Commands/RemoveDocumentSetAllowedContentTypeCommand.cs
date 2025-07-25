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

[Cmdlet(
    VerbsCommon.Remove,
    "KshDocumentSetAllowedContentType",
    SupportsShouldProcess = true,
    ConfirmImpact = ConfirmImpact.High
)]
[OutputType(typeof(void))]
public class RemoveDocumentSetAllowedContentTypeCommand : ClientObjectCmdlet<IDocumentSetAllowedContentTypeService>
{

    [Parameter(Mandatory = true, Position = 0)]
    public ContentType? ContentType { get; private set; }

    [Parameter(Mandatory = true, Position = 1)]
    public ContentType? AllowedContentType { get; private set; }

    [Parameter(Mandatory = false)]
    public SwitchParameter PushChanges { get; private set; }

    protected override void ProcessRecordCore()
    {
        _ = this.ContentType ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.ContentType));
        _ = this.AllowedContentType ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.AllowedContentType));
        if (this.ShouldProcess(this.AllowedContentType.Name, VerbsCommon.Remove))
        {
            this.Service.RemoveObject(
                this.ContentType,
                this.AllowedContentType,
                this.PushChanges
            );
        }
    }

}

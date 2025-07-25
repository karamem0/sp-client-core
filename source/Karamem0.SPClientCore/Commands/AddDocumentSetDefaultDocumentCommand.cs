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

[Cmdlet(VerbsCommon.Add, "KshDocumentSetDefaultDocument")]
[OutputType(typeof(DefaultDocument))]
public class AddDocumentSetDefaultDocumentCommand : ClientObjectCmdlet<IDocumentSetDefaultDocumentService>
{

    [Parameter(Mandatory = true)]
    public ContentType? ContentType { get; private set; }

    [Parameter(Mandatory = true)]
    public ContentType? DocumentContentType { get; private set; }

    [Parameter(Mandatory = true)]
    public byte[]? Content { get; private set; }

    [Parameter(Mandatory = true)]
    public string? FileName { get; private set; }

    [Parameter(Mandatory = false)]
    public SwitchParameter PushChanges { get; private set; }

    protected override void ProcessRecordCore()
    {
        _ = this.ContentType ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.ContentType));
        _ = this.DocumentContentType ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.DocumentContentType));
        _ = this.FileName ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.FileName));
        _ = this.Content ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Content));
        this.Outputs.Add(
            this.Service.AddObject(
                this.ContentType,
                this.DocumentContentType,
                this.FileName,
                this.Content,
                this.PushChanges
            )
        );
    }

}

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

[Cmdlet(VerbsCommon.Add, "KshDocument")]
[OutputType(typeof(ListItem))]
public class AddDocumentCommand : ClientObjectCmdlet<IDocumentService, IListService>
{

    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true
    )]
    public Folder? Folder { get; private set; }

    [Parameter(Mandatory = true, Position = 1)]
    public string? FileName { get; private set; }

    [Parameter(Mandatory = true, Position = 2)]
    public DocumentTemplateType DocumentTemplateType { get; private set; }

    protected override void ProcessRecordCore()
    {
        _ = this.Folder ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Folder));
        _ = this.FileName ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.FileName));
        var listObject = this.Service2.GetObject(this.Folder);
        _ = listObject ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
        this.Outputs.Add(
            this.Service1.AddObject(
                listObject,
                this.FileName,
                this.Folder,
                this.DocumentTemplateType
            )
        );
    }

}

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

[Cmdlet(VerbsCommon.Add, "ContentTypeColumn")]
[OutputType(typeof(ContentTypeColumn))]
public class AddContentTypeColumnCommand : ClientObjectCmdlet<IContentTypeColumnService>
{

    [Parameter(Mandatory = true)]
    public ContentType? ContentType { get; private set; }

    [Parameter(Mandatory = true)]
    public Column? Column { get; private set; }

    [Parameter(Mandatory = false)]
    public SwitchParameter PushChanges { get; private set; }

    protected override void ProcessRecordCore()
    {
        _ = this.ContentType ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.ContentType));
        this.Outputs.Add(
            this.Service.AddObject(
                this.ContentType,
                this.MyInvocation.BoundParameters,
                this.PushChanges
            )
        );
    }

}

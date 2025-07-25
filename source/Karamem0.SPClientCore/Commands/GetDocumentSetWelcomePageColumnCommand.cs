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

[Cmdlet(VerbsCommon.Get, "KshDocumentSetWelcomePageColumn")]
[OutputType(typeof(Column))]
public class GetDocumentSetWelcomePageColumnCommand : ClientObjectCmdlet<IDocumentSetWelcomePageColumnService>
{

    [Parameter(Mandatory = true, Position = 0)]
    public ContentType? ContentType { get; private set; }

    [Parameter(Mandatory = false)]
    public SwitchParameter NoEnumerate { get; private set; }

    protected override void ProcessRecordCore()
    {
        _ = this.ContentType ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.ContentType));
        if (this.NoEnumerate)
        {
            this.Outputs.Add(this.Service.GetObjectEnumerable(this.ContentType));
        }
        else
        {
            this.Outputs.AddRange(this.Service.GetObjectEnumerable(this.ContentType));
        }
    }

}

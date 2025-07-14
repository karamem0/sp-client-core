//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Runtime.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands;

[Cmdlet(VerbsCommon.New, "KshColumnUrlValue")]
[OutputType(typeof(ColumnUserValue))]
public class NewColumnUrlValueCommand : ClientObjectCmdlet
{

    [Parameter(Mandatory = true, Position = 0)]
    public Uri? Url { get; private set; }

    [Parameter(Mandatory = false, Position = 1)]
    public string? Description { get; private set; }

    protected override void ProcessRecordCore()
    {
        this.Outputs.Add(new ColumnUrlValue(this.Url, this.Description));
    }

}

//
// Copyright (c) 2018-2024 karamem0
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

[Cmdlet(VerbsCommon.New, "KshColumnLookupValue")]
[OutputType(typeof(ColumnLookupValue))]
public class NewColumnLookupValueCommand : ClientObjectCmdlet
{

    public NewColumnLookupValueCommand()
    {
    }

    [Parameter(Mandatory = true, Position = 0)]
    public int LookupId { get; private set; }

    [Parameter(Mandatory = false, Position = 1)]
    public string LookupValue { get; private set; }

    protected override void ProcessRecordCore()
    {
        this.Outputs.Add(new ColumnLookupValue(this.LookupId, this.LookupValue));
    }

}

//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Runtime.Commands;
using System.Management.Automation;

namespace Karamem0.SharePoint.PowerShell.Commands;

[Cmdlet(VerbsCommon.New, "ColumnLookupValue")]
[OutputType(typeof(ColumnLookupValue))]
public class NewColumnLookupValueCommand : ClientObjectCmdlet
{

    [Parameter(Mandatory = true, Position = 0)]
    public int LookupId { get; private set; }

    [Parameter(Mandatory = false, Position = 1)]
    public string? LookupValue { get; private set; }

    protected override void ProcessRecordCore()
    {
        this.Outputs.Add(new ColumnLookupValue(this.LookupId, this.LookupValue));
    }

}

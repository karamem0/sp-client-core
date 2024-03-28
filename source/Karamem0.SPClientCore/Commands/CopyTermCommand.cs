//
// Copyright (c) 2018-2024 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Runtime.Commands;
using Karamem0.SharePoint.PowerShell.Services.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands;

[Cmdlet(VerbsCommon.Copy, "KshTerm")]
[OutputType(typeof(Term))]
public class CopyTermCommand : ClientObjectCmdlet<ITermService>
{

    public CopyTermCommand()
    {
    }

    [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
    public Term Identity { get; private set; }

    [Parameter(Mandatory = false)]
    public SwitchParameter CopyChildren { get; private set; }

    protected override void ProcessRecordCore()
    {
        this.Outputs.Add(this.Service.CopyObject(this.Identity, this.CopyChildren));
    }

}

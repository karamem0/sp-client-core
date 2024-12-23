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

[Cmdlet(VerbsCommon.Remove, "KshTermGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
[OutputType(typeof(void))]
public class RemoveTermGroupCommand : ClientObjectCmdlet<ITermGroupService>
{

    public RemoveTermGroupCommand()
    {
    }

    [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
    public TermGroup Identity { get; private set; }

    protected override void ProcessRecordCore()
    {
        if (this.ShouldProcess(this.Identity.Name, VerbsCommon.Remove))
        {
            this.Service.RemoveObject(this.Identity);
        }
    }

}

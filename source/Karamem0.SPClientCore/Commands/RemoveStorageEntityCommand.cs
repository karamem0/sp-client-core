//
// Copyright (c) 2018-2024 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Runtime.Commands;
using Karamem0.SharePoint.PowerShell.Services.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands;

[Cmdlet(VerbsCommon.Remove, "KshStorageEntity", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
[OutputType(typeof(void))]
public class RemoveStorageEntityCommand : ClientObjectCmdlet<IStorageEntityService>
{

    public RemoveStorageEntityCommand()
    {
    }

    [Parameter(Mandatory = true, Position = 0)]
    public string Key { get; private set; }

    protected override void ProcessRecordCore()
    {
        if (this.ShouldProcess(this.Key, VerbsCommon.Remove))
        {
            this.Service.RemoveObject(this.Key);
        }
    }

}

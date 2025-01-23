//
// Copyright (c) 2018-2025 karamem0
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

[Cmdlet(VerbsCommon.Set, "KshTenantHomeSite")]
[OutputType(typeof(void))]
public class SetTenantHomeSiteCommand : ClientObjectCmdlet<ITenantHomeSiteService>
{

    [Parameter(Mandatory = true)]
    public string Url { get; private set; }

    [Parameter(Mandatory = false)]
    public SwitchParameter PassThru { get; private set; }

    protected override void ProcessRecordCore()
    {
        this.Service.SetObject(this.Url);
        if (this.PassThru)
        {
            this.Outputs.Add(this.Service.GetObject());
        }
    }

}

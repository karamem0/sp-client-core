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

[Cmdlet(VerbsCommon.Add, "KshTenantApp")]
[OutputType(typeof(App))]
public class AddTenantAppCommand : ClientObjectCmdlet<ITenantAppService>
{

    public AddTenantAppCommand()
    {
    }

    [Parameter(Mandatory = true)]
    public System.IO.Stream Content { get; private set; }

    [Parameter(Mandatory = true)]
    public string FileName { get; private set; }

    [Parameter(Mandatory = false)]
    public bool Overwrite { get; private set; }

    protected override void ProcessRecordCore()
    {
        this.Outputs.Add(this.Service.AddObject(this.Content, this.FileName, this.Overwrite));
    }

}

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

[Cmdlet(VerbsCommon.Get, "KshTenantSiteScriptFromList")]
[OutputType(typeof(string))]
public class GetTenantSiteScriptFromListCommand : ClientObjectCmdlet<ITenantSiteScriptService>
{

    public GetTenantSiteScriptFromListCommand()
    {
    }

    [Parameter(Mandatory = true, Position = 0)]
    public string ListUrl { get; private set; }

    protected override void ProcessRecordCore()
    {
        this.Outputs.Add(this.Service.GetScriptFromList(this.ListUrl));
    }

}
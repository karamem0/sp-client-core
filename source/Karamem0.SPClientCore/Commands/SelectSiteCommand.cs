//
// Copyright (c) 2018-2025 karamem0
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

[Cmdlet(VerbsCommon.Select, "KshSite")]
[OutputType(typeof(Site))]
public class SelectSiteCommand : ClientObjectCmdlet<ISiteService>
{

    [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
    public Site Identity { get; private set; }

    [Parameter(Mandatory = false)]
    public SwitchParameter PassThru { get; private set; }

    protected override void ProcessRecordCore()
    {
        this.Service.SelectObject(this.Identity);
        if (this.PassThru)
        {
            this.Outputs.Add(this.Identity);
        }
    }

}

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

[Cmdlet(VerbsCommon.Lock, "KshTenantSiteCollection")]
[OutputType(typeof(TenantSiteCollection))]
public class LockTenantSiteCollectionCommand : ClientObjectCmdlet<ITenantSiteCollectionService>
{

    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true,
        ParameterSetName = "ParamSet1"
    )]
    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true,
        ParameterSetName = "ParamSet2"
    )]
    public TenantSiteCollection Identity { get; private set; }

    [Parameter(Mandatory = false, ParameterSetName = "ParamSet1")]
    public SwitchParameter PassThru { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet2")]
    public SwitchParameter NoWait { get; private set; }

    protected override void ProcessRecordCore()
    {
        if (this.ParameterSetName == "ParamSet1")
        {
            this.Service.LockObjectAwait(this.Identity);
            var clientObject = this.Service.GetObjectAwait(this.Identity);
            if (this.PassThru)
            {
                this.Outputs.Add(clientObject);
            }
        }
        if (this.ParameterSetName == "ParamSet2")
        {
            this.ValidateSwitchParameter(nameof(this.NoWait));
            _ = this.Service.LockObject(this.Identity);
        }
    }

}

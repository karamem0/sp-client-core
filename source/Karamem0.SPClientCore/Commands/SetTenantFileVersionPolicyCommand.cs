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
using System.Management.Automation;

namespace Karamem0.SharePoint.PowerShell.Commands;

[Cmdlet(VerbsCommon.Set, "TenantFileVersionPolicy")]
[OutputType(typeof(FileVersionPolicy))]
public class SetTenantFileVersionPolicyCommand : ClientObjectCmdlet<ITenantService, ITenantFileVersionPolicyService>
{

    [Parameter(Mandatory = true)]
    public bool IsAutoTrimEnabled { get; private set; }

    [Parameter(Mandatory = true)]
    public int MajorVersionLimit { get; private set; }

    [Parameter(Mandatory = true)]
    public int ExpireVersionsAfterDays { get; private set; }

    [Parameter(Mandatory = false)]
    public SwitchParameter PassThru { get; private set; }

    protected override void ProcessRecordCore()
    {
        this.Service2.SetObject(
            this.IsAutoTrimEnabled,
            this.MajorVersionLimit,
            this.ExpireVersionsAfterDays
        );
        if (this.PassThru)
        {
            this.Outputs.Add(new FileVersionPolicy(this.Service1.GetObject()));
        }
    }

}

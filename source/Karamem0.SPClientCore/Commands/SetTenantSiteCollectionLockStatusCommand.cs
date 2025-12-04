//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Resources;
using Karamem0.SharePoint.PowerShell.Runtime.Commands;
using Karamem0.SharePoint.PowerShell.Services.V1;
using System.Management.Automation;

namespace Karamem0.SharePoint.PowerShell.Commands;

[Cmdlet(VerbsCommon.Set, "TenantSiteCollectionLockStatus")]
[OutputType(typeof(TenantSiteCollection))]
public class SetTenantSiteCollectionLockStatusCommand : ClientObjectCmdlet<ITenantSiteCollectionService>
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
    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true,
        ParameterSetName = "ParamSet3"
    )]
    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true,
        ParameterSetName = "ParamSet4"
    )]
    public TenantSiteCollection? Identity { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet1")]
    [Parameter(Mandatory = true, ParameterSetName = "ParamSet2")]
    public SwitchParameter Lock { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet3")]
    [Parameter(Mandatory = true, ParameterSetName = "ParamSet4")]
    public SwitchParameter Unlock { get; private set; }

    [Parameter(Mandatory = false, ParameterSetName = "ParamSet1")]
    [Parameter(Mandatory = false, ParameterSetName = "ParamSet3")]
    public SwitchParameter PassThru { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet2")]
    [Parameter(Mandatory = true, ParameterSetName = "ParamSet4")]
    public SwitchParameter NoWait { get; private set; }

    protected override void ProcessRecordCore()
    {
        if (this.ParameterSetName == "ParamSet1")
        {
            this.ValidateSwitchParameter(nameof(this.Lock));
            _ = this.Identity ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Identity));
            this.Service.LockObjectAwait(this.Identity);
            var siteCollectionObject = this.Service.GetObjectAwait(this.Identity);
            _ = siteCollectionObject ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
            if (this.PassThru)
            {
                this.Outputs.Add(siteCollectionObject);
            }
        }
        if (this.ParameterSetName == "ParamSet2")
        {
            this.ValidateSwitchParameter(nameof(this.Lock));
            this.ValidateSwitchParameter(nameof(this.NoWait));
            _ = this.Identity ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Identity));
            _ = this.Service.LockObject(this.Identity);
        }
        if (this.ParameterSetName == "ParamSet3")
        {
            this.ValidateSwitchParameter(nameof(this.Unlock));
            _ = this.Identity ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Identity));
            this.Service.UnlockObjectAwait(this.Identity);
            var siteCollectionObject = this.Service.GetObjectAwait(this.Identity);
            _ = siteCollectionObject ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
            if (this.PassThru)
            {
                this.Outputs.Add(siteCollectionObject);
            }
        }
        if (this.ParameterSetName == "ParamSet4")
        {
            this.ValidateSwitchParameter(nameof(this.Unlock));
            this.ValidateSwitchParameter(nameof(this.NoWait));
            _ = this.Identity ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Identity));
            _ = this.Service.UnlockObject(this.Identity);
        }
    }

}

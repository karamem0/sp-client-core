//
// Copyright (c) 2021 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models;
using Karamem0.SharePoint.PowerShell.Runtime.Commands;
using Karamem0.SharePoint.PowerShell.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands
{

    [Cmdlet("Set", "KshTenant")]
    [OutputType(typeof(void))]
    public class SetTenantCommand : ClientObjectCmdlet<ITenantService>
    {

        public SetTenantCommand()
        {
        }

        [Parameter(Mandatory = false)]
        public bool DisplayStartASiteOption { get; private set; }

        [Parameter(Mandatory = false)]
        public bool ExternalServicesEnabled { get; private set; }

        // [Parameter(Mandatory = false)]
        // public int MaxCompatibilityLevel { get; private set; }

        // [Parameter(Mandatory = false)]
        // public int MinCompatibilityLevel { get; private set; }

        [Parameter(Mandatory = false)]
        public string NoAccessRedirectUrl { get; private set; }

        [Parameter(Mandatory = false)]
        public bool OfficeClientAdalDisabled { get; private set; }

        [Parameter(Mandatory = false)]
        public bool ProvisionSharedWithEveryoneFolder { get; private set; }

        [Parameter(Mandatory = false)]
        public bool RequireAcceptingAccountMatchInvitedAccount { get; private set; }

        [Parameter(Mandatory = false)]
        public bool SearchResolveExactEmailOrUpn { get; private set; }

        [Parameter(Mandatory = false)]
        public SharingCapabilities SharingCapability { get; private set; }

        [Parameter(Mandatory = false)]
        public bool ShowAllUsersClaim { get; private set; }

        [Parameter(Mandatory = false)]
        public bool ShowEveryoneClaim { get; private set; }

        [Parameter(Mandatory = false)]
        public bool ShowEveryoneExceptExternalUsersClaim { get; private set; }

        [Parameter(Mandatory = false)]
        public string SignInAccelerationDomain { get; private set; }

        [Parameter(Mandatory = false)]
        public string StartASiteFormUrl { get; private set; }

        [Parameter(Mandatory = false)]
        public bool UsePersistentCookiesForExplorerView { get; private set; }

        protected override void ProcessRecordCore()
        {
            this.Service.UpdateObject(this.MyInvocation.BoundParameters);
        }

    }

}

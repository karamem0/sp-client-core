//
// Copyright (c) 2021 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
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

    [Cmdlet("Remove", "KshTenantUser")]
    [OutputType(typeof(void))]
    public class RemoveTenantUserCommand : ClientObjectCmdlet<ITenantUserService>
    {

        public RemoveTenantUserCommand()
        {
        }

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "ParamSet1")]
        public TenantSiteCollection SiteCollection { get; private set; }

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "ParamSet2")]
        public Uri SiteCollectionUrl { get; private set; }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = "ParamSet1")]
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = "ParamSet2")]
        public User User { get; private set; }

        protected override void ProcessRecordCore(ref List<object> outputs)
        {
            if (this.ParameterSetName == "ParamSet1")
            {
                this.Service.RemoveObject(new Uri(this.SiteCollection.Url, UriKind.Absolute), this.User);
            }
            if (this.ParameterSetName == "ParamSet2")
            {
                this.Service.RemoveObject(this.SiteCollectionUrl, this.User);
            }
        }

    }

}

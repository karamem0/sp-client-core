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

    [Cmdlet("Update", "KshTenantUser")]
    [OutputType(typeof(User))]
    public class UpdateTenantUserCommand : ClientObjectCmdlet<ITenantUserService>
    {

        public UpdateTenantUserCommand()
        {
        }

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "ParamSet1")]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "ParamSet2")]
        public TenantSiteCollection SiteCollection { get; private set; }

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "ParamSet3")]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "ParamSet4")]
        public Uri SiteCollectionUrl { get; private set; }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = "ParamSet1")]
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = "ParamSet3")]
        public User User { get; private set; }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = "ParamSet2")]
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = "ParamSet4")]
        public string UserName { get; private set; }

        [Parameter(Mandatory = true)]
        public bool IsSiteCollectionAdmin { get; private set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; private set; }

        protected override void ProcessRecordCore(ref List<object> outputs)
        {
            if (this.ParameterSetName == "ParamSet1")
            {
                this.Service.UpdateObject(new Uri(this.SiteCollection.Url, UriKind.Absolute), this.User, this.IsSiteCollectionAdmin);
                if (this.PassThru)
                {
                    outputs.Add(this.Service.GetObject(new Uri(this.SiteCollection.Url, UriKind.Absolute), this.User.LoginName));
                }
            }
            if (this.ParameterSetName == "ParamSet2")
            {
                this.Service.UpdateObject(new Uri(this.SiteCollection.Url, UriKind.Absolute), this.UserName, this.IsSiteCollectionAdmin);
                if (this.PassThru)
                {
                    outputs.Add(this.Service.GetObject(new Uri(this.SiteCollection.Url, UriKind.Absolute), this.UserName));
                }
            }
            if (this.ParameterSetName == "ParamSet3")
            {
                this.Service.UpdateObject(this.SiteCollectionUrl, this.User, this.IsSiteCollectionAdmin);
                if (this.PassThru)
                {
                    outputs.Add(this.Service.GetObject(this.SiteCollectionUrl, this.User.LoginName));
                }
            }
            if (this.ParameterSetName == "ParamSet4")
            {
                this.Service.UpdateObject(this.SiteCollectionUrl, this.UserName, this.IsSiteCollectionAdmin);
                if (this.PassThru)
                {
                    outputs.Add(this.Service.GetObject(this.SiteCollectionUrl, this.UserName));
                }
            }
        }

    }

}

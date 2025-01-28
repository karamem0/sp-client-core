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

[Cmdlet(VerbsCommon.Set, "KshTenantUser")]
[OutputType(typeof(User))]
public class SetTenantUserCommand : ClientObjectCmdlet<ITenantUserService>
{

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

    protected override void ProcessRecordCore()
    {
        if (this.ParameterSetName == "ParamSet1")
        {
            this.Service.SetObject(
                new Uri(this.SiteCollection.Url, UriKind.Absolute),
                this.User,
                this.IsSiteCollectionAdmin
            );
            if (this.PassThru)
            {
                this.Outputs.Add(
                    this.Service.GetObject(new Uri(this.SiteCollection.Url, UriKind.Absolute), this.User.LoginName)
                );
            }
        }
        if (this.ParameterSetName == "ParamSet2")
        {
            this.Service.SetObject(
                new Uri(this.SiteCollection.Url, UriKind.Absolute),
                this.UserName,
                this.IsSiteCollectionAdmin
            );
            if (this.PassThru)
            {
                this.Outputs.Add(
                    this.Service.GetObject(new Uri(this.SiteCollection.Url, UriKind.Absolute), this.UserName)
                );
            }
        }
        if (this.ParameterSetName == "ParamSet3")
        {
            this.Service.SetObject(this.SiteCollectionUrl, this.User, this.IsSiteCollectionAdmin);
            if (this.PassThru)
            {
                this.Outputs.Add(this.Service.GetObject(this.SiteCollectionUrl, this.User.LoginName));
            }
        }
        if (this.ParameterSetName == "ParamSet4")
        {
            this.Service.SetObject(this.SiteCollectionUrl, this.UserName, this.IsSiteCollectionAdmin);
            if (this.PassThru)
            {
                this.Outputs.Add(this.Service.GetObject(this.SiteCollectionUrl, this.UserName));
            }
        }
    }

}

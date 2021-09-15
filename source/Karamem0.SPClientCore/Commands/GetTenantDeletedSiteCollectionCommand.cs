//
// Copyright (c) 2021 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models;
using Karamem0.SharePoint.PowerShell.Resources;
using Karamem0.SharePoint.PowerShell.Runtime.Commands;
using Karamem0.SharePoint.PowerShell.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands
{

    [Cmdlet("Get", "KshTenantDeletedSiteCollection")]
    [OutputType(typeof(TenantDeletedSiteCollection))]
    public class GetTenantDeletedSiteCollectionCommand : ClientObjectCmdlet<ITenantDeletedSiteCollectionService>
    {

        public GetTenantDeletedSiteCollectionCommand()
        {
        }

        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ParameterSetName = "ParamSet1")]
        public TenantDeletedSiteCollection Identity { get; private set; }

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "ParamSet2")]
        public Uri SiteCollectionUrl { get; private set; }

        [Parameter(Mandatory = false, ParameterSetName = "ParamSet3")]
        public SwitchParameter NoEnumerate { get; private set; }

        protected override void ProcessRecordCore(ref List<object> outputs)
        {
            if (this.ParameterSetName == "ParamSet1")
            {
                outputs.Add(this.Service.GetObject(this.Identity));
            }
            if (this.ParameterSetName == "ParamSet2")
            {
                if (this.SiteCollectionUrl.IsAbsoluteUri)
                {
                    outputs.Add(this.Service.GetObject(this.SiteCollectionUrl));
                }
                else
                {
                    throw new ArgumentException(
                        string.Format(StringResources.ErrorValueIsNotAbsoluteUrl, this.SiteCollectionUrl),
                        nameof(this.SiteCollectionUrl));
                }
            }
            if (this.ParameterSetName == "ParamSet3")
            {
                if (this.NoEnumerate)
                {
                    outputs.Add(this.Service.GetObjectEnumerable());
                }
                else
                {
                    outputs.AddRange(this.Service.GetObjectEnumerable());
                }
            }
        }

    }

}

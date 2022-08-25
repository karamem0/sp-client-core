//
// Copyright (c) 2022 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Resources;
using Karamem0.SharePoint.PowerShell.Runtime.Commands;
using Karamem0.SharePoint.PowerShell.Services.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands
{

    [Cmdlet("Add", "KshAnonymousLink")]
    [Alias("New-KshAnonymousLink")]
    [OutputType(typeof(string))]
    public class AddAnonymousLinkCommand : ClientObjectCmdlet<ISharingLinkService>
    {

        public AddAnonymousLinkCommand()
        {
        }

        [Parameter(Mandatory = true, ParameterSetName = "ParamSet1")]
        [Parameter(Mandatory = true, ParameterSetName = "ParamSet2")]
        public Uri Url { get; private set; }

        [Parameter(Mandatory = true, ParameterSetName = "ParamSet1")]
        [Parameter(Mandatory = true, ParameterSetName = "ParamSet2")]
        public bool IsEditLink { get; private set; }

        [Parameter(Mandatory = true, ParameterSetName = "ParamSet2")]
        public DateTime Expiration { get; private set; }

        protected override void ProcessRecordCore()
        {
            if (this.ParameterSetName == "ParamSet1")
            {
                if (this.Url.IsAbsoluteUri)
                {
                    this.Outputs.Add(this.Service.CreateAnonymousLink(this.Url, this.IsEditLink));
                }
                else
                {
                    throw new ArgumentException(
                        string.Format(StringResources.ErrorValueIsNotAbsoluteUrl, this.Url),
                        nameof(this.Url));
                }
            }
            if (this.ParameterSetName == "ParamSet2")
            {
                if (this.Url.IsAbsoluteUri)
                {
                    this.Outputs.Add(this.Service.CreateAnonymousLink(this.Url, this.IsEditLink, this.Expiration));
                }
                else
                {
                    throw new ArgumentException(
                        string.Format(StringResources.ErrorValueIsNotAbsoluteUrl, this.Url),
                        nameof(this.Url));
                }
            }
        }

    }

}

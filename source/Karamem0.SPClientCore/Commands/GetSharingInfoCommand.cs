//
// Copyright (c) 2023 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
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

    [Cmdlet("Get", "KshSharingInfo")]
    [OutputType(typeof(SharingInfo))]
    public class GetSharingInfoCommand : ClientObjectCmdlet<ISharingLinkService>
    {

        public GetSharingInfoCommand()
        {
        }

        [Parameter(Mandatory = true)]
        public Uri Url { get; private set; }

        [Parameter(Mandatory = false)]
        public bool CheckForAccessRequests { get; private set; }

        [Parameter(Mandatory = false)]
        public bool ExcludeCurrentUser { get; private set; }

        [Parameter(Mandatory = false)]
        public bool ExcludeSecurityGroups { get; private set; }

        [Parameter(Mandatory = false)]
        public bool ExcludeSiteAdmin { get; private set; }

        [Parameter(Mandatory = false)]
        public bool RetrieveAnonymousLinks { get; private set; }

        [Parameter(Mandatory = false)]
        public bool RetrievePermissionLevels { get; private set; }

        [Parameter(Mandatory = false)]
        public bool RetrieveUserInfoDetails { get; private set; }

        protected override void ProcessRecordCore()
        {
            if (this.Url.IsAbsoluteUri)
            {
                this.Outputs.Add(this.Service.GetSharingInfo(
                    this.Url,
                    this.ExcludeCurrentUser,
                    this.ExcludeSiteAdmin,
                    this.ExcludeSecurityGroups,
                    this.RetrieveAnonymousLinks,
                    this.RetrieveUserInfoDetails,
                    this.CheckForAccessRequests,
                    this.RetrievePermissionLevels
                ));
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

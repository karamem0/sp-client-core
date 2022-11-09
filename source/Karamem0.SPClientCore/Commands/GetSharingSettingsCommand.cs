//
// Copyright (c) 2022 karamem0
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

    [Cmdlet("Get", "KshSharingSettings")]
    [OutputType(typeof(SharingSettings))]
    public class GetSharingSettingsCommand : ClientObjectCmdlet<ISharingLinkService>
    {

        public GetSharingSettingsCommand()
        {
        }

        [Parameter(Mandatory = true)]
        public Uri Url { get; private set; }

        [Parameter(Mandatory = false)]
        public int GroupId { get; private set; }

        [Parameter(Mandatory = false)]
        public bool UseSimplifiedRoles { get; private set; }

        protected override void ProcessRecordCore()
        {
            if (this.Url.IsAbsoluteUri)
            {
                this.Outputs.Add(this.Service.GetSharingSettings(this.Url, this.GroupId, this.UseSimplifiedRoles));
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

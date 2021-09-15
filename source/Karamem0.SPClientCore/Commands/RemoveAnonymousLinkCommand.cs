//
// Copyright (c) 2021 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Runtime.Commands;
using Karamem0.SharePoint.PowerShell.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands
{

    [Cmdlet("Remove", "KshAnonymousLink")]
    [OutputType(typeof(void))]
    public class RemoveAnonymousLinkCommand : ClientObjectCmdlet<ISharingLinkService>
    {

        public RemoveAnonymousLinkCommand()
        {
        }

        [Parameter(Mandatory = true, Position = 0)]
        public string Url { get; private set; }

        [Parameter(Mandatory = true, Position = 1)]
        public bool IsEditLink { get; private set; }

        [Parameter(Mandatory = true, Position = 2)]
        public bool RemoveAssociatedSharingLinkGroup { get; private set; }

        protected override void ProcessRecordCore(ref List<object> outputs)
        {
            this.Service.RemoveAnonymousLink(this.Url, this.IsEditLink, this.RemoveAssociatedSharingLinkGroup);
        }

    }

}

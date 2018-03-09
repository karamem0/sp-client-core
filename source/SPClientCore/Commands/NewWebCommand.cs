//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models;
using Karamem0.SharePoint.PowerShell.Models.OData;
using Karamem0.SharePoint.PowerShell.Resources;
using Karamem0.SharePoint.PowerShell.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands
{

    [Cmdlet("New", "SPWeb")]
    [OutputType(typeof(Web))]
    public class NewWebCommand : PSCmdlet
    {

        public NewWebCommand()
        {
        }

        [Parameter(Mandatory = false)]
        public string Description { get; private set; }

        [Parameter(Mandatory = false)]
        public int? Language { get; private set; }

        [Parameter(Mandatory = false)]
        public string Title { get; private set; }

        [Parameter(Mandatory = false)]
        public string Url { get; private set; }

        [Parameter(Mandatory = false)]
        public bool? UseSamePermissionsAsParentSite { get; private set; }

        [Parameter(Mandatory = false)]
        public string WebTemplate { get; private set; }

        [Parameter(Mandatory = false)]
        public string[] Includes { get; private set; }

        protected override void ProcessRecord()
        {
            if (ClientObjectService.ServiceProvider == null)
            {
                throw new InvalidOperationException(StringResources.ErrorNotConnected);
            }
            var webService = ClientObjectService.ServiceProvider.GetService<IWebService>();
            var webQuery = ODataQuery.Create<Web>(this.MyInvocation.BoundParameters);
            this.WriteObject(webService.CreateWeb(this.MyInvocation.BoundParameters, webQuery));
        }

    }

}

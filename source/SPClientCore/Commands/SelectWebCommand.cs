//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models;
using Karamem0.SharePoint.PowerShell.Models.OData;
using Karamem0.SharePoint.PowerShell.PipeBinds;
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

    [Cmdlet("Select", "SPWeb")]
    [OutputType(typeof(Web))]
    public class SelectWebCommand : PSCmdlet
    {

        public SelectWebCommand()
        {
        }

        [Parameter(Mandatory = true)]
        public WebPipeBind Web { get; private set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; private set; }

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
            var web = webService.GetWeb(this.Web, webQuery);
            webService.SelectWeb(web.Url);
            if (this.PassThru)
            {
                this.WriteObject(web);
            }
        }

    }

}

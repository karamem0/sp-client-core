//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.Core;
using Karamem0.SharePoint.PowerShell.Models.OData;
using Karamem0.SharePoint.PowerShell.PipeBinds.Core;
using Karamem0.SharePoint.PowerShell.Resources;
using Karamem0.SharePoint.PowerShell.Services;
using Karamem0.SharePoint.PowerShell.Services.Core;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands.Core
{

    [Cmdlet("Find", "SPAppInstance")]
    [OutputType(typeof(AppInstance[]))]
    public class FindAppInstanceCommand : PSCmdlet
    {

        public FindAppInstanceCommand()
        {
        }

        [Parameter(Mandatory = true)]
        public Guid? ProductId { get; private set; }

        [Parameter(Mandatory = false)]
        public string[] Includes { get; private set; }

        protected override void ProcessRecord()
        {
            if (ClientObjectService.ServiceProvider == null)
            {
                throw new InvalidOperationException(StringResources.ErrorNotConnected);
            }
            var webService = ClientObjectService.ServiceProvider.GetService<IWebService>();
            var appInstanceQuery = ODataQuery.Create<AppInstance>(this.MyInvocation.BoundParameters);
            this.WriteObject(webService.FindAppInstancesByProductId(this.ProductId, appInstanceQuery), true);
        }

    }

}

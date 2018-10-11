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

    [Cmdlet("Find", "SPView")]
    [OutputType(typeof(View[]))]
    public class FindViewCommand : ClientObjectCmdlet
    {

        public FindViewCommand()
        {
        }

        [Parameter(Mandatory = true, Position = 0)]
        public ListPipeBind List { get; private set; }

        [Parameter(Mandatory = false)]
        public string[] Includes { get; private set; }

        [Parameter(Mandatory = false)]
        public string[] OrderBy { get; private set; }

        [Parameter(Mandatory = false)]
        public int? Top { get; private set; }

        [Parameter(Mandatory = false)]
        public int? Skip { get; private set; }

        protected override void ProcessRecord()
        {
            if (ClientObjectService.ServiceProvider == null)
            {
                throw new InvalidOperationException(StringResources.ErrorNotConnected);
            }
            var viewService = ClientObjectService.ServiceProvider.GetService<IViewService>();
            var viewQuery = ODataQuery.Create<View>(this.MyInvocation.BoundParameters);
            var listService = ClientObjectService.ServiceProvider.GetService<IListService>();
            var list = listService.GetList(this.List);
            this.WriteObject(viewService.FindViews(list.Id, viewQuery), true);
        }

    }

}

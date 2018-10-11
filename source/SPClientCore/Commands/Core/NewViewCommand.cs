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

    [Cmdlet("New", "SPView")]
    [OutputType(typeof(View))]
    public class NewViewCommand : ClientObjectCmdlet
    {

        public NewViewCommand()
        {
        }

        [Parameter(Mandatory = true, Position = 0)]
        public ListPipeBind List { get; private set; }

        [Parameter(Mandatory = false)]
        public string Aggregations { get; private set; }

        [Parameter(Mandatory = false)]
        public string AggregationsStatus { get; private set; }

        [Parameter(Mandatory = false)]
        public bool? DefaultView { get; private set; }

        [Parameter(Mandatory = false)]
        public bool? DefaultViewForContentType { get; private set; }

        [Parameter(Mandatory = false)]
        public bool? EditorModified { get; private set; }

        [Parameter(Mandatory = false)]
        public string Formats { get; private set; }

        [Parameter(Mandatory = false)]
        public bool? Hidden { get; private set; }

        [Parameter(Mandatory = false)]
        public bool? IncludeRootFolder { get; private set; }

        [Parameter(Mandatory = false)]
        public string JSLink { get; private set; }

        [Parameter(Mandatory = false)]
        public bool? Paged { get; private set; }

        [Parameter(Mandatory = false)]
        public bool? MobileDefaultView { get; private set; }

        [Parameter(Mandatory = false)]
        public bool? MobileView { get; private set; }

        [Parameter(Mandatory = false)]
        public bool? PersonalView { get; private set; }

        [Parameter(Mandatory = false)]
        public int? RowLimit { get; private set; }

        [Parameter(Mandatory = false)]
        public ViewScope? Scope { get; private set; }

        [Parameter(Mandatory = true)]
        public string Title { get; private set; }

        [Parameter(Mandatory = false)]
        public string Toolbar { get; private set; }

        [Parameter(Mandatory = false)]
        public string ViewData { get; private set; }

        [Parameter(Mandatory = false)]
        public string ViewJoins { get; private set; }

        [Parameter(Mandatory = false)]
        public string ViewProjectedFields { get; private set; }

        [Parameter(Mandatory = false)]
        public string ViewQuery { get; private set; }

        [Parameter(Mandatory = false)]
        public string ViewType { get; private set; }

        [Parameter(Mandatory = false)]
        public string[] Includes { get; private set; }

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
            this.WriteObject(viewService.CreateView(list.Id, this.MyInvocation.BoundParameters, viewQuery));
        }

    }

}

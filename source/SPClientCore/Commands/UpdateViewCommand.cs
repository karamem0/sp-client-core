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

    [Cmdlet("Update", "SPView", DefaultParameterSetName = "ByParam")]
    [OutputType(typeof(View))]
    public class UpdateViewCommand : PSCmdlet
    {

        public UpdateViewCommand()
        {
        }

        [Parameter(Mandatory = true)]
        public ListPipeBind List { get; private set; }

        [Parameter(Mandatory = true)]
        public ViewPipeBind View { get; private set; }

        [Parameter(Mandatory = false, ParameterSetName = "ByParam")]
        public string Aggregations { get; private set; }

        [Parameter(Mandatory = false, ParameterSetName = "ByParam")]
        public string AggregationsStatus { get; private set; }

        [Parameter(Mandatory = false)]
        public bool? DefaultView { get; private set; }

        [Parameter(Mandatory = false)]
        public bool? DefaultViewForContentType { get; private set; }

        [Parameter(Mandatory = false)]
        public bool? EditorModified { get; private set; }

        [Parameter(Mandatory = false, ParameterSetName = "ByParam")]
        public string Formats { get; private set; }

        [Parameter(Mandatory = false)]
        public bool? Hidden { get; private set; }

        [Parameter(Mandatory = false)]
        public bool? IncludeRootFolder { get; private set; }

        [Parameter(Mandatory = false, ParameterSetName = "ByParam")]
        public string JSLink { get; private set; }

        [Parameter(Mandatory = false, ParameterSetName = "ByParam")]
        public bool? Paged { get; private set; }

        [Parameter(Mandatory = false)]
        public bool? MobileDefaultView { get; private set; }

        [Parameter(Mandatory = false)]
        public bool? MobileView { get; private set; }

        [Parameter(Mandatory = false, ParameterSetName = "ByParam")]
        public int? RowLimit { get; private set; }

        [Parameter(Mandatory = false)]
        public ViewScope? Scope { get; private set; }

        [Parameter(Mandatory = false)]
        public string Title { get; private set; }

        [Parameter(Mandatory = false, ParameterSetName = "ByParam")]
        public string Toolbar { get; private set; }

        [Parameter(Mandatory = false, ParameterSetName = "ByParam")]
        public string ViewData { get; private set; }

        [Parameter(Mandatory = false, ParameterSetName = "ByParam")]
        public string ViewJoins { get; private set; }

        [Parameter(Mandatory = false, ParameterSetName = "ByParam")]
        public string ViewProjectedFields { get; private set; }

        [Parameter(Mandatory = false, ParameterSetName = "ByParam")]
        public string ViewQuery { get; private set; }

        [Parameter(Mandatory = false, ParameterSetName = "ByXml")]
        public string ListViewXml { get; private set; }

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
            var viewService = ClientObjectService.ServiceProvider.GetService<IViewService>();
            var viewQuery = ODataQuery.Create<View>(this.MyInvocation.BoundParameters);
            var listService = ClientObjectService.ServiceProvider.GetService<IListService>();
            var list = listService.GetList(this.List);
            var view = viewService.GetView(list.Id, this.View);
            viewService.UpdateView(list.Id, view.Id, this.MyInvocation.BoundParameters);
            if (this.PassThru)
            {
                this.WriteObject(viewService.GetView(list.Id, new ViewPipeBind(view.Id), viewQuery));
            }
        }

    }

}

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

    [Cmdlet("New", "SPField", DefaultParameterSetName = "ByParam")]
    [OutputType(typeof(Field))]
    public class NewFieldCommand : PSCmdlet
    {

        public NewFieldCommand()
        {
        }

        [Parameter(Mandatory = false)]
        public ListPipeBind List { get; private set; }

        [Parameter(Mandatory = true, ParameterSetName = "ByParam")]
        public FieldTypeKind? FieldTypeKind { get; private set; }

        [Parameter(Mandatory = false, ParameterSetName = "ByParam")]
        public string DefaultValue { get; private set; }

        [Parameter(Mandatory = false, ParameterSetName = "ByParam")]
        public string Description { get; private set; }

        [Parameter(Mandatory = false, ParameterSetName = "ByParam")]
        public string Direction { get; private set; }

        [Parameter(Mandatory = false, ParameterSetName = "ByParam")]
        public bool? EnforceUniqueValues { get; private set; }

        [Parameter(Mandatory = false, ParameterSetName = "ByParam")]
        public string Group { get; private set; }

        [Parameter(Mandatory = false, ParameterSetName = "ByParam")]
        public bool? Hidden { get; private set; }

        [Parameter(Mandatory = false, ParameterSetName = "ByParam")]
        public bool? Indexed { get; private set; }

        [Parameter(Mandatory = false, ParameterSetName = "ByParam")]
        public string JSLink { get; private set; }

        [Parameter(Mandatory = false, ParameterSetName = "ByParam")]
        public bool? ReadOnlyField { get; private set; }

        [Parameter(Mandatory = false, ParameterSetName = "ByParam")]
        public bool? Required { get; private set; }

        [Parameter(Mandatory = false, ParameterSetName = "ByParam")]
        public string Scope { get; private set; }

        [Parameter(Mandatory = false, ParameterSetName = "ByParam")]
        public bool? Sortable { get; private set; }

        [Parameter(Mandatory = false, ParameterSetName = "ByParam")]
        public string StaticName { get; private set; }

        [Parameter(Mandatory = true, ParameterSetName = "ByParam")]
        public string Title { get; private set; }

        [Parameter(Mandatory = false, ParameterSetName = "ByParam")]
        public string ValidationFormula { get; private set; }

        [Parameter(Mandatory = false, ParameterSetName = "ByParam")]
        public string ValidationMessage { get; private set; }

        [Parameter(Mandatory = true, ParameterSetName = "ByXml")]
        public string SchemaXml { get; private set; }

        [Parameter(Mandatory = false, ParameterSetName = "ByXml")]
        public AddFieldOptions? Options { get; private set; }

        [Parameter(Mandatory = false)]
        public string[] Includes { get; private set; }

        protected override void ProcessRecord()
        {
            if (ClientObjectService.ServiceProvider == null)
            {
                throw new InvalidOperationException(StringResources.ErrorNotConnected);
            }
            var fieldService = ClientObjectService.ServiceProvider.GetService<IFieldService>();
            var fieldQuery = ODataQuery.Create<Field>(this.MyInvocation.BoundParameters);
            if (this.ParameterSetName == "ByParam")
            {
                if (this.List == null)
                {
                    this.WriteObject(fieldService.CreateField(this.MyInvocation.BoundParameters, fieldQuery));
                }
                else
                {
                    var listService = ClientObjectService.ServiceProvider.GetService<IListService>();
                    var list = listService.GetList(this.List);
                    this.WriteObject(fieldService.CreateField(list.Id, this.MyInvocation.BoundParameters, fieldQuery));
                }
            }
            if (this.ParameterSetName == "ByXml")
            {
                if (this.List == null)
                {
                    this.WriteObject(fieldService.CreateFieldAsXml(this.MyInvocation.BoundParameters, fieldQuery));
                }
                else
                {
                    var listService = ClientObjectService.ServiceProvider.GetService<IListService>();
                    var list = listService.GetList(this.List);
                    this.WriteObject(fieldService.CreateFieldAsXml(list.Id, this.MyInvocation.BoundParameters, fieldQuery));
                }
            }
        }

    }

}

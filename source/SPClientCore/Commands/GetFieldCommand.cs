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

    [Cmdlet("Get", "SPField")]
    [OutputType(typeof(Field))]
    public class GetFieldCommand : PSCmdlet
    {

        public GetFieldCommand()
        {
        }

        [Parameter(Mandatory = true)]
        public FieldPipeBind Field { get; private set; }

        [Parameter(Mandatory = false)]
        public ListPipeBind List { get; private set; }

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
            if (this.List == null)
            {
                this.WriteObject(fieldService.GetField(this.Field, fieldQuery));
            }
            else
            {
                var listService = ClientObjectService.ServiceProvider.GetService<IListService>();
                var list = listService.GetList(this.List);
                this.WriteObject(fieldService.GetField(list.Id, this.Field, fieldQuery));
            }
        }

    }

}

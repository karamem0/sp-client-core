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

    [Cmdlet("Update", "SPField")]
    [OutputType(typeof(Field))]
    public class UpdateFieldCommand : PSCmdlet
    {

        public UpdateFieldCommand()
        {
        }

        [Parameter(Mandatory = false)]
        public ListPipeBind List { get; private set; }

        [Parameter(Mandatory = true)]
        public FieldPipeBind Field { get; private set; }

        [Parameter(Mandatory = false)]
        public bool? Hidden { get; private set; }

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
            var fieldService = ClientObjectService.ServiceProvider.GetService<IFieldService>();
            var fieldQuery = ODataQuery.Create<Field>(this.MyInvocation.BoundParameters);
            if (this.List == null)
            {
                var field = fieldService.GetField(this.Field);
                fieldService.UpdateField(field.Id, this.MyInvocation.BoundParameters);
                if (this.PassThru)
                {
                    this.WriteObject(fieldService.GetField(new FieldPipeBind(field.Id), fieldQuery));
                }
            }
            else
            {
                var listService = ClientObjectService.ServiceProvider.GetService<IListService>();
                var list = listService.GetList(this.List);
                var field = fieldService.GetField(list.Id, this.Field);
                fieldService.UpdateField(list.Id, field.Id, this.MyInvocation.BoundParameters);
                if (this.PassThru)
                {
                    this.WriteObject(fieldService.GetField(list.Id, new FieldPipeBind(field.Id), fieldQuery));
                }
            }
        }

    }

}

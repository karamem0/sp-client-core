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

    [Cmdlet("New", "SPContentType")]
    [OutputType(typeof(ContentType))]
    public class NewContentTypeCommand : PSCmdlet
    {

        public NewContentTypeCommand()
        {
        }

        [Parameter(Mandatory = false, Position = 0)]
        public ListPipeBind List { get; private set; }

        [Parameter(Mandatory = false)]
        public string Description { get; private set; }

        [Parameter(Mandatory = false)]
        public string Group { get; private set; }

        [Parameter(Mandatory = false)]
        public string Name { get; private set; }

        [Parameter(Mandatory = false)]
        public string[] Includes { get; private set; }

        protected override void ProcessRecord()
        {
            if (ClientObjectService.ServiceProvider == null)
            {
                throw new InvalidOperationException(StringResources.ErrorNotConnected);
            }
            var contentTypeService = ClientObjectService.ServiceProvider.GetService<IContentTypeService>();
            var contentTypeQuery = ODataQuery.Create<ContentType>(this.MyInvocation.BoundParameters);
            if (this.List == null)
            {
                this.WriteObject(contentTypeService.CreateContentType(this.MyInvocation.BoundParameters, contentTypeQuery));
            }
            else
            {
                var listService = ClientObjectService.ServiceProvider.GetService<IListService>();
                var list = listService.GetList(this.List);
                this.WriteObject(contentTypeService.CreateContentType(list.Id, this.MyInvocation.BoundParameters, contentTypeQuery));
            }
        }

    }

}

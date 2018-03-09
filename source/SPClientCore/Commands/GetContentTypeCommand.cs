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

    [Cmdlet("Get", "SPContentType")]
    [OutputType(typeof(ContentType))]
    public class GetContentTypeCommand : PSCmdlet
    {

        public GetContentTypeCommand()
        {
        }

        [Parameter(Mandatory = false)]
        public ListPipeBind List { get; private set; }

        [Parameter(Mandatory = true)]
        public ContentTypePipeBind ContentType { get; private set; }

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
                this.WriteObject(contentTypeService.GetContentType(this.ContentType, contentTypeQuery));
            }
            else
            {
                var listService = ClientObjectService.ServiceProvider.GetService<IListService>();
                var list = listService.GetList(this.List);
                this.WriteObject(contentTypeService.GetContentType(list.Id, this.ContentType, contentTypeQuery));
            }
        }

    }

}

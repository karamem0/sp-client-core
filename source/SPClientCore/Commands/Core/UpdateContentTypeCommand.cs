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

    [Cmdlet("Update", "SPContentType", DefaultParameterSetName = "Web")]
    [OutputType(typeof(ContentType))]
    public class UpdateContentTypeCommand : ClientObjectCmdlet
    {

        public UpdateContentTypeCommand()
        {
        }

        [Parameter(Mandatory = true, ParameterSetName = "List", Position = 0)]
        public ListPipeBind List { get; private set; }

        [Parameter(Mandatory = true, ParameterSetName = "Web", Position = 0)]
        [Parameter(Mandatory = true, ParameterSetName = "List", Position = 1, ValueFromPipeline = true)]
        public ContentTypePipeBind ContentType { get; private set; }

        [Parameter(Mandatory = false)]
        public string Description { get; private set; }

        [Parameter(Mandatory = false)]
        public string JSLink { get; private set; }

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
            var contentTypeService = ClientObjectService.ServiceProvider.GetService<IContentTypeService>();
            var contentTypeQuery = ODataQuery.Create<ContentType>(this.MyInvocation.BoundParameters);
            if (this.List == null)
            {
                var contentType = contentTypeService.GetContentType(this.ContentType);
                contentTypeService.UpdateContentType(contentType.StringId, this.MyInvocation.BoundParameters);
                if (this.PassThru)
                {
                    this.WriteObject(contentTypeService.GetContentType(new ContentTypePipeBind(contentType.StringId), contentTypeQuery));
                }
            }
            else
            {
                var listService = ClientObjectService.ServiceProvider.GetService<IListService>();
                var list = listService.GetList(this.List);
                var contentType = contentTypeService.GetContentType(list.Id, this.ContentType);
                contentTypeService.UpdateContentType(list.Id, contentType.StringId, this.MyInvocation.BoundParameters);
                if (this.PassThru)
                {
                    this.WriteObject(contentTypeService.GetContentType(list.Id, new ContentTypePipeBind(contentType.StringId), contentTypeQuery));
                }
            }
        }

    }

}

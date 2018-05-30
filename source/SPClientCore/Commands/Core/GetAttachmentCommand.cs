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

    [Cmdlet("Get", "SPAttachment")]
    [OutputType(typeof(Attachment))]
    public class GetAttachmentCommand : PSCmdlet
    {

        public GetAttachmentCommand()
        {
        }

        [Parameter(Mandatory = true, Position = 0)]
        public ListPipeBind List { get; private set; }

        [Parameter(Mandatory = true, Position = 1)]
        public ListItemPipeBind ListItem { get; private set; }

        [Parameter(Mandatory = true, Position = 2, ValueFromPipeline = true)]
        public AttachmentPipeBind Attachment { get; private set; }

        [Parameter(Mandatory = false)]
        public string[] Includes { get; private set; }

        protected override void ProcessRecord()
        {
            if (ClientObjectService.ServiceProvider == null)
            {
                throw new InvalidOperationException(StringResources.ErrorNotConnected);
            }
            var attachmentService = ClientObjectService.ServiceProvider.GetService<IAttachmentService>();
            var attachmentQuery = ODataQuery.Create<Attachment>(this.MyInvocation.BoundParameters);
            var listService = ClientObjectService.ServiceProvider.GetService<IListService>();
            var list = listService.GetList(this.List);
            var listItemService = ClientObjectService.ServiceProvider.GetService<IListItemService>();
            var listItem = listItemService.GetListItem(list.Id, this.ListItem);
            this.WriteObject(attachmentService.GetAttachment(list.Id, listItem.Id, this.Attachment, attachmentQuery));
        }

    }

}

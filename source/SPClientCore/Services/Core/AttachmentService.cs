//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Common;
using Karamem0.SharePoint.PowerShell.Models;
using Karamem0.SharePoint.PowerShell.Models.Core;
using Karamem0.SharePoint.PowerShell.PipeBinds.Core;
using Karamem0.SharePoint.PowerShell.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Services.Core
{

    public interface IAttachmentService
    {

        Attachment CreateAttachment(Guid? listId, int? listItemId, string attachmentFileName, System.IO.Stream attachmentFileContent);

        IEnumerable<Attachment> FindAttachments(Guid? listId, int? listItemId, string attachmentQuery = null);

        Attachment GetAttachment(Guid? listId, int? listItemId, AttachmentPipeBind attachmentPipeBind, string attachmentQuery = null);

        void RemoveAttachment(Guid? listId, int? listItemId, string attachmentFileName);

    }

    public class AttachmentService : ClientObjectService, IAttachmentService
    {

        public AttachmentService(ClientContext clientContext) : base(clientContext)
        {
        }

        public Attachment CreateAttachment(Guid? listId, int? listItemId, string attachmentFileName, System.IO.Stream attachmentFileContent)
        {
            if (listId == null)
            {
                throw new ArgumentNullException(nameof(listId));
            }
            if (listItemId == null)
            {
                throw new ArgumentNullException(nameof(listItemId));
            }
            if (attachmentFileName == null)
            {
                throw new ArgumentNullException(nameof(attachmentFileName));
            }
            if (attachmentFileContent == null)
            {
                throw new ArgumentNullException(nameof(attachmentFileContent));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/lists('{0}')/items({1})/attachmentfiles/add(filename='{2}')",
                    listId, listItemId, attachmentFileName);
            return this.ClientContext.PostStream<Attachment>(requestUrl, attachmentFileContent);
        }

        public IEnumerable<Attachment> FindAttachments(Guid? listId, int? listItemId, string attachmentQuery = null)
        {
            if (listId == null)
            {
                throw new ArgumentNullException(nameof(listId));
            }
            if (listItemId == null)
            {
                throw new ArgumentNullException(nameof(listItemId));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/lists('{0}')/items({1})/attachmentfiles", listId, listItemId)
                .ConcatQuery(attachmentQuery);
            return this.ClientContext.GetObject<ClientObjectCollection<Attachment>>(requestUrl);
        }

        public Attachment GetAttachment(Guid? listId, int? listItemId, AttachmentPipeBind attachmentPipeBind, string attachmentQuery = null)
        {
            if (listId == null)
            {
                throw new ArgumentNullException(nameof(listId));
            }
            if (listItemId == null)
            {
                throw new ArgumentNullException(nameof(listItemId));
            }
            if (attachmentPipeBind == null)
            {
                throw new ArgumentNullException(nameof(attachmentPipeBind));
            }
            if (attachmentPipeBind.ClientObject != null)
            {
                if (attachmentPipeBind.ClientObject.Deferred == null)
                {
                    var requestUrl = attachmentPipeBind.ClientObject.Metadata.Uri.ConcatQuery(attachmentQuery);
                    return this.ClientContext.GetObject<Attachment>(requestUrl);
                }
                else
                {
                    var requestUrl = attachmentPipeBind.ClientObject.Deferred.Uri.ConcatQuery(attachmentQuery);
                    return this.ClientContext.GetObject<Attachment>(requestUrl);
                }
            }
            if (attachmentPipeBind.FileName != null)
            {
                var requestUrl = this.ClientContext.BaseAddress
                    .ConcatPath("_api/web/lists('{0}')/items({1})/attachmentfiles/getbyfilename('{2}')",
                        listId, listItemId, attachmentPipeBind.FileName)
                    .ConcatQuery(attachmentQuery);
                return this.ClientContext.GetObject<Attachment>(requestUrl);
            }
            throw new ArgumentException(string.Format(StringResources.ErrorValueIsInvalid, nameof(AttachmentPipeBind)), nameof(attachmentPipeBind));
        }

        public void RemoveAttachment(Guid? listId, int? listItemId, string attachmentFileName)
        {
            if (listId == null)
            {
                throw new ArgumentNullException(nameof(listId));
            }
            if (listItemId == null)
            {
                throw new ArgumentNullException(nameof(listItemId));
            }
            if (attachmentFileName == null)
            {
                throw new ArgumentNullException(nameof(attachmentFileName));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/lists('{0}')/items({1})/attachmentfiles('{2}')",
                        listId, listItemId, attachmentFileName);
            this.ClientContext.DeleteObject(requestUrl);
        }

    }

}

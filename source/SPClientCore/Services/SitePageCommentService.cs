//
// Copyright (c) 2020 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models;
using Karamem0.SharePoint.PowerShell.Runtime.Common;
using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Karamem0.SharePoint.PowerShell.Runtime.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Services
{

    public interface ISitePageCommentService
    {

        SitePageComment CreateObject(ListItem listItemObject, IReadOnlyDictionary<string, object> creationInformation);

        SitePageComment CreateObject(SitePageComment commentObject, IReadOnlyDictionary<string, object> creationInformation);

        SitePageComment GetObject(SitePageComment commentObject);

        SitePageComment GetObject(ListItem listItemObject, int commentId);

        IEnumerable<SitePageComment> GetObjectEnumerable(ListItem listItemObject);

        void RemoveObject(SitePageComment commentObject);

    }

    public class SitePageCommentService : ClientService, ISitePageCommentService
    {

        public SitePageCommentService(ClientContext clientContext) : base(clientContext)
        {
        }

        public SitePageComment CreateObject(ListItem listItemObject, IReadOnlyDictionary<string, object> creationInformation)
        {
            if (listItemObject == null)
            {
                throw new ArgumentNullException(nameof(listItemObject));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath(
                    "_api/web/lists('{0}')/items({1})/comments",
                    listItemObject.ObjectIdentity.Split(':').SkipLast(2).Last(),
                    listItemObject.Id)
                .ConcatQuery(ODataQuery.Create<SitePageComment>());
            var requestPayload = new ODataV1RequestPayload<SitePageCommentCreationInformation>(creationInformation);
            return this.ClientContext.PostObject<SitePageComment>(requestUrl, requestPayload.Entity);
        }

        public SitePageComment CreateObject(SitePageComment commentObject, IReadOnlyDictionary<string, object> creationInformation)
        {
            if (commentObject == null)
            {
                throw new ArgumentNullException(nameof(commentObject));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath(
                    "_api/web/lists('{0}')/items({1})/comments({2})/replies",
                    commentObject.ListId,
                    commentObject.ItemId,
                    commentObject.Id)
                .ConcatQuery(ODataQuery.Create<SitePageComment>());
            var requestPayload = new ODataV1RequestPayload<SitePageCommentCreationInformation>(creationInformation);
            return this.ClientContext.PostObject<SitePageComment>(requestUrl, requestPayload.Entity);
        }

        public SitePageComment GetObject(SitePageComment commentObject)
        {
            if (commentObject == null)
            {
                throw new ArgumentNullException(nameof(commentObject));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath(
                    "_api/web/lists('{0}')/items({1})/comments({2})",
                    commentObject.ListId,
                    commentObject.ItemId,
                    commentObject.Id)
                .ConcatQuery(ODataQuery.Create<SitePageComment>());
            return this.ClientContext.GetObject<SitePageComment>(requestUrl);
        }

        public SitePageComment GetObject(ListItem listItemObject, int commentId)
        {
            if (listItemObject == null)
            {
                throw new ArgumentNullException(nameof(listItemObject));
            }
            if (commentId == default(int))
            {
                throw new ArgumentNullException(nameof(commentId));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath(
                    "_api/web/lists('{0}')/items({1})/comments({2})",
                    listItemObject.ObjectIdentity.Split(':').SkipLast(2).Last(),
                    listItemObject.Id,
                    commentId)
                .ConcatQuery(ODataQuery.Create<SitePageComment>());
            return this.ClientContext.GetObject<SitePageComment>(requestUrl);
        }

        public IEnumerable<SitePageComment> GetObjectEnumerable(ListItem listItemObject)
        {
            if (listItemObject == null)
            {
                throw new ArgumentNullException(nameof(listItemObject));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath(
                    "_api/web/lists('{0}')/items({1})/comments",
                    listItemObject.ObjectIdentity.Split(':').SkipLast(2).Last(),
                    listItemObject.Id)
                .ConcatQuery(ODataQuery.Create<SitePageComment>());
            return this.ClientContext.GetObject<ODataV1ObjectEnumerable<SitePageComment>>(requestUrl);
        }

        public void RemoveObject(SitePageComment commentObject)
        {
            if (commentObject == null)
            {
                throw new ArgumentNullException(nameof(commentObject));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath(
                    "_api/web/lists('{0}')/items({1})/comments({2})",
                    commentObject.ListId,
                    commentObject.ItemId,
                    commentObject.Id);
            this.ClientContext.DeleteObject(requestUrl);
        }

    }

}

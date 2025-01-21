//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Runtime.Common;
using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Karamem0.SharePoint.PowerShell.Runtime.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Services.V1;

public interface ICommentService
{

    Comment AddObject(ListItem listItemObject, IReadOnlyDictionary<string, object> creationInfo);

    Comment AddObject(Comment commentObject, IReadOnlyDictionary<string, object> creationInfo);

    Comment GetObject(Comment commentObject);

    Comment GetObject(ListItem listItemObject, int? commentId);

    IEnumerable<Comment> GetObjectEnumerable(ListItem listItemObject);

    void RemoveObject(Comment commentObject);

    void SetDisabled(ListItem listItemObject, bool disabled);

}

public class CommentService(ClientContext clientContext) : ClientService(clientContext), ICommentService
{

    public Comment AddObject(ListItem listItemObject, IReadOnlyDictionary<string, object> creationInfo)
    {
        _ = listItemObject ?? throw new ArgumentNullException(nameof(listItemObject));
        var requestUrl = this.ClientContext.BaseAddress
            .ConcatPath(
                "_api/web/lists('{0}')/items({1})/comments",
                listItemObject.ObjectIdentity.Split(':').SkipLast(2).Last(),
                listItemObject.Id)
            .ConcatQuery(ODataQuery.CreateSelect<Comment>());
        var requestPayload = new ODataV1RequestPayload<CommentCreationInfo>(creationInfo);
        return this.ClientContext.PostObject<Comment>(requestUrl, requestPayload.Entity);
    }

    public Comment AddObject(Comment commentObject, IReadOnlyDictionary<string, object> creationInfo)
    {
        _ = commentObject ?? throw new ArgumentNullException(nameof(commentObject));
        var requestUrl = this.ClientContext.BaseAddress
            .ConcatPath(
                "_api/web/lists('{0}')/items({1})/comments({2})/replies",
                commentObject.ListId,
                commentObject.ItemId,
                commentObject.Id)
            .ConcatQuery(ODataQuery.CreateSelect<Comment>());
        var requestPayload = new ODataV1RequestPayload<CommentCreationInfo>(creationInfo);
        return this.ClientContext.PostObject<Comment>(requestUrl, requestPayload.Entity);
    }

    public Comment GetObject(Comment commentObject)
    {
        _ = commentObject ?? throw new ArgumentNullException(nameof(commentObject));
        var requestUrl = this.ClientContext.BaseAddress
            .ConcatPath(
                "_api/web/lists('{0}')/items({1})/comments({2})",
                commentObject.ListId,
                commentObject.ItemId,
                commentObject.Id)
            .ConcatQuery(ODataQuery.CreateSelect<Comment>());
        return this.ClientContext.GetObject<Comment>(requestUrl);
    }

    public Comment GetObject(ListItem listItemObject, int? commentId)
    {
        _ = listItemObject ?? throw new ArgumentNullException(nameof(listItemObject));
        _ = commentId ?? throw new ArgumentNullException(nameof(commentId));
        var requestUrl = this.ClientContext.BaseAddress
            .ConcatPath(
                "_api/web/lists('{0}')/items({1})/comments({2})",
                listItemObject.ObjectIdentity.Split(':').SkipLast(2).Last(),
                listItemObject.Id,
                commentId)
            .ConcatQuery(ODataQuery.CreateSelect<Comment>());
        return this.ClientContext.GetObject<Comment>(requestUrl);
    }

    public IEnumerable<Comment> GetObjectEnumerable(ListItem listItemObject)
    {
        _ = listItemObject ?? throw new ArgumentNullException(nameof(listItemObject));
        var requestUrl = this.ClientContext.BaseAddress
            .ConcatPath(
                "_api/web/lists('{0}')/items({1})/comments",
                listItemObject.ObjectIdentity.Split(':').SkipLast(2).Last(),
                listItemObject.Id)
            .ConcatQuery(ODataQuery.CreateSelect<Comment>());
        return this.ClientContext.GetObject<ODataV1ObjectEnumerable<Comment>>(requestUrl);
    }

    public void RemoveObject(Comment commentObject)
    {
        _ = commentObject ?? throw new ArgumentNullException(nameof(commentObject));
        var requestUrl = this.ClientContext.BaseAddress
            .ConcatPath(
                "_api/web/lists('{0}')/items({1})/comments({2})",
                commentObject.ListId,
                commentObject.ItemId,
                commentObject.Id);
        this.ClientContext.DeleteObject(requestUrl);
    }

    public void SetDisabled(ListItem listItemObject, bool disabled)
    {
        _ = listItemObject ?? throw new ArgumentNullException(nameof(listItemObject));
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            new ObjectPathIdentity(listItemObject.ObjectIdentity),
            objectPathId => new ClientActionMethod(
                objectPathId,
                "SetCommentsDisabled",
                requestPayload.CreateParameter(disabled)));
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

}

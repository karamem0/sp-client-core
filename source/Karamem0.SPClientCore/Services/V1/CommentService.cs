//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Resources;
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

    Comment? AddObject(ListItem listItemObject, IReadOnlyDictionary<string, object?> creationInfo);

    Comment? AddObject(Comment commentObject, IReadOnlyDictionary<string, object?> creationInfo);

    Comment? GetObject(Comment commentObject);

    Comment? GetObject(ListItem listItemObject, int commentId);

    IEnumerable<Comment>? GetObjectEnumerable(ListItem listItemObject);

    void RemoveObject(Comment commentObject);

    void SetDisabled(ListItem listItemObject, bool disabled);

}

public class CommentService(ClientContext clientContext) : ClientService(clientContext), ICommentService
{

    public Comment? AddObject(ListItem listItemObject, IReadOnlyDictionary<string, object?> creationInfo)
    {
        var objectIdentity = listItemObject.ObjectIdentity;
        _ = objectIdentity ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
        var requestUrl = this
            .ClientContext.BaseAddress.ConcatPath(
                "_api/web/lists('{0}')/items({1})/comments",
                objectIdentity
                    .Split(':')
                    .SkipLast(2)
                    .Last(),
                listItemObject.Id
            )
            .ConcatQuery(ODataQuery.CreateSelect<Comment>());
        var requestPayload = ODataV1RequestPayload.Create<CommentCreationInfo>(creationInfo);
        return this.ClientContext.PostObject<Comment>(requestUrl, requestPayload.Entity);
    }

    public Comment? AddObject(Comment commentObject, IReadOnlyDictionary<string, object?> creationInfo)
    {
        var requestUrl = this
            .ClientContext.BaseAddress.ConcatPath(
                "_api/web/lists('{0}')/items({1})/comments({2})/replies",
                commentObject.ListId,
                commentObject.ItemId,
                commentObject.Id
            )
            .ConcatQuery(ODataQuery.CreateSelect<Comment>());
        var requestPayload = ODataV1RequestPayload.Create<CommentCreationInfo>(creationInfo);
        return this.ClientContext.PostObject<Comment>(requestUrl, requestPayload.Entity);
    }

    public Comment? GetObject(Comment commentObject)
    {
        var requestUrl = this
            .ClientContext.BaseAddress.ConcatPath(
                "_api/web/lists('{0}')/items({1})/comments({2})?$expand=LikedBy",
                commentObject.ListId,
                commentObject.ItemId,
                commentObject.Id
            )
            .ConcatQuery(ODataQuery.CreateSelect<Comment>());
        return this.ClientContext.GetObject<Comment>(requestUrl);
    }

    public Comment? GetObject(ListItem listItemObject, int commentId)
    {
        var objectIdentity = listItemObject.ObjectIdentity;
        _ = objectIdentity ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
        var requestUrl = this
            .ClientContext.BaseAddress.ConcatPath(
                "_api/web/lists('{0}')/items({1})/comments({2})?$expand=LikedBy",
                objectIdentity
                    .Split(':')
                    .SkipLast(2)
                    .Last(),
                listItemObject.Id,
                commentId
            )
            .ConcatQuery(ODataQuery.CreateSelect<Comment>());
        return this.ClientContext.GetObject<Comment>(requestUrl);
    }

    public IEnumerable<Comment>? GetObjectEnumerable(ListItem listItemObject)
    {
        var objectIdentity = listItemObject.ObjectIdentity;
        _ = objectIdentity ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
        var requestUrl = this
            .ClientContext.BaseAddress.ConcatPath(
                "_api/web/lists('{0}')/items({1})/comments?$expand=LikedBy",
                objectIdentity
                    .Split(':')
                    .SkipLast(2)
                    .Last(),
                listItemObject.Id
            )
            .ConcatQuery(ODataQuery.CreateSelect<Comment>());
        return this.ClientContext.GetObject<ODataV1ObjectEnumerable<Comment>>(requestUrl);
    }

    public void RemoveObject(Comment commentObject)
    {
        var requestUrl = this.ClientContext.BaseAddress.ConcatPath(
            "_api/web/lists('{0}')/items({1})/comments({2})",
            commentObject.ListId,
            commentObject.ItemId,
            commentObject.Id
        );
        this.ClientContext.DeleteObject(requestUrl);
    }

    public void SetDisabled(ListItem listItemObject, bool disabled)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            ObjectPathIdentity.Create(listItemObject.ObjectIdentity),
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "SetCommentsDisabled",
                requestPayload.CreateParameter(disabled)
            )
        );
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

}

//
// Copyright (c) 2018-2026 karamem0
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

namespace Karamem0.SharePoint.PowerShell.Services.V1;

public interface ICommentService
{

    Task<Comment?> AddObjectAsync(ListItem listItemObject, IReadOnlyDictionary<string, object?> creationInfo);

    Task<Comment?> AddObjectAsync(Comment commentObject, IReadOnlyDictionary<string, object?> creationInfo);

    Task<Comment?> GetObjectAsync(Comment commentObject);

    Task<Comment?> GetObjectAsync(Comment commentObject, bool selectAllProperties = true);

    Task<Comment?> GetObjectAsync(ListItem listItemObject, int commentId);

    Task<IEnumerable<Comment>?> GetObjectEnumerableAsync(ListItem listItemObject);

    Task RemoveObjectAsync(Comment commentObject);

    Task SetDisabledAsync(ListItem listItemObject, bool disabled);

}

public class CommentService(ClientContext clientContext) : ClientService(clientContext), ICommentService
{

    public async Task<Comment?> AddObjectAsync(ListItem listItemObject, IReadOnlyDictionary<string, object?> creationInfo)
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
        return await this.ClientContext.PostObjectAsync<Comment>(requestUrl, requestPayload.Entity);
    }

    public async Task<Comment?> AddObjectAsync(Comment commentObject, IReadOnlyDictionary<string, object?> creationInfo)
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
        return await this.ClientContext.PostObjectAsync<Comment>(requestUrl, requestPayload.Entity);
    }

    public async Task<Comment?> GetObjectAsync(Comment commentObject)
    {
        var requestUrl = this
            .ClientContext.BaseAddress.ConcatPath(
                "_api/web/lists('{0}')/items({1})/comments({2})?$expand=LikedBy",
                commentObject.ListId,
                commentObject.ItemId,
                commentObject.Id
            )
            .ConcatQuery(ODataQuery.CreateSelect<Comment>());
        return await this.ClientContext.GetObjectAsync<Comment>(requestUrl);
    }

    public async Task<Comment?> GetObjectAsync(Comment commentObject, bool selectAllProperties = true)
    {
        return await this.GetObjectAsync(commentObject);
    }

    public async Task<Comment?> GetObjectAsync(ListItem listItemObject, int commentId)
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
        return await this.ClientContext.GetObjectAsync<Comment>(requestUrl);
    }

    public async Task<IEnumerable<Comment>?> GetObjectEnumerableAsync(ListItem listItemObject)
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
        return await this.ClientContext.GetObjectAsync<ODataV1ObjectEnumerable<Comment>>(requestUrl);
    }

    public async Task RemoveObjectAsync(Comment commentObject)
    {
        var requestUrl = this.ClientContext.BaseAddress.ConcatPath(
            "_api/web/lists('{0}')/items({1})/comments({2})",
            commentObject.ListId,
            commentObject.ItemId,
            commentObject.Id
        );
        await this.ClientContext.DeleteObjectAsync(requestUrl);
    }

    public async Task SetDisabledAsync(ListItem listItemObject, bool disabled)
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
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

}

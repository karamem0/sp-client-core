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

public interface ILikeService
{

    Task<IEnumerable<LikedUser>?> GetObjectEnumerableAsync(Comment commentObject);

    Task<IEnumerable<LikedUser>?> GetObjectEnumerableAsync(ListItem listItemObject);

    Task LikeObjectAsync(Comment commentObject);

    Task LikeObjectAsync(ListItem listItemObject);

    Task UnlikeObjectAsync(Comment commentObject);

    Task UnlikeObjectAsync(ListItem listItemObject);

}

public class LikeService(ClientContext clientContext) : ClientService(clientContext), ILikeService
{

    public async Task<IEnumerable<LikedUser>?> GetObjectEnumerableAsync(Comment commentObject)
    {
        var requestUrl = this.ClientContext.BaseAddress.ConcatPath(
            "_api/web/lists('{0}')/items({1})/comments({2})/likedby",
            commentObject.ListId,
            commentObject.ItemId,
            commentObject.Id
        );
        return await this.ClientContext.GetObjectAsync<ODataV1ObjectEnumerable<LikedUser>>(requestUrl);
    }

    public async Task<IEnumerable<LikedUser>?> GetObjectEnumerableAsync(ListItem listItemObject)
    {
        var objectIdentity = listItemObject.ObjectIdentity;
        _ = objectIdentity ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
        var requestUrl = this.ClientContext.BaseAddress.ConcatPath(
            "_api/web/lists('{0}')/items({1})/likedby",
            objectIdentity
                .Split(':')
                .SkipLast(2)
                .Last(),
            listItemObject.Id
        );
        return await this.ClientContext.GetObjectAsync<ODataV1ObjectEnumerable<LikedUser>>(requestUrl);
    }

    public async Task LikeObjectAsync(Comment commentObject)
    {
        var requestUrl = this.ClientContext.BaseAddress.ConcatPath(
            "_api/web/lists('{0}')/items({1})/comments({2})/like",
            commentObject.ListId,
            commentObject.ItemId,
            commentObject.Id
        );
        await this.ClientContext.PostObjectAsync(requestUrl, null);
    }

    public async Task LikeObjectAsync(ListItem listItemObject)
    {
        var objectIdentity = listItemObject.ObjectIdentity;
        _ = objectIdentity ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
        var requestUrl = this.ClientContext.BaseAddress.ConcatPath(
            "_api/web/lists('{0}')/items({1})/like",
            objectIdentity
                .Split(':')
                .SkipLast(2)
                .Last(),
            listItemObject.Id
        );
        await this.ClientContext.PostObjectAsync(requestUrl, null);
    }

    public async Task UnlikeObjectAsync(Comment commentObject)
    {
        var requestUrl = this.ClientContext.BaseAddress.ConcatPath(
            "_api/web/lists('{0}')/items({1})/comments({2})/unlike",
            commentObject.ListId,
            commentObject.ItemId,
            commentObject.Id
        );
        await this.ClientContext.PostObjectAsync(requestUrl, null);
    }

    public async Task UnlikeObjectAsync(ListItem listItemObject)
    {
        var objectIdentity = listItemObject.ObjectIdentity;
        _ = objectIdentity ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
        var requestUrl = this.ClientContext.BaseAddress.ConcatPath(
            "_api/web/lists('{0}')/items({1})/unlike",
            objectIdentity
                .Split(':')
                .SkipLast(2)
                .Last(),
            listItemObject.Id
        );
        await this.ClientContext.PostObjectAsync(requestUrl, null);
    }

}

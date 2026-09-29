//
// Copyright (c) 2018-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V2;
using Karamem0.SharePoint.PowerShell.Runtime.Common;
using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Karamem0.SharePoint.PowerShell.Runtime.Services;

namespace Karamem0.SharePoint.PowerShell.Services.V2;

public interface IDriveService
{

    Task<Drive?> GetObjectAsync(Drive driveObject);

    Task<Drive?> GetObjectAsync(
        Guid siteCollectionId,
        Guid siteId,
        Guid listId
    );

    Task<Drive?> GetObjectAsync(string driveId);

    Task<IEnumerable<Drive>?> GetObjectEnumerableAsync();

}

public class DriveService(ClientContext clientContext) : ClientService(clientContext), IDriveService
{
    public async Task<Drive?> GetObjectAsync(Drive driveObject)
    {
        var requestUrl = this
            .ClientContext.BaseAddress.ConcatPath("_api/v2.0/drives/{0}", driveObject.Id)
            .ConcatQuery(ODataQuery.CreateSelect<Drive>())
            .ConcatQuery(ODataQuery.CreateExpand<Drive>());
        return await this.ClientContext.GetObjectV2Async<Drive>(requestUrl);
    }

    public async Task<Drive?> GetObjectAsync(
        Guid siteCollectionId,
        Guid siteId,
        Guid listId
    )
    {
        var requestUrl = this
            .ClientContext.BaseAddress.ConcatPath(
                "_api/v2.0/sites/{0},{1},{2}/lists/{3}/drive",
                this.ClientContext.BaseAddress.Host,
                siteCollectionId,
                siteId,
                listId
            )
            .ConcatQuery(ODataQuery.CreateSelect<Drive>())
            .ConcatQuery(ODataQuery.CreateExpand<Drive>());
        return await this.ClientContext.GetObjectV2Async<Drive>(requestUrl);
    }

    public async Task<Drive?> GetObjectAsync(string driveId)
    {
        var requestUrl = this
            .ClientContext.BaseAddress.ConcatPath("_api/v2.0/drives/{0}", driveId)
            .ConcatQuery(ODataQuery.CreateSelect<Drive>())
            .ConcatQuery(ODataQuery.CreateExpand<Drive>());
        return await this.ClientContext.GetObjectV2Async<Drive>(requestUrl);
    }

    public async Task<IEnumerable<Drive>?> GetObjectEnumerableAsync()
    {
        var requestUrl = this
            .ClientContext.BaseAddress.ConcatPath("_api/v2.0/drives")
            .ConcatQuery(ODataQuery.CreateSelect<Drive>())
            .ConcatQuery(ODataQuery.CreateExpand<Drive>());
        return await this.ClientContext.GetObjectV2Async<ODataV2ObjectEnumerable<Drive>>(requestUrl);
    }

}

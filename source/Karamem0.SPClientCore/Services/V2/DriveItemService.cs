//
// Copyright (c) 2018-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Models.V2;
using Karamem0.SharePoint.PowerShell.Resources;
using Karamem0.SharePoint.PowerShell.Runtime.Common;
using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Karamem0.SharePoint.PowerShell.Runtime.Services;
using Karamem0.SharePoint.PowerShell.Services.V2.Utilities;

namespace Karamem0.SharePoint.PowerShell.Services.V2;

public interface IDriveItemService
{

    Task<DriveItem?> GetObjectAsync(DriveItem driveItemObject);

    Task<DriveItem?> GetObjectAsync(Models.V1.Folder folderObject);

    Task<DriveItem?> GetObjectAsync(Models.V1.File fileObject);

    Task<DriveItem?> GetObjectAsync(ListItem listItemObject);

    Task<DriveItem?> GetObjectAsync(Uri driveItemUrl);

    Task<DriveItem?> GetObjectAsync(Drive driveObject, string driveItemId);

    Task<DriveItem?> GetObjectAsync(Drive driveObject, Uri DriveItemPath);

    Task<IEnumerable<DriveItem>?> GetObjectEnumerableAsync(Drive driveObject);

    Task<IEnumerable<DriveItem>?> GetObjectEnumerableAsync(DriveItem driveItemObject);

}

public class DriveItemService(ClientContext clientContext) : ClientService(clientContext), IDriveItemService
{
    public async Task<DriveItem?> GetObjectAsync(DriveItem driveItemObject)
    {
        var parentReference = driveItemObject.ParentReference;
        _ = parentReference ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
        var requestUrl = this
            .ClientContext.BaseAddress.ConcatPath(
                "_api/v2.0/drives/{0}/items/{1}",
                parentReference.DriveId,
                driveItemObject.Id
            )
            .ConcatQuery(ODataQuery.CreateSelect<DriveItem>())
            .ConcatQuery(ODataQuery.CreateExpand<DriveItem>());
        return await this.ClientContext.GetObjectV2Async<DriveItem>(requestUrl);
    }

    public async Task<DriveItem?> GetObjectAsync(Models.V1.Folder folderObject)
    {
        var serverRelativeUrl = folderObject.ServerRelativeUrl;
        _ = serverRelativeUrl ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
        var requestUrl = this
            .ClientContext.BaseAddress.ConcatPath(
                "_api/v2.0/shares/{0}/driveitem",
                SharingUrl.Create(new Uri(this.ClientContext.BaseAddress.GetAuthority(), UriKind.Absolute), serverRelativeUrl)
            )
            .ConcatQuery(ODataQuery.CreateSelect<DriveItem>())
            .ConcatQuery(ODataQuery.CreateExpand<DriveItem>());
        return await this.ClientContext.GetObjectV2Async<DriveItem>(requestUrl);
    }

    public async Task<DriveItem?> GetObjectAsync(Models.V1.File fileObject)
    {
        var serverRelativeUrl = fileObject.ServerRelativeUrl;
        _ = serverRelativeUrl ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
        var requestUrl = this
            .ClientContext.BaseAddress.ConcatPath(
                "_api/v2.0/shares/{0}/driveitem",
                SharingUrl.Create(new Uri(this.ClientContext.BaseAddress.GetAuthority(), UriKind.Absolute), serverRelativeUrl)
            )
            .ConcatQuery(ODataQuery.CreateSelect<DriveItem>())
            .ConcatQuery(ODataQuery.CreateExpand<DriveItem>());
        return await this.ClientContext.GetObjectV2Async<DriveItem>(requestUrl);
    }

    public async Task<DriveItem?> GetObjectAsync(ListItem listItemObject)
    {
        var objectIdentity = listItemObject.ObjectIdentity;
        _ = objectIdentity ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
        var items = objectIdentity
            .Split(':')
            .OfType<string>()
            .Reverse()
            .ToArray();
        var requestUrl = this
            .ClientContext.BaseAddress.ConcatPath(
                "_api/v2.0/sites/{0},{1},{2}/lists/{3}/items/{4}/driveitem",
                this.ClientContext.BaseAddress.Host,
                Guid.Parse(items[6]),
                Guid.Parse(items[4]),
                Guid.Parse(items[2]),
                listItemObject.Id
            )
            .ConcatQuery(ODataQuery.CreateSelect<DriveItem>())
            .ConcatQuery(ODataQuery.CreateExpand<DriveItem>());
        return await this.ClientContext.GetObjectV2Async<DriveItem>(requestUrl);
    }

    public async Task<DriveItem?> GetObjectAsync(Uri driveItemUrl)
    {
        var requestUrl = this
            .ClientContext.BaseAddress.ConcatPath("_api/v2.0/shares/{0}/driveitem", SharingUrl.Create(driveItemUrl))
            .ConcatQuery(ODataQuery.CreateSelect<DriveItem>())
            .ConcatQuery(ODataQuery.CreateExpand<DriveItem>());
        return await this.ClientContext.GetObjectV2Async<DriveItem>(requestUrl);
    }

    public async Task<DriveItem?> GetObjectAsync(Drive driveObject, string driveItemId)
    {
        var requestUrl = this
            .ClientContext.BaseAddress.ConcatPath(
                "_api/v2.0/drives/{0}/items/{1}",
                driveObject.Id,
                driveItemId
            )
            .ConcatQuery(ODataQuery.CreateSelect<DriveItem>())
            .ConcatQuery(ODataQuery.CreateExpand<DriveItem>());
        return await this.ClientContext.GetObjectV2Async<DriveItem>(requestUrl);
    }

    public async Task<DriveItem?> GetObjectAsync(Drive driveObject, Uri driveItemPath)
    {
        var requestUrl = this
            .ClientContext.BaseAddress.ConcatPath(
                "_api/v2.0/drives/{0}/items/root:/{1}",
                driveObject.Id,
                driveItemPath
            )
            .ConcatQuery(ODataQuery.CreateSelect<DriveItem>())
            .ConcatQuery(ODataQuery.CreateExpand<DriveItem>());
        return await this.ClientContext.GetObjectV2Async<DriveItem>(requestUrl);
    }

    public async Task<IEnumerable<DriveItem>?> GetObjectEnumerableAsync(Drive driveObject)
    {
        var requestUrl = this
            .ClientContext.BaseAddress.ConcatPath("_api/v2.0/drives/{0}/root/children", driveObject.Id)
            .ConcatQuery(ODataQuery.CreateSelect<DriveItem>());
        return await this.ClientContext.GetObjectV2Async<ODataV2ObjectEnumerable<DriveItem>>(requestUrl);
    }

    public async Task<IEnumerable<DriveItem>?> GetObjectEnumerableAsync(DriveItem driveItemObject)
    {
        var parentReference = driveItemObject.ParentReference;
        _ = parentReference ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
        var requestUrl = this
            .ClientContext.BaseAddress.ConcatPath(
                "_api/v2.0/drives/{0}/items/{1}/children",
                parentReference.DriveId,
                driveItemObject.Id
            )
            .ConcatQuery(ODataQuery.CreateSelect<DriveItem>());
        return await this.ClientContext.GetObjectV2Async<ODataV2ObjectEnumerable<DriveItem>>(requestUrl);
    }

}

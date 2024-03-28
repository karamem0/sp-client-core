//
// Copyright (c) 2018-2024 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Models.V2;
using Karamem0.SharePoint.PowerShell.Runtime.Common;
using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Karamem0.SharePoint.PowerShell.Runtime.Services;
using Karamem0.SharePoint.PowerShell.Services.V2.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Services.V2;

public interface IDriveItemService
{

    DriveItem GetObject(DriveItem driveItemObject);

    DriveItem GetObject(Models.V1.Folder folderObject);

    DriveItem GetObject(Models.V1.File fileObject);

    DriveItem GetObject(ListItem listItemObject);

    DriveItem GetObject(Uri driveItemUrl);

    DriveItem GetObject(Drive driveObject, string driveItemId);

    DriveItem GetObject(Drive driveObject, Uri DriveItemPath);

    IEnumerable<DriveItem> GetObjectEnumerable(Drive driveObject);

    IEnumerable<DriveItem> GetObjectEnumerable(DriveItem driveItemObject);

}

public class DriveItemService : ClientService, IDriveItemService
{

    public DriveItemService(ClientContext clientContext) : base(clientContext)
    {
    }

    public DriveItem GetObject(DriveItem driveItemObject)
    {
        _ = driveItemObject ?? throw new ArgumentNullException(nameof(driveItemObject));
        var requestUrl = this.ClientContext.BaseAddress
            .ConcatPath(
                "_api/v2.0/drives/{0}/items/{1}",
                driveItemObject.ParentReference.DriveId,
                driveItemObject.Id)
            .ConcatQuery(ODataQuery.CreateSelect<DriveItem>())
            .ConcatQuery(ODataQuery.CreateExpand<DriveItem>());
        return this.ClientContext.GetObjectV2<DriveItem>(requestUrl);
    }

    public DriveItem GetObject(Models.V1.Folder folderObject)
    {
        _ = folderObject ?? throw new ArgumentNullException(nameof(folderObject));
        var requestUrl = this.ClientContext.BaseAddress
            .ConcatPath(
                "_api/v2.0/shares/{0}/driveitem",
                SharingUrl.Create(
                    this.ClientContext.BaseAddress.GetAuthority(),
                    folderObject.ServerRelativeUrl))
            .ConcatQuery(ODataQuery.CreateSelect<DriveItem>())
            .ConcatQuery(ODataQuery.CreateExpand<DriveItem>());
        return this.ClientContext.GetObjectV2<DriveItem>(requestUrl);
    }

    public DriveItem GetObject(Models.V1.File fileObject)
    {
        _ = fileObject ?? throw new ArgumentNullException(nameof(fileObject));
        var requestUrl = this.ClientContext.BaseAddress
            .ConcatPath(
                "_api/v2.0/shares/{0}/driveitem",
                SharingUrl.Create(
                    this.ClientContext.BaseAddress.GetAuthority(),
                    fileObject.ServerRelativeUrl))
            .ConcatQuery(ODataQuery.CreateSelect<DriveItem>())
            .ConcatQuery(ODataQuery.CreateExpand<DriveItem>());
        return this.ClientContext.GetObjectV2<DriveItem>(requestUrl);
    }

    public DriveItem GetObject(ListItem listItemObject)
    {
        _ = listItemObject ?? throw new ArgumentNullException(nameof(listItemObject));
        var items = listItemObject.ObjectIdentity.Split(':').Reverse().ToArray();
        var requestUrl = this.ClientContext.BaseAddress
            .ConcatPath(
                "_api/v2.0/sites/{0},{1},{2}/lists/{3}/items/{4}/driveitem",
                this.ClientContext.BaseAddress.Host,
                Guid.Parse(items[6]),
                Guid.Parse(items[4]),
                Guid.Parse(items[2]),
                listItemObject.Id)
            .ConcatQuery(ODataQuery.CreateSelect<DriveItem>())
            .ConcatQuery(ODataQuery.CreateExpand<DriveItem>());
        return this.ClientContext.GetObjectV2<DriveItem>(requestUrl);
    }

    public DriveItem GetObject(Uri driveItemUrl)
    {
        _ = driveItemUrl ?? throw new ArgumentNullException(nameof(driveItemUrl));
        var requestUrl = this.ClientContext.BaseAddress
            .ConcatPath(
                "_api/v2.0/shares/{0}/driveitem",
                SharingUrl.Create(driveItemUrl.ToString()))
            .ConcatQuery(ODataQuery.CreateSelect<DriveItem>())
            .ConcatQuery(ODataQuery.CreateExpand<DriveItem>());
        return this.ClientContext.GetObjectV2<DriveItem>(requestUrl);
    }

    public DriveItem GetObject(Drive driveObject, string driveItemId)
    {
        _ = driveObject ?? throw new ArgumentNullException(nameof(driveObject));
        _ = driveItemId ?? throw new ArgumentNullException(nameof(driveItemId));
        var requestUrl = this.ClientContext.BaseAddress
            .ConcatPath(
                "_api/v2.0/drives/{0}/items/{1}",
                driveObject.Id,
                driveItemId)
            .ConcatQuery(ODataQuery.CreateSelect<DriveItem>())
            .ConcatQuery(ODataQuery.CreateExpand<DriveItem>());
        return this.ClientContext.GetObjectV2<DriveItem>(requestUrl);
    }

    public DriveItem GetObject(Drive driveObject, Uri driveItemPath)
    {
        _ = driveObject ?? throw new ArgumentNullException(nameof(driveObject));
        _ = driveItemPath ?? throw new ArgumentNullException(nameof(driveItemPath));
        var requestUrl = this.ClientContext.BaseAddress
            .ConcatPath(
                "_api/v2.0/drives/{0}/items/root:/{1}",
                driveObject.Id,
                driveItemPath)
            .ConcatQuery(ODataQuery.CreateSelect<DriveItem>())
            .ConcatQuery(ODataQuery.CreateExpand<DriveItem>());
        return this.ClientContext.GetObjectV2<DriveItem>(requestUrl);
    }

    public IEnumerable<DriveItem> GetObjectEnumerable(Drive driveObject)
    {
        _ = driveObject ?? throw new ArgumentNullException(nameof(driveObject));
        var requestUrl = this.ClientContext.BaseAddress
            .ConcatPath(
                "_api/v2.0/drives/{0}/root/children",
                driveObject.Id)
            .ConcatQuery(ODataQuery.CreateSelect<DriveItem>());
        return this.ClientContext.GetObjectV2<ODataV2ObjectEnumerable<DriveItem>>(requestUrl);
    }

    public IEnumerable<DriveItem> GetObjectEnumerable(DriveItem driveItemObject)
    {
        _ = driveItemObject ?? throw new ArgumentNullException(nameof(driveItemObject));
        var requestUrl = this.ClientContext.BaseAddress
            .ConcatPath(
                "_api/v2.0/drives/{0}/items/{1}/children",
                driveItemObject.ParentReference.DriveId,
                driveItemObject.Id)
            .ConcatQuery(ODataQuery.CreateSelect<DriveItem>());
        return this.ClientContext.GetObjectV2<ODataV2ObjectEnumerable<DriveItem>>(requestUrl);
    }

}

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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Services.V2;

public interface IDriveService
{

    Drive GetObject(Drive driveObject);

    Drive GetObject(Guid? siteCollectionId, Guid? siteId, Guid? listId);

    Drive GetObject(string driveId);

    IEnumerable<Drive> GetObjectEnumerable();

}

public class DriveService(ClientContext clientContext) : ClientService(clientContext), IDriveService
{
    public Drive GetObject(Drive driveObject)
    {
        _ = driveObject ?? throw new ArgumentNullException(nameof(driveObject));
        var requestUrl = this.ClientContext.BaseAddress
            .ConcatPath(
                "_api/v2.0/drives/{0}",
                driveObject.Id)
            .ConcatQuery(ODataQuery.CreateSelect<Drive>())
            .ConcatQuery(ODataQuery.CreateExpand<Drive>());
        return this.ClientContext.GetObjectV2<Drive>(requestUrl);
    }

    public Drive GetObject(Guid? siteCollectionId, Guid? siteId, Guid? listId)
    {
        _ = siteCollectionId ?? throw new ArgumentNullException(nameof(siteCollectionId));
        _ = siteId ?? throw new ArgumentNullException(nameof(siteId));
        _ = listId ?? throw new ArgumentNullException(nameof(listId));
        var requestUrl = this.ClientContext.BaseAddress
            .ConcatPath(
                "_api/v2.0/sites/{0},{1},{2}/lists/{3}/drive",
                this.ClientContext.BaseAddress.Host,
                siteCollectionId,
                siteId,
                listId)
            .ConcatQuery(ODataQuery.CreateSelect<Drive>())
            .ConcatQuery(ODataQuery.CreateExpand<Drive>());
        return this.ClientContext.GetObjectV2<Drive>(requestUrl);
    }

    public Drive GetObject(string driveId)
    {
        _ = driveId ?? throw new ArgumentNullException(nameof(driveId));
        var requestUrl = this.ClientContext.BaseAddress
            .ConcatPath(
                "_api/v2.0/drives/{0}",
                driveId)
            .ConcatQuery(ODataQuery.CreateSelect<Drive>())
            .ConcatQuery(ODataQuery.CreateExpand<Drive>());
        return this.ClientContext.GetObjectV2<Drive>(requestUrl);
    }

    public IEnumerable<Drive> GetObjectEnumerable()
    {
        var requestUrl = this.ClientContext.BaseAddress
            .ConcatPath("_api/v2.0/drives")
            .ConcatQuery(ODataQuery.CreateSelect<Drive>())
            .ConcatQuery(ODataQuery.CreateExpand<Drive>());
        return this.ClientContext.GetObjectV2<ODataV2ObjectEnumerable<Drive>>(requestUrl);
    }

}

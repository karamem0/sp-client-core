//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Karamem0.SharePoint.PowerShell.Runtime.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Services.V1;

public interface IChangeService
{

    IEnumerable<Change>? GetObjectEnumerable(SiteCollection siteCollectionObject, ChangeQuery changeQueryObject);

    IEnumerable<Change>? GetObjectEnumerable(Site siteObject, ChangeQuery changeQueryObject);

    IEnumerable<Change>? GetObjectEnumerable(List listObject, ChangeQuery changeQueryObject);

}

public class ChangeService(ClientContext clientContext) : ClientService(clientContext), IChangeService
{

    public IEnumerable<Change>? GetObjectEnumerable(SiteCollection siteCollectionObject, ChangeQuery changeQueryObject)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(siteCollectionObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath1.Id,
                "GetChanges",
                requestPayload.CreateParameter(changeQueryObject)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(
                objectPathId,
                ClientQuery.Empty,
                ClientQuery.Create(true, typeof(Change))
            )
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<ChangeEnumerable>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public IEnumerable<Change>? GetObjectEnumerable(Site siteObject, ChangeQuery changeQueryObject)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(siteObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath1.Id,
                "GetChanges",
                requestPayload.CreateParameter(changeQueryObject)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(
                objectPathId,
                ClientQuery.Empty,
                ClientQuery.Create(true, typeof(Change))
            )
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<ChangeEnumerable>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public IEnumerable<Change>? GetObjectEnumerable(List listObject, ChangeQuery changeQueryObject)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(listObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath1.Id,
                "GetChanges",
                requestPayload.CreateParameter(changeQueryObject)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(
                objectPathId,
                ClientQuery.Empty,
                ClientQuery.Create(true, typeof(Change))
            )
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<ChangeEnumerable>(requestPayload.GetActionId<ClientActionQuery>());
    }

}

//
// Copyright (c) 2018-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Karamem0.SharePoint.PowerShell.Runtime.Services;

namespace Karamem0.SharePoint.PowerShell.Services.V1;

public interface IChangeService
{

    Task<IEnumerable<Change>?> GetObjectEnumerableAsync(
        SiteCollection siteCollectionObject,
        ChangeQuery changeQueryObject,
        bool selectAllProperties = true
    );

    Task<IEnumerable<Change>?> GetObjectEnumerableAsync(
        Site siteObject,
        ChangeQuery changeQueryObject,
        bool selectAllProperties = true
    );

    Task<IEnumerable<Change>?> GetObjectEnumerableAsync(
        List listObject,
        ChangeQuery changeQueryObject,
        bool selectAllProperties = true
    );

}

public class ChangeService(ClientContext clientContext) : ClientService(clientContext), IChangeService
{

    public async Task<IEnumerable<Change>?> GetObjectEnumerableAsync(
        SiteCollection siteCollectionObject,
        ChangeQuery changeQueryObject,
        bool selectAllProperties = true
    )
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
                ClientQuery.Create(selectAllProperties, typeof(Change))
            )
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<ChangeEnumerable>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<IEnumerable<Change>?> GetObjectEnumerableAsync(
        Site siteObject,
        ChangeQuery changeQueryObject,
        bool selectAllProperties = true
    )
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
                ClientQuery.Create(selectAllProperties, typeof(Change))
            )
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<ChangeEnumerable>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<IEnumerable<Change>?> GetObjectEnumerableAsync(
        List listObject,
        ChangeQuery changeQueryObject,
        bool selectAllProperties = true
    )
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
                ClientQuery.Create(selectAllProperties, typeof(Change))
            )
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<ChangeEnumerable>(requestPayload.GetActionId<ClientActionQuery>()));
    }

}

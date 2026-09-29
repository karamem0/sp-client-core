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

public interface ISiteCollectionFeatureService
{

    Task AddObjectAsync(
        Guid featureId,
        bool force,
        FeatureDefinitionScope scope
    );

    Task<Feature?> GetObjectAsync(Feature featureObject);

    Task<Feature?> GetObjectAsync(Feature featureObject, bool selectAllProperties = true);

    Task<Feature?> GetObjectAsync(Guid featureId, bool selectAllProperties = true);

    Task<IEnumerable<Feature>?> GetObjectEnumerableAsync(bool selectAllProperties = true);

    Task RemoveObjectAsync(Guid featureId, bool force);

}

public class SiteCollectionFeatureService(ClientContext clientContext) : ClientService<Feature>(clientContext), ISiteCollectionFeatureService
{

    public async Task AddObjectAsync(
        Guid featureId,
        bool force,
        FeatureDefinitionScope scope
    )
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Site"));
        var objectPath3 = requestPayload.Add(ObjectPathProperty.Create(objectPath2.Id, "Features"));
        var objectPath4 = requestPayload.Add(
            objectPath3,
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "Add",
                requestPayload.CreateParameter(featureId),
                requestPayload.CreateParameter(force),
                requestPayload.CreateParameter(scope)
            )
        );
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

    public async Task<Feature?> GetObjectAsync(Guid featureId, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Site"));
        var objectPath3 = requestPayload.Add(ObjectPathProperty.Create(objectPath2.Id, "Features"));
        var objectPath4 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath3.Id,
                "GetById",
                requestPayload.CreateParameter(featureId)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(Feature)))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<Feature>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<IEnumerable<Feature>?> GetObjectEnumerableAsync(bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Site"));
        var objectPath3 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath2.Id, "Features"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(
                objectPathId,
                ClientQuery.Empty,
                ClientQuery.Create(selectAllProperties, typeof(Feature))
            )
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<FeatureEnumerable>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task RemoveObjectAsync(Guid featureId, bool force)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Site"));
        var objectPath3 = requestPayload.Add(ObjectPathProperty.Create(objectPath2.Id, "Features"));
        var objectPath4 = requestPayload.Add(
            objectPath3,
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "Remove",
                requestPayload.CreateParameter(featureId),
                requestPayload.CreateParameter(force)
            )
        );
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

}

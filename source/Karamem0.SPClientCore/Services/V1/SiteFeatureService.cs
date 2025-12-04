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

namespace Karamem0.SharePoint.PowerShell.Services.V1;

public interface ISiteFeatureService
{

    void AddObject(
        Guid featureId,
        bool force,
        FeatureDefinitionScope scope
    );

    Feature? GetObject(Feature featureObject);

    Feature? GetObject(Guid featureId);

    IEnumerable<Feature>? GetObjectEnumerable();

    void RemoveObject(Guid featureId, bool force);

}

public class SiteFeatureService(ClientContext clientContext) : ClientService<Feature>(clientContext), ISiteFeatureService
{

    public void AddObject(
        Guid featureId,
        bool force,
        FeatureDefinitionScope scope
    )
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
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
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public Feature? GetObject(Guid featureId)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(ObjectPathProperty.Create(objectPath2.Id, "Features"));
        var objectPath4 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath3.Id,
                "GetById",
                requestPayload.CreateParameter(featureId)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(Feature)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<Feature>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public IEnumerable<Feature>? GetObjectEnumerable()
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath2.Id, "Features"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(
                objectPathId,
                ClientQuery.Empty,
                ClientQuery.Create(true, typeof(Feature))
            )
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<FeatureEnumerable>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public void RemoveObject(Guid featureId, bool force)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
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
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

}

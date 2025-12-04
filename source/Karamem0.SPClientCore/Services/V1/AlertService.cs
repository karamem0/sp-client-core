//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Resources;
using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Karamem0.SharePoint.PowerShell.Runtime.Services;

namespace Karamem0.SharePoint.PowerShell.Services.V1;

public interface IAlertService
{

    Guid AddObject(IReadOnlyDictionary<string, object?> creationInfo);

    Alert? GetObject(Alert alertObject);

    Alert? GetObject(Guid alertId);

    IEnumerable<Alert>? GetObjectEnumerable();

    void RemoveObject(Alert alertObject);

    void SetObject(Alert alertObject, IReadOnlyDictionary<string, object?> modificationInfo);

}

public class AlertService(ClientContext clientContext) : ClientService<Alert>(clientContext), IAlertService
{

    public Guid AddObject(IReadOnlyDictionary<string, object?> creationInfo)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(ObjectPathProperty.Create(objectPath2.Id, "Alerts"));
        var objectPath4 = requestPayload.Add(
            objectPath3,
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "Add",
                requestPayload.CreateParameter(ClientValueObject.Create<AlertCreationInfo>(creationInfo))
            )
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<Guid>(requestPayload.GetActionId<ClientActionMethod>());
    }

    public override Alert? GetObject(Alert alertObject)
    {
        var conditions = new List<string>();
        if (alertObject.AlertFrequency != AlertFrequency.Immediate)
        {
            conditions.Add("NotImmediate");
        }
        if (alertObject.AlertType == AlertType.ListItem)
        {
            conditions.Add("ListItem");
        }
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            ObjectPathIdentity.Create(alertObject.ObjectIdentity),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(
                objectPathId,
                ClientQuery.Create(
                    true,
                    typeof(Alert),
                    [.. conditions]
                )
            )
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<Alert>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public Alert? GetObject(Guid alertId)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(ObjectPathProperty.Create(objectPath2.Id, "Alerts"));
        var objectPath4 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath3.Id,
                "GetById",
                requestPayload.CreateParameter(alertId)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(Alert)))
        );
        var clientObject = this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<Alert>(requestPayload.GetActionId<ClientActionQuery>());
        return clientObject is null ? null : this.GetObject(clientObject);
    }

    public IEnumerable<Alert>? GetObjectEnumerable()
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath2.Id, "Alerts"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(
                objectPathId,
                ClientQuery.Empty,
                ClientQuery.Create(true, typeof(Alert))
            )
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<AlertEnumerable>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public override void RemoveObject(Alert alertObject)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(ObjectPathProperty.Create(objectPath2.Id, "Alerts"));
        var objectPath4 = requestPayload.Add(
            objectPath3,
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "DeleteAlert",
                requestPayload.CreateParameter(alertObject.Id)
            )
        );
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public override void SetObject(Alert alertObject, IReadOnlyDictionary<string, object?> modificationInfo)
    {
        var requestPayload = new ClientRequestPayload();
        var objectName = alertObject.ObjectType;
        _ = objectName ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
        var objectType = ClientObject.GetType(objectName);
        var objectPath1 = requestPayload.Add(
            ObjectPathIdentity.Create(alertObject.ObjectIdentity),
            requestPayload.CreateSetPropertyDelegates(alertObject, modificationInfo)
        );
        var objectPath2 = requestPayload.Add(objectPath1, objectPathId => ClientActionMethod.Create(objectPathId, "UpdateAlert"));
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

}

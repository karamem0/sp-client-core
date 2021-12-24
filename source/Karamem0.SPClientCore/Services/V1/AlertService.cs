//
// Copyright (c) 2022 karamem0
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

namespace Karamem0.SharePoint.PowerShell.Services.V1
{

    public interface IAlertService
    {

        Guid AddObject(IReadOnlyDictionary<string, object> creationInformation);

        Alert GetObject(Alert alertObject);

        Alert GetObject(Guid? alertId);

        IEnumerable<Alert> GetObjectEnumerable();

        void RemoveObject(Alert alertObject);

        void SetObject(Alert alertObject, IReadOnlyDictionary<string, object> modificationInformation);

    }

    public class AlertService : ClientService<Alert>, IAlertService
    {

        public AlertService(ClientContext clientContext) : base(clientContext)
        {
        }

        public Guid AddObject(IReadOnlyDictionary<string, object> creationInformation)
        {
            _ = creationInformation ?? throw new ArgumentNullException(nameof(creationInformation));
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathStaticProperty(typeof(Context), "Current"));
            var objectPath2 = requestPayload.Add(
                new ObjectPathProperty(objectPath1.Id, "Web"));
            var objectPath3 = requestPayload.Add(
                new ObjectPathProperty(objectPath2.Id, "Alerts"));
            var objectPath4 = requestPayload.Add(
                objectPath3,
                objectPathId => new ClientActionMethod(
                    objectPathId,
                    "Add",
                    requestPayload.CreateParameter(new AlertCreationInformation(creationInformation))));
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<Guid>(requestPayload.GetActionId<ClientActionMethod>());
        }

        public override Alert GetObject(Alert clientObject)
        {
            _ = clientObject ?? throw new ArgumentNullException(nameof(clientObject));
            var conditions = new List<string>();
            if (clientObject.AlertFrequency != AlertFrequency.Immediate)
            {
                conditions.Add("NotImmediate");
            }
            if (clientObject.AlertType == AlertType.ListItem)
            {
                conditions.Add("ListItem");
            }
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathIdentity(clientObject.ObjectIdentity),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
                objectPathId => new ClientActionQuery(objectPathId)
                {
                    Query = new ClientQuery(true, typeof(Alert), conditions.ToArray())
                });
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<Alert>(requestPayload.GetActionId<ClientActionQuery>());
        }

        public Alert GetObject(Guid? alertId)
        {
            _ = alertId ?? throw new ArgumentNullException(nameof(alertId));
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathStaticProperty(typeof(Context), "Current"));
            var objectPath2 = requestPayload.Add(
                new ObjectPathProperty(objectPath1.Id, "Web"));
            var objectPath3 = requestPayload.Add(
                new ObjectPathProperty(objectPath2.Id, "Alerts"));
            var objectPath4 = requestPayload.Add(
                new ObjectPathMethod(
                    objectPath3.Id,
                    "GetById",
                    requestPayload.CreateParameter(alertId)),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
                objectPathId => new ClientActionQuery(objectPathId)
                {
                    Query = new ClientQuery(true, typeof(Alert))
                });
            return this.GetObject(this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<Alert>(requestPayload.GetActionId<ClientActionQuery>()));
        }

        public IEnumerable<Alert> GetObjectEnumerable()
        {
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathStaticProperty(typeof(Context), "Current"));
            var objectPath2 = requestPayload.Add(
                new ObjectPathProperty(objectPath1.Id, "Web"));
            var objectPath3 = requestPayload.Add(
                new ObjectPathProperty(objectPath2.Id, "Alerts"),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
                objectPathId => new ClientActionQuery(objectPathId)
                {
                    Query = ClientQuery.Empty,
                    ChildItemQuery = new ClientQuery(true, typeof(Alert))
                });
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<AlertEnumerable>(requestPayload.GetActionId<ClientActionQuery>());
        }

        public override void RemoveObject(Alert alertObject)
        {
            _ = alertObject ?? throw new ArgumentNullException(nameof(alertObject));
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathStaticProperty(typeof(Context), "Current"));
            var objectPath2 = requestPayload.Add(
                new ObjectPathProperty(objectPath1.Id, "Web"));
            var objectPath3 = requestPayload.Add(
                new ObjectPathProperty(objectPath2.Id, "Alerts"));
            var objectPath4 = requestPayload.Add(
                objectPath3,
                objectPathId => new ClientActionMethod(
                    objectPathId,
                    "DeleteAlert",
                    requestPayload.CreateParameter(alertObject.Id)));
            _ = this.ClientContext.ProcessQuery(requestPayload);
        }

        public override void SetObject(Alert alertObject, IReadOnlyDictionary<string, object> modificationInformation)
        {
            _ = alertObject ?? throw new ArgumentNullException(nameof(alertObject));
            _ = modificationInformation ?? throw new ArgumentNullException(nameof(modificationInformation));
            var requestPayload = new ClientRequestPayload();
            var objectName = alertObject.ObjectType;
            var objectType = ClientObject.GetType(objectName);
            var objectPath1 = requestPayload.Add(
                new ObjectPathIdentity(alertObject.ObjectIdentity),
                requestPayload.CreateSetPropertyDelegates(alertObject, modificationInformation).ToArray());
            var objectPath2 = requestPayload.Add(
                objectPath1,
                objectPathId => new ClientActionMethod(objectPathId, "UpdateAlert"));
            _ = this.ClientContext.ProcessQuery(requestPayload);
        }

    }

}

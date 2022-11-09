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

    public interface IViewService
    {

        View AddObject(List listObject, IReadOnlyDictionary<string, object> creationInfo);

        View GetObject(View viewObject);

        View GetObject(List listObject, Guid? viewId);

        View GetObject(List listObject, string viewTitle);

        IEnumerable<View> GetObjectEnumerable(List listObject);

        void RemoveObject(View viewObject);

        void SetObject(View viewObject, IReadOnlyDictionary<string, object> modificationInfo);

    }

    public class ViewService : ClientService<View>, IViewService
    {

        public ViewService(ClientContext clientContext) : base(clientContext)
        {
        }

        public View AddObject(List listObject, IReadOnlyDictionary<string, object> creationInfo)
        {
            _ = listObject ?? throw new ArgumentNullException(nameof(listObject));
            _ = creationInfo ?? throw new ArgumentNullException(nameof(creationInfo));
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathIdentity(listObject.ObjectIdentity));
            var objectPath2 = requestPayload.Add(
                new ObjectPathProperty(objectPath1.Id, "Views"));
            var objectPath3 = requestPayload.Add(
                new ObjectPathMethod(
                    objectPath2.Id,
                    "Add",
                    requestPayload.CreateParameter(new ViewCreationInfo(creationInfo))),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
                objectPathId => new ClientActionQuery(objectPathId)
                {
                    Query = new ClientQuery(true, typeof(View))
                });
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<View>(requestPayload.GetActionId<ClientActionQuery>());
        }

        public View GetObject(List listObject, Guid? viewId)
        {
            _ = listObject ?? throw new ArgumentNullException(nameof(listObject));
            _ = viewId ?? throw new ArgumentNullException(nameof(viewId));
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathIdentity(listObject.ObjectIdentity));
            var objectPath2 = requestPayload.Add(
                new ObjectPathProperty(objectPath1.Id, "Views"));
            var objectPath3 = requestPayload.Add(
                new ObjectPathMethod(
                    objectPath2.Id,
                    "GetById",
                    requestPayload.CreateParameter(viewId)),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId));
            var objectPath4 = requestPayload.Add(
                objectPath3,
                objectPathId => new ClientActionQuery(objectPathId)
                {
                    Query = new ClientQuery(true, typeof(View))
                });
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<View>(requestPayload.GetActionId<ClientActionQuery>());
        }

        public View GetObject(List listObject, string viewTitle)
        {
            _ = listObject ?? throw new ArgumentNullException(nameof(listObject));
            _ = viewTitle ?? throw new ArgumentNullException(nameof(viewTitle));
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathIdentity(listObject.ObjectIdentity));
            var objectPath2 = requestPayload.Add(
                new ObjectPathProperty(objectPath1.Id, "Views"));
            var objectPath3 = requestPayload.Add(
                new ObjectPathMethod(
                    objectPath2.Id,
                    "GetByTitle",
                    requestPayload.CreateParameter(viewTitle)),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId));
            var objectPath4 = requestPayload.Add(
                objectPath3,
                objectPathId => new ClientActionQuery(objectPathId)
                {
                    Query = new ClientQuery(true, typeof(View))
                });
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<View>(requestPayload.GetActionId<ClientActionQuery>());
        }

        public IEnumerable<View> GetObjectEnumerable(List listObject)
        {
            _ = listObject ?? throw new ArgumentNullException(nameof(listObject));
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathIdentity(listObject.ObjectIdentity));
            var objectPath2 = requestPayload.Add(
                new ObjectPathProperty(objectPath1.Id, "Views"),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
                objectPathId => new ClientActionQuery(objectPathId)
                {
                    Query = ClientQuery.Empty,
                    ChildItemQuery = new ClientQuery(true, typeof(View))
                });
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<ViewEnumerable>(requestPayload.GetActionId<ClientActionQuery>());
        }

    }

}

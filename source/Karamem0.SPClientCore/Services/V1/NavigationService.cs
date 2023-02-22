//
// Copyright (c) 2023 karamem0
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

    public interface INavigationService
    {

        Navigation GetObject();

        void SetObject(IReadOnlyDictionary<string, object> modificationInfo);

    }

    public class NavigationService : ClientService, INavigationService
    {

        public NavigationService(ClientContext clientContext) : base(clientContext)
        {
        }

        public Navigation GetObject()
        {
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathStaticProperty(typeof(Context), "Current"));
            var objectPath2 = requestPayload.Add(
                new ObjectPathProperty(objectPath1.Id, "Web"));
            var objectPath3 = requestPayload.Add(
                new ObjectPathProperty(objectPath2.Id, "Navigation"),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
                objectPathId => new ClientActionQuery(objectPathId)
                {
                    Query = new ClientQuery(true, typeof(Navigation))
                });
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<Navigation>(requestPayload.GetActionId<ClientActionQuery>());
        }

        public void SetObject(IReadOnlyDictionary<string, object> modificationInfo)
        {
            _ = modificationInfo ?? throw new ArgumentNullException(nameof(modificationInfo));
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathStaticProperty(typeof(Context), "Current"));
            var objectPath2 = requestPayload.Add(
                new ObjectPathProperty(objectPath1.Id, "Web"));
            var objectPath3 = requestPayload.Add(
                new ObjectPathProperty(objectPath2.Id, "Navigation"),
                requestPayload.CreateSetPropertyDelegates(typeof(Navigation), modificationInfo).ToArray());
            var objectPath4 = requestPayload.Add(
                objectPath2,
                objectPathId => new ClientActionMethod(objectPathId, "Update"));
            _ = this.ClientContext.ProcessQuery(requestPayload);
        }

    }

}

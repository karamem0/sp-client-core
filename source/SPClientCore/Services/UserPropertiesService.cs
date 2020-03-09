//
// Copyright (c) 2020 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models;
using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Karamem0.SharePoint.PowerShell.Runtime.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Services
{

    public interface IUserPropertiesService
    {

        UserProperties GetObject();

        UserProperties GetObject(UserProperties userPropertiesObject);

        UserProperties GetObject(string userLoginName);

    }

    public class UserPropertiesService : ClientService<UserProperties>, IUserPropertiesService
    {

        public UserPropertiesService(ClientContext clientContext) : base(clientContext)
        {
        }

        public UserProperties GetObject()
        {
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathConstructor(typeof(PeopleManager)));
            var objectPath2 = requestPayload.Add(
                new ObjectPathMethod(objectPath1.Id, "GetMyProperties"),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
                objectPathId => new ClientActionQuery(objectPathId)
                {
                    Query = new ClientQuery(true, typeof(UserProperties))
                });
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<UserProperties>(requestPayload.GetActionId<ClientActionQuery>());
        }

        public UserProperties GetObject(string userLoginName)
        {
            if (userLoginName == null)
            {
                throw new ArgumentNullException(nameof(userLoginName));
            }
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathConstructor(typeof(PeopleManager)));
            var objectPath2 = requestPayload.Add(
                new ObjectPathMethod(
                    objectPath1.Id,
                    "GetPropertiesFor",
                    requestPayload.CreateParameter(userLoginName)),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
                objectPathId => new ClientActionQuery(objectPathId)
                {
                    Query = new ClientQuery(true, typeof(UserProperties))
                });
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<UserProperties>(requestPayload.GetActionId<ClientActionQuery>());
        }

    }

}

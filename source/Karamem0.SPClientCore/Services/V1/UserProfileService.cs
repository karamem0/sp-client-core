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

public interface IUserProfileService
{

    UserProfile? GetObject();

}

public class UserProfileService(ClientContext clientContext) : ClientService(clientContext), IUserProfileService
{

    public UserProfile? GetObject()
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticMethod.Create(typeof(ProfileLoader), "GetProfileLoader"));
        var objectPath2 = requestPayload.Add(
            ObjectPathMethod.Create(objectPath1.Id, "GetUserProfile"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(UserProfile)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<UserProfile>(requestPayload.GetActionId<ClientActionQuery>());
    }

}

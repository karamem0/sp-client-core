//
// Copyright (c) 2018-2024 karamem0
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

public interface ITermDescriptionService
{

    string GetObject(Term termObject, uint? lcid);

    void SetObject(Term termObject, string description, uint? lcid);

}

public class TermDescriptionService(ClientContext clientContext) : ClientService(clientContext), ITermDescriptionService
{

    public string GetObject(Term termObject, uint? lcid)
    {
        _ = termObject ?? throw new ArgumentNullException(nameof(termObject));
        _ = lcid ?? throw new ArgumentNullException(nameof(lcid));
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            new ObjectPathIdentity(termObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            objectPath1,
            objectPathId => new ClientActionMethod(
                objectPathId,
                "GetDescription",
                requestPayload.CreateParameter(lcid)));
        return this.ClientContext
            .ProcessQuery(requestPayload)
            .ToObject<string>(requestPayload.GetActionId<ClientActionMethod>());
    }

    public void SetObject(Term termObject, string description, uint? lcid)
    {
        _ = termObject ?? throw new ArgumentNullException(nameof(termObject));
        _ = description ?? throw new ArgumentNullException(nameof(description));
        _ = lcid ?? throw new ArgumentNullException(nameof(lcid));
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            new ObjectPathIdentity(termObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            objectPath1,
            objectPathId => new ClientActionMethod(
                objectPathId,
                "SetDescription",
                requestPayload.CreateParameter(description),
                requestPayload.CreateParameter(lcid)));
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

}

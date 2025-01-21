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

public interface ITermCustomPropertyService
{

    void AddObject(TermSetItem termSetItemObject, string propertyName, string propertyValue);

    void RemoveObject(TermSetItem termSetItemObject, string propertyName);

}

public class TermCustomPropertyService(ClientContext clientContext) : ClientService(clientContext), ITermCustomPropertyService
{

    public void AddObject(TermSetItem termSetItemObject, string propertyName, string propertyValue)
    {
        _ = termSetItemObject ?? throw new ArgumentNullException(nameof(termSetItemObject));
        _ = propertyName ?? throw new ArgumentNullException(nameof(propertyName));
        _ = propertyValue ?? throw new ArgumentNullException(nameof(propertyValue));
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            new ObjectPathIdentity(termSetItemObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            objectPath1,
            objectPathId => new ClientActionMethod(
                objectPathId,
                "SetCustomProperty",
                requestPayload.CreateParameter(propertyName),
                requestPayload.CreateParameter(propertyValue)));
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public void RemoveObject(TermSetItem termSetItemObject, string propertyName)
    {
        _ = termSetItemObject ?? throw new ArgumentNullException(nameof(termSetItemObject));
        _ = propertyName ?? throw new ArgumentNullException(nameof(propertyName));
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            new ObjectPathIdentity(termSetItemObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            objectPath1,
            objectPathId => new ClientActionMethod(
                objectPathId,
                "DeleteCustomProperty",
                requestPayload.CreateParameter(propertyName)));
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

}

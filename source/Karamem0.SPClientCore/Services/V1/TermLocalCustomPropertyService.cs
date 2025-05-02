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

public interface ITermLocalCustomPropertyService
{

    void AddObject(
        Term termObject,
        string propertyName,
        string propertyValue
    );

    void RemoveObject(Term termObject, string propertyName);

}

public class TermLocalCustomPropertyService(ClientContext clientContext) : ClientService(clientContext), ITermLocalCustomPropertyService
{

    public void AddObject(
        Term termObject,
        string propertyName,
        string propertyValue
    )
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(termObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            objectPath1,
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "SetLocalCustomProperty",
                requestPayload.CreateParameter(propertyName),
                requestPayload.CreateParameter(propertyValue)
            )
        );
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public void RemoveObject(Term termObject, string propertyName)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(termObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            objectPath1,
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "DeleteLocalCustomProperty",
                requestPayload.CreateParameter(propertyName)
            )
        );
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

}

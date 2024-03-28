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

public interface ITermLocalCustomPropertyService
{

    void AddObject(Term termObject, string propertyName, string propertyValue);

    void RemoveObject(Term termObject, string propertyName);

}

public class TermLocalCustomPropertyService : ClientService, ITermLocalCustomPropertyService
{

    public TermLocalCustomPropertyService(ClientContext clientContext) : base(clientContext)
    {
    }

    public void AddObject(Term termObject, string propertyName, string propertyValue)
    {
        _ = termObject ?? throw new ArgumentNullException(nameof(termObject));
        _ = propertyName ?? throw new ArgumentNullException(nameof(propertyName));
        _ = propertyValue ?? throw new ArgumentNullException(nameof(propertyValue));
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            new ObjectPathIdentity(termObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            objectPath1,
            objectPathId => new ClientActionMethod(
                objectPathId,
                "SetLocalCustomProperty",
                requestPayload.CreateParameter(propertyName),
                requestPayload.CreateParameter(propertyValue)));
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public void RemoveObject(Term termObject, string propertyName)
    {
        _ = termObject ?? throw new ArgumentNullException(nameof(termObject));
        _ = propertyName ?? throw new ArgumentNullException(nameof(propertyName));
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            new ObjectPathIdentity(termObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            objectPath1,
            objectPathId => new ClientActionMethod(
                objectPathId,
                "DeleteLocalCustomProperty",
                requestPayload.CreateParameter(propertyName)));
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

}

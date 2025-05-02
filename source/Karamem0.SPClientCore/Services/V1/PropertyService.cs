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

public interface IPropertyService
{

    PropertyValues? GetObject(Alert alertObject);

    PropertyValues? GetObject(File fileObject);

    PropertyValues? GetObject(Folder folderObject);

    PropertyValues? GetObject(ListItem listItemObject);

    PropertyValues? GetObject(Site siteObject);

}

public class PropertyService(ClientContext clientContext) : ClientService(clientContext), IPropertyService
{

    public PropertyValues? GetObject(Alert alertObject)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(alertObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath1.Id, "AllProperties"),
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<PropertyValues>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public PropertyValues? GetObject(File fileObject)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(fileObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath1.Id, "Properties"),
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<PropertyValues>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public PropertyValues? GetObject(Folder folderObject)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(folderObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath1.Id, "Properties"),
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<PropertyValues>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public PropertyValues? GetObject(ListItem listItemObject)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(listItemObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath1.Id, "Properties"),
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<PropertyValues>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public PropertyValues? GetObject(Site siteObject)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(siteObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath1.Id, "AllProperties"),
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<PropertyValues>(requestPayload.GetActionId<ClientActionQuery>());
    }

}

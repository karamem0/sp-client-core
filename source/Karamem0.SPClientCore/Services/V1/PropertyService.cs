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

    PropertyValues GetObject(Alert alertObject);

    PropertyValues GetObject(File fileObject);

    PropertyValues GetObject(Folder folderObject);

    PropertyValues GetObject(ListItem listItemObject);

    PropertyValues GetObject(Site siteObject);

}

public class PropertyService(ClientContext clientContext) : ClientService(clientContext), IPropertyService
{

    public PropertyValues GetObject(Alert alertObject)
    {
        _ = alertObject ?? throw new ArgumentNullException(nameof(alertObject));
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            new ObjectPathIdentity(alertObject.ObjectIdentity)
        );
        var objectPath2 = requestPayload.Add(
            new ObjectPathProperty(objectPath1.Id, "AllProperties"),
            objectPathId => new ClientActionQuery(objectPathId)
            {
                Query = new ClientQuery(true)
            }
        );
        return this.ClientContext
            .ProcessQuery(requestPayload)
            .ToObject<PropertyValues>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public PropertyValues GetObject(File fileObject)
    {
        _ = fileObject ?? throw new ArgumentNullException(nameof(fileObject));
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            new ObjectPathIdentity(fileObject.ObjectIdentity)
        );
        var objectPath2 = requestPayload.Add(
            new ObjectPathProperty(objectPath1.Id, "Properties"),
            objectPathId => new ClientActionQuery(objectPathId)
            {
                Query = new ClientQuery(true)
            }
        );
        return this.ClientContext
            .ProcessQuery(requestPayload)
            .ToObject<PropertyValues>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public PropertyValues GetObject(Folder folderObject)
    {
        _ = folderObject ?? throw new ArgumentNullException(nameof(folderObject));
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            new ObjectPathIdentity(folderObject.ObjectIdentity)
        );
        var objectPath2 = requestPayload.Add(
            new ObjectPathProperty(objectPath1.Id, "Properties"),
            objectPathId => new ClientActionQuery(objectPathId)
            {
                Query = new ClientQuery(true)
            }
        );
        return this.ClientContext
            .ProcessQuery(requestPayload)
            .ToObject<PropertyValues>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public PropertyValues GetObject(ListItem listItemObject)
    {
        _ = listItemObject ?? throw new ArgumentNullException(nameof(listItemObject));
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            new ObjectPathIdentity(listItemObject.ObjectIdentity)
        );
        var objectPath2 = requestPayload.Add(
            new ObjectPathProperty(objectPath1.Id, "Properties"),
            objectPathId => new ClientActionQuery(objectPathId)
            {
                Query = new ClientQuery(true)
            }
        );
        return this.ClientContext
            .ProcessQuery(requestPayload)
            .ToObject<PropertyValues>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public PropertyValues GetObject(Site siteObject)
    {
        _ = siteObject ?? throw new ArgumentNullException(nameof(siteObject));
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            new ObjectPathIdentity(siteObject.ObjectIdentity)
        );
        var objectPath2 = requestPayload.Add(
            new ObjectPathProperty(objectPath1.Id, "AllProperties"),
            objectPathId => new ClientActionQuery(objectPathId)
            {
                Query = new ClientQuery(true)
            }
        );
        return this.ClientContext
            .ProcessQuery(requestPayload)
            .ToObject<PropertyValues>(requestPayload.GetActionId<ClientActionQuery>());
    }

}

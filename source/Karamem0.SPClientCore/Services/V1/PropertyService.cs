//
// Copyright (c) 2018-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Karamem0.SharePoint.PowerShell.Runtime.Services;

namespace Karamem0.SharePoint.PowerShell.Services.V1;

public interface IPropertyService
{

    PropertyValues? GetObject(bool selectAllProperties = true);

    PropertyValues? GetObject(File fileObject, bool selectAllProperties = true);

    PropertyValues? GetObject(Folder folderObject, bool selectAllProperties = true);

    PropertyValues? GetObject(ListItem listItemObject, bool selectAllProperties = true);

    void SetObject(IReadOnlyDictionary<string, object?> modificationInfo);

    void SetObject(File fileObject, IReadOnlyDictionary<string, object?> modificationInfo);

    void SetObject(Folder folderObject, IReadOnlyDictionary<string, object?> modificationInfo);

    void SetObject(ListItem listItemObject, IReadOnlyDictionary<string, object?> modificationInfo);

}

public class PropertyService(ClientContext clientContext) : ClientService(clientContext), IPropertyService
{

    public PropertyValues? GetObject(bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath2.Id, "AllProperties"),
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<PropertyValues>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public PropertyValues? GetObject(File fileObject, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(fileObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath1.Id, "Properties"),
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<PropertyValues>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public PropertyValues? GetObject(Folder folderObject, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(folderObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath1.Id, "Properties"),
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<PropertyValues>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public PropertyValues? GetObject(ListItem listItemObject, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(listItemObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath1.Id, "Properties"),
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<PropertyValues>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public void SetObject(IReadOnlyDictionary<string, object?> modificationInfo)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath2.Id, "AllProperties"),
            modificationInfo.Select(item => new ClientActionDelegate(objectPathId => ClientActionMethod.Create(
                        objectPathId,
                        "SetFieldValue",
                        requestPayload.CreateParameter(item.Key),
                        requestPayload.CreateParameter(item.Value)
                    )
                )
            )
        );
        var objectPath4 = requestPayload.Add(objectPath2, objectPathId => ClientActionMethod.Create(objectPathId, "Update"));
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public void SetObject(File fileObject, IReadOnlyDictionary<string, object?> modificationInfo)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(fileObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath1.Id, "Properties"),
            modificationInfo.Select(item => new ClientActionDelegate(objectPathId => ClientActionMethod.Create(
                        objectPathId,
                        "SetFieldValue",
                        requestPayload.CreateParameter(item.Key),
                        requestPayload.CreateParameter(item.Value)
                    )
                )
            )
        );
        var objectPath3 = requestPayload.Add(objectPath1, objectPathId => ClientActionMethod.Create(objectPathId, "Update"));
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public void SetObject(Folder folderObject, IReadOnlyDictionary<string, object?> modificationInfo)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(folderObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath1.Id, "Properties"),
            modificationInfo.Select(item => new ClientActionDelegate(objectPathId => ClientActionMethod.Create(
                        objectPathId,
                        "SetFieldValue",
                        requestPayload.CreateParameter(item.Key),
                        requestPayload.CreateParameter(item.Value)
                    )
                )
            )
        );
        var objectPath3 = requestPayload.Add(objectPath1, objectPathId => ClientActionMethod.Create(objectPathId, "Update"));
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public void SetObject(ListItem listItemObject, IReadOnlyDictionary<string, object?> modificationInfo)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(listItemObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath1.Id, "Properties"),
            modificationInfo.Select(item => new ClientActionDelegate(objectPathId => ClientActionMethod.Create(
                        objectPathId,
                        "SetFieldValue",
                        requestPayload.CreateParameter(item.Key),
                        requestPayload.CreateParameter(item.Value)
                    )
                )
            )
        );
        var objectPath3 = requestPayload.Add(objectPath1, objectPathId => ClientActionMethod.Create(objectPathId, "Update"));
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

}

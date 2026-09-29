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

    Task<PropertyValues?> GetObjectAsync(bool selectAllProperties = true);

    Task<PropertyValues?> GetObjectAsync(File fileObject, bool selectAllProperties = true);

    Task<PropertyValues?> GetObjectAsync(Folder folderObject, bool selectAllProperties = true);

    Task<PropertyValues?> GetObjectAsync(ListItem listItemObject, bool selectAllProperties = true);

    Task SetObjectAsync(IReadOnlyDictionary<string, object?> modificationInfo);

    Task SetObjectAsync(File fileObject, IReadOnlyDictionary<string, object?> modificationInfo);

    Task SetObjectAsync(Folder folderObject, IReadOnlyDictionary<string, object?> modificationInfo);

    Task SetObjectAsync(ListItem listItemObject, IReadOnlyDictionary<string, object?> modificationInfo);

}

public class PropertyService(ClientContext clientContext) : ClientService(clientContext), IPropertyService
{

    public async Task<PropertyValues?> GetObjectAsync(bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath2.Id, "AllProperties"),
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<PropertyValues>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<PropertyValues?> GetObjectAsync(File fileObject, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(fileObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath1.Id, "Properties"),
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<PropertyValues>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<PropertyValues?> GetObjectAsync(Folder folderObject, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(folderObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath1.Id, "Properties"),
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<PropertyValues>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<PropertyValues?> GetObjectAsync(ListItem listItemObject, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(listItemObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath1.Id, "Properties"),
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<PropertyValues>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task SetObjectAsync(IReadOnlyDictionary<string, object?> modificationInfo)
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
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

    public async Task SetObjectAsync(File fileObject, IReadOnlyDictionary<string, object?> modificationInfo)
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
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

    public async Task SetObjectAsync(Folder folderObject, IReadOnlyDictionary<string, object?> modificationInfo)
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
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

    public async Task SetObjectAsync(ListItem listItemObject, IReadOnlyDictionary<string, object?> modificationInfo)
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
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

}

//
// Copyright (c) 2018-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Resources;
using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Karamem0.SharePoint.PowerShell.Runtime.Services;

namespace Karamem0.SharePoint.PowerShell.Services.V1;

public interface IViewColumnService
{

    Task AddObjectAsync(View viewObject, Column columnObject);

    Task AddObjectAsync(View viewObject, string columnName);

    Task<IEnumerable<string>?> GetObjectEnumerableAsync(View viewObject, bool selectAllProperties = true);

    Task MoveObjectAsync(
        View viewObject,
        Column columnObject,
        int columnIndex
    );

    Task MoveObjectAsync(
        View viewObject,
        string columnName,
        int columnIndex
    );

    Task RemoveObjectAsync(View viewObject, Column columnObject);

    Task RemoveObjectAsync(View viewObject, string columnName);

    Task RemoveObjectAllAsync(View viewObject);

}

public class ViewColumnService(ClientContext clientContext) : ClientService(clientContext), IViewColumnService
{

    public async Task AddObjectAsync(View viewObject, Column columnObject)
    {
        var columnName = columnObject.Name;
        _ = columnName ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
        await this.AddObjectAsync(viewObject, columnName);
    }

    public async Task AddObjectAsync(View viewObject, string columnName)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(viewObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "ViewFields"));
        var objectPath3 = requestPayload.Add(
            objectPath2,
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "Add",
                requestPayload.CreateParameter(columnName)
            )
        );
        var objectPath4 = requestPayload.Add(objectPath1, objectPathId => ClientActionMethod.Create(objectPathId, "Update"));
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

    public async Task<IEnumerable<string>?> GetObjectEnumerableAsync(View viewObject, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(viewObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath1.Id, "ViewFields"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(
                objectPathId,
                ClientQuery.Create(selectAllProperties, typeof(ViewColumnEnumerable)),
                ClientQuery.Create(selectAllProperties)
            )
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<ViewColumnEnumerable>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task MoveObjectAsync(
        View viewObject,
        Column columnObject,
        int columnIndex
    )
    {
        var columnName = columnObject.Name;
        _ = columnName ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
        await this.MoveObjectAsync(
            viewObject,
            columnName,
            columnIndex
        );
    }

    public async Task MoveObjectAsync(
        View viewObject,
        string columnName,
        int columnIndex
    )
    {
        if (columnIndex < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(columnIndex));
        }
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(viewObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "ViewFields"));
        var objectPath3 = requestPayload.Add(
            objectPath2,
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "MoveFieldTo",
                requestPayload.CreateParameter(columnName),
                requestPayload.CreateParameter(columnIndex)
            )
        );
        var objectPath4 = requestPayload.Add(objectPath1, objectPathId => ClientActionMethod.Create(objectPathId, "Update"));
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

    public async Task RemoveObjectAsync(View viewObject, Column columnObject)
    {
        var columnName = columnObject.Name;
        _ = columnName ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
        await this.RemoveObjectAsync(viewObject, columnName);
    }

    public async Task RemoveObjectAsync(View viewObject, string columnName)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(viewObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "ViewFields"));
        var objectPath3 = requestPayload.Add(
            objectPath2,
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "Remove",
                requestPayload.CreateParameter(columnName)
            )
        );
        var objectPath4 = requestPayload.Add(objectPath1, objectPathId => ClientActionMethod.Create(objectPathId, "Update"));
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

    public async Task RemoveObjectAllAsync(View viewObject)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(viewObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "ViewFields"));
        var objectPath3 = requestPayload.Add(objectPath2, objectPathId => ClientActionMethod.Create(objectPathId, "RemoveAll"));
        var objectPath4 = requestPayload.Add(objectPath1, objectPathId => ClientActionMethod.Create(objectPathId, "Update"));
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

}

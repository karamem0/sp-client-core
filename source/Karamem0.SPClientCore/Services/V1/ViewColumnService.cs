//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Resources;
using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Karamem0.SharePoint.PowerShell.Runtime.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Services.V1;

public interface IViewColumnService
{

    void AddObject(View viewObject, Column columnObject);

    void AddObject(View viewObject, string columnName);

    IEnumerable<string>? GetObjectEnumerable(View viewObject);

    void MoveObject(
        View viewObject,
        Column columnObject,
        int columnIndex
    );

    void MoveObject(
        View viewObject,
        string columnName,
        int columnIndex
    );

    void RemoveObject(View viewObject, Column columnObject);

    void RemoveObject(View viewObject, string columnName);

    void RemoveObjectAll(View viewObject);

}

public class ViewColumnService(ClientContext clientContext) : ClientService(clientContext), IViewColumnService
{

    public void AddObject(View viewObject, Column columnObject)
    {
        var columnName = columnObject.Name;
        _ = columnName ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
        this.AddObject(viewObject, columnName);
    }

    public void AddObject(View viewObject, string columnName)
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
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public IEnumerable<string>? GetObjectEnumerable(View viewObject)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(viewObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath1.Id, "ViewFields"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(
                objectPathId,
                ClientQuery.Create(true, typeof(ViewColumnEnumerable)),
                ClientQuery.Create(true)
            )
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<ViewColumnEnumerable>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public void MoveObject(
        View viewObject,
        Column columnObject,
        int columnIndex
    )
    {
        var columnName = columnObject.Name;
        _ = columnName ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
        this.MoveObject(
            viewObject,
            columnName,
            columnIndex
        );
    }

    public void MoveObject(
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
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public void RemoveObject(View viewObject, Column columnObject)
    {
        var columnName = columnObject.Name;
        _ = columnName ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
        this.RemoveObject(viewObject, columnName);
    }

    public void RemoveObject(View viewObject, string columnName)
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
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public void RemoveObjectAll(View viewObject)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(viewObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "ViewFields"));
        var objectPath3 = requestPayload.Add(objectPath2, objectPathId => ClientActionMethod.Create(objectPathId, "RemoveAll"));
        var objectPath4 = requestPayload.Add(objectPath1, objectPathId => ClientActionMethod.Create(objectPathId, "Update"));
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

}

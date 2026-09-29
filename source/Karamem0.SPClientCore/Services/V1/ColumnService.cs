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
using Karamem0.SharePoint.PowerShell.Services.V1.Utilities;

namespace Karamem0.SharePoint.PowerShell.Services.V1;

public interface IColumnService
{

    Task<Column?> AddObjectAsync(
        ColumnType columnType,
        IReadOnlyDictionary<string, object?> creationInfo,
        bool addToDefaultView,
        AddColumnOptions addColumnOptions,
        bool selectAllProperties = true
    );

    Task<Column?> AddObjectAsync(
        List listObject,
        ColumnType columnType,
        IReadOnlyDictionary<string, object?> creationInfo,
        bool addToDefaultView,
        AddColumnOptions addColumnOptions,
        bool selectAllProperties = true
    );

    Task<Column?> GetObjectAsync(Column columnObject);

    Task<Column?> GetObjectAsync(Column columnObject, bool selectAllProperties = true);

    Task<Column?> GetObjectAsync(Guid columnId, bool selectAllProperties = true);

    Task<Column?> GetObjectAsync(string columnTitle, bool selectAllProperties = true);

    Task<Column?> GetObjectAsync(
        ContentType contentTypeObject,
        Guid columnId,
        bool selectAllProperties = true
    );

    Task<Column?> GetObjectAsync(
        ContentType contentTypeObject,
        string columnTitle,
        bool selectAllProperties = true
    );

    Task<Column?> GetObjectAsync(
        List listObject,
        Guid columnId,
        bool selectAllProperties = true
    );

    Task<Column?> GetObjectAsync(
        List listObject,
        string columnTitle,
        bool selectAllProperties = true
    );

    Task<IEnumerable<Column>?> GetObjectEnumerableAsync(bool selectAllProperties = true);

    Task<IEnumerable<Column>?> GetObjectEnumerableAsync(ContentType contentTypeObject, bool selectAllProperties = true);

    Task<IEnumerable<Column>?> GetObjectEnumerableAsync(List listObject, bool selectAllProperties = true);

    Task RemoveObjectAsync(Column columnObject);

    Task SetObjectAsync(Column columnObject, IReadOnlyDictionary<string, object?> modificationInfo);

    Task SetObjectAsync(
        Column columnObject,
        IReadOnlyDictionary<string, object?> modificationInfo,
        bool pushChanges
    );

}

public class ColumnService(ClientContext clientContext) : ClientService<Column>(clientContext), IColumnService
{

    public async Task<Column?> AddObjectAsync(
        ColumnType columnType,
        IReadOnlyDictionary<string, object?> creationInfo,
        bool addToDefaultView,
        AddColumnOptions addColumnOptions,
        bool selectAllProperties = true
    )
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(ObjectPathProperty.Create(objectPath2.Id, "Fields"));
        var objectPath4 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath3.Id,
                "AddFieldAsXml",
                requestPayload.CreateParameter(SchemaXmlColumn.Create(columnType, creationInfo)),
                requestPayload.CreateParameter(addToDefaultView),
                requestPayload.CreateParameter(addColumnOptions)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(Column)))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<Column>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<Column?> AddObjectAsync(
        List listObject,
        ColumnType columnType,
        IReadOnlyDictionary<string, object?> creationInfo,
        bool addToDefaultView,
        AddColumnOptions addColumnOptions,
        bool selectAllProperties = true
    )
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(listObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Fields"));
        var objectPath3 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath2.Id,
                "AddFieldAsXml",
                requestPayload.CreateParameter(SchemaXmlColumn.Create(columnType, creationInfo)),
                requestPayload.CreateParameter(addToDefaultView),
                requestPayload.CreateParameter(addColumnOptions)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(Column)))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<Column>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<Column?> GetObjectAsync(Guid columnId, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(ObjectPathProperty.Create(objectPath2.Id, "Fields"));
        var objectPath4 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath3.Id,
                "GetById",
                requestPayload.CreateParameter(columnId)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(Column)))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<Column>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<Column?> GetObjectAsync(string columnTitle, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(ObjectPathProperty.Create(objectPath2.Id, "Fields"));
        var objectPath4 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath3.Id,
                "GetByInternalNameOrTitle",
                requestPayload.CreateParameter(columnTitle)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(Column)))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<Column>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<Column?> GetObjectAsync(
        ContentType contentTypeObject,
        Guid columnId,
        bool selectAllProperties = true
    )
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(contentTypeObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Fields"));
        var objectPath3 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath2.Id,
                "GetById",
                requestPayload.CreateParameter(columnId)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(Column)))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<Column>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<Column?> GetObjectAsync(
        ContentType contentTypeObject,
        string columnTitle,
        bool selectAllProperties = true
    )
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(contentTypeObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Fields"));
        var objectPath3 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath2.Id,
                "GetByInternalNameOrTitle",
                requestPayload.CreateParameter(columnTitle)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(Column)))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<Column>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<Column?> GetObjectAsync(
        List listObject,
        Guid columnId,
        bool selectAllProperties = true
    )
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(listObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Fields"));
        var objectPath3 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath2.Id,
                "GetById",
                requestPayload.CreateParameter(columnId)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(Column)))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<Column>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<Column?> GetObjectAsync(
        List listObject,
        string columnTitle,
        bool selectAllProperties = true
    )
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(listObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Fields"));
        var objectPath3 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath2.Id,
                "GetByInternalNameOrTitle",
                requestPayload.CreateParameter(columnTitle)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(Column)))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<Column>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<IEnumerable<Column>?> GetObjectEnumerableAsync(bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath2.Id, "Fields"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(
                objectPathId,
                ClientQuery.Empty,
                ClientQuery.Create(selectAllProperties, typeof(Column))
            )
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<ColumnEnumerable>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<IEnumerable<Column>?> GetObjectEnumerableAsync(ContentType contentTypeObject, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(contentTypeObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath1.Id, "Fields"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(
                objectPathId,
                ClientQuery.Empty,
                ClientQuery.Create(selectAllProperties, typeof(Column))
            )
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<ColumnEnumerable>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<IEnumerable<Column>?> GetObjectEnumerableAsync(List listObject, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(listObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath1.Id, "Fields"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(
                objectPathId,
                ClientQuery.Empty,
                ClientQuery.Create(selectAllProperties, typeof(Column))
            )
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<ColumnEnumerable>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public override async Task SetObjectAsync(Column columnObject, IReadOnlyDictionary<string, object?> modificationInfo)
    {
        var requestPayload = new ClientRequestPayload();
        var objectName = columnObject.ObjectType;
        _ = objectName ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
        var objectType = ClientObject.GetType(objectName);
        var schemaXml = columnObject.SchemaXml;
        _ = schemaXml ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
        var objectPath1 = requestPayload.Add(
            ObjectPathIdentity.Create(columnObject.ObjectIdentity),
            objectPathId => ClientActionSetProperty.Create(
                objectPathId,
                "SchemaXml",
                requestPayload.CreateParameter(SchemaXmlColumn.Create(schemaXml, modificationInfo))
            ),
            objectPathId => ClientActionMethod.Create(objectPathId, "Update")
        );
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

    public async Task SetObjectAsync(
        Column columnObject,
        IReadOnlyDictionary<string, object?> modificationInfo,
        bool pushChanges
    )
    {
        var requestPayload = new ClientRequestPayload();
        var objectName = columnObject.ObjectType;
        _ = objectName ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
        var objectType = ClientObject.GetType(objectName);
        var schemaXml = columnObject.SchemaXml;
        _ = schemaXml ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
        var objectPath1 = requestPayload.Add(
            ObjectPathIdentity.Create(columnObject.ObjectIdentity),
            objectPathId => ClientActionSetProperty.Create(
                objectPathId,
                "SchemaXml",
                requestPayload.CreateParameter(SchemaXmlColumn.Create(schemaXml, modificationInfo))
            ),
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "UpdateAndPushChanges",
                requestPayload.CreateParameter(pushChanges)
            )
        );
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

}

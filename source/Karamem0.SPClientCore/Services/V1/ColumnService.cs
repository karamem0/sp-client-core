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
using Karamem0.SharePoint.PowerShell.Services.V1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Services.V1;

public interface IColumnService
{

    Column? AddObject(
        ColumnType columnType,
        IReadOnlyDictionary<string, object?> creationInfo,
        bool addToDefaultView,
        AddColumnOptions addColumnOptions
    );

    Column? AddObject(
        List listObject,
        ColumnType columnType,
        IReadOnlyDictionary<string, object?> creationInfo,
        bool addToDefaultView,
        AddColumnOptions addColumnOptions
    );

    Column? GetObject(Column columnObject);

    Column? GetObject(Guid columnId);

    Column? GetObject(string columnTitle);

    Column? GetObject(ContentType contentTypeObject, Guid columnId);

    Column? GetObject(ContentType contentTypeObject, string columnTitle);

    Column? GetObject(List listObject, Guid columnId);

    Column? GetObject(List listObject, string columnTitle);

    IEnumerable<Column>? GetObjectEnumerable();

    IEnumerable<Column>? GetObjectEnumerable(ContentType contentTypeObject);

    IEnumerable<Column>? GetObjectEnumerable(List listObject);

    void RemoveObject(Column columnObject);

    void SetObject(Column columnObject, IReadOnlyDictionary<string, object?> modificationInfo);

    void SetObject(
        Column columnObject,
        IReadOnlyDictionary<string, object?> modificationInfo,
        bool pushChanges
    );

}

public class ColumnService(ClientContext clientContext) : ClientService<Column>(clientContext), IColumnService
{

    public Column? AddObject(
        ColumnType columnType,
        IReadOnlyDictionary<string, object?> creationInfo,
        bool addToDefaultView,
        AddColumnOptions addColumnOptions
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
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(Column)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<Column>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public Column? AddObject(
        List listObject,
        ColumnType columnType,
        IReadOnlyDictionary<string, object?> creationInfo,
        bool addToDefaultView,
        AddColumnOptions addColumnOptions
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
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(Column)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<Column>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public Column? GetObject(Guid columnId)
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
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(Column)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<Column>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public Column? GetObject(string columnTitle)
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
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(Column)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<Column>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public Column? GetObject(ContentType contentTypeObject, Guid columnId)
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
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(Column)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<Column>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public Column? GetObject(ContentType contentTypeObject, string columnTitle)
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
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(Column)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<Column>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public Column? GetObject(List listObject, Guid columnId)
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
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(Column)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<Column>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public Column? GetObject(List listObject, string columnTitle)
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
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(Column)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<Column>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public IEnumerable<Column>? GetObjectEnumerable()
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
                ClientQuery.Create(true, typeof(Column))
            )
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<ColumnEnumerable>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public IEnumerable<Column>? GetObjectEnumerable(ContentType contentTypeObject)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(contentTypeObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath1.Id, "Fields"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(
                objectPathId,
                ClientQuery.Empty,
                ClientQuery.Create(true, typeof(Column))
            )
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<ColumnEnumerable>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public IEnumerable<Column>? GetObjectEnumerable(List listObject)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(listObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath1.Id, "Fields"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(
                objectPathId,
                ClientQuery.Empty,
                ClientQuery.Create(true, typeof(Column))
            )
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<ColumnEnumerable>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public override void SetObject(Column columnObject, IReadOnlyDictionary<string, object?> modificationInfo)
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
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public void SetObject(
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
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

}

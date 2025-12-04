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

namespace Karamem0.SharePoint.PowerShell.Services.V1;

public interface IContentTypeColumnService
{

    ContentTypeColumn? AddObject(
        ContentType contentTypeObject,
        IReadOnlyDictionary<string, object?> creationInfo,
        bool pushChanges
    );

    ContentTypeColumn? GetObject(ContentTypeColumn contentTypeColumnObject);

    ContentTypeColumn? GetObject(ContentType contentTypeObject, Guid? columnId);

    IEnumerable<ContentTypeColumn>? GetObjectEnumerable(ContentType contentTypeObject);

    void RemoveObject(ContentTypeColumn contentTypeColumnObject, bool pushChanges);

    void ReorderObject(
        ContentType contentTypeObject,
        IEnumerable<string> contentTypeColumnNames,
        bool pushChanges
    );

    void SetObject(
        ContentTypeColumn contentTypeColumnObject,
        IReadOnlyDictionary<string, object?> modificationInfo,
        bool pushChanges
    );

}

public class ContentTypeColumnService(ClientContext clientContext) : ClientService<ContentTypeColumn>(clientContext), IContentTypeColumnService
{

    public ContentTypeColumn? AddObject(
        ContentType contentTypeObject,
        IReadOnlyDictionary<string, object?> creationInfo,
        bool pushChanges
    )
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(contentTypeObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "FieldLinks"));
        var objectPath3 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath2.Id,
                "Add",
                requestPayload.CreateParameter(ClientValueObject.Create<ContentTypeColumnCreationInfo>(creationInfo))
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(ContentTypeColumn)))
        );
        var objectPath4 = requestPayload.Add(
            objectPath1,
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "Update",
                requestPayload.CreateParameter(pushChanges)
            )
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<ContentTypeColumn>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public ContentTypeColumn? GetObject(ContentType contentTypeObject, Guid? columnId)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(contentTypeObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "FieldLinks"));
        var objectPath3 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath2.Id,
                "GetById",
                requestPayload.CreateParameter(columnId)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(ContentTypeColumn)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<ContentTypeColumn>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public IEnumerable<ContentTypeColumn>? GetObjectEnumerable(ContentType contentTypeObject)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(contentTypeObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath1.Id, "FieldLinks"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(
                objectPathId,
                ClientQuery.Empty,
                ClientQuery.Create(true, typeof(ContentTypeColumn))
            )
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<ContentTypeColumnEnumerable>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public void RemoveObject(ContentTypeColumn contentTypeColumnObject, bool pushChanges)
    {
        var objectIdentity = contentTypeColumnObject.ObjectIdentity;
        _ = objectIdentity ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            ObjectPathIdentity.Create(
                string.Join(
                    ":",
                    objectIdentity
                        .Split(':')
                        .SkipLast(2)
                )
            )
        );
        var objectPath2 = requestPayload.Add(ObjectPathIdentity.Create(contentTypeColumnObject.ObjectIdentity));
        var objectPath3 = requestPayload.Add(objectPath2, objectPathId => ClientActionMethod.Create(objectPathId, "DeleteObject"));
        var objectPath4 = requestPayload.Add(
            objectPath1,
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "Update",
                requestPayload.CreateParameter(pushChanges)
            )
        );
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public void ReorderObject(
        ContentType contentTypeObject,
        IEnumerable<string> contentTypeColumnNames,
        bool pushChanges
    )
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(contentTypeObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "FieldLinks"));
        var objectPath3 = requestPayload.Add(
            objectPath2,
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "Reorder",
                requestPayload.CreateParameter(contentTypeColumnNames)
            )
        );
        var objectPath4 = requestPayload.Add(
            objectPath1,
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "Update",
                requestPayload.CreateParameter(pushChanges)
            )
        );
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public void SetObject(
        ContentTypeColumn contentTypeColumnObject,
        IReadOnlyDictionary<string, object?> modificationInfo,
        bool pushChanges
    )
    {
        var objectIdentity = contentTypeColumnObject.ObjectIdentity;
        _ = objectIdentity ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            ObjectPathIdentity.Create(
                string.Join(
                    ":",
                    objectIdentity
                        .Split(':')
                        .SkipLast(2)
                )
            )
        );
        var objectPath2 = requestPayload.Add(ObjectPathIdentity.Create(contentTypeColumnObject.ObjectIdentity));
        var objectPath3 = requestPayload.Add(objectPath2, requestPayload.CreateSetPropertyDelegates(contentTypeColumnObject, modificationInfo));
        var objectPath4 = requestPayload.Add(
            objectPath1,
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "Update",
                requestPayload.CreateParameter(pushChanges)
            )
        );
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

}

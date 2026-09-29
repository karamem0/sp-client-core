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

public interface IContentTypeColumnService
{

    Task<ContentTypeColumn?> AddObjectAsync(
        ContentType contentTypeObject,
        IReadOnlyDictionary<string, object?> creationInfo,
        bool pushChanges,
        bool selectAllProperties = true
    );

    Task<ContentTypeColumn?> GetObjectAsync(ContentTypeColumn contentTypeColumnObject);

    Task<ContentTypeColumn?> GetObjectAsync(ContentTypeColumn contentTypeColumnObject, bool selectAllProperties = true);

    Task<ContentTypeColumn?> GetObjectAsync(
        ContentType contentTypeObject,
        Guid? columnId,
        bool selectAllProperties = true
    );

    Task<IEnumerable<ContentTypeColumn>?> GetObjectEnumerableAsync(ContentType contentTypeObject, bool selectAllProperties = true);

    Task RemoveObjectAsync(ContentTypeColumn contentTypeColumnObject, bool pushChanges);

    Task ReorderObjectAsync(
        ContentType contentTypeObject,
        IEnumerable<string> contentTypeColumnNames,
        bool pushChanges
    );

    Task SetObjectAsync(
        ContentTypeColumn contentTypeColumnObject,
        IReadOnlyDictionary<string, object?> modificationInfo,
        bool pushChanges
    );

}

public class ContentTypeColumnService(ClientContext clientContext) : ClientService<ContentTypeColumn>(clientContext), IContentTypeColumnService
{

    public async Task<ContentTypeColumn?> AddObjectAsync(
        ContentType contentTypeObject,
        IReadOnlyDictionary<string, object?> creationInfo,
        bool pushChanges,
        bool selectAllProperties = true
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
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(ContentTypeColumn)))
        );
        var objectPath4 = requestPayload.Add(
            objectPath1,
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "Update",
                requestPayload.CreateParameter(pushChanges)
            )
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<ContentTypeColumn>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<ContentTypeColumn?> GetObjectAsync(
        ContentType contentTypeObject,
        Guid? columnId,
        bool selectAllProperties = true
    )
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
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(ContentTypeColumn)))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<ContentTypeColumn>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<IEnumerable<ContentTypeColumn>?> GetObjectEnumerableAsync(ContentType contentTypeObject, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(contentTypeObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath1.Id, "FieldLinks"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(
                objectPathId,
                ClientQuery.Empty,
                ClientQuery.Create(selectAllProperties, typeof(ContentTypeColumn))
            )
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<ContentTypeColumnEnumerable>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task RemoveObjectAsync(ContentTypeColumn contentTypeColumnObject, bool pushChanges)
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
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

    public async Task ReorderObjectAsync(
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
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

    public async Task SetObjectAsync(
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
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

}

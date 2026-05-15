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

public interface IContentTypeService
{

    ContentType? AddObject(IReadOnlyDictionary<string, object?> creationInfo, bool selectAllProperties = true);

    ContentType? AddObject(
        List listObject,
        IReadOnlyDictionary<string, object?> creationInfo,
        bool selectAllProperties = true
    );

    ContentType? AddObject(
        List listObject,
        ContentType contentTypeObject,
        bool selectAllProperties = true
    );

    ContentType? GetObject(ContentType contentTypeObject);

    ContentType? GetObject(ContentType contentTypeObject, bool selectAllProperties = true);

    ContentType? GetObject(string contentTypeId, bool selectAllProperties = true);

    ContentType? GetObject(
        List listObject,
        string contentTypeId,
        bool selectAllProperties = true
    );

    IEnumerable<ContentType>? GetObjectEnumerable(bool selectAllProperties = true);

    IEnumerable<ContentType>? GetObjectEnumerable(List listObject, bool selectAllProperties = true);

    void RemoveObject(ContentType contentTypeObject);

    void SetObject(ContentType contentTypeObject, IReadOnlyDictionary<string, object?> modificationInfo);

}

public class ContentTypeService(ClientContext clientContext) : ClientService<ContentType>(clientContext), IContentTypeService
{

    public ContentType? AddObject(IReadOnlyDictionary<string, object?> creationInfo, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(ObjectPathProperty.Create(objectPath2.Id, "ContentTypes"));
        var objectPath4 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath3.Id,
                "Add",
                requestPayload.CreateParameter(ClientValueObject.Create<ContentTypeCreationInfo>(creationInfo))
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(ContentType)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<ContentType>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public ContentType? AddObject(
        List listObject,
        IReadOnlyDictionary<string, object?> creationInfo,
        bool selectAllProperties = true
    )
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(listObject.ObjectIdentity), ClientActionInstantiateObjectPath.Create);
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "ContentTypes"), ClientActionInstantiateObjectPath.Create);
        var objectPath3 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath2.Id,
                "Add",
                requestPayload.CreateParameter(ClientValueObject.Create<ContentTypeCreationInfo>(creationInfo))
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(ContentType)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<ContentType>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public ContentType? AddObject(
        List listObject,
        ContentType contentTypeObject,
        bool selectAllProperties = true
    )
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(listObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "ContentTypes"));
        var objectPath3 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath2.Id,
                "AddExistingContentType",
                requestPayload.CreateParameter(contentTypeObject)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(ContentType)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<ContentType>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public ContentType? GetObject(string contentTypeId, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(ObjectPathProperty.Create(objectPath2.Id, "ContentTypes"));
        var objectPath4 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath3.Id,
                "GetById",
                requestPayload.CreateParameter(contentTypeId)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(ContentType)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<ContentType>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public ContentType? GetObject(
        List listObject,
        string contentTypeId,
        bool selectAllProperties = true
    )
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(listObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "ContentTypes"));
        var objectPath3 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath2.Id,
                "GetById",
                requestPayload.CreateParameter(contentTypeId)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(ContentType)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<ContentType>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public IEnumerable<ContentType>? GetObjectEnumerable(bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath2.Id, "ContentTypes"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(
                objectPathId,
                ClientQuery.Empty,
                ClientQuery.Create(selectAllProperties, typeof(ContentType))
            )
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<ContentTypeEnumerable>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public IEnumerable<ContentType>? GetObjectEnumerable(List listObject, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(listObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath1.Id, "ContentTypes"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(
                objectPathId,
                ClientQuery.Empty,
                ClientQuery.Create(selectAllProperties, typeof(ContentType))
            )
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<ContentTypeEnumerable>(requestPayload.GetActionId<ClientActionQuery>());
    }

}

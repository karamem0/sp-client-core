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

public interface IContentTypeService
{

    ContentType? AddObject(IReadOnlyDictionary<string, object?> creationInfo);

    ContentType? AddObject(List listObject, IReadOnlyDictionary<string, object?> creationInfo);

    ContentType? AddObject(List listObject, ContentType contentTypeObject);

    ContentType? GetObject(ContentType contentTypeObject);

    ContentType? GetObject(string contentTypeId);

    ContentType? GetObject(List listObject, string contentTypeId);

    IEnumerable<ContentType>? GetObjectEnumerable();

    IEnumerable<ContentType>? GetObjectEnumerable(List listObject);

    void RemoveObject(ContentType contentTypeObject);

    void SetObject(ContentType contentTypeObject, IReadOnlyDictionary<string, object?> modificationInfo);

}

public class ContentTypeService(ClientContext clientContext) : ClientService<ContentType>(clientContext), IContentTypeService
{

    public ContentType? AddObject(IReadOnlyDictionary<string, object?> creationInfo)
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
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(ContentType)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<ContentType>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public ContentType? AddObject(List listObject, IReadOnlyDictionary<string, object?> creationInfo)
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
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(ContentType)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<ContentType>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public ContentType? AddObject(List listObject, ContentType contentTypeObject)
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
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(ContentType)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<ContentType>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public ContentType? GetObject(string contentTypeId)
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
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(ContentType)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<ContentType>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public ContentType? GetObject(List listObject, string contentTypeId)
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
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(ContentType)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<ContentType>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public IEnumerable<ContentType>? GetObjectEnumerable()
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
                ClientQuery.Create(true, typeof(ContentType))
            )
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<ContentTypeEnumerable>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public IEnumerable<ContentType>? GetObjectEnumerable(List listObject)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(listObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath1.Id, "ContentTypes"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(
                objectPathId,
                ClientQuery.Empty,
                ClientQuery.Create(true, typeof(ContentType))
            )
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<ContentTypeEnumerable>(requestPayload.GetActionId<ClientActionQuery>());
    }

}

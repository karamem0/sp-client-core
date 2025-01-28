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

    ContentType AddObject(IReadOnlyDictionary<string, object> creationInfo);

    ContentType AddObject(List listObject, IReadOnlyDictionary<string, object> creationInfo);

    ContentType AddObject(List listObject, ContentType contentTypeObject);

    ContentType GetObject(ContentType contentTypeObject);

    ContentType GetObject(string contentTypeId);

    ContentType GetObject(List listObject, string contentTypeId);

    IEnumerable<ContentType> GetObjectEnumerable();

    IEnumerable<ContentType> GetObjectEnumerable(List listObject);

    void RemoveObject(ContentType contentTypeObject);

    void SetObject(ContentType contentTypeObject, IReadOnlyDictionary<string, object> modificationInfo);

}

public class ContentTypeService(ClientContext clientContext)
    : ClientService<ContentType>(clientContext), IContentTypeService
{

    public ContentType AddObject(IReadOnlyDictionary<string, object> creationInfo)
    {
        _ = creationInfo ?? throw new ArgumentNullException(nameof(creationInfo));
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(new ObjectPathStaticProperty(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(new ObjectPathProperty(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(new ObjectPathProperty(objectPath2.Id, "ContentTypes"));
        var objectPath4 = requestPayload.Add(
            new ObjectPathMethod(
                objectPath3.Id,
                "Add",
                requestPayload.CreateParameter(ClientValueObject.Create<ContentTypeCreationInfo>(creationInfo))
            ),
            objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
            objectPathId => new ClientActionQuery(objectPathId)
            {
                Query = new ClientQuery(true, typeof(ContentType))
            }
        );
        return this.ClientContext.ProcessQuery(requestPayload)
            .ToObject<ContentType>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public ContentType AddObject(List listObject, IReadOnlyDictionary<string, object> creationInfo)
    {
        _ = listObject ?? throw new ArgumentNullException(nameof(listObject));
        _ = creationInfo ?? throw new ArgumentNullException(nameof(creationInfo));
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            new ObjectPathIdentity(listObject.ObjectIdentity),
            objectPathId => new ClientActionInstantiateObjectPath(objectPathId)
        );
        var objectPath2 = requestPayload.Add(
            new ObjectPathProperty(objectPath1.Id, "ContentTypes"),
            objectPathId => new ClientActionInstantiateObjectPath(objectPathId)
        );
        var objectPath3 = requestPayload.Add(
            new ObjectPathMethod(
                objectPath2.Id,
                "Add",
                requestPayload.CreateParameter(ClientValueObject.Create<ContentTypeCreationInfo>(creationInfo))
            ),
            objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
            objectPathId => new ClientActionQuery(objectPathId)
            {
                Query = new ClientQuery(true, typeof(ContentType))
            }
        );
        return this.ClientContext.ProcessQuery(requestPayload)
            .ToObject<ContentType>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public ContentType AddObject(List listObject, ContentType contentTypeObject)
    {
        _ = listObject ?? throw new ArgumentNullException(nameof(listObject));
        _ = contentTypeObject ?? throw new ArgumentNullException(nameof(contentTypeObject));
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(new ObjectPathIdentity(listObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(new ObjectPathProperty(objectPath1.Id, "ContentTypes"));
        var objectPath3 = requestPayload.Add(
            new ObjectPathMethod(
                objectPath2.Id,
                "AddExistingContentType",
                requestPayload.CreateParameter(contentTypeObject)
            ),
            objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
            objectPathId => new ClientActionQuery(objectPathId)
            {
                Query = new ClientQuery(true, typeof(ContentType))
            }
        );
        return this.ClientContext.ProcessQuery(requestPayload)
            .ToObject<ContentType>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public ContentType GetObject(string contentTypeId)
    {
        _ = contentTypeId ?? throw new ArgumentNullException(nameof(contentTypeId));
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(new ObjectPathStaticProperty(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(new ObjectPathProperty(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(new ObjectPathProperty(objectPath2.Id, "ContentTypes"));
        var objectPath4 = requestPayload.Add(
            new ObjectPathMethod(objectPath3.Id, "GetById", requestPayload.CreateParameter(contentTypeId)),
            objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
            objectPathId => new ClientActionQuery(objectPathId)
            {
                Query = new ClientQuery(true, typeof(ContentType))
            }
        );
        return this.ClientContext.ProcessQuery(requestPayload)
            .ToObject<ContentType>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public ContentType GetObject(List listObject, string contentTypeId)
    {
        _ = listObject ?? throw new ArgumentNullException(nameof(listObject));
        _ = contentTypeId ?? throw new ArgumentNullException(nameof(contentTypeId));
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(new ObjectPathIdentity(listObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(new ObjectPathProperty(objectPath1.Id, "ContentTypes"));
        var objectPath3 = requestPayload.Add(
            new ObjectPathMethod(objectPath2.Id, "GetById", requestPayload.CreateParameter(contentTypeId)),
            objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
            objectPathId => new ClientActionQuery(objectPathId)
            {
                Query = new ClientQuery(true, typeof(ContentType))
            }
        );
        return this.ClientContext.ProcessQuery(requestPayload)
            .ToObject<ContentType>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public IEnumerable<ContentType> GetObjectEnumerable()
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(new ObjectPathStaticProperty(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(new ObjectPathProperty(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(
            new ObjectPathProperty(objectPath2.Id, "ContentTypes"),
            objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
            objectPathId => new ClientActionQuery(objectPathId)
            {
                Query = ClientQuery.Empty,
                ChildItemQuery = new ClientQuery(true, typeof(ContentType))
            }
        );
        return this.ClientContext.ProcessQuery(requestPayload)
            .ToObject<ContentTypeEnumerable>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public IEnumerable<ContentType> GetObjectEnumerable(List listObject)
    {
        _ = listObject ?? throw new ArgumentNullException(nameof(listObject));
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(new ObjectPathIdentity(listObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            new ObjectPathProperty(objectPath1.Id, "ContentTypes"),
            objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
            objectPathId => new ClientActionQuery(objectPathId)
            {
                Query = ClientQuery.Empty,
                ChildItemQuery = new ClientQuery(true, typeof(ContentType))
            }
        );
        return this.ClientContext.ProcessQuery(requestPayload)
            .ToObject<ContentTypeEnumerable>(requestPayload.GetActionId<ClientActionQuery>());
    }

}

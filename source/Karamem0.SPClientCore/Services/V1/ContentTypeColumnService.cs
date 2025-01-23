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

public interface IContentTypeColumnService
{

    ContentTypeColumn AddObject(
        ContentType contentTypeObject,
        IReadOnlyDictionary<string, object> creationInfo,
        bool pushChanges
    );

    ContentTypeColumn GetObject(ContentTypeColumn contentTypeColumnObject);

    ContentTypeColumn GetObject(ContentType contentTypeObject, Guid? columnId);

    IEnumerable<ContentTypeColumn> GetObjectEnumerable(ContentType contentTypeObject);

    void RemoveObject(ContentTypeColumn contentTypeColumnObject, bool pushChanges);

    void ReorderObject(
        ContentType contentTypeObject,
        IEnumerable<string> contentTypeColumnNames,
        bool pushChanges
    );

    void SetObject(
        ContentTypeColumn contentTypeColumnObject,
        IReadOnlyDictionary<string, object> modificationInfo,
        bool pushChanges
    );

}

public class ContentTypeColumnService(ClientContext clientContext)
    : ClientService<ContentTypeColumn>(clientContext), IContentTypeColumnService
{

    public ContentTypeColumn AddObject(
        ContentType contentTypeObject,
        IReadOnlyDictionary<string, object> creationInfo,
        bool pushChanges
    )
    {
        _ = contentTypeObject ?? throw new ArgumentNullException(nameof(contentTypeObject));
        _ = creationInfo ?? throw new ArgumentNullException(nameof(creationInfo));
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            new ObjectPathIdentity(contentTypeObject.ObjectIdentity)
        );
        var objectPath2 = requestPayload.Add(
            new ObjectPathProperty(objectPath1.Id, "FieldLinks")
        );
        var objectPath3 = requestPayload.Add(
            new ObjectPathMethod(
                objectPath2.Id,
                "Add",
                requestPayload.CreateParameter(ClientValueObject.Create<ContentTypeColumnCreationInfo>(creationInfo))
            ),
            objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
            objectPathId => new ClientActionQuery(objectPathId)
            {
                Query = new ClientQuery(true, typeof(ContentTypeColumn))
            }
        );
        var objectPath4 = requestPayload.Add(
            objectPath1,
            objectPathId => new ClientActionMethod(
                objectPathId,
                "Update",
                requestPayload.CreateParameter(pushChanges)
            )
        );
        return this.ClientContext
            .ProcessQuery(requestPayload)
            .ToObject<ContentTypeColumn>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public ContentTypeColumn GetObject(ContentType contentTypeObject, Guid? columnId)
    {
        _ = contentTypeObject ?? throw new ArgumentNullException(nameof(contentTypeObject));
        _ = columnId ?? throw new ArgumentNullException(nameof(columnId));
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            new ObjectPathIdentity(contentTypeObject.ObjectIdentity)
        );
        var objectPath2 = requestPayload.Add(
            new ObjectPathProperty(objectPath1.Id, "FieldLinks")
        );
        var objectPath3 = requestPayload.Add(
            new ObjectPathMethod(
                objectPath2.Id,
                "GetById",
                requestPayload.CreateParameter(columnId)
            ),
            objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
            objectPathId => new ClientActionQuery(objectPathId)
            {
                Query = new ClientQuery(true, typeof(ContentTypeColumn))
            }
        );
        return this.ClientContext
            .ProcessQuery(requestPayload)
            .ToObject<ContentTypeColumn>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public IEnumerable<ContentTypeColumn> GetObjectEnumerable(ContentType contentTypeObject)
    {
        _ = contentTypeObject ?? throw new ArgumentNullException(nameof(contentTypeObject));
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            new ObjectPathIdentity(contentTypeObject.ObjectIdentity)
        );
        var objectPath2 = requestPayload.Add(
            new ObjectPathProperty(objectPath1.Id, "FieldLinks"),
            objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
            objectPathId => new ClientActionQuery(objectPathId)
            {
                Query = ClientQuery.Empty,
                ChildItemQuery = new ClientQuery(true, typeof(ContentTypeColumn))
            }
        );
        return this.ClientContext
            .ProcessQuery(requestPayload)
            .ToObject<ContentTypeColumnEnumerable>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public void RemoveObject(ContentTypeColumn contentTypeColumnObject, bool pushChanges)
    {
        _ = contentTypeColumnObject ?? throw new ArgumentNullException(nameof(contentTypeColumnObject));
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            new ObjectPathIdentity(string.Join(":", contentTypeColumnObject.ObjectIdentity.Split(':').SkipLast(2)))
        );
        var objectPath2 = requestPayload.Add(
            new ObjectPathIdentity(contentTypeColumnObject.ObjectIdentity)
        );
        var objectPath3 = requestPayload.Add(
            objectPath2,
            objectPathId => new ClientActionMethod(objectPathId, "DeleteObject")
        );
        var objectPath4 = requestPayload.Add(
            objectPath1,
            objectPathId => new ClientActionMethod(
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
        _ = contentTypeObject ?? throw new ArgumentNullException(nameof(contentTypeObject));
        _ = contentTypeColumnNames ?? throw new ArgumentNullException(nameof(contentTypeColumnNames));
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            new ObjectPathIdentity(contentTypeObject.ObjectIdentity)
        );
        var objectPath2 = requestPayload.Add(
            new ObjectPathProperty(objectPath1.Id, "FieldLinks")
        );
        var objectPath3 = requestPayload.Add(
            objectPath2,
            objectPathId => new ClientActionMethod(
                objectPathId,
                "Reorder",
                requestPayload.CreateParameter(contentTypeColumnNames)
            )
        );
        var objectPath4 = requestPayload.Add(
            objectPath1,
            objectPathId => new ClientActionMethod(
                objectPathId,
                "Update",
                requestPayload.CreateParameter(pushChanges)
            )
        );
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public void SetObject(
        ContentTypeColumn contentTypeColumnObject,
        IReadOnlyDictionary<string, object> modificationInfo,
        bool pushChanges
    )
    {
        _ = contentTypeColumnObject ?? throw new ArgumentNullException(nameof(contentTypeColumnObject));
        _ = modificationInfo ?? throw new ArgumentNullException(nameof(modificationInfo));
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            new ObjectPathIdentity(string.Join(":", contentTypeColumnObject.ObjectIdentity.Split(':').SkipLast(2)))
        );
        var objectPath2 = requestPayload.Add(
            new ObjectPathIdentity(contentTypeColumnObject.ObjectIdentity)
        );
        var objectPath3 = requestPayload.Add(
            objectPath2,
            requestPayload.CreateSetPropertyDelegates(contentTypeColumnObject, modificationInfo).ToArray()
        );
        var objectPath4 = requestPayload.Add(
            objectPath1,
            objectPathId => new ClientActionMethod(
                objectPathId,
                "Update",
                requestPayload.CreateParameter(pushChanges)
            )
        );
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

}

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

public interface IDocumentSetAllowedContentTypeService
{

    void AddObject(ContentType contentTypeObject, ContentType allowedContentTypeObject, bool pushChanges);

    IEnumerable<ContentTypeId> GetObjectEnumerable(ContentType contentTypeObject);

    void RemoveObject(ContentType contentTypeObject, ContentType allowedContentTypeObject, bool pushChanges);

}

public class DocumentSetAllowedContentTypeService(ClientContext clientContext)
    : ClientService(clientContext), IDocumentSetAllowedContentTypeService
{

    public void AddObject(ContentType contentTypeObject, ContentType allowedContentTypeObject, bool pushChanges)
    {
        _ = contentTypeObject ?? throw new ArgumentNullException(nameof(contentTypeObject));
        _ = allowedContentTypeObject ?? throw new ArgumentNullException(nameof(allowedContentTypeObject));
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(new ObjectPathIdentity(contentTypeObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            new ObjectPathStaticMethod(
                typeof(DocumentSetTemplate),
                "GetDocumentSetTemplate",
                new ClientRequestParameterObjectPath(objectPath1)
            )
        );
        var objectPath3 = requestPayload.Add(new ObjectPathProperty(objectPath2.Id, "AllowedContentTypes"));
        var objectPath4 = requestPayload.Add(
            objectPath3,
            objectPathId => new ClientActionMethod(
                objectPathId,
                "Add",
                requestPayload.CreateParameter(allowedContentTypeObject.Id)
            )
        );
        var objectPath5 = requestPayload.Add(
            objectPath2,
            objectPathId => new ClientActionMethod(objectPathId, "Update", requestPayload.CreateParameter(pushChanges))
        );
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public IEnumerable<ContentTypeId> GetObjectEnumerable(ContentType contentTypeObject)
    {
        _ = contentTypeObject ?? throw new ArgumentNullException(nameof(contentTypeObject));
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(new ObjectPathIdentity(contentTypeObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            new ObjectPathStaticMethod(
                typeof(DocumentSetTemplate),
                "GetDocumentSetTemplate",
                new ClientRequestParameterObjectPath(objectPath1)
            )
        );
        var objectPath3 = requestPayload.Add(
            new ObjectPathProperty(objectPath2.Id, "AllowedContentTypes"),
            objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
            objectPathId => new ClientActionQuery(objectPathId)
            {
                Query = ClientQuery.Empty,
                ChildItemQuery = new ClientQuery(true, typeof(ContentTypeId))
            }
        );
        return this.ClientContext.ProcessQuery(requestPayload)
            .ToObject<AllowedContentTypeEnumerable>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public void RemoveObject(ContentType contentTypeObject, ContentType allowedContentTypeObject, bool pushChanges)
    {
        _ = contentTypeObject ?? throw new ArgumentNullException(nameof(contentTypeObject));
        _ = allowedContentTypeObject ?? throw new ArgumentNullException(nameof(allowedContentTypeObject));
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(new ObjectPathIdentity(contentTypeObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            new ObjectPathStaticMethod(
                typeof(DocumentSetTemplate),
                "GetDocumentSetTemplate",
                new ClientRequestParameterObjectPath(objectPath1)
            )
        );
        var objectPath3 = requestPayload.Add(new ObjectPathProperty(objectPath2.Id, "AllowedContentTypes"));
        var objectPath4 = requestPayload.Add(
            objectPath3,
            objectPathId => new ClientActionMethod(
                objectPathId,
                "Remove",
                requestPayload.CreateParameter(allowedContentTypeObject.Id)
            )
        );
        var objectPath5 = requestPayload.Add(
            objectPath2,
            objectPathId => new ClientActionMethod(objectPathId, "Update", requestPayload.CreateParameter(pushChanges))
        );
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

}

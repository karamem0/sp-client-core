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

public interface IDocumentSetDefaultDocumentService
{

    DefaultDocument AddObject(
        ContentType contentTypeObject,
        ContentType documentContentTypeObject,
        string fileName,
        byte[] fileContent,
        bool pushChanges
    );

    IEnumerable<DefaultDocument> GetObjectEnumerable(ContentType documentContentTypeObject);

    void RemoveObject(
        ContentType contentTypeObject,
        string fileName,
        bool pushChanges
    );

}

public class DocumentSetDefaultDocumentService(ClientContext clientContext) : ClientService(clientContext), IDocumentSetDefaultDocumentService
{

    public DefaultDocument AddObject(
        ContentType contentTypeObject,
        ContentType documentContentTypeObject,
        string fileName,
        byte[] fileContent,
        bool pushChanges
    )
    {
        _ = contentTypeObject ?? throw new ArgumentNullException(nameof(contentTypeObject));
        _ = documentContentTypeObject ?? throw new ArgumentNullException(nameof(documentContentTypeObject));
        _ = fileName ?? throw new ArgumentNullException(nameof(fileName));
        _ = fileContent ?? throw new ArgumentNullException(nameof(fileContent));
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(new ObjectPathIdentity(contentTypeObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            new ObjectPathStaticMethod(
                typeof(DocumentSetTemplate),
                "GetDocumentSetTemplate",
                new ClientRequestParameterObjectPath(objectPath1)
            )
        );
        var objectPath3 = requestPayload.Add(new ObjectPathProperty(objectPath2.Id, "DefaultDocuments"));
        var objectPath4 = requestPayload.Add(
            new ObjectPathMethod(
                objectPath3.Id,
                "Add",
                requestPayload.CreateParameter(fileName),
                requestPayload.CreateParameter(documentContentTypeObject.Id),
                requestPayload.CreateParameter(fileContent)
            ),
            objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
            objectPathId => new ClientActionQuery(objectPathId)
            {
                Query = new ClientQuery(true, typeof(DefaultDocument))
            }
        );
        var objectPath5 = requestPayload.Add(
            objectPath2,
            objectPathId => new ClientActionMethod(
                objectPathId,
                "Update",
                requestPayload.CreateParameter(pushChanges)
            )
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<DefaultDocument>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public IEnumerable<DefaultDocument> GetObjectEnumerable(ContentType documentContentTypeObject)
    {
        _ = documentContentTypeObject ?? throw new ArgumentNullException(nameof(documentContentTypeObject));
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(new ObjectPathIdentity(documentContentTypeObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            new ObjectPathStaticMethod(
                typeof(DocumentSetTemplate),
                "GetDocumentSetTemplate",
                new ClientRequestParameterObjectPath(objectPath1)
            )
        );
        var objectPath3 = requestPayload.Add(
            new ObjectPathProperty(objectPath2.Id, "DefaultDocuments"),
            objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
            objectPathId => new ClientActionQuery(objectPathId)
            {
                Query = ClientQuery.Empty,
                ChildItemQuery = new ClientQuery(true, typeof(DefaultDocument))
            }
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<DefaultDocumentEnumerable>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public void RemoveObject(
        ContentType contentTypeObject,
        string fileName,
        bool pushChanges
    )
    {
        _ = contentTypeObject ?? throw new ArgumentNullException(nameof(contentTypeObject));
        _ = fileName ?? throw new ArgumentNullException(nameof(fileName));
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(new ObjectPathIdentity(contentTypeObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            new ObjectPathStaticMethod(
                typeof(DocumentSetTemplate),
                "GetDocumentSetTemplate",
                new ClientRequestParameterObjectPath(objectPath1)
            )
        );
        var objectPath3 = requestPayload.Add(new ObjectPathProperty(objectPath2.Id, "DefaultDocuments"));
        var objectPath4 = requestPayload.Add(
            objectPath3,
            objectPathId => new ClientActionMethod(
                objectPathId,
                "Remove",
                requestPayload.CreateParameter(fileName)
            )
        );
        var objectPath5 = requestPayload.Add(
            objectPath2,
            objectPathId => new ClientActionMethod(
                objectPathId,
                "Update",
                requestPayload.CreateParameter(pushChanges)
            )
        );
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

}

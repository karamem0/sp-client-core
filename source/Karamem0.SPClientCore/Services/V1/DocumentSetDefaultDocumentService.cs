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

    DefaultDocument? AddObject(
        ContentType contentTypeObject,
        ContentType documentContentTypeObject,
        string fileName,
        byte[] fileContent,
        bool pushChanges
    );

    IEnumerable<DefaultDocument>? GetObjectEnumerable(ContentType documentContentTypeObject);

    void RemoveObject(
        ContentType contentTypeObject,
        string fileName,
        bool pushChanges
    );

}

public class DocumentSetDefaultDocumentService(ClientContext clientContext) : ClientService(clientContext), IDocumentSetDefaultDocumentService
{

    public DefaultDocument? AddObject(
        ContentType contentTypeObject,
        ContentType documentContentTypeObject,
        string fileName,
        byte[] fileContent,
        bool pushChanges
    )
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(contentTypeObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathStaticMethod.Create(
                typeof(DocumentSetTemplate),
                "GetDocumentSetTemplate",
                ClientRequestParameterObjectPath.Create(objectPath1)
            )
        );
        var objectPath3 = requestPayload.Add(ObjectPathProperty.Create(objectPath2.Id, "DefaultDocuments"));
        var objectPath4 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath3.Id,
                "Add",
                requestPayload.CreateParameter(fileName),
                requestPayload.CreateParameter(documentContentTypeObject.Id),
                requestPayload.CreateParameter(fileContent)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(DefaultDocument)))
        );
        var objectPath5 = requestPayload.Add(
            objectPath2,
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "Update",
                requestPayload.CreateParameter(pushChanges)
            )
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<DefaultDocument>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public IEnumerable<DefaultDocument>? GetObjectEnumerable(ContentType documentContentTypeObject)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(documentContentTypeObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathStaticMethod.Create(
                typeof(DocumentSetTemplate),
                "GetDocumentSetTemplate",
                ClientRequestParameterObjectPath.Create(objectPath1)
            )
        );
        var objectPath3 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath2.Id, "DefaultDocuments"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(
                objectPathId,
                ClientQuery.Empty,
                ClientQuery.Create(true, typeof(DefaultDocument))
            )
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
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(contentTypeObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathStaticMethod.Create(
                typeof(DocumentSetTemplate),
                "GetDocumentSetTemplate",
                ClientRequestParameterObjectPath.Create(objectPath1)
            )
        );
        var objectPath3 = requestPayload.Add(ObjectPathProperty.Create(objectPath2.Id, "DefaultDocuments"));
        var objectPath4 = requestPayload.Add(
            objectPath3,
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "Remove",
                requestPayload.CreateParameter(fileName)
            )
        );
        var objectPath5 = requestPayload.Add(
            objectPath2,
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "Update",
                requestPayload.CreateParameter(pushChanges)
            )
        );
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

}

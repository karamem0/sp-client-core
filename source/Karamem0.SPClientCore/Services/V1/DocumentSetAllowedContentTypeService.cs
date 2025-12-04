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

namespace Karamem0.SharePoint.PowerShell.Services.V1;

public interface IDocumentSetAllowedContentTypeService
{

    void AddObject(
        ContentType contentTypeObject,
        ContentType allowedContentTypeObject,
        bool pushChanges
    );

    IEnumerable<ContentTypeId>? GetObjectEnumerable(ContentType contentTypeObject);

    void RemoveObject(
        ContentType contentTypeObject,
        ContentType allowedContentTypeObject,
        bool pushChanges
    );

}

public class DocumentSetAllowedContentTypeService(ClientContext clientContext) : ClientService(clientContext), IDocumentSetAllowedContentTypeService
{

    public void AddObject(
        ContentType contentTypeObject,
        ContentType allowedContentTypeObject,
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
        var objectPath3 = requestPayload.Add(ObjectPathProperty.Create(objectPath2.Id, "AllowedContentTypes"));
        var objectPath4 = requestPayload.Add(
            objectPath3,
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "Add",
                requestPayload.CreateParameter(allowedContentTypeObject.Id)
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

    public IEnumerable<ContentTypeId>? GetObjectEnumerable(ContentType contentTypeObject)
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
        var objectPath3 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath2.Id, "AllowedContentTypes"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(
                objectPathId,
                ClientQuery.Empty,
                ClientQuery.Create(true, typeof(ContentTypeId))
            )
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<AllowedContentTypeEnumerable>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public void RemoveObject(
        ContentType contentTypeObject,
        ContentType allowedContentTypeObject,
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
        var objectPath3 = requestPayload.Add(ObjectPathProperty.Create(objectPath2.Id, "AllowedContentTypes"));
        var objectPath4 = requestPayload.Add(
            objectPath3,
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "Remove",
                requestPayload.CreateParameter(allowedContentTypeObject.Id)
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

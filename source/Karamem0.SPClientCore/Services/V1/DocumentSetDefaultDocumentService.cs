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

public interface IDocumentSetDefaultDocumentService
{

    Task<DefaultDocument?> AddObjectAsync(
        ContentType contentTypeObject,
        ContentType documentContentTypeObject,
        string fileName,
        byte[] fileContent,
        bool pushChanges,
        bool selectAllProperties = true
    );

    Task<IEnumerable<DefaultDocument>?> GetObjectEnumerableAsync(ContentType documentContentTypeObject, bool selectAllProperties = true);

    Task RemoveObjectAsync(
        ContentType contentTypeObject,
        string fileName,
        bool pushChanges
    );

}

public class DocumentSetDefaultDocumentService(ClientContext clientContext) : ClientService(clientContext), IDocumentSetDefaultDocumentService
{

    public async Task<DefaultDocument?> AddObjectAsync(
        ContentType contentTypeObject,
        ContentType documentContentTypeObject,
        string fileName,
        byte[] fileContent,
        bool pushChanges,
        bool selectAllProperties = true
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
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(DefaultDocument)))
        );
        var objectPath5 = requestPayload.Add(
            objectPath2,
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "Update",
                requestPayload.CreateParameter(pushChanges)
            )
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<DefaultDocument>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<IEnumerable<DefaultDocument>?> GetObjectEnumerableAsync(ContentType documentContentTypeObject, bool selectAllProperties = true)
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
                ClientQuery.Create(selectAllProperties, typeof(DefaultDocument))
            )
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<DefaultDocumentEnumerable>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task RemoveObjectAsync(
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
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

}

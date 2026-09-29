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

public interface IDocumentSetAllowedContentTypeService
{

    Task AddObjectAsync(
        ContentType contentTypeObject,
        ContentType allowedContentTypeObject,
        bool pushChanges
    );

    Task<IEnumerable<ContentTypeId>?> GetObjectEnumerableAsync(ContentType contentTypeObject, bool selectAllProperties = true);

    Task RemoveObjectAsync(
        ContentType contentTypeObject,
        ContentType allowedContentTypeObject,
        bool pushChanges
    );

}

public class DocumentSetAllowedContentTypeService(ClientContext clientContext) : ClientService(clientContext), IDocumentSetAllowedContentTypeService
{

    public async Task AddObjectAsync(
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
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

    public async Task<IEnumerable<ContentTypeId>?> GetObjectEnumerableAsync(ContentType contentTypeObject, bool selectAllProperties = true)
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
                ClientQuery.Create(selectAllProperties, typeof(ContentTypeId))
            )
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<AllowedContentTypeEnumerable>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task RemoveObjectAsync(
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
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

}

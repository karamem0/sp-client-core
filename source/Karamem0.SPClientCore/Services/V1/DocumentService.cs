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

public interface IDocumentService
{

    Task<ListItem?> AddObjectAsync(
        List listObject,
        string fileName,
        Folder folderObject,
        DocumentTemplateType documentTemplateType,
        bool selectAllProperties = true
    );

}

public class DocumentService(ClientContext clientContext) : ClientService(clientContext), IDocumentService
{

    public async Task<ListItem?> AddObjectAsync(
        List listObject,
        string fileName,
        Folder folderObject,
        DocumentTemplateType documentTemplateType,
        bool selectAllProperties = true
    )
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(listObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath1.Id,
                "CreateDocument",
                requestPayload.CreateParameter(fileName),
                requestPayload.CreateParameter(folderObject),
                requestPayload.CreateParameter(documentTemplateType)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(ListItem)))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<ListItem>(requestPayload.GetActionId<ClientActionQuery>()));
    }

}

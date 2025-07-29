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

public interface IDocumentService
{

    ListItem? AddObject(
        List listObject,
        string fileName,
        Folder folderObject,
        DocumentTemplateType documentTemplateType
    );

}

public class DocumentService(ClientContext clientContext) : ClientService(clientContext), IDocumentService
{

    public ListItem? AddObject(
        List listObject,
        string fileName,
        Folder folderObject,
        DocumentTemplateType documentTemplateType
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
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(ListItem)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<ListItem>(requestPayload.GetActionId<ClientActionQuery>());
    }

}

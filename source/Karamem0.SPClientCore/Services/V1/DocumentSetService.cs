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

public interface IDocumentSetService
{

    string AddObject(
        Folder folderObject,
        string documentSetName,
        ContentType contentTypeObject
    );

}

public class DocumentSetService(ClientContext clientContext) : ClientService(clientContext), IDocumentSetService
{

    public string AddObject(
        Folder folderObject,
        string documentSetName,
        ContentType contentTypeObject
    )
    {
        _ = folderObject ?? throw new ArgumentNullException(nameof(folderObject));
        _ = documentSetName ?? throw new ArgumentNullException(nameof(documentSetName));
        _ = contentTypeObject ?? throw new ArgumentNullException(nameof(contentTypeObject));
        var requestPayload = new ClientRequestPayload();
        requestPayload.Actions.Add(
            new ClientActionStaticMethod(
                typeof(DocumentSet),
                "Create",
                requestPayload.CreateParameter(folderObject),
                requestPayload.CreateParameter(documentSetName),
                requestPayload.CreateParameter(contentTypeObject.Id)
            )
        );
        return this.ClientContext
            .ProcessQuery(requestPayload)
            .ToObject<string>(requestPayload.GetActionId<ClientActionStaticMethod>());
    }

}

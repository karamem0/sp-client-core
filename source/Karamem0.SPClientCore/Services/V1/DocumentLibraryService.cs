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

public interface IDocumentLibraryService
{

    DocumentLibraryInfo GetObject();

    IEnumerable<DocumentLibraryInfo> GetObjectEnumerable();

    IEnumerable<DocumentLibraryInfo> GetObjectEnumerable(bool includePageLibraries);

}

public class DocumentLibraryService(ClientContext clientContext) : ClientService(clientContext), IDocumentLibraryService
{

    public DocumentLibraryInfo GetObject()
    {
        var requestPayload = new ClientRequestPayload();
        requestPayload.Actions.Add(
            new ClientActionStaticMethod(
                typeof(Site),
                "DefaultDocumentLibraryUrl",
                requestPayload.CreateParameter(this.ClientContext.BaseAddress)
            )
        );
        return this.ClientContext.ProcessQuery(requestPayload)
            .ToObject<DocumentLibraryInfo>(requestPayload.GetActionId<ClientActionStaticMethod>());
    }

    public IEnumerable<DocumentLibraryInfo> GetObjectEnumerable()
    {
        var requestPayload = new ClientRequestPayload();
        requestPayload.Actions.Add(
            new ClientActionStaticMethod(
                typeof(Site),
                "GetDocumentLibraries",
                requestPayload.CreateParameter(this.ClientContext.BaseAddress)
            )
        );
        return this.ClientContext.ProcessQuery(requestPayload)
            .ToObject<List<DocumentLibraryInfo>>(requestPayload.GetActionId<ClientActionStaticMethod>());
    }

    public IEnumerable<DocumentLibraryInfo> GetObjectEnumerable(bool includePageLibraries)
    {
        var requestPayload = new ClientRequestPayload();
        requestPayload.Actions.Add(
            new ClientActionStaticMethod(
                typeof(Site),
                "GetDocumentAndMediaLibraries",
                requestPayload.CreateParameter(this.ClientContext.BaseAddress),
                requestPayload.CreateParameter(includePageLibraries)
            )
        );
        return this.ClientContext.ProcessQuery(requestPayload)
            .ToObject<List<DocumentLibraryInfo>>(requestPayload.GetActionId<ClientActionStaticMethod>());
    }

}

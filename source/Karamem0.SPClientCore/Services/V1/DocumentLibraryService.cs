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

public interface IDocumentLibraryService
{

    Task<DocumentLibraryInfo?> GetObjectAsync();

    Task<IEnumerable<DocumentLibraryInfo>?> GetObjectEnumerableAsync();

    Task<IEnumerable<DocumentLibraryInfo>?> GetObjectEnumerableAsync(bool includePageLibraries);

}

public class DocumentLibraryService(ClientContext clientContext) : ClientService(clientContext), IDocumentLibraryService
{

    public async Task<DocumentLibraryInfo?> GetObjectAsync()
    {
        var requestPayload = new ClientRequestPayload();
        requestPayload.Actions.Add(
            ClientActionStaticMethod.Create(
                typeof(Site),
                "DefaultDocumentLibraryUrl",
                requestPayload.CreateParameter(this.ClientContext.BaseAddress)
            )
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<DocumentLibraryInfo>(requestPayload.GetActionId<ClientActionStaticMethod>()));
    }

    public async Task<IEnumerable<DocumentLibraryInfo>?> GetObjectEnumerableAsync()
    {
        var requestPayload = new ClientRequestPayload();
        requestPayload.Actions.Add(
            ClientActionStaticMethod.Create(
                typeof(Site),
                "GetDocumentLibraries",
                requestPayload.CreateParameter(this.ClientContext.BaseAddress)
            )
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<List<DocumentLibraryInfo>>(requestPayload.GetActionId<ClientActionStaticMethod>()));
    }

    public async Task<IEnumerable<DocumentLibraryInfo>?> GetObjectEnumerableAsync(bool includePageLibraries)
    {
        var requestPayload = new ClientRequestPayload();
        requestPayload.Actions.Add(
            ClientActionStaticMethod.Create(
                typeof(Site),
                "GetDocumentAndMediaLibraries",
                requestPayload.CreateParameter(this.ClientContext.BaseAddress),
                requestPayload.CreateParameter(includePageLibraries)
            )
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<List<DocumentLibraryInfo>>(requestPayload.GetActionId<ClientActionStaticMethod>()));
    }

}

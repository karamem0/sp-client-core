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

public interface ITenantFileVersionPolicyForDocumentLibraryService
{

    Task<FileVersionPolicyForDocumentLibrary?> GetObjectAsync(Uri siteUrl, Guid listId);

    Task<FileVersionPolicyForDocumentLibrary?> GetObjectAsync(Uri siteUrl, string listTitle);

    Task<TenantOperationResult?> SetObjectAsync(
        Uri siteUrl,
        Guid listId,
        IReadOnlyDictionary<string, object?> modificationInfo,
        bool selectAllProperties = true
    );

    Task<TenantOperationResult?> SetObjectAsync(
        Uri siteUrl,
        string listTitle,
        IReadOnlyDictionary<string, object?> modificationInfo,
        bool selectAllProperties = true
    );

    Task SetObjectAwaitAsync(
        Uri siteUrl,
        Guid listId,
        IReadOnlyDictionary<string, object?> modificationInfo
    );

    Task SetObjectAwaitAsync(
        Uri siteUrl,
        string listTitle,
        IReadOnlyDictionary<string, object?> modificationInfo
    );

}

public class TenantFileVersionPolicyForDocumentLibraryService(ClientContext clientContext)
    : TenantClientService(clientContext), ITenantFileVersionPolicyForDocumentLibraryService
{

    public async Task<FileVersionPolicyForDocumentLibrary?> GetObjectAsync(Uri siteUrl, Guid listId)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathConstructor.Create(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(
            objectPath1,
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "GetFileVersionPolicyForLibrary",
                requestPayload.CreateParameter(siteUrl),
                requestPayload.CreateParameter(new ListParameters(id: listId))
            )
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<FileVersionPolicyForDocumentLibrary>(requestPayload.GetActionId<ClientActionMethod>()));
    }

    public async Task<FileVersionPolicyForDocumentLibrary?> GetObjectAsync(Uri siteUrl, string listTitle)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathConstructor.Create(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(
            objectPath1,
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "GetFileVersionPolicyForLibrary",
                requestPayload.CreateParameter(siteUrl),
                requestPayload.CreateParameter(new ListParameters(title: listTitle))
            )
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<FileVersionPolicyForDocumentLibrary>(requestPayload.GetActionId<ClientActionMethod>()));
    }

    public async Task<TenantOperationResult?> SetObjectAsync(
        Uri siteUrl,
        Guid listId,
        IReadOnlyDictionary<string, object?> modificationInfo,
        bool selectAllProperties = true
    )
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathConstructor.Create(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath1.Id,
                "SetFileVersionPolicyForLibrary",
                requestPayload.CreateParameter(siteUrl),
                requestPayload.CreateParameter(new ListParameters(id: listId)),
                requestPayload.CreateParameter(ClientValueObject.Create<FileVersionPolicyForDocumentLibrary>(modificationInfo))
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(TenantOperationResult)))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<TenantOperationResult>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<TenantOperationResult?> SetObjectAsync(
        Uri siteUrl,
        string listTitle,
        IReadOnlyDictionary<string, object?> modificationInfo,
        bool selectAllProperties = true
    )
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathConstructor.Create(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath1.Id,
                "SetFileVersionPolicyForLibrary",
                requestPayload.CreateParameter(siteUrl),
                requestPayload.CreateParameter(new ListParameters(title: listTitle)),
                requestPayload.CreateParameter(ClientValueObject.Create<FileVersionPolicyForDocumentLibrary>(modificationInfo))
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(TenantOperationResult)))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<TenantOperationResult>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task SetObjectAwaitAsync(
        Uri siteUrl,
        Guid listId,
        IReadOnlyDictionary<string, object?> modificationInfo
    )
    {
        await this.WaitObjectAsync(
            await this.SetObjectAsync(
                siteUrl,
                listId,
                modificationInfo
            )
        );
    }

    public async Task SetObjectAwaitAsync(
        Uri siteUrl,
        string listTitle,
        IReadOnlyDictionary<string, object?> modificationInfo
    )
    {
        await this.WaitObjectAsync(
            await this.SetObjectAsync(
                siteUrl,
                listTitle,
                modificationInfo
            )
        );
    }

}

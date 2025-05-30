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

public interface ITenantFileVersionPolicyForDocumentLibraryService
{

    FileVersionPolicyForDocumentLibrary? GetObject(Uri siteUrl, Guid listId);

    FileVersionPolicyForDocumentLibrary? GetObject(Uri siteUrl, string listTitle);

    TenantOperationResult? SetObject(
        Uri siteUrl,
        Guid listId,
        IReadOnlyDictionary<string, object?> modificationInfo
    );

    TenantOperationResult? SetObject(
        Uri siteUrl,
        string listTitle,
        IReadOnlyDictionary<string, object?> modificationInfo
    );

    void SetObjectAwait(
        Uri siteUrl,
        Guid listId,
        IReadOnlyDictionary<string, object?> modificationInfo
    );

    void SetObjectAwait(
        Uri siteUrl,
        string listTitle,
        IReadOnlyDictionary<string, object?> modificationInfo
    );

}

public class TenantFileVersionPolicyForDocumentLibraryService(ClientContext clientContext)
    : TenantClientService(clientContext), ITenantFileVersionPolicyForDocumentLibraryService
{

    public FileVersionPolicyForDocumentLibrary? GetObject(Uri siteUrl, Guid listId)
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
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<FileVersionPolicyForDocumentLibrary>(requestPayload.GetActionId<ClientActionMethod>());
    }

    public FileVersionPolicyForDocumentLibrary? GetObject(Uri siteUrl, string listTitle)
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
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<FileVersionPolicyForDocumentLibrary>(requestPayload.GetActionId<ClientActionMethod>());
    }

    public TenantOperationResult? SetObject(
        Uri siteUrl,
        Guid listId,
        IReadOnlyDictionary<string, object?> modificationInfo
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
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(TenantOperationResult)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<TenantOperationResult>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public TenantOperationResult? SetObject(
        Uri siteUrl,
        string listTitle,
        IReadOnlyDictionary<string, object?> modificationInfo
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
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(TenantOperationResult)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<TenantOperationResult>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public void SetObjectAwait(
        Uri siteUrl,
        Guid listId,
        IReadOnlyDictionary<string, object?> modificationInfo
    )
    {
        this.WaitObject(
            this.SetObject(
                siteUrl,
                listId,
                modificationInfo
            )
        );
    }

    public void SetObjectAwait(
        Uri siteUrl,
        string listTitle,
        IReadOnlyDictionary<string, object?> modificationInfo
    )
    {
        this.WaitObject(
            this.SetObject(
                siteUrl,
                listTitle,
                modificationInfo
            )
        );
    }

}

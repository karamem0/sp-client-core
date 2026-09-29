//
// Copyright (c) 2018-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Resources;
using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Karamem0.SharePoint.PowerShell.Runtime.Services;

namespace Karamem0.SharePoint.PowerShell.Services.V1;

public interface IFileVersionService
{

    Task<FileVersion?> GetObjectAsync(FileVersion fileVersionObject);

    Task<FileVersion?> GetObjectAsync(FileVersion fileVersionObject, bool selectAllProperties = true);

    Task<FileVersion?> GetObjectAsync(
        File fileObject,
        int fileVersionId,
        bool selectAllProperties = true
    );

    Task<IEnumerable<FileVersion>?> GetObjectEnumerableAsync(File fileObject, bool selectAllProperties = true);

    Task RecycleObjectAsync(FileVersion fileVersionObject);

    Task RemoveObjectAsync(FileVersion fileVersionObject);

    Task RemoveObjectAllAsync(File fileObject);

    Task RestoreObjectAsync(FileVersion fileVersionObject);

}

public class FileVersionService(ClientContext clientContext) : ClientService<FileVersion>(clientContext), IFileVersionService
{

    public async Task<FileVersion?> GetObjectAsync(
        File fileObject,
        int fileVersionId,
        bool selectAllProperties = true
    )
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(fileObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Versions"));
        var objectPath3 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath2.Id,
                "GetById",
                requestPayload.CreateParameter(fileVersionId)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(FileVersion)))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<FileVersion>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<IEnumerable<FileVersion>?> GetObjectEnumerableAsync(File fileObject, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(fileObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath1.Id, "Versions"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(
                objectPathId,
                ClientQuery.Empty,
                ClientQuery.Create(selectAllProperties, typeof(FileVersion))
            )
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<FileVersionEnumerable>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task RecycleObjectAsync(FileVersion fileVersionObject)
    {
        var objectIdentity = fileVersionObject.ObjectIdentity;
        _ = objectIdentity ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            ObjectPathIdentity.Create(
                string.Join(
                    ":",
                    objectIdentity
                        .Split(':')
                        .SkipLast(2)
                )
            ),
            ClientActionInstantiateObjectPath.Create
        );
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Versions"));
        var objectPath3 = requestPayload.Add(
            objectPath2,
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "RecycleByLabel",
                requestPayload.CreateParameter(fileVersionObject.VersionLabel)
            )
        );
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

    public override async Task RemoveObjectAsync(FileVersion fileVersionObject)
    {
        var objectIdentity = fileVersionObject.ObjectIdentity;
        _ = objectIdentity ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            ObjectPathIdentity.Create(
                string.Join(
                    ":",
                    objectIdentity
                        .Split(':')
                        .SkipLast(2)
                )
            )
        );
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Versions"));
        var objectPath3 = requestPayload.Add(
            objectPath2,
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "DeleteByLabel",
                requestPayload.CreateParameter(fileVersionObject.VersionLabel)
            )
        );
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

    public async Task RemoveObjectAllAsync(File fileObject)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(fileObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Versions"));
        var objectPath3 = requestPayload.Add(objectPath2, objectPathId => ClientActionMethod.Create(objectPathId, "DeleteAll"));
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

    public async Task RestoreObjectAsync(FileVersion fileVersionObject)
    {
        var objectIdentity = fileVersionObject.ObjectIdentity;
        _ = objectIdentity ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            ObjectPathIdentity.Create(
                string.Join(
                    ":",
                    objectIdentity
                        .Split(':')
                        .SkipLast(2)
                )
            )
        );
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Versions"));
        var objectPath3 = requestPayload.Add(
            objectPath2,
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "RestoreByLabel",
                requestPayload.CreateParameter(fileVersionObject.VersionLabel)
            )
        );
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

}

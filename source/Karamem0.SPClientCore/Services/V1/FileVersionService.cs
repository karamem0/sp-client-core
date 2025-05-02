//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Resources;
using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Karamem0.SharePoint.PowerShell.Runtime.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Services.V1;

public interface IFileVersionService
{

    FileVersion? GetObject(FileVersion fileVersionObject);

    FileVersion? GetObject(File fileObject, int fileVersionId);

    IEnumerable<FileVersion>? GetObjectEnumerable(File fileObject);

    void RecycleObject(FileVersion fileVersionObject);

    void RemoveObject(FileVersion fileVersionObject);

    void RemoveObjectAll(File fileObject);

    void RestoreObject(FileVersion fileVersionObject);

}

public class FileVersionService(ClientContext clientContext) : ClientService<FileVersion>(clientContext), IFileVersionService
{

    public FileVersion? GetObject(File fileObject, int fileVersionId)
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
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(FileVersion)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<FileVersion>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public IEnumerable<FileVersion>? GetObjectEnumerable(File fileObject)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(fileObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath1.Id, "Versions"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(
                objectPathId,
                ClientQuery.Empty,
                ClientQuery.Create(true, typeof(FileVersion))
            )
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<FileVersionEnumerable>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public void RecycleObject(FileVersion fileVersionObject)
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
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public override void RemoveObject(FileVersion fileVersionObject)
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
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public void RemoveObjectAll(File fileObject)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(fileObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Versions"));
        var objectPath3 = requestPayload.Add(objectPath2, objectPathId => ClientActionMethod.Create(objectPathId, "DeleteAll"));
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public void RestoreObject(FileVersion fileVersionObject)
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
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

}
